import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const base='artifacts/testing/test-design/backend-unit';
const data=JSON.parse(await fs.readFile(base+'/backend-unit-test-design.json','utf8'));
const patchMode=false;
const previous=patchMode?JSON.parse(await fs.readFile('scratch/unit-test-template/workbook-design-snapshot.json','utf8')):null;
const priorMethods=new Map((previous?.methods||[]).map(m=>[m.id,JSON.stringify(m)]));
const template=patchMode?base+'/FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx':'scratch/unit-test-template/Template_Unit Test Case.xlsx';
const metadata=JSON.parse(await fs.readFile('scratch/unit-test-template/Template_Unit Test Case.json','utf8'));
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load(template));
const cover=wb.worksheets.getItem('Cover'), list=wb.worksheets.getItem('FunctionList'), report=wb.worksheets.getItem('Test Report');
function col(n){let out='';for(;n>0;n=Math.floor((n-1)/26))out=String.fromCharCode(65+(n-1)%26)+out;return out;}
function put(s,a,value){s.getRange(a).values=[[value]];}
function formula(s,a,value){s.getRange(a).formulas=[[value]];}
const compact=value=>JSON.stringify(value);
put(cover,'B4','FreshFood Backend - Five Customer Use Cases');
put(cover,'B5','FRESHFOOD');
put(cover,'F4','Codex - draft test design');
put(cover,'F5','TBD - Technical Lead / QA / stakeholder approval');
put(cover,'F6','2026-11-04');
put(cover,'F7','0.2 - DRAFT - MATRIX CORRECTED');
cover.getRange('B4:D7').format.wrapText=true;cover.getRange('F4:F7').format.wrapText=true;cover.getRange('4:7').format.rowHeight=35;
formula(cover,'B6','=B5&"_Unit_Test_Design_v0.2"');
cover.getRange('A12:F18').clear({applyTo:'contents'});
cover.getRange('A12:F12').values=[['2026-11-04','0.1','All backend methods','A','Design only: '+data.summary.executableMethods+' executable methods; '+data.summary.interfaceContracts+' interface contracts; no test execution.','Approved use cases; detailed PIM; source inventory; project testing rules']];
cover.getRange('A12:F12').format.wrapText=true;
cover.getRange('A12:F12').format.rowHeight=105;
cover.getRange('A13:F13').copyFrom(cover.getRange('A12:F12'),'all');
cover.getRange('A13:F13').values=[['2026-11-04','0.2','Function-sheet matrix','M','Corrected template notation: left-side conditions/expected values with O/blank selection columns. Stable test IDs and no execution.','Template_Unit Test Case.xls']];
cover.getRange('A13:F13').format.rowHeight=70;
const matrix=JSON.parse(await fs.readFile(base+'/unit-test-matrix-layout.json','utf8'));
const matrices=new Map(matrix.methods.map(m=>[m.id,m]));
const methodTemplate=wb.worksheets.getItem('Function1');
const staging=wb.worksheets.getItem('Example');
staging.getRange('A60:AZ102').copyFrom(methodTemplate.getRange('A1:AZ43'),'all');
staging.getRange('A60:AZ102').unmerge();
const allLayouts=[];
let processed=0;
function singleText(value){return String(value??'');}
for(const m of data.methods) {
 const plan=matrices.get(m.id), ordinal=Number(m.id.split('-')[1]), listRow=ordinal+10;
 const sheet=ordinal<=3?wb.worksheets.getItem(m.sheet):wb.worksheets.add(m.sheet);
 if(ordinal>3) {
  sheet.getRange('A1:T9').copyFrom(methodTemplate.getRange('A1:T9'),'all');
  for(const merge of metadata.sheets.find(s=>s.name==='Function1').merges) {
   const [a,b]=merge.replaceAll('$','').split(':');
   if(Number(a.match(/\d+/)[0])<10 && Number((b||a).match(/\d+/)[0])<10)sheet.mergeCells(merge.replaceAll('$',''));
  }
 }
 sheet.getRange('A10:AZ50').unmerge();sheet.getRange('A10:AZ50').clear({applyTo:'all'});
 const actualCol=5+m.cases.length, displayCol=Math.max(20,actualCol), last=col(actualCol), displayLast=col(displayCol);
 sheet.getRange('F9:'+displayLast+'9').copyFrom(staging.getRange('F68'),'all');
 sheet.getRange('F9:'+displayLast+'9').clear({applyTo:'contents'});
 for(let n=0;n<m.cases.length;n++)put(sheet,col(n+6)+'9',m.cases[n].id);
 formula(sheet,'C2','=FunctionList!E'+listRow);
 const name=m.type+'.'+(m.name==='.ctor'?'Constructor':m.name)+(m.signature.includes(m.name+'<')?'<T>':'');
 put(sheet,'L2',name);put(sheet,'C3','Codex');put(sheet,'L3','');put(sheet,'C4',m.loc);
 put(sheet,'C5',m.useCases.join(', ')+' | '+m.testLevel+' | '+m.file+':'+m.line+' | Full signature: FunctionList D'+listRow+'. O=selected; blank=not selected. Draft; not executed.');
 formula(sheet,'L4','=IF(FunctionList!E6<>"N/A",SUM(C4*FunctionList!E6/1000,-O7),"N/A")');
 sheet.getRange('A:A').format.columnWidth=8.08984375;
 sheet.getRange('B:B').format.columnWidth=13.36328125;
 sheet.getRange('C:C').format.columnWidth=10.7265625;
 sheet.getRange('D:D').format.columnWidth=48;
 sheet.getRange('E:E').format.columnWidth=1.7265625;
 sheet.getRange('F:'+displayLast).format.columnWidth=2.90625;
 sheet.getRange('L2:T2').format.wrapText=true;sheet.getRange('C5:T5').format.wrapText=true;
 sheet.getRange('2:2').format.rowHeight=30;sheet.getRange('3:4').format.rowHeight=18;sheet.getRange('5:5').format.rowHeight=32;
 sheet.getRange('6:7').format.rowHeight=17;sheet.getRange('8:8').format.rowHeight=8;sheet.getRange('9:9').format.rowHeight=105;
 const idx=new Map(m.cases.map((c,i)=>[c.id,i+5]));
 let row=10;
 const layout={id:m.id,sheet:m.sheet,caseHeaderRow:9,firstCaseColumn:6,lastCaseColumn:actualCol,lastDisplayColumn:displayCol,rows:[],caseIds:plan.caseIds,conditionStart:10};
 function rowStyle(sourceRow,values,height=13.5) {
  sheet.getRange('A'+row+':E'+row).copyFrom(staging.getRange('A'+(sourceRow+59)+':E'+(sourceRow+59)),'all');
  sheet.getRange('F'+row+':'+displayLast+row).copyFrom(staging.getRange('F'+(sourceRow+59)),'all');
  sheet.getRange('A'+row+':'+displayLast+row).values=[values];
  sheet.getRange(row+':'+row).format.rowHeight=height;
 }
 function heading(label,sourceRow) {
  const v=Array(displayCol).fill(null);v[1]=label;rowStyle(sourceRow,v,Math.max(14,Math.ceil(label.length/72)*10));
  sheet.mergeCells('B'+row+':E'+row);
  sheet.getRange('B'+row+':E'+row).format.wrapText=true;
  sheet.getRange('B'+row+':E'+row).format.font.bold=true;
  sheet.getRange('B'+row+':E'+row).format.verticalAlignment='center';
  layout.rows.push({row,kind:'group',label});row++;
 }
 function variant(group,variant,prototype) {
  const v=Array(displayCol).fill(null);v[3]=singleText(variant.text);
  for(const id of variant.caseIds)v[idx.get(id)]='O';
  const lines=singleText(variant.text).split('\n').reduce((n,t)=>n+Math.max(1,Math.ceil(t.length/55)),0);
  rowStyle(prototype,v,Math.min(390,Math.max(15,(lines+1)*10)));
  sheet.getRange('D'+row).format.wrapText=true;
  sheet.getRange('D'+row).format.horizontalAlignment='left';
  sheet.getRange('D'+row).format.verticalAlignment='center';
  sheet.getRange('D'+row).setNumberFormat('@');
  sheet.getRange('F'+row+':'+displayLast+row).format.horizontalAlignment='center';
  sheet.getRange('F'+row+':'+displayLast+row).format.verticalAlignment='center';
  layout.rows.push({row,kind:'variant',section:group.section,group:group.field,value:variant.text,caseIds:variant.caseIds});
  row++;
 }
 heading('Precondition',10);
 for(const group of plan.conditions) {
  heading(group.field,group.section==='Precondition'?10:14);
  for(const v of group.variants)variant(group,v,15);
 }
 layout.confirmStart=row;
 for(const group of plan.confirmations) {
  heading(group.field,group.field==='Return'?31:group.field==='Exception'?34:36);
  for(const v of group.variants)variant(group,v,32);
 }
 layout.typeRow=row;layout.passRow=row+1;layout.dateRow=row+2;layout.defectRow=row+3;
 for(const [offset,source,label] of [[0,39,'Type(N : Normal, A : Abnormal, B : Boundary)'],[1,40,'Passed/Failed'],[2,41,'Executed Date'],[3,42,'Defect ID']]) {
  const values=Array(displayCol).fill(null);values[1]=label;
  if(offset===0)for(let n=0;n<m.cases.length;n++)values[n+5]=m.cases[n].inputType;
  rowStyle(source,values,offset===0?27:18);sheet.mergeCells('B'+row+':D'+row);
  sheet.getRange('B'+row+':D'+row).format.wrapText=true;row++;
 }
 layout.lastRow=row-1;
 for(const [a,b,text] of [[layout.conditionStart,layout.confirmStart-1,'Condition'],[layout.confirmStart,layout.typeRow-1,'Confirm'],[layout.typeRow,layout.lastRow,'Result']]) {
  sheet.mergeCells('A'+a+':A'+b);put(sheet,'A'+a,text);
  sheet.getRange('A'+a+':A'+b).format.verticalAlignment='top';
  sheet.getRange('A'+a+':A'+b).format.wrapText=true;
 }
 for(const [cell,expression] of Object.entries({
  A7:'COUNTIF(F'+layout.passRow+':'+last+layout.passRow+',"P")',
  C7:'COUNTIF(F'+layout.passRow+':'+last+layout.passRow+',"F")',
  F7:'SUM(O7,-A7,-C7)',
  L7:'COUNTIF(F'+layout.typeRow+':'+last+layout.typeRow+',"N")',
  M7:'COUNTIF(F'+layout.typeRow+':'+last+layout.typeRow+',"A")',
  N7:'COUNTIF(F'+layout.typeRow+':'+last+layout.typeRow+',"B")',
  O7:'COUNTA(F9:'+last+'9)'
 }))formula(sheet,cell,'='+expression);
 sheet.freezePanes.freezeRows(9);sheet.freezePanes.freezeColumns(5);
 allLayouts.push(layout);
 processed++;if(processed%30===0)console.log('Rebuilt template matrix '+processed+'/'+data.methods.length);
}
staging.getRange('A60:AZ102').unmerge();staging.getRange('A60:AZ102').clear({applyTo:'all'});
await fs.writeFile(base+'/unit-test-matrix-row-map.json',JSON.stringify({version:'0.2',caseCount:matrix.testCases,methods:allLayouts},null,2));

