"""Update existing Word baselines without replacing their template hierarchy."""
from pathlib import Path
from docx import Document
from docx.shared import Cm,Pt,Inches
from docx.enum.text import WD_ALIGN_PARAGRAPH
from PIL import Image
import json,hashlib,re,shutil,runpy

R=Path(__file__).resolve().parents[2]
target=R/'artifacts/Requirements_Analysis_Design_Specification.docx'
archive=R/'artifacts/design/baselines/nodejs-20261102'
archive.mkdir(parents=True,exist_ok=True)
for p in [target,R/'artifacts/requirements/Software_Requirements_Specification.docx']:
 backup=archive/p.name
 if not backup.exists():shutil.copy2(p,backup)

def paragraphs(doc):
 yield from doc.paragraphs
 for table in doc.tables:
  for row in table.rows:
   for cell in row.cells:yield from cell.paragraphs

replacements={
 '.NET 8 / ASP.NET Core Web API or Node.js runtime':'ASP.NET Core 10 Web API in C# on .NET 10',
 'Microsoft SQL Server 2022 or PostgreSQL 16+':'PostgreSQL 16+',
 'Node.js':'ASP.NET Core 10 / C#','NodeJS':'ASP.NET Core 10 / C#',
 'individual transition handlers':'one table-driven OrderStateMachine',
 'VOPC � View of Participating Classes':'VOPC - View of Participating Classes'
}
def update_text(doc):
 for p in paragraphs(doc):
  original=p.text;new=original
  for a,b in replacements.items():new=new.replace(a,b)
  if new!=original:
   if p.runs:
    p.runs[0].text=new
    for run in p.runs[1:]:run.text=''
   else:p.add_run(new)

doc=Document(target)
# Keep the approved hierarchy; remove only old detailed-design content after its heading.
body=doc._element.body;active=False
keep={'Detailed Design','Analysis-to-Design Class Mapping','Use Case Realization','Design Sequence Diagrams','Detailed Design Class Diagrams'}
for element in list(body):
 text=''.join(element.itertext()) if False else ''.join(element.xpath('.//w:t/text()'))
 if element.tag.endswith('}p') and text.strip()=='Detailed Design':active=True;continue
 if not active or element.tag.endswith('}sectPr'):continue
 if element.tag.endswith('}p') and text.strip() in keep:continue
 body.remove(element)
update_text(doc)
heads={p.text.strip():p for p in doc.paragraphs if p.style.name.startswith('Heading')}

def insert(anchor,p):anchor._p.addprevious(p._p);return p
def narrative(anchor,value,bold=False):
 p=doc.add_paragraph();p.add_run(value).bold=bold;p.alignment=WD_ALIGN_PARAGRAPH.JUSTIFY;p.paragraph_format.first_line_indent=Cm(0.5);return insert(anchor,p)
def figure(anchor,path,title,chapter):
 nums=[int(x) for p in doc.paragraphs for x in re.findall(r'^Figure '+str(chapter)+r'\.(\d+)',p.text)]
 number=max(nums,default=0)+1
 p=doc.add_paragraph();p.alignment=WD_ALIGN_PARAGRAPH.CENTER;p.paragraph_format.first_line_indent=Cm(0);p.paragraph_format.keep_with_next=True
 w,h=Image.open(path).size;scale=min(6.2/w,7.8/h)
 p.add_run().add_picture(str(path),width=Inches(w*scale),height=Inches(h*scale));insert(anchor,p)
 cap=narrative(anchor,f'Figure {chapter}.{number}: {title}',True);cap.alignment=WD_ALIGN_PARAGRAPH.CENTER;cap.paragraph_format.first_line_indent=Cm(0);cap.paragraph_format.space_before=Pt(3);cap.paragraph_format.space_after=Pt(6)
def table(anchor,headers,rows,title):
 nums=[int(x) for p in doc.paragraphs for x in re.findall(r'^Table 5\.(\d+)',p.text)]
 cap=narrative(anchor,f'Table 5.{max(nums,default=0)+1}: {title}',True);cap.paragraph_format.first_line_indent=Cm(0);cap.paragraph_format.keep_with_next=True
 t=doc.add_table(rows=1,cols=len(headers));t.style='Table Grid'
 for c,v in zip(t.rows[0].cells,headers):c.text=v
 for row in rows:
  for c,v in zip(t.add_row().cells,row):c.text=str(v)
 for i,row in enumerate(t.rows):
  for c in row.cells:
   for p in c.paragraphs:
    p.paragraph_format.first_line_indent=Cm(0);p.alignment=WD_ALIGN_PARAGRAPH.CENTER if i==0 else WD_ALIGN_PARAGRAPH.JUSTIFY
    for run in p.runs:run.bold=i==0;run.font.size=Pt(9)
 anchor._p.addprevious(t._tbl)

