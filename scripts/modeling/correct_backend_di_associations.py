from pathlib import Path
import shutil,json,hashlib,xml.etree.ElementTree as E
R=Path.cwd();B=R/'scratch/backend-di-association-before-20261031';B.mkdir(exist_ok=True)
for rel in ['scripts/modeling/build_detailed_class_model.py','scripts/modeling/render_detailed_class_diagrams.py','scripts/modeling/write_detailed_class_specification.py','scripts/modeling/verify_detailed_class_design.py','scripts/modeling/write_view_layer_consistency.py','scripts/modeling/write_detailed_design_review.py','artifacts/design/detailed-design-class-diagrams.md']:
 p=R/rel;d=B/rel;d.parent.mkdir(parents=True,exist_ok=True)
 if not d.exists():shutil.copy2(p,d)
for folder in ['artifacts/design/detailed','artifacts/diagrams/class']:
 for f in (R/folder).glob('*'):
  if f.is_file() and (folder.endswith('detailed') or 'design-classes' in f.name):
   d=B/f.relative_to(R);d.parent.mkdir(parents=True,exist_ok=True)
   if not d.exists():shutil.copy2(f,d)
old={}
for f in Path('artifacts/diagrams/class').glob('*design-classes.drawio'):
 for i,d in enumerate(E.parse(f).findall('diagram'),1):
  for e in d.iter():e.text=None;e.tail=None
  old[f.as_posix()+':'+str(i)]=hashlib.sha256(E.tostring(d)).hexdigest()
