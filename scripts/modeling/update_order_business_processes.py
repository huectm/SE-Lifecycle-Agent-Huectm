from pathlib import Path
import xml.etree.ElementTree as E,html,sys,json
ROOT=Path(__file__).resolve().parents[2];sys.path.insert(0,str(ROOT/'scratch'))
from test_render_drawio import render_drawio_file

def create(kind,code,include_pages):
 mx=E.Element('mxfile',host='app.diagrams.net',agent='SE-Lifecycle-Agent');records=[]
 for title,H,lanes,nodes,edges in include_pages:
  d=E.SubElement(mx,'diagram',id=code+'-'+str(len(mx)),name=title);gm=E.SubElement(d,'mxGraphModel',grid='1',page='1',pageWidth='1900',pageHeight=str(H),background='#ffffff');r=E.SubElement(gm,'root');E.SubElement(r,'mxCell',id='0');E.SubElement(r,'mxCell',id='1',parent='0');boxes={}
  def v(id,value,x,y,w,h,sty):
   c=E.SubElement(r,'mxCell',id=id,value=value,parent='1',vertex='1',style=sty);E.SubElement(c,'mxGeometry',x=str(x),y=str(y),width=str(w),height=str(h),**{'as':'geometry'});return c
  txt='text;html=1;whiteSpace=wrap;align=center;fontFamily=Arial;'
  v('title','<b>'+code+' | '+title+' | '+('BPMN Process' if kind=='bpmn' else 'UML Activity')+'</b>',40,20,1820,50,txt+'fontSize=25;')
  v('scope','Requested revision 2026-10-29 | Confirmed business rules; responsibility / payout gaps explicitly retained',40,75,1820,35,txt+'fontSize=16;')
  v('pool','',55,120,1790,H-180,'rounded=0;fillColor=#ffffff;strokeColor=#455A64;')
  for idx,(label,x,w) in enumerate(lanes):
   v('lane_'+str(idx),'',x,170,w,H-230,'rounded=0;fillColor=none;strokeColor=#CFD8DC;')
   v('lane_head_'+str(idx),'<b>'+html.escape(label)+'</b>',x,125,w,42,txt+'fontSize=17;fillColor=#E8EEF3;')
  for id,label,x,y,w,h,typ in nodes:
   style='html=1;whiteSpace=wrap;align=center;verticalAlign=middle;fontFamily=Arial;fontSize=17;strokeColor=#37474F;'
   if typ=='task':style+='rounded=1;arcSize=14;fillColor=#F5FAFD;'
   elif typ=='gateway':style+='rhombus;fillColor=#FFF8E1;'
   elif typ=='parallel':style+='rhombus;fillColor=#ffffff;fontSize=30;'
   elif typ=='start':style+='ellipse;fillColor='+('#ffffff;' if kind=='bpmn' else '#263238;')+'strokeWidth=1.5;'
   else:style+='ellipse;fillColor=#ffffff;strokeWidth=4;'
   value='+' if typ=='parallel' else '' if typ in ['start','end'] else ('X' if kind=='bpmn' else '') if typ=='gateway' else html.escape(label).replace('\n','<br>')
   v(id,value,x,y,w,h,style);boxes[id]=(x,y,w,h)
   if typ in ['start','end']:
    capbox={'pending_end':(925,930,320,70),'no_refund':(1620,2225,220,90)}.get(id,(x-145,y+h+12,w+290,65));v(id+'_caption',html.escape(label).replace('\n','<br>'),*capbox,txt+'fontSize=16;fillColor=#ffffff;')
   if typ=='gateway' and label:
    questions={'confirmed':(1325,535,260,90),'cancel_decision':(965,650,250,80),'full':(675,1240,220,70)}
    qbox=questions.get(id,(x-260,y,240,90));v(id+'_question',html.escape(label).replace('\n','<br>'),*qbox,txt+'fontSize=16;fillColor=#ffffff;')
   if typ=='end' and kind!='bpmn':v(id+'_final','',x+9,y+9,w-18,h-18,'ellipse;fillColor=#263238;strokeColor=#263238;')
  for id,src,tgt,ports,points,label,lb in edges:
   ex,ey,ix,iy=ports;a=boxes[src];b=boxes[tgt];route=[(a[0]+a[2]*ex,a[1]+a[3]*ey)]+points+[(b[0]+b[2]*ix,b[1]+b[3]*iy)]
   for (x1,y1),(x2,y2) in zip(route,route[1:]):
    assert x1==x2 or y1==y2,(code,id,'diagonal')
    for oid,(x,y,w,h) in boxes.items():
     if oid in [src,tgt]:continue
     hit=(x<x1<x+w and max(min(y1,y2),y)<min(max(y1,y2),y+h)) if x1==x2 else (y<y1<y+h and max(min(x1,x2),x)<min(max(x1,x2),x+w))
     assert not hit,(code,id,oid)
   c=E.SubElement(r,'mxCell',id=id,value='',edge='1',parent='1',source=src,target=tgt,style=f'edgeStyle=orthogonalEdgeStyle;rounded=0;endArrow=block;endFill=1;strokeWidth=1.6;strokeColor=#455A64;jumpStyle=arc;exitX={ex};exitY={ey};entryX={ix};entryY={iy};exitPerimeter=1;entryPerimeter=1;labelBackgroundColor=#ffffff;')
   g=E.SubElement(c,'mxGeometry',relative='1',**{'as':'geometry'});arr=E.SubElement(g,'Array',**{'as':'points'})
   for x,y in points:E.SubElement(arr,'mxPoint',x=str(x),y=str(y))
   if label:v(id+'_label',html.escape(label).replace('\n','<br>'),*lb,txt+'fontSize=15;fillColor=#ffffff;')
   records.append(dict(process=code,page=title,transition=id,label=label,source=src,target=tgt))
 return mx,records
