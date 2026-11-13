from pathlib import Path
import json,subprocess,sys
R=Path(__file__).resolve().parents[2]
p=R/'artifacts/design/detailed/detailed-class-model.json';m=json.loads(p.read_text(encoding='utf-8'))
m['classes']['Customer']['attributes']=[s.replace('Email: string {','Email: string? {') for s in m['classes']['Customer']['attributes']]
p.write_text(json.dumps(m,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
for name in ['build_detailed_class_model.py','map_backend_classes.py','realize_backend_core.py','realize_backend_orders.py','realize_backend_repositories.py','wire_backend_composition.py','wire_backend_http.py','write_backend_tests.py','write_backend_review.py','write_architecture_realization_review.py']:
 p=R/'scripts/modeling'/name;s=p.read_text(encoding='utf-8')
 guard="raise SystemExit('Historical Node.js generator retired after the explicit ASP.NET Core C# selection. Maintain the current C# source and detailed-class-model.json; do not regenerate the former backend.')\n"
 if not s.startswith(guard):p.write_text(guard+s,encoding='utf-8')
p=R/'scripts/modeling/write_design_sequence_index.py';s=p.read_text(encoding='utf-8').replace('Version: 0.1 | Date: 2026-11-01 | Status: Draft for Design Review','Version: 0.5 | Date: 2026-11-02 | Status: ASP.NET Core C# revision for technical review')
p.write_text(s,encoding='utf-8')
for path in ['artifacts/implementation/dotnet-migration-review.md','scripts/modeling/update_backend_rtm.mjs']:
 p=R/path;s=p.read_text(encoding='utf-8').replace('37 passing tests: 30 unit/data cases, six ASP.NET HTTP cases and one SQL integration scenario','40 passing tests: 31 unit/data cases, two design/DI checks, six ASP.NET HTTP cases and one SQL integration scenario').replace('39 local','40 local')
 p.write_text(s,encoding='utf-8')
subprocess.run([sys.executable,'scripts/modeling/render_revised_state_machine_pages.py'],check=True)
subprocess.run([sys.executable,'scripts/modeling/verify_table_state_machine_design.py'],check=True)
subprocess.run([sys.executable,'scripts/modeling/write_table_state_machine_design.py'],check=True)
subprocess.run([sys.executable,'scripts/modeling/verify_design_sequences.py'],check=True)
subprocess.run([sys.executable,'scripts/modeling/write_design_sequence_index.py'],check=True)
sys.path.insert(0,str(R/'scratch'))
from test_render_drawio import render_drawio_file
from PIL import Image
path=R/'artifacts/diagrams/images/high-level-architecture.png';w,h=Image.open(path).size
render_drawio_file(str(R/'artifacts/diagrams/architecture/high-level-architecture.drawio'),0,str(path),w,h)
print('Class, sequence and architecture exports are ready for Word synchronization.')
