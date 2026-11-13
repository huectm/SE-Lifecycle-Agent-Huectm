---
name: software-testing
description: "Plan, design, and execute V-Model tests against approved requirements and designs using project workbooks, coverage rules, and quality gates."
---

> **Version:** 4.3 — V-Model Shift-Left Lifecycle Aligned  
> **Governance:** `/AGENTS.md`, `.agents/Rules/testing-rules.md`, and `artifact-registry.md`.  
> **Mandatory template rule:** Before creating/updating any test artifact, inspect the actual approved template in `/templates/Test Documents` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact.  
> **Gate rule:** At each verification gate across the V-Model, submit test artifacts to QA/Test Lead and authorized roles, and STOP until explicit approval/revision instructions.  
> **Language rule:** All formal test deliverables (Test Plans, Test Designs, Test Cases, Defect Logs, Test Reports) MUST be authored in English.  

# Software Testing Skill — V-Model Lifecycle Orchestration

## 1. V-Model Shift-Left Testing Paradigm

In this software engineering lifecycle, testing operates strictly according to the **V-Model (Mô hình chữ V)**. Testing activities are NOT deferred until after implementation. 

Instead, **Test Planning and Test Design activities are executed incrementally and immediately after each corresponding upstream specification/design phase is approved at its Human Verification Gate:**

```text
       SPECIFICATION & DESIGN (Down)                  VERIFICATION & EXECUTION (Up)
=============================================      ===========================================
[Phase 03-05: Requirements Engineering] ---------> [System Testing & Acceptance Testing Design]
  (Approved SRS, UCs, BRs, Prototypes)       Trigger    (System Test Plan, Functional & NFR Cases)
         │                                                            ▲
         ▼                                                            │ Executed against System
[Phase 07A: High-Level Architecture & DB] -------> [System Integration Testing Design]
  (Approved Architecture, Services, DB)      Trigger    (Integration Test Plan, API & Subsystem Cases)
         │                                                            ▲
         ▼                                                            │ Executed against Integration
[Phase 07B: Detailed Design] --------------------> [Module Integration & Unit Testing Design]
  (Approved DCD, Sequence Diagrams, Classes) Trigger    (Module Integration Cases, Unit Test Cases)
         │                                                            ▲
         ▼                                                            │ Executed against Units/Modules
[Phase 08: Implementation (Source Code)] ─────────────────────────────┘
```

---

## 2. Phase-by-Phase V-Model Testing Workflows

### 2.1 Stage 1: Post-Requirements System Test Planning & Design
- **Trigger:** Immediate upon formal approval of the **Requirements Baseline** (Chapter I, II, III of Master Specification: SRS, Business Rules, Use Cases, Prototypes).
- **Test Basis (Inputs):**
  - Baselined Functional Requirements (`FR-xx`), Non-Functional Requirements (`NFR-xx`), Business Rules (`BR-xx`).
  - Structured Use Case Specifications (`UC-xx`) and Activity Diagrams.
  - Baselined User Interface Prototypes and Data Requirements.
- **Mandatory Activities:**
  1. **System Test Planning:** Develop the System Test Plan defining test scope, environmental requirements, toolchains, entry/exit criteria, and test schedules.
  2. **System Test Design (Test Analysis & Test Conditions):** Derive comprehensive Test Conditions from all requirements and business rules.
  3. **System Functional Test Case Authoring:** Design end-to-end test cases covering:
     - Basic flows (happy path), alternative flows, and exception flows of every Use Case.
     - Field validation, record validation, and transaction business rules.
     - User interface interactions, navigation, and validation error messages.
  4. **System Non-Functional Test Case Authoring:** Design performance, load, stress, and security test cases traced to NFRs.
  5. **UAT Test Design:** Formulate User Acceptance Test scenarios and acceptance criteria.
- **Approved Templates:**
  - `templates/Test Documents/Functional_Test Cases.xlsx` (Cover, Test report, dedicated module sheets).
  - `templates/Test Documents/Sample_Test_Design.xls` (Test condition derivation).
  - `templates/Test Documents/Preformance_Test case.xls` (Performance/load scenarios).
- **Applied Design Techniques:** Equivalence Partitioning, Boundary Value Analysis, Use Case Testing, Decision Table Testing, State Transition Testing.
- **Coverage Invariants (Độ bao phủ bắt buộc):**
  - **100% Functional Requirements Coverage:** Every `FR-xx` MUST trace to at least one primary positive test case and negative/boundary test cases.
  - **100% Business Rules Coverage:** Every `BR-xx` MUST have test cases verifying boundary conditions, valid inputs, and violation rejections.
  - **100% Use Case Flow Coverage:** All basic, alternative, and exception paths in `UC-xx` MUST be exercised.
  - **Traceability Update:** Record all mappings in `Requirements_Traceability_Matrix_Simplified.xlsx` (`RTM` and `Coverage` sheets).
