# FreshFood Component Design

Version: 1.0 (Stakeholder-Approved Component Diagram)  
Date: 2026-10-27  
Governing skill: software-design  
Governing rules: design-rules ?6.1?6.2  
Reference: examples/ComponentDiagram .png  
Intended master section: Chapter V, High-Level Architecture, Component Diagram.

## Source-confirmed direction

The user requires two backend components: one API component encapsulating business behavior and one data-access component. Components collaborate through interfaces. Subsequent instructions require UML provided-interface circles and required-interface sockets following the supplied reference; the view must show only software components, component types and interfaces, omit technologies, databases and system boundaries, match architecture subsystem names and use balanced, similarly sized component boxes.

## Component catalog and subsystem mapping

| ID | Diagram name | Type | High-level subsystem mapping | Responsibility |
|---|---|---|---|---|
| Existing presentation | FreshFood-Customer-Web | subsystem | FreshFood-Customer-Web | Customer browser application; requires IBusinessAPI. |
| Existing presentation | FreshFood-Web | subsystem | FreshFood-Web | Staff and Store Owner application; requires IBusinessAPI. |
| Existing presentation | FreshFood-App | subsystem | FreshFood-App | Customer mobile application; requires IBusinessAPI. |
| CMP-API-BUS | FreshFood-API | service | FreshFood-API, business/API component | Business rules, authentication, use-case orchestration and existing gateway coordination; provides IBusinessAPI and requires IDataAccess. |
| CMP-API-DATA | FreshFood-API.DataAccess | library | Internal data-access component of FreshFood-API | Persistence and transaction execution; provides IDataAccess. |

The existing four subsystem names are retained exactly. FreshFood-API.DataAccess is parent-qualified because it is an internal component, not a separately named subsystem in the high-level architecture. It replaces the draft label Data Access Project. FreshFood-API replaces the generic draft label API Project. Both components continue to belong to the existing FreshFood-API subsystem; omitting the visual boundary does not change ownership or deployment.

## Interface catalog

| ID | Interface | Provider | Consumers |
|---|---|---|---|
| IF-BUS-API | IBusinessAPI | FreshFood-API service component | FreshFood-Customer-Web, FreshFood-Web, FreshFood-App |
| IF-DATA-ACCESS | IDataAccess | FreshFood-API.DataAccess library component | FreshFood-API service component |

IBusinessAPI appears three times for readable routing; these are repeated presentations of one contract, not new contracts. Provided/required shapes are editable native drawio circle and requiredInterface elements. Interface assemblies use solid arrowless stems. Dependency direction is from consumers to the provider contract, without a circular business-to-data dependency. Concrete operation signatures remain TBD ? Stakeholder confirmation required at detailed design.

## Diagram scope and layout

Only five software components, their types, component glyphs and two interface contracts are shown. Technology labels, datastore elements, SQL connectors, system boundaries, actors, hardware and long explanatory notes are excluded from this view. They remain in their appropriate architecture/database views; their removal here does not delete them from the system design.

All component rectangles are 440 ? 180 px. Three presentation components form the left column; the service and library form the right column. Interfaces occupy reserved central and vertical corridors. This follows the reference grouping without stretching the API component across the diagram or stacking every component in one column.

## Traceability and impact

User direction ? CMP-API-BUS / CMP-API-DATA ? IF-BUS-API / IF-DATA-ACCESS ? Component diagram. Existing responsibility source: artifacts/design/system-architecture-design.md ?3.1 and ?5; subsystem names were checked against artifacts/diagrams/architecture/high-level-architecture.drawio. No new business requirement or technology choice is asserted. The stakeholder approved this component view on 2026-10-27. Component/interface names and their provider/consumer relationships are recorded in the RTM Design_Elements catalog. Detailed operation signatures, Entity/DTO placement and the broader architecture approval status remain unchanged.

On approval, integrate the diagram and verified component/interface mapping into Chapter V of artifacts/Requirements_Analysis_Design_Specification.docx and update the RTM Design_Elements catalog. Review interface/transaction coverage for the applicable V-Model integration test design. The existing approved architecture is not silently replaced.

## Review and artifacts

The approved Word template contains a Component Diagram subsection. Editable drawio was created and XML-validated before PNG export. Five equally sized component boxes, native circles/sockets, arrowless assemblies, omitted technologies/datastores/boundaries and architecture-consistent names were checked. Rendered PNG was visually inspected; interface label backgrounds were narrowed to avoid masking provider stems.

- artifacts/diagrams/architecture/freshfood-component-diagram.drawio
- artifacts/diagrams/images/freshfood-component-diagram.png

## Revision record

| Version | Date | Change |
|---|---|---|
| 0.1 | 2026-10-27 | Initial business/data-access decomposition and classifier-style interfaces. |
| 0.2 | 2026-10-27 | User-directed circle/socket notation following ComponentDiagram reference. |
| 0.3 | 2026-10-27 | User-directed software-only view; matching subsystem names; parent-qualified data-access component; no technologies/database/boundary; balanced equal-size component layout. |
| 1.0 | 2026-10-27 | Explicit stakeholder approval; approved Component Diagram integrated into Master Specification v1.2 / Chapter V / Figure 5.2; component/interface catalog synchronized to RTM. |

Gate: Component Diagram approved explicitly by the stakeholder in conversation on 2026-10-27. The diagram and corresponding decomposition/interface narrative are synchronized to Master Specification version 1.2, Chapter V, Figure 5.2. The RTM Design_Elements catalog records the approved components and interfaces. This approval is limited to the Component Diagram, not the full Design Baseline or Entity/DTO class-placement proposal.


## Integration verification scope

Exact approved PNG bytes were checked against the embedded DOCX image. Existing RTM nonblank values, formulas, sheet names and merged ranges were verified unchanged outside the eight added catalog rows; blank serialization may normalize empty cells. Existing FR-to-code/test rows were retained rather than inventing new requirement links. Detailed class placement and Entity/DTO proposals remain outside approval scope. Interface-based system/module integration tests require review when the corresponding architecture/detailed-design baseline gate is reached.

Document rendering QA: the approved diagram PNG was visually reviewed before integration. DOCX heading hierarchy, table schemas, page dimensions, exact image embedding and RTM preservation passed structural checks. Full Word-page visual validation remains pending: LibreOffice is unavailable and native Word PDF export did not complete. No claim of full Design Baseline completion is made.


## User-directed component rename - 2026-10-27

The stakeholder explicitly renamed `FreshFood-API.DataAccess` to `FreshFood.Reposistory` (spelling retained exactly as requested). The current Component and Package diagram labels, including the Entity ownership note, use `FreshFood.Reposistory`. Earlier names in this document describe the previous revision. Component identity, existing diagram IDs, library role, IDataAccess contract, package allocation, dependencies and behavior are unchanged. The confirmed name is an explicit exception to the default parent-qualified naming convention; it does not introduce another subsystem. The complete Package Diagram retains its pending-review status.
