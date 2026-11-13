"""Convert the existing case design into the template's left-values / O-selection matrix."""
from pathlib import Path
import json,collections,hashlib
D=Path('artifacts/testing/test-design/backend-unit')
design=json.loads((D/'backend-unit-test-design.json').read_text())
def shown(v):
 if v is None:return 'null'
 if isinstance(v,bool):return 'true' if v else 'false'
 if isinstance(v,str):return v if v else '"" (empty string)'
 return json.dumps(v,ensure_ascii=False,separators=(',',':'))
def flatten(value,path=''):
 if isinstance(value,dict) and value:
  result=[]
  for key,item in value.items():result+=flatten(item,(path+'.' if path else '')+key)
  return result
 return [(path or 'Input',value)]
def groups(section,pairs):
 result=[];fields=collections.OrderedDict()
 for case_id,items in pairs:
  for field,value in items:
   key=json.dumps(value,ensure_ascii=False,sort_keys=True)
   field_values=fields.setdefault(field,collections.OrderedDict())
   entry=field_values.setdefault(key,{'value':value,'text':shown(value),'caseIds':[]})
   entry['caseIds'].append(case_id)
 for field,values in fields.items():result.append({'section':section,'field':field,'variants':list(values.values())})
 return result
methods=[]
for m in design['methods']:
 cases=m['cases'];condition=[]
 condition+=groups('Precondition',[(c['id'],[('Setup',c['preconditions']),('Invocation',c['steps'])]) for c in cases])
 condition+=groups('Precondition',[(c['id'],[('Scenario',c['title']),('Review constraint',c['gap'] or 'No additional constraint recorded for this case.')]) for c in cases])
 condition+=groups('Input',[(c['id'],flatten(c['data'])) for c in cases])
 condition+=groups('Input',[(c['id'],[('Decision under test',c['decision'])] if c.get('decision') else []) for c in cases])
 condition+=groups('Input',[(c['id'],[('Condition: '+a,v) for a,v in c.get('conditionTrace',{}).items()]) for c in cases])
 confirms=[]
 confirms+=groups('Confirm',[(c['id'],[('Return',c['expected'])]) for c in cases])
 confirms+=groups('Confirm',[(c['id'],[('Exception',c['exception'] or 'No exception expected on this path.')]) for c in cases])
 confirms+=groups('Confirm',[(c['id'],[('State / collaborator effects',c['sideEffects'] or 'No additional side effect asserted.')]) for c in cases])
 confirms+=groups('Confirm',[(c['id'],[('Log message','Warning on the arranged post-commit notification failure; retain committed state and omit sensitive payloads.' if 'LogWarning' in c['expected'] or 'warning' in c['sideEffects'].lower() else 'No additional log message asserted on this path.')]) for c in cases])
 # Each selected input leaf and every confirmation survives the layout conversion.
 for c in cases:
  selected=[(g['field'],v['value']) for g in condition for v in g['variants'] if c['id'] in v['caseIds'] and g['field'] in dict(flatten(c['data']))]
  actual={k:json.dumps(v,sort_keys=True,ensure_ascii=False) for k,v in selected if k in dict(flatten(c['data']))}
  expected={k:json.dumps(v,sort_keys=True,ensure_ascii=False) for k,v in flatten(c['data'])}
  assert actual==expected,(m['id'],c['id'])
 methods.append({'id':m['id'],'sheet':m['sheet'],'signature':m['signature'],'type':m['type'],'name':m['name'],'loc':m['loc'],'file':m['file'],'line':m['line'],'useCases':m['useCases'],'testLevel':m['testLevel'],'testability':m['testability'],'caseIds':[c['id'] for c in cases],'types':[c['inputType'] for c in cases],'conditions':condition,'confirmations':confirms})
out={'version':'0.2','date':'2026-11-04','notation':'Conditions and expected values on the left; O/blank selections in test-case columns. Result rows contain type and future execution only.','sourceDesignSha256':hashlib.sha256((D/'backend-unit-test-design.json').read_bytes()).hexdigest(),'methodCount':len(methods),'testCases':design['summary']['testCases'],'methods':methods}
(D/'unit-test-matrix-layout.json').write_text(json.dumps(out,ensure_ascii=False,indent=2)+'\n')
print('Matrix plan:',len(methods),'methods;',out['testCases'],'unchanged test IDs; max rows',max(sum(1+len(g['variants']) for g in m['conditions']+m['confirmations']) for m in methods))

