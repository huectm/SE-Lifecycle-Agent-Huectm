from pathlib import Path
import xml.etree.ElementTree as E,html,json,sys,hashlib
out=Path('artifacts/diagrams/database/order-consistency-storage-amendment.drawio');out.parent.mkdir(exist_ok=True)
mx=E.Element('mxfile',host='Electron',agent='SE-Lifecycle-Agent')
physical={
'customer':['customers (existing)','PK customer_id BIGINT'],
'order':['orders (existing)','PK order_id BIGINT'],
'staff':['staff_accounts (existing)','PK staff_id INT'],
'claim':['checkout_idempotency (new)','PK/FK customer_id BIGINT','PK operation VARCHAR(32)','PK idempotency_key VARCHAR(128)','checkout_reference VARCHAR(128)','request_hash CHAR(64)','FK order_id BIGINT NULL','response JSONB NULL','created_at TIMESTAMPTZ','completed_at TIMESTAMPTZ NULL','UQ customer_id + operation + checkout_reference','Response / order / completed_at complete together','Replay returns original stored confirmation'],
'event':['order_transition_events (new)','PK transition_event_id BIGINT IDENTITY','aggregate_key VARCHAR(256)','event_id VARCHAR(128)','transition_id VARCHAR(64)','FK order_id BIGINT NULL','recorded_at TIMESTAMPTZ','UQ aggregate_key + event_id + transition_id','Initial aggregate: checkout:<customer>:<reference>','Existing order aggregate: order ID string','Initial events linked to order before commit'],
'audit':['audit_logs (extended)','PK log_id BIGINT (existing)','FK staff_id INT NULL (existing)','FK customer_id BIGINT NULL (new)','actor_type VARCHAR(16) GENERATED STORED','STAFF / CUSTOMER / SYSTEM derived from IDs','CHECK not both actor IDs present','Both NULL preserves automated SYSTEM entries','Existing action / entity / record ID fields','Existing old_values / new_values JSONB','Existing timestamp retained']}
layouts={'customer':(60,150,400,160),'order':(900,150,400,160),'staff':(1740,150,400,160),'claim':(60,570,600,590),'event':(800,570,600,590),'audit':(1540,570,600,590)}
records=[]
for pi,view in enumerate(['Conceptual technical model','Logical storage model','Physical PostgreSQL model']):
 dia=E.SubElement(mx,'diagram',id='storage-'+str(pi+1),name=view);model=E.SubElement(dia,'mxGraphModel',page='1',pageWidth='2220',pageHeight='1320',background='#ffffff');root=E.SubElement(model,'root');E.SubElement(root,'mxCell',id='0');E.SubElement(root,'mxCell',id='1',parent='0')
 def box(key,value,x,y,w,h,style):
  c=E.SubElement(root,'mxCell',id=key,value=value,vertex='1',parent='1',style=style);E.SubElement(c,'mxGeometry',x=str(x),y=str(y),width=str(w),height=str(h),**{'as':'geometry'})
 box('title','<b>Order consistency storage amendment | '+view+'</b>',40,20,2140,50,'text;html=1;align=center;fontSize=28;fontFamily=Arial;')
 box('status','UC-C06 / UC-C07 | Authorized technical amendment | Proposed for design review | 2026-11-02',40,80,2140,40,'text;html=1;align=center;fontSize=19;fontFamily=Arial;')
 for key,(x,y,w,h) in layouts.items():
  lines=physical[key]
  if pi==0 and key in ['claim','event','audit']:
   descriptions={'claim':['Checkout request identity','One stored result per customer + operation + key','One checkout reference per customer + operation','Atomic with stock, order, lines and cart','Same key + changed request: reject'], 'event':['Transition execution evidence','One effect per aggregate + event + transition','Initial acceptance events linked to created order','Same database transaction as domain effects'], 'audit':['Customer / staff / system audit','Customer identity is server-resolved','No customer impersonation of staff','Existing automated entries remain valid']}
   lines=[lines[0]]+descriptions[key]
  elif pi==1:lines=[line.replace('BIGINT','identifier').replace('VARCHAR(128)','text').replace('CHAR(64)','SHA-256 digest').replace('TIMESTAMPTZ','timestamp') for line in lines]
  value='<b>'+html.escape(lines[0])+'</b><br><br>'+'<br>'.join(html.escape(t) for t in lines[1:])
  box(key,value,x,y,w,h,'rounded=0;html=1;whiteSpace=wrap;align=left;verticalAlign=top;spacing=20;fontFamily=Arial;fontSize=21;fillColor='+('#E8F5E9;' if key in ['claim','event','audit'] else '#F5F5F5;')+'strokeColor=#455A64;')
 def edge(key,source,target,ex,ey,ix,iy,points,label,lx,ly,lw=300):
  c=E.SubElement(root,'mxCell',id=key,edge='1',parent='1',source=source,target=target,style=f'edgeStyle=orthogonalEdgeStyle;rounded=0;jumpStyle=arc;jumpSize=10;exitX={ex};exitY={ey};entryX={ix};entryY={iy};endArrow={"ERone" if key=="claim-customer" else "ERzeroToOne"};startArrow=ERmany;labelBackgroundColor=#ffffff;strokeColor=#455A64;strokeWidth=2;')
  g=E.SubElement(c,'mxGeometry',relative='1',**{'as':'geometry'});a=E.SubElement(g,'Array',{'as':'points'})
  for x,y in points:E.SubElement(a,'mxPoint',x=str(x),y=str(y))
  box(key+'-label',label,lx,ly,lw,48,'text;html=1;whiteSpace=wrap;align=center;fontSize=18;fontFamily=Arial;fillColor=#ffffff;labelBackgroundColor=#ffffff;')
 edge('claim-customer','claim','customer',.3333,0,.5,1,[(260,430)],'Required customer scope',80,365,260)
 edge('claim-order','claim','order',1,.12,.25,1,[(720,640),(720,370),(1000,370)],'Order 0..1 until completion',705,315,300)
 edge('event-order','event','order',.5,0,.75,1,[(1100,490),(1200,490)],'Order 0..1; bound before commit',1040,515,360)
 edge('audit-customer','audit','customer',.1667,0,1,.5,[(1640,450),(520,450),(520,230)],'Customer actor 0..1',600,465,300)
 edge('audit-staff','audit','staff',.6667,0,.5,1,[(1940,390)],'Staff actor 0..1',1810,405,260)
 box('note','<b>Database effects commit together. No automatic key expiry, history deletion, payout or retry count is introduced.</b>',60,1210,2080,55,'text;html=1;align=center;whiteSpace=wrap;fontSize=20;fontFamily=Arial;')
 records.append({'page':pi+1,'name':view})
E.indent(mx);E.ElementTree(mx).write(out,encoding='utf-8',xml_declaration=True);E.parse(out)
sys.path.insert(0,'scratch');from test_render_drawio import render_drawio_file
for r in records:
 png=Path('artifacts/diagrams/images')/f'order-consistency-storage-amendment-{r["page"]:02}.png';render_drawio_file(str(out),r['page']-1,str(png),2260,1360);r['png']=str(png);r['sha256']=hashlib.sha256(png.read_bytes()).hexdigest()
Path('artifacts/design/database/order-consistency-diagram-exports.json').write_text(json.dumps({'master':str(out),'pages':records},indent=2),encoding='utf-8')
print('Created three editable storage views and corresponding PNG exports')
