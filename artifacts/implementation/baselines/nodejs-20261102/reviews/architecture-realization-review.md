# Architecture to VOPC Design Realization Review

Version: 0.2 | Date: 2026-10-31 | Status: User-directed correction, design review pending.

## Direct source audit

The high-level, component and package Draw.io masters were read directly. The actual backend is Node.js, Customer Web and Staff Web are React, and Customer Mobile is Flutter. The scaffold package.json files confirm a Node.js ESM API and sibling repository library. HTTP framework, language tooling, PostgreSQL driver and DI library remain unselected. The prior .NET-specific signatures were an incorrect refinement and are superseded by Node-compatible typed UML; no TypeScript configuration or runtime implementation is claimed.

The component view exposes IBusinessAPI to clients and IDataAccess from FreshFood.Reposistory to FreshFood-API. These are aggregate architecture contracts realized by the feature controller/DTO and repository/transaction contracts respectively; they are not silently renamed to one feature class. The package view keeps Web Pages/CallService, Mobile Views/ViewModels/Models, API Controllers/Services/Implements/DTOs and repository Repository/Implements/Entities. Ownership is maintained in mappings and not drawn as package frames or qualified class headers.

## Required refinement of VOPC

Every one of the 48 participating VOPC classes has a recorded design realization. Each use-case master now starts with a connected realization page: retained classifiers, extracted interfaces, split frontend boundaries, repository implementation, domain policies and external adapters appear together. VOPC origin and applied solution are tagged on the classifier. That page displays a member excerpt to keep all participants visible; the following full-detail views and class-specifications.md contain complete members.

| VOPC role | Detailed realization | Applied selected solution |
|---|---|---|
| UI boundary | React Page + CallService client; Flutter View + ViewModel + API Model | UI/API separation and mobile MVVM; frontend has no DI |
| Controller | FeatureController retaining use-case boundary responsibility | Layered HTTP entry; backend constructor injection of IFeatureService |
| Application logic | IFeatureService + FeatureService, repository contract/implementation and extracted supported policies | Backend DI, Repository, pure domain policy refinement |
| External boundary | Port interface + provider adapter; payment server notice handler where applicable | Adapter and backend-only DI |
| Entity | Same domain class with guards and materialized object navigations | Domain model; IDs/data remain traced to existing schema |

Repository operations depend on the entity types they query, create or update; no retained result fields are prescribed. Read-only domain navigations are constructed as needed and do not add physical columns. Stored DI/collaborator references use solid navigable associations. DTO and non-entity-to-entity usage relationships use dashed open-arrow dependencies. Implementation-to-interface relationships use hollow-triangle realization. Package notation and frontend injection constructors remain absent.

## Use-case refinement

| Use case | Principal policy refinement beyond application/repository separation |
|---|---|
| UC-C01 | BatchPricingPolicy derives active/clearance batch prices without changing catalog rules |
| UC-C03 | Same pricing policy plus Cart/CartItem/Product/BatchInventory aggregate navigations |
| UC-C05 | Geocoding port/adapter and Customer/CustomerAddress/Order object collaboration |
| UC-C06 | DistanceCalculator, DeliveryFeePolicy, locked FefoBatchSpecification, payment and notification adapters, shared transition dispatch |
| UC-C07 | Batch pricing for re-order, owned order/cart/review/audit collaboration, cancellation transition dispatch and notification adapter |

All 24 state-transition handlers are retained, one per original transition. There is still no Pending parent or PendingUnpaid -> PendingPaid transition. No new staff/customer use case, refund provider, retry policy, migration or application code is introduced. Integer-VND values use bigint-backed domain values and explicit decimal-string wire projection; latitude, longitude, distances and bounded quantities are not converted to money. These encodings remain proposed detailed API/persistence mappings for review.

## Evidence and limits

See architecture-to-design-realization.csv for architecture source nodes, analysis-to-design-mapping.csv and vopc-realization-mapping.json for exact source/target classifiers, diagram-pages.json for exported views, and design-verification.json for checks. The five first-page views must each contain every mapped participant and the DTO graph in one connected collaboration view. Existing analysis sequence messages are mapped to operations; revised detailed design sequences and runtime execution are not asserted.

Before baseline, reconcile older Pending clauses, audit actor storage for customer cancellation, generic transition event/version storage, payment-reference correlation and unresolved payout policies. Only approved technical content is integrated into the Master Specification at the required design gate.
