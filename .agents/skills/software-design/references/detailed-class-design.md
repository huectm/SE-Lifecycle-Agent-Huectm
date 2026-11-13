# Detailed Class Design Conventions

Scope: stakeholder decisions for this project's detailed design class diagrams. These conventions refine the governing design rules; they do not select patterns for unrelated projects or approve unfinished design artifacts.

## Establish the design basis

Before drawing or changing classes, read the current high-level architecture, component diagram, package diagram, approved use-case descriptions, participating VOPC classes, and interaction diagrams. Use the editable masters, not filenames or an older generated summary alone. Check actual project manifests before selecting implementation types or libraries.

- Preserve subsystem, component, project and class names across views. In FreshFood, the repository component is spelled exactly `FreshFood.Reposistory`; do not silently correct it to another spelling.
- Follow the selected architecture when realizing the model in source: FreshFood uses ASP.NET Core 10 C#, React, Flutter and PostgreSQL. The stakeholder confirmed that detailed class/sequence views are PIM. Use neutral logical contracts there and [explicit PIM-to-code mapping](pim-code-mapping.md) for Task/Future, CancellationToken, ASP.NET binding, Npgsql and other platform details. Earlier Node.js implementations are historical.
- Record conflicts with approved upstream artifacts and unresolved contracts. A requested diagram correction does not authorize silently changing business requirements or declaring a design baseline approved.

## Realize each use case from VOPC

Produce a detailed design class view for each requested use case, with explicit analysis-to-design mappings using the approved template fields. Account for every participating Boundary, Controller, Application Logic and Entity analysis class: identify its design classes and the selected solution, or document a justified merge, split or transformation.

Show the mapped classes and their relationships in a connected realization view. A detached mapping table or a generic collection of architecture classes is insufficient. Preserve the VOPC class identity in the mapping even when its responsibility becomes several design classes. Show meaningful attributes, operations, visibility, parameter types and return types consistent with the interaction diagrams.

Apply the selected backend DI/repository and state-transition solutions to the mapped responsibilities; record the rationale. Separate domain responsibilities, transport DTOs, repository contracts and external gateway adapters without inventing new use-case behavior.

## Include the View layers

Read the package diagram to identify all View subdivisions; do not stop the detailed design at Controller or represent the UI with one generic box.

For the current FreshFood customer use cases, realize both client structures:

| Client | Design classes / collaboration |
|---|---|
| Customer Web | Feature Page in `Pages` -> concrete API client in `CallService` -> backend HTTPS API |
| Mobile | View in `Views` -> ViewModel in `ViewModels` -> concrete API model in `Models` -> backend HTTPS API |

The staff Web has its own `Pages` / `CallService` structure; include its classes when the requested use case involves that client. Do not invent staff use cases to fill a customer view.

Use ordinary concrete references on the frontend. The user's selected Dependency Injection solution applies only to backend classes; do not add frontend DI interfaces, registrations, or injected-constructor patterns merely to make the layers symmetrical. An HTTP call to a backend Controller is a remote collaboration, not injection of a server object into a client.

## Keep packages out of the detailed class diagram

Use the package diagram as the ownership source, but do not draw package containers or package frames in the detailed class view. Record ownership in class specifications or mapping metadata. Divide dense views into linked pages or focused views while retaining the class identities and relationships.

## Use precise relationship semantics

| Meaning | Required representation in this project |
|---|---|
| Backend object retains an injected collaborator | Solid navigable association to the collaborator interface; show the stored role/reference and constructor parameter |
| Concrete class implements an interface | Dashed realization with a hollow triangle toward the interface |
| Class consumes or produces a DTO as parameter, return value or transient data | Dashed dependency toward that DTO; do not leave DTOs disconnected |
| Service, repository, handler or policy uses a domain Entity | Dashed dependency toward the Entity, rather than an injected association to domain data |
| Entity-to-Entity domain relationship | Preserve the approved domain association and multiplicities |
| DTO owns/references another DTO through a property | Association reflecting that actual property; use ownership notation only when justified |
| Frontend object retains a concrete collaborator | Ordinary association reflecting the concrete reference |