- **Review & Verification Gate:** Apply `checklists/Checklist_Test Case Review.xls`. Submit to QA Lead / Product Owner. **STOP until System Test Design approval.**

---

### 2.2 Stage 2: Post-High-Level Design System Integration Test Planning & Design
- **Trigger:** Immediate upon formal approval of the **High-Level Architecture & Database Design Baseline** (Chapter V, Section 5.1 & 5.3 of Master Specification).
- **Test Basis (Inputs):**
  - System Architecture Diagram, Subsystems, Components, Packages, and Service boundaries.
  - External and Internal Interface Specifications (REST API contracts, Webhooks, messaging protocols).
  - Database Conceptual, Logical, and Physical Schemas, Foreign Keys, Stored Procedures, and Multi-Table Transactions.
- **Mandatory Activities:**
  1. **System Integration Test Planning:** Formulate integration testing strategy, defining stub/mock requirements, service virtualization, network simulation, and database test fixtures.
  2. **System Integration Test Case Authoring:**
     - Test inter-subsystem data communication and message payloads (e.g., Web Client ↔ Backend API ↔ Database).
     - Test third-party service and external gateway integrations (e.g., Payment Gateway / SePay Webhook, Map APIs, Mail/SMS services).
     - Test database integrity under transactional commits, rollbacks, and concurrent requests.
     - Test API contracts: HTTP methods, URL route parameters, request headers, JSON schema payloads, response codes (200, 201, 400, 401, 403, 404, 409, 500), error payloads, timeouts, and retry logic.
- **Approved Templates:**
  - `templates/Test Documents/Template_Integration Test Case.xls` (Cover, Test case List, Module/Interface sheets, Test Report).
- **Coverage Invariants (Độ bao phủ bắt buộc):**
  - **100% Subsystem & Service Interface Coverage:** Every inter-subsystem interface and API endpoint contract MUST have integration test cases.
  - **100% External Gateway Integration Coverage:** Every external third-party integration point MUST have test cases for normal callbacks, network failure, invalid signature, and timeout recovery.
  - **100% Multi-Table Transaction Coverage:** Every critical database transaction boundary MUST be verified for ACID compliance.
- **Review & Verification Gate:** Apply `checklists/Checklist_Test Case Review.xls`. Submit to Software Architect and QA Lead. **STOP until System Integration Test Design approval.**

---

### 2.3 Stage 3: Post-Detailed Design Module Integration & Unit Test Planning & Design

**Required unit-test workflow:** When designing method-level cases, reviewing branch/condition coverage, creating the approved test project/scripts, or recording unit results/defects, read [Unit Test Design, Approval, Execution and Reporting](references/unit-testing-workflow.md). It governs method inventory, concrete fixtures/oracles, short-circuit coverage, testability decisions, the design-before-automation gate and the existing template report. For script generation/refactoring, NUnit readability, skipped cases or execution/fix/retest cycles, apply sections 8–10 of that reference. Apply explicit higher coverage targets without replacing project minima.
- **Trigger:** Immediate upon formal approval of the **Detailed Design Baseline** (Chapter V, Section 5.2 of Master Specification: Detailed Design Class Diagrams, Sequence Diagrams, Class Specifications).
- **Test Basis (Inputs):**
  - Detailed Design Class Diagrams (DCD) and Design Sequence Diagrams.
  - Detailed Class Specifications: Class names, Attributes, Methods, Operation signatures, Parameter types, Return types, Exceptions, Pre-conditions, Post-conditions, Class Invariants.
- **Mandatory Activities:**
  1. **Module Integration Test Design:**
     - Design test cases verifying collaboration between classes within the same subsystem/component (e.g., Controller ↔ Service ↔ Repository ↔ DTO Mapper).
     - Template: `templates/Test Documents/Template_Integration Test Case.xls`.
  2. **Unit Test Planning & Design:**
     - Structure unit tests by Class and Function/Method according to `Template_Unit Test Case.xls`.
     - Create a sheet per Function/Method and catalog in `FunctionList`.
     - Plan automated unit test suites using the project's selected testing framework (NUnit for this C# backend; otherwise the stakeholder-selected framework).
- **Approved Templates:**
  - `templates/Test Documents/Template_Unit Test Case.xls` (Cover, Guideline, FunctionList, Test Report, individual Function sheets).
