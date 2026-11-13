/**
 * Design revision 2026-11-02: FefoBatchSpecification
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * + Criteria(asOf: Date): BatchCriteria
 */
export class FefoBatchSpecification { Criteria(asOf) { if(!(asOf instanceof Date)||Number.isNaN(+asOf))throw new TypeError('Valid asOf required');return {ActiveProductsOnly:true,AsOf:asOf,MinimumAvailable:1,SortKeys:['expiry_date ASC','batch_id ASC'],LockForUpdate:true}; } }
