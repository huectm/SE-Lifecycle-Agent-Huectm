"""Build an offline/local JMeter registration harness and reviewable test design."""
from pathlib import Path
import csv,json,xml.etree.ElementTree as E
ROOT=Path(__file__).resolve().parents[2]
OUT=ROOT/'artifacts/testing/tutorialsninja-performance'
cases=[
('PERF-01','Baseline response time','1 user; 5 warm-up + 30 measured transactions','1 user; approximately 5 minutes','Mean successful registration transaction <6000 ms; report errors separately.','Response time'),
('PERF-02','Daily registration capacity','1000 distinct guest sessions over 64800 seconds; 64.8-second mean inter-arrival','18 hours, 06:00 to 24:00 in the agreed service timezone','At least 1000 distinct successful sessions in the window; mean transaction <6000 ms.','Daily capacity'),
('PERF-03','Stepped load within supported concurrency','25, 50, 75, 100 virtual users; 30-second ramp and 180-second measured hold per level','Proposed; 4 levels with 60-second warm-up per level','Mean transaction <6000 ms at each supported level; no hidden failed transactions.','Load'),
('PERF-04','Sustained peak concurrency','100 active virtual users; 60-second ramp; 60-second warm-up; 15-minute measured hold','Proposed think time 5 seconds between transactions','100 users maintained during hold; mean transaction <6000 ms; collect achieved throughput and errors.','Peak load'),
('PERF-05','Concurrent submission burst','100 separate guest sessions wait at a barrier then submit valid registrations','Three bursts with recovery between bursts; proposed','Verify 100 submissions dispatched together, response distribution, successful persistence and mean <6000 ms.','Spike'),
('PERF-06','Stress beyond supported concurrency','100 -> 125 -> 150 -> 200 users; 3-minute holds; cap subject to owner approval','Proposed only; stop on approved error/latency/resource criteria','Find first sustained deterioration and recovery; no SLA guarantee above 100 users.','Stress'),
('PERF-07','Recovery after stress','After PERF-06 reduce to 1 user then 25 users','Proposed 5-minute recovery observation','Record time to recover mean <6000 ms, errors and throughput; recovery-time threshold TBD.','Recovery'),
('PERF-08','Endurance at peak','100 users maintained for 60 minutes; 5-second think time proposed','Proposed; monitor server memory/CPU/DB and generator','Mean <6000 ms in each measured window and overall; report trend/resource drift.','Endurance'),
('PERF-09','Operating-window availability','Low-rate health probe at 06:00 and 23:59 and every 60 seconds inside window','18-hour observation; approved timezone required','Registration page usable throughout observed window; no inference that access must be denied outside it.','Availability'),
('PERF-10','Mixed normal and validation workload','100 users; 80% valid registration and 20% invalid-form submissions','Proposed mix; 5-minute measured hold','Separate means for success and expected validation rejection; successful-registration mean <6000 ms.','Mixed load')]
records=[]
for cid,title,load,duration,expected,kind in cases:
 records.append(dict(id=cid,title=title,workload=load,duration=duration,expected=expected,type=kind,target_status='NOT EXECUTED - target owner authorization not available',basis='User performance request 2026-10-28; UC-REG-01',data='Synthetic unique emails; owner-approved disposable mailbox domain; valid fields; account cleanup plan required.'))
