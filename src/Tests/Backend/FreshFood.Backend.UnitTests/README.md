# FreshFood Backend Unit Tests

Authorized on 2026-11-05. The approved design is synchronized in the Master Specification. The .NET 10 NUnit project is included in the solution.

48 test classes map to all 1,190 planned IDs. Final results: 657 passed, zero failed, 533 skipped. Three supplemental payment-guard rejection cases passed separately. Existing regressions: 66 passed and one opt-in PostgreSQL test skipped.

Measured coverage: 85.19% lines and 73.49% branches. Individual-condition coverage is not independently measured. The requested coverage/completion gate is NOT MET. Skips remain explicit and do not count as passes. The source is isolated with strict fakes and captured SQL; private access uses test-only reflection, and no production database/provider is contacted.

UT-DEF-001: trusted paid initial acceptance failed at deferred P02. P02 now requires Initial, VerifiedPayment and PendingPaid, and records the payment-region transition. The paid evidence is I00,T01p,P01,P02; the original case omitted P02, and this refinement is recorded in the fix log. External provider verification/correlation is separately configured.

Run: dotnet test src/Tests/Backend/FreshFood.Backend.UnitTests/FreshFood.Backend.UnitTests.csproj --collect:"XPlat Code Coverage"

Actual P/F, dates and defect references are in the original design workbook and embedded Test Report. The pre-execution workbook is preserved. Evidence: artifacts/testing/unit-execution/execution-results.json, failure-history.json, fix-log.md and the template-based FreshFood_Unit_Defect_Log.xlsx. Per-case script mapping and unresolved skip reasons remain available in the design package.

Framework selection: NUnit 4.3.2 with NUnit3TestAdapter 5.0.0, authorized by the stakeholder. Verified run: artifacts/testing/unit-execution/nunit-verified/nunit-verified.trx. All 1,190 design IDs and their outcomes match the preceding xUnit run; 3 supplemental cases also pass. Coverage/completion gaps remain explicit.

## Reading and regenerating the tests

Each runnable test now contains its backend invocation and NUnit comparisons locally, with Arrange, Act and Assert comments. Named expected values and actual results are visible in the test. Shared fixtures prepare mocks, sample entities, cancellation tokens and trusted internal contexts. Nonpublic methods retain explicitly named reflection calls without changes to production visibility. Ignored cases contain their documented reason and never fabricate an actual result.

The runtime CaseRunner dispatcher and its scenario modules have been removed from this project. Their tested originals are retained in artifacts/testing/unit-execution/baselines/before-readable-tests. Generator templates under scripts/analysis/readable-unit-templates are build-time inputs only; tests do not dispatch by case ID or load Design.json/Materialized.json at runtime.

Regenerate with scripts/analysis/generate_unit_scripts.py. It stages files, expands typed C# bodies using scripts/analysis/ReadableUnitTests, verifies no incomplete body remains, then publishes the generated classes. A generator failure cannot publish empty passing tests.

Verified on 2026-11-06: all 1,190 design IDs and outcomes are preserved, with 660 passed cases including three supplemental cases, zero failures and 533 ignores. Evidence: artifacts/testing/unit-execution/explicit-final/explicit-final.trx and readability-refactor.json. Existing coverage limitations remain unchanged.

Latest execution cycle (2026-11-06): NUnit 660 passed, zero failed, 533 skipped; regressions 66 passed, zero failed, one skipped. No new failed execution required a fix or retest. The cycle terminates at zero failing executed tests, with skipped cases and coverage gaps still open. Evidence: artifacts/testing/unit-execution/cycle-20261106/cycle-log.json.
