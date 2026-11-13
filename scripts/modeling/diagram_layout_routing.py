"""Orthogonal diagram routing with exclusive parallel channels and clear labels."""
from bisect import bisect_left,bisect_right
from collections import defaultdict
import heapq
EPS=1e-6

def merge(intervals):
 result=[]
 for lo,hi in sorted(intervals):
  if hi-lo<EPS:continue
  if result and lo<=result[-1][1]+EPS:result[-1]=(result[-1][0],max(hi,result[-1][1]))
  else:result.append((lo,hi))
 return result

def intersects(intervals,lo,hi):
 if hi<lo:lo,hi=hi,lo
 if hi-lo<EPS:return False
 index=bisect_left(intervals,(hi-EPS,float('-inf')))-1
 return index>=0 and intervals[index][1]>lo+EPS

def overlap(a,b,c,d):return max(0,min(max(a,b),max(c,d))-max(min(a,b),min(c,d)))

def route(a,b,boxes,bounds,assigned=None,used=None):
 used=used or [];ax,ay,aw,ah=a;bx,by,bw,bh=b
 if assigned is None:
  dx=bx+bw/2-ax-aw/2;dy=by+bh/2-ay-ah/2
  assigned=(1,.5,0,.5) if abs(dx)>abs(dy) and dx>0 else (0,.5,1,.5) if abs(dx)>abs(dy) else (.5,1,.5,0) if dy>0 else (.5,0,.5,1)
 horizontal=defaultdict(list);vertical=defaultdict(list)
 for p,q in used:
  if abs(p[1]-q[1])<EPS:horizontal[round(p[1],7)].append((min(p[0],q[0]),max(p[0],q[0])))
  else:vertical[round(p[0],7)].append((min(p[1],q[1]),max(p[1],q[1])))
 horizontal={k:merge(v) for k,v in horizontal.items()};vertical={k:merge(v) for k,v in vertical.items()};hk=sorted(horizontal);vk=sorted(vertical)
 obstacles=[(x-18,y-18,w+36,h+36) for x,y,w,h in boxes]
 last=None
 # Additional fixed tracks are only explored when the narrower route grid is insufficient.
 for track_count in [5,9,14]:
  for perturb in [0,4,-4]:
   ex,ey,ix,iy=assigned
   if ex in [0,1]:ey=min(.97,max(.03,ey+perturb/ah))
   else:ex=min(.97,max(.03,ex+perturb/aw))
   if ix in [0,1]:iy=min(.97,max(.03,iy-perturb/bh))
   else:ix=min(.97,max(.03,ix-perturb/bw))
   start=(ax+aw*ex,ay+ah*ey);end=(bx+bw*ix,by+bh*iy)
   def outset(p,x,y):return (p[0]+(32 if x==1 else -32 if x==0 else 0),p[1]+(32 if y==1 else -32 if y==0 else 0))
   s=outset(start,ex,ey);t=outset(end,ix,iy)
   def reserved(p,q):
    if abs(p[0]-q[0])<EPS:return intersects(vertical.get(round(p[0],7),[]),min(p[1],q[1]),max(p[1],q[1]))
    return intersects(horizontal.get(round(p[1],7),[]),min(p[0],q[0]),max(p[0],q[0]))
   if reserved(start,s) or reserved(t,end):continue
   xs={s[0],t[0],40,bounds[0]-40};ys={s[1],t[1],145,bounds[1]-130}
   for x,y,w,h in boxes:
    for k in range(track_count):
     off=32+k*28
     xs.update(v for v in [x-off,x+w+off] if 35<v<bounds[0]-35)
     ys.update(v for v in [y-off,y+h+off] if 140<v<bounds[1]-110)
   xs=sorted(xs);ys=sorted(ys);sx=xs.index(s[0]);sy=ys.index(s[1]);tx=xs.index(t[0]);ty=ys.index(t[1]);hcache={};vcache={}
   def blocked(x,y,nx,ny):
    if x==nx:
     xx=xs[x]
     if x not in vcache:vcache[x]=merge([(oy,oy+oh) for ox,oy,ow,oh in obstacles if ox<xx<ox+ow]+vertical.get(round(xx,7),[]))
     return intersects(vcache[x],min(ys[y],ys[ny]),max(ys[y],ys[ny]))
    yy=ys[y]
    if y not in hcache:hcache[y]=merge([(ox,ox+ow) for ox,oy,ow,oh in obstacles if oy<yy<oy+oh]+horizontal.get(round(yy,7),[]))
    return intersects(hcache[y],min(xs[x],xs[nx]),max(xs[x],xs[nx]))
   def crossings(x,y,nx,ny):
    count=0
    if y==ny:
     lo,hi=sorted((xs[x],xs[nx]));yy=ys[y]
     for xx in vk[bisect_right(vk,lo+EPS):bisect_left(vk,hi-EPS)]:
      if intersects(vertical[xx],yy-.01,yy+.01):count+=1
    else:
     lo,hi=sorted((ys[y],ys[ny]));xx=xs[x]
     for yy in hk[bisect_right(hk,lo+EPS):bisect_left(hk,hi-EPS)]:
      if intersects(horizontal[yy],xx-.01,xx+.01):count+=1
    return count
   queue=[(0,0,sx,sy,0)];best={(sx,sy,0):0};prev={};goal=None
   while queue:
    _,cost,x,y,d=heapq.heappop(queue);key=(x,y,d)
    if cost!=best.get(key):continue
    if (x,y)==(tx,ty):goal=key;break
    for nx,ny,nd in [(x+1,y,1),(x-1,y,1),(x,y+1,2),(x,y-1,2)]:
     if not (0<=nx<len(xs) and 0<=ny<len(ys)) or blocked(x,y,nx,ny):continue
     length=abs(xs[nx]-xs[x])+abs(ys[ny]-ys[y]);nc=cost+length+(90 if d and d!=nd else 0)+65*crossings(x,y,nx,ny);nk=(nx,ny,nd)
     if nc<best.get(nk,float('inf')):
      best[nk]=nc;prev[nk]=key;heapq.heappush(queue,(nc+abs(xs[nx]-t[0])+abs(ys[ny]-t[1]),nc,nx,ny,nd))
   if goal is None:last=(track_count,perturb);continue
   path=[]
   while goal in prev:path.append((xs[goal[0]],ys[goal[1]]));goal=prev[goal]
   path.append(s);path=[start]+list(reversed(path))+[end];clean=[]
   for pt in path:
    if clean and abs(clean[-1][0]-pt[0])<EPS and abs(clean[-1][1]-pt[1])<EPS:continue
    while len(clean)>1 and ((abs(clean[-2][0]-clean[-1][0])<EPS and abs(clean[-1][0]-pt[0])<EPS) or (abs(clean[-2][1]-clean[-1][1])<EPS and abs(clean[-1][1]-pt[1])<EPS)):clean.pop()
    clean.append(pt)
   assert all(not reserved(p,q) for p,q in zip(clean,clean[1:])),('Reserved route overlap',clean)
   return (ex,ey,ix,iy),clean
 raise AssertionError(('No exclusive orthogonal route',a,b,last))

