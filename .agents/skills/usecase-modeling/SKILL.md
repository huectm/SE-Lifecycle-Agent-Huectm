---
name: usecase-modeling
description: "Model actors and use cases, specify interaction flows, and create activity diagrams using project rules, approved templates, and verification gates."
---

> **Version:** 3.0 — Template-Driven  
> **Governance:** `/AGENTS.md` and applicable `.agents/Rules/*.md`.  
> **Mandatory template rule:** Before creating/updating an artifact, inspect the actual approved template in `/templates` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact. If a required template does not exist, report `TEMPLATE MISSING`, propose a format if useful, and STOP for approval before adopting it.  
> **Gate rule:** At required verification/baseline gates, submit to the authorized project role and STOP until approval/revision instructions.  
> **Language rule:** All Use Case diagrams, actor names, use case names, relationship stereotypes, structured use case descriptions (preconditions, postconditions, normal/alternative/exception flows), and Activity Diagrams (swimlanes, action nodes, decision guards) MUST be written in English.  
> **Granularity rule:** Do NOT decompose Use Cases into micro-actions or UI interaction steps (e.g. Select Category, Select Supplier, Enter Batch Details, Calculate Total). These belong in Use Case Descriptions and Activity Diagrams, NOT as separate Use Cases.  
> **Use Case Description Packaging rule:** Distinct Use Cases with different primary business goals MUST be documented in separate Use Case Descriptions. Exceptions: (1) Extended Use Cases (`<<extend>>`) can be described within the Alternative Flows (or Extension Points) of the base/general Use Case description; (2) Included Use Cases (`<<include>>`) that form a mandatory part of the main flow can be described together within the Normal Flow of the base Use Case description without creating fragmented separate documents.  
> **Boundary & Layout rule:** All Use Cases MUST be enclosed inside ONE single System Boundary rectangle with sharp corners (`rounded=0`, no rounded/curved corners). Actors MUST be placed OUTSIDE the boundary (Primary Actor on the LEFT). Never place actors in the middle of scattered packages. Optimize internal layout for A4 document readability without blurriness.  
> **Master Specification Integration rule:** Upon receiving explicit approval at a verification gate, all approved Use Case models (General and decomposed Use Case diagrams, structured Use Case descriptions, and Activity diagrams) MUST be immediately integrated and synchronized into Chapter III of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).  
> **Diagram image rule (Mandatory Two-Step Workflow):** All Use Case diagrams (General, decomposed, common) and Activity diagrams MUST strictly follow the two-step workflow: (1) Export to an editable master `.drawio` file first (in `artifacts/diagrams/use-case/` or `artifacts/diagrams/activity/`); (2) Only then export from the `.drawio` file to a high-resolution static image file (`.png` in `artifacts/diagrams/images/`) before being embedded into specification documents. Generating an image without its corresponding `.drawio` master is strictly prohibited.  
> **Connector Routing & Anti-Overlap Invariant:** When constructing diagrams in `.drawio` (Use Case diagrams, Activity diagrams), all connector lines (`<<include>>`, `<<extend>>`, associations, generalizations, activity control flows) MUST NEVER cut across unrelated use case ellipses, actor icons, boundary frames, action nodes, or notes. Use orthogonal routing with explicit waypoints, anchor to explicit perimeter ports (`exitX/Y`, `entryX/Y`), ensure all labels (`<<include>>`, `<<extend>>`, condition guards) have opaque backgrounds (`labelBackgroundColor=#ffffff`), and maintain at least 60–80px spacing between use cases. Visually inspect rendered `.png` images to verify zero collision between lines, labels, and shapes before document embedding.

# Use Case Modeling Skill
## Workflow
1. Inspect approved Use Case sections/templates.
2. Read approved UR, FR, BR, TO-BE process and prototypes.
3. Identify Actors and actor goals; classify Primary/Secondary where appropriate.
4. Derive Use Cases and stable IDs per `requirements-rules.md` §8.3 (`UC-<group><nn>`, decomposed `UC-<general>.<n>`).
5. Create/update the **Use Case List** (`artifacts/diagrams/use-case/use-case-list.md`) and verify `UR/FR/source ↔ UC` coverage, unsupported UCs, and ID/name consistency across all diagrams. Submit the list and STOP for approval BEFORE drawing diagrams.
6. Use UML Associations with Karl Wiegers directional arrows (Primary Actor &rarr; UC, UC &rarr; Support Actor), `<<include>>` (Base &rarr; Included, mandatory only), `<<extend>>` (Extension &rarr; Base, optional/conditional with condition label), and Generalization (same-goal UCs → General UC) per `requirements-rules.md` §8.2. Enforce proper granularity: no micro-actions as UCs.
7. Construct and export the General diagram and decomposed diagrams as editable `.drawio` files first: single actor only per decomposed diagram; place actor OUTSIDE on the left; enclose all use cases inside ONE single System Boundary rectangle; decompose every general UC of that actor (CRUD pattern: `Manage X` includes `View X List`; Add/Update/Delete extend `Manage X`); keep all General-diagram UCs; draw UCs common to all actors only in the common-functions diagram.
8. Populate Use Case descriptions using the exact approved fields/order: distinct UCs MUST have separate descriptions; extended UCs (`<<extend>>`) are described in Alternative Flows of their base UC; included UCs (`<<include>>`) in the main flow are described within the Normal Flow of their base UC.
9. For complex UCs create UML Activity Diagrams with swimlanes, exporting to `.drawio` files first.
10. Export all `.drawio` diagrams to high-resolution `.png` images in `artifacts/diagrams/images/`.
11. Reference prototypes where needed.
12. Verify `Diagram ↔ Description ↔ Activity ↔ Prototype ↔ Requirements`.
13. Insert/reference outputs in the approved master specification, update RTM and apply checklist.
## Gate
Submit to appropriate Business/System Analyst, Product Owner and QA/Test roles; STOP until required approval. Upon receiving explicit approval, integrate and synchronize all approved Use Case diagrams, descriptions, and activity models into Chapter III of the Master Specification Document.
