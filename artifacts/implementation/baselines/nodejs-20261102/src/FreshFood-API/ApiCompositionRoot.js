/**
 * Design revision 2026-11-02: ApiCompositionRoot
 * Ownership: FreshFood-API
 * + ConfigureServices(services: RegistrationMap): void
 */
import {classes} from './class-catalog.js';
import {bindings,constructors} from './bindings.js';
export class ApiCompositionRoot {
  ConfigureServices(services){
    const construct=name=>new classes[name](...(constructors[name]??[]).map(type=>services.Resolve(type)));
    for(const row of bindings)services.Bind(row.Contract,()=>construct(row.Implementation));
    for(const name of ['CatalogController','CartController','ProfileController','CheckoutController','MyOrdersController','PaymentNoticeHandler'])services.Bind(name,()=>construct(name));
  }
}
