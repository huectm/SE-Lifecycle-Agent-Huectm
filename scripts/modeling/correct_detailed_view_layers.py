from pathlib import Path
import shutil,hashlib,json,xml.etree.ElementTree as E
R=Path.cwd();B=R/'scratch/view-layer-before-20261031';B.mkdir(exist_ok=True)
for folder in ['artifacts/design/detailed','artifacts/diagrams/class']:
 for f in (R/folder).glob('*'):
  if f.is_file() and (folder.endswith('detailed') or 'design-classes' in f.name):
   to=B/f.relative_to(R);to.parent.mkdir(parents=True,exist_ok=True)
   if not to.exists():shutil.copy2(f,to)
for rel in ['scripts/modeling/build_detailed_class_model.py','scripts/modeling/render_detailed_class_diagrams.py','scripts/modeling/write_detailed_class_specification.py','artifacts/design/detailed-design-class-diagrams.md']:
 p=R/rel;to=B/rel;to.parent.mkdir(parents=True,exist_ok=True)
 if not to.exists():shutil.copy2(p,to)
old={}
for f in Path('artifacts/diagrams/class').glob('*design-classes.drawio'):
 for i,d in enumerate(E.parse(f).findall('diagram'),1):
  for e in d.iter():e.text=None;e.tail=None
  old[f.as_posix()+':'+str(i)]=hashlib.sha256(E.tostring(d)).hexdigest()
