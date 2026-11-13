# FreshFood API

Node.js ES module backend mapped from the stakeholder-approved detailed class and sequence designs. The component names and package ownership follow the architecture: Controllers, Services, Services/Implements and DTOs. The sibling `FreshFood.Reposistory` owns repository contracts, SQL implementations and domain entities. Constructor injection is backend-only and uses the approved binding registry without a third-party container.

## Run local checks

Use Node.js 22 or later. From this directory:

```powershell
npm test
npm run check
npm run check:design
npm run coverage
npm start
```

The code uses Node built-ins and relative ESM imports; local checks do not require installing packages or provider credentials. `npm start` uses `runtime.example.js` by default and listens on `127.0.0.1:3000`. `GET /health` is a liveness check. Database-backed operations intentionally fail with 503 in this unconfigured runtime; protected operations also require a trusted authenticated principal. It is not a production-readiness endpoint.

## Supply the real runtime

Set `FRESHFOOD_RUNTIME_MODULE` to a trusted local module specifier or file URL. It exports `authenticate(request, signal)` and `scopeFactory(principal, signal)` used by `createApiServer` in `http.js`.

The authentication adapter must verify server-side credentials and return the existing `AuthenticatedPrincipal` shape. A client-provided customer ID, arbitrary header or JSON field must never establish identity. Guest carts require a server-validated persistent session ID. Authentication/login use cases are outside this five-use-case increment.

For each request, acquire an independent PostgreSQL connection, implement `DatabaseConnection.QueryAsync(sql, parameters, signal)`, and call `createRequestScope({connection, principal, transport})`. The connection must remain on the same physical client throughout BEGIN/COMMIT/ROLLBACK; do not implement QueryAsync with unrelated pool queries. Add `DisposeAsync` to the returned request scope to release the client. The driver/pool and production credential mechanism are supplied by the deployment runtime rather than silently selected by this mapping task.

`HttpTransport.SendAsync` is a server-owned integration dispatch port. The concrete adapter must implement and authenticate these dispatch keys: `maps:geocode`, `maps:distance`, `sepay:create-qr`, `sepay:verify-notice`, `notifications:publish`. They are dispatch identifiers, not external URLs. Validate actual provider payloads, timeouts and signatures before enabling these integrations; the class names do not establish a live Google Maps or SePay integration. Outgoing refunds remain disabled.

Use environment variables or a secret manager for real credentials. Do not commit tokens, provider keys or connection strings.

## Scope and interfaces

The implemented service methods cover catalog/search/details/clearance, current cart inspection and absolute quantity changes/removal, profile/address management, checkout planning, COD order orchestration, owned order history/detail, cancellation orchestration, reorder and delivered-order review. `routeCatalog` in `http.js` lists 22 HTTP routes. Controllers delegate to injected service contracts; DTO wire properties retain the exact PascalCase names in the approved design. VND values serialize as integer strings and database BIGINT identifiers remain strings. Repository SQL translates database uppercase status codes to the domain enums.

`ChangeQuantityAsync` currently represents absolute quantity setting, as in its approved DTO. The additive ?Add to cart? alternative needs an explicit action discriminator or separate method in the design; the API does not silently reinterpret quantity as both absolute and incremental. Reorder currently merges supplied product quantities into an existing cart without deleting unrelated lines; the returned result describes the reordered lines, so a client must reload GetCartAsync for the complete basket. These are recorded implementation/design review points.

The 24 distinct transition classes retain stable IDs. Customer acceptance/cancellation paths have guarded effects. Staff fulfillment/return/refund transitions have mapped source classes but their effects are outside this increment and remain unavailable. Do not treat class existence as completion of those staff use cases.

## Remaining runtime blockers

The approved design explicitly leaves durable transition-event/idempotency storage, customer audit identity schema, pre-acceptance QR/payment correlation, late/excess payment handling and prepaid-cancellation refunds unresolved. `OrderLifecycleRepository.RecordEventOnceAsync` and customer audit persistence therefore fail closed. With the default SQL repositories, order submission/cancellation cannot be claimed operational until those storage decisions are resolved. COD orchestration and rollback are exercised against explicit test doubles; no live database success is asserted.

Paid acceptance and payment callbacks return named 503 errors until trusted persistent correlation is implemented. The source never moves fulfillment from Pending Unpaid to Pending Paid. Fractional-VND discount results fail with ROUNDING_POLICY_TBD rather than inventing a rounding policy. The physical schema uses integer quantities.

## Traceability and verification

- `../../artifacts/implementation/backend-class-source-mapping.csv`: every backend classifier and its file.
- `design-contracts.json`: approved method names and source ownership.
- `../../artifacts/implementation/backend-implementation-review.md`: scope, validation and outstanding gaps.
- `tests/backend.test.js`: local unit/module/HTTP checks with test doubles, not PostgreSQL or provider integration tests.

Code, runtime integration and formal QA/quality-gate approval are separate from the stakeholder's design approval. This increment is submitted for code review, not production release.
