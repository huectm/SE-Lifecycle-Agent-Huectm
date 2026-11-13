import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const base='artifacts/testing/unit-execution';
const history=JSON.parse(await fs.readFile(base+'/failure-history.json','utf8'));
let fixes={};try{fixes=JSON.parse(await fs.readFile(base+'/fix-verification.json','utf8'));}catch{}
const w=await SpreadsheetFile.importXlsx(await FileBlob.load('scratch/unit-test-template/Template_Defect_log.xlsx'));
const s=w.worksheets.getItem('Defects');s.getRange('A4:H8').clear({applyTo:'contents'});
const backend=history.filter(r=>r.classification==='Backend');
const unique=[...new Map(history.filter(r=>r.classification!=='Backend').map(r=>[r.defectId,r])).values()];
const records=[...unique.map(r=>({...r,module:'Unit test fixtures',type:'Test Script',severity:'Medium',priority:'Normal'})),...(backend.length?[{...backend[0],module:'OrderStateMachine / payment region',type:'Logic',severity:'High',priority:'High'}]:[])];
for(let i=0;i<records.length;i++){
 const r=records[i],row=i+4;s.getRange('A4:H4').copyTo(s.getRange('A'+row+':H'+row), 'all');
 const desc=[r.caseId,'Owner: Developer / QA','Steps: run the mapped xUnit case using the retained TRX run.',r.classification==='Backend'?'Input: initial acceptOrder with internally verified payment, positive stock and owned order. Expected: PendingPaid/Paid; actual: STATE_EVENT_NOT_IMPLEMENTED at deferred payment row P02. Correction: implement trusted initial capture and include P02 in transition evidence; external verification remains separately configured.':'Fixture problem: '+r.message,'Evidence: '+r.evidence,'Retest: '+(fixes.status||'Pending')].join('\n');
 s.getRange('A'+row+':H'+row).values=[[r.defectId,r.module,desc,r.type,r.severity,r.priority,fixes.status==='Verified'?'Verified':'New','2026-11-05']];
 s.getRange('C'+row).format.wrapText=true;s.getRange('A'+row+':H'+row).format.rowHeight=155;
}
await(await SpreadsheetFile.exportXlsx(w)).save(base+'/FreshFood_Unit_Defect_Log.xlsx');
console.log('Logged',records.length,'defect/fixture records using the eight-column template.');
