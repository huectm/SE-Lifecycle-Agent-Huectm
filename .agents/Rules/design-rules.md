# Software Design Rules

## 1. Purpose
These rules govern high-level and detailed software design.

## 2. Entry Criteria
Design uses approved requirements and analysis artifacts as inputs. Significant unresolved requirement/analysis defects MUST be addressed or explicitly accepted before design is baselined.

## 3. Architecture Drivers
Architecture decisions MUST be justified by:
- Functional Requirements
- Quality Attributes
- Constraints
- Integration needs
- Data requirements
- Deployment needs
- Risks

Do not select architecture styles or patterns only because they are popular.

## 4. Architecture Selection
Possible approaches include, when justified:
- Layered Architecture
- MVC
- MVVM
- Component-Based Architecture
- Service-Oriented Architecture
- Microservices
- Modular Monolith
- Repository Pattern
- Dependency Injection

The selected approach MUST include rationale and trade-offs.

## 5. High-Level Design & System Architecture Diagram Standard
High-level design SHOULD define:
- system/subsystem boundaries;
- major components/services;
- responsibilities;
- dependencies;
- external integrations;
- deployment-relevant boundaries where applicable.

### 5.1 System Architecture Diagram Conventions (Reference: `examples/System Architecture .png`)
When constructing the High-Level System Architecture diagram:
1. **System Boundary Frame:** Clearly distinguish the internal system boundary from external services using a labeled outer container box (`<System Name> SYSTEM`).
2. **Subsystem Stereotypes:** Each subsystem/service box must explicitly declare its type using stereotypes in guillemets (e.g., `<<Service>>`, `<<Webserver>>` / `<<WebApp>>`, `<<MobileApp>>`, `<<Database>>`, `<<Client Device>>` / `<<Web Browser>>`, `<<Hardware Device>>`).
3. **Implementation Technology Logos/Icons:** Every subsystem/service box must visibly embed or represent the official technology icon/logo (e.g., .NET Core, React, Vue, Flutter, Python, PostgreSQL, SQL Server, Google Maps, SePay, Firebase, etc.).
4. **Inter-System Collaboration Protocols:** All communication flows between subsystems and external systems must be explicitly labeled with directional arrows and collaboration protocol types (e.g., `Https Request`, `Https Response`, `SQL Query`, `SQL Response`, `Webhook HTTP POST`, `ESC/POS Raw Command`).
5. **Color Legend:** Include a visual color legend at the bottom separating internal system components (e.g. light blue `#D9E8FB`) from external services/devices (e.g. light yellow `#FFF2CC`).
6. **Pre-Drawing Confirmation Gate:** Before constructing the `.drawio` diagram, the Agent MUST propose the subsystem decomposition, stereotypes, assigned technologies/logos, and collaboration flows to the User for explicit confirmation.

## 6. Component and Package Design
Components/packages MUST have cohesive responsibilities and controlled dependencies.

Avoid cyclic dependencies unless explicitly justified.

### 6.1 UML Component Interface Notation (Reference: `examples/ComponentDiagram .png`)
For every Component Diagram creation or revision, inspect the reference image before drawing and apply the following notation:
1. Use UML component rectangles with the component glyph at the upper-right corner, the `<<component>>` stereotype and a responsibility-based name. Add `<<subsystem>>`, `<<service>>` or `<<library>>` where the element role justifies it.
2. Show each provided interface as a named circle (lollipop) connected to its provider by a solid line. Show each required interface as a semicircular socket connected to its consumer by a solid line, with the socket opening toward the provider's circle. Use a ball-and-socket assembly for compatible contracts.
3. Label the assembly with the interface name outside the circle/socket. If several consumers share a contract, repeat the same named interface symbol per assembly when needed for clear routing; repetition does not create new contracts.
4. Use solid, arrowless assembly connections for interface collaboration. Reserve dashed dependencies for additional explicitly modeled dependency semantics. In this project's Component views, use lollipop/socket symbols rather than rectangular `<<interface>>` classifiers or realization triangles as the primary interface representation.
5. Preserve the reference's component glyphs and readable styling while deriving component names, responsibilities and interface contracts from approved project sources. The example does not supply business requirements, technology choices or components.
6. Apply the existing `.drawio` ? `.png` workflow and connector clearance rules. Verify each socket's consumer, each circle's provider and compatible contract names during visual review.

