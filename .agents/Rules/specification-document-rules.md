# Specification Document Rules

## 1. Purpose
These rules govern the creation, formatting, synchronization, and baselining of formal engineering documentation across all lifecycle phases, with primary authority over the Master Specification Document (`Requirements_Analysis_Design_Specification.docx`) and any standalone SRS or design deliverables.

---

## 2. Source-of-Truth & Template Preservation
1. **Master Deliverable:** The project's authoritative specification document is `artifacts/Requirements_Analysis_Design_Specification.docx`, instantiated from `/templates/Template_Requirements_Analysis_Design_Specification.docx`.
2. **Template Preservation:** The Agent MUST preserve the template's structural integrity:
   - Document cover page, metadata, version history table, and approvals;
   - Chapter numbering and heading hierarchy (Chapters I, II, III, IV, V);
   - Pre-existing table schemas and column layouts;
   - Styles and margins.
3. **No Isolated Artifacts:** Individual or intermediate artifacts (drawio diagrams, markdown specs, CSV matrices) MUST NOT remain disconnected upon receiving stakeholder approval at a verification gate. They must be synthesized into the Master Specification Document.

---

## 3. Mandatory English Language Policy
All engineering content within the specification document MUST strictly be authored in **English**:
- Business Requirements, Business Rules, User Requirements, Functional Requirements, Non-Functional Requirements, Data Dictionary;
- Actor names, Use Case specifications, step actions, extensions;
- Analysis BCE catalogs, lifelines, messages, state names;
- Architecture descriptions, subsystem/component/package names, Design Class Diagrams (DCD), method signatures, parameters;
- Database table names, column definitions, constraints, data types, ERD entities and relationships.

Conversational discussions with stakeholders may occur in Vietnamese, but formal deliverables must strictly use English.

---

## 4. Typography, Formatting & Presentation Standards

All specification documents MUST strictly enforce the following typography standards:

### 4.1 Titles and Headings (Dòng tiêu đề - In đậm bắt buộc)
1. **Document Title & Cover Metadata:**
   - The main document title and project name MUST be formatted in **bold** (`run.font.bold = True`).
2. **Chapter & Section Headings (Heading 1, 2, 3, 4):**
   - ALL heading lines (Chapter Titles, Section Headings, Sub-headings) MUST be formatted in **bold** (`run.font.bold = True`).
   - Headings MUST NOT have first-line indent (`first_line_indent = 0 cm`).
   - Maintain hierarchical numbering (`1.`, `1.1`, `1.1.1`, etc.).

### 4.2 Narrative Body Text (Đoạn văn bản)
1. **Alignment:** Justified across both margins (`WD_ALIGN_PARAGRAPH.JUSTIFY` / căn đều 2 bên).
2. **First-Line Indentation:** The first line of every narrative paragraph MUST be indented inward by exactly **0.5 cm** (`first_line_indent = Inches(0.197)` / `~14.17 pt`).
3. **Exceptions:** Bullet lists, numbered lists, table cells, captions, and headings do NOT carry first-line indent (`first_line_indent = 0 cm`).

### 4.3 Table Formatting & Captions (Bảng biểu - Tiêu đề ở TRÊN, in đậm)
1. **Caption Placement:** All table captions MUST be positioned directly **ABOVE** the table.
2. **Caption Numbering & Style:** 
   - Numbered hierarchically: `Table <Chapter>.<Seq>: <Table_Title>` (e.g., *Table 1.1: Business Objectives*, *Table 3.2: Functional Requirements*).
   - Caption text MUST be **bold** (`run.font.bold = True` / in đậm) with proper spacing (`space_before = 6 pt`, `space_after = 3 pt`, `keep_with_next = True`).
3. **Table Header Row (Dòng tiêu đề bảng):**
   - All header cell texts MUST be **bold** (`run.font.bold = True`).
   - Horizontally centered (`WD_ALIGN_PARAGRAPH.CENTER` / căn giữa).
   - Unindented (`first_line_indent = 0 cm`).
