raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')
﻿from pathlib import Path
p=Path('src/FreshFood-API/class-catalog.js');s=p.read_text();s='\n'.join(x for x in s.splitlines() if not x.startswith('import { ApiCompositionRoot }'));s=s.replace(', ApiCompositionRoot,',',').replace('{ApiCompositionRoot,','{');p.write_text(s+'\n')
p=Path('src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.js');s=p.read_text().replace('this.session=session;','this.session=session;this.fefo=fefo;').replace('return loadBatches(this.session,productIds,signal,true);','this.fefo.Criteria(new Date());return loadBatches(this.session,productIds,signal,true);');p.write_text(s)
api=Path('src/FreshFood-API')
(api/'http.js').write_text('''import { createServer as nodeServer } from 'node:http';
import { ApiError, requireValue } from './Services/Implements/shared.js';
const routes=[
 ['GET',/^\\/api\\/catalog$/,'CatalogController','GetCatalogAsync','query'],
 ['GET',/^\\/api\\/catalog\\/search$/,'CatalogController','SearchAsync','query'],
 ['GET',/^\\/api\\/catalog\\/clearance$/,'CatalogController','GetClearanceAsync','query'],
 ['GET',/^\\/api\\/products\\/([^/]+)$/,'CatalogController','GetProductDetailsAsync','id'],
 ['GET',/^\\/api\\/cart$/,'CartController','GetCartAsync','identity'],
 ['PUT',/^\\/api\\/cart\\/items\\/([^/]+)$/,'CartController','ChangeQuantityAsync','item'],
 ['DELETE',/^\\/api\\/cart\\/items\\/([^/]+)$/,'CartController','RemoveItemAsync','id'],
 ['GET',/^\\/api\\/profile$/,'ProfileController','GetProfileAsync','none'],
 ['PATCH',/^\\/api\\/profile$/,'ProfileController','UpdateProfileAsync','body'],
 ['POST',/^\\/api\\/addresses$/,'ProfileController','SaveAddressAsync','body'],
 ['PUT',/^\\/api\\/addresses\\/([^/]+)$/,'ProfileController','SaveAddressAsync','address'],
 ['PUT',/^\\/api\\/addresses\\/([^/]+)\\/default$/,'ProfileController','SetDefaultAddressAsync','id'],
 ['DELETE',/^\\/api\\/addresses\\/([^/]+)$/,'ProfileController','DeleteAddressAsync','id'],
 ['GET',/^\\/api\\/checkout$/,'CheckoutController','PrepareCheckoutAsync','query'],
 ['POST',/^\\/api\\/orders$/,'CheckoutController','PlaceOrderAsync','body'],
 ['POST',/^\\/api\\/checkout\\/payment-qr$/,'CheckoutController','CreatePaymentQrAsync','body'],
 ['GET',/^\\/api\\/orders$/,'MyOrdersController','GetOrdersAsync','none'],
 ['GET',/^\\/api\\/orders\\/([^/]+)$/,'MyOrdersController','GetOrderDetailsAsync','id'],
 ['POST',/^\\/api\\/orders\\/([^/]+)\\/cancel$/,'MyOrdersController','CancelOrderAsync','order'],
 ['POST',/^\\/api\\/orders\\/([^/]+)\\/reorder$/,'MyOrdersController','ReorderAsync','id'],
 ['POST',/^\\/api\\/orders\\/([^/]+)\\/review$/,'MyOrdersController','SubmitReviewAsync','order'],
 ['POST',/^\\/api\\/payments\\/sepay\\/webhook$/,'PaymentNoticeHandler','HandleAsync','notice']
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
  finally{await scope?.DisposeAsync?.();}
 });
}
''',encoding='utf-8')
(api/'server.js').write_text('''import { createApiServer } from './http.js';
// Trusted local runtime module owns authentication, connection pooling and provider credentials.
const file=process.env.FRESHFOOD_RUNTIME_MODULE;
if(!file)throw new Error('Set FRESHFOOD_RUNTIME_MODULE to the trusted runtime module described in README.md');
const runtime=await import(file);const server=createApiServer(runtime);server.listen(Number(process.env.PORT??3000),process.env.HOST??'127.0.0.1');
''',encoding='utf-8')
(api/'composition.js').write_text('''import { RegistrationMap } from './RegistrationMap.js';
import { ApiCompositionRoot } from './ApiCompositionRoot.js';
export function createRequestScope({connection,principal,transport}) {
 const scope=new RegistrationMap();scope.Bind('DatabaseConnection',()=>connection);scope.Bind('AuthenticatedPrincipal',()=>principal);scope.Bind('HttpTransport',()=>transport);
 new ApiCompositionRoot().ConfigureServices(scope);return scope;
}
''',encoding='utf-8')
(api/'scripts').mkdir(exist_ok=True)
(api/'scripts'/'check-source.js').write_text('''import { readdirSync } from 'node:fs';
import { resolve } from 'node:path';
import { spawnSync } from 'node:child_process';
const roots=[resolve(import.meta.dirname,'..'),resolve(import.meta.dirname,'../../FreshFood.Reposistory')];let checked=0;
function visit(dir){for(const e of readdirSync(dir,{withFileTypes:true})){if(e.name==='node_modules')continue;const p=resolve(dir,e.name);if(e.isDirectory())visit(p);else if(e.name.endsWith('.js')){const result=spawnSync(process.execPath,['--check',p],{encoding:'utf8'});if(result.status)throw new Error(result.stderr);checked++;}}}
roots.forEach(visit);await import('../class-catalog.js');console.log('Syntax/import checks passed:',checked,'JavaScript files');
''',encoding='utf-8')
print('Created native HTTP adapter, route catalog and per-request DI composition')
