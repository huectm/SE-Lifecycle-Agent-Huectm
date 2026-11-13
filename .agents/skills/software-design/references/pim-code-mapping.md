# Detailed Design PIM to Source Mapping

Apply this reference when creating, reviewing, changing or implementing detailed class and design sequence models. The stakeholder confirmed on 2026-11-03 that FreshFood detailed design is PIM; C# source is its platform-specific realization.

## Model boundary

Use logical responsibilities, business data, interfaces, ownership, operation inputs/results, guards, errors and transaction semantics in PIM. Do not require C# syntax or ASP.NET infrastructure in the PIM diagram. Use neutral types such as Text, Integer, Boolean, DateTime, EntityId and Sequence<T>. An operation's existing Async suffix may identify asynchronous intent; it does not require a Task/Future implementation type.

Keep framework async wrappers, cancellation tokens, logging/configuration services, route/body binding, generic persistence materialization and runtime registrations in the PIM-to-code mapping or a separately identified PSM view. Never add those parameters to the logical model solely to make it resemble source code.

## Required mapping evidence

Record each PIM classifier/operation, its logical input/result, source classifier/member and source location, adaptation rationale, and implementation status. Mapping may be one-to-one, one-to-many, merged or delegated. Examples include one logical address-save operation mapped to POST and PUT actions; one transaction operation mapped to generic/non-generic overloads; and one logical request assembled from route and body fields.

Record where trusted identity originates. Framework binding must not turn caller-supplied customer identifiers into authority. Map logical DTO/entity data to source fields or derived projections explicitly. A server-created context may use an internal constructor and private execution flags without exposing those details as a client request DTO.

## Three consistency checks

1. Within PIM: every executable message resolves to an operation/responsibility of its receiver; logical arguments/results and object relationships agree. Mark local computations, delegate callbacks and linked refinements explicitly. Preserve scenario guards, alternatives, exceptions and transaction boundaries.
2. PIM to code: verify the declared adaptation using current semantic source symbols/calls, not only class names. Task versus a logical result, a local cancellation token, a transport route parameter or a generic overload is an adaptation, not automatically a design defect.
3. Behavioral realization: check responsibility, ownership, stock/payment invariants, ordering, idempotency, failure handling and post-commit effects. A missing required business effect remains a defect even if names match. Do not copy an incorrect implementation into an approved design.

Use Implemented, FrameworkRefinement, FrontendDesignOnly, or DeferredIntegration status as supported by evidence. A method that only returns an unavailable/TBD error is not an implemented success path. Show the unavailable branch and mark planned integration separately; do not invent unresolved payment or refund policy to close a mapping.

## Change and verification

Classify prior findings as behavioral drift, data/responsibility drift, accepted PSM adaptation, or an explicit deferred integration. Keep stable finding/requirement/use-case IDs and record disposition. Do not relax quality gates, suppress findings or treat skill updates as approval.

Revise editable Draw.io masters before PNG exports. Recheck message-to-operation links, explicit mapping, continuous activations, no actor result arrows and routing clearance. Synchronize authorized revisions with the existing specification hierarchy and traceability records. Report unresolved integrations honestly; representational consistency does not prove complete implementation or runtime correctness.