list.getRange('A11:H350').clear({applyTo:'contents'});
put(list,'E6',100);
put(list,'E7','DRAFT: .NET 10 / C# / proposed xUnit. Strict fakes for services, gateways and IRepositorySession. No live provider. PostgreSqlSession needs an approved seam or separate component fixture. Target: all feasible branches and evaluated atomic conditions; >=90% core statements. No new project/scripts/execution until approval. fixtures.json and branch-condition-coverage.csv are part of this design.');
list.getRange('E7:H7').format.wrapText=true;list.getRange('7:7').format.rowHeight=140;
let row=11;
for(const m of data.methods) {
 list.getRange('A'+row+':H'+row).copyFrom(list.getRange('A11:H11'),'all');
 list.getRange('A'+row+':H'+row).values=[[row-10,m.useCases.join('; '),m.type,m.signature,m.id,m.sheet,m.cases.length+' cases; LOC='+m.loc+'; '+m.testLevel+'; '+m.requirements.join(', '),m.testability]];
 row++;
}
for(const c of data.contracts) {
 const matches=c.realizations.map(id=>data.methods.find(m=>m.id===id));const target=matches[0];
 list.getRange('A'+row+':H'+row).copyFrom(list.getRange('A11:H11'),'all');
 list.getRange('A'+row+':H'+row).values=[[row-10,'Interface contract',c.type,c.signature,'CON-'+String(row-10-data.methods.length).padStart(3,'0'),target?.sheet||'Review required',c.status+'; concrete methods: '+c.realizations.join(', '),'Interface has no executable body; no separate branch or execution claim.']];
 row++;
}
list.getRange('A11:H'+(row-1)).format.wrapText=true;list.getRange('A11:H'+(row-1)).format.verticalAlignment='top';list.getRange('11:'+(row-1)).format.rowHeight=95;
list.getRange('B:B').format.columnWidth=24;list.getRange('C:C').format.columnWidth=29;list.getRange('D:D').format.columnWidth=58;list.getRange('G:G').format.columnWidth=60;list.getRange('H:H').format.columnWidth=65;
list.freezePanes.freezeRows(10);
const total=12+data.methods.length+1, stats=total+2;
if(!patchMode){
 report.getRange('A'+total+':I'+total).copyFrom(report.getRange('A17:I17'),'all');
 report.getRange('B'+stats+':E'+(stats+4)).copyFrom(report.getRange('B19:E23'),'all');
}
report.getRange('A12:I23').clear({applyTo:'contents'});
put(report,'F4','Not executed');put(report,'F5','Awaiting approval');put(report,'F6','2026-11-04');
put(report,'B7','DESIGN ONLY. Actual results/dates/defect IDs are blank. Every case is Untested. Template Test coverage = execution rate, NOT branch/condition coverage. Structural targets and feasibility are in branch-condition-coverage.csv. Existing 67 tests are not results of this new plan. After approval: implement scripts, execute, fill each case P/F/date/defect ID, then this report recalculates.');
report.getRange('B7:I7').format.wrapText=true;report.getRange('7:7').format.rowHeight=120;
data.methods.forEach((m,i)=>{
 const r=i+12;report.getRange('A'+r+':I'+r).copyFrom(report.getRange('A12:I12'),'all');
 put(report,'A'+r,i+1);put(report,'B'+r,m.id);
 for(const [column,source] of Object.entries({C:'A7',D:'C7',E:'F7',F:'L7',G:'M7',H:'N7',I:'O7'}))formula(report,column+r,"='"+m.sheet+"'!"+source);
});
put(report,'B'+total,'Sub total');
for(const column of ['C','D','E','F','G','H','I'])formula(report,column+total,'=SUM('+column+'12:'+column+(11+data.methods.length)+')');
for(const [i,label] of ['Test coverage','Test successful coverage','Normal case','Abnormal case','Boundary case'].entries())put(report,'B'+(stats+i),label);
for(const [i,numerator] of ['(C'+total+'+D'+total+')','C'+total,'F'+total,'G'+total,'H'+total].entries()){formula(report,'D'+(stats+i),'=IFERROR('+numerator+'*100/I'+total+',0)');put(report,'E'+(stats+i),'%');}
for(const s of metadata.sheets.filter(s=>!['Cover','FunctionList','Test Report','Guidleline','Function1','Function2','Function3'].includes(s.name))) {
 const sh=wb.worksheets.getItem(s.name);put(sh,'C2','REFERENCE ONLY');put(sh,'C5','Original template example; excluded from project inventory and execution totals. No project result is represented here.');
 // Remove example P/F/dates/defects without changing its instructional layout.
 const result=s.cells.find(c=>c.value==='Passed/Failed');if(result){const r=Number(result.cell.match(/\d+/)[0]);sh.getRange('F'+r+':HT'+(r+2)).clear({applyTo:'contents'});}
}
wb.recalculate();
const inspection=await wb.inspect({kind:'match',searchTerm:'#REF!|#DIV/0!|#VALUE!|#NAME\\?|#NUM!',options:{useRegex:true,maxResults:20},maxChars:2000});
await fs.writeFile(base+'/workbook-inspection.json',inspection.ndjson);
const output=base+'/FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx';
await(await SpreadsheetFile.exportXlsx(wb)).save(output);
console.log('Saved '+output);
console.log('Workbook inspection: '+inspection.ndjson);
