"""Synchronize the explicitly authorized unit-test design before automation."""
from pathlib import Path
import json,hashlib,shutil,re
from docx import Document
from docx.shared import Cm,Pt
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.enum.table import WD_TABLE_ALIGNMENT
D=Path('artifacts/testing/test-design/backend-unit')
target=Path('artifacts/Requirements_Analysis_Design_Specification.docx')
backup=D/'baseline-20261105';backup.mkdir(exist_ok=True)
if not (backup/target.name).exists():shutil.copy2(target,backup/target.name)
design=json.loads((D/'backend-unit-test-design.json').read_text(encoding='utf-8'))
doc=Document(target)
heading='Unit Test Design Baseline'
assert not any(p.text==heading for p in doc.paragraphs),'Already synchronized; do not duplicate.'
p=doc.add_heading(heading,3)
for run in p.runs:run.bold=True
def paragraph(text):
 p=doc.add_paragraph(text);p.alignment=WD_ALIGN_PARAGRAPH.JUSTIFY;p.paragraph_format.first_line_indent=Cm(.5)
 return p
paragraph('Authorization 2026-11-05: the stakeholder instructed creation of the unit-test project and class-organized scripts, execution, defect logging, correction and retesting. This authorizes automation of the version 0.2 design. It does not assert measured coverage or approval of unresolved business rules and testability changes.')
paragraph('The approved workbook FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx retains the project template selection matrix. There are 193 executable method declarations, 85 interface contracts, and 1,190 planned cases. Conditions and confirmation criteria are listed on the left and selected with O in case columns. Actual execution results remain separate evidence and are not inferred from design approval.')
paragraph('Isolation strategy: strict interface fakes and an immediate transaction harness; no live payment, notification or database is counted as an isolated unit test. Private members are accessed through public behavior where practical; narrowly scoped test-only reflection preserves production visibility. Symbolic vectors without concrete witnesses remain blocked, and PostgreSqlSession component cases are reported separately. No new production transport seam is silently introduced.')
number=max([int(x) for p in doc.paragraphs for x in re.findall(r'^Table 5\.(\d+)',p.text)],default=0)
for m in design['methods']:
 number+=1
 cap=doc.add_paragraph(f'Table 5.{number}: {m["id"]} {m["type"]} {m["name"]} Unit Test Design')
 cap.paragraph_format.first_line_indent=Cm(0);cap.paragraph_format.keep_with_next=True
 for run in cap.runs:run.bold=True
 paragraph(m['signature']+'; source '+m['file']+':'+str(m['line'])+'; use cases '+', '.join(m['useCases'])+'.')
 table=doc.add_table(rows=1, cols=3);table.style='Table Grid';table.alignment=WD_TABLE_ALIGNMENT.CENTER
 for cell,text in zip(table.rows[0].cells,['Case and technique','Input and prerequisites','Expected result and review constraint']):cell.text=text
 for c in m['cases']:
  cells=table.add_row().cells
  values=[c['id']+'\n'+c['inputType']+'; '+c['technique'],json.dumps(c['data'],ensure_ascii=True)+'\n'+c['preconditions']+'\n'+c['steps'],c['expected']+'\nException: '+c['exception']+'\nEffects: '+c['sideEffects']+'\nConstraint: '+c['gap']]
  for cell,text in zip(cells,values):cell.text=text
 for ri,row in enumerate(table.rows):
  for cell in row.cells:
   for p in cell.paragraphs:
    p.paragraph_format.first_line_indent=Cm(0);p.alignment=WD_ALIGN_PARAGRAPH.CENTER if ri==0 else WD_ALIGN_PARAGRAPH.JUSTIFY
    for run in p.runs:run.font.size=Pt(8);run.bold=ri==0
try:
 doc.save(target)
except PermissionError:
 pending=backup/'master-with-approved-unit-design.docx'
 doc.save(pending)
 print('Master is open in Word; pending complete synchronization saved to',pending)
 raise SystemExit(2)
record={'date':'2026-11-05','scope':'Create project, scripts, run, log defects, fix and retest','source':'Explicit stakeholder instruction in this session','workbook':'FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx','methods':193,'plannedCases':1190,'masterSynchronized':True,'masterSha256':hashlib.sha256(target.read_bytes()).hexdigest(),'unresolvedConstraintsRemainExplicit':True}
(D/'automation-authorization.json').write_text(json.dumps(record,indent=2)+'\n',encoding='utf-8')
print('Approved design synchronized:',len(design['methods']),'method tables; existing chapters preserved.')
