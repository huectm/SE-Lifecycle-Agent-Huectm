# Order Consistency Storage Amendment

Version: 0.5 | 2026-11-02 | Basis: explicit stakeholder authorization for supplemental storage design and migrations.

The PostgreSQL migration `src/FreshFood-DB/migrations/20261102_001_order_consistency.up.sql` is language-independent and retained during the C# migration.

| Element | Responsibility | Boundary |
|---|---|---|
| checkout_idempotency | Customer/operation/key primary key, unique checkout reference, request fingerprint, owned order and original response | Same transaction as stock, order/lines, cart and evidence |
| order_transition_events | Unique aggregate/event/transition evidence; initial aggregate links to order after persistence | Caller-owned UnitOfWork |
| audit_logs.customer_id | Customer actor FK, mutually exclusive staff actor; generated actor_type preserves SYSTEM rows | Same cancellation transaction |

Npgsql commands use positional parameters. Claim reads lock the scoped row. Replay returns the original response before checking the cleared cart or running the machine. Reused keys with changed requests/references fail. Completion verifies order ownership. No retention/cleanup policy is invented.

The down migration refuses to discard idempotency, transition or customer-audit history. Only disposable test schemas have been changed; production application is a separate gate.

Editable masters: `artifacts/diagrams/database/order-consistency-storage-amendment.drawio` and `artifacts/diagrams/class/audit-actor-entity-amendment.drawio`. PNGs derive from those sources.
