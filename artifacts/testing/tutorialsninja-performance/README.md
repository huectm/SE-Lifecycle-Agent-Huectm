# Registration Performance Test Plan and Execution Record

Date: 2026-10-28. Status: Draft for QA / authorized owner review.
Requested system: https://tutorialsninja.com/demo/index.php?route=account/register

## Authorization and execution boundary

The user explicitly confirmed that permission to load/stress test the public target is not available. **No performance or stress traffic was sent to TutorialsNinja in this task.** All ten target cases are NOT EXECUTED. The supplied JMX contains only a literal loopback host, `127.0.0.1`. Its execution uses a temporary local HTTP mock. Local results are not evidence about TutorialsNinja and must not be substituted into the target case results.

## Requirements and workload interpretation

| Local trace ID | User requirement | Verification |
|---|---|---|
| PERF-REQ-01 | At least 1000 users/day | PERF-02; distinct sessions and successful outcomes counted over the full operating window |
| PERF-REQ-02 | Operate from 06:00 to 24:00 | PERF-02 and PERF-09; full 18-hour observation; service timezone requires confirmation |
| PERF-REQ-03 | Support up to 100 concurrent users | PERF-03, PERF-04, PERF-05, PERF-08 and PERF-10 |
| PERF-REQ-04 | Average response time strictly below 6 seconds | PERF-01 through PERF-05, PERF-08 and PERF-10, evaluated separately per workload/window |

These are local identifiers for the supplied request, not invented approved project NFR identifiers. All ten detailed cases are in `performance-test-cases.csv` and `Performance_Test_Cases.xls` (instantiated from `templates/Test Documents/Preformance_Test case.xls`). Cases PERF-06 and PERF-07 characterize stress and recovery; the user did not specify a response-time guarantee above 100 users or a recovery-time threshold.

An 18-hour window is 64800 seconds. Uniform arrivals of 1000 users imply 55.56 users/hour, 0.92593 users/minute, 0.015432 users/second, or a mean arrival interval of 64.8 seconds. Daily volume and concurrent occupancy are different requirements. User counts do not establish requests/second or registrations/day without a journey model. Proposed conservative journey: one registration attempt per user; confirm whether the 1000 users refer to all site users or registration users. Proposed think time, traffic mix, durations, ramp-up and stress ceiling are engineering test settings pending owner approval, not business requirements.

## Measurement and test data

Define a registration transaction as loading the form then submitting valid data through the success response, including redirects. Report GET form time and POST-to-success time separately as well. HTTP timings exclude browser rendering and embedded resource download in the local harness. Confirm whether the requested SLA concerns HTTP latency, the complete transaction, or browser-perceived completion before acceptance testing. Do not add user think time or pacing to measured response time.

Calculate arithmetic mean from measured transaction samples after the planned warm-up. The SLA comparison is `mean_ms < 6000`; exactly 6000 ms does not pass. Report measured count, successful count, failed count/rate, mean for all outcomes, successful-only mean, p50/p95/p99/max, completed transactions/second and observed active threads. p95/p99 are diagnostic metrics; no percentile acceptance threshold has been supplied. Report each load plateau separately so a low-load average cannot mask peak deterioration. HTTP 200 alone is not success: verify expected page contents and, on an authorized real environment, actual account persistence. An expected validation error must be classified separately from a technical failure.

Use isolated guest cookies, unique synthetic emails per attempt, matching valid password confirmation and accepted consent. For a real environment, agree an email sink, mailbox policy and cleanup process before account creation at scale. Avoid duplicate-email validation contaminating successful-registration latency. CSV data sources must stop on exhaustion rather than recycle registered emails. Verify active users and achieved arrivals/throughput rather than assuming the configured thread count proves the target workload. Collect generator CPU/memory/network and server CPU/memory/DB/connection metrics where authorized. No server resource thresholds were specified.

## Planned executions and stress controls

PERF-01 establishes a 1-user baseline. PERF-02 observes the full daily window and daily count. PERF-03 measures 25/50/75/100-user plateaus. PERF-04 holds 100 users for 15 minutes. PERF-05 synchronizes 100 submissions to expose bursts. PERF-06 proposes 100/125/150/200-user stress steps on an owner-authorized isolated environment only. PERF-07 measures recovery. PERF-08 proposes a 60-minute peak endurance run. PERF-09 observes availability during the operating window; the requirement does not say requests outside that window must be rejected. PERF-10 separates normal and invalid-input workloads under load.

