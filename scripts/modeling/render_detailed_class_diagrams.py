from pathlib import Path
import json,xml.etree.ElementTree as E,html,math,heapq,textwrap,hashlib,sys,copy
R=Path.cwd();M=json.loads((R/'artifacts/design/detailed/detailed-class-model.json').read_text());C=M['classes'];records=[]
OUT=R/'artifacts/diagrams/class';IM=R/'artifacts/diagrams/images';W=680;G=360

def wrap(s):return textwrap.wrap(s,width=70,break_long_words=False,break_on_hyphens=False) or ['']
def height(c):return 112+21*sum(len(wrap(s)) for s in c['attributes']+c['operations'])+(30 if c['attributes'] else 0)+(30 if c['operations'] else 0)
def segment_clear(a,b,boxes):
 x1,y1=a;x2,y2=b
 for x,y,w,h in boxes:
  if x1==x2 and x<x1<x+w and max(min(y1,y2),y)<min(max(y1,y2),y+h):return False
  if y1==y2 and y<y1<y+h and max(min(x1,x2),x)<min(max(x1,x2),x+w):return False
 return True

from diagram_layout_routing import route,label_box

def v(root,id,value,box,style):
 c=E.SubElement(root,'mxCell',id=id,value=value,vertex='1',parent='1',style=style);x,y,w,h=box;E.SubElement(c,'mxGeometry',x=str(x),y=str(y),width=str(w),height=str(h),**{'as':'geometry'});return c
