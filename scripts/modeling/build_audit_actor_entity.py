from pathlib import Path
import xml.etree.ElementTree as E,sys,json,hashlib
mx=E.Element('mxfile',host='Electron');dia=E.SubElement(mx,'diagram',name='Customer audit entity amendment',id='audit-actor');model=E.SubElement(dia,'mxGraphModel',page='1',pageWidth='2060',pageHeight='900',background='#ffffff');r=E.SubElement(model,'root');E.SubElement(r,'mxCell',id='0');E.SubElement(r,'mxCell',id='1',parent='0')
def box(i,value,x,y,w,h,style):
 c=E.SubElement(r,'mxCell',id=i,value=value,vertex='1',parent='1',style=style);E.SubElement(c,'mxGeometry',x=str(x),y=str(y),width=str(w),height=str(h),**{'as':'geometry'})
style='rounded=0;html=1;whiteSpace=wrap;verticalAlign=top;spacing=20;fontFamily=Arial;fontSize=23;fillColor=#E8F5E9;strokeColor=#455A64;'
box('title','<b>Audit actor entity amendment</b>',40,20,1980,55,'text;html=1;align=center;fontSize=30;fontFamily=Arial;')
box('status','UC-C07 | Proposed technical amendment | Existing entity relationships use associations | 2026-11-02',40,90,1980,40,'text;html=1;align=center;fontSize=20;fontFamily=Arial;')
box('customer','&lt;&lt;entity&gt;&gt;<br><b>Customer</b><br><br>+ CustomerId: EntityId {private set}',60,200,420,400,style)
box('audit','&lt;&lt;entity&gt;&gt;<br><b>AuditLog</b><br><br>+ LogId: EntityId {private set}<br>+ StaffId: number? {private set}<br>+ CustomerId: EntityId? {private set; new}<br>+ ActorType: string {derived; read only; new}<br>+ ActionType: string {private set}<br>+ RecordIdentifier: string {private set}<br>+ OldValues / NewValues: string<br>+ Timestamp: Date {private set}',720,200,620,400,style)
box('staff','&lt;&lt;entity&gt;&gt;<br><b>Staff {abstract}</b><br><br>+ StaffId: number {private set}',1580,200,420,400,style)
for i,a,b in [('customer-audit','customer','audit'),('audit-staff','audit','staff')]:
 c=E.SubElement(r,'mxCell',id=i,edge='1',source=a,target=b,parent='1',style='edgeStyle=orthogonalEdgeStyle;endArrow=none;exitX=1;exitY=0.5;entryX=0;entryY=0.5;labelBackgroundColor=#ffffff;strokeWidth=2;');E.SubElement(c,'mxGeometry',relative='1',**{'as':'geometry'})
for i,value,x in [('m1','0..1',500),('m2','0..*',650),('m3','0..*',1360),('m4','0..1',1510)]:box(i,value,x,345,65,40,'text;html=1;fontFamily=Arial;fontSize=22;align=center;fillColor=#ffffff;labelBackgroundColor=#ffffff;')
box('constraint','<b>Actor constraint</b><br>CustomerId and StaffId cannot both be present.<br>CustomerId present: CUSTOMER. StaffId present: STAFF. Both absent: SYSTEM.<br>The customer ID is resolved by the server; it is not accepted from the cancellation payload.<br>Member excerpts are shown; existing AuditLog fields and staff/system audit entries are retained.',120,660,1820,180,'rounded=0;html=1;whiteSpace=wrap;align=center;spacing=15;fontSize=23;fontFamily=Arial;fillColor=#FFF2CC;')
path=Path('artifacts/diagrams/class/audit-actor-entity-amendment.drawio');E.indent(mx);E.ElementTree(mx).write(path,encoding='utf-8',xml_declaration=True)
sys.path.insert(0,'scratch');from test_render_drawio import render_drawio_file
render_drawio_file(str(path),0,'artifacts/diagrams/images/audit-actor-entity-amendment.png',2100,940)
print('Saved editable audit entity amendment and PNG')
