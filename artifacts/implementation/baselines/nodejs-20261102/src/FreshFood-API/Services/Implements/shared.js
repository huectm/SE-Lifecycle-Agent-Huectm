export class ApiError extends Error {
  constructor(code, status = 400) { super(code); this.code = code; this.status = status; }
}
export function requireValue(ok, code, status = 400) { if (!ok) throw new ApiError(code, status); }
export function checkSignal(signal) { signal?.throwIfAborted(); }
export function id(value) { requireValue(typeof value === 'string' && value.length > 0 && value.length <= 128, 'INVALID_ID'); return value; }
export function quantity(value) { requireValue(Number.isSafeInteger(value) && value > 0, 'INVALID_QUANTITY'); return value; }
export function amount(value) { const s = typeof value?.ToWire === 'function' ? value.ToWire() : value; requireValue(typeof s === 'bigint' || (typeof s === 'string' && /^\d+$/.test(s)), 'INVALID_AMOUNT'); return BigInt(s); }
export function owned(value) { requireValue(value, 'NOT_FOUND', 404); return value; }
export function text(value, code = 'INVALID_TEXT') { requireValue(typeof value === 'string' && value.trim().length > 0, code); return value.trim(); }
export function sellable(batch, now = new Date()) { return ['ACTIVE','DISCOUNTED'].includes(batch.SaleStatus) && batch.ExpiryDate >= now.toISOString().slice(0, 10) && batch.CurrentStock > batch.ReservedStock; }
export function fefo(batches) { return [...batches].sort((a,b) => a.ExpiryDate.localeCompare(b.ExpiryDate) || String(a.BatchId).localeCompare(String(b.BatchId), 'en', {numeric:true})); }
export function orderSummary(o) { return { OrderId:o.OrderId, OrderNumber:o.OrderNumber, OrderDate:new Date(o.OrderDate).toISOString(), Status:o.OrderStatus, Total:amount(o.TotalAmount).toString() }; }
export function addressDto(a) { return Object.fromEntries(['AddressId','RecipientName','RecipientPhone','StreetAddress','Latitude','Longitude','IsDefault'].map(k => [k,a[k]])); }
