"""Record the authorized correction and pending execution gate in the living master."""
from pathlib import Path
from copy import deepcopy
import json
from docx import Document
from docx.shared import Cm
from docx.enum.text import WD_ALIGN_PARAGRAPH
target=Path('artifacts/Requirements_Analysis_Design_Specification.docx');doc=Document(target)
title='Unit Test Execution Review'
assert not any(p.text==title for p in doc.paragraphs),'Already synchronized'
p=doc.add_heading(title,3)
for r in p.runs:r.bold=True
notes=[
'Execution evidence dated 2026-11-05: 48 xUnit classes map the 1,190 planned case identifiers. The final design-case run has 657 passed, zero failed and 533 skipped; three supplemental trusted-payment guard rejection cases passed separately. Existing regressions have 66 passed and one skipped PostgreSQL opt-in case. The original unit workbook contains actual results and its embedded Test Report; no separate report replaces it.',
'UT-DEF-001 was reproduced and logged before correction: verified initial paid acceptance was rejected at deferred payment row P02. P02 now requires the trusted Initial and VerifiedPayment context and PendingPaid fulfillment state, then records the payment-region transition to Paid. External provider verification and correlation remain separate prerequisites. The correction retains the single table-driven OrderStateMachine and its existing transition identifiers.',
'Engineering erratum for UTM-087-TC003: the original expected transition list omitted P02, although the approved T01p table row schedules that payment follow-up. The executable assertion verifies I00, T01p, P01, P02 and the required PendingPaid/Paid result. The original pre-execution workbook is retained for audit; this paragraph records the refinement explicitly.',
'Measured final full-run coverage is 85.19 percent lines and 72.87 percent branches. Individual-condition coverage is not independently measured. Skipped symbolic vectors, component database cases and unresolved contract/testability constraints remain explicit. The requested coverage and completion gate is not met; these execution findings await QA review and do not imply release approval. Detailed evidence is retained in artifacts/testing/unit-execution/execution-results.json, failure-history.json, fix-log.md, FreshFood_Unit_Defect_Log.xlsx and the preserved TRX runs.'
]
for text in notes:
 p=doc.add_paragraph(text);p.alignment=WD_ALIGN_PARAGRAPH.JUSTIFY;p.paragraph_format.first_line_indent=Cm(.5)
doc.save(target)
# A small excerpt preserves the changed section's actual styles and geometry for QA.
preview=Document();styles=preview.styles.element
for child in list(styles):styles.remove(child)
for child in doc.styles.element:styles.append(deepcopy(child))
body=preview._element.body
for child in list(body):body.remove(child)
active=False;tables=0
for element in doc._element.body:
 text=''.join(element.xpath('.//w:t/text()'))
 if text=='Unit Test Design Baseline':active=True
 if active:
  body.append(deepcopy(element))
  if element.tag.endswith('}tbl'):tables+=1
  if tables==1:break
for p in doc.paragraphs:
 if p.text==title or p.text in notes:body.append(deepcopy(p._p))
body.append(deepcopy(doc.sections[-1]._sectPr))
Path('scratch/unit-document-qa').mkdir(exist_ok=True)
preview.save('scratch/unit-document-qa/changed-section.docx')
print('Master correction notes synchronized; changed-section preview prepared.')
