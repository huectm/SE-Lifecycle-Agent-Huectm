# FreshFood Package Design

Version: 0.4 ? Draft for Design Review  
Date: 2026-10-27  
Governing skill: software-design  
Supporting skill applied: external-skills/codebase-design  
Target master section: Chapter V, Package Diagram.

## Source and design status

Source-confirmed: both Web subsystems have Pages and CallService; Mobile uses Views, ViewModels and Models. The API has Controllers and Services. Latest stakeholder direction places service interfaces directly in Services, implementation classes in its nested Implements package; repository interfaces directly in Repository, persistence implementations in its nested Implements package. Entity and DTO package allocation is requested as an engineering recommendation.

Naming: FSOReposistory is interpreted as the repository role of the existing FreshFood-API.DataAccess component, not an instruction to rename the approved FreshFood system. No baseline subsystem/component name was changed.

## Package allocation

| Component / namespace | Package | Content / responsibility | Status |
|---|---|---|---|
| FreshFood-Customer-Web | Pages; CallService | Customer presentation pages; API-call adapter | User-directed |
| FreshFood-Web | Pages; CallService | Staff presentation pages; API-call adapter | User-directed |
| FreshFood-App | Views; ViewModels; Models | MVVM presentation, presentation logic, data/service access | User-directed |
| FreshFood-API | Controllers | API request handling and service invocation | User-directed |
| FreshFood-API | Services | Service interfaces directly in this package; uses DTO contracts | User-directed |
| FreshFood-API | Services.Implements | Nested package containing classes that implement service interfaces; consumes repository abstractions and domain entities | User-directed |
| FreshFood-API.DataAccess | Repository | Repository interfaces directly in this package; contains nested Implements | User-directed |
| FreshFood-API.DataAccess | Repository.Implements | Concrete repository/persistence implementation classes | User-directed |
| FreshFood-API.DataAccess | Entities | Backend domain entities used by business and repository implementations | User-directed placement, 2026-10-27 |
| FreshFood-API | DTOs | Explicit request/response contracts used by Controllers and Services; separate from domain entities | Stakeholder-confirmed placement, 2026-10-27 |

No separate Interfaces subpackage is introduced. Native nested drawio ownership expresses Services.Implements and Repository.Implements containment. Concrete interface and class names, fields and operations remain TBD ? Stakeholder confirmation required during detailed design. Models on Mobile are client-side representations, not shared backend Entity classes.

## Rationale from supporting external skill

codebase-design defines a seam as the location of an interface, distinguishes the interface from its implementation and recommends accepting dependencies rather than constructing them inside business code. Those principles support keeping stable contracts visible to callers, isolating implementation classes and injecting repository implementations. The skill does not prescribe Entities/DTOs folder names or a shared-project architecture; the specific package allocation here is an engineering proposal under software-design governance.

Entities is now owned by FreshFood-API.DataAccess, following the stakeholder instruction on 2026-10-27. Services.Implements references DataAccess.Entities; Repository.Implements references the same package internally. Interfaces and implementations remain separated as requested. Entity ownership within DataAccess does not require the entity classes to depend on persistence-framework types, database connections or controllers.

DTOs is owned by FreshFood-API, following explicit stakeholder confirmation on 2026-10-27. Controllers and service interfaces depend on the API-owned DTO contracts. DataAccess does not reference API DTOs. The earlier FreshFood.Shared proposal is withdrawn from the current diagram; no additional Shared or Core component is introduced. The stakeholder confirmed the two ownership decisions, not the entire revised Package Diagram.

Entities carry domain state and invariants; DTOs carry explicitly selected boundary data. DTOs should not inherit from domain entities or expose persistence internals. Mapping belongs in the consuming application/service implementation or an adapter as appropriate; no extra Mapping package is assumed. The DTO contract may be represented by client-specific/generated types; frontend packages do not import backend runtime classes across technology boundaries.

