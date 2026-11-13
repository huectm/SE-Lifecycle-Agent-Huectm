# MathX Login Functional Test Design

Version: 1.0  
Date: 2026-10-26 (Asia/Bangkok)  
Status: DRAFT — Awaiting QA Lead / Product Owner test-design approval.  
Target: https://mathx.vn/dang-nhap.html  
Scope: External MathX assessment requested by the user; independent of the FreshFood baseline.

## Basis and authority

Source-confirmed: live visible login form surveyed on 2026-10-26; user confirmed that no valid test account is available. Survey evidence is saved in survey.json and login-page.html. No approved MathX FR/BR/UC baseline, account policy, password policy or authentication contract was provided. No FreshFood requirement IDs or coverage claims are assigned to this external application.

Observed: the main form is under #main_box; the identifier is text input name=e and label Email/Username/Phone; password is password input name=p; both are required. The form uses POST. Reset and registration links point to quen-mat-khau.html and dang-ky.html. A hidden modal duplicates login IDs, so all active form locators are scoped to #main_box. No visible remember-me or password-visibility toggle exists in the main form; those features are outside this suite.

Derived: native required validation provides valueMissing and a localized validationMessage; empty-field tests check those properties rather than assume Vietnamese/English wording. Email, username and phone samples test value entry only, not successful authentication.

Proposed — Project approval required: invalid-credential rejection is expected to retain the login form and show explicit rejection feedback in the main content. The configured regex covers explicit invalid/incorrect/not-found wording; it is not a source-confirmed exact MathX error contract. Exact rejection wording, minimum/maximum lengths, whitespace/case normalization, lockout, sessions, MFA and post-login success state are TBD – Stakeholder confirmation required. The 1/256-character samples are exploratory input probes, not documented policy boundaries. A mismatch is an observation requiring triage, not automatically a confirmed product defect.

## Environment and execution plan

Robot Framework with SeleniumLibrary and Chrome, headless desktop 1440x1000. Fresh browser per test; Close All Browsers teardown runs after failures. Tests are sequential; at most two synthetic invalid-credential submissions per suite run. The reserved .invalid email is used for rejection tests; phone/username samples are never submitted. Registration and password recovery are navigation-only: no account is created and no recovery email/SMS is requested.

Entry: approve this design and the proposed rejection oracle; target reachable; Chrome/WebDriver available. Three successful-login cases require a dedicated authorized account and a confirmed success oracle; they remain explicitly skipped/blocked without these prerequisites. No passwords for real accounts are stored in fixtures.

Exit: execute all 19 runnable cases; retain output.xml, log.html and report.html; report each failure separately; report 3 blocked cases separately. Network/locator/oracle failures must be classified before identifying a MathX defect. No claim of complete login, security, mobile-browser or business-rule coverage is made.

## Cases and data traceability

22 cases: 19 runnable after approval; 3 blocked without a valid account. Data contains 14 synthetic fixture records plus one blocked-account placeholder. Each case maps directly to a Robot test with the same MX-LG identifier. All actions, preconditions and expected results are in test_cases.csv.

| ID | Test condition | Fixture | Readiness |
|---|---|---|---|
| MX-LG-001 | Login page exposes the intended main form | none | Ready after approval |
| MX-LG-002 | Password is masked | none | Ready after approval |
| MX-LG-003 | Both required fields empty | empty_both | Ready after approval |
| MX-LG-004 | Identifier empty | empty_identifier | Ready after approval |
| MX-LG-005 | Password empty | empty_password | Ready after approval |
| MX-LG-006 | Email identifier entry | email | Ready after approval |
| MX-LG-007 | Username identifier entry | username | Ready after approval |
| MX-LG-008 | Phone identifier entry | phone | Ready after approval |
| MX-LG-009 | Unicode identifier entry | unicode_identifier | Ready after approval |
| MX-LG-010 | One-character identifier entry | one_identifier | Ready after approval |
| MX-LG-011 | 256-character identifier entry | long_identifier | Ready after approval |
| MX-LG-012 | Special and Unicode password entry | special_password | Ready after approval |
| MX-LG-013 | One-character password entry | one_password | Ready after approval |
| MX-LG-014 | 256-character password entry | long_password | Ready after approval |
| MX-LG-015 | Keyboard focus sequence | none | Ready after approval |
| MX-LG-016 | Forgot password navigation | none | Ready after approval |
| MX-LG-017 | Registration navigation | none | Ready after approval |
| MX-LG-018 | Invalid credentials rejected by button | invalid_button | Ready after approval |
| MX-LG-019 | Invalid credentials rejected by Enter | invalid_enter | Ready after approval |
| MX-LG-020 | Successful login using registered email | valid_account | Blocked |
| MX-LG-021 | Successful login using registered username | valid_account | Blocked |
| MX-LG-022 | Successful login using registered phone | valid_account | Blocked |

