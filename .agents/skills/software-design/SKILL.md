---
name: software-design
description: "Develop high-level architecture and detailed design from approved analysis using project templates and verification gates."
---

> **Version:** 3.3 — Template-Driven  
> **Governance:** `/AGENTS.md` and applicable `.agents/Rules/*.md`.  
> **Mandatory template rule:** Before creating/updating an artifact, inspect the actual approved template in `/templates` (sections, sheets, columns, fields, formulas, validation, naming, embedded result/report areas). Populate the existing structure. Do **not** add/delete/rename/reorder/redesign it without authorization. If an approved template already contains the required output/report, do not create a duplicate artifact. If a required template does not exist, report `TEMPLATE MISSING`, propose a format if useful, and STOP for approval before adopting it.  
> **Gate rule:** At required verification/baseline gates, submit to the authorized project role and STOP until approval/revision instructions.  
> **Language rule:** All Architecture and Detailed Design artifacts (Architecture diagrams, style rationales, Component/Package diagrams, Design Sequence Diagrams, Detailed Design Class Diagrams, class specifications, method signatures, parameters, return types, design patterns, and interface contracts) MUST be written in English.  
> **Master Specification Integration rule:** Upon receiving explicit approval at a verification gate, all approved Software Design artifacts (Architecture styles, Component diagrams, Design Sequence Diagrams, Detailed Design Class Diagrams, and Class Specifications) MUST be immediately integrated and synchronized into Chapter V of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`). Progression to Phase 08 (Implementation) is blocked until this integration is complete.  
> **Presentation rule:** All specification text must be justified across both margins (`both`), with standard body paragraphs indented 0.5 cm. Table captions MUST be placed ABOVE the table (`Table 5.<Seq>: <Title>`). In tables, header rows MUST be centered, bold, and unindented; table body cell contents MUST be justified across both margins without indentation (`first_line_indent = 0 cm`). Figure captions MUST be placed BELOW the figure (`Figure 5.<Seq>: <Title>`), centered.  
> **Diagram image rule (Mandatory Two-Step Workflow):** All Software Design diagrams (Architecture Views, Component/Package diagrams, Design Sequence Diagrams, Detailed Design Class Diagrams) MUST strictly follow the two-step workflow: (1) Export to editable master `.drawio` files first (saved in `artifacts/diagrams/architecture/`, `artifacts/diagrams/class/`, or `artifacts/diagrams/sequence/`); (2) Only then export from `.drawio` to high-resolution static image files (`.png` in `artifacts/diagrams/images/`) before being embedded into Chapter V of the Master Specification Document. Creating an image without its corresponding `.drawio` master is strictly prohibited.  
> **Connector Routing & Anti-Overlap Invariant:** When constructing diagrams in `.drawio` (Architecture Views, Subsystems, Component/Package diagrams, Sequence Diagrams, Detailed Design Class Diagrams), all connector lines (dependencies, associations, generalizations, interfaces, calls) MUST NEVER cut across unrelated component boxes, class boxes, package boundaries, or notes. Use orthogonal routing with explicit waypoints (`<Array as="points"><mxPoint .../></Array>`), anchor to explicit perimeter ports (`exitX/Y`, `entryX/Y`), ensure all text labels (interface signatures, verbs, stereotypes, multiplicity) have opaque backgrounds (`labelBackgroundColor=#ffffff`), and maintain at least 60–80px spacing between components/classes. Visually inspect rendered `.png` images to verify zero collision between lines, labels, and shapes before document embedding.

# Software Design Skill
## A. High-Level Architecture
When the requested view is a DFD System Context Diagram, use `requirements-engineering` and `.agents/Rules/requirements-rules.md` Section 8.5 for its compact central circle and balanced surrounding external entities, including when its file is stored under `artifacts/diagrams/architecture/`. The subsystem architecture conventions below apply to architecture views.