## Dependency injection and UML semantics

Controllers uses Services interfaces. Services.Implements depends on its parent service contracts and on Repository contracts, not on Repository.Implements. Repository.Implements depends on its parent repository contracts. Service and repository implementation classes use Entities. Services interfaces use DTO contracts. DI registration occurs in application startup and supplies concrete implementations; DI is not modeled as a package.

Dashed open arrows are UML package/contract usage dependencies. The Implements-to-parent usage paths indicate access to the parent interfaces; they do not replace class-level interface realization, which will be specified with classes during detailed design. Native folder tabs represent UML packages. Cross-component dependencies from CallService / Mobile Models to Controllers denote consumption of the business API contract, not remote source-code imports. Dependency cycles and unrelated package/notation crossings were checked geometrically. The parent namespace is allowed to contain its own implementation package.

If these components become independently compiled projects, API may reference DataAccess repository contracts and Entities while DataAccess remains independent of API-owned business services. DTOs remain internal to API; DataAccess does not depend on API types. Deployment packaging is unchanged and no sixth component is introduced.

## Traceability and review

The earlier approved component names are retained: CMP-CUSTOMER-WEB, CMP-STAFF-WEB, CMP-CUSTOMER-MOBILE, CMP-API-BUS and CMP-API-DATA. The new package allocation refines that view but remains unapproved. No upstream requirement IDs, detailed Entity/DTO fields or new business rules have been invented. RTM and the Master Specification remain on their previous approved baseline until this Package Diagram and the proposed shared namespace pass design review.

The master template contains a Package Diagram subsection. No dedicated Package Diagram example was found in examples. Editable .drawio was generated and validated before PNG export. The image was visually inspected for nested ownership, correct dashed usage arrows, clear labels and connectors, with explicit ports on folder tabs where top anchors are used.

Artifacts:
- artifacts/diagrams/architecture/freshfood-package-diagram.drawio
- artifacts/diagrams/images/freshfood-package-diagram.png

Gate: Pending stakeholder / Architect review. Entity/DTO package ownership is confirmed; the complete revised Package Diagram awaits review before figure integration and detailed implementation. External skill principles do not constitute architecture approval.


## Revision 0.3 - Entity ownership decision

Stakeholder instruction: place the Entity package inside the DataAccess component. Applied as FreshFood-API.DataAccess.Entities using native nested package ownership in drawio. Services.Implements and Repository.Implements dependencies were rerouted to this package; Entities was removed from FreshFood.Shared. DTO placement remains an open proposal. Namespace labels were positioned away from incoming dependency routes and the PNG was re-exported and visually checked.

This is a local revision of the Package Diagram draft. It does not constitute approval of the whole package view or the DTO/shared proposal, and does not modify the previously approved Component Diagram baseline.


## Revision 0.4 - Confirmed DTO ownership

Stakeholder confirmed DTOs belongs to FreshFood-API on 2026-10-27. The diagram now contains FreshFood-API.DTOs and FreshFood-API.DataAccess.Entities; FreshFood.Shared was removed. Controllers and Services use DTOs; Services.Implements and Repository.Implements use Entities. No direct dependency from DataAccess to API DTOs is introduced. The two confirmed ownership decisions are synchronized as narrative in the Master Specification Package Diagram section; the full draft diagram remains pending review. Historical revision notes above document superseded proposals only.


## User-directed component rename - 2026-10-27

The stakeholder explicitly renamed `FreshFood-API.DataAccess` to `FreshFood.Reposistory` (spelling retained exactly as requested). The current Component and Package diagram labels, including the Entity ownership note, use `FreshFood.Reposistory`. Earlier names in this document describe the previous revision. Component identity, existing diagram IDs, library role, IDataAccess contract, package allocation, dependencies and behavior are unchanged. The confirmed name is an explicit exception to the default parent-qualified naming convention; it does not introduce another subsystem. The complete Package Diagram retains its pending-review status.
