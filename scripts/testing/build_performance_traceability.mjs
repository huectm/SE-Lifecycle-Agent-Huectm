import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const out='artifacts/testing/tutorialsninja-performance/';
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load('templates/Test Documents/Requirements_Traceability_Matrix_Simplified.xlsx'));
const requirements=[
 ['PERF-REQ-01','NFR','Serve at least 1000 users/day.','User request 2026-10-28','User stated; target not verified','Draft 1.0'],
 ['PERF-REQ-02','NFR','Operate 06:00 to 24:00; service timezone TBD.','User request 2026-10-28','User stated; target not verified','Draft 1.0'],
 ['PERF-REQ-03','NFR','Support up to 100 concurrent users.','User request 2026-10-28','User stated; target not verified','Draft 1.0'],
 ['PERF-REQ-04','NFR','Average response time strictly below 6 seconds; measurement boundary requires agreement.','User request 2026-10-28','User stated; target not verified','Draft 1.0']
];
wb.worksheets.getItem('Requirements').getRange('A4:F7').values=requirements;
const mappings={
 'PERF-REQ-01':['PERF-02'],
 'PERF-REQ-02':['PERF-02','PERF-09'],
 'PERF-REQ-03':['PERF-03','PERF-04','PERF-05','PERF-08','PERF-10'],
 'PERF-REQ-04':['PERF-01','PERF-02','PERF-03','PERF-04','PERF-05','PERF-08','PERF-10']
};
const rows=Object.entries(mappings).flatMap(([id,tests])=>tests.map(t=>[null,null,id,'UC-REG-01',null,null,t+' - NOT EXECUTED (authorization unavailable)']));
rows.push([null,null,null,'UC-REG-01',null,null,'PERF-06 - stress characterization; NOT EXECUTED'],[null,null,null,'UC-REG-01',null,null,'PERF-07 - recovery characterization; NOT EXECUTED']);
wb.worksheets.getItem('RTM').getRange(`A4:G${rows.length+3}`).values=rows;
wb.recalculate();
console.log((await wb.inspect({kind:'table',range:'Coverage!A4:G7',tableMaxRows:4,tableMaxCols:7,maxChars:1700})).ndjson);
await(await SpreadsheetFile.exportXlsx(wb)).save(out+'Performance_Traceability.xlsx');
for(const name of ['RTM','Requirements','Coverage']){
 const img=await wb.render({sheetName:name,range:name==='Requirements'?'A1:F7':'A1:G7',scale:1});await fs.writeFile(out+name.toLowerCase()+'-preview.png',new Uint8Array(await img.arrayBuffer()));
}
const preview=await SpreadsheetFile.importXlsx(await FileBlob.load(out+'performance-preview-source.xlsx'));
for(const [name,range,file] of [['KBKTHN','A1:V6','summary-preview.png'],['KBKTHN','A11:M18','scenario-preview.png'],['Trang bìa','A9:G23','cover-preview.png']]){
 const img=await preview.render({sheetName:name,range,scale:1});await fs.writeFile(out+file,new Uint8Array(await img.arrayBuffer()));
}
