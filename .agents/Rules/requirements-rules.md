# Requirements Engineering Rules

## 1. Purpose
These rules govern requirements engineering activities from business context through requirements baseline.

## 2. Source-of-Truth Priority in Requirements
1. Approved business requirements, charter, and baselined artifacts.
2. Authorized stakeholder decisions.
3. Project-approved templates and checklists.
4. Business Rules and validated domain knowledge.
5. General reference books (e.g., Karl Wiegers & Joy Beatty, Software Requirements 3rd Edition).
6. Generic AI knowledge.

A lower-priority source MUST NOT override an approved business source or requirement baseline.

## 3. Separation of Requirement Types
Maintain strict conceptual and structural separation:
- **Business Requirements (Why):** Background, business problems/opportunities, business objectives, success metrics, vision, scope, and business risks.
- **Business Rules (Organizational Policies):** Policies, computations, constraints, and business logic that exist independently of software automation.
- **User Requirements (What users need):** User classes, user tasks, user goals, and user stories.
- **Software Requirements (What the system shall provide):**
  - **Functional Requirements (FR):** Verifiable statements of what the software must execute or support.
  - **Quality Attributes / Non-Functional Requirements (NFR):** Measurable quality characteristics (Performance, Security, Usability, Reliability, Maintainability, Availability).
  - **Constraints:** Technical, organizational, regulatory, or business limits placed on the solution.
  - **External Interfaces:** UI, Hardware, Software, Communication, and API interfaces.
  - **Data Requirements:** Logical data structures, data dictionary, retention, volume, and integrity rules.

## 4. Process-Driven Requirements Discovery
When the software automates or supports organizational workflows:
1. Explore and model the **AS-IS** business process first.
2. Identify pain points, bottlenecks, compliance issues, and opportunities.
3. Design and model the **TO-BE** business process using standard BPMN notation (`.drawio`).
4. Derive User Requirements and Functional Requirements directly from TO-BE process steps and actor responsibilities.

## 5. Do Not Invent Requirements
The Agent MUST NOT introduce requirements, business rules, or data attributes without a traceable basis:
- **Source-confirmed:** Clearly grounded in stakeholder input or project documentation.
- **Logically derived:** Directly and logically inferred from confirmed business processes or rules.
- **Proposed:** Tagged explicitly as `Proposed – Project approval required.`
- **Missing / Unknown:** Tagged explicitly as `TBD – Stakeholder confirmation required.`

A proposal MUST NOT silently become an approved requirement.

## 6. Identifier Stability and Conventions
Requirements MUST have unique, persistent, and traceable identifiers:
- `BO-xx`: Business Objective
- `BR-xx`: Business Rule
- `UC-xx`: Use Case
- `UR-xx`: User Requirement
- `FR-xx`: Functional Requirement
- `NFR-xx`: Non-Functional Requirement (or `QA-xx`)
- `CON-xx`: Constraint
- `EI-xx`: External Interface
- `DR-xx`: Data Requirement

Never renumber baselined requirements. If a requirement is deprecated, mark it `Deprecated / Withdrawn` with approved rationale.

## 7. Prototyping Rules
- Prototypes (UI wireframes, mockups, screen flows) SHOULD be used to clarify ambiguous, risky, or complex user interactions.
- A prototype is a visual clarification mechanism, NOT a license to invent new unapproved requirements.
- Any new requirement discovered through a prototype must be explicitly specified in the Requirements specification, verified against checklists, and approved before baseline.

## 8. Template and Presentation Rules
- Requirements MUST be documented within the project-approved master specification template: `/templates/Template_Requirements_Analysis_Design_Specification.docx`.
- Preserve existing sections, headings, tables, and conventions. Do not create parallel, unapproved SRS documents.
- RTM sheet in `/templates/Requirements_Traceability_Matrix_Simplified.xlsx` must be updated with all approved requirement IDs.

### 8.1 Use Case Diagram Modeling and Directed Association Rules (Karl Wiegers Convention)
In accordance with Karl Wiegers & Joy Beatty (*Software Requirements*, 3rd Edition), Use Case diagrams MUST follow these association rules:
1. **Actor-to-Use Case Associations:**
   - Associations between actors and use cases MUST be solid lines (never dashed).
   - **Primary Actor &rarr; Use Case:** Solid line with an arrowhead pointing from the Primary Actor to the Use Case (`Primary Actor` &rarr; `Use Case`). This represents the primary actor initiating the interaction.
   - **Use Case &rarr; Support / Secondary Actor:** Solid line with an arrowhead pointing from the Use Case to the Support Actor (`Use Case` &rarr; `Support Actor`). This represents the system/use case sending requests, data, or invoking external services (e.g., Auth Provider, SMS Gateway, Payment Gateway).
