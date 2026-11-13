# Registration Functional Test Design and Execution

Status: Draft for QA / stakeholder review. Execution authorized by the task request; no baseline approval inferred.
Date: 2026-10-28. Target: https://tutorialsninja.com/demo/index.php?route=account/register
Basis: `artifacts/requirements/Use Case Register .docx` (the actual filename has a space before `.docx`), UC-REG-01, and live UI survey.

## Scope and oracles

Verify guest registration, required fields, email format and duplicate rejection, confirmation, consent, Newsletter defaults/selection/persistence, login navigation, Privacy Policy dialog, success page and persisted profile values. Functional black-box tests run against the live shared demo with SeleniumLibrary and headless Chrome. All account details are synthetic, using unique `example.com` addresses; successful cases create real demo accounts. No administrative cleanup API is available. Generated accounts remain in the demo. Evidence contains synthetic credentials only.

The supplied use case explicitly marks appendix limits as proposed or requiring confirmation. The observed UI advertises First Name and Last Name 1–32 characters, Telephone 3–32, and Password 4–20. Its proposed First Name maximum 20, Last Name maximum 10, and minimum-eight/composition password rules are tested separately. These proposals are not silently promoted to approved requirements. Email deliverability, inbox receipt, email case sensitivity, country-specific telephone format and server storage/rollback are not confirmed.

`REG-028` is a functional inconsistency against the displayed password maximum: 21 characters are accepted. `REG-041`, `043`, `044`, `046`–`049` are requirement clarification findings, not seven confirmed implementation defects. Do not change the expected results merely to make these tests pass.

## Equivalence partitions and boundary values

| Input | Valid partition | Invalid partitions | Three-point / adjacent values |
|---|---|---|---|
| First Name, live UI | 1–32 characters | empty, >32 | 0, 1, 2, 31, 32, 33 |
| Last Name, live UI | 1–32 characters | empty, >32 | 0, 1, 2, 31, 32, 33 |
| Telephone, live UI | 3–32 characters | below 3, above 32 | 0, 2, 3, 4, 31, 32, 33 |
| Password, live UI | 4–20 advertised | below 4, above 20 advertised | 0, 3, 4, 5, 19, 20, 21 |
| First Name, UC proposal | maximum 20 | 21 characters; whitespace-only | 19, 20, 21 |
| Last Name, UC proposal | maximum 10 | 11 characters; whitespace-only | 9, 10, 11 |
| Password, UC proposal | minimum 8, uppercase/lowercase/digit/special | below minimum; individually missing each character category | 7, 8, 9; one missing category per row |
| Email | syntactically valid and unique | empty, no @, absent local/domain parts, embedded space, existing account | EP; numeric length limits unconfirmed |
| Confirmation | exact equality | empty and mismatch | EP |
| Privacy | accepted | unchecked | Boolean partitions |
| Newsletter | No by default or Yes selected | invalid radio values outside normal UI excluded | both choices; saved preference checked |

The CSV contains 55 individually identified datasets. Except for explicit navigation/fault cases, a normal valid dataset is copied and one field is changed, isolating the effect of each validation condition. A valid baseline is compared with each single-invalid row. Duplicate testing creates its own account fixture and reuses its exact email, without depending on earlier test order. Each case resets cookies and reloads the register form. Do not run against a production system.

## Keyword-driven and data-driven architecture

`tests/functional/tutorialsninja_register.robot` uses a suite-level `Test Template` and one named test per CSV ID. The business keywords are `Reset Guest Registration`, `Fill Registration Form`, `Submit Registration`, `Assert Registration Outcome`, and `Prepare Duplicate Account`. Data lives independently in `tests/data/tutorialsninja_register.csv`; `RegistrationData.py` loads it, creates run-unique email addresses, evaluates observable outcomes and saves evidence. Modify data and regenerate the test index using `scripts/testing/build_registration_tests.py`. Assertions remain active; unexpected acceptance fails.

Success checks include the account success heading and URL, saved Newsletter preference, and exact First Name/Last Name/email/telephone on the account-edit page. Negative checks require no success plus the specific warning; invalid email may be stopped by native browser validation. A browser rejection does not demonstrate the server-side email-validation branch. Waiting for an observable success/error/native-validation state prevents assertions racing a page transition. Duplicate fixture setup also waits for the success heading.

## Decision and condition model

The analysis model has nine decisions: First Name bounds, Last Name bounds, Telephone bounds, Password bounds, email syntax, duplicate email, password equality, Privacy consent, and Newsletter selection. It has 13 atomic input predicates: the lower and upper checks for each of the four length-limited fields, invalid email, duplicate email, confirmation mismatch, accepted consent and Newsletter Yes. The `condition-coverage.csv` lists the exact dataset IDs producing true and false for each predicate.

