import { readdirSync } from 'node:fs';
import { resolve } from 'node:path';
import { spawnSync } from 'node:child_process';
const roots=[resolve(import.meta.dirname,'..'),resolve(import.meta.dirname,'../../FreshFood.Reposistory')];let checked=0;
function visit(dir){for(const e of readdirSync(dir,{withFileTypes:true})){if(e.name==='node_modules')continue;const p=resolve(dir,e.name);if(e.isDirectory())visit(p);else if(e.name.endsWith('.js')){const result=spawnSync(process.execPath,['--check',p],{encoding:'utf8'});if(result.status)throw new Error(result.stderr);checked++;}}}
roots.forEach(visit);await import('../class-catalog.js');console.log('Syntax/import checks passed:',checked,'JavaScript files');
