param(
    [string]$ServerUrl = 'http://localhost:9000',
    [string]$ProjectKey = 'freshfood-backend-five-use-cases',
    [string]$Organization = '',
    [switch]$BootstrapLocalServer,
    [switch]$ResumeAfterBuild
)
$ErrorActionPreference = 'Stop'
$root = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
Set-Location -LiteralPath $root
$output = Join-Path $root 'artifacts/analysis/sonarqube'
New-Item -ItemType Directory -Force -Path $output | Out-Null
$scanner = Join-Path $root 'scratch/sonar-tools/dotnet-sonarscanner.exe'
$coverageTool = Join-Path $root 'scratch/sonar-tools/dotnet-coverage.exe'
$env:DOTNET_ROLL_FORWARD = 'LatestMajor'
if (!(Test-Path -LiteralPath $scanner)) { throw 'Install dotnet-sonarscanner into scratch/sonar-tools first.' }
if (!(Test-Path -LiteralPath $coverageTool)) { throw 'Install dotnet-coverage into scratch/sonar-tools first.' }

function Request-Sonar([string]$Path, [string]$Method = 'Get', [hashtable]$Body = @{}) {
    $arguments = @{ Uri = $ServerUrl.TrimEnd('/') + $Path; Method = $Method; TimeoutSec = 60 }
    if ($script:headers) { $arguments.Headers = $script:headers }
    if ($Method -eq 'Post') { $arguments.Body = $Body }
    Invoke-RestMethod @arguments
}
function Set-BasicAuthorization([string]$User, [string]$Password) {
    $bytes = [Text.Encoding]::UTF8.GetBytes($User + ':' + $Password)
    $script:headers = @{ Authorization = 'Basic ' + [Convert]::ToBase64String($bytes) }
}
if ($BootstrapLocalServer) {
    if ($ServerUrl -ne 'http://localhost:9000') { throw 'Bootstrap is restricted to the newly created local server.' }
    $credentialPath = Join-Path $root 'scratch/sonarqube-review-admin.credential.xml'
    if (Test-Path -LiteralPath $credentialPath) {
        $credential = Import-Clixml -LiteralPath $credentialPath
        Set-BasicAuthorization 'admin' $credential.GetNetworkCredential().Password
    } else {
        $password = [Guid]::NewGuid().ToString('N') + [Guid]::NewGuid().ToString('N')
        Set-BasicAuthorization 'admin' 'admin'
        $null = Request-Sonar '/api/users/change_password' 'Post' @{ login = 'admin'; previousPassword = 'admin'; password = $password }
        $secure = ConvertTo-SecureString $password -AsPlainText -Force
        $credential = New-Object System.Management.Automation.PSCredential ('admin', $secure)
        $credential | Export-Clixml -LiteralPath $credentialPath
        Set-BasicAuthorization 'admin' $password
        $password = $null
    }
    $search = Request-Sonar ('/api/projects/search?projects=' + [Uri]::EscapeDataString($ProjectKey))
    if ($search.components.Count -eq 0) {
        $null = Request-Sonar '/api/projects/create' 'Post' @{ project = $ProjectKey; name = 'FreshFood C# Backend Five Use Cases'; visibility = 'public' }
    }
    $tokenResult = Request-Sonar '/api/user_tokens/generate' 'Post' @{ name = 'freshfood-review-' + [Guid]::NewGuid().ToString('N'); type = 'PROJECT_ANALYSIS_TOKEN'; projectKey = $ProjectKey }
    $env:SONAR_TOKEN = $tokenResult.token
}
if ([string]::IsNullOrWhiteSpace($env:SONAR_TOKEN)) { throw 'Set SONAR_TOKEN in the process environment. Never put it in committed configuration.' }
if (!$BootstrapLocalServer) { Set-BasicAuthorization $env:SONAR_TOKEN '' }

function Save-RedactedLog($Lines, [string]$Name) {
    $Lines | ForEach-Object { $_.ToString().Replace($env:SONAR_TOKEN, '[REDACTED]') } |
        Set-Content -LiteralPath (Join-Path $output $Name) -Encoding UTF8
}

$begin = @('begin', ('/k:' + $ProjectKey), '/v:dotnet-0.5',
    ('/d:sonar.host.url=' + $ServerUrl), ('/d:sonar.token=' + $env:SONAR_TOKEN),
    '/d:sonar.scanner.scanAll=false', ('/d:sonar.projectBaseDir=' + $root),
    '/d:sonar.inclusions=src/FreshFood-API/**/*.cs,src/FreshFood.Reposistory/**/*.cs,src/Tests/Backend/**/*.cs',
    '/d:sonar.exclusions=**/bin/**,**/obj/**',
    '/d:sonar.cs.vscoveragexml.reportsPaths=artifacts/analysis/sonarqube/coverage.xml')
