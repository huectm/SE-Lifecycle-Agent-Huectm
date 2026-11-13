"""Populate approved legacy XLS templates using native Excel; keep sheet/column structure."""
from pathlib import Path
import json
import win32com.client as win32
ROOT=Path(__file__).resolve().parents[2];OUT=ROOT/'artifacts/testing/tutorialsninja-performance'
cases=json.loads((OUT/'performance-test-cases.json').read_text(encoding='utf-8'))
xl=win32.DispatchEx('Excel.Application');xl.Visible=False;xl.DisplayAlerts=False
try:
 wb=xl.Workbooks.Open(str(ROOT/'templates/Test Documents/Preformance_Test case.xls'))
 cover=wb.Worksheets(1);s=wb.Worksheets('KBKTHN')
 def write(sheet,row,col,value):sheet.Cells(row,col).MergeArea.Cells(1,1).Value=value
 cover_values={(1,5):'SOFTWARE QUALITY ASSURANCE',(9,1):'TutorialsNinja Registration',(10,1):'PERFORMANCE TEST SCENARIOS',(16,3):'Project code',(16,5):'UC-REG-01',(17,3):'Document code',(17,5):'REG-PERF-1.0',(18,3):'Version',(18,5):'1.0 - Draft',(21,1):'Prepared by:',(22,3):'SE Lifecycle Agent',(22,6):'2026-10-28',(23,3):'Test analyst',(27,1):'Reviewed by:',(28,3):'TBD - QA reviewer',(28,6):'Pending',(29,3):'QA / Test Lead',(33,1):'Approved by:',(34,3):'TBD - Authorized owner',(34,6):'Not approved',(35,3):'Authorized Approver',(38,1):'DOCUMENT CHANGE RECORD',(40,1):'Date',(40,2):'Location',(40,3):'Reason',(40,4):'Source',(40,5):'Old version',(40,6):'Change description',(40,7):'New version',(41,1):'2026-10-28',(41,2):'All',(41,3):'Initial design',(41,4):'User request',(41,5):'-',(41,6):'10 target cases not executed; local harness results kept separate.',(41,7):'1.0'}
 for (r,c),v in cover_values.items():write(cover,r,c,v)
 for r in range(1,13):
  for c in range(1,23):
   cell=s.Cells(r,c)
   if cell.MergeArea.Cells(1,1).Address!=cell.Address:continue
   value=cell.Value
   if isinstance(value,str) and value.strip():
    print('Template header',r,c,value[:65])
 # Repeat the existing six-row metric block; preserve columns and approved tab names.
 for i in range(2,10):s.Range('A13:O18').Copy(Destination=s.Range(f'A{13+i*6}'))
 write(s,1,3,'PERFORMANCE TEST SCENARIOS - TARGET NOT EXECUTED')
 write(s,8,1,'Script construction and execution scope:')
 for row,title in [(2,'Passed target cases'),(3,'Failed target cases'),(4,'Pending evaluation'),(5,'Not executed target cases'),(6,'Total target cases')]:write(s,row,3,title)
 for row,val in [(2,0),(3,0),(4,0),(5,10),(6,10)]:write(s,row,5,val)
 # Original instruction/section cells are translated in place.
 for row in [9,10]:
  for col in range(1,23):
   cell=s.Cells(row,col)
   if cell.MergeArea.Cells(1,1).Address==cell.Address and isinstance(cell.Value,str) and cell.Value.strip():
    cell.Value=('Script and scope: 10 public-target cases are NOT EXECUTED because the user has no owner authorization. Local JMeter mock checks at 1/100/200 threads passed; these do not verify target SLAs. See README.md and local-validation/report.html.' if row==9 else 'Scenarios: daily volume, response time, supported concurrency, spike, stress, recovery, endurance and availability.')
 headers={1:'ID',2:'Script / Scenario',3:'Target',4:'Users / Data',5:'Expected metric',7:'Actual results',12:'Summary',13:'Result (Pass/Fail)',14:'Report path',15:'Script path'}
 for col,val in headers.items():write(s,11,col,val)
 for col in range(7,12):write(s,12,col,f'Run {col-6}')
 for i,case in enumerate(cases):
  row=13+i*6
  for off in range(6):
   for col in range(5,16):
    cell=s.Cells(row+off,col)
    if cell.MergeArea.Cells(1,1).Address==cell.Address:cell.Value=None
  for col,val in {1:case['id'],2:case['title'],3:'tutorialsninja.com\nNOT AUTHORIZED',4:case['workload'],14:'README.md; target not executed',15:'tests/performance/registration_local_harness.jmx (loopback validation only)'}.items():write(s,row,col,val)
  metrics=[('Technical errors','Record; validity prerequisite'),('Response time mean','<6 seconds at supported load'),('Capacity measure',case['duration']),('Throughput','1000 sessions/18h for PERF-02; otherwise record'),('CPU','Observe; threshold TBD'),('RAM','Observe; threshold TBD')]
  for off,(metric,expected) in enumerate(metrics):
   write(s,row+off,5,metric);write(s,row+off,6,expected)
   for col in range(7,12):write(s,row+off,col,'NOT RUN')
   write(s,row+off,12,'Not measured')
   write(s,row+off,13,'NOT RUN' if off==0 else 'Not evaluated')
  write(s,row,6,case['expected'])
  s.Range(f'A{row}:O{row+5}').WrapText=True
  s.Range(f'A{row}:O{row+5}').VerticalAlignment=-4160
  s.Rows(row).RowHeight=120
  for off in range(1,6):s.Rows(row+off).RowHeight=52
 s.Range('B13:B72').ColumnWidth=25;s.Range('C13:C72').ColumnWidth=22;s.Range('D13:D72').ColumnWidth=35;s.Range('F13:F72').ColumnWidth=46;s.Range('M13:M72').ColumnWidth=17
 cover.Range('A41:J41').WrapText=True;cover.Rows(41).RowHeight=55
 s.PageSetup.PrintArea='$A$1:$O$72'
 xl.CalculateFullRebuild()
 wb.SaveAs(str(OUT/'Performance_Test_Cases.xls'),56)
 wb.SaveAs(str(OUT/'performance-preview-source.xlsx'),51)
 wb.Close(False)
 issues=xl.Workbooks.Open(str(ROOT/'templates/Test Documents/Template_Defect_log.xls'))
 d=issues.Worksheets('Defects');d.Range('A4:H50').ClearContents()
 values=['PERF-ENV-001','JMeter MCP runtime','Configured JMETER_HOME D:/apache-jmeter-5.6.3 does not exist. Expected: path containing bin/ApacheJMeter.jar. Actual: runtime found only in the nested Downloads folder. MCP initialize/tools-list succeeded earlier but does not prove execute_test_plan can run. Workaround: local JMeter CLI with resolved jar; external configuration was not modified.','Environment configuration','Low','Medium','Open - local CLI workaround','2026-10-28']
 for col,val in enumerate(values,1):d.Cells(4,col).Value=val
 d.Range('A4:H4').WrapText=True;d.Rows(4).RowHeight=160
 issues.SaveAs(str(OUT/'Environment_Issues.xls'),56);issues.Close(False)
 print('Saved performance workbook and environment issue log.')
finally:xl.Quit()
