/**
 * Design revision 2026-11-02: CatalogRepository
 * Ownership: FreshFood.Reposistory.Repository.Implements
 * - session: IRepositorySession
 * + CatalogRepository(session: IRepositorySession)
 * + FindActiveAsync(keyword: string?, categoryId: number?, clearanceOnly: boolean, signal: AbortSignal): Promise<ReadonlyArray<Product>>
 * + GetCategoriesAsync(signal: AbortSignal): Promise<ReadonlyArray<ProductCategory>>
 * + GetProductAsync(productId: EntityId, signal: AbortSignal): Promise<Product?>
 * + GetSellableBatchesAsync(productIds: ReadonlyArray<EntityId>, signal: AbortSignal): Promise<ReadonlyArray<BatchInventory>>
 * + GetPopularAsync(limit: number, signal: AbortSignal): Promise<ReadonlyArray<Product>>
 */
import { encode, rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';
export class CatalogRepository {
  constructor(session) {this.session=session;}
  async FindActiveAsync(keyword, categoryId, clearanceOnly, signal) { return rows(this.session,`SELECT p.* FROM products p WHERE p.is_active=TRUE AND ($1::text IS NULL OR p.product_name ILIKE '%' || $1 || '%') AND ($2::bigint IS NULL OR p.category_id=$2) AND ($3=FALSE OR EXISTS(SELECT 1 FROM batch_inventory b WHERE b.product_id=p.product_id AND b.discount_rate>0 AND b.sale_status IN ('ACTIVE','DISCOUNTED') AND b.expiry_date>=CURRENT_DATE AND b.current_stock>b.reserved_stock)) ORDER BY p.product_id`,[keyword,categoryId,clearanceOnly],signal); }
  async GetCategoriesAsync(signal) { return rows(this.session,'SELECT * FROM product_categories WHERE is_active=TRUE ORDER BY category_id',[],signal); }
  async GetProductAsync(productId, signal) { return one(this.session,'SELECT * FROM products WHERE product_id=$1',[productId],signal); }
  async GetSellableBatchesAsync(productIds, signal) { return loadBatches(this.session,productIds,signal); }
  async GetPopularAsync(limit, signal) { return rows(this.session,'SELECT p.* FROM products p LEFT JOIN batch_inventory b ON b.product_id=p.product_id LEFT JOIN order_details d ON d.batch_id=b.batch_id WHERE p.is_active=TRUE GROUP BY p.product_id ORDER BY COALESCE(SUM(d.quantity),0) DESC,p.product_id LIMIT $1',[limit],signal); }
}
