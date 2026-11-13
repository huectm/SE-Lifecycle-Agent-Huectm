"""
Specification Formatter Helper Module
Enforces all typography and layout rules for formal specification documents according to:
- AGENTS.md (Section 2.7)
- .agents/Rules/specification-document-rules.md
"""

import os
import docx
from docx.shared import Inches, Pt, Cm, RGBColor
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.enum.table import WD_TABLE_ALIGNMENT
from docx.oxml import OxmlElement, parse_xml
from docx.oxml.ns import nsdecls, qn

FONT_NAME = 'Segoe UI'
PRIMARY_COLOR = RGBColor(0, 51, 102)     # Deep Navy
TEXT_COLOR = RGBColor(33, 33, 33)        # Dark Charcoal
MUTED_COLOR = RGBColor(80, 80, 80)       # Gray for metadata / notes

def format_body_paragraph(p, text="", font_size=10, bold=False, italic=False, color=TEXT_COLOR):
    """
    Formats standard narrative body paragraph:
    - Justified alignment across both margins.
    - First-line indent exactly 0.5 cm.
    """
    p.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
    p.paragraph_format.first_line_indent = Inches(0.197)  # 0.5 cm
    p.paragraph_format.space_after = Pt(4)
    p.paragraph_format.line_spacing = 1.15
    if text:
        run = p.add_run(text)
        run.bold = bold
        run.italic = italic
        run.font.size = Pt(font_size)
        run.font.name = FONT_NAME
        run.font.color.rgb = color
    return p

def format_heading(p, text, level=1):
    """
    Formats chapter and section headings:
    - Mandatory BOLD formatting.
    - No first-line indentation.
    """
    p.alignment = WD_ALIGN_PARAGRAPH.LEFT
    p.paragraph_format.first_line_indent = Cm(0)
    p.paragraph_format.keep_with_next = True
    
    if level == 1:
        p.paragraph_format.space_before = Pt(16)
        p.paragraph_format.space_after = Pt(6)
        size = 14
        color = PRIMARY_COLOR
    elif level == 2:
        p.paragraph_format.space_before = Pt(12)
        p.paragraph_format.space_after = Pt(4)
        size = 12
        color = PRIMARY_COLOR
    elif level == 3:
        p.paragraph_format.space_before = Pt(8)
        p.paragraph_format.space_after = Pt(3)
        size = 11
        color = TEXT_COLOR
    else:
        p.paragraph_format.space_before = Pt(6)
        p.paragraph_format.space_after = Pt(2)
        size = 10.5
        color = TEXT_COLOR
        
    run = p.add_run(text)
    run.bold = True  # MANDATORY BOLD
    run.font.size = Pt(size)
    run.font.name = FONT_NAME
    run.font.color.rgb = color
    return p

def format_table_caption(p, caption_text):
    """
    Formats table title positioned ABOVE the table:
    - Format: Table <Chapter>.<Seq>: <Title>
    - Mandatory BOLD formatting.
    - Left-aligned, no first-line indent, keep_with_next = True.
    """
    p.alignment = WD_ALIGN_PARAGRAPH.LEFT
    p.paragraph_format.first_line_indent = Cm(0)
    p.paragraph_format.space_before = Pt(12)
    p.paragraph_format.space_after = Pt(4)
    p.paragraph_format.keep_with_next = True
    
    run = p.add_run(caption_text)
    run.bold = True  # MANDATORY BOLD
    run.font.size = Pt(10)
    run.font.name = FONT_NAME
    run.font.color.rgb = PRIMARY_COLOR
    return p

def format_figure_caption(p, caption_text):
    """
    Formats figure title positioned BELOW the figure:
    - Format: Figure <Chapter>.<Seq>: <Title>
    - Mandatory BOLD formatting.
    - Horizontally centered, no first-line indent.
    """
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.paragraph_format.first_line_indent = Cm(0)
    p.paragraph_format.space_before = Pt(4)
    p.paragraph_format.space_after = Pt(12)
    
    run = p.add_run(caption_text)
    run.bold = True  # MANDATORY BOLD
    run.font.size = Pt(9.5)
    run.font.name = FONT_NAME
    run.font.color.rgb = MUTED_COLOR
    return p

def style_table(table, header_bg="EAECEE", font_size=9.5):
    """
    Applies standard styling to tables:
    - Header row: bold, centered, background shading, unindented.
    - Data rows: cell content justified, unindented.
    - IDs and short codes: centered.
    """
    table.alignment = WD_TABLE_ALIGNMENT.CENTER
    table.autofit = False
    
    # Header row
    hdr_row = table.rows[0]
    for cell in hdr_row.cells:
        tcPr = cell._tc.get_or_add_tcPr()
        shd = parse_xml(f'<w:shd {nsdecls("w")} w:fill="{header_bg}"/>')
        tcPr.append(shd)
        for p in cell.paragraphs:
            p.alignment = WD_ALIGN_PARAGRAPH.CENTER  # Centered header
            p.paragraph_format.first_line_indent = Cm(0)
            p.paragraph_format.space_before = Pt(3)
            p.paragraph_format.space_after = Pt(3)
            for r in p.runs:
                r.bold = True  # MANDATORY BOLD
                r.font.size = Pt(font_size)
                r.font.name = FONT_NAME
                
    # Data rows
    for row in table.rows[1:]:
        for col_idx, cell in enumerate(row.cells):
            for p in cell.paragraphs:
                p.paragraph_format.first_line_indent = Cm(0)  # No first line indent in cells
                p.paragraph_format.space_before = Pt(2)
                p.paragraph_format.space_after = Pt(2)
                
                # Check if cell is short ID/Code column (first column or short text)
                cell_text = cell.text.strip()
                if col_idx == 0 or len(cell_text) <= 12 and ('-' in cell_text or cell_text.isdigit()):
                    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
                else:
                    p.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY  # Justified body cell text
                    
                for r in p.runs:
                    r.font.size = Pt(font_size)
                    r.font.name = FONT_NAME
                    r.font.color.rgb = TEXT_COLOR

def embed_figure(doc, target_elem, image_path, caption_text, width=Inches(6.2)):
    """
    Embeds a centered static image followed by a BOLD figure caption below.
    """
    if not os.path.exists(image_path):
        print(f"Warning: Figure image path does not exist: {image_path}")
        return target_elem

    # 1. Image paragraph (centered)
    pic_p = doc.add_paragraph()
    pic_p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    pic_p.paragraph_format.first_line_indent = Cm(0)
    pic_p.paragraph_format.space_before = Pt(12)
    pic_p.paragraph_format.space_after = Pt(4)
    run = pic_p.add_run()
    run.add_picture(image_path, width=width)
    target_elem.addnext(pic_p._element)
    current_elem = pic_p._element

    # 2. Figure caption directly BELOW the figure
    cap_p = doc.add_paragraph()
    format_figure_caption(cap_p, caption_text)
    current_elem.addnext(cap_p._element)
    
    return cap_p._element
