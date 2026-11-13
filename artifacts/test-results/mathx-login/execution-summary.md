# MathX Login Functional Execution Summary

Date: 2026-10-26 (Asia/Bangkok)  
Authorization: user approved the reviewed design and execution in conversation.  
Environment: Robot Framework + SeleniumLibrary, desktop Chrome headless, 1440x1000.  
Result: **19 PASS, 0 FAIL, 3 SKIP; 22 total; process exit code 0.**  
Cleanup: 22/22 browser teardowns passed.

Three successful-login cases (MX-LG-020..022) are blocked: no authorized account or defined post-login success oracle. A PASS for this suite does not establish successful authentication, session correctness or complete login coverage. No MathX defect was established within the exercised scope.

## Per-case results

| ID | Result | Browser teardown |
|---|---|---|
| MX-LG-001 | PASS | PASS |
| MX-LG-002 | PASS | PASS |
| MX-LG-003 | PASS | PASS |
| MX-LG-004 | PASS | PASS |
| MX-LG-005 | PASS | PASS |
| MX-LG-006 | PASS | PASS |
| MX-LG-007 | PASS | PASS |
| MX-LG-008 | PASS | PASS |
| MX-LG-009 | PASS | PASS |
| MX-LG-010 | PASS | PASS |
| MX-LG-011 | PASS | PASS |
| MX-LG-012 | PASS | PASS |
| MX-LG-013 | PASS | PASS |
| MX-LG-014 | PASS | PASS |
| MX-LG-015 | PASS | PASS |
| MX-LG-016 | PASS | PASS |
| MX-LG-017 | PASS | PASS |
| MX-LG-018 | PASS | PASS |
| MX-LG-019 | PASS | PASS |
| MX-LG-020 | SKIP | PASS |
| MX-LG-021 | SKIP | PASS |
| MX-LG-022 | SKIP | PASS |


Raw evidence: output.xml, log.html, report.html in this directory. The design DRAFT label in the raw run is historical; approval and execution are recorded in artifacts/testing/mathx-login/test-design.md. Dry-run artifacts are separate and are not counted as live results.
