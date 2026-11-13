# FreshFood ASP.NET Core Backend

Selected by the stakeholder on 2026-11-02: C#, ASP.NET Core 10, built-in constructor DI, Npgsql 10.0.3 and PostgreSQL. Active backend projects contain no JavaScript runtime dependency. Former sources are preserved under `artifacts/implementation/baselines/nodejs-20261102/`.

## Build, test and run

From the workspace root:

```powershell
dotnet restore src/FreshFood.sln
dotnet build src/FreshFood.sln --configuration Release
dotnet test src/FreshFood.sln --configuration Release
dotnet run --project src/FreshFood-API --urls http://localhost:5080
```

`GET /health` runs without a database. PostgreSQL integration tests skip unless `FRESHFOOD_TEST_DATABASE` points to a disposable test database; unit and HTTP tests still execute. To execute SQL tests:

```powershell
$env:FRESHFOOD_TEST_DATABASE='Host=localhost;Database=freshfood_test;Username=test_user;Password=<test-password>'
dotnet test src/FreshFood.sln
```

The test creates a random isolated schema and drops only that schema. Its minimal fixture is not a production bootstrap. A single-connection PostgreSQL-protocol fixture is also available under `tests/infrastructure/postgres-fixture/`; it is test infrastructure, not backend runtime, and does not prove real server lock contention.

## Configuration

Use environment variables or .NET user secrets; never commit credentials:

- `ConnectionStrings__FreshFood`: PostgreSQL connection string.
- `Authentication__Authority`, `Authentication__Audience`: existing HTTPS JWT issuer and expected audience. Ownership comes from verified `customer_id` claims, never arbitrary headers/body IDs.
- JWT issuance and immediate revocation integration belong to the existing authentication subsystem, outside these five use cases. Verify that integration before production acceptance.

Authenticated clients use `Authorization: Bearer ...`. Guest cart identity uses a protected HttpOnly SameSite cookie. Guest mutations first obtain the cookie/token from `GET /api/security/csrf`, then send `X-CSRF-TOKEN`. Use HTTPS outside local development and configure persistent Data Protection keys for the deployment environment.

## Behavior and boundaries

Controllers delegate to injected services. `FreshFood.Reposistory` owns entities and repository contracts and never references API DTOs. Queries are parameterized; one scoped session retains one physical connection for the whole unit of work. CancellationToken propagates from HTTP through SQL.

IDs and integer VND retain string JSON representation; enum names remain PascalCase. Domain money uses exact decimal. FEFO stock allocation is atomic across all lines. Checkout claims, reservations, order/lines, cart clearing, transition evidence and the original confirmation commit together. Cancellation releases stock and appends audit once. Notifications run after commit without a durable outbox guarantee.

`OrderStateMachine` encapsulates 24 private transition-table rows. `ProcessEventAsync` returns selected action outputs in StateMachineResult; `CurrentState` returns the managed state view. The service owns the transaction. There are no per-transition classes or PendingUnpaid-to-PendingPaid fulfillment transitions.

## Existing integration limits

Maps, notification and SePay verification remain injectable ports returning explicit 503 errors until configured and verified. Production checkout needs an operational distance adapter. Pre-acceptance payment correlation, late/excess payment policy, prepaid cancellation refunds, outgoing payouts, staff return/refund execution and per-item inspection summary projection remain unresolved or outside this increment. No provider success is fabricated. Migrations have only been applied to disposable test schemas.

See [migration review](../../artifacts/implementation/dotnet-migration-review.md).