4. **Table Data Cells (Nội dung các ô dữ liệu):**
   - Narrative text in data cells MUST be **justified across both margins** (`WD_ALIGN_PARAGRAPH.JUSTIFY`).
   - Short codes, IDs (e.g., `FR-01`, `BR-02`), dates, status flags, and numbers SHOULD be horizontally centered.
   - All cell text MUST NOT have first-line indent (`first_line_indent = 0 cm`).

### 4.4 Figure / Diagram Formatting & Captions (Hình ảnh - Tiêu đề ở DƯỚI, in đậm)
1. **Caption Placement:** All figure captions MUST be positioned directly **BELOW** the image.
2. **Caption Numbering & Style:**
   - Numbered hierarchically: `Figure <Chapter>.<Seq>: <Figure_Title>` (e.g., *Figure 2.1: System Context Diagram*, *Figure 3.1: Customer Use Case Diagram*).
   - Caption text MUST be **bold** (`run.font.bold = True` / in đậm) and horizontally centered (`WD_ALIGN_PARAGRAPH.CENTER`) with proper spacing (`space_before = 3 pt`, `space_after = 6 pt`).
3. **Image Alignment & Embedding:**
   - All diagram images MUST be horizontally centered.
   - Images MUST be scaled appropriately to fit within document printable margins without truncation or aspect ratio distortion.

---

## 5. Mandatory Two-Step Diagram Generation and Static Image Embedding Rule (Quy tắc bắt buộc xuất biểu đồ ra file .drawio trước, sau đó mới xuất ra file ảnh tĩnh)
1. **Step 1 — Mandatory Master Source Export to `.drawio` (Bắt buộc xuất file nguồn `.drawio` trước tiên):** Every diagram across all lifecycle phases MUST be constructed and exported as an editable XML master file with extension `.drawio` into its designated folder under `artifacts/diagrams/`. The `.drawio` format is the sole authoritative master format. Creating an image file without its corresponding `.drawio` master file is strictly prohibited.
2. **Step 2 — Static Image Export & Embedding (`.drawio` → `.png`) (Từ file `.drawio` mới xuất ra file ảnh tĩnh):**
   - **Anti-Drift Guarantee:** Only after the `.drawio` master file is validated, the diagram is rendered and exported to a high-resolution static `.png` image (in `artifacts/diagrams/images/` and/or alongside the `.drawio` file) before being embedded into the `.docx` specification document.
   - Eliminates layout shifting, detached connectors, font corruption, and rendering anomalies in Word/PDF viewers.
3. **Dual-Artifact Storage:**
   - Master editable files (`.drawio`) remain stored in `artifacts/diagrams/**/*.drawio`.
   - Rendered images are stored in `artifacts/diagrams/images/**/*.png`.
4. **Re-export on Revision:** Any approved change to a diagram requires updating the source `.drawio` file first, re-exporting the static `.png` image, and updating the embedded image in the Master Specification Document.

### 5.1 Diagram Layout, Connector Routing, and Notation Anti-Overlap Invariant (Quy tắc định tuyến đường kết nối và chống vẽ đè chồng lên các notation)
All embedded diagrams MUST be verified for zero connector collisions and notation overlaps prior to document embedding:
1. **Zero Obstacle Crossing:** Connectors must never cut across or intersect unrelated shapes, class boxes, swimlanes, actor icons, or notes.
2. **Orthogonal Routing & Explicit Waypoints:** Use orthogonal routing (`edgeStyle=orthogonalEdgeStyle;`) with explicit intermediate waypoints (`<Array as="points"><mxPoint x="..." y="..."/></Array>`) navigating cleanly around intervening shapes.
3. **Explicit Perimeter Port Anchoring:** Connectors MUST anchor to explicit perimeter ports (`exitX, exitY` and `entryX, entryY`) on node boundaries. Never default to node centers.
4. **Label Clearance & Background Protection:** Every text label (verbs, stereotypes, multiplicity) MUST have an opaque background (`labelBackgroundColor=#ffffff`). Multiplicity labels and relation names MUST NOT collide with node borders or internal text.
5. **Layout Spacing & Channel Width:** Maintain a minimum channel spacing of **60–80px** horizontally and vertically between adjacent shapes.
6. **Pre-Embedding Visual Inspection:** Visually inspect every exported `.png` image to ensure crispness, readability, and zero collision before inserting into the `.docx` document.

