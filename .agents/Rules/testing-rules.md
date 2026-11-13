---
trigger: always_on
---

# Software Testing Rules — V-Model Lifecycle Invariants

## 1. Purpose and Philosophy
These rules govern all static review, test planning, test design, test execution, defect management, and reporting activities across the entire software engineering lifecycle.

Testing strictly follows the **V-Model (Mô hình chữ V)** and the **Shift-Left Principle**:
- Testing is NOT deferred until implementation is complete.
- Every development phase has a corresponding testing level.
- **Test Planning and Test Design MUST be triggered and completed immediately upon approval of the corresponding upstream specification/design artifact.**
- Static verification (reviews and checklists) begins as soon as any reviewable work product exists.

---

## 2. V-Model Shift-Left Test Design Invariants

```text
Specification / Design Phase (Approved)         Corresponding Test Planning & Design Activity (Mandatory)
───────────────────────────────────────────────────────────────────────────────────────────────────────────
Phase 03–05: Requirements Baseline Approved   ──► System Test Plan & System Test Cases (Functional & NFR)
Phase 07A:   High-Level Architecture Approved  ──► System Integration Test Plan & System Integration Test Cases
Phase 07B:   Detailed Design Approved          ──► Module Integration Test Plan & Unit Test Plan & Cases
Phase 08:    Implementation Completed          ──► Dynamic Test Execution (Bottom-Up: Unit ──► Integration ──► System ──► UAT)
```

### 2.1 Invariant 1 — Post-Requirements System Test Planning & Design
Upon formal approval of the Requirements Baseline (SRS, Business Rules, Use Case Specifications, UI Prototypes):
1. **Mandatory Action:** The Agent MUST immediately initiate System Test Planning and System Test Case Design using `templates/Test Documents/Functional_Test Cases.xlsx`, `Sample_Test_Design.xls`, and `Preformance_Test case.xls`.
2. **Techniques:** Equivalence Partitioning, Boundary Value Analysis, Use Case Testing, Decision Table Testing, State Transition Testing.
3. **Mandatory Coverage Targets:**
   - **100% Functional Requirements Coverage:** Every `FR-xx` MUST trace to at least one positive test case and corresponding negative/boundary test cases.
   - **100% Business Rules Coverage:** Every `BR-xx` MUST have test cases verifying valid operation, limit boundaries, and rejection of invalid states.
   - **100% Use Case Flow Coverage:** All basic flows, alternative branches, and exception paths in `UC-xx` MUST have explicit test cases.
4. **Verification Gate:** Test cases must pass `checklists/Checklist_Test Case Review.xls` and obtain QA Lead / Product Owner sign-off before proceeding.

### 2.2 Invariant 2 — Post-High-Level Design System Integration Test Planning & Design
Upon formal approval of the High-Level Architecture & Database Design Baseline:
1. **Mandatory Action:** The Agent MUST immediately initiate System Integration Test Planning and System Integration Test Case Design using `templates/Test Documents/Template_Integration Test Case.xls`.
2. **Focus Areas:**
   - Communication across subsystem boundaries (e.g., Client App ↔ Web Server ↔ Backend API ↔ Database).
   - Third-party external gateways and services (e.g., Payment Gateway / Webhooks, Mapping services, SMS/Email).
   - Multi-table transaction integrity, rollback under failure, and concurrent access.
   - API contract conformance (HTTP verbs, paths, headers, JSON request/response schema, status codes, timeout/retry logic).
3. **Mandatory Coverage Targets:**
   - **100% Subsystem & Service Interface Coverage:** Every defined internal and external interface must have integration test cases.
   - **100% External Gateway Error & Callback Handling:** Success, timeout, network failure, and invalid signature scenarios must be verified.
4. **Verification Gate:** Test cases must pass `checklists/Checklist_Test Case Review.xls` and obtain Software Architect and QA Lead sign-off.

