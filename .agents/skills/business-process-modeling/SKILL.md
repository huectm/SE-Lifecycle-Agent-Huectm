---
name: business-process-modeling
description: "Discover AS-IS and TO-BE business processes, model BPMN, and identify user classes using project rules and templates."
---

> **Version:** 3.0 — Template-Driven  
> **Governance:** `/AGENTS.md` and applicable `.agents/Rules/*.md`.  
> **Mandatory template rule:** Before creating/updating an artifact, inspect the actual approved template in `/templates` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact. If a required template does not exist, report `TEMPLATE MISSING`, propose a format if useful, and STOP for approval before adopting it.  
> **Gate rule:** At required verification/baseline gates, submit to the authorized project role and STOP until approval/revision instructions.  
> **Language rule:** All BPMN diagrams, pool/lane names, task/activity labels, gateway decisions, event names, and data object labels MUST be written in English.  
> **Master Specification Integration rule:** Upon receiving explicit approval at a verification gate, all approved Business Process models (AS-IS and TO-BE BPMN diagrams, process narratives, and pain point analyses) MUST be immediately integrated and synchronized into Chapter II of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).  
> **Mandatory Two-Step Diagram Rule:** All BPMN diagrams (AS-IS and TO-BE) MUST strictly follow the two-step workflow: (1) Export to an editable master `.drawio` file first (in `artifacts/diagrams/business-process/`); (2) Only then export from the `.drawio` file to a high-resolution static image file (`.png` in `artifacts/diagrams/images/`) before being embedded into specification documents. Generating an image without its corresponding `.drawio` master is strictly prohibited.  
> **Connector Routing & Anti-Overlap Invariant:** In all BPMN models, sequence flows and message flows MUST NEVER cut across unrelated tasks, subprocesses, gateways, data objects, or pool/lane boundaries. Use orthogonal routing with explicit waypoints, anchor to explicit perimeter ports (`exitX/Y`, `entryX/Y`), ensure gateway branch condition labels have opaque backgrounds (`labelBackgroundColor=#ffffff`), and maintain clear channel spacing between parallel flows. Visually inspect rendered `.png` images to verify zero collision between lines, labels, and shapes before document embedding.

# Business Process Modeling Skill
## Workflow
1. Inspect approved BPMN/process template or master-document section.
2. Define process scope, trigger, outcome, participants, Process Owner and evidence.
3. Discover AS-IS activities, decisions, handoffs, data, systems, exceptions and rules.
4. Model AS-IS using BPMN.
5. Identify evidence-supported pain points/opportunities.
6. Derive/propose TO-BE from approved objectives, scope, Business Rules and decisions.
7. Model TO-BE using BPMN in `.drawio` format first.
8. Verify `Objectives ↔ Rules ↔ AS-IS ↔ TO-BE`.
9. Export `.drawio` diagrams to high-resolution `.png` images.
10. Identify process-derived user needs/candidate system responsibilities without silently approving FRs.
11. Insert/reference diagrams in the approved specification and update traceability.
12. Apply applicable checklist.
## Output
Mandatory editable `.drawio` files in `artifacts/diagrams/business-process/` as master sources, followed by exported `.png` images in `artifacts/diagrams/images/`. Do not substitute UML Activity notation for BPMN.
## Gate
Submit to BA + Domain Expert/Process Owner + Product Owner/authorized stakeholder; STOP when approval is required. Upon receiving explicit approval, integrate and synchronize all approved BPMN process models and documentation into Chapter II of the Master Specification Document.
