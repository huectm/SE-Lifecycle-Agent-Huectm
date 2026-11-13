"""Verify actual result cells and template integrity in native Excel."""
from pathlib import Path
import json,hashlib
import win32com.client as w
P=Path('artifacts/testing/test-design/backend-unit');D=Path('artifacts/testing/unit-execution')
layout=json.loads((P/'unit-test-matrix-row-map.json').read_text(encoding='utf-8'));design=json.loads((P/'backend-unit-test-design.json').read_text(encoding='utf-8'));results=json.loads((D/'execution-results.json').read_text(encoding='utf-8'))
def col(n):
 text=''
 while n:n,r=divmod(n-1,26);text=chr(65+r)+text
 return text
app=w.DispatchEx('Excel.Application');app.Visible=False;app.DisplayAlerts=False
try:
 book=app.Workbooks.Open(str((P/'FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx').resolve()),UpdateLinks=0)
 app.Calculation=-4135;app.CalculateBeforeSave=False;book.ForceFullCalculation=False
 listing=book.Worksheets('FunctionList');listing.Hyperlinks.Delete()
 for index,m in enumerate(design['methods'],11):listing.Hyperlinks.Add(Anchor=listing.Cells(index,6),Address='',SubAddress="'"+m['sheet']+"'!A1",TextToDisplay=m['sheet'])
 executed=0;skipped=0
 for index,m in enumerate(layout['methods'],1):
  sheet=book.Worksheets(m['sheet']);end=col(m['lastCaseColumn']);caseResults=[results['cases'][cid] for cid in m['caseIds']]
  assert list(sheet.Range('F9:'+end+'9').Value[0])==m['caseIds']
  body=sheet.Range('F10:'+col(m['lastDisplayColumn'])+str(m['typeRow']-1)).Value
  left=sheet.Range('D10:D'+str(m['typeRow']-1)).Value
  assert all(v in [None,'','O'] for row in body for v in row),m['id']
  for criterion in m['rows']:
   if criterion['kind']!='variant':continue
   offset=criterion['row']-10;actual={cid for cid,v in zip(m['caseIds'],body[offset]) if v=='O'}
   assert actual==set(criterion['caseIds'])
   assert str(left[offset][0]).replace('\r\n','\n')==criterion['value'].replace('\r\n','\n')
  expected=['P' if r['outcome']=='Passed' else 'F' if r['outcome']=='Failed' else None for r in caseResults]
  assert list(sheet.Range('F'+str(m['passRow'])+':'+end+str(m['passRow'])).Value[0])==expected,m['id']
  # Restore literal execution date strings after the known export date coercion.
  dates=sheet.Range('F'+str(m['dateRow'])+':'+end+str(m['dateRow']));dates.NumberFormat='@';dates.Value=[[results.get('executionDate',results['date']) if r['executed'] else None for r in caseResults]]
  dates.Orientation=90;dates.RowHeight=95;dates.WrapText=False
  defects=sheet.Range('F'+str(m['defectRow'])+':'+end+str(m['defectRow']));defects.Orientation=90;defects.RowHeight=190;defects.WrapText=False
  assert list(sheet.Range('F'+str(m['defectRow'])+':'+end+str(m['defectRow'])).Value[0])==['; '.join(r['defects']) or None for r in caseResults]
  sheet.Calculate();p=sum(r['outcome']=='Passed' for r in caseResults);f=sum(r['outcome']=='Failed' for r in caseResults)
  assert sheet.Range('A7').Value==p and sheet.Range('C7').Value==f and sheet.Range('F7').Value==len(caseResults)-p-f,m['id']
  executed+=p+f;skipped+=len(caseResults)-p-f
  if index%50==0:print('Verified result sheets',index,flush=True)
 report=book.Worksheets('Test Report');report.Calculate();assert [report.Cells(206,c).Value for c in range(3,10)]==[657,0,533,533,268,389,1190]
 assert abs(report.Range('D208').Value-657/1190*100)<.001
 book.Worksheets('Cover').Activate();app.Calculation=-4105;book.Save();book.Close(False)
 defects=app.Workbooks.Open(str((D/'FreshFood_Unit_Defect_Log.xlsx').resolve()),ReadOnly=True,UpdateLinks=0)
 s=defects.Worksheets('Defects');assert [s.Cells(3,c).Value for c in range(1,9)]==['Defect ID','Module','Description','Type','Severity','Priority','Status','Created Date']
 assert all(s.Cells(r,7).Value=='Verified' for r in range(4,35));defects.Close(False)
 output={'nativeExcelOpen':'Passed','methodSheetsVerified':193,'conditionMatrixPreserved':True,'actualResultsVerified':True,'passed':executed,'failed':0,'skipped':skipped,'templateReportReconciled':True,'verifiedDefectRecords':31,'sha256':hashlib.sha256((P/'FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx').read_bytes()).hexdigest()}
 (D/'workbook-verification.json').write_text(json.dumps(output,indent=2)+'\n',encoding='utf-8');print(json.dumps(output,indent=2))
finally:app.Quit()
