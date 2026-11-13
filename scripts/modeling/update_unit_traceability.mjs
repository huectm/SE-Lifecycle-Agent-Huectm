import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const path='artifacts/traceability/Requirements_Traceability_Matrix.xlsx';
const design=JSON.parse(await fs.readFile('artifacts/testing/test-design/backend-unit/backend-unit-test-design.json','utf8'));
const results=JSON.parse(await fs.readFile('artifacts/testing/unit-execution/execution-results.json','utf8'));
const w=await SpreadsheetFile.importXlsx(await FileBlob.load(path));const s=w.worksheets.getItem('RTM');
const data=s.getRange('A1:G300').values;let row=data.reduce((n,r,i)=>r.some(v=>v!==null&&v!=='')?i+1:n,0)+1;
for(const uc of ['UC-C01','UC-C03','UC-C05','UC-C06','UC-C07']){
 const source=[...data].reverse().find(r=>r[3]===uc&&String(r[5]||'').startsWith('src/FreshFood-API/Services/'));
 if(!source)throw Error('Missing approved RTM basis '+uc);
 const tag='DCD-'+uc+'; Unit execution 2026-11-05';const existing=data.findIndex(r=>r[4]===tag);const target=existing>=0?existing+1:row++;
 const cases=design.methods.filter(m=>m.useCases.includes(uc)).flatMap(m=>m.cases.map(c=>results.cases[c.id]));const passed=cases.filter(r=>r.outcome==='Passed').length;
 s.getRange('A4:G4').copyTo(s.getRange('A'+target+':G'+target),'all');
 s.getRange('A'+target+':G'+target).values=[[...source.slice(0,4),tag,source[5],'Method-level support: '+passed+' passed; '+(cases.length-passed)+' skipped. IDs/scripts/results: artifacts/testing/test-design/backend-unit/script-case-mapping.json and artifacts/testing/unit-execution/execution-results.json. Coverage gate not met; no FR acceptance claim.']];
 s.getRange('A'+target+':G'+target).format.wrapText=true;s.getRange('A'+target+':G'+target).format.rowHeight=115;
}
w.recalculate();await(await SpreadsheetFile.exportXlsx(w)).save(path);console.log('Updated five use-case RTM support links; schema retained.');