with (OUT/'performance-test-cases.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(records[0]));w.writeheader();w.writerows(records)
(OUT/'performance-test-cases.json').write_text(json.dumps(records,indent=2),encoding='utf-8')
root=E.Element('jmeterTestPlan',version='1.2',properties='5.0',jmeter='5.6.3');tree=E.SubElement(root,'hashTree')
def prop(parent,name,value,typ='stringProp'):
 e=E.SubElement(parent,typ,name=name);e.text=str(value);return e
def element(parent,tag,name,gui,**attrs):return E.SubElement(parent,tag,guiclass=gui,testclass=tag,testname=name,enabled='true',**attrs)
plan=element(tree,'TestPlan','Local Registration Harness - NOT target performance evidence','TestPlanGui')
prop(plan,'TestPlan.comments','Loopback-only harness. Public target load execution is NOT authorized.');prop(plan,'TestPlan.functional_mode','false','boolProp');prop(plan,'TestPlan.serialize_threadgroups','false','boolProp')
args=E.SubElement(plan,'elementProp',name='TestPlan.user_defined_variables',elementType='Arguments',guiclass='ArgumentsPanel',testclass='Arguments',enabled='true');E.SubElement(args,'collectionProp',name='Arguments.arguments')
pt=E.SubElement(tree,'hashTree')
group=element(pt,'ThreadGroup','Local users','ThreadGroupGui');prop(group,'ThreadGroup.on_sample_error','continue')
loop=E.SubElement(group,'elementProp',name='ThreadGroup.main_controller',elementType='LoopController',guiclass='LoopControlPanel',testclass='LoopController',enabled='true');prop(loop,'LoopController.continue_forever','false','boolProp');prop(loop,'LoopController.loops','${__P(iterations,1)}')
for name,val in [('ThreadGroup.num_threads','${__P(threads,1)}'),('ThreadGroup.ramp_time','${__P(ramp,0)}'),('ThreadGroup.duration','120'),('ThreadGroup.delay','0')]:prop(group,name,val)
prop(group,'ThreadGroup.scheduler','true','boolProp');prop(group,'ThreadGroup.same_user_on_next_iteration','false','boolProp')
gt=E.SubElement(pt,'hashTree')
cookie=element(gt,'CookieManager','Isolated guest cookies','CookiePanel');E.SubElement(cookie,'collectionProp',name='CookieManager.cookies');prop(cookie,'CookieManager.clearEachIteration','true','boolProp');prop(cookie,'CookieManager.controlledByThreadGroup','false','boolProp');E.SubElement(gt,'hashTree')
trx=element(gt,'TransactionController','REGISTRATION_TRANSACTION','TransactionControllerGui');prop(trx,'TransactionController.parent','true','boolProp');prop(trx,'TransactionController.includeTimers','false','boolProp');tt=E.SubElement(gt,'hashTree')
def sampler(name,method,path,fields,expected):
 s=element(tt,'HTTPSamplerProxy',name,'HttpTestSampleGui')
 a=E.SubElement(s,'elementProp',name='HTTPsampler.Arguments',elementType='Arguments',guiclass='HTTPArgumentsPanel',testclass='Arguments',enabled='true');ac=E.SubElement(a,'collectionProp',name='Arguments.arguments')
 for key,value in fields.items():
  arg=E.SubElement(ac,'elementProp',name=key,elementType='HTTPArgument');prop(arg,'HTTPArgument.always_encode','true','boolProp');prop(arg,'Argument.name',key);prop(arg,'Argument.value',value);prop(arg,'Argument.metadata','=');prop(arg,'HTTPArgument.use_equals','true','boolProp')
 for k,v in [('HTTPSampler.domain','127.0.0.1'),('HTTPSampler.port','${__P(port,8765)}'),('HTTPSampler.protocol','http'),('HTTPSampler.path',path),('HTTPSampler.method',method),('HTTPSampler.contentEncoding','UTF-8'),('HTTPSampler.connect_timeout','3000'),('HTTPSampler.response_timeout','5000')]:prop(s,k,v)
 for k,v in [('HTTPSampler.follow_redirects','true'),('HTTPSampler.auto_redirects','false'),('HTTPSampler.use_keepalive','true'),('HTTPSampler.DO_MULTIPART_POST','false')]:prop(s,k,v,'boolProp')
 st=E.SubElement(tt,'hashTree');ass=element(st,'ResponseAssertion','Verify '+expected,'AssertionGui');texts=E.SubElement(ass,'collectionProp',name='Asserion.test_strings');prop(texts,'expected',expected);prop(ass,'Assertion.test_field','Assertion.response_data');prop(ass,'Assertion.assume_success','false','boolProp');prop(ass,'Assertion.test_type','16','intProp');E.SubElement(st,'hashTree')
sampler('GET_REGISTER','GET','/index.php?route=account/register',{},'Register Account')
fields=dict(firstname='Load',lastname='Tester',email='local_${__threadNum}_${__counter(TRUE,)}_${__time(,)}@example.com',telephone='0812345678',password='Valid123!',confirm='Valid123!',newsletter='0',agree='1')
sampler('POST_REGISTER','POST','/index.php?route=account/register',fields,'Your Account Has Been Created!')
E.indent(root);E.ElementTree(root).write(ROOT/'tests/performance/registration_local_harness.jmx',encoding='UTF-8',xml_declaration=True)
print('Created',len(records),'performance test designs and loopback-only JMX.')
