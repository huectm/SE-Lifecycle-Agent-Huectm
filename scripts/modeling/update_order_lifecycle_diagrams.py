from pathlib import Path
import xml.etree.ElementTree as E,html,re,json,sys,csv,shutil
ROOT=Path(__file__).resolve().parents[2];sys.path.insert(0,str(ROOT/'scratch'))
from test_render_drawio import render_drawio_file
m=json.loads((ROOT/'artifacts/design/order-lifecycle-model.json').read_text());catalog=json.loads((ROOT/'artifacts/design/database/physical-schema-catalog.json').read_text());bytable={t['name']:t for t in m['tables']};alltables={t['name']:t for t in catalog}
ENTITY={'orders':'Order','order_details':'OrderDetail','staff_accounts':'Staff',**{t['name']:t['entity'] for t in m['tables']}}
records=[]
def camel(s):return re.sub('_([a-z])',lambda a:a[1].upper(),s)
def desc_cols(name,physical,reference=False):
 cols=alltables[name]['columns'] if name in alltables else bytable[name]['columns']
 if reference:cols=[c for c in cols if c['name'] in ['order_id','sub_total','shipping_fee','order_status','payment_status','order_detail_id','batch_id','quantity']]
 if physical:
  return [('PK ' if 'PRIMARY KEY' in c['constraint'] else 'FK ' if 'REFERENCES' in c['constraint'] or 'FK ' in c['constraint'] else '')+c['name']+' : '+c['type'].replace('BIGSERIAL / BIGINT','BIGINT').replace('SERIAL / INT','INT') for c in cols]
 result=[]
 for c in cols:
  if 'PRIMARY KEY' in c['constraint']:continue
  typ='DateTime' if 'TIMESTAMP' in c['type'] else 'Decimal' if 'NUMERIC' in c['type'] or 'DECIMAL' in c['type'] else 'Boolean' if 'BOOLEAN' in c['type'] else 'Integer' if 'INT' in c['type'] else 'String'
  if c['name'].endswith('_id'):
   for key,entity in ENTITY.items():
    if key in c['constraint']:typ=entity;break
  if c['name']=='idempotency_key':continue
  typ={'payment_method':'PaymentMethod','payment_status':'PaymentStatus','order_status':'OrderStatus','phone_confirmation_status':'PhoneConfirmationResult','failure_cause':'DeliveryFailureCause','refund_status':'RefundStatus','receipt_status':'ReturnReceiptStatus','disposition':'StockDisposition','customer_id':'Customer','delivery_address_id':'CustomerAddress','batch_id':'BatchInventory'}.get(c['name'],typ)
  result.append(camel(c['name'])+': '+typ+(' {derived}' if 'GENERATED ALWAYS' in c['constraint'] else '')+(' [0..1]' if 'NOT NULL' not in c['constraint'] and 'DEFAULT' not in c['constraint'] and 'GENERATED' not in c['constraint'] else ''))
 if name=='orders' and not reference:result += ['phoneConfirmationRequired: Boolean {derived}']
 return result