## Template and checklist review

Inspected templates/Test Documents/Functional_Test Cases.xlsx, including Cover, Test report and MFM-Login rows 1–9. test_cases.csv preserves the exact 13 MFM-Login row-4 column labels and order. This is a companion interchange artifact following the existing external-site test precedent; it is not an approved replacement workbook or an approved baseline. The template's five named legacy mobile-device result columns are left blank; desktop execution status is explicit in Note. The source workbook also contains pre-existing #REF! report formulas. No template sheet, header, formula or sample result was edited or represented as MathX execution evidence. Formal desktop workbook adaptation is a governance gap requiring template-owner approval if an official workbook is required.

Applied checklists/Checklist_Test Case Review.xls (Checklist sheet):

| Review item | Finding |
|---|---|
| Unique IDs, actions, preconditions, expected outcomes | Present for all 22 cases |
| Traceable history and references | User request → observed DOM → case ID → JSON fixture → Robot case ID |
| All approved requirements covered | Cannot establish; no MathX approved requirements supplied |
| Normal, invalid, empty and unusual data | Covered for observed form/input scope; policy boundaries unknown |
| Error message/code specified | Native validation property specified; server regex proposed, exact message TBD |
| Inter-test dependencies | None; each test uses a new browser; same synthetic rejection identifier used twice |
| Environments specified | Desktop Chrome only; no legacy phone execution claimed |
| Successful authentication/session/logout | Blocked without an account and confirmed oracle |
| Document page/header/footer checks | Not applicable to Markdown/CSV source deliverables |
| Independent human review | Pending; no baseline approval inferred |

Review disposition: ready for human test-design review with the stated gaps; not approved for baselining. MathX artifacts are not synchronized into the unrelated FreshFood master specification.

## Validation performed

Live survey only: form structure, field attributes, visibility and links inspected. No login credentials were submitted during survey. The robotmcp-generated mathx_login_survey.robot records only the survey browser lifecycle and is not a login correctness test.

Robot --dryrun completed with return code 0 for 22 cases; it checks syntax, keyword availability and variables only. Its generated PASS statuses are NOT functional test results. No functional execution has occurred. Output is intentionally under artifacts/test-results/mathx-login-dryrun, separate from the future live run directory.

## Run after approval

From the repository root:

```powershell
.venv-robot/Scripts/python.exe -m robot --outputdir artifacts/test-results/mathx-login tests/functional/mathx_login.robot
```

Default execution includes all cases; the three account-dependent cases explicitly SKIP. To run only the 19 executable cases, add --exclude requires-account before the suite path. Do not include the survey suite when measuring functional coverage.

Governance gate: .agents/skills/software-testing/SKILL.md §2.1 requires “STOP until System Test Design approval.” This design and the proposed server rejection oracle must be reviewed before live functional execution. No live functional pass/fail rate is available yet.


## Approved execution record — 2026-10-26

The user explicitly approved the presented test design and live execution with “yes”. This approval supersedes the earlier pending-execution statements above; they describe the design history. No complete requirements baseline or formal desktop workbook adaptation was approved or inferred.

Execution command: `.venv-robot/Scripts/python.exe -m robot --outputdir artifacts/test-results/mathx-login tests/functional/mathx_login.robot`.

Verified against output.xml: **22 total; 19 PASS; 0 FAIL; 3 SKIP**; runner exit code 0. All 22 Close All Browsers teardowns passed. MX-LG-020, MX-LG-021 and MX-LG-022 skipped explicitly because the user has no authorized test account and success oracle is undefined. These are coverage gaps, not successful authentication tests. The report's earlier DRAFT suite label is historical metadata from the executed source; this record captures the subsequent approval without modifying raw run evidence.

MX-LG-001..019 passed on the live site, including required-field validation, identifier/password value handling, keyboard focus, reset/registration navigation, and explicit rejection of the synthetic invalid credentials through both button and Enter. No product defect was established by this run. Authentication success, session/logout behavior, actual policy limits and security remain outside the verified scope.

Evidence: `artifacts/test-results/mathx-login/output.xml`, `log.html`, `report.html`. Per-case statuses are synchronized to test_cases.csv Note column and cases.json; the five legacy mobile result columns remain blank because no mobile devices were tested. Raw execution artifacts are preserved. MathX is an independent external assessment, so no unrelated FreshFood baseline was changed.