Path('scratch/dcd-page-hashes.json').write_text(json.dumps(old))
p=R/'scripts/modeling/build_detailed_class_model.py';s=p.read_text();a=s.index(' # Frontend runtime classes');b=s.index(' ucs[uc]=',a)
new=""" # Web View has exactly the two package responsibilities in the package master.
 web=feat+'Page';wi='I'+feat+'ApiClient';wc=feat+'ApiClient';mv=feat+'ViewModel';mi='I'+feat+'ApiModel';mc=feat+'ApiModel'
 def client_sig(sig,mobile=False):
  sig=sig.replace(', ct: CancellationToken','').replace('ct: CancellationToken','')
  sig=sig.replace('Task<','Future<' if mobile else 'Promise<')
  if not mobile:sig=re.sub(r'\\b(long|int)\\b','number',sig)
  return sig
 exposed=[(n,args,ret) for n,args,ret in ops if n!='HandleVerifiedPayment']
 web_sigs=[client_sig(x) for x in sigs if 'HandleVerifiedPayment' not in x]
 mobile_sigs=[client_sig(x,True) for x in sigs if 'HandleVerifiedPayment' not in x]
 state_type={'UC-C01':'CatalogResultDto','UC-C03':'CartResultDto','UC-C05':'ProfileResultDto','UC-C06':'CheckoutSummaryDto','UC-C07':'OrderListDto'}[uc]
 web_events=['+ On'+n+'Async('+re.sub(r'\\b(long|int)\\b','number',args)+'): Promise<void>' for n,args,ret in exposed]
 mobile_events=['+ On'+n+'('+args+'): Future<void>' for n,args,ret in exposed]
 if uc=='UC-C06':
  web_events+=['+ OnPaymentStateChanged(result: PaymentResultDto): void']
  mobile_events+=['+ OnPaymentStateChanged(result: PaymentResultDto): void']
 if uc=='UC-C07':
  web_events+=['+ ShowCancellationConfirmation(orderId: number): void']
  mobile_events+=['+ ShowCancellationConfirmation(orderId: long): void']
 C(web,'FreshFood-Customer-Web.Pages','boundary',['- api: '+wi,'- state: '+state_type+'?','- isBusy: boolean','- errorCode: string?'],['+ '+web+'(api: '+wi+')','+ Render(): ReactNode']+web_events,view+' Web event handling and rendering; no direct HTTP/server service dependency',uc)
 C(wi,'FreshFood-Customer-Web.CallService','interface',[],web_sigs,'Client HTTP abstraction injected into Pages; JSON contract, no backend assembly reference',uc)
 C(wc,'FreshFood-Customer-Web.CallService','adapter',['- http: HttpClient'],['+ '+wc+'(http: HttpClient)']+web_sigs,'Authenticated HTTPS/JSON and boundary serialization; no UI rendering or stock/refund policy',uc)
 C(view,'FreshFood-App.Views','boundary',['- model: '+mv],['+ '+view+'(model: '+mv+')','+ Build(): Widget']+mobile_events,view+' Mobile rendering and events forwarded to injected ViewModel',uc)
 C(mv,'FreshFood-App.ViewModels','viewmodel',['- api: '+mi,'- state: '+state_type+'?','- isBusy: bool','- errorCode: string?'],['+ '+mv+'(api: '+mi+')']+mobile_sigs,'MVVM client interaction state and orchestration; no persistence or server business policy',uc)
 C(mi,'FreshFood-App.Models','interface',[],mobile_sigs,'Mobile-owned API model contract; Future denotes native asynchronous operations',uc)
 C(mc,'FreshFood-App.Models','adapter',['- http: HttpClient'],['+ '+mc+'(http: HttpClient)']+mobile_sigs,'Authenticated HTTPS/JSON; client DTO/model projections distinct from backend Entities',uc)
 page(uc,'Web View - Pages and CallService',[web,wi,ctrl,wc,ic],[dep(web,wi),dep(wc,wi,'implements','realization'),dep(wc,ctrl,'HTTPS / JSON','remote'),dep(ctrl,ic)])
 pages[-1]['package_groups']={'FreshFood-Customer-Web.Pages':[web],'FreshFood-Customer-Web.CallService':[wi,wc],'FreshFood-API (references)':[ctrl,ic]}
 page(uc,'Mobile View - Views ViewModels Models',[view,mv,mi,mc,ctrl],[dep(view,mv),dep(mv,mi),dep(mc,mi,'implements','realization'),dep(mc,ctrl,'HTTPS / JSON','remote')])
 pages[-1]['package_groups']={'FreshFood-App.Views':[view],'FreshFood-App.ViewModels':[mv],'FreshFood-App.Models':[mi,mc]}
"""
s=s[:a]+new+s[b:];idx=s.index("model={'version'")
s=s[:idx]+"# Surface View realizations first so opening a use-case master shows the package split immediately.\nordered=[]\nfor uc in ucs:\n own=[p for p in pages if p['owner']==uc]\n ordered += [p for p in own if p['title'].startswith('Web View')] + [p for p in own if p['title'].startswith('Mobile View')] + [p for p in own if not p['title'].startswith(('Web View','Mobile View'))]\npages=ordered+[p for p in pages if p['owner'] not in ucs]\n"+s[idx:];p.write_text(s)
p=R/'scripts/modeling/render_detailed_class_diagrams.py';s=p.read_text();needle="  for n,box in boxes.items():"
insert="""  # Explicit View package compartments: background frames are saved before their classifiers.
  for gi,(label,members) in enumerate(p.get('package_groups',{}).items(),1):
   bs=[boxes[n] for n in members];left=min(b[0] for b in bs)-30;top=min(b[1] for b in bs)-50;right=max(b[0]+b[2] for b in bs)+30;bottom=max(b[1]+b[3] for b in bs)+30
   v(root,'package_'+str(gi),html.escape(label),(left,top,right-left,bottom-top),'shape=folder;tabWidth=270;tabHeight=28;html=1;whiteSpace=wrap;align=left;verticalAlign=top;spacingLeft=10;spacingTop=5;fontFamily=Arial;fontSize=16;fontStyle=1;fillColor=#FAFAFA;strokeColor=#90A4AE;')
"""
s=s.replace(needle,insert+needle);p.write_text(s)
p=R/'scripts/modeling/write_detailed_class_specification.py';s=p.read_text().replace("targets=[feature+'Page',name,feature+'ViewModel',feature+'ApiClient',feature+'ApiModel']","targets=[feature+'Page','I'+feature+'ApiClient',feature+'ApiClient',name,feature+'ViewModel','I'+feature+'ApiModel',feature+'ApiModel']")
s=s.replace('Separate Customer Web and Mobile runtime responsibilities; HTTP boundary retained.','Web Pages render and handle UI events through injected CallService interfaces/adapters; Mobile Views delegate to ViewModels and Models. No direct Page-to-server-service dependency.')
s=s.replace('The first page shows API/controller/service/repository dependency injection. Subsequent pages show participating entities, request/response contracts, Web/Mobile boundary realization and applicable transition classes.','Page 1 explicitly groups Web View into Pages and CallService, with UI actions and constructor-injected client contracts. Page 2 separately shows Mobile Views, ViewModels and Models. Later pages show API/controller/service/repository injection, participating entities, request/response contracts and applicable transition classes.')
s=s.replace('Frontend signatures denote logical async boundary contracts: Web implementations adapt Task to native Promise and Mobile implementations to Future, without importing backend assemblies.','Frontend contracts use Promise for Web and Future for Mobile; backend contracts retain Task. DTO names in client signatures denote platform-local JSON projections, not imported backend classes. Page classifiers represent React page/component responsibilities and dependency supply through client composition (props/context/provider); the constructor is UML injection notation, not a requirement to implement React class components.')
p.write_text(s)
print('View source corrected: Web Pages / CallService, separate Mobile view, explicit actions and native async types')