def add_page(mx,pid,title,physical,kind):
 d=E.SubElement(mx,'diagram',id=pid,name=title);gm=E.SubElement(d,'mxGraphModel',grid='1',page='1',pageWidth='1900',pageHeight='1900',background='#ffffff');r=E.SubElement(gm,'root');E.SubElement(r,'mxCell',id='0');E.SubElement(r,'mxCell',id='1',parent='0');boxes={}
 def vertex(id,text,x,y,w,h,style):
  c=E.SubElement(r,'mxCell',id=id,value=text,vertex='1',parent='1',style=style);E.SubElement(c,'mxGeometry',x=str(x),y=str(y),width=str(w),height=str(h),**{'as':'geometry'});return c
 def text(id,s,x,y,w,h,size=17):return vertex(id,s,x,y,w,h,f'text;html=1;whiteSpace=wrap;fillColor=#ffffff;align=center;fontFamily=Arial;fontSize={size};')
 text('title','<b>'+title+'</b>',60,20,1780,45,26)
 text('subtitle','Requested revision 2026-10-29 | '+('Physical PostgreSQL design' if physical else 'Requirements-level entity model')+' | Full dictionary and policy caveats accompany this view',60,75,1780,40)
 def box(id,name,x,y,w=550,reference=False):
  rows=desc_cols(name,physical,reference);h=52+24*len(rows)
  header=(name if physical else ENTITY[name])+(' (reference)' if reference else '')
  body='<b>'+html.escape(header)+'</b><hr><div style="text-align:left">'+'<br>'.join(html.escape(s) for s in rows)+'</div>'
  vertex(id,body,x,y,w,h,'rounded=0;html=1;whiteSpace=wrap;align=center;verticalAlign=top;spacing=12;fillColor=#F3F7FB;strokeColor=#455A64;fontFamily=Arial;fontSize=15;')
  boxes[id]=(x,y,w,h,name);return boxes[id]
 def edge(id,src,tgt,ports,waypoints,label,lb):
  ex,ey,ix,iy=ports;a=boxes[src];b=boxes[tgt];start=(a[0]+ex*a[2],a[1]+ey*a[3]);end=(b[0]+ix*b[2],b[1]+iy*b[3]);route=[start]+waypoints+[end]
  for (x1,y1),(x2,y2) in zip(route,route[1:]):
   assert x1==x2 or y1==y2,(id,'not orthogonal')
   for oid,(x,y,w,h,_) in boxes.items():
    if oid in [src,tgt]:continue
    if x1==x2:hit=x<x1<x+w and max(min(y1,y2),y)<min(max(y1,y2),y+h)
    else:hit=y<y1<y+h and max(min(x1,x2),x)<min(max(x1,x2),x+w)
    assert not hit,(title,id,oid)
  marker=(('startArrow=ERzeroToOne;' if '0..1 :' in label else 'startArrow=ERone;')+('endArrow=ERzeroToOne;' if label.endswith('0..1') else 'endArrow=ERzeroToMany;' if label.endswith('0..*') else 'endArrow=ERmany;')) if physical else 'startArrow=none;endArrow=none;'
  c=E.SubElement(r,'mxCell',id=id,parent='1',edge='1',source=src,target=tgt,value='',style=f'edgeStyle=orthogonalEdgeStyle;rounded=0;{marker}html=1;strokeColor=#455A64;strokeWidth=1.6;exitX={ex};exitY={ey};entryX={ix};entryY={iy};exitPerimeter=1;entryPerimeter=1;labelBackgroundColor=#ffffff;')
  g=E.SubElement(c,'mxGeometry',relative='1',**{'as':'geometry'});arr=E.SubElement(g,'Array',**{'as':'points'})
  for x,y in waypoints:E.SubElement(arr,'mxPoint',x=str(x),y=str(y))
  text(id+'_label',html.escape(label),*lb,15)
  records.append(dict(view=title,source=a[4],target=b[4],relationship=label,source_basis='Order lifecycle stakeholder decisions 2026-10-29; model JSON and database dictionary'))
 if kind=='financial':
  a=box('agent','delivery_agents',100,150,430);o=box('order','orders',650,150,550);pay=box('payment','order_payments',100,1000,530);failure=box('failure','delivery_failures',1270,1000,550);fee=box('fee','shipping_fee_settlements',650,1450,550)
  # All routes remain in the large corridors between focused table groups.
  sy=a[1]+a[3]*.5;ty=o[1]+o[3]*.2
  edge('agent_order','agent','order',(1,.5,0,.2),[(590,sy),(590,ty)],'assigned 0..1 : 0..*',(435,320,205,65))
  ox=o[0]+o[2]*.2;px=pay[0]+pay[2]*.5
  edge('order_payment','order','payment',(.2,1,.5,0),[(ox,850),(px,850)],'records 1 : 0..*',(420,875,300,45))
  ox=o[0]+o[2]*.8;fx=failure[0]+failure[2]*.5
  edge('order_failure','order','failure',(.8,1,.5,0),[(ox,850),(fx,850)],'failure 1 : 0..1',(1280,875,240,45))
  edge('order_fee','order','fee',(.5,1,.5,0),[],'fee obligation 1 : 0..1',(955,1230,290,55))
  fy=fee[1]+fee[3]*.8
  edge('agent_fee','agent','fee',(0,.5,0,.8),[(40,sy),(40,fy)],'payee 1 : 0..*',(60,1370,450,50))
  px=pay[0]+pay[2]*.5;fy=fee[1]+fee[3]*.5
  edge('payment_fee','payment','fee',(.5,1,0,.5),[(px,1350),(560,1350),(560,fy)],'collection evidence 0..1 : 0..1',(120,1370,400,55))
  text('notes','Payment allocations separate goods and shipping. Pending Unpaid/Paid are independent initial OrderStatus values. Phone-required is derived.<br>Final fault-decision authority and product-fault delivery-agent compensation remain TBD. Other Staff references are explicit reference attributes/FK columns; core Staff appears in the overview.',80,1770,1740,105,17)
 else:
  o=box('order','orders',650,150,550,True);rr=box('receipt','return_receipts',650,520,550);ri=box('item','return_receipt_items',650,970,550);detail=box('detail','order_details',100,970,450,True);ins=box('inspection','return_inspections',100,1350,530);ref=box('refund','refunds',1270,520,550)
  edge('order_receipt','order','receipt',(.5,1,.5,0),[],'return receipt 1 : 0..1',(660,420,240,50))
  ox=o[0]+o[2]*.8;fx=ref[0]+ref[2]*.5
  edge('order_refund','order','refund',(.8,1,.5,0),[(ox,420),(fx,420)],'refund obligation 1 : 0..1',(1250,345,550,55))
  edge('receipt_item','receipt','item',(.5,1,.5,0),[],'received lines 1 : 0..*',(945,835,300,55))
  y1=rr[1]+rr[3]*.4;y2=ref[1]+ref[3]*.4
  edge('receipt_refund','receipt','refund',(1,.4,0,.4),[(1235,y1),(1235,y2)],'1 : 0..1',(1203,max(y1,y2)+15,65,50))
  y1=detail[1]+detail[3]*.5;y2=ri[1]+ri[3]*.5
  edge('detail_item','detail','item',(1,.5,0,.5),[(600,y1),(600,y2)],'1 : 0..*',(550,max(y1,y2)+15,100,50))
  ix=ri[0]+ri[2]*.2;tx=ins[0]+ins[2]*.5
  edge('item_inspection','item','inspection',(.2,1,.5,0),[(ix,1280),(tx,1280)],'staff decisions 1 : 0..*',(800,1230,400,55))
  text('notes','Complete physical receipt is checked against every original order line. Staff quality/disposition records are independent of the customer refund.<br>Product fault: refund captured goods and shipping. Confirmed deliberate refusal: refund goods only; unpaid goods incur only the direct courier fee.<br>Do not treat a queued refund as settled or make returned food sellable automatically. Partial returns and payout integration remain TBD.',80,1740,1740,130,17)
 return d