if ($Organization) { $begin += '/o:' + $Organization }
if (!$ResumeAfterBuild) {
$beginLog = & $scanner @begin 2>&1
$beginExit = $LASTEXITCODE
Save-RedactedLog $beginLog 'scanner-begin.txt'
if ($beginExit -ne 0) { throw 'SonarScanner begin failed. Check scanner-begin.txt; no Quality Gate result exists.' }
Write-Output 'Sonar begin completed. Building with Sonar analyzers; warnings are captured as findings, not suppressed.'
$buildLog = & dotnet build src/FreshFood.sln --configuration Release --no-incremental --disable-build-servers /p:TreatWarningsAsErrors=false 2>&1
$buildExit = $LASTEXITCODE
Save-RedactedLog $buildLog 'build-analysis.txt'
if ($buildExit -ne 0) { throw 'Analysis build failed. Check build-analysis.txt.' }
}
Write-Output 'Analysis build completed. Collecting actual test coverage.'
$testCommand = 'dotnet test src/FreshFood.sln --configuration Release --no-build --no-restore --logger trx --results-directory artifacts/analysis/sonarqube/tests'
$ErrorActionPreference = 'Continue'
$testLog = & $coverageTool collect $testCommand --output-format xml --output (Join-Path $output 'coverage.xml') 2>&1
$testExit = $LASTEXITCODE
$ErrorActionPreference = 'Stop'
Save-RedactedLog $testLog 'test-coverage.txt'
$ErrorActionPreference = 'Continue'
$endLog = & $scanner end ('/d:sonar.token=' + $env:SONAR_TOKEN) 2>&1
$endExit = $LASTEXITCODE
$ErrorActionPreference = 'Stop'
Save-RedactedLog $endLog 'scanner-end.txt'
if ($endExit -ne 0) { throw 'SonarScanner upload failed. Check scanner-end.txt.' }
Write-Output 'Analysis submitted. Waiting for the server task.'

$taskFile = Join-Path $root '.sonarqube/out/.sonar/report-task.txt'
if (!(Test-Path -LiteralPath $taskFile)) { throw 'Sonar report-task.txt is missing.' }
$taskProperties = @{}
Get-Content -LiteralPath $taskFile | ForEach-Object { $key, $value = $_ -split '=', 2; $taskProperties[$key] = $value }
$deadline = (Get-Date).AddMinutes(5)
do {
    $task = Request-Sonar ('/api/ce/task?id=' + $taskProperties.ceTaskId)
    if ($task.task.status -in @('SUCCESS', 'FAILED', 'CANCELED')) { break }
    Start-Sleep -Seconds 3
} while ((Get-Date) -lt $deadline)
if ($task.task.status -ne 'SUCCESS') { throw ('Sonar server task did not succeed: ' + $task.task.status) }
$gate = Request-Sonar ('/api/qualitygates/project_status?analysisId=' + $task.task.analysisId)
$metrics = Request-Sonar ('/api/measures/component?component=' + [Uri]::EscapeDataString($ProjectKey) + '&metricKeys=bugs,vulnerabilities,code_smells,security_hotspots,ncloc,coverage,duplicated_lines_density,sqale_rating,reliability_rating,security_rating')
$allIssues = @(); $page = 1
do {
    $batch = Request-Sonar ('/api/issues/search?componentKeys=' + [Uri]::EscapeDataString($ProjectKey) + '&resolved=false&ps=500&p=' + $page)
    $allIssues += $batch.issues; $page++
} while ($allIssues.Count -lt $batch.paging.total)
$hotspots = Request-Sonar ('/api/hotspots/search?projectKey=' + [Uri]::EscapeDataString($ProjectKey) + '&ps=500')
try { $status = Request-Sonar '/api/system/status' } catch { $status = @{ version = 'SonarQube Cloud' } }
$gate | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath (Join-Path $output 'quality-gate.json') -Encoding UTF8
$metrics | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath (Join-Path $output 'metrics.json') -Encoding UTF8
@{ issues = $allIssues; total = $allIssues.Count } | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath (Join-Path $output 'issues.json') -Encoding UTF8
$hotspots | ConvertTo-Json -Depth 30 | Set-Content -LiteralPath (Join-Path $output 'hotspots.json') -Encoding UTF8
$manifest = Get-ChildItem -LiteralPath (Join-Path $root 'src/FreshFood-API'),(Join-Path $root 'src/FreshFood.Reposistory') -Filter '*.cs' -Recurse | Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' } | ForEach-Object { @{ path = $_.FullName.Substring($root.Length + 1); sha256 = (Get-FileHash -LiteralPath $_.FullName -Algorithm SHA256).Hash } }
@{ date = '2026-11-02'; projectKey = $ProjectKey; serverVersion = $status.version; scannerVersion = '12.0.0'; analysisId = $task.task.analysisId; dashboard = $taskProperties.dashboardUrl; testExitCode = $testExit; qualityGate = $gate.projectStatus.status; source = $manifest } | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath (Join-Path $output 'analysis-run.json') -Encoding UTF8
Write-Output ('Sonar Quality Gate: ' + $gate.projectStatus.status + '; issues: ' + $allIssues.Count + '; hotspots: ' + $hotspots.paging.total + '; test exit: ' + $testExit)
Write-Output ('Dashboard: ' + $taskProperties.dashboardUrl)