Path('scratch/dcd-page-hashes.json').write_text(json.dumps(old))
p=Path('scripts/modeling/build_detailed_class_model.py');s=p.read_text();s=s.replace("def dep(a,b,label='injects',kind='dependency'):","def dep(a,b,label='holds reference',kind='association'):")
a=s.index(' # Web View has exactly');b=s.index(' ucs[uc]=',a)
new=""" # Frontend uses ordinary concrete references; dependency injection is backend-only.
 web=feat+'Page';wc=feat+'ApiClient';mv=feat+'ViewModel';mc=feat+'ApiModel'
 def client_sig(sig,mobile=False):
  sig=sig.replace(', ct: CancellationToken','').replace('ct: CancellationToken','')
  sig=sig.replace('Task<','Future<' if mobile else 'Promise<')
  return re.sub(r'\\blong\\b','int',sig) if mobile else re.sub(r'\\b(long|int)\\b','number',sig)
 exposed=[(n,args,ret) for n,args,ret in ops if n!='HandleVerifiedPayment']
 web_sigs=[client_sig(x) for x in sigs if 'HandleVerifiedPayment' not in x]
 mobile_sigs=[client_sig(x,True) for x in sigs if 'HandleVerifiedPayment' not in x]
 state_type={'UC-C01':'CatalogResultDto','UC-C03':'CartResultDto','UC-C05':'ProfileResultDto','UC-C06':'CheckoutSummaryDto','UC-C07':'OrderListDto'}[uc]
 web_events=['+ On'+n+'Async('+re.sub(r'\\b(long|int)\\b','number',args)+'): Promise<void>' for n,args,ret in exposed]
 mobile_events=['+ On'+n+'('+re.sub(r'\\blong\\b','int',args)+'): Future<void>' for n,args,ret in exposed]
 if uc=='UC-C06':
  web_events+=['+ OnPaymentStateChanged(result: PaymentResultDto): void']
  mobile_events+=['+ OnPaymentStateChanged(result: PaymentResultDto): void']
 if uc=='UC-C07':
  web_events+=['+ ShowCancellationConfirmation(orderId: number): void']
  mobile_events+=['+ ShowCancellationConfirmation(orderId: int): void']
 C(web,'FreshFood-Customer-Web.Pages','boundary',['- api: '+wc,'- state: '+state_type+'?','- isBusy: boolean','- errorCode: string?'],['+ Render(): ReactNode']+web_events,view+' Web rendering/events; ordinary reference to concrete CallService class; no DI',uc)
 C(wc,'FreshFood-Customer-Web.CallService','adapter',['- http: HttpClient'],web_sigs,'Authenticated HTTPS/JSON and boundary serialization; ordinary frontend object/module lifecycle, no DI',uc)
 C(view,'FreshFood-App.Views','boundary',['- model: '+mv],['+ Build(): Widget']+mobile_events,view+' Mobile rendering/events through ordinary ViewModel association; no DI',uc)
 C(mv,'FreshFood-App.ViewModels','viewmodel',['- api: '+mc,'- state: '+state_type+'?','- isBusy: bool','- errorCode: string?'],mobile_sigs,'MVVM state and orchestration; ordinary association to concrete API model; no DI',uc)
 C(mc,'FreshFood-App.Models','adapter',['- http: HttpClient'],mobile_sigs,'Authenticated HTTPS/JSON; ordinary frontend lifecycle; no DI or backend type imports',uc)
 page(uc,'Web View Classes',[web,ctrl,wc,ic],[dep(web,wc,'api'),dep(wc,ctrl,'HTTPS / JSON','remote'),dep(ctrl,ic,'service')])
 page(uc,'Mobile View Classes',[view,mv,mc,ctrl],[dep(view,mv,'model'),dep(mv,mc,'api'),dep(mc,ctrl,'HTTPS / JSON','remote')])
"""
s=s[:a]+new+s[b:]
s=s.replace("ns=[service,'ITransitionExecutor','IStateTransition']+group", "ns=[service,'ITransitionExecutor','TransitionExecutor','IStateTransition']+group")
s=s.replace("[dep(service,'ITransitionExecutor'),dep('ITransitionExecutor','IStateTransition','injected collection')]+", "[dep(service,'ITransitionExecutor'),dep('TransitionExecutor','ITransitionExecutor','implements','realization'),dep('TransitionExecutor','IStateTransition','transitions')]+")
# Architecture ownership remains in metadata, never on diagram notation.
s=s.replace("'classes':classes,'pages':pages,'transitions':transitions}","'classes':classes,'pages':pages,'transitions':transitions,'presentation_rules':{'di_scope':'backend only','show_packages':False,'stored_reference_notation':'association','implementation_notation':'realization','frontend_lifecycle':'ordinary concrete references; no constructor injection'}}")
p.write_text(s)
p=Path('scripts/modeling/render_detailed_class_diagrams.py');s=p.read_text();a=s.index('  # Explicit View package compartments:');b=s.index('  for n,box in boxes.items():',a);s=s[:a]+s[b:]
s=s.replace("c=C[n];header=html.escape(c['package'])+'<br><b>&lt;&lt;'+c['role']+'&gt;&gt;<br>'+n+'</b>'", "c=C[n];header='<b>&lt;&lt;'+c['role']+'&gt;&gt;<br>'+n+'</b>'")
s=s.replace("Proposed detailed design | 2026-10-31 | Constructor injection | Technical review required", "Proposed detailed design | 2026-10-31 | Backend DI only | Technical review required")
s=s.replace("style+= 'dashed=1;endArrow=block;endFill=0;' if e['kind']=='realization' else 'dashed=1;endArrow=open;' if e['kind'] in ['dependency','remote'] else 'endArrow=none;'", "style+= 'dashed=1;endArrow=block;endFill=0;' if e['kind']=='realization' else 'dashed=0;endArrow=open;endFill=0;' if e['kind']=='remote' or e['label'] not in ['1 : 0..*','1 : 1..*','1 : 0..1'] else 'dashed=0;endArrow=none;'")
s=s.replace("if e['kind'] in ['association','remote']:","if e['kind']=='remote' or e['label'] in ['1 : 0..*','1 : 1..*','1 : 0..1']:")
s=s.replace("UML: dashed hollow triangle = interface realization; dashed open arrow = dependency; solid line = domain association.<br>API constructor parameters are local runtime dependencies. HTTPS links are remote calls. Entities and DTOs are distinct types.","UML: solid line / open arrow = association; dashed hollow triangle = interface realization.<br>Only backend classes use constructor DI. Frontend classes have ordinary references. HTTPS labels denote remote communication.")
p.write_text(s)
print('Corrected sources: backend-only DI, no package notation, solid associations for reference relationships.')