2. **Use Case Relationships:**
   - `<<extend>>`: Dashed line with an open arrowhead pointing from the **Extension Use Case** to the **Base Use Case** (`Extension UC` &dash;&dash;&gt; `Base UC`).
   - `<<include>>`: Dashed line with an open arrowhead pointing from the **Base Use Case** to the **Included Use Case** (`Base UC` &dash;&dash;&gt; `Included UC`).
3. **Actor Generalization:**
   - Solid line with a hollow triangle arrowhead (`endArrow=block;endFill=0;`) pointing from the specialized actor to the generalized actor.

### 8.2 Use Case Relationship Semantics and Decomposition Rules
Relationships MUST be chosen by meaning, not by visual convenience:
1. **`<<include>>` (mandatory):** the Base UC cannot complete its goal without executing the Included UC. Use it only when (a) a large UC is split into mandatory sub-steps of its main flow, or (b) two or more UCs share a common behavior that is factored out. Never use it for optional or conditional behavior.
2. **`<<extend>>` (optional / conditional):** the Base UC completes its goal with or without the Extension UC; the extension runs at the user's choice or when a stated condition holds. Every `<<extend>>` SHOULD carry its condition label, e.g. `[First-time login]`.
3. **Generalization (between UCs):** two or more UCs with the same goal but different specialized behavior are abstracted into a General (parent) UC; children point to the parent with a solid line and hollow triangle.
4. **Management / CRUD decomposition pattern:** a general "Manage X" UC is decomposed in the actor diagram as follows:
   - `Manage X` `<<include>>` `View X List` (the management UC always loads a list first);
   - `Add X`, `Update X`, `Delete X` (and other optional business actions) `<<extend>>` `Manage X`.
   Never model `Manage X` `<<include>>` Add / Update / Delete.
5. **Decomposed diagrams per actor:**
   - Show only that actor and its own UCs; no other actors and no other actors' UCs.
   - Every general UC of that actor on the General diagram MUST appear (decomposed), none may be dropped.
   - Exception: UCs common to all actors (e.g. authentication) are drawn once in the dedicated common-functions diagram and are not repeated in each actor diagram.
   - An actor that generalizes other actors inherits their UCs by actor generalization; do not redraw inherited UCs.
6. **Use Case Granularity — Do Not Decompose into Micro-Actions (Không phân rã thành hành động vi mô):**
   - Do NOT model individual UI steps, input field entries, dropdown selections, or internal calculation steps as separate Use Cases (e.g. `Select Product Category`, `Select Supplier`, `Enter Batch Details`, `Calculate Total`, `Validate Input`, `Click Save`).
   - These are internal interactions / steps within the flow of events of a Use Case, to be documented inside **Use Case Descriptions** and **UML Activity Diagrams**, NOT as separate ellipses in Use Case diagrams.
   - Every Use Case MUST represent a complete, elementary business task delivering a discrete result of value to the actor (Karl Wiegers / Alistair Cockburn goal level).
7. **System Boundary & Diagram Layout Policy (Quy chuẩn System Boundary duy nhất & Bố cục A4):**
   - **Single System Boundary Rule:** In Use Case diagrams, all Use Cases MUST be contained within **ONE single System Boundary rectangle** (Khung ranh giới hệ thống duy nhất). The boundary MUST be a standard sharp-cornered rectangle (`rounded=0`), **NEVER rounded/curved corners** (không bo tròn hay bo cung ở góc).
   - **Actor Placement:** Actors MUST be placed **OUTSIDE** the system boundary (Primary Actor on the LEFT, Support / Secondary Actors on the RIGHT if any). **NEVER place an actor in the middle** between scattered packages or use cases.
   - **No Disjoint Package Scattering:** Do NOT divide use cases into multiple isolated package boxes scattered around the actor. If functional grouping is needed, use subtle internal grouping or aligned columns/swimlanes INSIDE the single system boundary.
   - **A4 Document Readability:** Structure the single system boundary and its internal use cases cleanly (e.g. columns of base use cases and their decomposed children) with font sizes at **10pt - 11.5pt Bold** minimum, ensuring crisp legibility without blurriness when embedded into A4 documents.