- **Unit Test Design & Coverage Requirements (Quy định chi tiết độ bao phủ theo bộ skill):**
  - **Three Input Value Types (Condition & Confirmation) for every Function/Method:**
    1. **Normal Values (Giá trị thông thường):** Standard operational inputs used to verify core algorithmic success and state post-conditions.
    2. **Boundary Values (Giá trị biên):** Strict upper and lower limits ($Min, Max, Min-1, Max+1, 0$, empty strings, single-element collections).
    3. **Abnormal / Exception Values (Giá trị bất thường):** Non-expected inputs, out-of-range values, invalid data formats, null/empty references, and verification of explicit exception throws/error codes.
  - **Normative Number of Test Cases per KLOC:**
    - Calculate and record the planned Line of Code (LOC) and enforce the `Normal number of Test cases/KLOC` in the `FunctionList` sheet (default project norm: $\ge 100 \text{ TCs/KLOC}$).
    - Eliminate or justify any "Lack of test cases" in the template formula.
  - **Structural Coverage Targets (Độ bao phủ cấu trúc mã nguồn):**
    - **Statement Coverage:** $\ge 90\%$ for domain business logic.
    - **Branch / Decision Coverage:** $\ge 80\%$ across all conditional branches (`if/else`, `switch/case`, guard clauses).
    - **Condition / Basis Path Coverage:** 100% of critical calculation and validation paths.
- **Review & Verification Gate:** Apply `checklists/Checklist_Test Case Review.xls`. Submit to Technical Lead / Lead Developer and QA Lead. **STOP until Unit & Module Integration Test Design approval.**

---

### 2.4 Stage 4: Implementation & Dynamic Test Execution (Bottom-Up Execution)
- **Trigger:** Source code implementation completed and verified by Static Code Analysis (SonarQube) and Peer Code Review (`Code Review CheckList_v1.0.xls`).
- **Execution Workflow (Bottom-Up along the right arm of the V-Model):**
  1. **Level 1 — Unit Testing Execution:**
     - Execute automated unit test suite.
     - Record actual results, execution status (`Pass`, `Fail`), and defect links in `Template_Unit Test Case.xls` (`Test Report` sheet).
  2. **Level 2 — Module Integration Testing Execution:**
     - Execute intra-module integration tests with repository/service mocks or in-memory fixtures.
     - Record results in `Template_Integration Test Case.xls`.
  3. **Level 3 — System Integration Testing Execution:**
     - Execute inter-subsystem API tests and database integration tests in staging environment.
     - Record results in `Template_Integration Test Case.xls`.
  4. **Level 4 — System Functional & Non-Functional Testing Execution:**
     - Execute full end-to-end test cases on deployed build.
     - Record test pass/fail results directly in `Functional_Test Cases.xlsx` (`Test report` and module sheets).
     - Execute performance and load testing using `Preformance_Test case.xls`.
  5. **Level 5 — User Acceptance Testing (UAT):**
     - Validate operational workflows with Product Owner and Business Stakeholders.
- **Defect Management:**
  - Log every detected issue immediately in `templates/Test Documents/Template_Defect_log.xls`.
  - Record: Defect ID, Summary, Severity, Priority, Test Case Reference, Steps to Reproduce, Expected vs Actual Result, Assigned Developer, Status (`New`, `Assigned`, `Fixed`, `Verified`, `Closed`).
  - Perform re-testing and regression testing upon defect resolution.
- **Consolidated Test Reporting:**
  - Populate the built-in `Test report` sheet of each approved workbook.
  - Synthesize overall testing progress, defect metrics, and milestone verification into `templates/Test Documents/Log_Report Test.xlsx`.
- **Phase Exit Gate:** Verify against `checklists/Checklist_Quality Gate Review.xls`. Obtain formal sign-off from QA Lead and Project Approver before CI/CD release deployment.

---

## 3. Test Artifacts Summary & Traceability

| V-Model Level | Upstream Input Basis | Approved Test Document Template | Review Checklist | Gate Approver |
|---|---|---|---|---|
| **System Testing (Functional & Non-Functional)** | Requirements Baseline (SRS, UCs, BRs, Prototypes) | `Functional_Test Cases.xlsx`, `Sample_Test_Design.xls`, `Preformance_Test case.xls` | `Checklist_Test Case Review.xls` | QA Lead, Product Owner |
| **System Integration Testing** | High-Level Architecture & DB Baseline | `Template_Integration Test Case.xls` | `Checklist_Test Case Review.xls` | Software Architect, QA Lead |
| **Module Integration Testing** | Detailed Design Baseline (Component/Packages) | `Template_Integration Test Case.xls` | `Checklist_Test Case Review.xls` | Technical Lead, QA Lead |
| **Unit Testing** | Detailed Design Baseline (Class Specs, Methods) | `Template_Unit Test Case.xls` | `Checklist_Test Case Review.xls` | Technical Lead, Lead Developer |
| **Test Execution, Defects & Reporting** | Baselined Source Code + Pre-designed Test Cases | `Template_Defect_log.xls`, `Log_Report Test.xlsx`, embedded workbook report sheets | `Checklist_Quality Gate Review.xls` | QA Lead, Authorized Approver |

All test cases and execution results MUST maintain bidirectional traceability in `Requirements_Traceability_Matrix_Simplified.xlsx` (`RTM` sheet: `BR → UR → FR → UC → Design → Code → Test Case → Defect`).
