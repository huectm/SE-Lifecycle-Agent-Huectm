import { createServer as nodeServer } from 'node:http';
import { ApiError, requireValue } from './Services/Implements/shared.js';
const routes=[
 ['GET',/^\/api\/catalog$/,'CatalogController','GetCatalogAsync','query'],
 ['GET',/^\/api\/catalog\/search$/,'CatalogController','SearchAsync','query'],
 ['GET',/^\/api\/catalog\/clearance$/,'CatalogController','GetClearanceAsync','query'],
 ['GET',/^\/api\/products\/([^/]+)$/,'CatalogController','GetProductDetailsAsync','id'],
 ['GET',/^\/api\/cart$/,'CartController','GetCartAsync','identity'],
 ['PUT',/^\/api\/cart\/items\/([^/]+)$/,'CartController','ChangeQuantityAsync','item'],
 ['DELETE',/^\/api\/cart\/items\/([^/]+)$/,'CartController','RemoveItemAsync','id'],
 ['GET',/^\/api\/profile$/,'ProfileController','GetProfileAsync','none'],
 ['PATCH',/^\/api\/profile$/,'ProfileController','UpdateProfileAsync','body'],
 ['POST',/^\/api\/addresses$/,'ProfileController','SaveAddressAsync','body'],
 ['PUT',/^\/api\/addresses\/([^/]+)$/,'ProfileController','SaveAddressAsync','address'],
 ['PUT',/^\/api\/addresses\/([^/]+)\/default$/,'ProfileController','SetDefaultAddressAsync','id'],
 ['DELETE',/^\/api\/addresses\/([^/]+)$/,'ProfileController','DeleteAddressAsync','id'],
 ['GET',/^\/api\/checkout$/,'CheckoutController','PrepareCheckoutAsync','query'],
 ['POST',/^\/api\/orders$/,'CheckoutController','PlaceOrderAsync','body'],
 ['POST',/^\/api\/checkout\/payment-qr$/,'CheckoutController','CreatePaymentQrAsync','body'],
 ['GET',/^\/api\/orders$/,'MyOrdersController','GetOrdersAsync','none'],
 ['GET',/^\/api\/orders\/([^/]+)$/,'MyOrdersController','GetOrderDetailsAsync','id'],
 ['POST',/^\/api\/orders\/([^/]+)\/cancel$/,'MyOrdersController','CancelOrderAsync','order'],
 ['POST',/^\/api\/orders\/([^/]+)\/reorder$/,'MyOrdersController','ReorderAsync','id'],
 ['POST',/^\/api\/orders\/([^/]+)\/review$/,'MyOrdersController','SubmitReviewAsync','order'],
 ['POST',/^\/api\/payments\/sepay\/webhook$/,'PaymentNoticeHandler','HandleAsync','notice']
];
export const routeCatalog=routes.map(([method,pattern,controller,operation])=>({method,pattern:pattern.source,controller,operation}));
async function body(req){let bytes=0;const parts=[];for await(const part of req){bytes+=part.length;if(bytes>65536)throw new ApiError('BODY_TOO_LARGE',413);parts.push(part);}return Buffer.concat(parts).toString('utf8');}
function json(res,status,value){res.writeHead(status,{'Content-Type':'application/json; charset=utf-8','Cache-Control':'no-store','X-Content-Type-Options':'nosniff'});res.end(JSON.stringify(value,(_,v)=>typeof v==='bigint'?v.toString():v));}
export function createApiServer({scopeFactory,authenticate=async()=>({}),logger=()=>{}}){
 return nodeServer(async(req,res)=>{const cancel=new AbortController();req.on('aborted',()=>cancel.abort());let scope;
  try {const url=new URL(req.url,'http://localhost');if(req.method==='GET'&&url.pathname==='/health')return json(res,200,{Status:'ok'});
   const route=routes.find(r=>r[0]===req.method&&r[1].test(url.pathname));if(!route)throw new ApiError('NOT_FOUND',404);
   const [,pattern,controller,operation,kind]=route;const match=url.pathname.match(pattern);const raw=['POST','PUT','PATCH'].includes(req.method)?await body(req):'';
   let payload={};if(raw&&kind!=='notice'){try{payload=JSON.parse(raw);}catch{throw new ApiError('INVALID_JSON');}requireValue(payload&&typeof payload==='object'&&!Array.isArray(payload),'INVALID_JSON_OBJECT');}
   const principal=await authenticate(req,cancel.signal);scope=await scopeFactory(principal,cancel.signal);const target=scope.Resolve(controller);const query=Object.fromEntries(url.searchParams);query.ClearanceOnly=query.ClearanceOnly==='true';
   let arg;if(kind==='query')arg=query;else if(kind==='body')arg=payload;else if(kind==='id')arg=decodeURIComponent(match[1]);else if(kind==='identity')arg=undefined;else if(kind==='item')arg={ProductId:decodeURIComponent(match[1]),Quantity:payload.Quantity};else if(kind==='address')arg={...payload,AddressId:decodeURIComponent(match[1])};else if(kind==='order')arg={...payload,OrderId:decodeURIComponent(match[1])};else if(kind==='notice')arg={RawBody:raw,Signature:String(req.headers['authorization']??''),ProviderReference:String(req.headers['x-provider-reference']??'')};
   const result=kind==='none'?await target[operation](cancel.signal):await target[operation](arg,cancel.signal);json(res,200,result);
  }catch(error){const status=Number.isInteger(error.status)?error.status:500;logger({code:error.code??'INTERNAL_ERROR',status});if(!res.headersSent)json(res,status,{Code:error.code??'INTERNAL_ERROR'});}
  finally{try{await scope?.DisposeAsync?.();}catch{logger({code:'REQUEST_SCOPE_DISPOSAL_FAILED',status:500});}}
 });
}
