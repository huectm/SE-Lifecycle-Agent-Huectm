from pathlib import Path
import json,hashlib
from collections import defaultdict
from diagram_layout_routing import rectangle_overlap,segment_hits_rect,overlap
R=Path.cwd();D=R/'artifacts/design/detailed';rows=json.loads((D/'diagram-pages.json').read_text());issues=[];stats={'class_pairs':0,'route_segments':0,'labels':0,'shared_collinear_segments':0,'class_collisions':0,'label_collisions':0}
for p in rows:
 boxes=p.get('class_boxes');labels=p.get('labels')
 if boxes is None or labels is None:raise AssertionError('New layout metadata not finalized')
 values=list(boxes.items())
 for i,(n,a) in enumerate(values):
  for nn,b in values[i+1:]:
   stats['class_pairs']+=1
   if rectangle_overlap(a,b,0):issues.append((p['owner'],p['page'],'class overlap',n,nn));stats['class_collisions']+=1
 segments=[];axes=defaultdict(list)
 for ei,r in enumerate(p['routes']):
  for a,b in zip(r['points'],r['points'][1:]):
   segments.append((a,b));stats['route_segments']+=1
   if abs(a[1]-b[1])<1e-6:key=('H',round(a[1],7));lo,hi=sorted([a[0],b[0]])
   else:key=('V',round(a[0],7));lo,hi=sorted([a[1],b[1]])
   axes[key].append((lo,hi,ei))
 for key,spans in axes.items():
  active=[]
  for lo,hi,ei in sorted(spans):
   active=[s for s in active if s[1]>lo+1e-6]
   for old in active:
    if old[2]!=ei and min(hi,old[1])-lo>1e-6:issues.append((p['owner'],p['page'],'shared route',key,old,(lo,hi,ei)));stats['shared_collinear_segments']+=1
   active.append((lo,hi,ei))
 for i,label in enumerate(labels):
  lb=label['box'];stats['labels']+=1
  if any(rectangle_overlap(lb,box,0) for box in boxes.values()) or any(segment_hits_rect(a,b,lb,0) for a,b in segments) or any(rectangle_overlap(lb,l['box'],0) for l in labels[:i]):issues.append((p['owner'],p['page'],'label collision',label));stats['label_collisions']+=1
before=(R/'scratch/dcd-layout-before-20261031/model.sha256').read_text();actual=hashlib.sha256((D/'detailed-class-model.json').read_bytes()).hexdigest();assert actual==before,'Semantic class model changed'
result={'date':'2026-10-31','scope':'Seven detailed-class Draw.io masters','pages':len(rows),'semantics_preserved':actual==before,'checks':stats,'issues':issues,'crossing_convention':'Perpendicular crossings use draw.io jump arcs; no different edges share a collinear segment.'}
(D/'layout-verification.json').write_text(json.dumps(result,indent=2));assert not issues,issues[:5]
print('PASS: class boxes, labels and routing channels do not overlap across',len(rows),'pages; class/relationship semantics unchanged.')