### 6.2 Component View Scope, Naming and Layout
1. Focus Component Diagrams on software components, component types, and provided/required interfaces. Omit implementation technologies, frameworks, vendor logos, database/datastore elements, physical devices, actors and deployment details from this view; retain those in the appropriate architecture, database or deployment views.
2. Use the same names as the corresponding subsystems in the High-Level Architecture Diagram. For an internal component without a separate subsystem counterpart, use a parent-qualified name and record its mapping to that subsystem. For example, `FreshFood-API.DataAccess` belongs to `FreshFood-API`; it does not introduce another subsystem.
3. Present components without a system/subsystem boundary frame. Component types and names communicate the decomposition; document internal ownership in the component catalog.
4. Keep peer component rectangles comparable in size, sized for their names and stereotypes. Distribute components across balanced rows/columns with dedicated interface corridors; avoid an oversized central component, overlapping shapes or labels, and a single vertical stack of all components.
5. Use the supplied ComponentDiagram reference for UML glyphs, ball-and-socket notation and balanced grouping. Check scope exclusions, architecture-name consistency, component size balance and connector clearance before delivery.

## 7. Analysis-to-Design Mapping
Every significant analysis class/responsibility MUST be mapped to one or more design elements or explicitly marked as transformed/merged/removed with rationale.

Maintain a mapping table when appropriate:
| Analysis Element | Design Element | Mapping / Rationale |

## 8. Detailed Use Case Realization
After architecture is approved, realize Use Cases at design level.

Design Sequence Diagrams MUST:
- reflect approved Use Case behavior;
- use actual design classes/components;
- respect architecture boundaries;
- show important calls/messages;
- remain consistent with class responsibilities.

## 9. Detailed Class Design
Detailed class specifications SHOULD include, where relevant:
- responsibility;
- attributes;
- operations;
- visibility;
- parameter/return types;
- relationships;
- interfaces;
- constraints.

Do not add methods/fields without responsibility or requirement/design rationale.

## 10. Design Patterns
Patterns such as Repository and Dependency Injection MUST be applied because they solve identified design problems, not as mandatory decoration.

## 11. Quality Attributes
Design MUST explicitly address applicable quality attributes such as performance, security, reliability, availability, maintainability, scalability, and testability.

## 12. Mandatory Diagram Format & Two-Step Workflow
All Architecture, Component, Package, Design Sequence, Detailed Design Class, and Deployment diagrams MUST be constructed and exported as editable `.drawio` files FIRST into their designated directories (`artifacts/diagrams/architecture/`, `artifacts/diagrams/class/`, `artifacts/diagrams/sequence/`). Only after the `.drawio` master file is validated may high-resolution `.png` images be exported from it.

## 13. Design Review
Apply the project Design Review Checklist before baselining. Record findings, fixes, and unresolved issues.

## 14. Verification Gate
Verify:
Requirements ↔ Analysis ↔ Architecture ↔ Detailed Design.

Design MUST be approved before implementation proceeds beyond explicitly authorized prototypes/spikes.

## 15. Master Specification Document Integration Rule (Post-Approval)
- Upon obtaining approval at the Design Baseline Gate:
  1. The Agent MUST immediately incorporate and synchronize all approved high-level architecture and detailed design artifacts into **Chapter V (Software Design)** of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).
  2. This includes:
     - Architecture styles, patterns, drivers, and trade-off rationales;
     - Subsystem and Component/Package diagrams with interface definitions;
     - Analysis-to-Design class mappings;
     - Design Sequence Diagrams for key use cases;
     - Detailed Design Class Diagrams (DCD) and detailed class specifications (attributes, operations, visibility, parameter and return types);
     - Database conceptual/logical/physical models and schema tables.
  3. Embedded diagram figures must be placed directly in their corresponding Chapter V subsections alongside the technical narrative and tables.
  4. Progression to Phase 08 (Implementation) is strictly blocked until Chapter V of the Master Specification Document is fully populated and verified.

## 16. Mandatory English Language Policy
- All software design artifacts, architecture descriptions, subsystem/component/package names, Design Sequence Diagrams, Detailed Design Class Diagrams, class specifications, attributes, method signatures, parameters, return types, interfaces, design patterns, and deployment diagrams MUST be specified in **English**.

