# Database Design Rules

## 1. Purpose
These rules govern conceptual, logical, and physical database design.

## 2. Sources
Database design MUST derive from:
- Data Requirements
- Business Rules
- Functional Requirements
- Use Cases
- Analysis entities
- Reporting/audit needs
- Integration requirements
- Legal/privacy/retention obligations

## 3. No Unsupported Data
Do not introduce business entities, attributes, or relationships without an approved source or documented technical rationale.

## 4. Conceptual and Logical Design
Identify:
- entities;
- attributes;
- identifiers;
- relationships;
- cardinalities;
- optionality;
- business integrity constraints.

## 5. Physical Design
Physical schema decisions MAY introduce technical fields such as surrogate keys, timestamps, concurrency fields, indexes, and audit metadata when justified.

Technical fields MUST be distinguishable from business data.

## 6. Normalization and Denormalization
Normalize data appropriately to reduce anomalies. Denormalization MUST have a documented reason such as performance/reporting needs and MUST preserve correctness.

## 7. Referential Integrity
Foreign keys and relationship constraints SHOULD enforce approved domain relationships unless a justified architecture constraint requires another approach.

## 8. Business Rules
Database constraints MAY enforce Business Rules when appropriate, but enforcement location MUST be consistent with architecture and application rules.

## 9. Security and Privacy
Apply least privilege, sensitive-data protection, retention, audit, and privacy requirements where applicable.

Never place credentials/secrets in schema scripts or repository files.

## 10. Traceability
Maintain traceability:
Requirement / Business Rule → Data Entity/Attribute/Constraint → Database Element.

## 11. Review Gate
Before database baseline:
- check consistency with requirements and analysis/design;
- review integrity and deletion/update behavior;
- review security/privacy;
- review migration implications;
- obtain approval from responsible design/database roles.

## 12. Master Specification Document Integration Rule (Post-Approval)
- Upon obtaining approval at the Database Design Gate:
  1. The Agent MUST immediately incorporate and synchronize all approved database design artifacts into the **Database Design section of Chapter V** in the official Master Specification Document (`artifacts/Requirements_Analysis_Design_Specification.docx`).
  2. This includes:
     - Conceptual and Logical Data Models / ERDs (embedded visual diagram figures);
     - Physical database schema tables with column names, data types, nullability, primary/foreign keys, default values, and integrity constraints;
     - Data dictionary, indexing strategy, and denormalization rationales.
  3. No database design is considered baselined until it is incorporated into the Master Specification Document.

## 13. Mandatory English Language Policy
All database design artifacts MUST be written in English:
- **Conceptual & Logical Data Models (ERDs):** Entity names, attribute names, relationships, cardinality annotations, and constraint notes MUST be in English.
- **Physical Schemas & DDL:** Table names, column names, primary/foreign key constraint names, indexes, triggers, stored procedures, and migration scripts MUST use standard English naming conventions (e.g., snake_case or PascalCase as approved by project technical stack).
- **Data Dictionaries & Mapping Catalogs:** Descriptions, data types, validation rules, and notes MUST be specified in English.
- *Note:* Interactions and discussions with stakeholders may occur in Vietnamese, but the formal database specification and schema artifacts MUST remain strictly in English.

## 14. Mandatory Two-Step Diagram Generation and Static Image Embedding Rule for ERDs (Quy tắc bắt buộc xuất ERD ra file .drawio trước, sau đó mới xuất ra file ảnh tĩnh)
All database ERD models (Conceptual Data Model, Logical Data Model, Physical ERD) MUST strictly follow a **mandatory two-step workflow**:
1. **Step 1 — Mandatory Master Source Export to `.drawio` (Bắt buộc xuất file nguồn `.drawio` trước tiên):** Every database ERD model MUST be constructed and exported as an editable XML master file with extension `.drawio` in `artifacts/diagrams/database/`. The `.drawio` format is the sole authoritative master format. Creating an image file without its corresponding `.drawio` source is strictly prohibited.
2. **Step 2 — Static Image Export & Embedding (`.drawio` → `.png`) (Từ file `.drawio` mới xuất ra file ảnh tĩnh):**
   - **Anti-Drift Guarantee:** Only after the `.drawio` ERD file is validated, the diagram is exported into a high-resolution static `.png` image (in `artifacts/diagrams/images/` and/or alongside the `.drawio` file) and embedded into the Database Design section of Chapter V in the Master Specification Document (`Requirements_Analysis_Design_Specification.docx`).
   - Preserves the exact entity boxes, attribute lists, primary/foreign key markings, and cardinality crow's-foot relationships approved at the Database Design Gate, preventing distortion in document renderers.
3. **Dual-Artifact Storage:** Editable diagram source files (`.drawio`) are preserved in `artifacts/diagrams/database/`; exported high-resolution `.png` images in `artifacts/diagrams/images/` are embedded into the specification document.
4. **Mandatory Synchronization:** Any change to database entities or schemas requires updating the source `.drawio` file first, re-exporting the static `.png` image, and synchronizing Chapter V of the Master Specification Document.

### 14.1 Diagram Layout, Connector Routing, and Notation Anti-Overlap Invariant (Quy tắc định tuyến đường kết nối và chống vẽ đè chồng lên các notation)
All database models (Conceptual, Logical, Physical ERDs) MUST strictly enforce collision-free layout and connector routing:
1. **Zero Obstacle Crossing:** Relationship lines (crow's foot connectors, foreign key references) MUST NEVER cut across or intersect unrelated tables, entity boxes, or note boxes.
2. **Orthogonal Routing & Explicit Waypoints:** Use orthogonal routing (`edgeStyle=orthogonalEdgeStyle;`). Define explicit intermediate waypoints (`<Array as="points"><mxPoint x="..." y="..."/></Array>`) navigating cleanly around intervening entity tables.
3. **Explicit Perimeter Port Anchoring:** Connectors MUST anchor to explicit perimeter ports (`exitX, exitY` and `entryX, entryY`) on table boundaries. Never default to entity centers.
4. **Label Clearance & Background Protection:** Relationship verbs and cardinality labels (`1:N`, `1:1`, `M:N`, crow's foot notations) MUST have an opaque background (`labelBackgroundColor=#ffffff`) and not collide with table borders or column text.
5. **Layout Spacing & Channel Width:** Maintain a minimum channel spacing of **60–80px** horizontally and vertically between adjacent entity tables.
6. **Pre-Export Visual Anti-Overlap Inspection:** After exporting from `.drawio` to `.png`, visually inspect the rendered image to verify zero collision between relationship lines, crow's foot symbols, and table attributes. Fix any collision in `.drawio` before deliverable embedding.


