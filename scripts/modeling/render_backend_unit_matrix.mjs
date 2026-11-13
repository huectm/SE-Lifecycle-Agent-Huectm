import fs from 'node:fs/promises';
import {FileBlob, SpreadsheetFile} from '@oai/artifact-tool';
const base='artifacts/testing/test-design/backend-unit';
const layout=JSON.parse(await fs.readFile(base+'/unit-test-matrix-row-map.json','utf8'));
const w=await SpreadsheetFile.importXlsx(await FileBlob.load(base+'/FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx'));
const sample=layout.methods.find(x=>x.id==='UTM-111')||layout.methods[0];
for(const [sheetName,range,name] of [['Cover','A2:F13','matrix-cover'],[sample.sheet,'A10:L31','matrix-condition'],[sample.sheet,'A'+sample.confirmStart+':L'+sample.lastRow,'matrix-confirm-result'],['Test Report','A206:I212','matrix-report']]){
 const b=await w.render({sheetName,range,scale:1.5});
 await fs.writeFile('scratch/unit-test-template/'+name+'.png',Buffer.from(await b.arrayBuffer()));
}
console.log('Read-only previews rendered.');
