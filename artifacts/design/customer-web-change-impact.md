# Customer Web Subsystem Change Impact

Date: 2026-10-26 (Asia/Bangkok)
Status: User-directed revision; pending Architecture Review. No gate or baseline approval has been inferred.

## Confirmed Decision
The user requires Customer access through Web and Mobile App. Separate FreshFood-Customer-Web from FreshFood-Web; retain FreshFood-App for Android/iOS. Both customer presentation channels use FreshFood-API. React follows the existing Web design and Flutter follows the existing mobile design; no new technology selection is introduced.

## Synchronized Artifacts
- artifacts/design/system-architecture-design.md: version 1.1; five internal subsystems; customer channels; responsibility and requirement mappings.
- artifacts/diagrams/architecture/high-level-architecture.drawio and artifacts/diagrams/images/high-level-architecture.png: separate customer browser/mobile and staff browser paths.
- artifacts/diagrams/architecture/system-context-diagram.drawio and its PNG: Guest/Customer channel annotations; actor and central-system boundaries retained.
- artifacts/requirements/software-requirements-specification.md and Software_Requirements_Specification.docx: operating-environment channel clarification.
- artifacts/Requirements_Analysis_Design_Specification.docx: Chapter V subsystem and traceability tables, both existing architecture-view occurrences, context image, platform statement and revision record.
- artifacts/prototypes/prototype-specification.md: Customer Web ownership of existing browser prototypes.
- artifacts/traceability/Requirements_Traceability_Matrix.xlsx: two customer-channel design catalog entries and eight FR-CUS-01..08 links. Existing blank requirement/use-case/code/test fields remain unclaimed.
- artifacts/testing/test-design/Functional_Test_Design_Specification.md: channel-specific coverage and integration-test impact, pending test design review.

## Impact Assessment
Customer use-case behavior, business rules, database entities/schema, backend transaction boundaries and external gateway contracts are unchanged. Channel-neutral use-case, activity and database artifacts require no semantic edit. Customer browser and mobile implementations must share backend authorization, business rules and data through the API. Database access from either client is prohibited by the existing backend boundary.

## Verification
Editable drawio masters precede static PNG export. The architecture image was visually inspected. Explicit orthogonal waypoints were checked against unrelated node interiors with zero crossings. The updated architecture PNG is embedded byte-for-byte in Master Specification. All eight FR-CUS requirements have both customer-channel design links. Word was used to export updated documents to PDF for page-layout inspection; verification artifacts are in scratch/customer-web-qa.

## Remaining Review Items
- Architecture Review and corresponding integration-test design review are pending; no functional tests were executed for this architectural document change.
- Web push behavior is TBD - Stakeholder confirmation required. Existing Firebase mobile push is retained.
- The Master Specification already contains duplicate V.1 section/table/figure numbering for two architecture-view blocks. Both views are aligned with the new channel separation; their pre-existing numbering/hierarchy was preserved. Consolidation requires a separately controlled editorial change.
- Browser/mobile feature parity beyond existing requirements is not newly asserted.
- Original edited artifacts are backed up under scratch/customer-web-change-20261026.
