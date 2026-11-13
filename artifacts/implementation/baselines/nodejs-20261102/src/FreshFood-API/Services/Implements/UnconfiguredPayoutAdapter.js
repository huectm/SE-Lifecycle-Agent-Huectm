/**
 * Design revision 2026-11-02: UnconfiguredPayoutAdapter
 * Ownership: FreshFood-API.Services.Implements
 * + RequestAsync(refundId: EntityId, signal: AbortSignal): Promise<PayoutOutcomeDto>
 */
export class UnconfiguredPayoutAdapter { async RequestAsync(refundId,signal) {signal?.throwIfAborted();throw Object.assign(new Error('Outgoing payout provider requires approval'),{code:'PAYOUT_PROVIDER_TBD',status:503});} }