### 8.3 Use Case Identifier Consistency and Pre-Diagram Verification
1. Maintain a **Use Case List** (`artifacts/diagrams/use-case/use-case-list.md`) BEFORE drawing or redrawing any use case diagram. For each UC record: ID, name, actor(s), relationship and parent, source (paragraph / UR / FR / BR), and status (`Source-confirmed`, `Derived`, `Proposed`, `TBD`).
2. IDs MUST be identical in every artifact (list, General diagram, decomposed diagrams, common diagram, descriptions, RTM). General UCs use `UC-<group><nn>` (e.g. `UC-C01`, `UC-M05`); decomposed UCs use `UC-<general>.<n>` (e.g. `UC-M06.2`). Every UC in every diagram carries an ID; one ID never denotes two different UCs.
3. Before drawing, verify and report: (a) every source requirement maps to at least one UC; (b) every UC has a source or is flagged Derived / Proposed / TBD; (c) every General-diagram UC appears in a decomposed diagram or the common diagram; (d) names and IDs are identical across diagrams; (e) no stale or conflicting diagram files remain.
4. Obtain approval of the Use Case List (Human Verification Gate) before drawing diagrams.

### 8.4 Use Case Description Packaging & Granularity Rule (Quy tắc cấu trúc và gom cụm Use Case Description)
1. **Separate Use Case Descriptions for Distinct UCs (Mô tả Use Case độc lập riêng biệt):**
   Mỗi Use Case có mục tiêu nghiệp vụ khác nhau (different elementary business goals) bắt buộc phải được mô tả trong một bản đặc tả Use Case Description riêng biệt (với cấu trúc chuẩn gồm ID & Name, Primary/Secondary Actors, Preconditions, Postconditions, Normal Flow, Alternative Flows, Exception Flows, Business Rules).
2. **Exception 1 — Extended Use Cases inside Alternative Flows (Use Case có quan hệ `<<extend>>` mô tả trong Alternative Flows):**
   Trường hợp Use Case cơ sở/tổng quát (Base UC) có các Use Case mở rộng (`<<extend>>`), các hành vi mở rộng này có thể được mô tả lồng trực tiếp trong phần **Alternative Flows** (hoặc Extension Points) của bản đặc tả Use Case cơ sở, ghi rõ điều kiện kích hoạt rẽ nhánh (condition guard) và các bước xử lý mà không nhất thiết phải tách thành một bản đặc tả độc lập riêng biệt.
3. **Exception 2 — Included Use Cases inside Main Flow (Use Case có quan hệ `<<include>>` mô tả trong Normal Flow):**
   Trường hợp Use Case có quan hệ `<<include>>` là một bước bắt buộc nằm trong luồng chính của Use Case cơ sở, hành vi của Use Case được bao gồm có thể được mô tả chung trực tiếp như một bước nghiệp vụ cụ thể trong **Normal Flow (Basic Flow)** của Use Case cơ sở mà không cần tách rời thành một bản đặc tả riêng biệt, giúp tài liệu tập trung và không bị phân mảnh.

### 8.5 System Context Diagram Notation and Layout
For this project's DFD-style System Context Diagrams:
- Represent the entire software system as exactly one circular process, numbered `0` and labeled with the system name. In draw.io, use `ellipse;aspect=fixed;` with equal width and height.
- Keep the system circle compact at the visual center. Size it only large enough for the process number and a readable system name; do not enlarge it to match the full height or width of the external-entity arrangement.
- Distribute external entities around the top, bottom, left and right of the system, with balanced spacing and visual weight. Avoid placing all entities in only two side columns when a surrounding layout is feasible. Adapt the number per side to entity count and flow clearance; do not hard-code a specific count or pixel size.
- Represent external entities as sharp-cornered rectangles outside the circle, using comparable sizes and consistent text styling.
- Show named, directed data flows between external entities and the system; retain separate arrows when input and output data differ. Do not show internal subsystems or data stores at this context level.
- Preserve confirmed entity names, flow meanings, directions and stable IDs when changing layout. Apply Section 13.1: orthogonal routing, explicit perimeter anchors and waypoints where needed, opaque label backgrounds, and 60-80px minimum shape clearance. Separate opposite-direction flows into distinct lanes; keep labels clear of other labels, shapes, bends and unrelated connectors.
- Save and validate the editable `.drawio` master before exporting its PNG. Visually inspect the actual exported PNG for a compact central circle, balanced surrounding entities, legible labels and unobstructed routes. Correct defects in the master and re-export before review; synchronize the approved image into the Master Specification under the existing approval rules.
This convention applies to DFD context diagrams; other architecture views retain their own notation.