---

## 6. Lifecycle Gate Synchronization Invariant
1. **Prerequisite for Progression:** Transitioning to the next lifecycle phase is strictly blocked until the Master Specification Document is synchronized with all approved artifacts of the completed phase:
   - **Post-Requirements Gate:** Chapters I, II, and III fully populated.
   - **Post-Analysis Gate:** Chapter IV fully populated.
   - **Post-Design Gate:** Chapter V fully populated.
2. **Version & Change History:** Each synchronization must record a new version entry in the Document Change History table (`Table 0`) specifying version, date, author, and description of changes.

---

## 7. Authoritative Form and Table Schemas Reference (Mẫu biểu chuẩn từ file ví dụ)
All structured table forms and specification templates MUST be read from and strictly conform to the approved reference document:
`examples/SWD392Example_RDS Document-VersionVietNhat.docx`

The Agent MUST inspect and mirror the exact layout and field definitions from this file:

### 7.1 Record of Changes Form (`Table 0`)
- **Columns (5):** `Version` | `Date` | `A* M, D` (Action: Add, Modify, Delete) | `In charge` | `Change Description`

### 7.2 Business Rules Form (`Table 1`)
- **Columns (3):** `Business Rule ID` | `Description` | `Reference Source (if applicable)`

### 7.3 Structured Use Case Description Form (`Tables 2–7`)
The Use Case Description table MUST strictly follow the 12-row schema from the reference example:
- **Row 0:** `ID and Name:` (e.g., `UC-01 Manage products`)
- **Row 1:** `Created By:` | `[Author]` | `Date Created:` | `[Date]`
- **Row 2:** `Primary Actor:` | `[Actor Name]` | `Secondary Actors:` | `[Actors / Services]`
- **Row 3:** `Description:` | `[High-level summary of use case]`
- **Row 4:** `Trigger:` | `[Event triggering the use case]`
- **Row 5:** `Preconditions:` | `[Numbered list: PRE-1, PRE-2...]`
- **Row 6:** `Postconditions:` | `[Numbered list: POST-1, POST-2...]`
- **Row 7:** `Normal Flow:` | `[Step-by-step numbered interaction steps between Actor and System]`
- **Row 8:** `Alternative Flows:` | `[Branching flows with reference step IDs, e.g., A4.1, A4.2]`
- **Row 9:** `Exceptions:` | `[Failure conditions with reference step IDs, e.g., E3.1]`
- **Row 10:** `Priority:` | `[High / Medium / Low]`
- **Row 11:** `Business Rules:` | `[Referenced BR IDs, e.g., BR-01, BR-02]`

### 7.4 Data Requirements / Data Dictionary Form (`Table 8`)
- **Columns (4):** `Name` | `Data Type` | `Length` | `Description`
- **Entity Category Rows:** For each entity/table (e.g., `Category`, `Product`, `Supplier`, `Order`), insert a full-width header row with the Entity Name in Column 0, followed by attribute rows with `Name`, `Data Type`, `Length`, and `Description`.

### 7.5 High-Level Architecture & Subsystem Mapping
- Mapping of Architecture styles, Subsystems, Component and Package Diagrams, and Code Mappings must follow the structure outlined in Chapters 3 and 4 of `SWD392Example_RDS Document-VersionVietNhat.docx`.

