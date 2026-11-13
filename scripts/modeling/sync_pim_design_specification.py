"""Synchronize the stakeholder-authorized PIM correction without duplicating prior chapters."""
from pathlib import Path
from docx import Document
import shutil,json
root=Path.cwd();target=Path('artifacts/Requirements_Analysis_Design_Specification.docx')
backup=Path('artifacts/design/baselines/mixed-psm-20261103/Requirements_Analysis_Design_Specification.docx')
if not backup.exists():shutil.copy2(target,backup)
doc=Document(target);body=doc._element.body;active=False
keep={'Analysis-to-Design Class Mapping','Use Case Realization','Design Sequence Diagrams','Detailed Design Class Diagrams'}
for element in list(body):
 text=''.join(element.itertext()) if False else ''.join(element.xpath('.//w:t/text()')).strip()
 if element.tag.endswith('}p') and text=='Detailed Design':active=True;continue
 if active and not element.tag.endswith('}sectPr'):
  if element.tag.endswith('}p') and text in keep:continue
  body.remove(element)
doc.save(target)
s=Path('scripts/modeling/sync_approved_detailed_design.py').read_text(encoding='utf-8-sig')
s=s.replace('Technology revision 0.5','PIM revision 0.6').replace("'2026-11-02','M'","'2026-11-03','M'")
s=s.replace('ASP.NET Core 10 C# migration; table-driven OrderStateMachine; storage amendment; class and sequence sources synchronized. Technical review and existing TBDs retained.','Stakeholder-authorized PIM correction; explicit PIM-to-C# mapping; class and sequence sources synchronized. Technical review and deferred integrations retained.')
s=s.replace("'approval_date':'2026-11-01'","'revision_date':'2026-11-03','model_level':'PIM'")
s=s.replace('approved-design-master-sync.json','pim-master-sync.json')
s=s.replace('row=t.add_row().cells', "row=next((existing.cells for existing in t.rows if existing.cells[0].text=='PIM revision 0.6'),None) or t.add_row().cells")
s=s.replace("rows=list(csv.DictReader", "text(map_anchor,'PIM revision 0.6 (2026-11-03): logical contracts exclude framework wrappers, cancellation tokens, HTTP binding and database-driver types. The explicit PIM-to-C# mapping records these implementation refinements; deferred integrations and frontend-only designs are not claimed implemented.')\nrows=list(csv.DictReader",1)
needle="text(heads['Design Sequence Diagrams']"
insertion="""mapping=json.loads(Path('artifacts/design/detailed/pim-to-code-mapping.json').read_text(encoding='utf-8'))
maprows=[]
for entry in mapping['operations']:
 members=entry.get('sourceMembers',[])
 mapped='; '.join((x.get('name','')+'('+', '.join(p['name']+': '+p['type'] for p in x.get('parameters',[]))+'): '+x.get('returnType','')+' ['+x.get('file','')+':'+str(x.get('line',''))+']') for x in members) or entry['sourceClass']
 maprows.append([entry['pimClass']+' :: '+entry['pimOperation'], mapped, entry['status']])
table(map_anchor,['PIM logical operation','C# realization / framework role','Realization status'],maprows,'Table 5.'+str(max([int(x) for p in doc.paragraphs for x in re.findall(r'^Table 5\\.(\\d+)',p.text)],default=0)+1)+': PIM to Source Operation Mapping')
text(map_anchor,'Implementation remediation verified 2026-11-04: all 18 original SonarCloud issues are FIXED; 67 tests passed, with no issue suppression. Quantity and Rating are required JSON members; nullable optional IsDefault/ClearanceOnly inputs explicitly default to false. A dedicated ASP.NET model binder preserves the webhook body and verification headers. Regex execution is bounded to 100 ms; logical patterns and state transitions are preserved. Detailed execution and defect evidence is recorded in artifacts/analysis/sonarqube/fix-log.md and SonarCloud_Defect_Log.xlsx. Coverage is 73.2%, below the unchanged 80% gate; release readiness is not asserted.')
text(map_anchor,'Detailed source locations and adaptation rules are maintained in artifacts/design/detailed/pim-to-code-mapping.csv and .json. Status counts: 218 implemented, 7 framework refinements, 114 frontend design-only and 8 deferred integrations. RepositorySession maps to PostgreSqlSession; logical value objects map to exact C# and JSON representations. Route binding and trusted identity resolution are explicit platform refinements.')
"""
s=s.replace(needle,insertion+needle,1)
exec(compile(s,'sync_approved_detailed_design.py','exec'))