for physical,path,slug in [(False,ROOT/'artifacts/diagrams/class/entity-class-diagram.drawio','entity-class-diagram'),(True,ROOT/'artifacts/diagrams/database/physical-erd.drawio','physical-erd')]:
 mx=E.parse(path).getroot()
 # Replace generated detail pages on a rerun; keep the original project overview.
 for d in list(mx)[1:]:mx.remove(d)
 first=mx.find('diagram')
 for c in first.findall('.//mxCell'):
  if c.get('id')=='t_sub':c.set('value','Domain overview | revised Order/payment/return details on pages 2-3 | 2026-10-29')
  if c.get('id')=='note_enums':
   c.set('value','<b>DOMAIN TYPES</b><br>OrderStatus: Pending Unpaid, Pending Paid,<br>Confirmed, Packing, Shipping, Delivered,<br>Cancelled, Delivery Failed, Returned<br>PaymentStatus: Unpaid, Paid,<br>Partially Refunded, Refunded<br>PaymentMethod: COD, VietQR<br><br>Fault: Unclassified, ProductFault,<br>CustomerIntentionalRefusal, Other<br>Phone: NotContacted, Confirmed, Unconfirmed')
   c.find('mxGeometry').set('height','400');c.set('style',c.get('style','')+'fontSize=12;html=1;')
  if c.get('id')=='tbl_orders':c.set('value','<b>orders (core fields; full revision on page 2)</b>')
 add_page(mx,slug+'-financial','Order, Payments and Delivery Fees',physical,'financial')
 add_page(mx,slug+'-return','Physical Return, Staff Inspection and Refund',physical,'return')
 E.indent(mx);E.ElementTree(mx).write(path,encoding='utf-8',xml_declaration=True)
 for i in range(3):
  output=ROOT/f'artifacts/diagrams/images/{slug}{"" if i==0 else "-"+str(i+1)}.png'
  render_drawio_file(str(path),i,str(output),width=1940,height=1970 if i else 1940)
 if not physical:shutil.copy2(ROOT/'artifacts/diagrams/images/entity-class-diagram.png',ROOT/'artifacts/diagrams/class/entity-class-diagram.png')
with (ROOT/'artifacts/analysis/order-lifecycle-entity-traceability.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(records[0]));w.writeheader();w.writerows(records)
print('Updated entity and physical ERD masters: 3 pages each; explicit obstacle-checked routing on detail pages.')
