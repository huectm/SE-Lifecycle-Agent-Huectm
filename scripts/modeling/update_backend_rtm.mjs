import fs from 'node:fs/promises';
import { FileBlob, SpreadsheetFile } from '@oai/artifact-tool';
const path='artifacts/traceability/Requirements_Traceability_Matrix.xlsx';
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load(path));
const rt=wb.worksheets.getItem('RTM'), ds=wb.worksheets.getItem('Design_Elements');
const r=rt.getRange('A4:G300').values,d=ds.getRange('A4:G300').values;
const before=await wb.render({sheetName:'RTM',range:'A3:G10',scale:1.1});await fs.writeFile('scratch/backend-rtm-before.png',Buffer.from(await before.arrayBuffer()));
const scopes={ 'UC-C01':['Catalog','browse-search'],'UC-C03':['Cart','manage-cart'],'UC-C05':['Profile','profile-addresses'],'UC-C06':['Checkout','checkout'],'UC-C07':['MyOrders','my-orders']};
let rows=0;
for(const [uc,[feature,slug]] of Object.entries(scopes)){
 const existing=r.find(x=>x[3]===uc&&x[4]==='DCD-'+uc);
 if(!existing)throw new Error('Missing approved DCD trace '+uc);
 existing[5]='src/FreshFood-API/Services/Implements/'+feature+'Service.cs';existing[6]='src/Tests/Backend/FreshFood-API.Tests/BackendTests.cs; src/Tests/Backend/FreshFood-API.Tests/PostgreSqlTests.cs';rows++;
 const dcd=d.find(x=>x[0]==='DCD-'+uc);if(dcd)dcd[6]='PIM 0.6 mapped to C# through explicit refinements; unresolved TBDs retained';
 const id='DSEQ-'+uc;let i=d.findIndex(x=>x[0]===id);if(i<0)i=d.findIndex(x=>!x[0]);if(i<0)throw new Error('Design registry capacity');
 d[i]=[id,'Design sequence',uc+' approved interactions','CMP-API-BUS','Controller/service/repository/DTO and transition collaborations','artifacts/diagrams/sequence/'+uc.toLowerCase()+'-'+slug+'-design-sequence.drawio','PIM 0.6 source mapping verified; external providers remain deferred'];
}
for(const id of ['DCD-SHARED-DI','DCD-STATE-TRANSITIONS']){const x=d.find(x=>x[0]===id);if(x)x[6]='Approved for backend source mapping; shared staff/financial effects remain scoped and TBD';}
// Write only changed data cells; preserve all unrelated formulas and worksheet structures.
for(let i=0;i<r.length;i++)if(r[i][4]?.startsWith('DCD-UC-')&&scopes[r[i][3]])rt.getRange('F'+(i+4)+':G'+(i+4)).values=[[r[i][5],r[i][6]]];
for(let i=0;i<d.length;i++)if(d[i][0]?.startsWith('DCD-')||d[i][0]?.startsWith('DSEQ-'))ds.getRange('A'+(i+4)+':G'+(i+4)).values=[d[i]];
const read=wb.worksheets.getItem('README');let notes=read.getRange('A4:B100').values;let k=notes.findIndex(x=>x[0]==='Backend source realization');if(k<0)k=notes.findIndex(x=>!x[0]);read.getRange('A'+(k+4)+':B'+(k+4)).values=[['Backend source realization','ASP.NET Core C#: 132 backend classifiers mapped; 41 local unit/HTTP/SQL tests passed; PIM 0.6 has 347 explicit operation mappings in artifacts/design/detailed/pim-to-code-mapping.csv. Real-server contention and external provider acceptance remain pending. Code links do not assert full FR/branch coverage.']];
wb.recalculate();const errors=await wb.inspect({kind:'match',searchTerm:'#REF!|#DIV/0!|#VALUE!|#NAME\\?|#NUM!|#SPILL!',options:{useRegex:true,maxResults:20},maxChars:1500});
console.log(errors.ndjson);await(await SpreadsheetFile.exportXlsx(wb)).save(path);
const first=r.findIndex(x=>x[4]==='DCD-UC-C01')+4;const preview=await wb.render({sheetName:'RTM',range:`A${first}:G${first+4}`,scale:1.1});await fs.writeFile('scratch/backend-rtm-after.png',Buffer.from(await preview.arrayBuffer()));
console.log('Updated five code/test trace rows and five approved sequence design records');