## 9. Verification Checklist
Every requirements increment MUST be statically verified against:
- `/checklists/d2_Checklist_SRS Review.xls`
- `/checklists/d1_Checklist_GUI Review.xls` (for prototypes and UI requirements)
- Traceability checks against business objectives and rules.

Report all defects, ambiguities, conflicting requirements, and TBD items.

## 10. Human Verification Gate & Baseline
- Requirements MUST NOT proceed to Analysis or Detailed Design without explicit approval from the Business Analyst, Product Owner, and authorized approvers.
- **Master Specification Document Integration Rule (Post-Approval):** Upon explicit approval at the Requirements Baseline Gate, the Agent MUST immediately incorporate and synchronize all approved requirements artifacts (Business Context, Business Rules, BPMN processes, User Classes, User Requirements, System Context Diagram, FR/NFR specifications, Data Dictionary, and Use Case specifications) into Chapters I, II, and III of the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).
- For all visual models (System Context Diagram, BPMN Diagrams, Use Case Diagrams, Activity Diagrams), high-resolution rendered figures MUST be embedded directly into their designated sections alongside structured narrative and tabular specifications.
- Progression to Phase 06 (Analysis Modeling) is strictly blocked until the Master Specification Document is fully updated, formatted, and verified.
- Once approved and integrated, the document forms the official **Requirements Baseline**.
- Any downstream change to requirements must trigger Change Impact Analysis and formal re-baselining.

## 11. Mandatory English Language Policy
- All requirements engineering artifacts (Business Requirements, Objectives, Business Rules, User Classes, User Requirements, Functional Requirements, Quality Attributes, Constraints, External Interfaces, Data Dictionaries, Use Case descriptions, and BPMN/Activity diagrams) MUST be written in **English**.
- If source materials, user interviews, or stakeholder inputs are provided in Vietnamese or another language, the Agent MUST accurately translate, synthesize, and formalize them into professional, unambiguous technical English.
- Identifiers, actor names, use case names, and diagram labels MUST strictly use English terminology.

## 12. Document Presentation and Formatting Conventions (Quy tắc trình bày và định dạng tài liệu đặc tả yêu cầu)
In all requirements specification deliverables (including Master Specification Document Chapters I, II, III and standalone SRS documents):
1. **Body Text Paragraphs (Đoạn văn bản):**
   - Must be justified across both margins (`WD_ALIGN_PARAGRAPH.JUSTIFY` / căn đều 2 bên).
   - Standard narrative paragraphs must have a first-line indent of **0.5 cm** (`first_line_indent = 0.5 cm` / `~14.17 pt` / `Inches(0.197)`). (Headings, bullet lists, captions remain unindented).
2. **Table Formatting, Captions & Cell Content (Tiêu đề và nội dung bảng biểu):**
   - Table captions MUST be placed directly **ABOVE** the table (tiêu đề bảng ở trên).
   - Numbering convention: `Table <Chapter>.<Table_Number_In_Chapter>: <Table_Title>` (e.g., *Table 1.1: Business Objectives*, *Table 2.1: AS-IS Process Assessment*, *Table 3.4: Functional Requirements Specifications*).
   - **Header Row:** Centered alignment (`alignment = WD_ALIGN_PARAGRAPH.CENTER` / căn giữa), bold, `first_line_indent = 0 cm`.
   - **Body Cell Content:** Justified alignment across both margins (`alignment = WD_ALIGN_PARAGRAPH.JUSTIFY` / căn đều 2 bên), unindented (`first_line_indent = 0 cm` / không thụt lùi dòng).
3. **Figure / Diagram Formatting & Caption Numbering (Tiêu đề hình):**
   - Figure/diagram captions MUST be placed directly **BELOW** the figure (tiêu đề hình ở dưới).
   - Numbering convention: `Figure <Chapter>.<Figure_Number_In_Chapter>: <Figure_Title>` (e.g., *Figure 2.1: System Context Diagram*, *Figure 2.2: Goods Receipt Activity Diagram*, *Figure 3.1: General Use Case Diagram*).
   - Figures and their captions must be centered horizontally.