# All gateways express business decisions; user/manual and system work is assigned by the vertical lane headers.
BP02=[('Stock-Backed Order Acceptance',1700,[('FreshFood System',55,1790)],[
 ('start','Order submission received',480,200,40,40,'start'),('stock','Validate checkout and sellable on-hand stock\nLock FEFO batches; subtract reservations',280,340,440,110,'task'),('available','All lines\navailable?',455,550,90,90,'gateway'),('create','Assess verified payment at accepted checkout\nKeep all stock reservations in one transaction',280,740,440,110,'task'),('paid','Verified\npayment?',455,970,90,90,'gateway'),('record','Create Pending Paid order; record allocations\nCommit all reservations; clear cart',1010,1090,520,120,'task'),('unpaid','Create Pending Unpaid order\nCommit all reservations; clear cart',280,1120,440,110,'task'),('merge','',465,1350,70,70,'gateway'),('accepted','Await store approval',480,1540,40,40,'end'),('reject','Reject entire submission\nNo order or partial reservation committed',1050,540,440,110,'task'),('rejected','Submission rejected',1660,575,40,40,'end')],[
 ('b1','start','stock',(.5,1,.5,0),[],'',(0,0,0,0)),('b2','stock','available',(.5,1,.5,0),[],'',(0,0,0,0)),('b3','available','create',(.5,1,.5,0),[],'Yes',(540,665,150,40)),('b4','available','reject',(1,.5,0,.5),[],'No',(740,540,180,45)),('b5','reject','rejected',(1,.5,0,.5),[],'',(0,0,0,0)),('b6','create','paid',(.5,1,.5,0),[],'',(0,0,0,0)),('b7','paid','record',(1,.5,.5,0),[(1270,1015)],'Yes',(760,950,220,40)),('b8','paid','unpaid',(.5,1,.5,0),[],'Not paid',(535,1060,200,40)),('b8u','unpaid','merge',(.5,1,.5,0),[],'',(0,0,0,0)),('b9','record','merge',(.5,1,1,.5),[(1270,1385)],'',(0,0,0,0)),('b10','merge','accepted',(.5,1,.5,0),[],'',(0,0,0,0))])]
