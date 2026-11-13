# Backend Unit Test Design - Review Package

Version: 0.2 | Date: 2026-11-04 | Status: design authorized 2026-11-05; execution completed for runnable cases; exit gate not met.

Use FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx. Version 0.1 is retained for comparison and superseded for worksheet layout. Preconditions, input variants and confirmation criteria appear on the left; test-case intersections contain only O (selected) or blank (not selected). True, False and NE are explicit condition values on the left, not interpretations of blank cells. All 1,190 stable case identifiers and the canonical design data are preserved. Repeated rows retain the template Condition, Confirm and Result sections. unit-test-matrix-row-map.json identifies each sheet's actual result rows; matrix-workbook-verification-v0.2.json records the selection and formula checks.

The workbook is instantiated from the approved Template_Unit Test Case.xls. The legacy template was converted to XLSX while retaining its structural sheet names, column roles and condition/confirmation/result sections. Repeated test-case columns and additional function sheets follow the template guideline: one sheet per executable method. Original instructional sheets remain marked REFERENCE ONLY and are excluded from project totals.

## Scope and navigation

- Use cases: UC-C01 (catalog), UC-C03 (cart), UC-C05 (profile/addresses), UC-C06 (checkout), UC-C07 (my orders), plus their shared backend services, repositories, policies, entities and technical helpers.
- 193 executable declarations and 85 interface declarations. Compiler-generated methods and trivial auto-property accessors are excluded; explicit getter logic, constructors and private/protected helpers are included.
- 1190 designed cases: 533 normal, 389 boundary, 268 abnormal. There are 226 structural decision points in the source snapshot.
- FunctionList links to each method sheet. Contract-only rows link to concrete realization; interfaces have no executable branch body.
- Each case contains preconditions, input/mock state, action, expected output/exception, side-effect checks, technique and trace references.
- Supporting files: method-coverage.csv, branch-condition-coverage.csv, interface-realization-mapping.csv, requirements-design-code-tests.csv and fixtures.json.
- Existing source/compiled symbols and detailed PIM signatures are the mapping basis. Support links to FRs do not claim full system-level requirements acceptance coverage.

## Coverage semantics

LOC is the non-empty method-declaration line count (including signature); primary constructors count as one declaration line. The template TC/KLOC calculation is a planning norm and does not replace branch/condition adequacy.

The design targets every feasible decision outcome and each elementary condition True and False when actually evaluated. NE denotes short-circuit non-evaluation and never counts as False. Condition truth vectors and explicit state/data partitions supplement boundary analysis and experience-based cases (ownership, tampered cookies, replay, stale addresses, partial stock, late notification failure, SQL-like input and monetary precision).

Coverage is NOT MEASURED at this stage. Template Test coverage is the proportion of executed test cases, not source branch or condition coverage. Existing 67 tests and prior Sonar coverage are not results of this new plan. After approval, measure source statements/branches and retain separate evaluated-condition evidence; do not infer atomic-condition coverage from a branch percentage alone. Project minima are >=90% core statements and >=80% branches; the requested design target is 100% feasible branch/condition outcomes, with justified infeasible paths.

## Review items before automation

1. PostgreSqlSession has seven concrete Npgsql-dependent declarations. Choose an approved isolation seam for pure unit tests, or separately tag these cases as component verification. The workbook labels this distinction explicitly.
2. Corrupt embedded resources, ambiguity/cycle defenses and static bounded-regex timeouts may require a reviewed test-only resource/harness or structural-unreachability justification. Production tables/visibility must not be changed silently.
3. The planned verified-paid state case expects PendingPaid/Paid under approved decisions. Static inspection shows P01 initializes Unpaid after the paid branch; investigate this potential mismatch during review/execution. No runtime defect or failed result has been fabricated.
4. Cases marked with review constraints require concrete witness and abnormal-contract confirmation. Constructors/pure methods without an abnormal-input requirement do not acquire an invented rejection rule.
5. Payment/provider/refund success paths that remain TBD have fail-closed tests for current behavior. They are not represented as implemented successful business flows.
6. Proposed automation project after approval: src/Tests/Backend/FreshFood.Backend.UnitTests (.NET 10 / NUnit, referencing the existing backend projects). Existing regression tests remain separate. Internal access/private harness changes need the technical approval noted above.

## Approval and subsequent execution workflow

The stakeholder authorized automation on 2026-11-05. The Master was synchronized, the project and scripts were created, and runnable cases were executed. Final design-case results: 657 passed, zero failed, 533 skipped. Three supplemental payment-guard rejection tests passed. Measured full-run coverage is 85.19% lines and 73.49% branches; individual-condition coverage is not independently measured. UT-DEF-001 was fixed and retested. The coverage/completion gate remains unmet. See artifacts/testing/unit-execution/execution-results.json, failure-history.json and fix-log.md. The existing workbook contains actual results and its embedded Test Report.

Authorized execution workflow (approval recorded 2026-11-05):
1. Baseline the approved design and synchronize approved content under project governance.
2. Create the selected unit-test project, fixture builders, strict fakes and scripts traced to the stable UTM-xxx-TCyyy identifiers. Resolve reviewed testability items before claiming coverage.
3. Execute approved cases; record actual assertions and measured statement/branch/evaluated-condition evidence.
4. Record every failed execution using templates/Test Documents/Template_Defect_log.xls. Preserve its eight columns. Put artifact/version, test case reference, steps, input, expected/actual, assigned owner and retest evidence in the Description field; do not add columns or invent defects before execution.
5. Fill each method sheet: Executed By (L3), Passed/Failed, Executed Date and Defect ID in its Result section. Locate these rows using their labels or unit-test-matrix-row-map.json; row numbers vary with repeated input and confirmation variants. Leave not-run cases blank. The embedded Test Report recalculates passed, failed, untested and N/A/B totals using each sheet's actual result rows.
6. Retest/regressions, defect verification and final test report remain subject to the project verification gate. No duplicate standalone test result report will replace the embedded Test Report.

## Source basis

- templates/Test Documents/Template_Unit Test Case.xls
- templates/Test Documents/Template_Defect_log.xls
- checklists/Checklist_Test Case Review.xls
- .agents/Rules/testing-rules.md and .agents/skills/software-testing/SKILL.md
- artifacts/requirements/customer-use-case-descriptions.md
- artifacts/requirements/reviews/order-payment-return-use-case-review.md
- artifacts/design/detailed/detailed-class-model.json and pim-to-code-mapping.json
- artifacts/design/design-sequence-message-traceability.csv
- artifacts/testing/test-design/backend-unit-method-inventory.json

design-review.json records the static checks and unresolved human review items. The authorized design is integrated in the Master. Execution findings and skipped cases remain subject to QA review; no release approval is implied.

Framework selection: NUnit 4.3.2 with NUnit3TestAdapter 5.0.0, authorized by the stakeholder. Verified run: artifacts/testing/unit-execution/nunit-verified/nunit-verified.trx. All 1,190 design IDs and their outcomes match the preceding xUnit run; 3 supplemental cases also pass. Coverage/completion gaps remain explicit.