A dependency arrow alone does not model the stored reference required by the selected backend constructor-injection design. Do not replace every relationship with an association: DTO and Entity usage dependencies and interface realizations retain their distinct meanings.

For each backend injected association, verify that the interface exists, the implementation realizes it, constructor and stored reference types agree, and a backend registration/binding is recorded. Do not choose a DI framework merely to illustrate a binding.

Include all DTOs used by displayed signatures and connect their consumers/producers explicitly. Use focused DTO views if needed for readability, with trace links to the same classes and operations. Keep API transport DTOs out of repository/entity signatures unless an approved contract explicitly supports that boundary crossing.

## Encapsulate the state chart in a table-driven state-machine class

The stakeholder selected the table-driven alternative on 2026-11-02. This supersedes the earlier one-class-per-transition choice for FreshFood. Do not generate or register individual transition implementation classes for this selected design.

Use an OrderStateMachine control class with the reusable operations `ProcessEventAsync(...)` and `CurrentState()`. Encapsulate its transition table as private data. The service submits a business event; the machine resolves current state, event and trusted guards to an allowed row and applies the associated action. Do not require service/UI callers to choose a TransitionId.

- Map every approved transition ID to a table row with region, source, event, guard, action and target. A transition ID remains useful for traceability and durable evidence; it does not imply an implementation class.
- Expose the state-machine contract through backend DI. The concrete machine realizes the interface and retains repository collaborators through associations. DTO/Entity usages retain the project dependency semantics.
- `CurrentState()` reads the managed object's state; do not introduce a conflicting persistent state copy. Keep fulfillment, payment and refund dimensions distinct. Choice and final-node positions are transient UML workflow data, not extra business statuses.
- For initial acceptance, process the common acceptOrder event, exactly one guarded Pending Unpaid/Pending Paid branch, and the corresponding payment initialization within the caller's transaction. Do not add a Pending Unpaid to Pending Paid fulfillment transition.
- Internal completion routing must be explicit table data, bounded against cycles and unambiguous within each region. Do not invent priority ordering to hide overlapping guards.
- A fulfilled/cancelled/returned final node ends fulfillment only. It must not end independent payment/refund handling or delete the object.
- Enforce trusted server facts, authorization, locking and durable event deduplication alongside table evaluation. Operation-level idempotent replay does not create a new state-machine transition. Keep transaction ownership and public operation signatures consistent with sequence diagrams and code.
- Archive superseded class/DI mappings for traceability and remove them from the active model, bindings and source. Revise VOPC-to-design mappings, DTO relationships, sequence participants, class specifications, RTM and the consolidated specification under the existing approval/change rules.

## Check consistency and presentation

Before delivery, verify VOPC participation coverage, architecture/project ownership, View subdivisions, constructor/interface/binding consistency, DTO connections, Entity dependency direction, and transition-to-table-row coverage. Reconcile operation names, parameters and results with design sequence messages; identify gaps rather than inventing methods silently.

Apply AGENTS.md Section 2.9 and design-rules.md Section 18.1. In particular, expand class boxes to fit members, reserve routing corridors, route orthogonally with explicit perimeter ports/waypoints, and protect labels with opaque backgrounds. Avoid shared collinear connector segments that obscure individual relationships. Where a perpendicular line crossing is unavoidable, use a visible jump and keep it away from labels and class boundaries; never cross an unrelated class box.

Save the editable `.drawio` master under `artifacts/diagrams/class/` before exporting PNGs. Inspect the exported views, including dense DTO/transition pages; correct collisions in the source and re-export. Geometry-only cleanup must preserve the classes, signatures, relation kinds and directions.

Use the existing project design review checklist and traceability artifacts. Submit new design content at the required design gate; integrate approved content into the designated Chapter V sections only under the existing approval/synchronization rules. Skill maintenance does not itself approve the diagrams.
