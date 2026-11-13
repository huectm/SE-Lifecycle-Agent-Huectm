import { Cart } from '../../Entities/Cart.js';
const decode={PENDING_UNPAID:'PendingUnpaid',PENDING_PAID:'PendingPaid',CONFIRMED:'Confirmed',PACKING:'Packing',SHIPPING:'Shipping',DELIVERED:'Delivered',CANCELLED:'Cancelled',DELIVERY_FAILED:'DeliveryFailed',RETURNED:'Returned',UNPAID:'Unpaid',PAID:'Paid',PARTIALLY_REFUNDED:'PartiallyRefunded',REFUNDED:'Refunded',COD:'Cod',VIETQR:'VietQr'};
export function encode(value) {return Object.entries(decode).find(([,v])=>v===value)?.[0]??value;}
export function record(row) {if(!row)return null;return Object.fromEntries(Object.entries(row).map(([k,v])=>{const key=k.replace(/(^|_)([a-z])/g,(_,a,b)=>b.toUpperCase());if(['order_status','payment_status','payment_method'].includes(k))v=decode[v]??v;return [key,k.endsWith('_id')&&v!=null?String(v):['expiry_date','manufacture_date'].includes(k)&&v instanceof Date?v.toISOString().slice(0,10):v];}));}
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
export async function batches(session,ids,signal,locked=false) {if(!ids.length)return [];return rows(session,`SELECT b.* FROM batch_inventory b JOIN products p ON p.product_id=b.product_id WHERE b.product_id=ANY($1::bigint[]) AND p.is_active=TRUE AND b.sale_status IN ('ACTIVE','DISCOUNTED') AND b.expiry_date>=CURRENT_DATE AND b.current_stock>b.reserved_stock ORDER BY b.expiry_date,b.batch_id`+(locked?' FOR UPDATE OF b':''),[ids],signal);}
export async function orders(session,customerId,signal) {
 const result=await rows(session,'SELECT * FROM orders WHERE customer_id=$1 ORDER BY order_date DESC,order_id DESC',[customerId],signal);
 for(const o of result){o.Details=await rows(session,'SELECT d.*,b.product_id,p.product_name FROM order_details d JOIN batch_inventory b ON b.batch_id=d.batch_id JOIN products p ON p.product_id=b.product_id WHERE d.order_id=$1 ORDER BY d.order_detail_id',[o.OrderId],signal);o.DeliveryAddress=await one(session,'SELECT * FROM customer_addresses WHERE address_id=$1 AND customer_id=$2',[o.DeliveryAddressId,customerId],signal);}
 return result;
}
export function gap(code) {throw Object.assign(new Error(code),{code,status:503});}