## 13. Mandatory Two-Step Diagram Generation and Static Image Embedding Rule (Quy tắc bắt buộc xuất biểu đồ ra file .drawio trước, sau đó mới xuất ra file ảnh tĩnh)
All requirements diagram artifacts (System Context Diagrams, BPMN process models, Use Case Diagrams, Activity Diagrams, and Entity Class Diagrams) MUST strictly follow a **mandatory two-step workflow**:
1. **Step 1 — Mandatory Master Source Export to `.drawio` (Bắt buộc xuất file nguồn `.drawio` trước tiên):** Every requirements diagram MUST be constructed and exported as an editable XML master file with extension `.drawio` in `artifacts/diagrams/` (e.g. `business-process/`, `use-case/`, `activity/`, `class/`, `context/`). The `.drawio` format is the sole authoritative master format for all project diagrams. Creating an image without its corresponding `.drawio` source is strictly prohibited.
2. **Step 2 — Static Image Export & Embedding (`.drawio` → `.png`) (Từ file `.drawio` mới xuất ra file ảnh tĩnh):**
   - **Anti-Drift Guarantee:** Only after the `.drawio` file is validated, the diagram is exported into a high-resolution `.png` image (in `artifacts/diagrams/images/` and/or alongside the `.drawio` file) and embedded into the specification documents (`Requirements_Analysis_Design_Specification.docx`, standalone SRS).
   - Guarantees visual fidelity matching the approved baseline without connector breakage, symbol displacement, or rendering drift.
3. **Dual-Artifact Storage:** The source editable file (`.drawio`) is version-controlled in `artifacts/diagrams/` as the editable baseline, while the high-resolution `.png` file in `artifacts/diagrams/images/` is embedded in the document.
4. **Mandatory Synchronization:** Whenever an approved diagram is revised through an authorized Change Request, the `.drawio` source file must be updated first, the static `.png` image re-exported immediately, and synchronized into the specification document.

### 13.1 Diagram Layout, Connector Routing, and Notation Anti-Overlap Invariant (Quy tắc định tuyến đường kết nối và chống vẽ đè chồng lên các notation)
All requirements diagrams (System Context, BPMN, Use Case Diagrams, Activity Diagrams, Entity Class Diagrams) MUST strictly enforce collision-free layout and connector routing:
1. **Zero Obstacle Crossing:** Connectors (associations, generalizations, dependencies, data flows) MUST NEVER cut across, intersect, or pass underneath any unrelated shapes, entity/class boxes, swimlanes, actor icons, boundary frames, or note boxes. Connectors must traverse exclusively through empty canvas space (dedicated routing corridors).
2. **Orthogonal Routing & Explicit Waypoints:** Connectors must use orthogonal routing (`edgeStyle=orthogonalEdgeStyle;`). When connecting nodes separated by intervening shapes, define explicit intermediate routing waypoints (`<Array as="points"><mxPoint x="..." y="..."/></Array>`) navigating cleanly around intervening shapes.
3. **Explicit Perimeter Port Anchoring:** Connectors MUST anchor to explicit perimeter ports (`exitX, exitY` and `entryX, entryY`) on node boundaries (North: `0.5, 0`, South: `0.5, 1`, East: `1, 0.5`, West: `0, 0.5`). Never default to node centers.
4. **Label Clearance & Background Protection:** Every text label (association verbs, stereotypes, conditions) and multiplicity indicator (`1`, `0..*`, `1..*`) MUST have an opaque background (`labelBackgroundColor=#ffffff`). Multiplicity labels MUST NOT collide with node borders or internal text. Position them with clear outward clearance from the shape boundary. Association verb labels must be positioned in dedicated whitespace along straight connector segments.
5. **Layout Spacing & Channel Width:** Maintain a minimum channel spacing of **60–80px** horizontally and vertically between adjacent shapes.
6. **Pre-Export Visual Anti-Overlap Inspection:** After exporting from `.drawio` to `.png`, visually inspect the rendered image to verify zero collision between lines, labels, and shapes. Any detected collision must be fixed in `.drawio` before deliverable embedding.

