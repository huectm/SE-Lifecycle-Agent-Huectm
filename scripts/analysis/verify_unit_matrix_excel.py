"""Verify corrected O-selection matrices and dynamic result rows in native Excel."""
from pathlib import Path
import json,hashlib
import win32com.client as w
D=Path('artifacts/testing/test-design/backend-unit')
design=json.loads((D/'backend-unit-test-design.json').read_text(encoding='utf-8'))
layout=json.loads((D/'unit-test-matrix-row-map.json').read_text(encoding='utf-8'))
byid={m['id']:m for m in design['methods']}
path=(D/'FreshFood_Backend_Unit_Test_Cases_v0.2.xlsx').resolve()
def col(n):
 text=''
 while n:n,r=divmod(n-1,26);text=chr(65+r)+text
 return text
app=w.DispatchEx('Excel.Application');app.Visible=False;app.DisplayAlerts=False
try:
 book=app.Workbooks.Open(str(path),ReadOnly=False,UpdateLinks=0)
 app.Calculation=-4135;app.CalculateBeforeSave=False;app.ScreenUpdating=False;book.ForceFullCalculation=False
 listing=book.Worksheets('FunctionList')
 if listing.Hyperlinks.Count:listing.Hyperlinks.Delete()
 for row,m in enumerate(design['methods'],11):
  listing.Cells(row,6).Value=m['sheet'];listing.Hyperlinks.Add(Anchor=listing.Cells(row,6),Address='',SubAddress="'"+m['sheet']+"'!A1",TextToDisplay=m['sheet'])
 for row,c in enumerate(design['contracts'],11+len(design['methods'])):
  if c['realizations']:
   target=byid[c['realizations'][0]]['sheet'];listing.Cells(row,6).Value=target;listing.Hyperlinks.Add(Anchor=listing.Cells(row,6),Address='',SubAddress="'"+target+"'!A1",TextToDisplay=target)
 book.Worksheets('Cover').Calculate();listing.Calculate()
 checked_rows=0;markers=0
 for n,info in enumerate(layout['methods'],1):
  m=byid[info['id']];sheet=book.Worksheets(info['sheet']);end=col(info['lastDisplayColumn'])
  header=list(sheet.Range('F9:'+col(info['lastCaseColumn'])+'9').Value[0])
  assert header==info['caseIds'],('header',info['id'])
  body=sheet.Range('F10:'+end+str(info['typeRow']-1)).Value
  for values in body:assert all(v in [None,'','O'] for v in values),('non-marker in test column',info['id'])
  for criterion in info['rows']:
   if criterion['kind']!='variant':continue
   values=body[criterion['row']-10]
   actual={info['caseIds'][i] for i,v in enumerate(values[:len(header)]) if v=='O'}
   assert actual==set(criterion['caseIds']),('wrong selection',info['id'],criterion['row'])
   assert str(sheet.Cells(criterion['row'],4).Value).replace('\r\n','\n')==str(criterion['value']).replace('\r\n','\n'),('left value',info['id'],criterion['row'])
   checked_rows+=1;markers+=len(actual)
  types=list(sheet.Range('F'+str(info['typeRow'])+':'+col(info['lastCaseColumn'])+str(info['typeRow'])).Value[0])
  assert types==[c['inputType'] for c in m['cases']],info['id']
  assert all(v is None for row in sheet.Range('F'+str(info['passRow'])+':'+end+str(info['defectRow'])).Value for v in row),('actual result not blank',info['id'])
  assert sheet.Range('L3').Value is None,('executor not blank',info['id'])
  sheet.Calculate()
  assert sheet.Range('O7').Value==len(m['cases']),('total',info['id'])
  assert sheet.Range('A7').Value==0 and sheet.Range('C7').Value==0,('fabricated result',info['id'])
  # Repeated matrix rows require expanded print areas instead of template's example-only area.
  sheet.PageSetup.PrintArea='$A$1:$'+end+'$'+str(info['lastRow'])
  if n%40==0:print('Verified template matrices',n,flush=True)
 report=book.Worksheets('Test Report');report.Calculate();total=12+len(design['methods'])+1
 expected=[0,0,design['summary']['testCases'],design['summary']['inputGroups']['N'],design['summary']['inputGroups']['A'],design['summary']['inputGroups']['B'],design['summary']['testCases']]
 assert [report.Cells(total,c).Value for c in range(3,10)]==expected
 report.PageSetup.PrintArea='$A$1:$I$'+str(total+6)
 listing.PageSetup.PrintArea='$A$1:$H$'+str(10+len(design['methods'])+len(design['contracts']))
 book.Worksheets('Cover').Activate();app.ActiveWindow.DisplayGridlines=False
 app.Calculation=-4105;book.Save();book.Close(False)
 result={'version':'0.2','template':'templates/Test Documents/Template_Unit Test Case.xls','notation':'O/blank matrix; left-side conditions and confirmation values','methodSheets':len(layout['methods']),'unchangedTestCases':design['summary']['testCases'],'criterionRowsVerified':checked_rows,'selectionMarkersVerified':markers,'allTestColumnsOOrBlank':True,'inputAndExpectedValuesVerified':True,'stableCaseIdsVerified':True,'passed':0,'failed':0,'untested':design['summary']['testCases'],'actualExecutionRegionsBlank':True,'dynamicResultFormulasVerified':True,'backendTestsExecuted':False,'workbookSha256':hashlib.sha256(path.read_bytes()).hexdigest()}
 (D/'matrix-workbook-verification-v0.2.json').write_text(json.dumps(result,indent=2)+'\n')
 print(json.dumps(result,indent=2))
finally:app.Quit()

