# Architecture to C# Design Realization Review

Revision 2026-11-02: FreshFood-API is an ASP.NET Core 10 Web API; FreshFood.Reposistory is its .NET 10 class-library dependency. The component/package names and frontend packages remain unchanged. Controllers map to ASP.NET endpoints, application logic to injected service interfaces, repositories to parameterized Npgsql implementations, DTOs to C# boundary contracts, and VOPC entities to repository-owned C# entity types.

Backend DI references remain associations to interfaces; realizations point to interfaces; DTO/entity usage remains dependency. Web and Mobile views retain their client-language contracts. Detailed class diagrams have no package containers. One OrderStateMachine encapsulates 24 table rows; per-transition classes are historical only.

The 48 VOPC participations remain in analysis-to-design-mapping.csv. Actual C# source paths are recorded in artifacts/implementation/dotnet-source-mapping.csv. Technical verification and unresolved external contracts are recorded in artifacts/implementation/dotnet-migration-review.md.

## PIM, Source and Interaction Consistency Review

Date: 2026-11-03. Scope: UC-C01, UC-C03, UC-C05, UC-C06 and UC-C07.

The stakeholder confirmed that detailed class and sequence models are PIM. Literal equality with C# signatures is superseded by explicit logical-to-platform refinements. The prior mixed PSM audit is archived under `../baselines/mixed-psm-20261103`.

The current model contains 157 classifiers, 54 class pages and 29 sequence pages. All 347 logical operations have a declared mapping: 218 implemented, 7 framework refinements, 114 frontend design-only and 8 deferred integration entries. Frontend design-only and deferred entries are not claimed implemented.

Corrected responsibilities include trusted transition context and derived order-line product projections. Corrected interactions include address ownership reads, checkout FEFO/pricing, final state reads after transition effects and post-commit notifications excluding idempotent replay. QR generation explicitly distinguishes the current unavailable path from a future approved provider/correlation path.

`Task`, cancellation tokens, ASP.NET route binding, generic persistence materialization and infrastructure-specific types belong to the mapping, rather than PIM operation contracts. `RepositorySession` maps to the existing `PostgreSqlSession` implementation. One table-driven OrderStateMachine remains responsible for transitions.

Evidence: [PIM verification](pim-code-consistency.json), [operation mapping](pim-to-code-mapping.csv), [sequence static review](../design-sequence-static-review.json). All 41 local tests passed in `artifacts/implementation/dotnet-test-results/pim-mapping.trx`. Static checks verify declared refinements and selected ordering invariants; they do not establish exhaustive behavioral equivalence.

Maps, payment verification/correlation, notification transport and payouts remain deferred or fail-closed. Existing business-policy TBDs and the previous SonarCloud quality-gate failure remain unresolved. No production behavior, database schema or payment policy was changed by this PIM revision.