## 17. Document Presentation and Formatting Conventions (Quy tắc trình bày và định dạng)
In Chapter V (Software Design & Database Design) of the Master Specification Document:
1. **Body Text Paragraphs (Đoạn văn bản):** Justified alignment across both margins (`WD_ALIGN_PARAGRAPH.JUSTIFY` / căn đều 2 bên), standard narrative paragraphs indented by **0.5 cm** (`first_line_indent = 0.5 cm` / `~14.17 pt`).
2. **Table Formatting, Captions & Cell Content (Tiêu đề và nội dung bảng):** Placed directly **ABOVE** the table, following the convention: `Table 5.<Seq>: <Table_Title>`. Header row text must be centered (`alignment = WD_ALIGN_PARAGRAPH.CENTER`), bold, unindented. Body cell content must be justified across both margins (`alignment = WD_ALIGN_PARAGRAPH.JUSTIFY`), unindented (`first_line_indent = 0 cm` / không thụt lùi dòng).
3. **Figure / Diagram Formatting & Caption Numbering (Tiêu đề hình):** Placed directly **BELOW** the figure, centered, following the convention: `Figure 5.<Seq>: <Figure_Title>` (tiêu đề hình ở dưới, đánh số theo Chương.thứ tự hình trong chương).

## 18. Mandatory Two-Step Diagram Generation and Static Image Embedding Rule (Quy tắc bắt buộc xuất biểu đồ ra file .drawio trước, sau đó mới xuất ra file ảnh tĩnh)
All software design and architecture diagrams (Architecture Views, Subsystems, Component/Package diagrams, Design Sequence Diagrams, Detailed Design Class Diagrams, and Deployment diagrams) MUST strictly follow a **mandatory two-step workflow**:
1. **Step 1 — Mandatory Master Source Export to `.drawio` (Bắt buộc xuất file nguồn `.drawio` trước tiên):** Every software design diagram MUST be constructed and exported as an editable XML master file with extension `.drawio` in designated subdirectories under `artifacts/diagrams/`. The `.drawio` format is the sole authoritative master format. Creating an image without its corresponding `.drawio` master file is strictly prohibited.
2. **Step 2 — Static Image Export & Embedding (`.drawio` → `.png`) (Từ file `.drawio` mới xuất ra file ảnh tĩnh):**
   - **Anti-Drift Guarantee:** Only after the `.drawio` master file is validated, the diagram is exported into a high-resolution static `.png` image (in `artifacts/diagrams/images/` and/or alongside the `.drawio` file) and embedded into Chapter V of the Master Specification Document (`Requirements_Analysis_Design_Specification.docx`).
   - Protects the design specification from rendering errors, class layout shifting, line disconnection, or font discrepancies so that the visual model in the deliverable strictly matches the approved design baseline.
3. **Dual-Artifact Storage:** Editable `.drawio` files are maintained in `artifacts/diagrams/architecture/`, `artifacts/diagrams/class/`, or `artifacts/diagrams/sequence/` as editable master models; exported `.png` files in `artifacts/diagrams/images/` are embedded into the specification document.
4. **Mandatory Synchronization:** Any revision to a design diagram requires updating the source `.drawio` file first, re-exporting the static `.png` image, and immediately updating Chapter V of the Master Specification Document.

### 18.1 Diagram Layout, Connector Routing, and Notation Anti-Overlap Invariant (Quy tắc định tuyến đường kết nối và chống vẽ đè chồng lên các notation)
All architecture and detailed design diagrams (Subsystems, Components, Packages, Design Class Diagrams, Sequence Diagrams, Deployment Diagrams) MUST strictly enforce collision-free layout and connector routing:
1. **Zero Obstacle Crossing:** Dependency arrows, associations, generalizations, interfaces, and component connections MUST NEVER cut across or pass underneath any unrelated component boxes, class boxes, package boundaries, or notes.
2. **Orthogonal Routing & Explicit Waypoints:** Use orthogonal routing (`edgeStyle=orthogonalEdgeStyle;`). Define explicit intermediate waypoints (`<Array as="points"><mxPoint x="..." y="..."/></Array>`) when navigating around shapes.
3. **Explicit Perimeter Port Anchoring:** Connectors MUST anchor to explicit perimeter ports (`exitX, exitY` and `entryX, entryY`) on node boundaries. Never default to node centers.
4. **Label Clearance & Background Protection:** Every text label (operation names, stereotyped messages, interface signatures, multiplicity) MUST have an opaque background (`labelBackgroundColor=#ffffff`). Multiplicity labels and method signatures MUST NOT collide with class borders or internal text.
5. **Layout Spacing & Channel Width:** Maintain a minimum channel spacing of **60–80px** horizontally and vertically between adjacent classes, components, and packages.
6. **Pre-Export Visual Anti-Overlap Inspection:** After exporting from `.drawio` to `.png`, visually inspect the rendered image to verify zero collision between lines, labels, and shapes. Fix any collision in `.drawio` before deliverable embedding.



