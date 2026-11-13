/**
 * Design revision 2026-11-02: IBatchPricingPolicy
 * Ownership: FreshFood.Reposistory.Entities
 * + Quote(batch: BatchInventory, asOf: Date): VndAmount
 */
/** IBatchPricingPolicy — FreshFood.Reposistory.Entities; approved design source: detailed-class-model.json. */
export class IBatchPricingPolicy {
  Quote(batch, asOf) { throw Object.assign(new Error("IBatchPricingPolicy.Quote: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
