from pathlib import Path
from docx import Document
from docx.shared import Cm,Pt,Inches
from docx.enum.text import WD_ALIGN_PARAGRAPH
from PIL import Image
import json,csv,shutil,re,hashlib
root=Path.cwd();target=Path('artifacts/Requirements_Analysis_Design_Specification.docx')
backup=Path('scratch/approved-design-before-20261101.docx')
if not backup.exists():shutil.copy2(target,backup)
doc=Document(target)
heads={p.text.strip():p for p in doc.paragraphs if p.style.name.startswith('Heading')}
def insert_before(anchor,p):anchor._p.addprevious(p._p);return p
def text(anchor,t,bold=False):
 p=doc.add_paragraph();p.add_run(t).bold=bold;p.alignment=WD_ALIGN_PARAGRAPH.JUSTIFY;p.paragraph_format.first_line_indent=Cm(0.5);return insert_before(anchor,p)
def table(anchor,headers,rows,caption):
 p=text(anchor,caption,True);p.paragraph_format.first_line_indent=Cm(0);p.paragraph_format.keep_with_next=True
 t=doc.add_table(rows=1,cols=len(headers));t.style='Table Grid'
 for c,s in zip(t.rows[0].cells,headers):c.text=s
 for row in rows:
  for c,s in zip(t.add_row().cells,row):c.text=str(s)
 for i,row in enumerate(t.rows):
  for c in row.cells:
   for p in c.paragraphs:
    p.paragraph_format.first_line_indent=Cm(0);p.alignment=WD_ALIGN_PARAGRAPH.CENTER if i==0 else WD_ALIGN_PARAGRAPH.JUSTIFY
    for r in p.runs:r.bold=i==0;r.font.size=Pt(9)
 anchor._p.addprevious(t._tbl)
# Remove only empty template guidance in the approved detailed-design sections.
for p in list(doc.paragraphs):
 if p.text.startswith('[Guidance:') and ('Detailed Design Class' in p.text or 'Model detailed interactions' in p.text):p._p.getparent().remove(p._p)
map_anchor=heads['Use Case Realization'];seq_anchor=heads['Detailed Design Class Diagrams']
text(map_anchor,'Detailed class and design sequence artifacts were approved on 2026-11-01. The stakeholder explicitly requested the table-driven state-machine replacement, storage amendment and ASP.NET Core C# migration on 2026-11-02. Approval authorizes backend realization of UC-C01, UC-C03, UC-C05, UC-C06 and UC-C07. Explicit TBDs remain unresolved and are not silently converted into requirements.')
rows=list(csv.DictReader(Path('artifacts/design/detailed/analysis-to-design-mapping.csv').open(encoding='utf-8-sig')))
table(map_anchor,list(rows[0]),[list(r.values()) for r in rows],'Table 5.'+str(max([int(x) for p in doc.paragraphs for x in re.findall(r'^Table 5\.(\d+)',p.text)],default=0)+1)+': Analysis to Design Class Mapping')
text(heads['Design Sequence Diagrams'],'The five use cases are realized through Web and Mobile entry paths, backend constructor-injected services, repositories and one table-driven OrderStateMachine. Call results terminate at UI boundaries; continuous activations include nested calls and combined fragments. Payment callbacks call CheckoutService through PaymentNoticeHandler, independently of the customer-facing Controller.')
end=doc.add_paragraph();seqs=json.loads(Path('artifacts/design/design-sequence-verification.json').read_text());classes=json.loads(Path('artifacts/design/detailed/diagram-pages.json').read_text())
existing=[int(x) for p in doc.paragraphs for x in re.findall(r'^Figure 5\.(\d+)',p.text)];fig=max(existing,default=0)
inserted=[]
def figure(anchor,png,title):
 global fig
 fig+=1
 p=doc.add_paragraph();p.alignment=WD_ALIGN_PARAGRAPH.CENTER;p.paragraph_format.first_line_indent=Cm(0);p.paragraph_format.keep_with_next=True
 im=Image.open(png);w,h=im.size;scale=min(6.2/w,8.0/h);p.add_run().add_picture(str(png),width=Inches(w*scale),height=Inches(h*scale));insert_before(anchor,p)
 cap=doc.add_paragraph();cap.alignment=WD_ALIGN_PARAGRAPH.CENTER;cap.paragraph_format.first_line_indent=Cm(0);cap.paragraph_format.space_before=Pt(3);cap.paragraph_format.space_after=Pt(6);cap.add_run(f'Figure 5.{fig}: {title}').bold=True;insert_before(anchor,cap);inserted.append(str(png))
for r in seqs:
 for pg in r['pages']:figure(seq_anchor,Path(pg['png']),r['use_case']+' Design Sequence '+pg['name'])
for pg in classes:
 png=pg.get('png') or pg.get('image')
 if not png:raise ValueError(str(pg.keys()))
 figure(end,Path(png),str(pg['owner'])+' Detailed Class Design '+pg['title'])
m=json.loads(Path('artifacts/design/detailed/detailed-class-model.json').read_text(encoding='utf-8-sig'))
text(end,'Detailed class specifications',True)
for name,c in m['classes'].items():
 text(end,name+' | '+c['package']+' | '+c['role'],True)
 text(end,'Attributes: '+'; '.join(c['attributes']) if c['attributes'] else 'Attributes: none specified.')
 text(end,'Operations: '+'; '.join(c['operations']) if c['operations'] else 'Operations: none specified.')
text(end,'Implementation boundaries and unresolved technical decisions: '+Path('artifacts/design/design-sequence-diagrams.md').read_text(encoding='utf-8').split('## Review limits and unresolved issues',1)[1].split('## Page and image index',1)[0].replace('\n',' '))
for p in doc.paragraphs:
 if p.style.name.startswith('Heading'):
  p.paragraph_format.first_line_indent=Cm(0)
  for r in p.runs:r.bold=True
# Preserve the existing record-of-changes schema.
for t in doc.tables:
 if len(t.columns)==5 and 'Version' in t.cell(0,0).text:
  row=t.add_row().cells
  for c,v in zip(row,['Technology revision 0.5','2026-11-02','M','Authorized stakeholder','ASP.NET Core 10 C# migration; table-driven OrderStateMachine; storage amendment; class and sequence sources synchronized. Technical review and existing TBDs retained.']):c.text=v
  break
doc.save(target)
report={'approval_date':'2026-11-01','basis':'Explicit stakeholder approval in this conversation','master':str(target),'embedded_sequence_pages':29,'embedded_class_pages':len(classes),'class_specifications':len(m['classes']),'images':inserted,'sha256':hashlib.sha256(target.read_bytes()).hexdigest()}
Path('artifacts/design/approved-design-master-sync.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps({k:v for k,v in report.items() if k!='images'},indent=2))
