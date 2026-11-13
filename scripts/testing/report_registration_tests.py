import csv,json,collections,xml.etree.ElementTree as E
from pathlib import Path
root=Path(__file__).resolve().parents[2];out=root/'artifacts/testing/tutorialsninja-register';results=root/'artifacts/test-results/tutorialsninja-register'
rows=list(csv.DictReader((root/'tests/data/tutorialsninja_register.csv').open(encoding='utf-8')))
tests={t.get('name').split()[0]:t for t in E.parse(results/'output.xml').findall('.//test')}
counts=collections.Counter();entries=[];defects=[];coverage=[]
for r in rows:
 t=tests.get(r['id']);s=t.find('status') if t is not None else None
 status=s.get('status') if s is not None else 'NOT RUN';counts[status]+=1
 msg=s.text or '' if s is not None else ''
 if status=='PASS':msg=''
 evfile=results/'evidence'/f"{r['id']}.json"
 ev=json.loads(evfile.read_text(encoding='utf-8')) if evfile.exists() else {}
 actual=ev.get('actual') or {}
 steps=f"1. Reset guest session. 2. Load dataset {r['id']} from tests/data/tutorialsninja_register.csv. 3. Fill Registration Form. 4. Submit Registration. 5. Assert Registration Outcome; verify stored profile/newsletter on success."
 if r['field']=='duplicate':steps='Create a unique valid account; reset cookies; submit the same email again; verify duplicate warning.'
 if r['field']=='login':steps='Open Register; click login page; verify account/login route.'
 if r['field']=='policy':steps='Open Register; click Privacy Policy; verify visible dialog and heading.'
 if r['field']=='network':steps='In a controlled environment inject network/server failure during registration; verify recoverable error, no account commit, and safe retry. Not executable on shared demo.'
 expectation=r['expected']
 if expectation=='success':expectation='Account success page; stored profile matches input; saved Newsletter matches selected value.'
 elif expectation=='reject':expectation='Registration rejected under the proposed UC rule. Approval/clarification required.'
 elif expectation=='email-invalid':expectation='Browser email validation or application email error; account not created.'
 note=f"{status} on Chrome; UC-REG-01 {r['flow']}; {r['basis']}; {r['technique']}; dataset {r['id']}; actual: {msg or actual or ev.get('url','')}"
 if status=='FAIL':
  did=f'REG-ISS-{len(defects)+1:03}'
  category='Requirement clarification' if 'proposal' in r['basis'] else 'Functional validation'
  defects.append(dict(id=did,case=r['id'],summary=r['title'],category=category,expected=expectation,actual=msg,severity='Medium',priority='Medium',status='New - review required'))
  note+=f'; {did}'
 entries.append({**r,'status':status,'steps':steps,'expected':expectation,'note':note})
 coverage.append(dict(case=r['id'],use_case='UC-REG-01',flow=r['flow'],basis=r['basis'],technique=r['technique'],status=status))
(out/'workbook-data.json').write_text(json.dumps(dict(date='2026-10-28',cases=entries,pass_=counts['PASS'],**{'pass':counts['PASS'],'fail':counts['FAIL'],'skip':counts['SKIP']}),indent=2),encoding='utf-8')
(out/'issues.json').write_text(json.dumps(defects,indent=2),encoding='utf-8')
for name,data in [('traceability.csv',coverage),('issues.csv',defects)]:
 with (out/name).open('w',newline='',encoding='utf-8') as f:
  w=csv.DictWriter(f,fieldnames=list(data[0]));w.writeheader();w.writerows(data)
# The following are input-model predicates, not measured source-code conditions.
conditions=[('C01','firstname','length < 1',lambda c:len(c['firstname'])<1),('C02','firstname','length > 32',lambda c:len(c['firstname'])>32),('C03','lastname','length < 1',lambda c:len(c['lastname'])<1),('C04','lastname','length > 32',lambda c:len(c['lastname'])>32),('C05','telephone','length < 3',lambda c:len(c['telephone'])<3),('C06','telephone','length > 32',lambda c:len(c['telephone'])>32),('C07','password','length < 4',lambda c:len(c['password'])<4),('C08','password','length > 20',lambda c:len(c['password'])>20),('C09','email','format invalid',lambda c:c['field']=='email'),('C10','duplicate','email already registered',lambda c:c['field']=='duplicate'),('C11','confirm','confirmation differs',lambda c:c['confirm']!=c['password']),('C12','agree','privacy accepted',lambda c:c['agree']=='1'),('C13','newsletter','newsletter selected Yes',lambda c:c['newsletter']=='1')]
evidence=[]
for r in rows:
 p=results/'evidence'/f"{r['id']}.json"
 if p.exists() and r['field'] not in ['login','policy','network']:
  c=json.loads(p.read_text(encoding='utf-8')).get('case')
  if c:evidence.append((r['id'],c))
model=[]
for cid,field,pred,fn in conditions:
 true=[i for i,c in evidence if fn(c)];false=[i for i,c in evidence if not fn(c)]
 model.append(dict(id=cid,field=field,predicate=pred,true_cases=' '.join(true),false_cases=' '.join(false),input_outcomes_exercised=int(bool(true))+int(bool(false)),limitation='Input model only; not source condition/branch instrumentation. C09 may be blocked by browser validation.'))
with (out/'condition-coverage.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(model[0]));w.writeheader();w.writerows(model)
print(dict(counts));print('Input model condition outcomes:',sum(c['input_outcomes_exercised'] for c in model),'/ 26')
resolved=[{'id':i,**{k:c[k] for k in ['firstname','lastname','email','telephone','password','confirm','newsletter','agree']}} for i,c in evidence]
with (out/'executed-test-data.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(resolved[0]));w.writeheader();w.writerows(resolved)
decisions=[('D01','First Name invalid',lambda c:len(c['firstname'])<1 or len(c['firstname'])>32),('D02','Last Name invalid',lambda c:len(c['lastname'])<1 or len(c['lastname'])>32),('D03','Telephone invalid',lambda c:len(c['telephone'])<3 or len(c['telephone'])>32),('D04','Password length invalid',lambda c:len(c['password'])<4 or len(c['password'])>20),('D05','Email format invalid',lambda c:c['field']=='email'),('D06','Email duplicate',lambda c:c['field']=='duplicate'),('D07','Confirmation mismatch',lambda c:c['password']!=c['confirm']),('D08','Consent accepted',lambda c:c['agree']=='1'),('D09','Newsletter Yes',lambda c:c['newsletter']=='1')]
decision_rows=[]
for did,label,fn in decisions:
 t=[i for i,c in evidence if fn(c)];f=[i for i,c in evidence if not fn(c)]
 decision_rows.append(dict(id=did,decision=label,true_cases=' '.join(t),false_cases=' '.join(f),input_outcomes_exercised=int(bool(t))+int(bool(f)),measurement='Black-box input model; actual source branches not measured'))
with (out/'decision-coverage.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(decision_rows[0]));w.writeheader();w.writerows(decision_rows)
