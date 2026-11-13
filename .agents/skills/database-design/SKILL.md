---
name: database-design
description: "Develop conceptual, logical, and physical database designs from approved requirements and analysis entities using project templates and verification gates."
---

> **Version:** 3.0 — Template-Driven  
> **Governance:** `/AGENTS.md` and applicable `.agents/Rules/*.md`.  
> **Mandatory template rule:** Before creating/updating an artifact, inspect the actual approved template in `/templates` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact. If a required template does not exist, report `TEMPLATE MISSING`, propose a format if useful, and STOP for approval before adopting it.  
> **Gate rule:** At required verification/baseline gates, submit to the authorized project role and STOP until approval/revision instructions.  
> **Language rule:** All database design artifacts (conceptual/logical ERDs, physical schemas, table names, column names, constraints, keys, indexes, DDL scripts, data dictionaries) MUST be written in English.  
> **Master Specification Integration rule:** Upon receiving explicit approval at a verification gate, all approved Database Design artifacts (Conceptual/Logical/Physical ERDs, Schema Tables, Data Dictionary, and Constraints) MUST be immediately integrated and synchronized into the Database Design section of Chapter V in the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).  
> **Presentation rule:** All specification text must be justified across both margins (`both`), with standard body paragraphs indented 0.5 cm. Table captions MUST be placed ABOVE the table (`Table 5.<Seq>: <Title>`). In tables, header rows MUST be centered, bold, and unindented; table body cell contents MUST be justified across both margins without indentation (`first_line_indent = 0 cm`). Figure captions MUST be placed BELOW the figure (`Figure 5.<Seq>: <Title>`), centered.  
> **Diagram image rule (Mandatory Two-Step Workflow):** All Database ERD models (Conceptual, Logical, Physical) MUST strictly follow the two-step workflow: (1) Export to editable master `.drawio` files first in `artifacts/diagrams/database/`; (2) Only then export from `.drawio` to high-resolution static image files (`.png` in `artifacts/diagrams/images/`) before being embedded into Chapter V of the Master Specification Document. Creating an image without its corresponding `.drawio` master is strictly prohibited.  
> **Connector Routing & Anti-Overlap Invariant:** In all ERD diagrams (Conceptual, Logical, Physical), relationship lines and crow's foot connectors MUST NEVER cut across or pass underneath unrelated tables, entity boxes, or note boxes. Use orthogonal routing with explicit waypoints, anchor to explicit perimeter ports (`exitX/Y`, `entryX/Y`), ensure cardinality labels and relationship verbs have opaque backgrounds (`labelBackgroundColor=#ffffff`), and maintain at least 60–80px spacing between entity tables. Visually inspect rendered `.png` images to verify zero collision between lines, labels, and shapes before document embedding.

# Database Design Skill
## Workflow
1. Inspect approved database-design section/template.
2. Read Data Requirements, BRs, FRs, UCs, analysis Entities and architecture.
3. Identify conceptual entities/relationships; define identifiers, attributes, cardinalities, optionality and integrity rules.
4. Create conceptual and logical models in editable `.drawio` format first.
5. Normalize appropriately and document justified denormalization.
6. Create physical schema for approved DB technology, generating physical ERD in `.drawio` format.
7. Export all `.drawio` ERD models to high-resolution `.png` images in `artifacts/diagrams/images/`.
8. Add only justified technical fields/indexes/audit metadata.
9. Address referential integrity, privacy, security, retention, audit and migration implications.
10. Verify `Requirements ↔ Analysis Entities ↔ Design ↔ Database`.
11. Populate/reference outputs in Chapter V (Database Design) of the approved template (`Requirements_Analysis_Design_Specification.docx`); update RTM and apply checklist.
## Gate
Submit to Database Designer + Architect/Technical Lead + Security/Compliance where applicable; STOP until approval. Upon receiving explicit approval, integrate and synchronize all approved ERDs, database schemas, table dictionaries, and constraints into Chapter V (Database Design) of the Master Specification Document.
