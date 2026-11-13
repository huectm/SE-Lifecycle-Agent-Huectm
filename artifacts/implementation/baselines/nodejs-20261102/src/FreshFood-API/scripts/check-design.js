import { readFileSync, existsSync } from 'node:fs';
import { pathToFileURL } from 'node:url';
import { resolve } from 'node:path';
const workspaceRoot=resolve(import.meta.dirname,'../../..');
const contracts=JSON.parse(readFileSync(new URL('../design-contracts.json',import.meta.url)));let operations=0;
for(const [name,c] of Object.entries(contracts)) {if(!existsSync(resolve(workspaceRoot,c.file)))throw new Error('Missing source '+name);const module=await import(pathToFileURL(resolve(workspaceRoot,c.file)));const classifier=module[name];if(!classifier)throw new Error('Missing export '+name);for(const operation of c.operations){if(typeof classifier.prototype?.[operation]!=='function' && typeof classifier[operation]!=='function')throw new Error(name+'.'+operation+' missing');operations++;}}
console.log('Design mapping verified:',Object.keys(contracts).length,'backend classifiers,',operations,'modeled operations; frontend excluded');
