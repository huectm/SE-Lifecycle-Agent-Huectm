# Unit Test Design, Approval, Execution and Reporting

Read this reference for method-level test design, branch/condition review, approved unit-test automation, and unit-test results/defects. Apply project Rules first and the relevant authoring skill for the file format.

## 1. Establish the basis and method inventory

- Establish the authorized iteration boundary first using testing-rules.md section 8. Inventory only its scoped requirements and changes; identify earlier-iteration dependencies separately. Existing regression execution does not authorize modifying those modules or their tests.
- Load approved requirements, latest stakeholder decisions, detailed class/sequence design and current source. Apply [PIM-to-code mapping rules](../../software-design/references/pim-code-mapping.md) for platform refinements.
- Enumerate executable declarations with a language-aware parser/semantic symbols where available. Record class, full signature/overload, visibility, source location/hash and applicable use cases/design elements.
- Include authored constructors, private/protected/internal helpers, custom accessors and operators. Explain exclusions such as compiler-generated methods, trivial auto-properties and framework internals.
- Map interface contracts to concrete realizations; declarations without bodies have no executable branches. Account for inherited/shared implementations without counting their code twice.
- Keep stable method/case IDs and trace requirements/business rules/use cases, design, source, fixture, future script, result and defect. A supporting FR link does not prove full system-level acceptance coverage.

Completion: every scoped method is accounted for, each contract has a realization or a visible gap, and the basis identifies unresolved conflicts.

## 2. Inspect and populate the actual templates

Inspect these files before authoring:
- templates/Test Documents/Template_Unit Test Case.xls
- templates/Test Documents/Template_Defect_log.xls
- checklists/Checklist_Test Case Review.xls

Preserve structural sheet names, column roles, condition/confirmation/result sections, styles, formulas, validation and embedded reports. Follow the template guideline for repeated function sheets/case columns. In the current unit template, populate Cover and FunctionList, use one sheet per executable method, and retain Test Report for execution summaries. Determine exact cells/rows from the inspected labels, not coordinates cached from a past workbook.

The function-sheet notation is a selection matrix: list preconditions, input values/partitions and confirmation criteria on the left; mark applicable rows in each test-case column with the literal O, leaving other intersections blank. Keep long narratives, setup JSON and expected-result descriptions out of the case intersection cells. Repeat value rows within the original Condition / Confirm sections as needed, followed by the Result section. Derive summary formulas, result references and print areas from the resulting row map. Validate every selection against its case data, including unused columns, rather than relying on a few screenshots.

Record LOC and its counting convention, the TC/KLOC norm and the existing lack-of-test-cases calculation. The project default norm is at least 100 TCs/KLOC. Explain deficits; a count surplus is not structural coverage, and duplicate/vague cases are not a remedy.

Keep instructional sheets reference-only and outside project totals. Clear sample case IDs, P/F, dates and defects in all unused project case columns as well as populated columns.

XLS-to-XLSX conversion is acceptable when structure is preserved. Verify the result opens normally and that hyperlinks, formulas/caches, merges, wrapping, images and blank execution regions are intact. For unsupported hyperlink/calculation/export features, use a narrow compatibility fallback and compare values, formulas, merges and images before/after; file repair does not authorize redesign.

## 3. Specify concrete cases and independent oracles

Address normal, boundary and abnormal/exception partitions for every method. Where a constructor or pure method has no meaningful abnormal-input contract, record the N/A rationale for review rather than inventing a rejection or counting a review-only item as executed.

Each proposed executable case needs:
- Stable ID, method/signature, source/design basis and technique.
- Concrete typed inputs, state and mock returns/failures; resolve fixture aliases to explicit values. "Make condition false" alone is not an executable case.
- Prerequisite guards and ordered arrange/act/assert actions.
- Exact expected output or independently calculated values, exception/error code/status where applicable, state/call effects, forbidden calls, transaction and cancellation expectations.
- Reset/isolation, identity/ownership and repeat/replay sequence where relevant.
- Readiness: executable, policy/testability-blocked or review-only, with reason; keep these categories visible in totals.

Use approved requirements/design as the business oracle and source structure for path/technical-contract derivation. A suspected implementation defect must not be made to pass by changing the expected business result. Record a static mismatch as a review concern, not a fabricated failed execution.

