/**
 * Design revision 2026-11-02: BatchPricingPolicy
 * Ownership: FreshFood.Reposistory.Entities
 * + Quote(batch: BatchInventory, asOf: Date): VndAmount
 */
import { VndAmount } from './VndAmount.js';
export class BatchPricingPolicy {
  Quote(batch, asOf) {
    if (!asOf || batch.ExpiryDate < asOf.toISOString().slice(0,10)) throw new RangeError('BATCH_EXPIRED');
    const raw = String(batch.DiscountRate ?? 0);
    if (!/^\d+(\.\d{1,2})?$/.test(raw)) throw new RangeError('INVALID_DISCOUNT');
    const [a,b=''] = raw.split('.'); const rate = BigInt(a)*100n + BigInt(b.padEnd(2,'0'));
    if (rate !== 0n && (rate < 1000n || rate > 5000n)) throw new RangeError('CLEARANCE_RATE_OUT_OF_RANGE');
    const retail = BigInt(typeof batch.RetailPrice?.ToWire === 'function' ? batch.RetailPrice.ToWire() : batch.RetailPrice); if (retail < 0n) throw new RangeError('INVALID_PRICE');
    const numerator = retail * (10000n-rate);
    if (numerator % 10000n) throw Object.assign(new Error('Fractional VND rounding policy requires confirmation'), {code:'ROUNDING_POLICY_TBD',status:503});
    return new VndAmount(numerator/10000n);
  }
}