# Replace the existing architecture figure in place, retaining caption and location.
for i,p in enumerate(doc.paragraphs):
 if p.text.startswith('Figure 5.2: Overall System Architecture'):
  prior=doc.paragraphs[i-1]
  for run in list(prior.runs):run._r.getparent().remove(run._r)
  png=R/'artifacts/diagrams/images/high-level-architecture.png';w,h=Image.open(png).size;scale=min(6.2/w,7.8/h)
  prior.add_run().add_picture(str(png),width=Inches(w*scale),height=Inches(h*scale));break

anchor=heads['Detailed Design']
narrative(anchor,'Storage amendment authorized on 2026-11-02: checkout idempotency, durable transition-row evidence and customer audit actor identity share the PostgreSQL transaction with their domain effects. The C# migration retains the existing schema and guarded migration; no live database has been modified.')
storage=json.loads((R/'artifacts/design/database/order-consistency-diagram-exports.json').read_text())
for page in storage['pages']:figure(anchor,R/Path(page['png'].replace('\\','/')),page['name'],5)
for entry in json.loads((R/'artifacts/design/database/order-consistency-schema-catalog.json').read_text()):
 table(anchor,['Column','Type','Constraint','Description'],[[c['name'],c['type'],c['constraint'],c['description']] for c in entry['columns']],entry['name']+' storage amendment')
figure(heads['Analysis Sequence Diagrams'],R/'artifacts/diagrams/images/audit-actor-entity-amendment.png','Customer and Staff Audit Actor Entity Amendment',4)
doc.save(target)

# Reuse the established authoring layout after making its text/counts migration-aware.
p=R/'scripts/modeling/sync_approved_detailed_design.py';s=p.read_text(encoding='utf-8')
s=s.replace('and individual transition handlers','and one table-driven OrderStateMachine')
s=s.replace("'Table 5.38: Approved Analysis to Design Class Mapping'","'Table 5.'+str(max([int(x) for p in doc.paragraphs for x in re.findall(r'^Table 5\\.(\\d+)',p.text)],default=0)+1)+': Analysis to Design Class Mapping'")
s=s.replace('Detailed class and design sequence artifacts approved by the stakeholder on 2026-11-01.','Detailed class and design sequence artifacts were approved on 2026-11-01. The stakeholder explicitly requested the table-driven state-machine replacement, storage amendment and ASP.NET Core C# migration on 2026-11-02.')
s=s.replace("['Design baseline 2026-11-01','2026-11-01','M','Authorized stakeholder','Approved DCD and design sequences synchronized into Chapter V; backend implementation authorized; existing TBDs retained.']","['Technology revision 0.5','2026-11-02','M','Authorized stakeholder','ASP.NET Core 10 C# migration; table-driven OrderStateMachine; storage amendment; class and sequence sources synchronized. Technical review and existing TBDs retained.']")
p.write_text(s,encoding='utf-8')
runpy.run_path(str(p),run_name='__main__')

for path in [target,R/'artifacts/requirements/Software_Requirements_Specification.docx']:
 doc=Document(path);update_text(doc)
 for p in doc.paragraphs:
  if p.style.name.startswith('Heading'):
   p.paragraph_format.first_line_indent=Cm(0)
   for run in p.runs:run.bold=True
 doc.save(path)
report={'date':'2026-11-02','basis':'Explicit stakeholder technology and pattern revision requests','master':str(target.relative_to(R)),'sha256':hashlib.sha256(target.read_bytes()).hexdigest(),'class_pages':54,'sequence_pages':29,'storage_pages':3,'audit_entity_pages':1,'backend_classifiers':132,'runtime':'ASP.NET Core 10 / C#','status':'Revision for technical review; not release approval'}
(R/'artifacts/design/dotnet-master-sync.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps(report,indent=2))
