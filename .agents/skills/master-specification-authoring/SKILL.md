---
name: master-specification-authoring
description: "Integrate approved lifecycle artifacts into the Master Specification Document while preserving its template, formatting, and synchronization rules."
---

> **Version:** 1.0 — Dedicated Specification Authoring & Synchronization Skill  
> **Governance:** `/AGENTS.md`, `.agents/Rules/specification-document-rules.md`, and applicable phase rules.  
> **Mandatory template rule:** Always use `/templates/Template_Requirements_Analysis_Design_Specification.docx` as the authoritative structural baseline. Maintain all chapter numbering, styles, metadata tables, and headers.  
> **Gate rule:** Synchronization and formatting of the Master Specification Document is executed upon receiving explicit Human Verification Gate approval at the end of each lifecycle phase. Progression to downstream phases is strictly blocked until the deliverable is updated and validated.  
> **Language rule:** All content in the deliverable MUST be strictly in English.  
> **Presentation rule:**  
> - **Headings & Titles:** Document titles, chapter titles, section headings (Heading 1 to 4), table captions, and figure captions MUST be formatted in **bold** (`run.font.bold = True`).  
> - **Body Paragraphs:** Justified alignment (`WD_ALIGN_PARAGRAPH.JUSTIFY`), first-line indent of exactly **0.5 cm** (`first_line_indent = 0.5 cm`).  
> - **Tables:** Captions placed directly **ABOVE** the table (`Table <Chapter>.<Seq>: <Title>`), bold. Header row bold and centered. Cell contents justified without first-line indent.  
> - **Figures & Diagrams:** Captions placed directly **BELOW** the figure (`Figure <Chapter>.<Seq>: <Title>`), bold and centered. All diagrams MUST follow the mandatory two-step workflow: created and exported as editable `.drawio` files first, and only then exported to high-resolution static `.png` images for embedding into the Word document.
> - **Diagram Layout & Anti-Overlap Invariant:** All embedded diagrams must strictly enforce zero obstacle crossing (lines never cut through notations/shapes), orthogonal routing with explicit waypoints, explicit perimeter port anchoring, white opaque label backgrounds, and minimum channel clearance (60–80px).

# Master Specification Authoring Skill

## 1. Role & Objective
This skill governs the end-to-end authoring, updating, formatting, and baselining of the project's primary engineering deliverable:
`artifacts/Requirements_Analysis_Design_Specification.docx`.

It serves as the dedicated cross-cutting skill responsible for synthesizing approved artifacts into a unified, publication-grade Word specification document.

---

## 2. Chapter Ownership & Integration Scope

| Document Section | Source Lifecycle Phase | Source Artifacts | Governing Domain Skill |
|---|---|---|---|
| **Cover Page & Record of Changes** | Cross-cutting / Baseline Gates | Project metadata, approval records, version history | `master-specification-authoring` |
| **Chapter I: Business Context** | 01 Business Requirements | Business Background, Problem, Objectives, Vision, Scope, Risks, Assumptions, Business Rules | `requirements-engineering` |
| **Chapter II: Business Processes & User Classes** | 02 Process Discovery & User Classes | AS-IS assessment, TO-BE workflows, BPMN diagrams (`.drawio` → `.png`), User Classes | `business-process-modeling`, `requirements-engineering` |
| **Chapter III: Software Requirements & Use Cases** | 03 Requirements & 04-05 Use Cases | URs, FRs, Quality Attributes (NFRs), Constraints, External Interfaces, Data Dictionary, Use Case Diagrams, Structured Use Case Descriptions, Activity Diagrams | `requirements-engineering`, `usecase-modeling` |
| **Chapter IV: Analysis Models** | 06 Analysis Modeling | BCE Class Catalogs, VOPC Diagrams, Analysis Sequence Diagrams, State Machine Diagrams | `analysis-modeling` |
| **Chapter V: Design & Database** | 07A/07B Architecture & Detailed Design | High-Level Architecture, Style Trade-offs, Subsystems, Components, Packages, DCDs, Design Sequence Diagrams, Class Specs, Conceptual/Logical/Physical ERDs, Data Dictionary | `software-design`, `database-design` |

---

## 3. Standard Authoring & Synchronization Workflow

### Step 1: Pre-requisite Verification
1. Ensure the upstream phase has passed its Human Verification Gate with explicit approval.
2. Verify all diagram sources have been exported to editable `.drawio` files first in `artifacts/diagrams/`, and then exported to high-resolution `.png` images in `artifacts/diagrams/images/`.
3. Check that tabular data (Business Rules, Requirements, Use Case lists, BCE classes, DB tables) are fully validated.

### Step 2: Template Initialization (First Run) or Baseline Load
- If `artifacts/Requirements_Analysis_Design_Specification.docx` does not exist:
  - Copy `/templates/Template_Requirements_Analysis_Design_Specification.docx` to `artifacts/`.
  - Initialize project title, author, date, and Version `1.0` in the metadata cover page and `Table 0: Record of Changes`.
- If already existing:
  - Open the existing file for incremental chapter synchronization.
  - Increment version entry in `Table 0` (e.g., `1.1`, `1.2`, `2.0`).

### Step 3: Populate and Format Chapter Content
Execute formatting using the dedicated script:
`python .agents/skills/master-specification-authoring/scripts/sync_specification.py`

Ensure the script strictly applies all presentation rules:
1. **Bold Headings:** Apply bold styling to all title runs (`run.bold = True`).
2. **Body Indentation:** Set `p.paragraph_format.first_line_indent = Inches(0.197)` (~0.5 cm) for standard body paragraphs.
3. **Table Formatting:**
   - Table Title above: `Table X.Y: <Title>` in bold.
   - Header row: Bold, centered, light background shading.
   - Body cells: Justified, unindented.
4. **Figure Formatting:**
   - Center-align image paragraph.
   - Insert figure caption below: `Figure X.Y: <Title>` in bold, centered.

### Step 4: Verification & Gate Review
1. Inspect the resulting `.docx` file for formatting anomalies, table overflows, missing figure references, or untranslated text.
2. Confirm 100% English adherence across all sections.
3. Confirm bidirectional alignment between the Word deliverable and the RTM (`Requirements_Traceability_Matrix.xlsx`).
4. Submit the updated deliverable to the authorized Project Lead / PO / Architect for phase baseline sign-off.

---

## 4. Authoritative Form and Table Schemas Reference
All table layouts, form structures, and section organizations MUST be read from and strictly conform to:
`examples/SWD392Example_RDS Document-VersionVietNhat.docx`

Key forms to inspect and replicate:
- **Record of Changes (`Table 0`):** 5 columns (`Version`, `Date`, `A* M, D`, `In charge`, `Change Description`).
- **Business Rules Form (`Table 1`):** 3 columns (`Business Rule ID`, `Description`, `Reference Source (if applicable)`).
- **Use Case Description Form (`Tables 2–7`):** Canonical 12-row table (`ID and Name:`, `Created By:` / `Date Created:`, `Primary Actor:` / `Secondary Actors:`, `Description:`, `Trigger:`, `Preconditions:`, `Postconditions:`, `Normal Flow:`, `Alternative Flows:`, `Exceptions:`, `Priority:`, `Business Rules:`).
- **Data Dictionary Form (`Table 8`):** 4 columns (`Name`, `Data Type`, `Length`, `Description`) grouped by Entity rows.
- **Architecture & Design Mapping:** Structure following Chapters 3 and 4 of the reference document.

