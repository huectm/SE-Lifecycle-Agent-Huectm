const values=new WeakMap();
export function initializeEntity(entity,input,names){values.set(entity,{...input});for(const name of names)Object.defineProperty(entity,name,{enumerable:true,get(){const v=values.get(this)[name];return Array.isArray(v)?Object.freeze([...v]):v;}});}
export function patchEntity(entity,patch){const state=values.get(entity);if(!state)throw new TypeError('Expected entity');Object.assign(state,patch);}
