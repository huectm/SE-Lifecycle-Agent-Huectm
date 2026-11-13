/**
 * Design revision 2026-11-02: BatchCriteria
 * Ownership: FreshFood.Reposistory.Repository
 * + ActiveProductsOnly: boolean
 * + AsOf: Date
 * + MinimumAvailable: number
 * + SortKeys: ReadonlyArray<string>
 * + LockForUpdate: boolean
 */
/** BatchCriteria — FreshFood.Reposistory.Repository; approved design source: detailed-class-model.json. */
export class BatchCriteria {
  constructor(values = {}) {
    this.ActiveProductsOnly = values.ActiveProductsOnly;
    this.AsOf = values.AsOf;
    this.MinimumAvailable = values.MinimumAvailable;
    this.SortKeys = values.SortKeys;
    this.LockForUpdate = values.LockForUpdate;
  }
}
