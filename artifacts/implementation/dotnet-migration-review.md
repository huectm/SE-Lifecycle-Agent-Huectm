# ASP.NET Core C# Migration Review

Version: 0.5 | 2026-11-02 | Status: stakeholder-requested revision for technical review; not release approval.

## Authorized change

Replace the NodeJS backend with ASP.NET Core 10 C#, built-in DI and Npgsql 10.0.3. Preserve React/Flutter clients, PostgreSQL, canonical component names and the five approved customer use cases. Former Node sources/designs remain dated baseline evidence.

| Use case | Application class | Repository |
|---|---|---|
| UC-C01 | CatalogService | CatalogRepository |
| UC-C03 | CartService | CartRepository |
| UC-C05 | ProfileService | ProfileRepository |
| UC-C06 | CheckoutService | CheckoutRepository |
| UC-C07 | MyOrdersService | MyOrdersRepository |

Backend contracts use Task/Task<T> and CancellationToken. Decimal-backed VndAmount preserves integer string JSON. BIGINT IDs remain strings. Frontend Promise/Future contracts remain in client languages. Existing route and PascalCase DTO/enum shapes are retained; guest CSRF token retrieval is documented.

## State machine and consistency

One OrderStateMachine implements IOrderStateMachine with ProcessEventAsync and CurrentState. All 24 transition row IDs, original sources/targets and business event labels remain stable. PendingUnpaid/PendingPaid are independent initial choices after acceptOrder. Payment remains independent of fulfillment completion. There are no per-transition classes.

PostgreSqlSession retains one connection per outer transaction. Checkout claims, all-line reservations, order/lines, cart clearing, evidence and confirmation response are atomic. Cancellation, release and customer audit are atomic. Repeated cancellation preserves the original reason and does not release or notify twice. Existing migrations are reused, not applied to a live environment.

## Verification

Local evidence: `dotnet-test-results/dotnet-all.trx` records 41 passing tests: 32 unit/data cases, two design/DI checks, six ASP.NET HTTP cases and one SQL integration scenario asserting behavior across the five use cases. SQL uses actual Npgsql commands against a disposable local PostgreSQL-protocol fixture. Its single underlying connection does not prove real PostgreSQL multi-connection contention. No performance, exhaustive branch coverage or production integration acceptance is claimed.

The compiler treats warnings as errors. HTTP checks cover startup, private-route authentication, caller-ID rejection and guest CSRF. Unit checks cover money/shipping boundaries, stock invariants, cart ownership/clamping, profile validation, table routing, cancellation states and payment independence. SQL checks cover five-use-case reads/writes, replay, request conflicts, release-once, customer audit, event evidence and rollback.

## Remaining limits

JWT issuer/issuance and immediate revocation integration, production database provisioning, Maps/notification transports, SePay verification/correlation, late/excess payments, prepaid cancellation refunds and outgoing payouts remain unconfigured or TBD. Staff return/refund execution is outside this customer increment. Per-item inspection disposition lacks an approved single-value summary rule; that summary remains null. Adapter failures never report synthetic success. Notifications run after commit without a durable outbox policy.

Requirements, architecture, class/sequence masters, source mappings, RTM and Master Specification are revised together. Technical review and later release gates remain required.

## SonarCloud review on 2026-11-02

Completed analysis: 85936be9-119b-403e-9dbd-58f803d4e9c5. Project: huectm_SE-Lifecycle-Agent; organization: huectm. SonarScanner for .NET 12.0.0 uploaded the C# analysis after the stakeholder disabled Automatic Analysis. All 41 tests passed with coverage collection. Quality Gate: FAILED.

| Metric | Actual result |
|---|---|
| Bugs | 0 |
| Vulnerabilities | 5 |
| Code Smells | 13 |
| Security Hotspots | 0 |
| Coverage | 68.7% |
| Duplicated lines | 0.0% |
| Security Rating | B; gate requires A |

The two failed gate conditions are new-code security rating B (required A) and new-code coverage 68.7% (required at least 80%). Reliability, maintainability, duplication and reviewed-hotspot conditions passed. This does not establish production acceptance.

The 18 server issues comprise the original 11 Sonar C# findings and seven imported Roslyn recommendations. Two informational recommendations concern test infrastructure; 16 issues concern production sources. Five vulnerabilities are four missing regex timeouts and one conditional Secure cookie flag. Exploitability and treatment remain subject to contextual review. Raw webhook payload access and optional input defaults must be assessed against their approved contracts before mechanical changes. No production source fixes, issue suppression, false-positive closure or Quality Gate relaxation were performed.

| Main application service class | Coverage | Uncovered lines |
|---|---|---|
| CartService.cs | 92.6% | 2 |
| CatalogService.cs | 68.4% | 6 |
| CheckoutService.cs | 86.8% | 9 |
| MyOrdersService.cs | 43.9% | 23 |
| ProfileService.cs | 29.0% | 22 |

These are service-class metrics, not use-case event-flow or branch/condition coverage claims. Prioritize missing address-management paths in ProfileService and reorder/review/cancellation exception paths in MyOrdersService, while retaining tests for ownership, atomicity and payment independence.

Evidence: artifacts/analysis/sonarqube/review.json, quality-gate.json, metrics.json, issues.json, file-coverage.json and SonarCloud_Defect_Log.xlsx. The prior preliminary-review.json is retained as historical evidence and is superseded by this completed analysis.
