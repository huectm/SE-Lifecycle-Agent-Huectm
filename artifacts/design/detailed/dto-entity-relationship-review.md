# DTO and Entity Usage Relationship Review

Date: 2026-10-31 | Status: Stakeholder-directed notation correction; design baseline approval pending.

| Relationship | Detailed class notation | Reason |
|---|---|---|
| Backend controller/service to injected interface | Solid navigable association | Owned reference supplied through backend constructor DI |
| Backend implementation to implemented interface | Dashed hollow-triangle realization | Interface implementation contract |
| Class to DTO parameter/result or wire projection | Dashed open-arrow dependency, consumer to DTO | Data contract usage, not an injected collaborator |
| Processing/repository/policy class to entity | Dashed open-arrow dependency, consumer to entity | Query, materialization, business operation or persistence type usage |
| Entity to related entity | Existing domain association | Preserves domain structure and read-only navigations |
| DTO containing nested DTOs | Structural association | Explicit nested DTO property/collection |

The first-page VOPC realization of each use case now includes the request/response DTO graph and its consumers. The DTO contract pages include the controller, service interface and service implementation as appropriate, so the DTOs are not detached class listings. Shared callback/gateway/transition views include DTOs used directly by their contracts. Frontend DTO dependencies denote platform-local wire projections, not backend runtime object imports.

The earlier repository fields retaining materialized entity lists have been removed. Repository methods return/query/update entities through usage dependencies; the diagram no longer invents retained object references to justify associations. Backend DI references and their constructor signatures remain. Source VOPC mappings and the 24 unique transition classes are retained.

See dto-entity-dependency-mapping.csv and design-verification.json for relationship-level evidence. No package frames, frontend DI, application code, database migration or new business policy is introduced by this correction.
