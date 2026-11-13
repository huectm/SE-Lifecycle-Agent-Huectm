import fs from 'node:fs';
import { spawnSync } from 'node:child_process';
const output='artifacts/implementation';fs.mkdirSync(output,{recursive:true});
const checks=[];
for(const file of ['src/FreshFood-API/scripts/check-source.js','src/FreshFood-API/scripts/check-design.js']){
 const result=spawnSync(process.execPath,[file],{encoding:'utf8'});checks.push({command:'node '+file,exitCode:result.status,output:result.stdout+result.stderr});if(result.status)console.error(result.stderr);
}
const result=spawnSync(process.execPath,['--test','--experimental-test-coverage','--test-reporter=spec','--test-reporter-destination='+output+'/backend-test-output.txt','--test-reporter=junit','--test-reporter-destination='+output+'/backend-test-results.xml','src/FreshFood-API/tests/backend.test.js'],{encoding:'utf8'});
checks.push({command:'node --test --experimental-test-coverage src/FreshFood-API/tests/backend.test.js',exitCode:result.status,output:result.stdout+result.stderr});
fs.writeFileSync(output+'/backend-check-results.json',JSON.stringify({nodeVersion:process.version,checks,scope:'Local syntax, design mapping and test-double unit/module/HTTP checks; not live PostgreSQL/provider integration'},null,2));
console.log(checks.map(x=>({command:x.command,exitCode:x.exitCode})));process.exitCode=checks.some(x=>x.exitCode!==0)?1:0;