1. Inspect Design sections of the approved master specification.
2. Identify architecture drivers from FRs, Quality Attributes, Constraints, integrations, data, deployment and risks.
3. Evaluate/select justified styles/patterns such as Layered, MVC, MVVM, Component-Based, SOA, Modular Monolith, Microservices, Repository and DI.
4. Record rationale/trade-offs using the approved structure.
5. Define subsystems/components/services/interfaces/dependencies.
6. **Overall System Architecture Diagram Conventions (Reference: `examples/System Architecture .png`):**
   - **System Boundary Frame:** Clearly bound internal subsystems inside a container labeled `<System Name> SYSTEM`. External services/peripherals/devices placed outside.
   - **Subsystem Stereotypes:** Explicitly declare stereotype on each subsystem/service box: `<<Service>>`, `<<Webserver>>` / `<<WebApp>>`, `<<MobileApp>>`, `<<Database>>`, `<<Web Browser>>` / `<<Client Device>>`, `<<Hardware Device>>`.
   - **Technology Implementation Icons:** Prominently embed official technology icons/logos (e.g., .NET Core, React, Vue, Flutter, Python, PostgreSQL, SQL Server, Google Maps, SePay, Firebase, etc.).
   - **Inter-System Collaboration Protocols:** Directional arrows explicitly labeled with communication types: `Https Request`, `Https Response`, `SQL Query`, `SQL Response`, `Webhook HTTP POST`, `ESC/POS Raw Command`.
   - **Visual Legend:** Distinguish internal subsystems (light blue `#D9E8FB`) from external services (light yellow `#FFF2CC`).
7. **Pre-Drawing Confirmation Gate:** BEFORE drawing the architecture diagram in `.drawio`, the Agent MUST outline the subsystem breakdown, stereotypes, assigned technologies/logos, and collaboration flows, and obtain explicit user confirmation.
8. Create required Architecture/Component/Package diagrams and export to `.drawio` format first. For Component Diagrams, first inspect `examples/ComponentDiagram .png` and apply `.agents/Rules/design-rules.md` ??6.1?6.2: UML component glyphs, named provided-interface circles (lollipops), required-interface sockets, and solid arrowless assembly connections. Show only software components, types and interfaces; omit technologies, database elements and boundary frames. Match High-Level Architecture subsystem names, qualify internal component names by their parent, and use comparable component sizes in a balanced layout. Verify provider/consumer direction, contract compatibility, naming and visual clearance before PNG export.
9. Coordinate with `database-design`; verify quality-attribute support.
## B. Detailed Design
After architecture & database design approval:
- **Trigger System Integration Test Design:** Invoke `software-testing` to create the System Integration Test Plan and API/Interface Test Cases (`Template_Integration Test Case.xls`) covering 100% of inter-subsystem and external gateway interfaces.
- Proceed to Detailed Design:
1. Map Analysis classes/responsibilities to Design classes/components/services. For creation, revision, or review of Detailed Design Class Diagrams, first read [Detailed class design conventions](references/detailed-class-design.md); apply the project decisions on VOPC realization, View layers, backend-only DI, relationship semantics, DTO usage, table-driven state-machine control, and layout.
2. For detailed design/source mapping, read [PIM to code mapping](references/pim-code-mapping.md). FreshFood detailed class and sequence diagrams are PIM; verify their logical contracts and behavioral realization through an explicit mapping to C# rather than requiring identical platform signatures. Create Design Sequence Diagrams, exporting to `.drawio` format first.
3. Create Detailed Design Class Diagrams, exporting to `.drawio` format first.
4. Populate detailed class specifications using exact approved fields.
5. Export all `.drawio` design diagrams to high-resolution `.png` images in `artifacts/diagrams/images/`.
6. Verify architecture boundaries and `Requirements ↔ Analysis ↔ Architecture ↔ Detailed Design`.
7. Insert/reference outputs in designated sections of Chapter V in the approved master specification (`Requirements_Analysis_Design_Specification.docx`), update RTM and apply Design Review Checklist.
## Gate
Submit to Architect/Technical Lead and authorized roles; STOP until Design Baseline approval. Upon receiving explicit approval:
1. Integrate and synchronize all approved architecture models, component diagrams, sequence diagrams, DCDs, and class specifications into Chapter V of the Master Specification Document.
2. **Invoke `software-testing` to initiate Module Integration & Unit Test Planning & Design** (`Template_Integration Test Case.xls` and `Template_Unit Test Case.xls`) covering normal, boundary, and abnormal input groups, and meeting normative TC/KLOC requirements before proceeding to Implementation.
