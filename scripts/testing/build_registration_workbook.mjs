import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const base='artifacts/testing/tutorialsninja-register/';
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load('templates/Test Documents/Functional_Test Cases.xlsx'));
const data=JSON.parse(await fs.readFile(base+'workbook-data.json','utf8'));
const cases=wb.worksheets.getItem('MFM-CreateAcct');
cases.getRange('A5:L200').clear({applyTo:'contents'});
cases.getRange('B2').values=[['UC-REG-01 TutorialsNinja Registration']];
cases.getRange('B3').values=[['Robot Framework / Chrome headless']];
for(let i=0;i<data.cases.length;i++){
 const c=data.cases[i],r=i+5;
 if(r>50)cases.getRange(`A${r}:L${r}`).copyFrom(cases.getRange('A6:L6'),'all');
 cases.getRange(`A${r}:L${r}`).values=[[c.id,c.title,'Guest; isolated cookies; live demo reachable. Synthetic unique email.',c.steps,c.expected,'N/A','N/A','N/A','N/A','N/A',data.date,c.note]];
 cases.getRange(`A${r}:L${r}`).format.wrapText=true;
 cases.getRange(`A${r}:L${r}`).format.rowHeight=110;
}
cases.getRange('L4:L59').format.columnWidth=85;
const last=data.cases.length+4;
const countFormula=(prefix,sheet='')=>'SUM('+data.cases.map((_,i)=>`IF(LEFT(${sheet}L${i+5},4)="${prefix}",1,0)`).join(',')+')';
cases.getRange('D1').formulas=[[`="Pass: "&${countFormula("PASS")}`]];
cases.getRange('D2').formulas=[[`="Fail: "&${countFormula("FAIL")}`]];
cases.getRange('D3').values=[['Chrome results are in Note; legacy device columns N/A.']];
cases.getRange('E1').formulas=[[`="Skipped: "&${countFormula("SKIP")}`]];
cases.getRange('E2').values=[['Baseline status: review required']];
cases.getRange('E3').values=[['Number of cases: '+data.cases.length]];
const cover=wb.worksheets.getItem('Cover');
for(const [cell,val] of Object.entries({C4:'TutorialsNinja Registration',C5:'UC-REG-01',C6:'Functional Registration Tests v1.0',G4:'SE Lifecycle Agent',G5:'TBD - Authorized reviewer',G6:data.date,G7:'1.0',F12:'Keyword/data-driven registration tests. Only MFM-CreateAcct applies. Other module tabs retain template examples and are excluded.',G12:'Use Case Register .docx; live form; README.md'}))cover.getRange(cell).values=[[val]];
cover.getRange('B12').values=[[data.date]];
cover.getRange('C12').values=[['1.0']];
cover.getRange('F12:G12').format.wrapText=true;
cover.getRange('B12:G12').format.rowHeight=70;
cover.getRange('B13:G20').clear({applyTo:'contents'});
const report=wb.worksheets.getItem('Test report');
report.getRange('B5:P22').clear({applyTo:'contents'});
report.getRange('B12:P12').values=[['Live demo','UC-REG-01 Registration',null,null,null,null,null,null,null,data.pass,data.fail,data.skip,0,data.cases.length,data.cases.length]];
report.getRange('K12').formulas=[[`=${countFormula("PASS","'MFM-CreateAcct'!")}`]];
report.getRange('L12').formulas=[[`=${countFormula("FAIL","'MFM-CreateAcct'!")}`]];
report.getRange('M12').formulas=[[`=${countFormula("SKIP","'MFM-CreateAcct'!")}`]];
report.getRange('D23:P27').clear({applyTo:'contents'});
report.getRange('K23:P23').formulas=[['=K12','=L12','=M12','=N12','=O12','=P12']];
report.getRange('L25').formulas=[['=(K12+L12)/O12*100']];
wb.recalculate();
console.log((await wb.inspect({kind:'table',range:"'Test report'!K12:P12",tableMaxRows:1,tableMaxCols:6})).ndjson);
await (await SpreadsheetFile.exportXlsx(wb)).save(base+'Functional_Test_Cases.xlsx');
for(const [name,range,file] of [['Cover','B2:G12','cover-preview.png'],['MFM-CreateAcct','A1:E7','cases-preview.png'],['MFM-CreateAcct','K4:L8','results-preview.png'],['Test report','B4:P13','report-preview.png']]){
 const img=await wb.render({sheetName:name,range,scale:1});await fs.writeFile(base+file,new Uint8Array(await img.arrayBuffer()));
}
const rtm=await SpreadsheetFile.importXlsx(await FileBlob.load('templates/Test Documents/Requirements_Traceability_Matrix_Simplified.xlsx'));
const trace=rtm.worksheets.getItem('RTM'),req=rtm.worksheets.getItem('Requirements');
const rules=[['BR-01','Business Rule','Starred fields are required. Numeric limits remain proposed or observed as identified in the dataset.','UC-REG-01; Use Case Register .docx','Source described; limits pending confirmation','Draft v1.0'],['BR-02','Business Rule','Password confirmation must match.','UC-REG-01','Source described','Draft v1.0'],['BR-03','Business Rule','Privacy Policy consent is required.','UC-REG-01','Source described','Draft v1.0'],['BR-04','Business Rule','Newsletter supports Yes/No and defaults to No.','UC-REG-01','Source described','Draft v1.0'],['BR-05','Business Rule','Valid unique email; deliverability and case policy unconfirmed.','UC-REG-01','Proposed / confirmation required','Draft v1.0']];
req.getRange('A4:F8').values=rules;
const br=c=>c.field==='confirm'?'BR-02':c.field==='agree'?'BR-03':c.field==='newsletter'||c.id==='REG-001'?'BR-04':['email','duplicate'].includes(c.field)?'BR-05':['firstname','lastname','telephone','password'].includes(c.field)?'BR-01':'';
trace.getRange(`A4:G${data.cases.length+3}`).values=data.cases.map(c=>[br(c)||null,null,null,'UC-REG-01',null,null,c.id+' '+c.status+(c.field==='network'?' - designed only; controlled fault environment needed':'')]);
rtm.recalculate();
await (await SpreadsheetFile.exportXlsx(rtm)).save(base+'Requirements_Traceability_Matrix.xlsx');
console.log((await rtm.inspect({kind:'table',range:'Coverage!A4:G8',tableMaxRows:5,tableMaxCols:7,maxChars:1800})).ndjson);
for(const name of ['RTM','Coverage','Requirements']){const im=await rtm.render({sheetName:name,range:name==='RTM'?'A1:G8':name==='Coverage'?'A1:G8':'A1:F8',scale:1});await fs.writeFile(base+name.toLowerCase()+'-preview.png',new Uint8Array(await im.arrayBuffer()));}


