import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const base='artifacts/testing/test-design/backend-unit';
const w=await SpreadsheetFile.importXlsx(await FileBlob.load(base+'/FreshFood_Backend_Unit_Test_Cases_v0.1.xlsx'));
for(const [sheetName,range,name] of [['Cover','A2:F12','final-cover'],['FunctionList','A10:H13','final-function-list'],['Test Report','A206:I212','final-report']]){
 const b=await w.render({sheetName,range,scale:1});await fs.writeFile('scratch/unit-test-template/'+name+'.png',Buffer.from(await b.arrayBuffer()));
}
console.log('Final native-compatible workbook previews rendered; no workbook mutation.');

