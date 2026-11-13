import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const path='artifacts/traceability/Requirements_Traceability_Matrix.xlsx';
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load(path));
const ds=wb.worksheets.getItem('Design_Elements');const rt=wb.worksheets.getItem('RTM');
console.log('Existing headers',JSON.stringify(ds.getRange('A3:G3').values));
const reqSheet=wb.worksheets.getItem('Requirements');const req=reqSheet.getRange('A4:F300').values;const srs=await fs.readFile('artifacts/requirements/software-requirements-specification.md','utf8');
let d=ds.getRange('A4:G300').values;const r=rt.getRange('A4:G300').values;let added=[];
const roots={'UC-C01':'uc-c01-browse-search','UC-C03':'uc-c03-manage-cart','UC-C05':'uc-c05-profile-addresses','UC-C06':'uc-c06-checkout','UC-C07':'uc-c07-my-orders'};
const slot=(rows,id)=>{let i=rows.findIndex(x=>x[0]===id);if(i<0)i=rows.findIndex(x=>!x[0]);if(i<0)throw Error('Approved template capacity exceeded');return i;};
for (const [uc,stem] of Object.entries(roots)){
 const id='DCD-'+uc;i: {const i=slot(d,id);d[i]=[id,'Detailed class view',uc+' constructor injection design','CMP-API-BUS','Service and repository abstractions, typed operations, client and domain views; proposed for review','artifacts/diagrams/class/'+stem+'-design-classes.drawio','Draft for Design Review; no code or test execution'];}
 if(!r.some(x=>x[3]===uc&&x[4]===id)){
  const frs={'UC-C01':['FR-BRW-01','UR-06'],'UC-C03':['FR-CRT-01','UR-06'],'UC-C05':['FR-PRF-01','UR-07'],'UC-C06':['FR-ORD-03','UR-06'],'UC-C07':['FR-MYO-01','UR-08']};
  const [fr,ur]=frs[uc];const basis=r.find(x=>x[2]===fr)||[null,ur,fr,uc];
  if(!req.some(x=>x[0]===fr)){const line=srs.split(/\r?\n/).find(x=>x.startsWith('| **'+fr+'** |'));if(!line)throw Error('Missing SRS source '+fr);const qi=slot(req,fr);req[qi]=[fr,'Functional Requirement',line.split('|')[2].trim(),'Existing SRS; catalog synchronization 2026-10-31','Source-confirmed existing requirement; DCD pending review','2026-10-31'];}
  const i=r.findIndex(x=>!x.some(v=>v!==null&&v!==''));if(i<0)throw Error('RTM full');r[i]=[basis[0],basis[1],basis[2],uc,id,null,null];added.push(i+4);
 }
}
for(const [id,name,file] of [['DCD-SHARED-DI','Shared DI and transaction seams','shared-di-design-classes.drawio'],['DCD-STATE-TRANSITIONS','One handler class per existing transition','state-transitions-design-classes.drawio']]){
 const i=slot(d,id);d[i]=[id,'Detailed class view',name,'CMP-API-BUS','Shared lifecycle support; 24 unique handlers. Staff/return/refund goals are not invented customer use cases.','artifacts/diagrams/class/'+file,'Draft for Design Review; payout/audit/storage policy gaps explicit'];
}
reqSheet.getRange('A4:F300').values=req;ds.getRange('A4:G300').values=d;rt.getRange('A4:G300').values=r;
const read=wb.worksheets.getItem('README');let notes=read.getRange('A4:B100').values;const ni=slot(notes,'Detailed class design 2026-10-31');notes[ni]=['Detailed class design 2026-10-31','Five use-case DCD views and shared DI / 24 transition handlers are draft trace links. No implementation or dynamic-test result is asserted; technical baseline approval is pending.'];read.getRange('A4:B100').values=notes;
wb.recalculate();await(await SpreadsheetFile.exportXlsx(wb)).save(path);
const first=Math.min(...added.filter(Number.isFinite));const start=Number.isFinite(first)?first:r.findIndex(x=>x[4]==='DCD-UC-C01')+4;
const png=await wb.render({sheetName:'RTM',range:`A${start}:G${start+4}`,scale:1.3});await fs.writeFile('artifacts/design/detailed/rtm-preview.png',new Uint8Array(await png.arrayBuffer()));
console.log('Added seven design elements and',added.length,'requirement trace rows; preserved original workbook sheets/columns.');
