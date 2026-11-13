/**
 * Design revision 2026-11-02: DeliveryFeePolicy
 * Ownership: FreshFood.Reposistory.Entities
 * + Quote(distanceKm: number): VndAmount
 */
import { VndAmount } from './VndAmount.js';
export class DeliveryFeePolicy {
  Quote(distanceKm) {
    if (typeof distanceKm !== 'number' || !Number.isFinite(distanceKm) || distanceKm < 0) throw new RangeError('INVALID_DISTANCE');
    if (distanceKm > 10) throw Object.assign(new RangeError('OUTSIDE_DELIVERY_AREA'),{code:'OUTSIDE_DELIVERY_AREA',status:422});
    return new VndAmount(distanceKm < 1 ? 10000n : distanceKm < 3 ? 20000n : 30000n);
  }
}
