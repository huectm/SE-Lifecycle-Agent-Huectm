---
name: requirements-engineering
description: "Elicit and specify business, user, and software requirements using project rules, approved templates, prioritization, and verification gates."
---

> **Version:** 3.0 — Template-Driven  
> **Governance:** `/AGENTS.md` and applicable `.agents/Rules/*.md`.  
> **Mandatory template rule:** Before creating/updating an artifact, inspect the actual approved template in `/templates` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact. If a required template does not exist, report `TEMPLATE MISSING`, propose a format if useful, and STOP for approval before adopting it.  
> **Gate rule:** At required verification/baseline gates, submit to the authorized project role and STOP until approval/revision instructions.  
> **Language rule:** All requirements deliverables (SRS, user requirements, functional requirements, non-functional quality attributes, business rules, constraints, data dictionaries, and acceptance criteria) MUST be written in English. Stakeholder communication may occur in Vietnamese, but formal deliverables must remain strictly in English.  
> **Master Specification Integration rule:** Upon receiving explicit approval at a verification gate, all approved artifact content (narratives, tables, diagrams, data dictionaries) MUST be immediately integrated and synchronized into Chapters I, II, and III of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`). Progression to Phase 06 (Analysis) is blocked until this integration is complete.  
> **Presentation rule:** All specification text must be justified across both margins (`both`), with standard body paragraphs indented 0.5 cm. Table captions MUST be placed ABOVE the table (`Table <Chapter>.<Seq>: <Title>`). In tables, header rows MUST be centered, bold, and unindented; table body cell contents MUST be justified across both margins without indentation (`first_line_indent = 0 cm`). Figure captions MUST be placed BELOW the figure (`Figure <Chapter>.<Seq>: <Title>`), centered.  
> **Diagram image rule (Mandatory Two-Step Workflow):** All diagram artifacts (System Context Diagrams, BPMN, Use Case Diagrams, Activity Diagrams, Entity Class Diagrams) MUST strictly follow the two-step workflow: (1) Export to editable master `.drawio` files first (saved in `artifacts/diagrams/`); (2) Only then export from `.drawio` to high-resolution static image files (`.png` in `artifacts/diagrams/images/`) before being embedded into specification documents. Creating an image without its corresponding `.drawio` master is strictly prohibited.  
> **Connector Routing & Anti-Overlap Invariant:** When constructing diagrams in `.drawio` (System Context, Conceptual Entity Class Diagrams), all connector lines MUST NEVER cut across unrelated shapes, boxes, or text. Use orthogonal routing with explicit waypoints (`<Array as="points"><mxPoint .../></Array>`), explicit perimeter port anchors (`exitX/Y`, `entryX/Y`), opaque label backgrounds (`labelBackgroundColor=#ffffff`), and minimum 60–80px spacing between shapes. Visually inspect exported images to verify zero collision between lines, labels, and shapes before document embedding.  
> **Requirements Prioritization rule:** All candidate functional requirements in the Product Backlog MUST be quantitatively prioritized using Karl Wiegers Prioritization Model: $\text{Total value} = 2 \times \text{benefit} + \text{penalty}$; $\text{Priority} = \frac{\text{value } \%}{\text{cost } \% + \text{risk } \%}$. Sorted backlog items directly govern Sprint Planning selection for the upcoming Sprint.

