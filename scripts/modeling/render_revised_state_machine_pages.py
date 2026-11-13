from pathlib import Path
import json,xml.etree.ElementTree as E,hashlib,subprocess,sys,shutil
root=Path.cwd();meta=root/'artifacts/design/detailed/diagram-pages.json';old=json.loads(meta.read_text());oldhash={}
for rec in old:
 path=rec['source'];diagrams=E.parse(path).findall('diagram');oldhash[(path,rec['page'])]=hashlib.sha256(E.tostring(diagrams[rec['page']-1])).hexdigest()
subprocess.run([sys.executable,'scripts/modeling/render_detailed_class_diagrams.py'],check=True)
records=json.loads(meta.read_text());sys.path.insert(0,'scratch');from test_render_drawio import render_drawio_file
changed=0
for rec in records:
 d=E.parse(rec['source']).findall('diagram')[rec['page']-1];key=(rec['source'],rec['page']);h=hashlib.sha256(E.tostring(d)).hexdigest()
 if oldhash.get(key)!=h or not Path(rec['image']).exists():
  render_drawio_file(rec['source'],rec['page']-1,rec['image'],rec['width']+70,rec['height']+70);changed+=1
 rec['png_sha256']=hashlib.sha256(Path(rec['image']).read_bytes()).hexdigest()
meta.write_text(json.dumps(records,indent=2),encoding='utf-8')
# Retire unreferenced old transition-class PNGs without deleting baseline evidence.
active={str(Path(r['image']).resolve()) for r in records};archive=root/'artifacts/design/baselines/per-transition-20261101/retired-images';archive.mkdir(parents=True,exist_ok=True)
for p in (root/'artifacts/diagrams/images').glob('state-transitions-design-classes-*.png'):
 if str(p.resolve()) not in active:
  target=archive/p.name;assert p.resolve().is_relative_to(root.resolve()) and target.resolve().is_relative_to(root.resolve());shutil.move(str(p),str(target))
print('Re-exported changed class pages',changed,flush=True)