BP03=[('Store Approval and Dispatch',1730,[('System / Order records',55,700),('Store Staff',755,1090)],[
 ('start','Accepted Pending Unpaid / Pending Paid order',380,200,40,40,'start'),('required','First order\nAND unpaid?',355,360,90,90,'gateway'),('call','Call customer to confirm the order',1050,350,440,110,'task'),('confirmed','Customer\nconfirmed?',1225,550,90,90,'gateway'),('cancel_decision','Staff\ncancels?',855,650,90,90,'gateway'),('cancel','Record explicit cancellation and reason\nRelease original reservations exactly once',180,790,440,120,'task'),('cancel_end','Cancelled',380,1040,40,40,'end'),('pending_end','Keep current initial state; no retry deadline',880,930,40,40,'end'),('approve','Approve order as Confirmed\nRecheck current payment / required call evidence',1050,1090,440,120,'task'),('dispatch','Packing -> Shipping\nRequire packing documents and assigned agent',180,1330,440,120,'task'),('shipping','Shipping; continue with delivery outcome',380,1580,40,40,'end')],[
 ('a1','start','required',(.5,1,.5,0),[],'',(0,0,0,0)),('a2','required','call',(1,.5,0,.5),[],'Yes',(670,335,200,45)),('a3','call','confirmed',(.5,1,.5,0),[],'',(0,0,0,0)),('a4','required','approve',(.5,1,0,.5),[(400,490),(780,490),(780,1150)],'No: paid first order or repeat order',(480,515,280,65)),('a5','confirmed','approve',(.5,1,.5,0),[],'Yes',(1320,800,220,45)),('a6','confirmed','cancel_decision',(0,.5,.5,0),[(900,595)],'No',(1010,545,170,45)),('a7','cancel_decision','cancel',(0,.5,.5,0),[(400,695)],'Staff elects cancellation',(430,705,300,55)),('a8','cancel_decision','pending_end',(.5,1,.5,0),[],'No',(950,800,150,45)),('a9','cancel','cancel_end',(.5,1,.5,0),[],'',(0,0,0,0)),('a10','approve','dispatch',(.5,1,1,.5),[(1270,1390)],'',(0,0,0,0)),('a11','dispatch','shipping',(.5,1,.5,0),[],'',(0,0,0,0))]),
 ('Delivery Outcome, Physical Return and Independent Disposition',2770,[('Sales / Delivery reporting',55,600),('Warehouse Staff',655,600),('System',1255,590)],[
 ('start','Delivery outcome received',335,200,40,40,'start'),('success','Delivery\nsucceeded?',310,360,90,90,'gateway'),('delivered','Record Delivered\nFinalize reserved stock and revenue',1320,350,460,110,'task'),('delivered_end','Delivered',1530,570,40,40,'end'),('failure','Record Delivery Failed, reason and evidence\nDo not infer deliberate customer refusal',110,620,480,120,'task'),('receive','Count actual goods against original order lines\nRecord warehouse receipt',710,1040,480,120,'task'),('full','All goods\nreceived?',905,1330,90,90,'gateway'),('draft','Keep incomplete receipt facts\nFull-return auto-refund path not eligible',110,1530,480,110,'task'),('draft_end','Incomplete return; separate policy TBD',330,1790,40,40,'end'),('returned','Confirm Returned with receiver/time\nDo not automatically expose sellable stock',1320,1320,460,120,'task'),('parallel','+',1505,1600,90,90,'parallel'),('inspect','Staff inspect quality and decide disposition\nSystem records authorized stock handling',710,1860,480,130,'task'),('inspect_end','Staff inventory disposition recorded',930,2200,40,40,'end'),('fees','Resolve fee liability from confirmed cause\nProduct fault: waive / refund ship\nDeliberate refusal: retain / collect ship\nRecord actual agent collection / compensation',1320,1840,460,160,'task'),('eligible','Paid goods +\nconfirmed cause?',1505,2120,90,90,'gateway'),('refund','Queue idempotent automatic refund\nGoods + paid ship for product fault\nGoods only for deliberate refusal\nDo not wait for quality inspection',1320,2370,460,150,'task'),('refund_end','Refund initiated; track settlement separately',1530,2620,40,40,'end'),('no_refund','No auto-refund: unpaid goods or unresolved cause',1680,2145,40,40,'end')],[
 ('c1','start','success',(.5,1,.5,0),[],'',(0,0,0,0)),('c2','success','delivered',(1,.5,0,.5),[(1100,405),(1100,405)],'Yes',(840,345,220,45)),('c3','delivered','delivered_end',(.5,1,.5,0),[],'',(0,0,0,0)),('c4','success','failure',(.5,1,.5,0),[(355,510),(350,510)],'No',(380,500,160,45)),('c5','failure','receive',(.5,1,.5,0),[(350,900),(950,900)],'Physical handover back to warehouse',(430,835,450,55)),('c6','receive','full',(.5,1,.5,0),[],'',(0,0,0,0)),('c7','full','draft',(0,.5,.5,0),[(350,1375)],'No',(550,1400,220,45)),('c8','draft','draft_end',(.5,1,.5,0),[],'',(0,0,0,0)),('c9','full','returned',(1,.5,0,.5),[(1160,1375),(1160,1380)],'Yes',(1090,1300,180,45)),('c10','returned','parallel',(.5,1,.5,0),[],'Independent branches',(1580,1500,245,60)),('c11','parallel','inspect',(0,.5,.5,0),[(950,1645)],'',(0,0,0,0)),('c12','parallel','fees',(.5,1,.5,0),[],'',(0,0,0,0)),('c13','inspect','inspect_end',(.5,1,.5,0),[],'',(0,0,0,0)),('c14','fees','eligible',(.5,1,.5,0),[],'',(0,0,0,0)),('c15','eligible','refund',(.5,1,.5,0),[],'Yes',(1320,2260,200,45)),('c16','eligible','no_refund',(1,.5,0,.5),[],'No',(1630,2090,120,40)),('c17','refund','refund_end',(.5,1,.5,0),[],'',(0,0,0,0))])]
