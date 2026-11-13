# Software Analysis Rules

## 1. Purpose
These rules govern analysis activities after the Requirements Baseline is approved.

## 2. Entry Criteria
Analysis MUST NOT begin until applicable requirements are approved/baselined or explicitly authorized for iterative analysis.

Required inputs may include:
- Software Requirements
- Use Case Model and Use Case Descriptions
- Activity Diagrams
- Business Rules
- Data Requirements
- Prototypes
- Traceability information

## 3. BCE Analysis
For each significant Use Case, identify participating analysis classes using BCE:
- Boundary: interaction between actors/external systems and the system.
- Control: coordinates use-case behavior/business flow.
- Entity: represents persistent or domain information.

Do NOT force a fixed number of BCE classes. Classes must be justified by responsibilities.

## 4. Boundary Rules
Boundary classes SHOULD correspond to meaningful interaction points such as UI screens/forms, APIs, external-system adapters, or interfaces.

Do not model every UI widget as a separate Boundary class unless justified.

## 5. Control Rules
Control classes coordinate use-case flow. Avoid placing persistent domain state or low-level infrastructure responsibilities in Control classes.

A complex Use Case MAY require more than one Control class when responsibilities justify it.

## 6. Entity Rules
Entity classes MUST derive from domain/data concepts supported by approved requirements. Do not invent entities without an approved source or documented design rationale.

## 7. VOPC
Create a View of Participating Classes (VOPC) for relevant Use Cases before detailed interaction modeling.

A VOPC SHOULD show:
- participating Boundary, Control, Entity classes;
- relevant actors where the project notation requires them;
- meaningful relationships needed to understand participation.

The VOPC is an analysis-level UML class diagram, not a final design class diagram. Its authoritative editable `.drawio` master MUST be stored in `artifacts/diagrams/class/`; its exported PNG MUST be stored in `artifacts/diagrams/images/`.

## 8. Analysis Sequence Diagrams
Analysis Sequence Diagrams MUST realize approved Use Case flows using participating analysis objects.

Check:
- actor/system interactions match the Use Case Description;
- alternative/exception behavior is represented when significant;
- messages correspond to analysis responsibilities;
- no premature framework/database implementation detail is introduced.

## 9. State Machine Diagrams
Create State Machine Diagrams for entities or systems whose behavior depends materially on lifecycle state.

States and transitions MUST derive from requirements, Business Rules, Use Cases, or approved domain behavior.

Each transition SHOULD have a meaningful trigger and, where applicable, guard/action.

## 10. Analysis Class Responsibilities
Each analysis class MUST have a clear responsibility. Avoid:
- duplicate responsibilities;
- god classes;
- infrastructure-specific details;
- design patterns introduced without need.

## 11. Consistency
Verify:
Use Case ↔ Activity Diagram ↔ BCE ↔ VOPC ↔ Analysis Sequence ↔ State Machine.

Any discrepancy MUST be reported.

## 12. Mandatory Output Format & Two-Step Workflow
All UML analysis diagrams MUST be constructed and exported as editable `.drawio` files FIRST into the notation-specific directory: `artifacts/diagrams/class/` for BCE/VOPC class diagrams, `artifacts/diagrams/sequence/` for Analysis Sequence Diagrams, and `artifacts/diagrams/state-machine/` for State Machines. Only after the `.drawio` master source is validated may high-resolution `.png` images be generated from it.

## 13. Review Gate
Before Design:
1. Self-review analysis artifacts.
2. Apply applicable design/analysis checklist.
3. Run traceability/consistency checks.
4. Record defects/issues.
5. Correct and re-review.
6. Obtain approval from the responsible System Analyst / Architect / project approver.

## 14. Master Specification Document Integration Rule (Post-Approval)
- Upon obtaining approval at the Analysis Baseline Gate:
  1. The Agent MUST immediately incorporate and synchronize all approved analysis artifacts into **Chapter IV (Analysis Modeling)** of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).
  2. This includes:
     - Boundary-Control-Entity (BCE) class catalogs and responsibility descriptions;
     - View of Participating Classes (VOPC) diagrams (embedded figures and textual models);
     - Analysis Sequence Diagrams for realized use cases;
     - State Machine Diagrams for state-dependent entities.
  3. All diagram figures must be embedded directly into Chapter IV, accompanied by their detailed textual and tabular specifications.
  4. Progression to Phase 07 (Software Design) is strictly blocked until Chapter IV of the Master Specification Document is fully populated and verified.

## 15. Mandatory English Language Policy
- All analysis artifacts, class names (Boundary, Control, Entity), attributes, responsibilities, VOPC models, Analysis Sequence Diagrams, State Machine states, events, guards, and actions MUST be specified in **English**.