### 2.3 Invariant 3 — Post-Detailed Design Module Integration & Unit Test Planning & Design
Upon formal approval of the Detailed Design Baseline (Detailed Design Class Diagrams, Sequence Diagrams, Detailed Class Specifications):
1. **Mandatory Action:** The Agent MUST immediately initiate:
   - **Module Integration Test Design:** Verifying inter-class collaboration within components using `templates/Test Documents/Template_Integration Test Case.xls`.
   - **Unit Test Plan & Test Case Design:** Structuring method/function-level test cases using `templates/Test Documents/Template_Unit Test Case.xls`.
2. **Mandatory Unit Test Input Groups (Condition & Confirmation):**
   Every function/method under test MUST be designed with test cases spanning all three input conditions:
   - **Normal Values (Giá trị thông thường):** Standard valid inputs verifying correct business calculation and return types.
   - **Boundary Values (Giá trị biên):** Min, Max, upper and lower limits, zero, empty strings, boundary extremes.
   - **Abnormal / Exception Values (Giá trị bất thường):** Out-of-bounds, invalid formats, null/empty references, and verification of thrown exceptions / error codes.
3. **Normative Test Cases per KLOC:**
   - In `Template_Unit Test Case.xls` (`FunctionList` sheet), the planned Line of Code (LOC) and `Normal number of Test cases/KLOC` MUST be recorded (default norm: $\ge 100 \text{ TCs/KLOC}$). Any deficit ("Lack of test cases") must be justified or resolved.
4. **Structural Coverage Targets:**
   - Statement Coverage: $\ge 90\%$ for core business logic.
   - Branch / Decision Coverage: $\ge 80\%$ across all conditional logic.
   - Basis Path Coverage: 100% for critical computational paths.
5. **Verification Gate:** Test cases must pass `checklists/Checklist_Test Case Review.xls` and obtain Technical Lead / QA Lead sign-off.

---

## 3. Dynamic Test Execution Invariants (Bottom-Up Execution)
When implementation is complete and passes static analysis (SonarQube and Code Review):
1. **Execution Order:**
   - Level 1: Unit Testing (Automated xUnit/NUnit/pytest/Jest suites).
   - Level 2: Module Integration Testing.
   - Level 3: System Integration Testing.
   - Level 4: System Functional & Non-Functional Testing.
   - Level 5: User Acceptance Testing (UAT).
2. **Embedded Reporting Rule:**
   Execution results MUST be recorded directly into the designated report sheets of approved templates:
   - `Test Report` sheet in `Template_Unit Test Case.xls`.
   - `Test Report` sheet in `Template_Integration Test Case.xls`.
   - `Test report` sheet in `Functional_Test Cases.xlsx`.
   - The Agent MUST NOT create separate duplicate test reports when embedded sheets exist.
3. **Consolidated Test Log:**
   Overall test cycle progress and milestone verification are consolidated into `templates/Test Documents/Log_Report Test.xlsx`.

---

## 4. Defect Management Invariants
1. Every failed test execution MUST be logged immediately in `templates/Test Documents/Template_Defect_log.xls`.
2. Each defect record MUST contain: Defect ID, Artifact/Version, Detailed Description, Severity, Priority, Steps to Reproduce, Expected vs Actual Output, Test Case Reference, Assigned Developer, Status (`New`, `Assigned`, `Fixed`, `Verified`, `Closed`).
3. Re-testing and regression testing MUST be conducted and documented before closing any defect.
4. The Agent MUST NOT silently fix defects without logging them.

---

## 5. Bidirectional Traceability Invariants
All test cases across all V-Model levels MUST maintain unbroken bidirectional traceability:
$$\text{Requirement (FR/NFR)} \longleftrightarrow \text{Business Rule (BR)} \longleftrightarrow \text{Use Case (UC)} \longleftrightarrow \text{Design Element} \longleftrightarrow \text{Code Element} \longleftrightarrow \text{Test Case} \longleftrightarrow \text{Test Result} \longleftrightarrow \text{Defect}$$
Maintain and update `templates/Test Documents/Requirements_Traceability_Matrix_Simplified.xlsx` (`RTM` and `Coverage` sheets) at each test design and execution phase.

