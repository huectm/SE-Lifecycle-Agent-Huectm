# Order State Machine Control Design

Version: 0.6 | Decision date: 2026-11-03 | Basis: explicit stakeholder selection of the table-driven alternative.

## Selected solution

OrderStateMachine replaces TransitionExecutor, ITransitionExecutor, IStateTransition and the 24 individual transition implementation classes. The earlier model/source is retained only as a dated baseline archive. The class encapsulates a private transition table and implements IOrderStateMachine through backend constructor DI.

- ProcessEventAsync(snapshot, event) resolves the current state, incoming business event and trusted guard facts, selects an unambiguous table row per region, executes its action and follows declared internal completion events.
- CurrentState() returns the managed order state view. Fulfillment, payment, refund and transient UML workflow position remain distinct. Before an aggregate is bound, it returns null.

The logical result represents the reference figure's out-action output through StateMachineResult: Applied, Duplicate, TransitionIds, Actions and State. The action outputs describe effects executed in the caller's transaction, not arbitrary commands that the UI may inject. The table and guard dispatch remain private.

## Table and state semantics

[Transition table](order-state-transition-table.json) and [traceable row mapping](state-transition-class-mapping.csv) preserve all 24 existing transition IDs, sources and targets. IDs identify rows and durable execution evidence; they do not identify implementation classes.

The common acceptOrder event applies I00, routes the private payment-choice pseudostate to exactly one T01u/T01p branch, and initializes the independent payment region. The enabled unpaid path records I00, T01u and P01 in the checkout transaction. Verified paid acceptance and payment capture remain disabled pending persistent payment correlation and provider policy; table representation does not imply completed integration.

cancelOrder selects T08u, T08p or T09 from the locked current fulfillment state and trusted ownership. Its action releases reservations, saves Cancelled and records the customer audit. Internal completion records F_cancelled and finishes fulfillment without adding a database OrderStatus. Payment/refund dimensions remain accessible independently. A completed cancellation request replay returns at the service layer and does not add a self-loop to the state chart.

## Responsibilities and transaction boundary

CheckoutService and MyOrdersService submit events; they do not select transition IDs. The service owns UnitOfWork. OrderStateMachine retains IOrderLifecycleRepository through an association and uses internal DTOs/entities through dependencies. There are no package frames in the detailed class view.

The checkout repository remains the sole persistence site for stock reservation/order lines, after state-machine acceptance, in the same transaction. This avoids reserving stock a second time in the machine. Customer/reference-scoped idempotency claims and the original confirmation commit together with the domain effects and table-row evidence. Notification attempts occur after commit and are not repeated on replay; a durable notification outbox is outside this increment.

## Scope and verification limits

Customer acceptance/cancellation actions and fulfillment completion are implemented. Staff fulfillment, return and refund effects remain deferred, with explicit unsupported-event errors. The private table retains their approved triggers/guards/targets as design data; it does not invent policies for them. Unknown events, ambiguous per-region routing, completion cycles, untrusted snapshots and inconsistent prior evidence fail closed.

The active source has one state-machine control class rather than classes per transition or per state. Web/Mobile refinements, backend-only DI, DTO relationships and Entity dependency conventions are preserved. The revised class and sequence artifacts and the consolidated specification must reference this selection consistently.