Proposed stress stop rules for owner review: stop escalation after a sustained mean >=6000 ms or technical errors in two consecutive 30-second windows, an owner resource alarm, a timeout storm, or the approved ceiling. These characterize a breakpoint rather than redefine the business SLA. Stop immediately at an owner request. Thresholds, maximum concurrency, total account budget, recovery window and monitoring access must be agreed before remote execution. An isolated local validation below is a short burst smoke test of the harness, not the designed sustained/stress-capacity campaign and not a determination of a breaking point.

## Actual execution

JMeter MCP protocol initialization and tool discovery were previously successful, but no JMeter connector tools are exposed to this session. Its configured `JMETER_HOME` is `D:/apache-jmeter-5.6.3`, which does not exist. A usable Apache JMeter 5.6.3 distribution was found under the user's nested Downloads directory and used directly in non-GUI mode. The external Codex configuration was not edited. This distinguishes a working MCP protocol handshake from a working JMeter execution environment.

Local execution: `scripts/testing/run_registration_performance_local.py` starts a temporary loopback-only HTTP server and runs `tests/performance/registration_local_harness.jmx`. The mock adds an artificial 20 ms delay per HTTP request, returns a form and redirects POST to a synthetic success page. It implements neither the real database nor application business rules. Run profiles are 1 thread x 3 iterations, 100 threads x 1 iteration and 200 threads x 1 iteration. There is no sustained hold and no warm-up exclusion in these short pipeline checks. Afterward the local server is stopped. The code never starts a load test against the public URL.

Outputs under `artifacts/test-results/tutorialsninja-performance/local-validation/`: `summary.json`, `summary.csv`, `report.html`, and per-run JTL, JMeter log and console output. The report visibly labels its local scope. Metrics are extracted from `REGISTRATION_TRANSACTION` JTL samples, not from the console summarizer. The standard summarizer can omit generated transaction-controller parents; its displayed zero count is not the sample count used in this report.

Reproduce the local check with a fresh output directory (the runner refuses to overwrite existing JTL evidence):

```powershell
.venv-robot/Scripts/python.exe scripts/testing/build_registration_performance.py
.venv-robot/Scripts/python.exe scripts/testing/run_registration_performance_local.py
```

The launcher requires installed Java and a valid JMeter jar. No remote URL parameter is supported by this local harness. Create a separate approved target plan when a controlled staging environment and permission are provided; do not repoint this mock execution and treat it as already approved.

## Review and outcome

Test design covers all four supplied requirements and includes load, response time, daily volume, concurrency, endurance, spike, stress and recovery. It does not imply complete use-case event-flow coverage. Functional correctness is a prerequisite for any real performance run. Review checks include stable case IDs, explicit workload, test data, pacing, warm-up, measurement boundary, expected result, resource observations, authorization, stop conditions, evidence and outstanding assumptions.

**Target verdict: NOT VERIFIED.** Neither 1000 users/day, the 18-hour availability window, 100 concurrent users, nor the <6-second SLA can be accepted from local mock results. No product performance defect is logged without target execution evidence. The invalid MCP runtime path is an environment issue, recorded separately. Independent QA and owner review remain required; no baseline approval or Master Specification update is inferred.

References: [Apache JMeter Best Practices](https://jmeter.apache.org/usermanual/best-practices.html) recommends non-GUI load execution. [Apache JMeter Component Reference](https://jmeter.apache.org/usermanual/component_reference.html) documents transaction controllers, cookie isolation, throughput timers and thread groups. A throughput timer limits sample rate; it does not by itself create sufficient users or prove achieved capacity.


## Local harness measurements (not target results)

| Local run | Configured threads | Transactions | Failures | Mean (ms) | p95 (ms) | Observed active threads |
|---|---:|---:|---:|---:|---:|---:|
| baseline-1 | 1 | 3 | 0 | 77.667 | 97.0 | 1 |
| load-100 | 100 | 100 | 0 | 224.73 | 252.0 | 100 |
| stress-200 | 200 | 200 | 0 | 348.4 | 392.0 | 200 |

303 mock transactions completed without assertion failures. These short checks demonstrate that Java/JMeter, the local HTTP script and JTL collection work. They do not locate a breaking point or verify daily capacity, sustained concurrency or the real response-time SLA. The environment issue is recorded in `Environment_Issues.xls`; requirement-to-case design links are in `Performance_Traceability.xlsx`. Trace counts represent planned links, not executed requirement coverage.
