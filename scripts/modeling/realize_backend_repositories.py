raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
﻿from pathlib import Path
import json,re,os
P=json.loads(Path('scratch/backend-mapping-paths.json').read_text())
m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
base=Path('src/FreshFood.Reposistory/Repository/Implements')
(base/'sql.js').write_text('''import { Cart } from '../../Entities/Cart.js';
export function record(row) {if(!row)return null;return Object.fromEntries(Object.entries(row).map(([k,v])=>{const key=k.replace(/(^|_)([a-z])/g,(_,a,b)=>b.toUpperCase());return [key,k.endsWith('_id')&&v!=null?String(v):k.endsWith('_date')&&v instanceof Date?v.toISOString().slice(0,10):v];}));}
export async function rows(session,sql,args=[],signal) {const result=await session.connection.QueryAsync(sql,args,signal);return (Array.isArray(result)?result:result.rows??[]).map(record);}
export async function one(session,sql,args=[],signal) {return (await rows(session,sql,args,signal))[0]??null;}
export function lock(session) {return session.active?' FOR UPDATE':'';}
export async function cart(session,customerId,sessionId,signal) {
 let c=await one(session,'SELECT * FROM carts WHERE ($1::bigint IS NOT NULL AND customer_id=$1) OR ($1::bigint IS NULL AND customer_id IS NULL AND session_id=$2)'+lock(session),[customerId,sessionId],signal);
 if(!c)c=await one(session,'INSERT INTO carts(customer_id,session_id) VALUES($1,$2) RETURNING *',[customerId,customerId?null:sessionId],signal);
 c.Items=await rows(session,'SELECT * FROM cart_items WHERE cart_id=$1 ORDER BY cart_item_id',[c.CartId],signal);return new Cart(c);
}
export async function saveCart(session,c,signal) {
 if(!session.active)throw new Error('Cart writes require active transaction');
 await rows(session,'DELETE FROM cart_items WHERE cart_id=$1',[c.CartId],signal);
 for(const i of c.Items)await rows(session,'INSERT INTO cart_items(cart_id,product_id,quantity) VALUES($1,$2,$3)',[c.CartId,i.ProductId,i.Quantity],signal);
}
export async function batches(session,ids,signal,locked=false) {if(!ids.length)return [];return rows(session,'SELECT b.* FROM batch_inventory b JOIN products p ON p.product_id=b.product_id WHERE b.product_id=ANY($1::bigint[]) AND p.is_active=TRUE AND b.sale_status=$2 AND b.expiry_date>=CURRENT_DATE AND b.current_stock>b.reserved_stock ORDER BY b.expiry_date,b.batch_id'+(locked?' FOR UPDATE OF b':''),[ids,'Available'],signal);}
export async function orders(session,customerId,signal) {
 const result=await rows(session,'SELECT * FROM orders WHERE customer_id=$1 ORDER BY order_date DESC,order_id DESC',[customerId],signal);
 for(const o of result){o.Details=await rows(session,'SELECT d.*,b.product_id,p.product_name FROM order_details d JOIN batch_inventory b ON b.batch_id=d.batch_id JOIN products p ON p.product_id=b.product_id WHERE d.order_id=$1 ORDER BY d.order_detail_id',[o.OrderId],signal);o.DeliveryAddress=await one(session,'SELECT * FROM customer_addresses WHERE address_id=$1 AND customer_id=$2',[o.DeliveryAddressId,customerId],signal);}
 return result;
}
export function gap(code) {throw Object.assign(new Error(code),{code,status:503});}
''',encoding='utf-8')
ops={
'CatalogRepository':{
'FindActiveAsync':"return rows(this.session,`SELECT p.* FROM products p WHERE p.is_active=TRUE AND ($1::text IS NULL OR p.product_name ILIKE '%' || $1 || '%') AND ($2::bigint IS NULL OR p.category_id=$2) AND ($3=FALSE OR EXISTS(SELECT 1 FROM batch_inventory b WHERE b.product_id=p.product_id AND b.discount_rate>0 AND b.sale_status='Available' AND b.expiry_date>=CURRENT_DATE AND b.current_stock>b.reserved_stock)) ORDER BY p.product_id`,[keyword,categoryId,clearanceOnly],signal);",
'GetCategoriesAsync':"return rows(this.session,'SELECT * FROM product_categories WHERE is_active=TRUE ORDER BY category_id',[],signal);",
'GetProductAsync':"return one(this.session,'SELECT * FROM products WHERE product_id=$1',[productId],signal);",
'GetSellableBatchesAsync':"return batches(this.session,productIds,signal);",
'GetPopularAsync':"return rows(this.session,'SELECT p.* FROM products p LEFT JOIN batch_inventory b ON b.product_id=p.product_id LEFT JOIN order_details d ON d.batch_id=b.batch_id WHERE p.is_active=TRUE GROUP BY p.product_id ORDER BY COALESCE(SUM(d.quantity),0) DESC,p.product_id LIMIT $1',[limit],signal);"},
'CartRepository':{
'GetAsync':"return cart(this.session,customerId,sessionId,signal);",
'GetProductsAsync':"return rows(this.session,'SELECT * FROM products WHERE product_id=ANY($1::bigint[])',[ids],signal);",
'GetSellableBatchesAsync':"return batches(this.session,ids,signal);",
'SaveAsync':"return saveCart(this.session,cart,signal);"},
'ProfileRepository':{
'GetCustomerAsync':"return one(this.session,'SELECT * FROM customers WHERE customer_id=$1'+lock(this.session),[customerId],signal);",
'GetAddressesAsync':"return rows(this.session,'SELECT * FROM customer_addresses WHERE customer_id=$1 ORDER BY address_id'+lock(this.session),[customerId],signal);",
'HasActiveOrderAsync':"return (await rows(this.session,\"SELECT order_id FROM orders WHERE customer_id=$1 AND delivery_address_id=$2 AND order_status NOT IN ('Delivered','Cancelled','Returned') LIMIT 1\",[customerId,addressId],signal)).length>0;",
'SaveCustomerAsync':"await rows(this.session,'UPDATE customers SET full_name=$1,email=$2 WHERE customer_id=$3',[customer.FullName,customer.Email,customer.CustomerId],signal);",
'SaveAddressAsync':"""if(!this.session.active)throw new Error('Address writes require transaction');
await rows(this.session,'SELECT customer_id FROM customers WHERE customer_id=$1 FOR UPDATE',[address.CustomerId],signal);
if(address.IsDefault)await rows(this.session,'UPDATE customer_addresses SET is_default=FALSE WHERE customer_id=$1',[address.CustomerId],signal);
const values=[address.CustomerId,address.RecipientName,address.RecipientPhone,address.StreetAddress,address.Latitude,address.Longitude,address.IsDefault];
const result=address.AddressId?await one(this.session,'UPDATE customer_addresses SET recipient_name=$2,recipient_phone=$3,street_address=$4,latitude=$5,longitude=$6,is_default=$7 WHERE customer_id=$1 AND address_id=$8 RETURNING *',[...values,address.AddressId],signal):await one(this.session,'INSERT INTO customer_addresses(customer_id,recipient_name,recipient_phone,street_address,latitude,longitude,is_default) VALUES($1,$2,$3,$4,$5,$6,$7) RETURNING *',values,signal);
if(!result)throw Object.assign(new Error('Address not owned'),{code:'NOT_FOUND',status:404});Object.assign(address,result);""",
'DeleteAddressAsync':"await rows(this.session,'DELETE FROM customer_addresses WHERE customer_id=$1 AND address_id=$2',[customerId,addressId],signal);"},
'CheckoutRepository':{
'GetCheckoutCartAsync':"return cart(this.session,customerId,null,signal);",
'GetOwnedAddressAsync':"return one(this.session,'SELECT * FROM customer_addresses WHERE customer_id=$1 AND address_id=$2',[customerId,addressId],signal);",
'LockFefoBatchesAsync':"return batches(this.session,productIds,signal,true);",
'ClearCartAsync':"await rows(this.session,'DELETE FROM cart_items WHERE cart_id=$1',[cartId],signal);",
'SavePaymentOnceAsync':"gap('PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED');",
'SaveOrderAsync':"""if(!this.session.active)throw new Error('Order persistence requires transaction');
await rows(this.session,'SELECT customer_id FROM customers WHERE customer_id=$1 FOR UPDATE',[order.CustomerId],signal);
const prior=await rows(this.session,'SELECT order_id FROM orders WHERE customer_id=$1 LIMIT 1',[order.CustomerId],signal);order.IsFirstOrder=prior.length===0;order.PhoneConfirmationStatus=order.IsFirstOrder&&order.PaymentStatus==='Unpaid'?'Pending':'NotRequired';
for(const l of order.Details){const updated=await rows(this.session,'UPDATE batch_inventory SET reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock >= $1 RETURNING batch_id',[l.Quantity,l.BatchId],signal);if(!updated.length)throw Object.assign(new Error('Stock changed'),{code:'INSUFFICIENT_STOCK',status:409});}
const saved=await one(this.session,'INSERT INTO orders(order_number,customer_id,delivery_address_id,order_date,sub_total,delivery_distance,shipping_fee,total_amount,payment_method,payment_status,order_status,is_first_order,phone_confirmation_status) VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13) RETURNING order_id',[order.OrderNumber,order.CustomerId,order.DeliveryAddressId,order.OrderDate,order.SubTotal,order.DeliveryDistance,order.ShippingFee,order.TotalAmount,order.PaymentMethod,order.PaymentStatus,order.OrderStatus,order.IsFirstOrder,order.PhoneConfirmationStatus],signal);order.OrderId=saved.OrderId;
for(const l of order.Details)await rows(this.session,'INSERT INTO order_details(order_id,batch_id,quantity,unit_price,discount_amount,line_total) VALUES($1,$2,$3,$4,$5,$6)',[order.OrderId,l.BatchId,l.Quantity,l.UnitPrice,l.DiscountAmount,l.LineTotal],signal);"""},
'MyOrdersRepository':{
'FindOwnedAsync':"return orders(this.session,customerId,signal);",
'LockOwnedAsync':"const owned=await one(this.session,'SELECT order_id FROM orders WHERE customer_id=$1 AND order_id=$2 FOR UPDATE',[customerId,orderId],signal);if(!owned)return null;return (await orders(this.session,customerId,signal)).find(o=>o.OrderId===orderId);",
'GetCurrentBatchesAsync':"return batches(this.session,productIds,signal);",
'SaveCartAsync':"const current=await loadCart(this.session,cart.CustomerId,null,signal);for(const i of cart.Items)current.ChangeQuantity(i.ProductId,i.Quantity);return saveCart(this.session,current,signal);",
'SaveReviewOnceAsync':"return (await rows(this.session,'INSERT INTO order_reviews(order_id,customer_id,rating,comment) VALUES($1,$2,$3,$4) ON CONFLICT (order_id) DO NOTHING RETURNING review_id',[review.OrderId,review.CustomerId,review.Rating,review.Comment??null],signal)).length>0;",
'GetReturnReceiptAsync':"return one(this.session,'SELECT * FROM return_receipts WHERE order_id=$1',[orderId],signal);",
'GetRefundAsync':"return one(this.session,'SELECT * FROM refunds WHERE order_id=$1 ORDER BY refund_id DESC LIMIT 1',[orderId],signal);"},
'OrderLifecycleRepository':{
'LockOrderAsync':"return one(this.session,'SELECT * FROM orders WHERE order_id=$1 FOR UPDATE',[orderId],signal);",
'LoadLifecycleAsync':"gap('TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD');",
'SaveAsync':"await rows(this.session,'UPDATE orders SET order_status=$1,payment_status=$2,cancellation_reason=$3 WHERE order_id=$4',[order.OrderStatus,order.PaymentStatus,order.CancellationReason??null,order.OrderId],signal);",
'RecordEventOnceAsync':"gap('DURABLE_TRANSITION_EVENT_STORAGE_TBD');",
'SaveOrderLinesAsync':"gap('SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW');",
'SavePaymentOnceAsync':"gap('PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED');",
'SaveFailureAsync':"gap('STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT');",
'SaveReceiptAsync':"gap('STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT');",
'SaveRefundOnceAsync':"gap('REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED');",
'SaveShippingSettlementAsync':"gap('SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT');",
'LockReservedBatchesAsync':"return rows(this.session,'SELECT DISTINCT b.* FROM batch_inventory b JOIN order_details d ON d.batch_id=b.batch_id WHERE d.order_id=$1 ORDER BY b.batch_id',[orderId],signal).then(async bs=>{for(const b of bs)Object.assign(b,await one(this.session,'SELECT * FROM batch_inventory WHERE batch_id=$1 FOR UPDATE',[b.BatchId],signal));return bs;});",
'SaveBatchesAsync':"for(const b of batches)await rows(this.session,'UPDATE batch_inventory SET reserved_stock=$1 WHERE batch_id=$2',[b.ReservedStock,b.BatchId],signal);",
'AppendAuditAsync':"gap('CUSTOMER_AUDIT_SCHEMA_TBD');"}}
for n,methods in ops.items():
 c=m['classes'][n];ctor=next(o for o in c['operations'] if o.startswith('+ '+n+'('));params=', '.join(x.split(':')[0].strip() for x in re.search(r'\((.*?)\)',ctor)[1].split(',') if x.strip())
 s="import { rows, one, lock, cart as loadCart, saveCart, batches as loadBatches, orders, gap } from './sql.js';\n"
 s+=f'export class {n} {{\n  constructor({params}) {{this.session=session;}}\n'
 for op in c['operations']:
  match=re.match(r'\+ (\w+)\((.*?)\)',op)
  if not match or match[1]==n:continue
  method=match[1];args=', '.join(x.split(':')[0].strip() for x in match[2].split(',') if x.strip());body=methods[method]
  body=body.replace('return cart(', 'return loadCart(').replace('return batches(', 'return loadBatches(')
  s+=f'  async {method}({args}) {{ {body} }}\n'
 s+='}\n';Path(P[n]).write_text(s,encoding='utf-8')
print('Implemented parameterized SQL for six repository classes; schema-dependent gaps are explicit')
