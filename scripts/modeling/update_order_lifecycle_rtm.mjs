import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const path='artifacts/traceability/Requirements_Traceability_Matrix.xlsx';
const model=JSON.parse(await fs.readFile('artifacts/design/order-lifecycle-model.json','utf8'));
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load(path));
const requirements=wb.worksheets.getItem('Requirements');const rt=wb.worksheets.getItem('RTM');const design=wb.worksheets.getItem('Design_Elements');
const req=requirements.getRange('A4:F300').values;
function slot(rows,id){let i=rows.findIndex(r=>r[0]===id);if(i<0)i=rows.findIndex(r=>!r[0]);if(i<0)throw Error('Template capacity exceeded');return i;}
for(const [id,text] of Object.entries({...model.rules,...model.trace_rule_clarifications,...model.requirements})){
 const i=slot(req,id);req[i]=[id,id.startsWith('BR')?'Business Rule':'Functional Requirement',text,'Stakeholder 2026-10-29; SRS / order lifecycle revision','User-directed revision; design review pending','2026-10-29'];
}
requirements.getRange('A4:F300').values=req;
const rows=rt.getRange('A4:G300').values;
const mapping={
 'FR-ORD-03':['BR-ORD-01','UR-06','UC-C06'], 'FR-FUL-02':['BR-FUL-01','UR-09','UC-M01.3'],
 'FR-MYO-01':['BR-ORD-04','UR-08','UC-C07'], 'FR-DEL-03':['BR-FUL-04','UR-09','UC-M03.3'],
 'FR-DEL-04':['BR-FUL-04','UR-09',null], 'FR-DEL-05':['BR-FUL-05','UR-09','UC-M03.3'],
 'FR-DEL-06':['BR-FUL-05','UR-09','UC-M03'], 'FR-DEL-07':['BR-FUL-04','UR-09',null],
 'FR-PAY-03':['BR-ORD-03','UR-06','UC-C06'], 'FR-PAY-04':['BR-FUL-05','UR-09',null], 'FR-PAY-05':['BR-FUL-06','UR-09',null]
};
const baseTest=id=>id==='FR-ORD-03'?'Local stock CHECK tested; multi-line concurrent allocation not tested':id==='FR-DEL-05'?'Unconfirmed cause blocks local refund; final authority TBD':id==='FR-DEL-07'?'Refund without inspection tested; manual disposition workflow not executed':id==='FR-DEL-06'?'Shipping-only collection does not mark goods paid; courier payout not executed':'Local SQL design checks in order-lifecycle-db-verification.json; not app end-to-end execution';
const test=id=>(mapping[id][2]===null?'New receiving/refund UC ID pending review; ':'')+baseTest(id);
for(const r of rows){if(mapping[r[2]]){r[3]=mapping[r[2]][2];r[4]='DB-ORDER-LIFECYCLE';r[5]=null;r[6]=test(r[2]);}}
let added=[];
for(const [id,[br,ur,uc]] of Object.entries(mapping)){
 if(!rows.some(r=>r[0]===br&&r[2]===id)){
  const i=rows.findIndex(r=>!r.some(v=>v!==null&&v!==''));if(i<0)throw Error('RTM template full');
  rows[i]=[br,ur,id,uc,'DB-ORDER-LIFECYCLE',null,test(id)];added.push(i+4);
 }
}
rt.getRange('A4:G300').values=rows;
const ds=design.getRange('A4:G300').values;ds[slot(ds,'DB-ORDER-LIFECYCLE')]=['DB-ORDER-LIFECYCLE','Database / analysis revision','Order payment, physical return and delivery-fee settlement',null,'Existing core plus eight normalized tables; independent initial Pending Unpaid/Paid states; authorization/provider gaps explicit.','artifacts/design/database-design.md; artifacts/design/database/order-lifecycle-extension.sql; artifacts/diagrams/class/entity-class-diagram.drawio; artifacts/diagrams/database/physical-erd.drawio','Requested revision for review; no production deployment'];design.getRange('A4:G300').values=ds;
const guide=wb.worksheets.getItem('README');let g=guide.getRange('A4:B100').values;let gi=g.findIndex(r=>r[0]==='Order lifecycle revision 2026-10-29');if(gi<0)gi=g.findIndex(r=>!r[0]);g[gi]=['Order lifecycle revision 2026-10-29','Coverage counts are trace links, not passed tests. Twenty isolated local SQL checks passed; provider payouts, role authorization and multi-session stock races are not proven.'];guide.getRange('A4:B100').values=g;
wb.recalculate();
await(await SpreadsheetFile.exportXlsx(wb)).save(path);
const start=added.length?added[0]:4;const image=await wb.render({sheetName:'RTM',range:`A${start}:G${Math.min(start+5,300)}`,scale:1});await fs.writeFile('artifacts/analysis/order-lifecycle-rtm-preview.png',new Uint8Array(await image.arrayBuffer()));
console.log((await wb.inspect({kind:'table',range:`RTM!A${start}:G${Math.min(start+3,300)}`,tableMaxRows:4,tableMaxCols:7,maxChars:2000})).ndjson);
console.log('RTM affected requirements:',Object.keys(mapping).length,'new rows:',added.length);
