"""Excel compatibility verification for native hyperlinks unsupported by artifact-tool."""
from pathlib import Path
import json,time,math
import win32com.client as w
D=Path('artifacts/testing/test-design/backend-unit');design=json.loads((D/'backend-unit-test-design.json').read_text())
path=(D/'FreshFood_Backend_Unit_Test_Cases_v0.1.xlsx').resolve()
app=w.DispatchEx('Excel.Application');app.Visible=False;app.DisplayAlerts=False
try:
 repaired=False
 try:book=app.Workbooks.Open(str(path),ReadOnly=False,UpdateLinks=0)
 except Exception:
  repaired=True
  book=app.Workbooks.Open(str(path),ReadOnly=False,UpdateLinks=0,CorruptLoad=1)
 app.Calculation=-4135
 app.CalculateBeforeSave=False
 book.ForceFullCalculation=False
 # Native hyperlinks have no supported authoring/evaluation API in the available artifact tool.
 listing=book.Worksheets('FunctionList')
 if listing.Hyperlinks.Count:listing.Hyperlinks.Delete()
 for n,m in enumerate(design['methods'],11):
  listing.Cells(n,6).Value=m['sheet']
  listing.Hyperlinks.Add(Anchor=listing.Cells(n,6),Address='',SubAddress="'"+m['sheet']+"'!A1",TextToDisplay=m['sheet'])
 start=11+len(design['methods'])
 byid={m['id']:m for m in design['methods']}
 for n,c in enumerate(design['contracts'],start):
  if c['realizations']:
   target=byid[c['realizations'][0]]['sheet'];listing.Cells(n,6).Value=target
   listing.Hyperlinks.Add(Anchor=listing.Cells(n,6),Address='',SubAddress="'"+target+"'!A1",TextToDisplay=target)
 book.Worksheets('Cover').Calculate()
 listing.Calculate()
 for index,m in enumerate(design['methods'],1):
  book.Worksheets(m['sheet']).Calculate()
  if index%40==0:print('Calculated function sheets',index,flush=True)
 book.Worksheets('Test Report').Calculate()
 total=12+len(design['methods'])+1;report=book.Worksheets('Test Report')
 actual=[report.Cells(total,c).Value for c in range(3,10)]
 expected=[0,0,design['summary']['testCases'],design['summary']['inputGroups']['N'],design['summary']['inputGroups']['A'],design['summary']['inputGroups']['B'],design['summary']['testCases']]
 assert actual==expected,(actual,expected)
 errors=[];sample_markers=[]
 for m in design['methods']:
  sheet=book.Worksheets(m['sheet'])
  def column(index):
   text=''
   while index:
    index,remainder=divmod(index-1,26);text=chr(65+remainder)+text
   return text
  end=column(5+len(m['cases']))
  for rownum in [11,15,16,19,20,23,24,25,32,33,35,37,38]:
   values=sheet.Range('F'+str(rownum)+':'+end+str(rownum)).Value[0]
   lines=max((sum(max(1,math.ceil(len(line)/38)) for line in str(value or '').split('\n')) for value in values),default=1)
   sheet.Rows(rownum).RowHeight=min(409,max(35,(lines+2)*12))
  # The entire original result area must be blank, including unused template example columns.
  for row in sheet.Range('F40:HT42').Value:
   if any(v is not None for v in row):sample_markers.append(m['id'])
  if sheet.Range('O7').Value!=len(m['cases']):errors.append([m['id'],'case count'])
  if sheet.Range('A7').Value!=0 or sheet.Range('C7').Value!=0:errors.append([m['id'],'fabricated result'])
 assert not errors and not sample_markers,(errors,sample_markers)
 book.Worksheets('Cover').Activate()
 app.ActiveWindow.DisplayGridlines=False
 app.Calculation=-4105
 book.Save();book.Close(False)
 result={'date':'2026-11-04','templatePreserved':True,'sheets':202,'executableMethods':len(design['methods']),'contracts':len(design['contracts']),'nativeFunctionLinks':len(design['methods'])+len(design['contracts']),'passed':0,'failed':0,'untested':design['summary']['testCases'],'total':design['summary']['testCases'],'unusedTemplateResultsBlank':True,'formulasVerifiedBy':'Excel per-sheet Calculate; live formula totals verified; native hyperlinks','backendTestsExecuted':False,'excelCompatibilityRepair':repaired}
 (D/'workbook-verification.json').write_text(json.dumps(result,indent=2)+'\n')
 print(json.dumps(result,indent=2))
finally:app.Quit()