def rectangle_overlap(a,b,pad=0):
 x,y,w,h=a;xx,yy,ww,hh=b
 return x<xx+ww+pad and xx<x+w+pad and y<yy+hh+pad and yy<y+h+pad

def segment_hits_rect(a,b,rect,pad=0):
 x,y,w,h=rect;x-=pad;y-=pad;w+=2*pad;h+=2*pad
 if abs(a[0]-b[0])<EPS:return x<a[0]<x+w and overlap(a[1],b[1],y,y+h)>EPS
 return y<a[1]<y+h and overlap(a[0],b[0],x,x+w)>EPS

def label_box(points,text,boxes,segments,labels,bounds):
 w=max(90,min(220,len(text)*8+22));h=30
 segs=sorted(zip(points,points[1:]),key=lambda ab:abs(ab[0][0]-ab[1][0])+abs(ab[0][1]-ab[1][1]),reverse=True)
 for a,b in segs:
  for ratio in [.5,.3,.7,.15,.85,.05,.95]:
   cx=a[0]+(b[0]-a[0])*ratio;cy=a[1]+(b[1]-a[1])*ratio
   for off in [22,46,72,100,140,180,220]:
    candidates=[(cx-w/2,cy-h-off,w,h),(cx-w/2,cy+off,w,h)] if abs(a[1]-b[1])<EPS else [(cx+off,cy-h/2,w,h),(cx-w-off,cy-h/2,w,h)]
    for rect in candidates:
     x,y,ww,hh=rect
     if not (35<x and x+ww<bounds[0]-35 and 140<y and y+hh<bounds[1]-100):continue
     if any(rectangle_overlap(rect,bx,12) for bx in boxes) or any(rectangle_overlap(rect,lb,10) for lb in labels):continue
     if any(segment_hits_rect(p,q,rect,8) for p,q in segments):continue
     return rect
 raise AssertionError(('No clear label space',text,points))