textstyle='text;html=1;whiteSpace=wrap;align=center;fontFamily=Arial;fillColor=#ffffff;'
masters=[]
for owner in list(M['scope'])+['shared','transitions']:
 ps=[p for p in M['pages'] if p['owner']==owner];mx=E.Element('mxfile',host='app.diagrams.net',agent='SE-Lifecycle-Agent',version='24.7.17');slug=M['scope'][owner]['slug'] if owner in M['scope'] else 'shared-di' if owner=='shared' else 'state-transitions';stem=owner.lower()+'-'+slug+'-design-classes' if owner in M['scope'] else slug+'-design-classes'
 for pi,p in enumerate(ps,1):
  ns=p['classes'];degree={n:sum(e['source']==n or e['target']==n for e in p['edges']) for n in ns};compact=p.get('compact',False);display={n:copy.deepcopy(C[n]) for n in ns}
  if compact:
   for c in display.values():c['attributes']=c['attributes'][:2];c['operations']=c['operations'][:2]
  member_wrap=lambda value:textwrap.wrap(value,width=44 if compact else 64,break_long_words=False,break_on_hyphens=False) or ['']
  def boxheight(c):return max((185 if compact else 125)+(20 if compact else 23)*sum(len(member_wrap(s)) for s in c['attributes']+c['operations'])+(30 if c['attributes'] else 0)+(30 if c['operations'] else 0),(degree[c['name']]+2)*26)
  if compact:
   cw=500;cg=520;boxes={};bottoms=[]
   for col,lane in enumerate(p['lanes']):
    y=190
    for n in lane:
     h=boxheight(display[n]);boxes[n]=(120+col*(cw+cg),y,cw,h);y+=h+320
    bottoms.append(y)
   assert set(boxes)==set(ns)
   width=240+len(p['lanes'])*cw+(len(p['lanes'])-1)*cg;H=max(bottoms)+100
  else:
   cols=2 if len(ns)<=6 else 3;rows=math.ceil(len(ns)/cols);rowheights=[max(boxheight(display[n]) for n in ns[i*cols:(i+1)*cols]) for i in range(rows)];ys=[190]
   for h in rowheights:ys.append(ys[-1]+h+320)
   boxes={n:(120+(i%cols)*(W+G),ys[i//cols],W,boxheight(display[n])) for i,n in enumerate(ns)};width=240+cols*W+(cols-1)*G;H=ys[-1]+100
  d=E.SubElement(mx,'diagram',id=stem+'-'+str(pi),name=f'{pi:02d} '+p['title']);gm=E.SubElement(d,'mxGraphModel',grid='1',page='1',pageWidth=str(width),pageHeight=str(H),background='#ffffff');root=E.SubElement(gm,'root');E.SubElement(root,'mxCell',id='0');E.SubElement(root,'mxCell',id='1',parent='0')
  v(root,'title','<b>'+html.escape(owner+' - '+p['title'])+'</b>',(40,20,width-80,50),textstyle+'fontSize=27;')
  v(root,'status','PIM detailed design | 2026-11-03 | Backend DI only | Explicit source refinements',(40,85,width-80,45),textstyle+'fontSize=17;')
  for n,box in boxes.items():
   c=display[n];header='<b>&lt;&lt;'+c['role']+'&gt;&gt;<br>'+n+'</b>'
   if compact:header+='<br>'+html.escape('VOPC: '+p['origin_tags'][n])+'<br>'+html.escape('Design: '+p['pattern_tags'][n] if p['pattern_tags'][n] else 'Refined responsibility')+'<br><i>Member excerpt; full detail views follow</i>'
   attrs='<br>'.join(html.escape(line) for a in c['attributes'] for line in member_wrap(a))
   ops='<br>'.join(html.escape(line) for a in c['operations'] for line in member_wrap(a))
   value='<div style="font-size:13px;text-align:center">'+header+'</div>'
   if attrs:value+='<hr><div style="text-align:left;line-height:'+str(20 if compact else 23)+'px">'+attrs+'</div>'
   if ops:value+='<hr><div style="text-align:left;line-height:'+str(20 if compact else 23)+'px">'+ops+'</div>'
   color={'interface':'#FFF8E1','entity':'#F1F8E9','DTO':'#F5F5F5','transition':'#E3F2FD','boundary':'#F3E5F5'}.get(c['role'],'#E8F1FA')
   v(root,n,value,box,'html=1;whiteSpace=wrap;rounded=0;align=left;verticalAlign=top;spacing=12;fontFamily=Arial;fontSize='+str(14 if compact else 17)+';fillColor='+color+';strokeColor=#455A64;')
  routes=[];used=[];sides=[];counts={};seen={};pending_labels=[]
  for e in p['edges']:
   aa=boxes[e['source']];bb=boxes[e['target']];dx=(bb[0]+bb[2]/2)-(aa[0]+aa[2]/2);dy=(bb[1]+bb[3]/2)-(aa[1]+aa[3]/2)
   ab=('E','W') if abs(dx)>abs(dy) and dx>0 else ('W','E') if abs(dx)>abs(dy) else ('S','N') if dy>0 else ('N','S');sides.append(ab)
   for n,side in zip([e['source'],e['target']],ab):counts[(n,side)]=counts.get((n,side),0)+1
  for ei,e in enumerate(p['edges'],1):
   assert e['source'] in boxes and e['target'] in boxes
   pp=[]
   for n,side in zip([e['source'],e['target']],sides[ei-1]):
    key=(n,side);seen[key]=seen.get(key,0)+1;f=seen[key]/(counts[key]+1);pp.extend({'E':(1,f),'W':(0,f),'N':(f,0),'S':(f,1)}[side])
   ports,pts=route(boxes[e['source']],boxes[e['target']],list(boxes.values()),(width,H),pp,used);ex,ey,ix,iy=ports
   used.extend(zip(pts,pts[1:]))
   for aa,bb in zip(pts,pts[1:]):
    assert aa[0]==bb[0] or aa[1]==bb[1]
    assert segment_clear(aa,bb,[b for n,b in boxes.items() if n not in [e['source'],e['target']]])
   style='edgeStyle=orthogonalEdgeStyle;html=1;rounded=0;strokeColor=#455A64;strokeWidth=1.5;labelBackgroundColor=#ffffff;jumpStyle=arc;exitX='+str(ex)+';exitY='+str(ey)+';entryX='+str(ix)+';entryY='+str(iy)+';exitPerimeter=1;entryPerimeter=1;'
   style+= 'dashed=1;endArrow=block;endFill=0;' if e['kind']=='realization' else 'dashed=1;endArrow=open;endFill=0;' if e['kind']=='dependency' else 'dashed=0;endArrow=open;endFill=0;' if e['kind']=='remote' or e['label'] not in ['1 : 0..*','1 : 1..*','1 : 0..1'] else 'dashed=0;endArrow=none;'
   cell=E.SubElement(root,'mxCell',id='e'+str(ei),value='',edge='1',parent='1',source=e['source'],target=e['target'],style=style);g=E.SubElement(cell,'mxGeometry',relative='1',**{'as':'geometry'});arr=E.SubElement(g,'Array',**{'as':'points'})
   for x,y in pts[1:-1]:E.SubElement(arr,'mxPoint',x=str(x),y=str(y))
   if e['kind']=='remote' or e['label'] in ['1 : 0..*','1 : 1..*','1 : 0..1']:pending_labels.append((ei,e['label'],pts))
   routes.append({'source':e['source'],'target':e['target'],'points':pts,'kind':e['kind']})
  label_records=[]
  for ei,label,points in pending_labels:
   lb=label_box(points,label,list(boxes.values()),used,[r['box'] for r in label_records],(width,H));v(root,'label'+str(ei),html.escape(label),lb,textstyle+'fontSize=15;');label_records.append({'edge':'e'+str(ei),'text':label,'box':lb})
  footer='UML: solid line = association; dashed open arrow = DTO/entity usage dependency; dashed hollow triangle = realization.<br>Only backend classes use constructor DI. Frontend classes have ordinary references. HTTPS labels denote remote communication.'
  if compact:footer+=' VOPC origin and applied solution are tagged on each classifier; full attributes/operations are in subsequent detail views.'
  if owner=='transitions':footer+=' OrderStateMachine encapsulates 24 table rows. UML choice/final positions introduce no persisted business status.'
  v(root,'legend',footer,(60,H-90,width-120,75),textstyle+'fontSize=16;')
  records.append({'owner':owner,'page':pi,'title':p['title'],'classes':ns,'width':width,'height':H,'routes':routes,'labels':label_records,'class_boxes':boxes,'compact':compact,'source':(OUT/(stem+'.drawio')).relative_to(R).as_posix(),'image':'artifacts/diagrams/images/'+stem+f'-{pi:02d}.png'})
 path=OUT/(stem+'.drawio');E.indent(mx);E.ElementTree(mx).write(path,encoding='utf-8',xml_declaration=True);masters.append(path)
# Every editable source has been saved and structurally validated before any PNG export.
for path in masters:
 for d in E.parse(path).findall('diagram'):
  ids=[c.get('id') for c in d.findall('.//mxCell')];assert len(ids)==len(set(ids))
(R/'artifacts/design/detailed/diagram-pages.json').write_text(json.dumps(records,indent=2))
print('Validated',len(masters),'Draw.io masters and',len(records),'pages; every connector obstacle-checked.',flush=True)
if '--render' in sys.argv:
 sys.path.insert(0,str(R/'scratch'));from test_render_drawio import render_drawio_file
 for rec in records:
  render_drawio_file(str(R/rec['source']),rec['page']-1,str(R/rec['image']),width=rec['width']+70,height=rec['height']+70)
  rec['png_sha256']=hashlib.sha256((R/rec['image']).read_bytes()).hexdigest()
 (R/'artifacts/design/detailed/diagram-pages.json').write_text(json.dumps(records,indent=2))
 print('Rendered all detailed-design pages.',flush=True)
