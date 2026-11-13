/**
 * Design revision 2026-11-02: RegistrationMap
 * Ownership: FreshFood-API
 * + Bind(token: string, factory: () => object): void
 * + BindMany(token: string, factories: ReadonlyArray<() => object>): void
 */
export class RegistrationMap {
  constructor(){this.bindings=new Map();this.many=new Map();this.cache=new Map();this.resolving=new Set();}
  Bind(token,factory){if(this.bindings.has(token))throw new Error('Duplicate binding: '+token);this.bindings.set(token,factory);}
  BindMany(token,factories){if(this.many.has(token))throw new Error('Duplicate collection: '+token);this.many.set(token,factories);}
  Resolve(token){if(this.cache.has(token))return this.cache.get(token);const f=this.bindings.get(token);if(!f)throw new Error('Missing binding: '+token);if(this.resolving.has(token))throw new Error('Circular binding: '+token);this.resolving.add(token);try{const value=f();this.cache.set(token,value);return value;}finally{this.resolving.delete(token);}}
  ResolveMany(token){return (this.many.get(token)??[]).map(f=>f());}
}