records=[]
for code,pages,activity,stem in [('BP-02',BP02,'bp02-online-ordering-activity-diagram.drawio','bp02-order-acceptance'),('BP-03',BP03,'bp03-order-fulfillment-activity-diagram.drawio','bp03-fulfillment-returns')]:
 for kind,path in [('bpmn',ROOT/f'artifacts/diagrams/business-process/{stem}.drawio'),('activity',ROOT/f'artifacts/diagrams/activity/{activity}')]:
  mx,trace=create(kind,code,pages);records+=trace if kind=='bpmn' else[];E.indent(mx);E.ElementTree(mx).write(path,encoding='utf-8',xml_declaration=True)
  for i,(_,H,*_) in enumerate(pages):
   if kind=='bpmn':png=ROOT/f'artifacts/diagrams/images/{stem}{"" if i==0 else "-"+str(i+1)}.png'
   else:png=ROOT/f'artifacts/diagrams/images/{"bp02-online-ordering-activity" if code=="BP-02" else "bp03-order-fulfillment-activity"}{"" if i==0 else "-"+str(i+1)}.png'
   render_drawio_file(str(path),i,str(png),width=1940,height=H+70)
(ROOT/'artifacts/analysis/order-business-process-verification.json').write_text(json.dumps({'status':'Requested revision for review','routing':'All transitions obstacle-checked; explicit ports; all source masters saved before image export','transitions':records},indent=2),encoding='utf-8')
print('Updated BP-02/BP-03 BPMN sources, legacy UML Activity views and PNGs.')

