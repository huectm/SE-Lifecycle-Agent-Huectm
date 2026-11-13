import {FileBlob,SpreadsheetFile} from '@oai/artifact-tool';
const w=await SpreadsheetFile.importXlsx(await FileBlob.load('artifacts/traceability/Requirements_Traceability_Matrix.xlsx'));
const r=w.worksheets.getItem('RTM').getRange('A4:G300').values;console.log(JSON.stringify(r.filter(x=>String(x[3]).includes('UC-C')).map(x=>x.slice(0,4)).slice(0,35)));
const q=w.worksheets.getItem('Requirements').getRange('A4:F300').values;console.log(JSON.stringify(q.filter(x=>/^FR-(CAT|BRW|CRT|PRF|MYO)/.test(x[0]||'')).map(x=>[x[0],String(x[2]).slice(0,90)])));