Apply boundaries to declared domains: numeric/length minima and maxima, zero, fractions, overflow, null/empty, collection cardinality, UTC dates and money precision. Do not invent limits, rounding, refund or provider policy. For deferred methods, specify current fail-closed behavior and keep desired success paths blocked until prerequisites are approved/implemented.

## 4. Separate planned and measured structural coverage

Apply testing-rules.md minima and explicit higher user targets. Full branch/condition coverage means targeting 100% feasible outcomes; do not silently reduce that request to the default minimum.

- Inventory guards, if/else, conditional expressions, switch arms/defaults, loops (zero/one/many/exit), null access/coalescing/coalescing assignment, catch/filter paths and relevant Boolean predicates/returns.
- Give decisions and atomic conditions stable IDs and map required outcomes to concrete cases.
- For AND/OR and pattern combinations, distinguish evaluated True/False from short-circuit non-evaluation (NE). NE never counts as False. Check correlated-input feasibility instead of assuming every Boolean vector is constructible.
- Branch/decision coverage and individual-condition coverage are distinct. Claim MC/DC only with independent-effect pairs and matching measured evidence.
- Document immutable-table, trusted-read-only, defensive and exception-only paths. Specify a permitted harness/resource variant or justify unreachability. Keep blocked/infeasible outcomes explicit; never silently mark them covered or change the denominator.
- Generated vectors, method inventory and earlier regression runs are planning evidence, not runtime coverage for the new suite.
- After execution, bind measurements to the exact source/scripts/run. Retain separate evaluated-condition evidence if the tool only reports branches/blocks.
- The template's Test coverage formula commonly means executed-case percentage. Label its meaning; it does not automatically measure source branches or conditions.

Completion: the matrix accounts for required decisions/conditions, concrete-witness gaps are visible, and measured claims have execution evidence.

## 5. Add experience-based cases and review testability

Derive error-guessing cases from approved behavior. Useful examples:
- Conflicting route/body IDs, forged identity headers, foreign-owned data and tampered cookies.
- Empty/unavailable stock, FEFO ties/splits, changed prices/addresses, overflow and exact-money wire compatibility.
- Idempotency-key reuse, exact replay, duplicate transition evidence and duplicate reviews.
- Begin/work/commit/rollback failure, cancellation and notification failure after commit without undoing committed work.
- Signature-sensitive webhook text/headers, absent required numeric fields, optional defaults, independent fulfillment/payment/refund projections and unavailable providers.

Use strict fakes for replaceable collaborators. Real databases/providers/network transports are component/integration verification, not isolated unit coverage. For concrete framework dependencies such as Npgsql connections/readers, propose an approved seam or separately tagged component fixture; do not count the latter as pure unit tests.

Reach private helpers through public behavior where feasible. Internal access, reflection, test-resource variants and production seam changes require a reviewable strategy; approving test design is not blanket permission to change production visibility/architecture. Prefer deterministic failure/clock injection to flaky timing, sleeps or forced regex timeouts.

## 6. Respect design approval before automation

When the request is design first, automation after approval:
1. Prepare the reviewable workbook, fixtures, method/coverage mappings and checklist findings.
2. Leave actual executor/P-F/date/defect fields blank and all unrun cases untested. Earlier tests do not become results for this design.
3. Present remaining oracle, policy, fixture and testability choices. STOP before creating a new test project, generating backend test scripts or executing the new plan until explicit approval.
4. Record approval scope, resolve remaining choices before dependent work, and synchronize approved artifacts with the Master Specification/traceability according to AGENTS.md.
5. Create/adapt the selected project and scripts, retain existing regression suites, and map each script/data row to approved case IDs.

Skill updates, planning conventions and status acknowledgments do not approve a specific test design. Past case/method counts, discovered bugs and proposed seams are project evidence, not universal skill requirements.

## 7. Execute and update the same workbook

After authorization, preserve actual run output, source/script versions and coverage evidence. Distinguish pass/fail/blocked/skipped/not-run. Use only template-supported states in P/F cells; explain other states in existing notes instead of fabricating passes or altering the schema.

For every failed execution:
- Use the inspected Template_Defect_log.xls and preserve its columns.
- In the current eight-column template, put case reference, artifact/version, steps/input, expected/actual, assigned owner, evidence and retest details in Description where no dedicated column exists.
- Use applicable severity/priority/status conventions. Static concerns are not executed failures.
- Link defects to cases and preserve history through fix, retest and regression. Production fixes follow their authorization.

