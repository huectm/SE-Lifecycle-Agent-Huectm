using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

MSBuildLocator.RegisterDefaults();
await Extract(args.Length>0?Path.GetFullPath(args[0]):Directory.GetCurrentDirectory());

static async Task Extract(string root)
{
    using var workspace=MSBuildWorkspace.Create(new Dictionary<string,string>{{"RunAnalyzers","false"},{"SonarQubeExclude","true"}});
    var loadDiagnostics=new List<string>();
    workspace.WorkspaceFailed+=(_,e)=>loadDiagnostics.Add(e.Diagnostic.ToString());
    var solution=await workspace.OpenSolutionAsync(Path.Combine(root,"src/FreshFood.sln"));
    var classes=new List<object>();var calls=new List<object>();var compileErrors=new List<string>();
    foreach(var project in solution.Projects.Where(p=>p.Name is "FreshFood-API" or "FreshFood.Reposistory"))
    {
        var compilation=(await project.GetCompilationAsync())!;
        compileErrors.AddRange(compilation.GetDiagnostics().Where(d=>d.Severity==DiagnosticSeverity.Error).Select(d=>d.ToString()));
        var found=new HashSet<ISymbol>(SymbolEqualityComparer.Default);
        foreach(var document in project.Documents)
        {
            if(document.FilePath is null||document.FilePath.Contains(Path.DirectorySeparatorChar+"obj"+Path.DirectorySeparatorChar))continue;
            var syntax=await document.GetSyntaxRootAsync();if(syntax is null)continue;
            var semantic=await document.GetSemanticModelAsync();if(semantic is null)continue;
            var file=Path.GetRelativePath(root,document.FilePath).Replace('\\','/');
            foreach(var declaration in syntax.DescendantNodes().OfType<BaseTypeDeclarationSyntax>())
            {
                if(semantic.GetDeclaredSymbol(declaration) is not INamedTypeSymbol type||!found.Add(type))continue;
                var methods=type.GetMembers().OfType<IMethodSymbol>().Where(s=>!s.IsImplicitlyDeclared && s.MethodKind is MethodKind.Ordinary or MethodKind.Constructor or MethodKind.StaticConstructor).ToList();
                classes.Add(new{name=type.Name,fullName=type.ToDisplayString(),project=project.Name,kind=type.TypeKind.ToString(),accessibility=type.DeclaredAccessibility.ToString(),file,line=Line(declaration),sha256=Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(document.FilePath))),interfaces=type.AllInterfaces.Select(t=>t.Name).ToArray(),
                    methods=methods.Select(m=>new{name=m.MethodKind==MethodKind.Constructor?type.Name:m.Name,arity=m.Arity,accessibility=m.DeclaredAccessibility.ToString(),isStatic=m.IsStatic,isConstructor=m.MethodKind==MethodKind.Constructor,parameters=m.Parameters.Select(p=>new{name=p.Name,type=TypeName(p.Type),optional=p.IsOptional,refKind=p.RefKind.ToString()}).ToArray(),returnType=m.MethodKind==MethodKind.Constructor?"":TypeName(m.ReturnType),file=SymbolFile(m,root),line=SymbolLine(m)}).ToArray(),
                    properties=type.GetMembers().OfType<IPropertySymbol>().Where(p=>!p.IsImplicitlyDeclared).Select(p=>new{name=p.Name,type=TypeName(p.Type),accessibility=p.DeclaredAccessibility.ToString(),setter=p.SetMethod?.DeclaredAccessibility.ToString(),isReadOnly=p.IsReadOnly,file=SymbolFile(p,root),line=SymbolLine(p)}).ToArray()});
            }
            foreach(var invocation in syntax.DescendantNodes().OfType<InvocationExpressionSyntax>())
            {
                var info=semantic.GetSymbolInfo(invocation);var method=info.Symbol as IMethodSymbol;
                var callerNode=invocation.Ancestors().FirstOrDefault(n=>n is BaseMethodDeclarationSyntax or LocalFunctionStatementSyntax);
                var caller=callerNode is null?null:semantic.GetDeclaredSymbol(callerNode) as IMethodSymbol;
                if(caller is null)continue;
                var member=invocation.Expression as MemberAccessExpressionSyntax;
                var receiverType=method?.ContainingType;
                var isProject=receiverType?.ContainingAssembly.Name is "FreshFood-API" or "FreshFood.Reposistory";
                calls.Add(new{callerType=caller.ContainingType.Name,callerMethod=caller.Name,receiverType=receiverType?.Name,receiverFullType=receiverType?.ToDisplayString(),receiverExpression=member?.Expression.ToString(),method=method?.Name??invocation.Expression.ToString(),arity=method?.Arity??0,argumentExpressions=invocation.ArgumentList.Arguments.Select(a=>a.Expression.ToString()).ToArray(),argumentTypes=invocation.ArgumentList.Arguments.Select(a=>TypeName(semantic.GetTypeInfo(a.Expression).Type)).ToArray(),formalParameters=method?.Parameters.Select(p=>new{name=p.Name,type=TypeName(p.Type)}).ToArray(),returnType=TypeName(method?.ReturnType),projectInternal=isProject,file,line=Line(invocation),resolved=method is not null,text=invocation.ToString()});
            }
        }
    }
    if (Environment.GetEnvironmentVariable("FRESHFOOD_UNIT_DESIGN") == "1") await UnitTestInventory.Export(solution, root);
    var output=Path.Combine(root,"artifacts/design/detailed/source-consistency-symbols.json");
    await File.WriteAllTextAsync(output,JsonSerializer.Serialize(new{date=DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).ToString("yyyy-MM-dd"),method="Roslyn MSBuildWorkspace semantic symbols and invocation binding",loadDiagnostics,compileErrors,classes,calls},new JsonSerializerOptions{WriteIndented=true}));
    Console.WriteLine($"Extracted {classes.Count} source types and {calls.Count} bound invocation records; compilation errors={compileErrors.Count}; workspace diagnostics={loadDiagnostics.Count}");
    if(compileErrors.Count>0)Environment.ExitCode=2;
}
static int Line(SyntaxNode n)=>n.GetLocation().GetLineSpan().StartLinePosition.Line+1;
static string TypeName(ITypeSymbol? type)=>type?.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.UseSpecialTypes|SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier))??"?";
static string SymbolFile(ISymbol symbol,string root)=>symbol.Locations.FirstOrDefault(l=>l.IsInSource)?.SourceTree?.FilePath is string path?Path.GetRelativePath(root,path).Replace('\\','/'):"";
static int SymbolLine(ISymbol symbol)=>symbol.Locations.FirstOrDefault(l=>l.IsInSource)?.GetLineSpan().StartLinePosition.Line+1??0;
