"""Execute the JMeter transport/reporting harness ONLY against a temporary loopback server."""
from pathlib import Path
from http.server import ThreadingHTTPServer,BaseHTTPRequestHandler
from urllib.parse import parse_qs,urlparse
import csv,json,time,threading,subprocess,statistics,html,tomllib,os
ROOT=Path(__file__).resolve().parents[2]
OUT=ROOT/'artifacts/test-results/tutorialsninja-performance/local-validation'
OUT.mkdir(parents=True,exist_ok=True)
class MockRegistration(BaseHTTPRequestHandler):
    def log_message(self,*args):pass
    def reply(self,status,body,location=None):
        encoded=body.encode();self.send_response(status)
        self.send_header('Content-Type','text/html; charset=utf-8');self.send_header('Content-Length',str(len(encoded)))
        if location:self.send_header('Location',location)
        self.end_headers();self.wfile.write(encoded)
    def do_GET(self):
        time.sleep(.02)
        route=parse_qs(urlparse(self.path).query).get('route',[''])[0]
        if route=='account/register':self.reply(200,'<h1>Register Account</h1><form method="post"></form>')
        elif route=='account/success':self.reply(200,'<h1>Your Account Has Been Created!</h1>')
        else:self.reply(404,'Not found')
    def do_POST(self):
        self.rfile.read(int(self.headers.get('Content-Length','0')));time.sleep(.02)
        self.reply(302,'','/index.php?route=account/success')
class LocalServer(ThreadingHTTPServer):
    request_queue_size=512
    daemon_threads=True
server=LocalServer(('127.0.0.1',0),MockRegistration)
threading.Thread(target=server.serve_forever,daemon=True).start()
configured=tomllib.loads((Path.home()/'.codex/config.toml').read_text(encoding='utf-8')).get('mcp_servers',{}).get('jmeter',{}).get('env',{}).get('JMETER_HOME','')
candidates=[Path(configured)] if configured else []
candidates += [Path.home()/'Downloads/apache-jmeter-5.6.3/apache-jmeter-5.6.3']
home=next((p for p in candidates if (p/'bin/ApacheJMeter.jar').exists()),None)
if home is None:raise SystemExit('JMeter runtime not found. No external requests were made.')
results=[]
try:
 for name,threads,iterations in [('baseline-1',1,3),('load-100',100,1),('stress-200',200,1)]:
  target=OUT/name;target.mkdir(exist_ok=True)
  jtl=target/'samples.jtl'
  if jtl.exists():raise SystemExit('Existing run would be overwritten: '+str(jtl))
  cmd=['java','-jar',str(home/'bin/ApacheJMeter.jar'),'-n','-t',str(ROOT/'tests/performance/registration_local_harness.jmx'),'-l',str(jtl),'-j',str(target/'jmeter.log'),f'-Jport={server.server_port}',f'-Jthreads={threads}',f'-Jiterations={iterations}','-Jramp=0','-Jjmeter.save.saveservice.output_format=csv','-Jjmeter.save.saveservice.thread_counts=true','-Jsampleresult.timestamp.start=true']
  print('LOCAL HARNESS',name,'JMeter home:',home,flush=True)
  start=time.time()
  completed=subprocess.run(cmd,cwd=ROOT,capture_output=True,text=True,encoding='utf-8',errors='replace',timeout=150)
  (target/'console.txt').write_text(completed.stdout+'\n'+completed.stderr,encoding='utf-8')
  print(completed.stdout[-1200:],flush=True)
  row=dict(run=name,scope='LOCAL SYNTHETIC HARNESS ONLY',threads_configured=threads,iterations=iterations,exit_code=completed.returncode,wall_seconds=round(time.time()-start,3),target='127.0.0.1',jmeter_home=str(home))
  if jtl.exists():
   samples=list(csv.DictReader(jtl.open(encoding='utf-8-sig')))
   tx=[r for r in samples if r['label']=='REGISTRATION_TRANSACTION']
   elapsed=[float(r['elapsed']) for r in tx]
   if elapsed:
    values=sorted(elapsed);percent=lambda q: values[max(0,__import__('math').ceil(q*len(values))-1)]
    row.update(transactions=len(tx),failed=sum(r['success'].lower()!='true' for r in tx),mean_ms=round(statistics.mean(elapsed),3),p95_ms=percent(.95),p99_ms=percent(.99),max_ms=max(elapsed),max_observed_active_threads=max(int(r.get('allThreads',0)) for r in tx),under_6000_ms=statistics.mean(elapsed)<6000)
    row['harness_status']='PASS' if row['failed']==0 and len(tx)==threads*iterations and completed.returncode==0 else 'FAIL'
   else:row['harness_status']='FAIL - no transaction samples'
  else:row['harness_status']='FAIL - no JTL'
  results.append(row)
finally:server.shutdown();server.server_close()
(OUT/'summary.json').write_text(json.dumps(results,indent=2),encoding='utf-8')
keys=list(dict.fromkeys(k for r in results for k in r))
with (OUT/'summary.csv').open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=keys);w.writeheader();w.writerows(results)
head='<html lang="en"><meta charset="utf-8"><title>JMeter local harness validation</title><style>body{font:16px Arial;margin:40px}table{border-collapse:collapse}td,th{padding:10px;border:1px solid #ccc}.notice{background:#fff1c2;padding:16px}</style><h1>JMeter local harness validation</h1><p class="notice">TutorialsNinja was NOT load-tested. These results are from a temporary loopback HTTP mock with artificial 20 ms request delays. They validate the JMeter script and reporting pipeline only. None of the production performance requirements is verified.</p>'
cols=['run','threads_configured','transactions','failed','mean_ms','p95_ms','max_observed_active_threads','harness_status']
body='<table><tr>'+''.join('<th>'+c+'</th>' for c in cols)+'</tr>'+''.join('<tr>'+''.join('<td>'+html.escape(str(r.get(c,'N/A')))+'</td>' for c in cols)+'</tr>' for r in results)+'</table></html>'
(OUT/'report.html').write_text(head+body,encoding='utf-8')
print(json.dumps(results,indent=2),flush=True)
raise SystemExit(0 if all(r.get('harness_status')=='PASS' for r in results) else 1)
