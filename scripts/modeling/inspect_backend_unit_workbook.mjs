import fs from 'node:fs/promises';
import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const w=await SpreadsheetFile.importXlsx(await FileBlob.load('artifacts/testing/test-design/backend-unit/FreshFood_Backend_Unit_Test_Cases_v0.1.xlsx'));
console.log(w.help('range.hyperlink',{include:'index,examples'}));
for(const [sheetName,range,path] of [['UT111','A1:T7','scratch/unit-test-template/function-header.png'],['UT111','D31:H42','scratch/unit-test-template/function-confirm.png']]) {
 const b=await w.render({sheetName,range,scale:.8});await fs.writeFile(path,Buffer.from(await b.arrayBuffer()));
}

