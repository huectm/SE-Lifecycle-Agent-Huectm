import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const base='artifacts/testing/test-design/backend-unit';
const path=base+'/FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx';
const evidence=JSON.parse(await fs.readFile('artifacts/testing/unit-execution/execution-results.json','utf8'));
const executionDate=evidence.executionDate||evidence.date;
const layout=JSON.parse(await fs.readFile(base+'/unit-test-matrix-row-map.json','utf8'));
const backup=base+'/baseline-20261105/FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx';
try{await fs.access(backup);}catch{await fs.copyFile(path,backup);}
const w=await SpreadsheetFile.importXlsx(await FileBlob.load(path));
for(const info of layout.methods){
 const s=w.worksheets.getItem(info.sheet);const results=info.caseIds.map(id=>evidence.cases[id]);
 const col=n=>{let v='';for(;n>0;n=Math.floor((n-1)/26))v=String.fromCharCode(65+(n-1)%26)+v;return v;};
 for(const [row,values] of [[info.passRow,results.map(r=>r.outcome==='Passed'?'P':r.outcome==='Failed'?'F':'')],[info.dateRow,results.map(r=>r.executed?executionDate:'')],[info.defectRow,results.map(r=>r.defects.join('; '))]])s.getRange('F'+row+':'+col(info.lastCaseColumn)+row).values=[values];
 if(results.some(r=>r.executed))s.getRange('L3').values=[['Codex / NUnit automated runner']];
 const count=results.filter(r=>!r.executed).length;
 const original=String(s.getRange('C5').values[0][0]||'').split(' Execution:')[0].split(' UT-DEF-001:')[0];
 s.getRange('C5').values=[[original+(count?' Execution: '+count+' case(s) skipped; P/F remains blank. Reasons: artifacts/testing/unit-execution/execution-results.json.':'')+(info.id==='UTM-087'?' UT-DEF-001: paid evidence includes P02 required by T01p; see fix-log.md.':'')]];
}
const cover=w.worksheets.getItem('Cover');
cover.getRange('F4:F7').values=[['Codex / NUnit automated runner'],['Design authorized 2026-11-05; execution and coverage gate pending QA review'],[executionDate],['0.2 - EXECUTION RESULTS - COVERAGE GAPS OPEN']];
w.recalculate();await(await SpreadsheetFile.exportXlsx(w)).save(path);
console.log('Wrote actual results into the existing workbook; skipped P/F cells remain blank.');