# Requirements Engineering Skill
## Role
Orchestrator for Requirements Engineering; delegate BPMN and Use Case details to their specialized Skills.
## Workflow
1. Read AGENTS.md and Requirements/Traceability/Testing/Security Rules.
2. Inspect the approved Requirements–Analysis–Design master template and determine its Requirements sections.
3. Inspect applicable Checklists and authoritative sources.
4. Populate, only in the approved structure: Background; Problem/Opportunity; Business Objectives; Success Measures where approved; Vision; Scope/Exclusions/Major Features; Risks; Assumptions/Dependencies; Business Rules and references.
5. Invoke `business-process-modeling` for AS-IS → problems/opportunities → TO-BE → BPMN.
6. Identify User Classes.
7. Derive User Requirements.
8. Specify Functional Requirements, Quality Attributes, Constraints, External Interfaces and Data Requirements.
9. **Apply Karl Wiegers Quantitative Prioritization Model:** Score and calculate priority for all candidate Functional Requirements in the Product Backlog to rank them and select high-priority requirements for upcoming Sprints (`Total value = 2*benefit + penalty`, `Priority = value% / (cost% + risk%)`).
10. Invoke `usecase-modeling`.
11. Use prototypes for unclear/complex requirements; prototypes must not silently create requirements.
12. Invoke `traceability-consistency`.
13. Apply approved SRS/requirements checklist; record → confirm → fix → re-review.
14. Update the same approved master document; do not create parallel Requirements documents unless explicitly required.
## System Context Diagram
When creating or revising a DFD System Context Diagram, follow `.agents/Rules/requirements-rules.md` Section 8.5:
1. Use one compact circular system process (`0` and system name; equal width and height) at the visual center.
2. Distribute comparable rectangular external entities around all four sides with balanced spacing; adapt placement to the entity count and routing space.
3. Preserve entity/flow IDs, names, meanings and directions. Route distinct input/output lanes with explicit anchors, orthogonal waypoints where needed, and clear labels.
4. Save and validate the `.drawio` master, export PNG from that source, then visually check system size, surrounding balance and routing/label clearance. Fix the master and re-export before review. Apply the existing approval and Master Specification synchronization gates.

## Gate
Prepare the template-based Requirements Baseline package and STOP before Analysis until approved (unless authorized iterative overlap). Upon receiving explicit approval:
1. Integrate and synchronize all approved requirements artifacts into Chapters I, II, and III of the Master Specification Document (`Requirements_Analysis_Design_Specification.docx`).
2. **Invoke `software-testing` to initiate System Test Planning & System Test Case Design** (`Functional_Test Cases.xlsx`, `Sample_Test_Design.xls`, `Preformance_Test case.xls`) covering 100% FRs, BRs, and Use Cases before or in parallel with proceeding to Phase 06 (Analysis).

---

## Requirements Prioritization & Sprint Selection Workflow (Karl Wiegers Quantitative Formula)

### 1. Dimension Scoring Matrix (Thang điểm 1–9)
For each requirement $i$, assign integer scores ($1$ to $9$) collaboratively across business and technical roles:
- **$\text{Benefit}_i$ (1–9):** Relative advantage to users/business if delivered (Evaluated by Product Owner / Business Analyst).
- **$\text{Penalty}_i$ (1–9):** Relative damage/loss if omitted (Evaluated by Product Owner / Domain Expert).
- **$\text{Cost}_i$ (1–9):** Relative implementation effort and architectural complexity (Evaluated by Lead Developer / Architect).
- **$\text{Risk}_i$ (1–9):** Relative technical risk and uncertainty (Evaluated by Lead Developer / Architect).

### 2. Computation Steps
1. **Calculate Total Value:**
   $$\text{Total value}_i = 2 \times \text{Benefit}_i + \text{Penalty}_i$$
2. **Calculate Normalization Percentages:**
   $$\text{value } \%_i = \left(\frac{\text{Total value}_i}{\sum \text{Total value}}\right) \times 100\%$$
   $$\text{cost } \%_i = \left(\frac{\text{Cost}_i}{\sum \text{Cost}}\right) \times 100\%$$
   $$\text{risk } \%_i = \left(\frac{\text{Risk}_i}{\sum \text{Risk}}\right) \times 100\%$$
3. **Calculate Priority Score:**
   $$\text{Priority}_i = \frac{\text{value } \%_i}{\text{cost } \%_i + \text{risk } \%_i}$$

### 3. Backlog Triage to Sprint Planning Execution
- **Sort Backlog:** Order all candidate backlog items descending by `Priority` score.
- **Select for Next Sprint:** Pull top-ranked items that fit within the Sprint velocity.
- **Automated Tooling:** Use `.agents/skills/requirements-engineering/scripts/calculate_priority.py` to recalculate priority scores whenever backlog items change.

