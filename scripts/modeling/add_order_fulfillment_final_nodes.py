from pathlib import Path
from docx import Document
import hashlib,subprocess,csv,json,shutil
R=Path.cwd();src=R/'scratch/generate_order_state_machine.py';doc=R/'artifacts/Requirements_Analysis_Design_Specification.docx';im=R/'artifacts/diagrams/images/order-state-machine.png'
B=R/'scratch/order-final-node-before';B.mkdir(exist_ok=True)
for p in [src,doc,im,R/'artifacts/diagrams/state-machine/order-state-machine.drawio']:
 shutil.copy2(p,B/p.name)
old=hashlib.sha256(im.read_bytes()).hexdigest();s=src.read_text(encoding='utf-8');needle="text(r,'notes','<b>Confirmed modeling decision</b>"
a=s.index(needle)
add="""# Final nodes complete the fulfillment region; financial tracking is modeled separately.
for fid,x,y,source,ports,points in [
 ('final_delivered',1715,1160,'delivered',(.5,1,.5,0),[]),
 ('final_returned',465,1160,'returned',(.5,1,.5,0),[]),
 ('final_cancelled',35,800,'cancelled',(0,.5,.5,0),[(50,710)])]:
 node(r,fid,'',x,y,30,30,'ellipse;fillColor=#ffffff;strokeColor=#263238;strokeWidth=2;')
 node(r,fid+'_center','',x+7,y+7,16,16,'ellipse;fillColor=#263238;strokeColor=#263238;')
 edge(r,'F_'+source,source,fid,ports,points,'',(0,0,0,0),'Stakeholder request: explicit UML final node for fulfillment completion',p)
 text(r,fid+'_caption','End fulfillment',max(0,x-65),y+34,160,28,14)
"""
s=s[:a]+add+s[a:];s=s.replace('Returned means complete physical receipt. Confirmed cause determines fees/refund; staff quality disposition is separate.','Final nodes end fulfillment only. Payment/refund and staff inventory disposition remain separately tracked.')
src.write_text(s,encoding='utf-8');subprocess.run([str(R/'.venv-robot/Scripts/python.exe'),str(src)],check=True)
d=Document(doc);replaced=0
for part in d.part.package.parts:
 if part.content_type.startswith('image/') and hashlib.sha256(part.blob).hexdigest()==old:part._blob=im.read_bytes();replaced+=1
assert replaced==1,replaced
note=' UML final nodes after Delivered, Cancelled and Returned complete the fulfillment region only. They do not assert settled refunds, completed inventory disposition, deletion of the order or a new persisted OrderStatus.'
for p in d.paragraphs:
 if p.text.startswith('Stakeholder correction 2026-10-29:'):p.add_run(note);break
d.save(doc)
p=R/'artifacts/analysis/order-state-analysis.md';s=p.read_text(encoding='utf-8');a=s.index('| ID | Diagram page');b=s.index('## Artifacts and limits',a)
rows=list(csv.DictReader((R/'artifacts/analysis/order-state-traceability.csv').open(encoding='utf-8-sig')))
t='| ID | Diagram page | Source → target | Trigger / guard |\n|---|---|---|---|\n'
for row in rows:t+='| '+' | '.join([row['id'],row['page'],row['source']+' → '+row['target'],row['label'].replace('\n','; ') or 'Completion transition'])+' |\n'
s=s[:a]+t+'\n'+s[b:];s=s.replace('21 traceable transitions','24 traceable transitions');s+='\n## Fulfillment final nodes\n\n'+note.strip()+' Completion transitions follow each terminal fulfillment state. Delivery Failed is not final because warehouse return acknowledgment is still required. Final-node notation introduces no new business status or payout policy.\n';p.write_text(s,encoding='utf-8')
p=R/'artifacts/analysis/order-state-verification.json';v=json.loads(p.read_text());v['final_nodes']=['final_delivered','final_cancelled','final_returned'];v['final_scope']='Fulfillment region only; financial state machines remain independent';v['master_image_synchronized']=True;p.write_text(json.dumps(v,indent=2))
print('Added three UML final nodes and synchronized master document; 24 transitions.')