---

## 6. Review & Exit Gates
Before closing any testing phase:
1. All planned test cases for that level are designed, reviewed with `checklists/Checklist_Test Case Review.xls`, and baselined.
2. Required execution runs completed with results recorded in approved template sheets.
3. 100% of critical and high-severity defects are resolved and verified.
4. Defined coverage thresholds (Requirement coverage, Input value type coverage, Branch/Statement coverage) are fulfilled.
5. Exit criteria verified against `checklists/Checklist_Quality Gate Review.xls`.
6. Responsible QA Lead / Authorized Approver confirms completion.

## 7. Backend Unit Automation and Execution Controls

The following conventions reflect explicit project stakeholder decisions:

1. **Framework and layout:** Use NUnit for the dedicated C# backend unit suite. Place each test project in its own directory under `src/Tests/Backend/` or `src/Tests/Frontend/`, within the source solution tree. Retain the existing regression suite unless its migration is separately authorized. Update project references, solution entries, fixture paths, generators and active trace links when moving projects; preserve historical execution paths as evidence.
2. **Readable scripts:** Create one test class per source class. Each test method must contain its actual subject invocation and explicit expected-versus-actual assertions, with local Arrange/Act/Assert structure and English XML case documentation. Shared fixtures may prepare dependencies; business scenarios must not be hidden behind a case-ID dispatcher.
3. **Case readiness:** Executable cases require concrete typed inputs and an independent oracle. Track every skipped/blocked case with a reason, prerequisite, owner and next action. Resolve feasible cases; obtain review for unspecified contracts or N/A. Skips count as unexecuted, never passed or covered.
4. **Correction loop:** Execute, retain failure evidence, log and classify defects before fixing, perform authorized fixes, retest affected cases and run relevant regression tests. Repeat until executed failures and unresolved confirmed defects in scope are cleared. Report blocked work rather than masking it. An initial zero-failure run requires no artificial fix/retest cycle.
5. **Evidence and completion:** Preserve initial failures and all fix/retest history. Record actual results and execution dates in the approved workbook and defect template. Report unexecuted cases and measured coverage independently of pass counts. Zero failures alone does not satisfy the exit gate or establish a defect-free product.
6. **Safe generation:** Validate generated tests in staging before publishing. Generation failure must leave the known-good suite intact; empty passing placeholders must not become execution evidence.

For script documentation, mocks, skip remediation, generation validation and the complete correction loop, follow [Unit Test Design, Approval, Execution and Reporting](../skills/software-testing/references/unit-testing-workflow.md), sections 8–10. These controls supplement the approval and coverage gates above; they do not waive them.

## 8. Iteration Scope Boundary

1. Before test design or execution, identify the current authorized development iteration, its approved requirement/use-case IDs, changed modules/methods and baseline. Map new cases, fixes and coverage claims to that scope. If ownership is unclear, inspect iteration records and traceability; obtain clarification before modifying an ambiguously owned module.
2. Test design, execution and the defect correction loop address requirements in the current iteration. Select dependency/regression checks only where needed to verify the impact of those requirements; running an existing check does not authorize changing its previously developed module.
3. Preserve modules delivered in earlier iterations, including their implementation, established contracts and existing tests. Do not refactor, repair, regenerate or alter them solely to make the current iteration pass without explicit authorization to expand scope.
4. When a failure originates in an earlier-iteration or shared module outside scope, retain the failure evidence, log the affected module/baseline and requirement impact, and submit the proposed change with impact analysis for approval. Continue independent current-iteration work; mark dependent cases blocked when necessary. Do not weaken assertions or change expected behavior to hide the dependency failure.
5. Apply an out-of-scope fix only after explicit approval identifies the added modules/change and required regression scope. Record that approval and update traceability before correction. An instruction to repeat testing until errors are cleared applies within the authorized iteration; it is not blanket approval to change earlier iterations.
6. Report current-iteration results and coverage separately from dependency/regression observations and deferred prior-iteration defects. Unresolved blocking dependencies remain visible at the exit gate.
