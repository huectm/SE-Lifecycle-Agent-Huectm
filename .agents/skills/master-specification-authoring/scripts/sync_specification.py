"""
Master Specification Synchronization Script
Executes synchronization and formatting of artifacts into:
artifacts/Requirements_Analysis_Design_Specification.docx

Governed by:
- AGENTS.md (Section 2.7)
- .agents/Rules/specification-document-rules.md
- .agents/skills/master-specification-authoring/SKILL.md
"""

import os
import re
import shutil
import docx
from docx.shared import Inches, Pt, Cm, RGBColor
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.enum.table import WD_TABLE_ALIGNMENT
from docx.oxml import parse_xml
from docx.oxml.ns import nsdecls

import specification_formatter as sf

TEMPLATE_PATH = 'templates/Template_Requirements_Analysis_Design_Specification.docx'
TARGET_PATH = 'artifacts/Requirements_Analysis_Design_Specification.docx'

def ensure_master_document():
    """Initializes target master document from template if not existing."""
    if not os.path.exists(TARGET_PATH):
        print(f"Instantiating {TARGET_PATH} from {TEMPLATE_PATH}...")
        os.makedirs(os.path.dirname(TARGET_PATH), exist_ok=True)
        shutil.copyfile(TEMPLATE_PATH, TARGET_PATH)
    return docx.Document(TARGET_PATH)

def apply_bold_to_headings_and_captions(doc):
    """
    Enforces bold styling for:
    - All Heading styles (Heading 1 to 9, Title, Subtitle)
    - All Table captions ('Table <Chapter>.<Seq>: ...')
    - All Figure captions ('Figure <Chapter>.<Seq>: ...')
    """
    print("Enforcing bold formatting on headings, titles, table captions, and figure captions...")
    for p in doc.paragraphs:
        txt = p.text.strip()
        if not txt:
            continue
            
        # 1. Document Headings
        if p.style.name.startswith('Heading') or p.style.name in ['Title', 'Subtitle']:
            p.paragraph_format.first_line_indent = Cm(0)
            for r in p.runs:
                r.bold = True
            continue
            
        # 2. Table captions (ABOVE table, Bold)
        if txt.startswith('Table '):
            p.alignment = WD_ALIGN_PARAGRAPH.LEFT
            p.paragraph_format.first_line_indent = Cm(0)
            p.paragraph_format.keep_with_next = True
            for r in p.runs:
                r.bold = True
            continue
            
        # 3. Figure captions (BELOW figure, Centered, Bold)
        if txt.startswith('Figure '):
            p.alignment = WD_ALIGN_PARAGRAPH.CENTER
            p.paragraph_format.first_line_indent = Cm(0)
            for r in p.runs:
                r.bold = True
            continue

def apply_body_and_table_typography(doc):
    """
    Enforces typography rules:
    - Body text: Justified alignment, 0.5 cm first-line indent.
    - Bullet/Number lists: unindented.
    - Tables: Header row bold, centered; data cells justified, unindented.
    """
    print("Enforcing body typography (Justify, 0.5 cm indent) and table cell rules...")
    for p in doc.paragraphs:
        txt = p.text.strip()
        if not txt:
            continue
            
        # Skip headings, captions, lists
        if (p.style.name.startswith('Heading') or 
            p.style.name in ['Title', 'Subtitle'] or 
            txt.startswith('Table ') or 
            txt.startswith('Figure ') or 
            p.style.name.startswith('List') or 
            txt.startswith('- ') or 
            txt.startswith('* ') or 
            re.match(r'^\d+\.', txt)):
            continue
            
        # Standard narrative paragraph
        p.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
        p.paragraph_format.first_line_indent = Inches(0.197)  # 0.5 cm
        p.paragraph_format.line_spacing = 1.15
        p.paragraph_format.space_after = Pt(4)

    # Tables
    for tbl in doc.tables:
        sf.style_table(tbl)

def sync_master_specification():
    """Main synchronization routine."""
    doc = ensure_master_document()
    
    # Apply comprehensive formatting
    apply_bold_to_headings_and_captions(doc)
    apply_body_and_table_typography(doc)
    
    doc.save(TARGET_PATH)
    print(f"Master Specification successfully synchronized and formatted at: {TARGET_PATH}")

if __name__ == '__main__':
    sync_master_specification()
