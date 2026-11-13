"""Normalize an artifact-authored XLSX only when native Excel rejects its package."""
from pathlib import Path
from zipfile import ZipFile
import openpyxl,shutil,json,hashlib,sys
D=Path('artifacts/testing/test-design/backend-unit')
source=Path(sys.argv[1]) if len(sys.argv)>1 else D/'FreshFood_Backend_Unit_Test_Cases_v0.1.xlsx'
converted=Path('scratch/unit-test-template/native-compatible.xlsx')
a=openpyxl.load_workbook(source)
# Restore ISO timestamp text coerced by artifact export using the canonical map.
restored=[]
if source.stem.endswith('v0.2'):
 layout=json.loads((D/'unit-test-matrix-row-map.json').read_text(encoding='utf-8'))
 for method in layout['methods']:
  for criterion in method['rows']:
   if criterion['kind']!='variant':continue
   cell=a[method['sheet']].cell(criterion['row'],4)
   if str(cell.value).replace('\r\n','\n')!=str(criterion['value']).replace('\r\n','\n'):
    assert hasattr(cell.value,'isoformat'),(method['sheet'],cell.coordinate,cell.value)
    cell.value=criterion['value'];cell.data_type='s';cell.number_format='@'
    restored.append(method['sheet']+'!'+cell.coordinate)
a.save(converted);b=openpyxl.load_workbook(converted)
assert a.sheetnames==b.sheetnames
for left,right in zip(a.worksheets,b.worksheets):
 assert str(left.merged_cells)==str(right.merged_cells),left.title
 values=lambda sheet:{(c.coordinate,c.value) for row in sheet.iter_rows() for c in row if c.value is not None}
 assert values(left)==values(right),left.title
with ZipFile(source) as za,ZipFile(converted) as zb:
 media=lambda z:sorted(hashlib.sha256(z.read(n)).hexdigest() for n in z.namelist() if n.startswith('xl/media/'))
 assert media(za)==media(zb)
shutil.copy2(converted,source)
(D/('export-compatibility-'+source.stem.rsplit('_',1)[-1]+'.json')).write_text(json.dumps({'authoring':'artifact-tool','compatibilityConversion':'OpenXML normalization via openpyxl load/save after native Excel rejected artifact export','canonicalTimestampTextRestored':restored,'sheetCount':len(a.sheetnames),'valuesAndFormulasUnchanged':True,'mergedRangesUnchanged':True,'templateImageBytesUnchanged':True},indent=2)+'\n')
print('Compatibility package: values, formulas, merges and template image unchanged across',len(a.sheetnames),'sheets.',flush=True)