## 16. Document Presentation and Formatting Conventions (Quy tắc trình bày và định dạng)
In Chapter IV (Analysis Modeling) of the Master Specification Document:
1. **Body Text Paragraphs (Đoạn văn bản):** Justified alignment across both margins (`WD_ALIGN_PARAGRAPH.JUSTIFY` / căn đều 2 bên), standard narrative paragraphs indented by **0.5 cm** (`first_line_indent = 0.5 cm` / `~14.17 pt`).
2. **Table Formatting, Captions & Cell Content (Tiêu đề và nội dung bảng):** Placed directly **ABOVE** the table, following the convention: `Table 4.<Seq>: <Table_Title>`. Header row text must be centered (`alignment = WD_ALIGN_PARAGRAPH.CENTER`), bold, unindented. Body cell content must be justified across both margins (`alignment = WD_ALIGN_PARAGRAPH.JUSTIFY`), unindented (`first_line_indent = 0 cm` / không thụt lùi dòng).
3. **Figure / Diagram Formatting & Caption Numbering (Tiêu đề hình):** Placed directly **BELOW** the figure, centered, following the convention: `Figure 4.<Seq>: <Figure_Title>` (tiêu đề hình ở dưới, đánh số theo Chương.thứ tự hình trong chương).

## 17. Mandatory Two-Step Diagram Generation and Static Image Embedding Rule (Quy tắc bắt buộc xuất biểu đồ ra file .drawio trước, sau đó mới xuất ra file ảnh tĩnh)
All analysis diagram artifacts (BCE Diagrams, VOPC Diagrams, Analysis Sequence Diagrams, and State Machine Diagrams) MUST strictly follow a **mandatory two-step workflow**:
1. **Step 1 — Mandatory Master Source Export to `.drawio` (Bắt buộc xuất file nguồn `.drawio` trước tiên):** Every analysis diagram MUST be saved and exported as an editable XML master file with extension `.drawio` in the notation-specific directories: `artifacts/diagrams/class/` for BCE/VOPC class diagrams, `artifacts/diagrams/sequence/` for Analysis Sequence Diagrams, and `artifacts/diagrams/state-machine/` for State Machines. The `.drawio` format is the sole authoritative editable master format for all project diagrams. Generating an image without first establishing its corresponding `.drawio` master file is strictly prohibited.
2. **Step 2 — Static Image Export & Embedding (`.drawio` → `.png`) (Từ file `.drawio` mới xuất ra file ảnh tĩnh):**
   - **Anti-Drift Guarantee:** Only after the `.drawio` file is validated, the diagram is exported into a high-resolution `.png` image (in `artifacts/diagrams/images/` and/or alongside the `.drawio` file) and embedded into Chapter IV of the Master Specification Document (`Requirements_Analysis_Design_Specification.docx`).
   - Guarantees that the visual structure, lifelines, message flows, and class relationships shown in the deliverable strictly match the exact approved model verified at the Analysis Baseline Gate.
3. **Dual-Artifact Storage:** Editable `.drawio` files are maintained in the notation-specific directories above as editable master models; exported `.png` files in `artifacts/diagrams/images/` are embedded into the specification document.
4. **Mandatory Synchronization:** Any revision to an analysis diagram requires updating the source `.drawio` file first, re-exporting the static `.png` image, and updating Chapter IV of the Master Specification Document.

### 17.1 Diagram Layout, Connector Routing, and Notation Anti-Overlap Invariant (Quy tắc định tuyến đường kết nối và chống vẽ đè chồng lên các notation)
All analysis diagrams (BCE, VOPC, Analysis Sequence Diagrams, State Machines) MUST strictly enforce collision-free layout and connector routing:
1. **Zero Obstacle Crossing:** Message arrows, lifelines, association links, and state transitions MUST NEVER cut across or intersect unrelated BCE classes, note boxes, state nodes, or lifelines.
2. **Orthogonal Routing & Explicit Waypoints:** In VOPC and State Machine diagrams, use orthogonal routing (`edgeStyle=orthogonalEdgeStyle;`). Define explicit intermediate waypoints (`<Array as="points"><mxPoint x="..." y="..."/></Array>`) when navigating around shapes.
3. **Explicit Perimeter Port Anchoring:** Connectors MUST anchor to explicit perimeter ports (`exitX, exitY` and `entryX, entryY`) on node boundaries. Never default to node centers.
4. **Label Clearance & Background Protection:** Every text label (operation names, stereotyped messages, guard conditions, multiplicity) MUST have an opaque background (`labelBackgroundColor=#ffffff`). Multiplicity labels and message signatures MUST NOT collide with node borders or internal text.
5. **Layout Spacing & Channel Width:** Maintain a minimum channel spacing of **60–80px** horizontally and vertically between adjacent classes and states.
6. **Pre-Export Visual Anti-Overlap Inspection:** After exporting from `.drawio` to `.png`, visually inspect the rendered image to verify zero collision between lines, labels, and shapes. Fix any collision in `.drawio` before deliverable embedding.


