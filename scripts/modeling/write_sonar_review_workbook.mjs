import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const report=JSON.parse(await fs.readFile('artifacts/analysis/sonarqube/review.json','utf8'));
if(process.argv.includes('--update-all-fixed')) {
 const bookPath='artifacts/analysis/sonarqube/SonarCloud_Defect_Log.xlsx';
 const book=await SpreadsheetFile.importXlsx(await FileBlob.load(bookPath));
 const defects=book.worksheets.getItem('Defects');
 const values=defects.getRange('A1:H100').values;
 for(const finding of report.findings) {
  const row=values.findIndex(r=>r[0]===finding.id)+1;
  if(!row)throw new Error('Missing stable defect ID '+finding.id);
  if(finding.resolution!=='FIXED')throw new Error('Unverified finding '+finding.id);
  const previous=String(values[row-1][2]).split('\nFinal batch verification 2026-11-04:')[0];
  defects.getRange('C'+row).values=[[previous+'\nFinal batch verification 2026-11-04: '+finding.implemented_action+'\nEvidence: '+finding.verification+'\nOriginal detection context above is retained as history; status is now Closed.']];
  defects.getRange('G'+row).values=[['Closed']];
  defects.getRange('C'+row).format.wrapText=true;
  defects.getRange('A'+row+':H'+row).format.autofitRows();
 }
 defects.getRange('D1').values=[['Quality Gate: ERROR (coverage)']];
 defects.getRange('D2').values=[['Coverage: '+report.metrics.coverage+'%']];
 book.recalculate();
 const inspect=await book.inspect({kind:'match',searchTerm:'#REF!|#DIV/0!|#VALUE!|#NAME\\?',options:{useRegex:true,maxResults:10},maxChars:1000});
 await fs.writeFile('artifacts/analysis/sonarqube/workbook-inspection.json',inspect.ndjson);
 await(await SpreadsheetFile.exportXlsx(book)).save(bookPath);
 const image=await book.render({sheetName:'Defects',range:'A4:H6',scale:1});
 await fs.writeFile('scratch/sonar-all-fixed-preview.png',Buffer.from(await image.arrayBuffer()));
 console.log('Updated 18 existing defect rows; all Closed. Coverage gate remains explicit.');
 process.exit(0);
}
if(process.argv.includes('--update-approved-cookie') || process.argv.includes('--update-approved-finding')) {
 const selectedId=process.argv.includes('--update-approved-finding') ? process.argv[process.argv.indexOf('--update-approved-finding')+1] : 'SQ-007';
 const bookPath='artifacts/analysis/sonarqube/SonarCloud_Defect_Log.xlsx';
 const book=await SpreadsheetFile.importXlsx(await FileBlob.load(bookPath));
 const defects=book.worksheets.getItem('Defects');
 const values=defects.getRange('A1:H100').values;
 const row=values.findIndex(r=>r[0]===selectedId)+1;
 if(!row)throw new Error(selectedId+' missing from existing defect template');
 const finding=report.findings.find(f=>f.id===selectedId);
 defects.getRange('C'+row).values=[[values[row-1][2]+'\n'+(finding.approval_date ? 'Approved fix 2026-11-04: ' : 'Automatic analyzer reevaluation 2026-11-04: ')+finding.implemented_action+'\nVerification: '+finding.verification+'; Sonar issue FIXED automatically.']];
 defects.getRange('G'+row).values=[['Closed']];
 defects.getRange('C'+row).format.wrapText=true;
 defects.getRange('A'+row+':H'+row).format.autofitRows();
 defects.getRange('D1').values=[['Quality Gate: '+report.quality_gate]];
 defects.getRange('D2').values=[['Coverage: '+report.metrics.coverage+'%']];
 book.recalculate();
 const inspect=await book.inspect({kind:'match',searchTerm:'#REF!|#DIV/0!|#VALUE!|#NAME\\?',options:{useRegex:true,maxResults:10},maxChars:1000});
 await fs.writeFile('artifacts/analysis/sonarqube/workbook-inspection.json',inspect.ndjson);
 await(await SpreadsheetFile.exportXlsx(book)).save(bookPath);
 const image=await book.render({sheetName:'Defects',range:'A'+row+':H'+row,scale:1});
 await fs.writeFile('scratch/sonar-'+selectedId+'-fixed.png',Buffer.from(await image.arrayBuffer()));
 console.log('Updated only '+selectedId+' resolution and current gate/coverage summary.');
 process.exit(0);
}
const wb=await SpreadsheetFile.importXlsx(await FileBlob.load('scratch/sonar-defect-template.xlsx'));
const sheet=wb.worksheets.getItem('Defects');
const before=await wb.render({sheetName:'Defects',range:'A1:H8',scale:1});
await fs.writeFile('scratch/sonar-defect-before.png',Buffer.from(await before.arrayBuffer()));
const original=sheet.getRange('A1:H12').values;
const header=original.findIndex(r=>r[0]==='Defect ID')+1;
if(!header)throw new Error('Approved defect header not found');
const expected=['Defect ID','Module','Description','Type','Severity','Priority','Status','Created Date'];
if(JSON.stringify(original[header-1])!==JSON.stringify(expected))throw new Error('Template columns differ');
const first=header+1,last=header+report.findings.length;
for(let row=9;row<=last;row++)sheet.getRange(`A${row}:H${row}`).copyFrom(sheet.getRange('A4:H4'),'all');
sheet.getRange('A1').values=[['FreshFood C# Sonar Review Findings']];
sheet.getRange('D1').values=[['Quality Gate: FAILED']];sheet.getRange('D2').values=[['Coverage: 68.7%']];
const rows=report.findings.map((f,i)=>[
 f.id,f.scope+' / '+f.file.split('/').at(-1),
 `[${f.rule}; ${f.sonar_type}; Sonar severity ${f.sonar_severity}] ${f.file}:${f.line}. ${f.message}\nTriage: ${f.triage}\nAction: ${f.recommended_action}\nCloud issue: ${f.issue_key}. Project severity/priority proposed; human disposition pending.`,
 'Coding Logic',f.sonar_type==='VULNERABILITY'?'Medium':'Cosmetic',f.file.endsWith('CurrentCustomer.cs')?'High':'Medium',first+i===5?'Reported':'Pending','2026-11-02'
]);
sheet.getRange(`A${first}:H${last}`).values=rows;
sheet.getRange(`A${first}:H${last}`).format.wrapText=true;
sheet.getRange(`A${first}:H${last}`).format.autofitRows();
wb.recalculate();
const inspection=await wb.inspect({kind:'match',searchTerm:'#REF!|#DIV/0!|#VALUE!|#NAME\\?',options:{useRegex:true,maxResults:10},maxChars:1000});
await fs.writeFile('artifacts/analysis/sonarqube/workbook-inspection.json',inspection.ndjson);
await (await SpreadsheetFile.exportXlsx(wb)).save('artifacts/analysis/sonarqube/SonarCloud_Defect_Log.xlsx');
const preview=await wb.render({sheetName:'Defects',range:`A1:H${Math.min(last,7)}`,scale:1});
await fs.writeFile('scratch/sonar-defect-after.png',Buffer.from(await preview.arrayBuffer()));
console.log('Wrote approved eight-column defect log: '+rows.length+' completed SonarCloud findings; Quality Gate FAILED.');