All 26 atomic truth outcomes are represented in executed input datasets (26/26). Both input outcomes of the nine modeled decisions are exercised (18/18). This is **modeled input decision/condition coverage**, not measured source-code branch/condition coverage, and does not mean every expected outcome passed. In particular, the upper-password rejection oracle fails. No source instrumentation, application version/source access or control-flow graph is available, so statement coverage, actual branch coverage, actual condition coverage and MC/DC cannot be established. Do not report them as 100%.

UC basic flow, Alt1.1, Alt1.2 and E1–E5 were exercised: 8/9 named basic/alternative/exception flows. E6 was designed but skipped. The extended model including fault handling consequently has at least one unexercised decision; its full branch denominator cannot be known from the UI. No claim of exhaustive system branch coverage is made.

## Results and limitations

55 cases: **46 PASS, 8 FAIL, 1 SKIP**. The Functional_Test_Cases workbook embeds cases and the final execution counts. Its approved template sheet names, column order and legacy device fields are preserved. Only `MFM-CreateAcct` is populated for this target. Chrome results are recorded in `Note`; legacy phone columns are N/A. Other module tabs retain template examples and are excluded from this project's report. Existing unrelated template defined names contain `#REF!`; they were not repaired or used for registration metrics.

The first execution exposed synchronization defects in the test harness; they were corrected. The duplicate fixture synchronization was then corrected and its successful retest merged. Three adjacent-boundary cases were added and their execution merged. The final `output.xml`, `log.html`, and `report.html` consolidate the latest outcome for each ID. Initial/partial runs remain in subdirectories for audit. The initial harness failures are not application defects.

Evidence for each case is in `artifacts/test-results/tutorialsninja-register/evidence/`: screenshot, HTML and JSON (actual generated data, URL and observed validation). Main report: `artifacts/test-results/tutorialsninja-register/report.html`. Detailed messages/steps: `log.html`. Machine-readable result: `output.xml`.

E6 requires a controlled failure environment and persistence visibility to verify rollback and safe retry. Injecting a browser connectivity failure alone would not prove the application system-error branch. Email delivery, account deletion, server code coverage and cross-browser execution remain outside the measured evidence.

## Reproduction

Run from repository root with the installed virtual environment:

```powershell
.venv-robot/Scripts/python.exe scripts/testing/build_registration_tests.py
.venv-robot/Scripts/python.exe -m robot --outputdir artifacts/test-results/tutorialsninja-register tests/functional/tutorialsninja_register.robot
.venv-robot/Scripts/python.exe scripts/testing/report_registration_tests.py
```

Expected current suite outcome includes failures while the above differences remain unresolved; a nonzero Robot exit status is meaningful. The report generation reads Robot's result XML and does not convert failures into passes. Synthetic data uses fresh email addresses on every run. Runtime: Robot Framework 7.5, SeleniumLibrary 6.9, Selenium 4.51; installed Chrome and Selenium driver management. Do not run this registration suite concurrently against the same browser session.

## Review and gate

Self-review against `Checklist_Test Case Review.xls`: stable IDs, upstream basis, preconditions, independently generated data, repeatable steps, explicit observable expected results, positive/negative/boundary cases, traceability, evidence and outstanding ambiguities checked. E6 and structural coverage remain incomplete; release/acceptance exit criteria are not met. Author review does not replace independent QA approval.

Requested decisions: confirm the intended name/password limits and composition policy; triage the advertised password maximum; provide a controlled environment if E6 or true code coverage is required. The Master Specification is not updated because these test artifacts have not received formal baseline approval and this target is a separate tutorial website rather than an inferred FreshFood requirement.

## Visible execution for tester observation

Run ten existing cases in a maximized, non-headless Chrome window:

```powershell
.venv-robot/Scripts/python.exe scripts/testing/run_registration_visible.py
```

Selected IDs: REG-001, REG-002, REG-003, REG-008, REG-029, REG-035, REG-036, REG-037, REG-038, REG-039. This selection demonstrates normal registration, Newsletter Yes, required/upper-bound name validation, email required validation, confirmation mismatch, Privacy consent, duplicate email, login navigation and the policy dialog. It does not claim complete use-case event-flow coverage.

The launcher sets Selenium action speed to 0.5 seconds and pauses 3 seconds after each case. The shared suite remains headless by default for routine runs; browser options and observation delays are configurable. Reports, step logs and screenshots for this run are saved separately under `artifacts/test-results/tutorialsninja-register/visible-10/`. Successful cases create synthetic demo accounts. Chrome closes at suite completion.


## Event-flow coverage clarification

`event-flow-coverage.csv` maps every named flow to its executed evidence and remaining recovery steps. The prior 8/9 figure means entry/rejection paths were exercised, not that eight complete event sequences were verified. Strict end-to-end event-flow coverage is **3/9 complete (33.3%)**, **5/9 partial**, and **1/9 not executed**. Basic registration, Newsletter subscription and Login navigation are complete. E1?E5 still require the correction/continuation step in the same session. E6 requires controlled fault injection and storage/retry verification. The ten-case visible demonstration reuses existing cases; it does not close these recovery gaps.