## 14. Requirements Prioritization Model (Mô hình tính toán Độ ưu tiên Karl Wiegers)
To eliminate subjective guesswork, establish objective criteria for Product Backlog management, and determine which functional requirements enter the immediate Sprint, the Agent MUST apply the **Karl Wiegers Quantitative Requirements Prioritization Model** (*Software Requirements*, 3rd Edition):

### 14.1 Valuation and Assessment Parameters (Thang điểm đánh giá 1–9)
For each candidate Functional Requirement (FR) or Product Backlog item, stakeholders and technical leads assign integer scores from `1` (lowest) to `9` (highest) across four dimensions:
1. **Relative Benefit ($\text{Benefit} \in [1..9]$):** The value or advantage gained by the customer, end-user, or business if the requirement is successfully implemented.
   - `1–3`: Minor convenience / cosmetic enhancement.
   - `4–6`: Significant operational improvement or productivity gain.
   - `7–9`: Mission-critical core capability, primary revenue driver, or strategic differentiator.
2. **Relative Penalty ($\text{Penalty} \in [1..9]$):** The adverse consequence, business damage, legal penalty, or customer churn suffered if the requirement is NOT implemented.
   - `1–3`: Low impact, users can easily work around without major dissatisfaction.
   - `4–6`: Noticeable customer dissatisfaction, operational inefficiencies, or manual overhead.
   - `7–9`: Severe legal violation, regulatory non-compliance, heavy financial penalty, or critical business breakdown.
3. **Relative Cost ($\text{Cost} \in [1..9]$):** Estimated technical effort, architectural complexity, database schema changes, and developer person-hours required to deliver the feature (evaluated primarily by Developers/Software Architects).
   - `1–3`: Simple modification, routine CRUD, or minor UI adjustment.
   - `4–6`: Moderate complexity, multi-component interaction, or business rule calculation.
   - `7–9`: High complexity, architectural overhaul, or extensive transaction/concurrency control.
4. **Relative Risk ($\text{Risk} \in [1..9]$):** The degree of technical uncertainty, algorithmic difficulty, unproven third-party dependency, or integration instability.
   - `1–3`: Well-understood technology, standard library, or routine pattern.
   - `4–6`: Moderate integration uncertainty or new external API dependencies.
   - `7–9`: High technical volatility, third-party service unreliability, or stringent real-time concurrency demands.

### 14.2 Mathematical Formulas (Công thức tính toán)
The prioritization scores are calculated using the following mathematical formulation:

1. **Total Value (Tổng giá trị nghiệp vụ):**
   $$\text{Total value} = 2 \times \text{benefit} + \text{penalty}$$
   *(Note: Benefit carries a relative weight of 2, reflecting customer satisfaction priority, while Penalty carries a relative weight of 1).*

2. **Percentage Normalization (Chuẩn hóa phần trăm theo danh mục Backlog):**
   For requirement $i$ among $N$ backlog items:
   $$\text{value } \%_i = \left( \frac{\text{Total value}_i}{\sum_{k=1}^N \text{Total value}_k} \right) \times 100\%$$
   $$\text{cost } \%_i = \left( \frac{\text{Cost}_i}{\sum_{k=1}^N \text{Cost}_k} \right) \times 100\%$$
   $$\text{risk } \%_i = \left( \frac{\text{Risk}_i}{\sum_{k=1}^N \text{Risk}_k} \right) \times 100\%$$

3. **Priority Score (Điểm chỉ số ưu tiên):**
   $$\text{Priority}_i = \frac{\text{value } \%_i}{\text{cost } \%_i + \text{risk } \%_i}$$

### 14.3 Backlog Triage & Sprint Selection Principle (Đưa vào Backlog & Chọn vào Sprint)
1. **Backlog Ranking:** All requirements in the Product Backlog MUST be calculated using these formulas and sorted in descending order of their calculated `Priority` score.
2. **Sprint Planning Selection:** Requirements with the highest `Priority` scores deliver the highest business value relative to their cost and risk. These items MUST be prioritized for pull into the immediate upcoming Sprint (Sprint Backlog).
3. **High-Value / High-Cost Tradeoff:** Requirements with high value but equally high cost/risk are evaluated for architectural decomposition into smaller, lower-cost increments before entering the Sprint.
4. **Low Priority Retention:** Requirements with low `Priority` scores remain in the Product Backlog for future evaluation or scope reconsideration.