Write actual executor, P/F, date and defect ID into each method's designated result region. Recalculate the embedded Test Report and reconcile case subtotals, N/A/B counts and percentages. Keep measurement meanings explicit; do not replace an existing embedded report with a duplicate standalone execution report. Update the consolidated log/RTM when applicable and submit evidence to the completion gate.

## 8. Implement readable, traceable test scripts

Apply the project-specific framework and layout in testing-rules.md section 7. Create one test class per source class, retaining stable method and case IDs across regeneration and refactoring. Account for overloads and shared implementations without duplicate coverage claims.

Each test method must show Arrange, Act and Assert locally: concrete setup, the actual subject invocation, and an explicit comparison of actual output with the expected value, exception or side effects. Use NUnit assertions for the selected backend unit suite. Keep business invocation and assertions out of generic case-ID dispatchers such as CaseRunner.Run. Shared helpers may construct data, mocks and fixtures or perform clearly named technical checks; they must not conceal the business scenario.

Add English XML documentation to every test method identifying case ID, target signature, scenario, concrete inputs, preconditions, action, expected result, technique, branch/condition targets and trace basis. Document a skip reason when applicable. Label supplemental cases separately from approved design IDs and preserve these comments during generation.

Keep the subject real and replace its external dependencies through their contracts. Identify which fixture creates each fake and whether it acts as a stub, spy or mock. Assert relevant calls, arguments, cancellation tokens, ordering and forbidden side effects explicitly. A fake repository session does not verify real PostgreSQL behavior; tag real transport/database fixtures separately. Passing a fail-closed provider test does not prove the provider's successful integration flow.

For generated scripts, generate into staging, validate syntax, case-ID completeness, documentation and executable assertion bodies, then publish only after the entire expansion succeeds. A generator failure must fail the command and retain the known-good active suite. Empty bodies or success-only placeholders are not valid tests. After a readability-only refactor, compare per-case outcomes and source hashes to verify preserved behavior and unchanged production code; retain the comparison evidence.

## 9. Resolve skipped and blocked cases explicitly

For each skipped or blocked case, record its ID, exact reason, missing prerequisite, responsible owner and next action in the case mapping/log. Distinguish symbolic inputs awaiting concrete witnesses, unspecified contracts, missing fixtures, separately scoped integration cases, justified N/A and indirect coverage through owning behavior. A skip is unexecuted work, never a pass or evidence of coverage.

Materialize feasible symbolic cases into typed inputs and independent expected results. Resolve missing approved fixtures within scope instead of marking cases ignored merely to obtain a green run. For unspecified constructor guards or business policies, request the responsible decision rather than inventing behavior. Review N/A and infeasibility rationales explicitly; retain their trace links and disclose their effect on denominators. Exercise private implementation records and base construction through public owners where suitable, without claiming an independent execution that did not occur. Use deterministic seams for exceptional/resource paths rather than timing-dependent failures.

## 10. Execute the defect correction loop

1. Run the authorized suite and preserve the first failure output, case IDs, source/script versions, framework/tool versions and coverage evidence.
2. Log each failure before correction using the approved defect template. Triage whether its cause is production code, test script, fixture, generator or an upstream contract conflict; retain expected versus actual evidence.
3. Correct authorized defects within the current iteration. For earlier-iteration/shared modules outside scope, log evidence and impact and obtain explicit scope-expansion approval before changing implementation, contracts or existing tests. Keep dependent cases visibly blocked and continue independent work. Escalate unresolved policy/design conflicts under the applicable gate rather than changing the oracle to match faulty behavior.
4. Retest the affected cases and run relevant regression tests after the fix. Record the change, retest result and defect status while preserving the original failure history.
5. Repeat while executed tests fail or confirmed in-scope defects remain unresolved. If the initial run has no failures, record that no corrective retest was required; do not invent defects or repeat unchanged runs without cause.
6. Update actual execution dates from run evidence, executor, per-case results, defect references and the embedded Test Report in the same workbook. Leave skipped cases without fabricated P/F values and explain them in supported notes or the linked case log.
7. Report executed pass/fail counts, skipped/blocked/not-run cases, open defects, measured statement/branch coverage, separate condition evidence and unmet exit criteria. Zero failures among executed cases does not establish that all planned cases ran, coverage targets were met, or the product is defect-free. Submit the completion gate only with these limitations visible; test success does not grant release approval.

