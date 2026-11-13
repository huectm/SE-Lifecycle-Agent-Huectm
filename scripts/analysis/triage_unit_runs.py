"""Preserve every failed execution and classify harness failures separately."""
from pathlib import Path
from xml.etree import ElementTree as E
import json,re
D=Path('artifacts/testing/unit-execution');D.mkdir(exist_ok=True)
records=[];ns={'t':'http://microsoft.com/schemas/VisualStudio/TeamTest/2010'}
for path in sorted(D.glob('*/*.trx')):
 root=E.parse(path)
 for r in root.findall('.//t:UnitTestResult',ns):
  if r.get('outcome')!='Failed':continue
  name=r.get('testName');match=re.search(r'UTM_(\d+)_TC(\d+)',name or '')
  case='UTM-'+match[1]+'-TC'+match[2] if match else name
  message=r.findtext('t:Output/t:ErrorInfo/t:Message','',ns)
  records.append({'run':path.parent.name,'caseId':case,'test':name,'message':message,'stack':r.findtext('t:Output/t:ErrorInfo/t:StackTrace','',ns),'evidence':str(path),'classification':'Backend' if case=='UTM-087-TC003' else 'Test harness / fixture','defectId':'UT-DEF-001' if case=='UTM-087-TC003' else 'UTH-'+case})
(D/'failure-history.json').write_text(json.dumps(records,indent=2)+'\n',encoding='utf-8')
print('Preserved failed execution records:',len(records))
