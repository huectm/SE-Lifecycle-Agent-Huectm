---
name: analysis-modeling
description: "Create BCE, VOPC, analysis sequence, and state machine models from approved use cases using project templates and verification gates."
---

> **Version:** 3.0 — Template-Driven  
> **Governance:** `/AGENTS.md` and applicable `.agents/Rules/*.md`.  
> **Mandatory template rule:** Before creating/updating an artifact, inspect the actual approved template in `/templates` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact. If a required template does not exist, report `TEMPLATE MISSING`, propose a format if useful, and STOP for approval before adopting it.  
> **Gate rule:** At required verification/baseline gates, submit to the authorized project role and STOP until approval/revision instructions.  
> **Language rule:** All Analysis artifacts (BCE class names, attributes, operations, VOPC diagrams, Analysis Sequence Diagrams, messages, lifeline roles, and State Machine Diagrams) MUST be written in English.  
> **Master Specification Integration rule:** Upon receiving explicit approval at a verification gate, all approved Analysis artifacts (BCE class catalogs, VOPC diagrams, Analysis Sequence Diagrams, and State Machine Diagrams) MUST be immediately integrated and synchronized into Chapter IV of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`). Progression to Phase 07 (Design) is blocked until this integration is complete.  
> **Presentation rule:** All specification text must be justified across both margins (`both`), with standard body paragraphs indented 0.5 cm. Table captions MUST be placed ABOVE the table (`Table 4.<Seq>: <Title>`). In tables, header rows MUST be centered, bold, and unindented; table body cell contents MUST be justified across both margins without indentation (`first_line_indent = 0 cm`). Figure captions MUST be placed BELOW the figure (`Figure 4.<Seq>: <Title>`), centered.  
> **Diagram image rule (Mandatory Two-Step Workflow):** All Analysis diagrams (BCE, VOPC, Analysis Sequence, State Machines) MUST strictly follow the two-step workflow: (1) Export to editable master `.drawio` files first (saved in `artifacts/diagrams/class/` for BCE/VOPC class diagrams, `artifacts/diagrams/sequence/` for Analysis Sequence Diagrams, and `artifacts/diagrams/state-machine/` for State Machines); (2) Only then export from `.drawio` to high-resolution static image files (`.png` in `artifacts/diagrams/images/`) before being embedded into Chapter IV of the Master Specification Document. Creating an image without its corresponding `.drawio` master is strictly prohibited.  
> **Connector Routing & Anti-Overlap Invariant:** In all analysis diagrams (VOPC, BCE, Sequence, State Machine), message flows, transitions, and class associations MUST NEVER cut across unrelated classes, lifelines, states, or notes. Use orthogonal routing with explicit waypoints, anchor to explicit perimeter ports (`exitX/Y`, `entryX/Y`), ensure message/transition/guard labels have opaque backgrounds (`labelBackgroundColor=#ffffff`), and maintain at least 60–80px spacing between classes/states. Visually inspect rendered `.png` images to verify zero collision between lines, labels, and shapes before document embedding.

# Analysis Modeling Skill
## Entry
Approved Requirements Baseline or explicitly authorized iterative input.
## Workflow
1. Inspect Analysis sections of the approved master specification.
2. Read complete approved Use Case and related requirements/activity/prototype.
3. Identify BCE classes: Boundary, Control, Entity.
4. Populate BCE information only in the approved format.
5. Create VOPC (View of Participating Classes) as an analysis-level UML class diagram and save the editable `.drawio` master in `artifacts/diagrams/class/` first. Keep the exported PNG in `artifacts/diagrams/images/` and update catalog/verification source paths whenever a master is relocated.
6. Create Analysis Sequence Diagrams using BCE objects, exporting to `.drawio` format first.
7. Model significant alternatives/exceptions where required.
8. Create State Machine Diagrams where lifecycle/state-dependent behavior exists, exporting to `.drawio` format first.
9. Verify `UC ↔ Activity ↔ BCE ↔ VOPC ↔ Analysis Sequence ↔ State Machine`.
10. Export all `.drawio` diagrams to high-resolution `.png` images in `artifacts/diagrams/images/`.
11. Insert/reference outputs in Chapter IV of the approved master specification (`Requirements_Analysis_Design_Specification.docx`), update traceability and apply checklist.
## Constraint
Remain technology-independent; do not prematurely introduce final framework/database implementation details.
## Gate
Submit to System Analyst + Architect/Technical Lead + applicable reviewer; STOP until Analysis Baseline approval. Upon receiving explicit approval, integrate and synchronize all approved analysis models, diagrams, and specifications into Chapter IV of the Master Specification Document before proceeding to Design.
