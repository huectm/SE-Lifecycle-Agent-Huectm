"""
Build Master Specification Document
Loads templates/Template_Requirements_Analysis_Design_Specification.docx,
incorporates all artifacts from artifacts/diagrams/ and artifacts/requirements/,
mirrors table forms from examples/SWD392Example_RDS Document-VersionVietNhat.docx,
and outputs artifacts/Requirements_Analysis_Design_Specification.docx.
"""

import os
import re
import csv
import docx
from docx.shared import Inches, Pt, Cm, RGBColor
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.enum.table import WD_TABLE_ALIGNMENT
from docx.oxml import OxmlElement, parse_xml
from docx.oxml.ns import nsdecls, qn

import specification_formatter as sf

TEMPLATE_PATH = 'templates/Template_Requirements_Analysis_Design_Specification.docx'
TARGET_PATH = 'artifacts/Requirements_Analysis_Design_Specification.docx'
PRIMARY_HEX = "1B5E20"     # Forest Green for primary highlights
HEADER_BG = "E8F5E9"       # Soft green tint for table headers
ALT_ROW_BG = "F9FBF9"

def set_cell_properties(cell, bg_color=None, bold=False, font_size=9.5, align=WD_ALIGN_PARAGRAPH.JUSTIFY, text_color=None):
    if bg_color:
        tcPr = cell._tc.get_or_add_tcPr()
        shd = parse_xml(f'<w:shd {nsdecls("w")} w:fill="{bg_color}"/>')
        tcPr.append(shd)
    for p in cell.paragraphs:
        p.alignment = align
        p.paragraph_format.first_line_indent = Cm(0)
        p.paragraph_format.space_before = Pt(2)
        p.paragraph_format.space_after = Pt(2)
        for r in p.runs:
            r.bold = bold
            r.font.size = Pt(font_size)
            r.font.name = 'Segoe UI'
            if text_color:
                r.font.color.rgb = text_color

def set_table_data(table, data, header_bg=HEADER_BG, font_size=9.0):
    # Keep row 0 (header), remove older rows
    while len(table.rows) > 1:
        table._element.remove(table.rows[-1]._element)
        
    table.alignment = WD_TABLE_ALIGNMENT.CENTER
    table.autofit = False
    
    # Format Header Row
    if len(table.rows) > 0:
        for cell in table.rows[0].cells:
            set_cell_properties(cell, bg_color=header_bg, bold=True, font_size=9.5, align=WD_ALIGN_PARAGRAPH.CENTER)
            
    # Add Data Rows
    for r_idx, row_data in enumerate(data):
        row = table.add_row()
        bg = ALT_ROW_BG if r_idx % 2 == 1 else "FFFFFF"
        for c_idx, val in enumerate(row_data):
            if c_idx < len(row.cells):
                cell = row.cells[c_idx]
                cell.text = str(val)
                txt = str(val).strip()
                if c_idx == 0 or (len(txt) <= 12 and ('-' in txt or txt.isdigit() or txt in ['High', 'Medium', 'Low', 'Strict', 'Active'])):
                    align = WD_ALIGN_PARAGRAPH.CENTER
                else:
                    align = WD_ALIGN_PARAGRAPH.JUSTIFY
                set_cell_properties(cell, bg_color=bg, bold=(c_idx == 0), font_size=font_size, align=align)

def insert_caption_above_table(table, text, doc):
    """
    Inserts a mandatory bold table caption directly ABOVE the table.
    """
    p = doc.add_paragraph()
    p.alignment = WD_ALIGN_PARAGRAPH.LEFT
    p.paragraph_format.first_line_indent = Cm(0)
    p.paragraph_format.space_before = Pt(12)
    p.paragraph_format.space_after = Pt(4)
    p.paragraph_format.keep_with_next = True
    run = p.add_run(text)
    run.bold = True
    run.font.size = Pt(10.5)
    run.font.name = 'Segoe UI'
    run.font.color.rgb = RGBColor(27, 94, 32)
    table._element.addprevious(p._element)
    return p

def insert_paragraph_after(target_elem, text="", bold=False, italic=False, color_rgb=(0,0,0), font_size=10, align=None, first_line_indent=None):
    doc_body = target_elem.getparent()
    p = docx.text.paragraph.Paragraph(OxmlElement('w:p'), doc_body)
    
    if bold and text.strip().startswith("Table"):
        p.alignment = WD_ALIGN_PARAGRAPH.LEFT
        p.paragraph_format.first_line_indent = Cm(0)
        p.paragraph_format.space_before = Pt(12)
        p.paragraph_format.space_after = Pt(4)
        p.paragraph_format.keep_with_next = True
    elif text.strip().startswith("Figure"):
        p.alignment = WD_ALIGN_PARAGRAPH.CENTER
        p.paragraph_format.first_line_indent = Cm(0)
        p.paragraph_format.space_before = Pt(4)
        p.paragraph_format.space_after = Pt(12)
    else:
        p.alignment = align if align is not None else WD_ALIGN_PARAGRAPH.JUSTIFY
        p.paragraph_format.first_line_indent = first_line_indent if first_line_indent is not None else Inches(0.197)
        p.paragraph_format.space_after = Pt(4)
        p.paragraph_format.line_spacing = 1.15

    if text:
        run = p.add_run(text)
        run.bold = bold
        run.italic = italic
        run.font.size = Pt(font_size)
        run.font.name = 'Segoe UI'
        run.font.color.rgb = RGBColor(*color_rgb)
    target_elem.addnext(p._element)
    return p._element

def insert_styled_table_after(target_elem, doc, headers, data, col_widths=None, header_bg="2E7D32", font_size=8.5):
    """
    Creates and inserts a formatted table directly after target_elem.
    """
    tbl = doc.add_table(rows=1 + len(data), cols=len(headers))
    tbl.style = 'Table Grid'
    tbl.alignment = WD_TABLE_ALIGNMENT.CENTER
    tbl.autofit = False
    
    # Header Row
    for j, h in enumerate(headers):
        cell = tbl.rows[0].cells[j]
        cell.text = h
        set_cell_properties(cell, bg_color=header_bg, bold=True, font_size=9.0, align=WD_ALIGN_PARAGRAPH.CENTER)
        cell.paragraphs[0].runs[0].font.color.rgb = RGBColor(255, 255, 255)
        
    # Data Rows
    for r_idx, row_values in enumerate(data):
        row = tbl.rows[r_idx + 1]
        bg = ALT_ROW_BG if r_idx % 2 == 1 else "FFFFFF"
        for c_idx, val in enumerate(row_values):
            if c_idx < len(row.cells):
                cell = row.cells[c_idx]
                cell.text = str(val)
                txt = str(val).strip()
                align = WD_ALIGN_PARAGRAPH.CENTER if (c_idx == 0 or (len(txt) <= 15 and ('-' in txt or txt.isdigit()))) else WD_ALIGN_PARAGRAPH.JUSTIFY
                set_cell_properties(cell, bg_color=bg, bold=(c_idx == 0), font_size=font_size, align=align)
                
    # Widths
    if col_widths:
        for row in tbl.rows:
            for j, w in enumerate(col_widths):
                if j < len(row.cells):
                    row.cells[j].width = w
                    
    target_elem.addnext(tbl._element)
    return tbl._element

def insert_picture_after(target_elem, doc, image_path, width=Inches(6.2), caption_text=None):
    if not os.path.exists(image_path):
        print(f"Warning: Image path not found: {image_path}")
        return target_elem
        
    pic_p = doc.add_paragraph()
    pic_p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    pic_p.paragraph_format.first_line_indent = Cm(0)
    pic_p.paragraph_format.space_before = Pt(12)
    pic_p.paragraph_format.space_after = Pt(4)
    run = pic_p.add_run()
    run.add_picture(image_path, width=width)
    target_elem.addnext(pic_p._element)
    current_elem = pic_p._element
    
    if caption_text:
        cap_p = doc.add_paragraph()
        cap_p.alignment = WD_ALIGN_PARAGRAPH.CENTER
        cap_p.paragraph_format.first_line_indent = Cm(0)
        cap_p.paragraph_format.space_before = Pt(4)
        cap_p.paragraph_format.space_after = Pt(12)
        cap_run = cap_p.add_run(caption_text)
        cap_run.bold = True  # MANDATORY BOLD
        cap_run.font.size = Pt(9.5)
        cap_run.font.name = 'Segoe UI'
        cap_run.font.color.rgb = RGBColor(60, 60, 60)
        current_elem.addnext(cap_p._element)
        current_elem = cap_p._element
        
    return current_elem

def insert_uc_table(target_elem, doc, uc_dict):
    """
    Creates structured Use Case Description Table exactly matching 
    Tables 2-7 of examples/SWD392Example_RDS Document-VersionVietNhat.docx.
    """
    tbl = doc.add_table(rows=12, cols=4)
    tbl.style = 'Table Grid'
    tbl.alignment = WD_TABLE_ALIGNMENT.CENTER
    tbl.autofit = False
    
    def setup_row(r_idx, label, val, is_split=False, label2=None, val2=None):
        row = tbl.rows[r_idx]
        if not is_split:
            cell0 = row.cells[0]
            cell1 = row.cells[1]
            for c in row.cells[2:]:
                cell1.merge(c)
            cell0.text = label
            cell1.text = val
            set_cell_properties(cell0, bg_color="F2F4F4", bold=True, font_size=9.0, align=WD_ALIGN_PARAGRAPH.LEFT)
            set_cell_properties(cell1, bg_color="FFFFFF", bold=(r_idx==0), font_size=9.0, align=WD_ALIGN_PARAGRAPH.JUSTIFY)
            cell0.width = Inches(1.6)
            cell1.width = Inches(5.0)
        else:
            cell0 = row.cells[0]
            cell1 = row.cells[1]
            cell2 = row.cells[2]
            cell3 = row.cells[3]
            cell0.text = label
            cell1.text = val
            cell2.text = label2
            cell3.text = val2
            set_cell_properties(cell0, bg_color="F2F4F4", bold=True, font_size=9.0, align=WD_ALIGN_PARAGRAPH.LEFT)
            set_cell_properties(cell1, bg_color="FFFFFF", bold=False, font_size=9.0, align=WD_ALIGN_PARAGRAPH.LEFT)
            set_cell_properties(cell2, bg_color="F2F4F4", bold=True, font_size=9.0, align=WD_ALIGN_PARAGRAPH.LEFT)
            set_cell_properties(cell3, bg_color="FFFFFF", bold=False, font_size=9.0, align=WD_ALIGN_PARAGRAPH.LEFT)
            cell0.width = Inches(1.6)
            cell1.width = Inches(1.8)
            cell2.width = Inches(1.5)
            cell3.width = Inches(1.7)

    setup_row(0, "ID and Name:", uc_dict.get("id_name", ""))
    setup_row(1, "Created By:", uc_dict.get("created_by", "SE Lifecycle Engineering Team"), True, "Date Created:", uc_dict.get("date_created", "07/10/2026"))
    setup_row(2, "Primary Actor:", uc_dict.get("primary_actor", ""), True, "Secondary Actors:", uc_dict.get("secondary_actors", "—"))
    setup_row(3, "Description:", uc_dict.get("description", ""))
    setup_row(4, "Trigger:", uc_dict.get("trigger", ""))
    setup_row(5, "Preconditions:", uc_dict.get("preconditions", ""))
    setup_row(6, "Postconditions:", uc_dict.get("postconditions", ""))
    setup_row(7, "Normal Flow:", uc_dict.get("normal_flow", ""))
    setup_row(8, "Alternative Flows:", uc_dict.get("alt_flows", "None."))
    setup_row(9, "Exceptions:", uc_dict.get("exceptions", "None."))
    setup_row(10, "Priority:", uc_dict.get("priority", "High"))
    setup_row(11, "Business Rules:", uc_dict.get("business_rules", "—"))

    target_elem.addnext(tbl._element)
    return tbl._element

def insert_data_dictionary_table(target_elem, doc, entities_dict):
    """
    Creates Data Dictionary Table matching Table 8 of examples/SWD392Example_RDS Document-VersionVietNhat.docx:
    Columns (4): Name | Data Type | Length | Description
    With full-width Entity category rows.
    """
    tbl = doc.add_table(rows=1, cols=4)
    tbl.style = 'Table Grid'
    tbl.alignment = WD_TABLE_ALIGNMENT.CENTER
    tbl.autofit = False
    
    headers = ["Name", "Data Type", "Length", "Description"]
    for j, h in enumerate(headers):
        cell = tbl.rows[0].cells[j]
        cell.text = h
        set_cell_properties(cell, bg_color="2E7D32", bold=True, font_size=9.5, align=WD_ALIGN_PARAGRAPH.CENTER)
        cell.paragraphs[0].runs[0].font.color.rgb = RGBColor(255, 255, 255)
        
    for ent_name, (ent_desc, attrs) in entities_dict.items():
        cat_row = tbl.add_row()
        cell0 = cat_row.cells[0]
        for c in cat_row.cells[1:]:
            cell0.merge(c)
        cell0.text = f"{ent_name} ({ent_desc})"
        set_cell_properties(cell0, bg_color="E8F5E9", bold=True, font_size=9.5, align=WD_ALIGN_PARAGRAPH.LEFT, text_color=RGBColor(27, 94, 32))
        
        for attr in attrs:
            row = tbl.add_row()
            bg = ALT_ROW_BG if len(tbl.rows) % 2 == 1 else "FFFFFF"
            for j in range(4):
                c = row.cells[j]
                c.text = str(attr[j])
                align = WD_ALIGN_PARAGRAPH.CENTER if j in [1, 2] else (WD_ALIGN_PARAGRAPH.LEFT if j==0 else WD_ALIGN_PARAGRAPH.JUSTIFY)
                set_cell_properties(c, bg_color=bg, bold=(j==0), font_size=9.0, align=align)
            
    col_widths = [Inches(1.5), Inches(1.1), Inches(0.8), Inches(3.2)]
    for row in tbl.rows:
        for j, w in enumerate(col_widths):
            if j < len(row.cells):
                row.cells[j].width = w
                
    target_elem.addnext(tbl._element)
    return tbl._element

def build_full_specification():
    print(f"Loading base template: {TEMPLATE_PATH}...")
    doc = docx.Document(TEMPLATE_PATH)

    # 1. Update Title and metadata
    for p in doc.paragraphs:
        if '[PROJECT / SYSTEM NAME]' in p.text:
            p.text = 'FRESHFOOD — LOCAL ORGANIC FOOD E-COMMERCE PLATFORM'
            p.runs[0].bold = True
        elif 'Version: [x.x]' in p.text:
            p.text = 'Version: 1.0 (Baselined Requirements Specification)'
            p.runs[0].bold = True
        elif 'Prepared by: [Team / Student names]' in p.text:
            p.text = 'Prepared by: SE Lifecycle Engineering Team'
        elif 'Date: [dd/mm/yyyy]' in p.text:
            p.text = 'Date: 07/10/2026'

    # 2. Table 0: Record of Changes
    t0 = doc.tables[0]
    if len(t0.rows) > 1:
        cells = t0.rows[1].cells
        cells[0].text = '1.0'
        cells[1].text = '07/10/2026'
        cells[2].text = 'A'
        cells[3].text = 'SE Lifecycle Agent'
        cells[4].text = 'Initial baseline requirements deliverable synthesized from verified stakeholder requirements, TO-BE BPMN processes, Use Case models, and NFR specifications.'
        for c in cells:
            set_cell_properties(c, font_size=9.0, align=WD_ALIGN_PARAGRAPH.JUSTIFY)
        cells[0].paragraphs[0].alignment = WD_ALIGN_PARAGRAPH.CENTER
        cells[1].paragraphs[0].alignment = WD_ALIGN_PARAGRAPH.CENTER
        cells[2].paragraphs[0].alignment = WD_ALIGN_PARAGRAPH.CENTER

    # 3. Table 1: Business Objectives (BO-xx)
    insert_caption_above_table(doc.tables[1], "Table 1.1: Business Objectives", doc)
    bo_data = [
        ['BO-01', 'Expand customer reach and sales revenue through online channels', 'Achieve at least 35% of total store revenue through the online platform within 6 months of rollout.'],
        ['BO-02', 'Minimize perishable inventory waste and expired stock shrinkage', 'Reduce expired food disposal losses by >= 60% through batch-level tracking, automated clearance discounts, and FEFO sales priority.'],
        ['BO-03', 'Accelerate order processing and fulfillment turnaround', 'Decrease average order turnaround time (order placement to delivery dispatch) from 45 minutes to < 20 minutes.'],
        ['BO-04', 'Enhance customer retention and purchase frequency', 'Attain a repeat purchase rate of >= 40% within 90 days among registered customers.'],
        ['BO-05', 'Eliminate order delivery failures resulting from geographical misrouting', 'Maintain < 1% delivery failure rate by strictly enforcing maximum 10 km service distance limits and address verification.']
    ]
    set_table_data(doc.tables[1], bo_data)

    # 4. Table 2: Success Metrics (SM-xx)
    insert_caption_above_table(doc.tables[2], "Table 1.2: Success Metrics", doc)
    sm_data = [
        ['SM-01', 'Monthly Online Revenue Growth', '>= 15% month-over-month growth for the first 2 quarters.'],
        ['SM-02', 'Inventory Waste Ratio (Disposal / Import)', 'Kept under 2.5% of total imported perishable inventory weight.'],
        ['SM-03', 'Order Processing Efficiency', '90% of validated orders ready for dispatch within <= 15 minutes of confirmation.'],
        ['SM-04', 'Customer Retention Rate', '>= 40% of first-time buyers make a second purchase within 30 days.'],
        ['SM-05', 'Accurate Geocoded Deliveries', '>= 99% of completed delivery orders within the strictly validated 10 km radius.']
    ]
    set_table_data(doc.tables[2], sm_data)

    # 5. Table 3: Business Risks
    insert_caption_above_table(doc.tables[3], "Table 1.3: Business Risks Assessment", doc)
    risk_data = [
        ['RSK-01', 'Perishable food spoilage during delivery', 'Medium', 'High', 'Enforce insulated thermal packaging and restrict deliveries strictly to <= 10 km.', 'Store Manager'],
        ['RSK-02', 'Customer fake orders / phone unreachable on COD', 'High', 'Medium', 'Mandatory phone verification for first-time orders (BR-FUL-01) and SMS OTP registration.', 'Sales Lead'],
        ['RSK-03', 'Third-party map API downtime or incorrect geocoding', 'Low', 'High', 'Implement API timeout (3s) and fallback to administrative Ward dropdown selection with default fee (BR-DEL-02).', 'Lead Architect'],
        ['RSK-04', 'Concurrent overselling of scarce clearance batches', 'Medium', 'High', 'Database pessimistic row locking during checkout holding state (NFR-INT-01).', 'Database Designer']
    ]
    set_table_data(doc.tables[3], risk_data)

    # 6. Table 4: Assumptions and Dependencies
    insert_caption_above_table(doc.tables[4], "Table 1.4: Business Assumptions and Dependencies", doc)
    bad_data = [
        ['AS-01', 'Assumption', 'The business operates from a single fulfillment store/warehouse location in Da Nang.', 'Store Owner'],
        ['AS-02', 'Assumption', 'Product catalog focuses on pre-packaged or standard weighable units (kg, bunch, box).', 'Warehouse Manager'],
        ['AS-03', 'Assumption', 'Store staff possess basic smartphone/computer literacy for order processing.', 'HR Lead'],
        ['DP-01', 'Dependency', 'Google Maps / OpenStreetMap API for automated distance measurement.', 'External Service'],
        ['DP-02', 'Dependency', 'SePay / VietQR banking integration for automated payment notification webhooks.', 'Vietnamese Banking System'],
        ['DP-03', 'Dependency', 'SMS Brandname Gateway maintains high delivery rates for OTP verification messages.', 'Telecommunications Provider']
    ]
    set_table_data(doc.tables[4], bad_data)

    # 7. Table 5: Business Rules
    insert_caption_above_table(doc.tables[5], "Table 1.5: Master Business Rules Inventory", doc)
    br_data = []
    with open('artifacts/requirements/business-rules.csv', 'r', encoding='utf-8') as f:
        reader = csv.reader(f)
        headers = next(reader)
        for row in reader:
            if len(row) >= 8:
                br_id = row[0]
                desc_en = f"{row[1]}: {row[6]}"
                source = row[7]
                br_data.append([br_id, desc_en, source])
    set_table_data(doc.tables[5], br_data)

    # 8. Table 6: User Classes
    insert_caption_above_table(doc.tables[6], "Table 2.1: User Classes and Characteristics", doc)
    uc_data = [
        ['UC-01', 'Guest (Unauthenticated Visitor)', 'Local residents exploring organic food catalogs and reading culinary advice before registration.', 'Browses freely; cannot checkout without OAuth login.', 'Catalog exploration, cart drafting.'],
        ['UC-02', 'Customer (Authenticated Shopper)', 'Health-conscious households within 10 km radius ordering fresh food for home delivery.', 'Requires authenticated phone and delivery address.', 'Checkout, online payment, order cancellation, review, re-order.'],
        ['UC-03', 'Sales Staff (Store Associate)', 'Front-office store employees managing order validation, customer phone calls, invoice printing, and dispatch.', 'High attention to customer contact and delivery accuracy.', 'Order confirmation, printing packing slips, shipper dispatch, delivery status.'],
        ['UC-04', 'Warehouse Staff (Thủ kho)', 'Back-office staff responsible for supplier receiving, batch validation, stock management, and spoilage disposal.', 'Strict adherence to FEFO principles and food safety standards.', 'Goods receipt entry, batch pricing, hold/release batches, disposal logs.'],
        ['UC-05', 'Store Owner (Administrator)', 'Business proprietor with overarching governance authority and administrative control.', 'Full system visibility, staff supervision, and business reporting.', 'Account creation, role assignment, access revocation, revenue and loss analytics.']
    ]
    set_table_data(doc.tables[6], uc_data)

    # 9. Table 7: AS-IS Process Assessment
    insert_caption_above_table(doc.tables[7], "Table 2.2: AS-IS Process Problems and Improvement Opportunities", doc)
    asis_data = [
        ['Goods Receipt & Inventory', 'Receiving recorded in handwritten paper books; expiration dates manually written on carton boxes without FEFO tracking.', 'High risk of selling expired goods; stockouts during peak hours; manual accounting reconciliation.', 'Digital Goods Receipt entry with mandatory Batch/EXP tracking and automated FEFO sales allocation.'],
        ['Customer Ordering', 'Orders received via phone calls and unstructured social chat messages; staff cannot check real-time stock.', 'Slow response times; over-promising out-of-stock items; price quoting inconsistencies.', 'Real-time online catalog with batch inventory reservation and automated radius checking.'],
        ['Order Fulfillment', 'Handwritten paper receipts; no mandatory address verification; unverified customer contact numbers.', 'Failed delivery trips due to wrong addresses; payment disputes on COD orders.', 'Mandatory SMS OTP verification, printed invoices/packing slips, automated distance calculation.'],
        ['Spoilage Management', 'Expired perishables discarded without formal condemnation records or root-cause logs.', 'Inability to track inventory shrinkage or evaluate supplier product shelf-life quality.', 'Automated expiration delisting (BR-EXP-01) and formal disposal logging (UC-M10).']
    ]
    set_table_data(doc.tables[7], asis_data)

    # 10. Table 8: Operating Environment
    insert_caption_above_table(doc.tables[8], "Table 3.1: Operating Environment Specification", doc)
    env_data = [
        ['Client Devices', 'Modern web browsers on Desktop, Tablet, and Mobile (Google Chrome >= 110, Apple Safari >= 16, Mozilla Firefox >= 115).'],
        ['Server Infrastructure', 'Linux / Docker containerized hosting (Ubuntu LTS 22.04), Reverse Proxy via Nginx with TLS 1.3 encryption.'],
        ['Application Framework', 'ASP.NET Core Web API / Node.js backend with React / Next.js responsive frontend.'],
        ['Relational Database', 'PostgreSQL 15+ / Microsoft SQL Server 2022 with ACID transaction isolation and automated daily backups.'],
        ['Hardware Peripherals', 'Standard 80mm POS Thermal Receipt Printer / A4 Laser Printer for invoices and packing slips.']
    ]
    set_table_data(doc.tables[8], env_data)

    # 11. Table 9: Functional Requirements
    insert_caption_above_table(doc.tables[9], "Table 3.2: Functional Requirements Specification", doc)
    fr_data = [
        # Subsystem 1: Product Catalog & Batch Inventory (Warehouse Staff)
        ['FR-CAT-01', 'System shall display paginated product categories with code, name, and active product count.', 'UR-01, P1, UC-M05.1', 'High'],
        ['FR-CAT-02', 'System shall allow Warehouse Staff to create a new category with unique name and description.', 'UR-01, P1, UC-M05.2', 'High'],
        ['FR-CAT-03', 'System shall allow Warehouse Staff to update existing category attributes.', 'UR-01, P1, UC-M05.3', 'High'],
        ['FR-CAT-04', 'System shall allow category deletion strictly when containing zero associated products (BR-CAT-01).', 'UR-01, BR-CAT-01, UC-M05.4', 'High'],
        ['FR-PRD-01', 'System shall display filtered product master list with SKU, name, unit, and total available stock.', 'UR-02, P2, UC-M06.1', 'High'],
        ['FR-PRD-02', 'System shall allow creating product masters with unique SKU, name, category, unit, and photos (BR-CAT-02).', 'UR-02, BR-CAT-02, UC-M06.2', 'High'],
        ['FR-PRD-03', 'System shall allow Warehouse Staff to update product descriptions, units, and showcase photographs.', 'UR-02, P2, UC-M06.3', 'Medium'],
        ['FR-PRD-04', 'System shall allow marking products as inactive or deleting products with zero transaction history.', 'UR-02, P2, UC-M06.4', 'Medium'],
        ['FR-SUP-01', 'System shall list all suppliers with code, name, phone, address, and partnership status.', 'UR-03, P3, UC-M07.1', 'High'],
        ['FR-SUP-02', 'System shall allow creating new verified suppliers with tax ID, contact person, and phone.', 'UR-03, P3, UC-M07.2', 'High'],
        ['FR-SUP-03', 'System shall allow updating supplier contact details and warehouse addresses.', 'UR-03, P3, UC-M07.3', 'Medium'],
        ['FR-SUP-04', 'System shall prevent deleting suppliers with historical receipts, allowing status change to Inactive only (BR-SUP-02).', 'UR-03, BR-SUP-02, UC-M07.4', 'High'],
        ['FR-GR-01', 'System shall display historical Goods Receipt notes with Receipt ID, date, supplier, line count, and total cost.', 'UR-04, P4, UC-M08.1', 'High'],
        ['FR-GR-02', 'System shall record Goods Receipts with Supplier, Item SKU, Batch No, MFG, EXP, Qty, and Unit Import Price (BR-GR-01).', 'UR-04, BR-GR-01, UC-M08.2', 'High'],
        ['FR-GR-03', 'System shall validate EXP > MFG and EXP >= Receipt Date + 3 days for perishable fresh food items (BR-GR-02).', 'UR-04, BR-GR-02, UC-M08.2', 'High'],
        ['FR-GR-04', 'System shall automatically compute line totals and grand receipt invoice costs without manual overrides (BR-GR-03).', 'UR-04, BR-GR-03, UC-M08.2', 'High'],
        ['FR-GR-05', 'System shall lock Goods Receipts against deletion or modification once any batch stock is sold or disposed (BR-GR-04).', 'UR-04, BR-GR-04, UC-M08.3', 'High'],
        ['FR-BAT-01', 'System shall maintain real-time physical inventory quantity and reserved inventory per individual batch.', 'UR-05, P5, UC-M09.1', 'High'],
        ['FR-BAT-02', 'System shall allow Warehouse Staff to configure and update retail selling price independently per batch (BR-BAT-01).', 'UR-05, BR-BAT-01, UC-M09.2', 'High'],
        ['FR-BAT-03', 'System shall allow applying 10%–50% clearance discounts to aging batches nearing expiration (BR-BAT-04).', 'UR-05, BR-BAT-04, UC-M09.3', 'High'],
        ['FR-BAT-04', 'System shall allow setting batch sales status to "Delayed" or "Active" to stage inventory rollout (BR-BAT-03).', 'UR-05, BR-BAT-03, UC-M09.4', 'Medium'],
        ['FR-EXP-01', 'System shall execute an automated daily routine to delist any batch from storefront when Current Date >= EXP (BR-EXP-01).', 'UR-05, BR-EXP-01, UC-M09', 'High'],
        ['FR-EXP-02', 'System shall record formal Expired Stock Disposal logs with condemned quantity, reason, and stock deduction (BR-EXP-02).', 'UR-11, BR-EXP-02, UC-M10', 'High'],

        # Subsystem 2: Customer Storefront & Checkout (Customer & Guest)
        ['FR-BRW-01', 'System shall allow browsing products grouped by New Arrivals, Best Sellers, Promotions, and Categories.', 'UR-06, P6, UC-C01', 'High'],
        ['FR-BRW-02', 'System shall provide real-time keyword search on product names with latency <= 500 ms (NFR-PERF-03).', 'UR-06, P6, UC-C02', 'High'],
        ['FR-BRW-03', 'System shall display product details with high-resolution images, origin, active batch retail price, and discount badge.', 'UR-06, P6, UC-C01.3', 'High'],
        ['FR-CRT-01', 'System shall allow users to add items to a persistent cart, adjust quantities, and clear selected items.', 'UR-06, P6, UC-C03', 'High'],
        ['FR-CRT-02', 'System shall validate cart item quantities against available batch inventory, preventing over-selection (NFR-INT-01).', 'UR-06, NFR-INT-01, UC-C03.2', 'High'],
        ['FR-ATH-01', 'System shall authenticate customers via Google OAuth 2.0 and Facebook Single Sign-On (BR-AUTH-01).', 'UR-07, BR-AUTH-01, UC-C04', 'High'],
        ['FR-ATH-02', 'On first-time social login, system shall require Full Name, Phone, Email, and Initial Delivery Address (BR-AUTH-02).', 'UR-07, BR-AUTH-02, UC-C04.3', 'High'],
        ['FR-ATH-03', 'System shall dispatch 6-digit SMS OTP to customer phone and verify input within a 3-minute validity window.', 'UR-07, BR-AUTH-02, UC-C04.4', 'High'],
        ['FR-PRF-01', 'System shall allow authenticated customers to manage profile information and saved delivery address book.', 'UR-07, P7, UC-C05', 'Medium'],
        ['FR-PRF-02', 'System shall automatically default checkout delivery address to the one used in the most recent completed order (BR-AUTH-03).', 'UR-07, BR-AUTH-03, UC-C05.3', 'Medium'],
        ['FR-ORD-01', 'At checkout, system shall measure driving distance d from store; reject order if d > 10.0 km (BR-DEL-01).', 'UR-13, BR-DEL-01, UC-C06', 'High'],
        ['FR-ORD-02', 'System shall automatically compute 3-tier delivery fee based on distance: 10k (<1km), 20k (1-3km), 30k (3-10km) (BR-DEL-02).', 'UR-13, BR-DEL-02, UC-C06', 'High'],
        ['FR-ORD-03', 'Upon order placement, system shall allocate batches via FEFO (BR-BAT-02) and place atomic inventory locks (BR-ORD-01).', 'UR-06, BR-ORD-01, UC-C06', 'High'],
        ['FR-PAY-01', 'System shall support Cash on Delivery (COD) payment, creating order in Pending status.', 'UR-06, UC-C06.3', 'High'],
        ['FR-PAY-02', 'System shall generate dynamic VietQR code and match payment via SePay webhook, advancing order to Paid (BR-ORD-03).', 'UR-06, BR-ORD-03, UC-C06.4', 'High'],
        ['FR-MYO-01', 'System shall display order tracking history with lifecycle statuses: Pending, Processing, In Delivery, Delivered, Cancelled.', 'UR-08, P8, UC-C07.1', 'High'],
        ['FR-MYO-02', 'System shall permit order cancellation while in Pending or Processing, releasing stock back to original batches (BR-ORD-04, 05).', 'UR-08, BR-ORD-04, UC-C07.3', 'High'],
        ['FR-MYO-03', 'System shall restrict product ratings (1–5 stars) and reviews strictly to orders in Delivered status (BR-FB-01).', 'UR-08, BR-FB-01, UC-C07.4', 'Medium'],
        ['FR-MYO-04', 'System shall provide one-click Re-Order cloning previous items and mapping them to currently active batches and prices (BR-RE-01).', 'UR-08, BR-RE-01, UC-C07.5', 'Medium'],

        # Subsystem 3: Order Fulfillment & Store Operations (Sales Staff)
        ['FR-FUL-01', 'System shall display incoming order queue for Sales Staff, highlighting first-time customer orders.', 'UR-09, P9, UC-M01.1', 'High'],
        ['FR-FUL-02', 'System shall mandate Sales Staff phone verification confirmation before approving first-time customer orders (BR-FUL-01).', 'UR-09, BR-FUL-01, UC-M01.3', 'High'],
        ['FR-PRN-01', 'System shall provide one-click printing generating formatted Invoices and Packing Slips for packaging (BR-FUL-02).', 'UR-09, BR-FUL-02, UC-M02', 'High'],
        ['FR-DEL-01', 'System shall allow Sales Staff to assign orders to delivery shippers and transition order status to In Delivery.', 'UR-09, P9, UC-M03.1', 'High'],
        ['FR-DEL-02', 'System shall confirm delivery success (Delivered), permanently deducting reserved stock and finalizing revenue (BR-FUL-03).', 'UR-09, BR-FUL-03, UC-M03.2', 'High'],
        ['FR-DEL-03', 'System shall record delivery failure reasons (Delivery Failed) and trigger warehouse restocking inspection (BR-FUL-04).', 'UR-09, BR-FUL-04, UC-M03.3', 'High'],
        ['FR-ART-01', 'System shall allow Sales Staff to author and publish rich-text culinary news, food safety guides, and organic recipes.', 'UR-10, P10, UC-M04.1', 'Medium'],
        ['FR-ART-02', 'System shall allow editing, deleting, hiding outdated articles, and unhiding archived articles.', 'UR-10, P10, UC-M04.2', 'Medium'],
        ['FR-ART-03', 'System shall render published articles on the storefront for guest and customer viewing.', 'UR-10, P6, UC-M04', 'Medium'],

        # Subsystem 4: Store Administration & Business Reporting (Store Owner)
        ['FR-REP-01', 'System shall generate Revenue Reports aggregated daily, weekly, monthly, or by custom date range by category (BR-REP-01).', 'UR-11, BR-REP-01, UC-M11.1', 'High'],
        ['FR-REP-02', 'System shall generate Real-Time Stock Reports showing quantity on hand, reserved stock, and days until expiration per batch.', 'UR-11, P11, UC-M11.2', 'High'],
        ['FR-REP-03', 'System shall generate Expired Stock Disposal Reports detailing destroyed quantities and financial loss values.', 'UR-11, P11, UC-M11.3', 'High'],
        ['FR-REP-04', 'System shall trigger visual low-stock alerts when batch inventory drops below defined minimum thresholds.', 'UR-11, UC-M11.4', 'Medium'],
        ['FR-REP-05', 'System shall support exporting report tables to Microsoft Excel (.xlsx) and PDF formats.', 'UR-11, UC-M11.5', 'Medium'],
        ['FR-ADM-01', 'System shall allow Store Owner to manage employee accounts and assign RBAC roles (Sales Staff, Warehouse Staff).', 'UR-12, P12, UC-M12', 'High'],
        ['FR-ADM-02', 'System shall allow Store Owner to revoke employee access, terminating all active sessions within <= 1.0 s (BR-SEC-03).', 'UR-12, BR-SEC-03, UC-M13.3', 'High'],
        ['FR-ADM-03', 'System shall enforce role-based access control granting Store Owner unrestricted access to all system functions (BR-SEC-02).', 'UR-12, BR-SEC-02, Role RBAC', 'High'],
        ['FR-ADM-04', 'System shall automatically and immutably record an audit log entry for every database mutation (creation, modification, deletion) executed by staff users (BR-SEC-04).', 'UR-12, BR-SEC-04, UC-M12', 'High']
    ]

    # Map Karl Wiegers quantitative priorities
    prio_map = {}
    prio_csv = 'artifacts/requirements/requirements-prioritization.csv'
    if os.path.exists(prio_csv):
        with open(prio_csv, 'r', encoding='utf-8') as f:
            for row in csv.DictReader(f):
                fr_id = row.get('ID', '').strip()
                score = float(row.get('Priority', 0))
                tier = row.get('Tier', '')
                if 'Sprint 1' in tier:
                    prio_map[fr_id] = f"High (Sprint 1, Score: {score:.2f})"
                elif 'Sprint 2' in tier:
                    prio_map[fr_id] = f"Medium (Sprint 2, Score: {score:.2f})"
                else:
                    prio_map[fr_id] = f"Low (Sprint 3, Score: {score:.2f})"

    for row in fr_data:
        fr_id = row[0]
        if fr_id in prio_map:
            row[3] = prio_map[fr_id]

    set_table_data(doc.tables[9], fr_data)

    # 12. Table 10: Constraints
    insert_caption_above_table(doc.tables[10], "Table 3.12: System Constraints Specification", doc)
    con_data = [
        ['CON-01', 'Geographical Delivery Restriction: Maximum delivery distance is strictly capped at 10.0 km from the central store.', 'Business Strategy & Fresh Food Perishability'],
        ['CON-02', 'Single Store / Warehouse Scope: Multi-store inventory transfers and complex distributed routing are excluded in Version 1.0.', 'Project Charter Scope'],
        ['CON-03', 'Payment Methods: Domestic payments restricted to Cash on Delivery (COD) and VietQR bank transfers (Visa/Mastercard excluded).', 'Business Decision'],
        ['CON-04', 'Monetary Currency: All calculations and display values must use Vietnamese Dong (VND) with zero decimal places.', 'Legal & Accounting Convention'],
        ['CON-05', 'Regulatory Food Safety Compliance: Expired perishables cannot be sold under any circumstances and must be logged for disposal.', 'Vietnamese Food Safety Regulations']
    ]
    set_table_data(doc.tables[10], con_data)

    # Table 13: Actor Identification Catalog
    insert_caption_above_table(doc.tables[13], "Table 3.14: Actor Identification Catalog", doc)
    actor_data = [
        ['Guest', 'Secondary', 'Unauthenticated user browsing store catalog, searching items, and reading culinary articles.'],
        ['Customer', 'Primary', 'Authenticated shopper placing orders, paying via VietQR/COD, tracking delivery, and submitting reviews.'],
        ['Sales Staff', 'Primary', 'Front-office employee verifying first-time customer orders by phone, printing packing slips, and dispatching orders.'],
        ['Warehouse Staff', 'Primary', 'Back-office worker receiving goods, validating batch EXP, managing FEFO pricing, holding batches, and logging disposals.'],
        ['Store Owner', 'Primary', 'Business administrator managing staff accounts, monitoring live revenues, inventory shrinkage, and business performance.']
    ]
    set_table_data(doc.tables[13], actor_data)

    # 13. Replace guidance paragraphs with rich narrative text
    guidance_map = {
        '[Guidance: Describe the organization, current business situation, existing way of working, and the context that motivates the project.]':
            'FreshFood is an established local retail store specializing in certified organic vegetables, fruits, and fresh meat/poultry. FreshFood serves customers located in the immediate vicinity of the store (within a 10 km operational radius).\n\nCurrently, the store conducts operations through walk-in retail and informal phone/messaging channels. Inventory management, batch expiration tracking, and bookkeeping are handled via manual paper ledgers and disconnected spreadsheets. As demand for organic products grows, this manual approach leads to stockouts, inventory shrinkage from expired products, slow order turnaround times, and lack of customer retention. The FreshFood E-Commerce Platform is commissioned to automate store operations and establish an online storefront.',

        '[Guidance: Describe the business problem/opportunity and the value expected from introducing or improving the system.]':
            'FreshFood aims to capture the growing local demand for clean and organic food by providing a fast, reliable, and convenient online ordering experience. By introducing a localized e-commerce web platform, FreshFood will:\n1. Enable local households to browse verified organic catalogs, view fresh arrivals, and order for delivery.\n2. Automate warehouse batch inventory control, implementing strict First-Expired, First-Out (FEFO) retail pricing and timely clearance discounts.\n3. Streamline sales operations through standardized order verification, automated invoice/packing slip printing, and real-time delivery status updates.\n4. Establish brand authority and customer trust through culinary articles and verified product reviews.',

        '[Guidance: Summarize target users, product/system, major capabilities, business value, and differentiation from the current approach.]':
            'For local health-conscious consumers and families seeking trustworthy organic and clean food,\nWho want a fast, transparent, and hassle-free grocery shopping experience,\nThe FreshFood E-Commerce Platform is a web-based retail and inventory fulfillment system\nThat provides real-time fresh product availability, batch-level freshness visibility, seamless social login, VietQR instant payments, and localized doorstep delivery.\nUnlike generic large-scale marketplaces with uncertain food provenance and multi-day delivery windows,\nOur Product guarantees strict batch-tracked food safety, expiration-aware dynamic pricing, immediate local delivery within 10 km, and dedicated personal phone verification for new customers.',

        '[Guidance: Explicitly identify what is out of scope or intentionally excluded.]':
            '1. Deliveries beyond 10 km driving distance from the store are strictly out of scope (enforced by BR-DEL-01).\n2. Multi-warehouse inventory transfers and cross-docking operations are excluded in Version 1.0 (single store/warehouse assumption AS-01).\n3. International credit card payment processing (Visa/Mastercard) is excluded; payments are strictly Cash on Delivery (COD) and VietQR banking transfers.\n4. Foreign language localization is excluded; the storefront is specialized for local Vietnamese consumers.',

        '[Guidance: Describe current business processes discovered from stakeholders and document manual steps, pain points, bottlenecks, or compliance issues.]':
            'Currently, the store operates through manual, fragmented workflows across receiving, order taking, and waste management:\n1. Goods Receipt: Suppliers deliver goods with physical paper invoices. Warehouse staff record items in paper ledgers, write expiration dates on carton boxes, and stack produce without systematic FIFO/FEFO controls.\n2. Customer Ordering: Orders are taken via telephone calls or unstructured social chat messages. Staff quote prices manually and cannot guarantee real-time stock availability.\n3. Order Fulfillment: Sales staff write paper receipts by hand. First-time customer addresses and phones are frequently unverified, leading to failed delivery trips.\n4. Waste Management: Expired perishables are culled and discarded without formal accounting logs, preventing management from measuring shrinkage or identifying loss trends.',

        '[Guidance: Insert or reference BPMN diagrams. Prefer editable .drawio source files located in artifacts/diagrams/business-process/.]':
            'AS-IS business processes are summarized above and contrasted against TO-BE digitalized workflows in Table 2.2.',

        '[Guidance: Describe proposed processes after digitalization/automation.]':
            'The digitalized TO-BE processes automate end-to-end retail and inventory operations across 5 core workflows:\n- BP-01: Goods Receipt & Batch Inventory Management (digital entry, mandatory batch/MFG/EXP validation, FEFO rotation, dynamic clearance pricing).\n- BP-02: Online Customer Ordering & Payment (real-time catalog browsing, 10 km radius check, tiered shipping fees, VietQR webhook matching).\n- BP-03: Order Fulfillment & Delivery Dispatch (incoming order queue, first-order phone check, automated invoice/packing slip printing, status updates).\n- BP-04: Post-Purchase Review & Order Cancellation (atomic cancellation restocking, verified purchase ratings and feedback, one-click re-order).\n- BP-05: Expired Stock Inspection & Disposal (automated daily delisting, formal condemnation records).',

        '[Guidance: Insert or reference verified TO-BE BPMN diagrams.]':
            'Verified TO-BE Activity Diagrams modeling actor interactions and decision gateways are embedded below.',

        '[Guidance: Insert or reference the system context diagram.]':
            'The System Context Diagram (Data Flow Diagram Level 0) defines the formal boundary of the FreshFood E-Commerce Platform.',

        '[Guidance: Insert or reference the general UML Use Case Diagram.]':
            'The General Use Case Diagram establishes the functional scope across all 5 subsystems with strict single system boundary notation.',

        '[Guidance: Insert or reference decomposed use case diagrams using include, extend, and generalization where appropriate.]':
            'Decomposed Use Case Diagrams illustrate actor-specific capabilities, including include, extend, and generalization relationships.',

        '[Guidance: For each use case, provide the lecturer-approved structured Use Case Description template.]':
            'Detailed Use Case Descriptions follow the canonical 12-row table schema from the approved reference example.',

        '[Guidance: For complex use cases, model actor-system interaction flow with UML Activity Diagrams using swimlanes.]':
            'Complex actor-system interactions are modeled with swimlane Activity Diagrams below.',

        '[Guidance: Insert or reference prototypes for complex, ambiguous, or interaction-heavy user requirements.]':
            'UI wireframes clarify the Storefront Product Catalog, Mobile Cart Drawer, Localized 10 km Checkout Screen, Order Tracking View, and Back-Office Goods Receipt Batch Entry.',

        '[Guidance: Derive software functional requirements from approved business processes and user requirements. Use FR-xx identifiers.]':
            'Software functional requirements specify the complete set of capabilities that the FreshFood E-Commerce Platform must provide, systematically derived from confirmed User Requirements (UR-01 through UR-13), TO-BE business processes, and governing Business Rules.\n\n'
            'All candidate functional requirements have been quantitatively prioritized using the Karl Wiegers Quantitative Requirements Prioritization Model (Software Requirements, 3rd Edition):\n\n'
            '   Total Value = 2 * Relative Benefit + Relative Penalty\n'
            '   Priority Score = Value % / (Cost % + Risk %)\n\n'
            'Where Relative Benefit (1-9, weight 2), Relative Penalty (1-9, weight 1), Relative Cost (1-9), and Relative Risk (1-9) were evaluated with domain stakeholders and engineering leads. Based on normalized percentages, all 54 functional requirements are objectively triaged into three controlled delivery tiers (mean score = 0.500):\n'
            '- High Priority (Score >= 0.60 — Sprint 1 Candidates): 19 core functional requirements delivering the highest value-to-cost/risk ratio, selected for immediate implementation in Sprint 1.\n'
            '- Medium Priority (0.45 <= Score < 0.60 — Sprint 2 Candidates): 26 operational, administrative, and reporting requirements scheduled for Sprint 2.\n'
            '- Low Priority (Score < 0.45 — Sprint 3 & Future Backlog): 14 complex integration features (VietQR webhook, Google Maps driving distance, SMS OTP gateway, FEFO inventory atomic locks) and secondary modules (culinary articles, customer reviews).\n\n'
            'Table 3.2 details the complete catalog of Functional Requirements across all four core subsystems, including their exact Karl Wiegers priority scores and sprint triage allocations.'
    }

    for p in doc.paragraphs:
        p_text = p.text.strip()
        for placeholder, replacement in guidance_map.items():
            if placeholder in p_text:
                p.text = replacement
                break

    # Locate insertion headings
    headings_map = {}
    for p in doc.paragraphs:
        txt = p.text.strip()
        if txt in [
            "TO-BE BPMN Models",
            "System Context Diagram",
            "General Use Case Diagram",
            "Decomposed Use Case Diagrams",
            "Use Case Descriptions",
            "III.7.5 Activity Diagrams for Complex Use Cases",
            "Data Requirements",
            "Database Design",
            "Quality Attribute Requirements",
            "Usability Requirements",
            "Performance Requirements",
            "Security Requirements",
            "Reliability and Availability Requirements",
            "Maintainability Requirements",
            "Scalability Requirements"
        ]:
            headings_map[txt] = p._element

    print("Found anchor headings:", list(headings_map.keys()))

    # 14. Embed TO-BE BPMN Activity Diagrams in Chapter II
    if "TO-BE BPMN Models" in headings_map:
        print("Embedding TO-BE Activity Diagrams into Chapter II...")
        curr = headings_map["TO-BE BPMN Models"]
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/bp01-goods-receipt-activity.png', Inches(6.3),
                                   'Figure 2.1: Goods Receipt & Batch Inventory Activity Diagram (BP-01)')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/bp02-online-ordering-activity.png', Inches(6.3),
                                   'Figure 2.2: Online Customer Ordering & Payment Activity Diagram (BP-02)')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/bp03-order-fulfillment-activity.png', Inches(6.3),
                                   'Figure 2.3: Order Fulfillment & Delivery Dispatch Activity Diagram (BP-03)')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/bp04-post-purchase-activity.png', Inches(6.3),
                                   'Figure 2.4: Post-Purchase Review, Re-Order & Cancellation Activity Diagram (BP-04)')

    # 15. Embed System Context Diagram in Chapter III
    if "System Context Diagram" in headings_map:
        print("Embedding System Context Diagram into Chapter III...")
        curr = headings_map["System Context Diagram"]
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/system-context-diagram.png', Inches(6.3),
                                   'Figure 3.1: FreshFood System Context Diagram (Level 0 DFD)')

    # 16. POPULATE COMPREHENSIVE NON-FUNCTIONAL REQUIREMENTS (NFR) SECTIONS & TABLES
    print("Populating Comprehensive Non-Functional Requirements & Quality Attributes...")
    nfr_widths_5col = [Inches(1.1), Inches(1.2), Inches(1.8), Inches(1.1), Inches(1.3)]
    nfr_headers_5col = ["NFR ID", "Quality Attribute & Scope", "Measurable Metric / Threshold", "Verification Method", "Technical Architecture Rationale"]

    # 16.1 Section Overview & Workload Baseline
    if "Quality Attribute Requirements" in headings_map:
        curr = headings_map["Quality Attribute Requirements"]
        overview_text = (
            "This section specifies the Non-Functional Requirements (NFRs / Quality Attributes) governing the FreshFood "
            "E-Commerce Platform, formulated in strict accordance with the ISO/IEC 25010 Software Quality Standard and Karl Wiegers "
            "Requirements Engineering principles. These quantified quality criteria serve as foundational architectural drivers, directly "
            "influencing technology stack selection, database indexing, caching topologies, API contracts, security controls, and infrastructure dimensioning.\n\n"
            "Operational Workload Baseline Parameters:\n"
            "• Total Registered User Base: 500 accounts (combining active local household consumers and internal store staff).\n"
            "• Peak Concurrent Users (CCU): 100 CCU actively browsing catalogs, performing batch searches, or executing checkouts during daily peak trading hours (09:00–11:30 and 16:00–18:30).\n"
            "• Geographical Delivery Service Radius: Strictly bounded within a 10.0-kilometer driving distance from the FreshFood store location (governed by BR-DEL-01)."
        )
        curr = insert_paragraph_after(curr, overview_text, align=WD_ALIGN_PARAGRAPH.JUSTIFY)

    # 16.2 Usability Requirements
    if "Usability Requirements" in headings_map:
        curr = headings_map["Usability Requirements"]
        curr = insert_paragraph_after(
            curr,
            "The FreshFood storefront emphasizes a mobile-first, friction-free shopping journey tailored for local households and elderly shoppers. "
            "All core interactions prioritize responsive layouts, large touch targets, streamlined checkout procedures, and clear, localized feedback.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.3: Usability & Mobile-First Experience Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        usa_data = [
            ['NFR-USA-01', 'Mobile Responsiveness & Visual Scaling', '100% of storefront pages render cleanly without horizontal scrolling across viewport widths from 360px (compact mobile) to 1920px (desktop). Touch targets >= 44x44 px; body font >= 14px.', 'Responsive testing on iOS Safari, Android Chrome, and Chrome DevTools.', 'Mobile-first responsive CSS Grid/Flexbox layouts; accessible typography hierarchy.'],
            ['NFR-USA-02', 'Checkout Interaction Simplicity', 'Authenticated repeat customers with a saved delivery address complete checkout within <= 3 touch/click interactions (Click "Checkout" -> Select Payment Method -> Confirm Order).', 'User journey evaluation and interaction testing.', 'Automated pre-selection of default/recent delivery address (BR-AUTH-03) and cached checkout state.'],
            ['NFR-USA-03', 'Graceful Localized Error Feedback', 'When a customer enters an address beyond the 10 km delivery radius (BR-DEL-01), system displays friendly, clear localized feedback within <= 500 ms with suggested solutions.', 'GUI validation and boundary input testing.', 'Contextual inline validation messages without raw technical HTTP error codes or SQL exceptions.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, usa_data, nfr_widths_5col)

    # 16.3 Performance Requirements (Capacity & Concurrency + Data Integrity)
    if "Performance Requirements" in headings_map:
        curr = headings_map["Performance Requirements"]
        curr = insert_paragraph_after(
            curr,
            "Performance efficiency requirements establish rigorous latency and throughput bounds under peak operating conditions. "
            "High concurrency throughput and sub-second transactional response times are enforced to deliver a responsive retail experience while strictly maintaining inventory consistency.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.4: Performance Efficiency & Capacity Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        perf_data = [
            ['NFR-PERF-01', 'Concurrency Capacity & Throughput', 'Smoothly support 100 peak concurrent users (100 CCU) with error rate < 0.1% under full load. Total registered user base: 500 users.', 'Load testing simulating concurrent browsing and order placement using k6 / JMeter.', 'Database connection pooling optimization, catalog response caching, lightweight stateless API design.'],
            ['NFR-PERF-02', 'Web Page Load Performance', 'First Contentful Paint (FCP) <= 1.5 seconds; Largest Contentful Paint (LCP) <= 2.0 seconds over standard 4G mobile networks under 100 CCU load.', 'Google Lighthouse Audit & PageSpeed Insights profiling.', 'WebP image compression, lazy-loading of product imagery, minified JS/CSS bundle optimization.'],
            ['NFR-PERF-03', 'Search & Catalog Filter Latency', '95th percentile response time (p95) <= 500 ms for product search by name and category filtering queries.', 'APM monitoring (Prometheus / Application Insights) and benchmark testing.', 'Composite B-tree indexes on ProductName, CategoryID, and BatchExpiryDate.'],
            ['NFR-PERF-04', 'End-to-End Checkout Latency', 'Processing from clicking "Place Order" to receiving Order Confirmation ID <= 1.0 second (including database write and batch stock reservation).', 'API latency tracing and transaction profiling.', 'Atomic transaction scope, avoiding table-level locking, dedicated batch holding table.'],
            ['NFR-PERF-05', 'Automated VietQR Payment Matching', 'Time from customer scanning transfer QR code to storefront screen updating to "Paid" state: <= 3.0 seconds.', 'Real-time webhook round-trip latency testing.', 'SePay payment gateway webhook integration with client-side polling (1.5s interval) or WebSocket notification.'],
            ['NFR-PERF-06', 'Distance Measurement & Shipping Fee Latency', 'External Map API call and tiered shipping fee calculation (BR-DEL-02) <= 800 ms.', 'Client-side API tracing and network timing analysis.', 'Geocoding coordinate caching for repeat customer delivery addresses.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, perf_data, nfr_widths_5col)

        curr = insert_paragraph_after(
            curr,
            "Data integrity and concurrency control requirements safeguard financial accuracy and eliminate inventory discrepancies such as overselling during peak traffic windows.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.5: Data Integrity & Concurrency Control Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        int_data = [
            ['NFR-INT-01', 'Zero Over-Selling Guarantee', 'Over-selling rate: strictly 0.0%. When multiple shoppers attempt to purchase the final remaining units of a batch concurrently, serialized consistency must be guaranteed.', 'Concurrency stress testing (100 concurrent threads attempting to buy a single remaining inventory unit).', 'Database transactions with row-level pessimistic locking (SELECT ... FOR UPDATE) or optimistic concurrency control with version stamps.'],
            ['NFR-INT-02', 'Cancellation Restock Accuracy', '100% of cancelled orders (UC-C07.3) and delivery failures (UC-M03.3) must restock the exact item quantity back to the original Batch ID within <= 1.0 second.', 'Automated integration testing for order cancellation and failed dispatch workflows.', 'Enforced foreign key linkage between OrderDetail and BatchInventory.'],
            ['NFR-INT-03', 'Financial Calculation Precision', 'All subtotal, discount, shipping fee, and grand total calculations must be exact in VND with 0 VND calculation or rounding error. Floating-point types strictly prohibited.', 'Static code analysis and unit test suites with boundary currency values.', 'Mandatory use of 64-bit integer or high-precision Decimal data types in database schemas and application code.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, int_data, nfr_widths_5col)

    # 16.4 Security Requirements
    if "Security Requirements" in headings_map:
        curr = headings_map["Security Requirements"]
        curr = insert_paragraph_after(
            curr,
            "The platform enforces strict authentication, authorization, communication encryption, and abuse prevention mechanisms to protect user credentials, sensitive transaction records, and store communications.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.6: Security & Access Control Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        sec_data = [
            ['NFR-SEC-01', 'Transport Encryption & Password Hashing', '100% of web traffic transmitted over HTTPS (TLS 1.2 / TLS 1.3). Staff account passwords hashed using BCrypt (work factor >= 11) or Argon2. Plaintext storage strictly prohibited.', 'Security audit and SSL Labs SSL/TLS compliance testing.', 'Let\'s Encrypt / Cloudflare SSL termination and cryptographic password hashing library.'],
            ['NFR-SEC-02', 'Role-Based Access Control (RBAC)', '100% unauthorized cross-role access attempts between Sales Staff, Warehouse Staff, and Customers blocked with HTTP 403 Forbidden without data leakage.', 'Penetration testing and automated RBAC authorization test cases.', 'Declarative role-claim authorization middleware guarding all administrative API endpoints.'],
            ['NFR-SEC-03', 'Session & Token Revocation', 'Access token lifespan capped at 60 minutes. Upon access revocation by Store Owner (BR-SEC-03), account is deactivated and active sessions terminated within <= 1.0 second.', 'Integration testing of staff deactivation workflow.', 'In-memory token blacklist (Redis/DB cache) or real-time IsActive claim checks on incoming requests.'],
            ['NFR-SEC-04', 'SMS OTP Rate Limiting & Abuse Prevention', 'Maximum 3 OTP requests per phone number within a 15-minute rolling window. OTP validity duration: 3 minutes. Account locked for 30 minutes after 5 consecutive incorrect attempts.', 'API abuse security testing.', 'Rate-limiting middleware and OTP attempt tracking to prevent financial exhaustion of SMS Brandname balance.'],
            ['NFR-SEC-05', 'Staff Database Mutation Audit Trail', 'The system shall automatically record an immutable audit log entry for every database mutation (INSERT, UPDATE, DELETE) executed by staff users, capturing staff ID, action type, entity name, record ID, old/new values, IP address, and timestamp (BR-SEC-04). Audit logs are append-only and preserved >= 12 months.', 'Security audit and automated mutation verification testing.', 'Database audit trigger / EF Core interceptor writing to dedicated AuditLog table.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, sec_data, nfr_widths_5col)

    # 16.5 Reliability and Availability Requirements (+ Resilience)
    if "Reliability and Availability Requirements" in headings_map:
        curr = headings_map["Reliability and Availability Requirements"]
        curr = insert_paragraph_after(
            curr,
            "Availability and operational reliability standards ensure consistent storefront accessibility during store operating hours, accompanied by automated backup routines to prevent data loss.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.7: Availability & Operational Reliability Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        rel_data = [
            ['NFR-REL-01', 'System Availability & Uptime', 'Minimum 99.5% uptime during core business operating hours (06:00 to 22:00 daily). Unplanned downtime capped at <= 2.4 hours per month.', 'Synthetic uptime monitoring (UptimeRobot / Prometheus blackbox exporter).', 'Scheduled maintenance and deployment windows restricted to low-traffic hours (00:00 to 04:00).'],
            ['NFR-REL-02', 'Automated Daily Database Backup', 'Full automated database backup executed daily at 01:00 AM; encrypted archives retained for at least 30 days. Recovery Point Objective (RPO) <= 24 hours; Recovery Time Objective (RTO) <= 2 hours.', 'Automated cron job audit and periodic backup restoration drill.', 'Automated pg_dump / SQL Server maintenance plans with offsite cloud storage replication.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, rel_data, nfr_widths_5col)

        curr = insert_paragraph_after(
            curr,
            "Resilience engineering protects the platform against external third-party integration interruptions (e.g., mapping APIs, automated banking webhooks, and SMS gateways) through timeouts and graceful degradation fallbacks.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.8: Third-Party Service Resilience Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        res_data = [
            ['NFR-RES-01', 'External API Timeout Protection', 'Maximum timeout threshold for external integrations (Google Maps, SePay, SMS Gateway) capped at <= 3.0 seconds. Requests abort gracefully to avoid hanging threads.', 'Mock network latency and timeout injection testing.', 'Timeout and Circuit Breaker patterns implemented via Polly / Axios interceptors.'],
            ['NFR-RES-02', 'Maps Service Fallback Mechanism', 'If Google Maps API is unreachable or quota is exceeded, system falls back to manual Ward/District dropdown selection with default flat delivery fee (20,000 VND), ensuring order continuity.', 'Chaos testing / external API service failure simulation.', 'Resilient fallback workflow preventing checkout abandonment during third-party outages.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, res_data, nfr_widths_5col)

    # 16.6 Maintainability Requirements (+ Reusability)
    if "Maintainability Requirements" in headings_map:
        curr = headings_map["Maintainability Requirements"]
        curr = insert_paragraph_after(
            curr,
            "Maintainability criteria ensure long-term system evolution, clean modular separation, zero-downtime configuration modifications, high automated testing coverage, and rapid incident triage through structured observability.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.9: Software Maintainability Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        mnt_data = [
            ['NFR-MNT-01', 'Layered & Modular Architecture', 'Codebase strictly enforces Clean Layered Architecture: Controller (Presentation) -> Service (Domain/Application Logic) -> Repository (Data Access). Loose coupling enforced via Interfaces and Dependency Injection (DI).', 'Code architecture review and SonarQube static architecture analysis.', 'Minimizes ripple effects when modifying core business rules or swapping database layers.'],
            ['NFR-MNT-02', 'Runtime Configurability without Recompile', '100% of core operational parameters (MaxDeliveryDistance = 10 km, shipping fee tiers, API timeouts, OTP expiry) configurable via appsettings.json, .env, or System_Config table. Changes take effect within <= 5 seconds without recompilation.', 'Configuration inspection test and hot-reload verification.', 'ASP.NET Core IOptionsSnapshot / dynamic environment configuration loader.'],
            ['NFR-MNT-03', 'Automated Testability & Code Coverage', 'Automated unit test coverage reaches >= 75% for critical business services (ShippingFeeCalculator, FEFO batch allocator, stock holding, order cancellation). Full test suite executes within <= 2 minutes in CI/CD.', 'Code coverage reports (dotCover / Coverlet / Jest) in automated CI pipeline.', 'Fast feedback loop preventing regression defects during iterative maintenance.'],
            ['NFR-MNT-04', 'Structured Logging & Observability', '100% of application exceptions and security events logged in structured JSON format (Serilog) with CorrelationId, User ID, and UTC timestamp. Mean Time to Identify (MTTI) <= 15 minutes.', 'Log auditing and incident simulation exercises.', 'Centralized rolling file logging with structured metadata for rapid diagnostic querying.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, mnt_data, nfr_widths_5col)

        curr = insert_paragraph_after(
            curr,
            "Software reusability principles govern the creation of decoupled domain service libraries, unified frontend UI components, pluggable third-party adapters, and shared utilities.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.10: Software Reusability Requirements Specification", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        reu_data = [
            ['NFR-REU-01', 'Reusable Domain Service Engines', 'Core calculation engines (DistanceCalculator, ShippingFeeCalculator, BatchStockValidator) encapsulated as independent shared domain services reusable across Web API, Admin portal, and background workers without duplicate logic.', 'Architecture compliance review and code reuse audit.', 'Encapsulation within FreshFood.Domain / FreshFood.Core class libraries.'],
            ['NFR-REU-02', 'Reusable UI Component Library', 'Standardized UI components (ProductCard, QuantitySelector, AddressPickerModal, OrderStatusBadge) packaged into a shared component library. Minimum UI component reuse rate across storefront screens: >= 80%.', 'Frontend code audit and component library showcase.', 'Design system tokens and reusable component architecture reducing frontend development overhead.'],
            ['NFR-REU-03', 'Pluggable Payment & Notification Adapters', 'Adapter & Strategy patterns applied to peripheral integrations: IPaymentGateway implemented by SePayAdapter and CodPaymentAdapter; ISmsService implemented by SpeedSmsAdapter. Extensible to MoMo/VNPay without modifying order processing core.', 'Architecture conformance testing with mock gateway implementations.', 'Decoupled adapter architecture enabling new gateway additions in less than 1 business day.'],
            ['NFR-REU-04', 'Shared Common Utilities Library', 'Common utility functions (VND currency formatting VndCurrencyFormatter, Vietnam phone normalization PhoneNumberHelper, password hashing, GMT+7 date-time helpers) consolidated into Shared.Common. Code duplication < 3%.', 'Static analysis code duplication scanning.', 'DRY (Don\'t Repeat Yourself) principle ensuring uniform numerical and date formatting.']
        ]
        curr = insert_styled_table_after(curr, doc, nfr_headers_5col, reu_data, nfr_widths_5col)

    # 16.7 Scalability Requirements
    if "Scalability Requirements" in headings_map:
        curr = headings_map["Scalability Requirements"]
        curr = insert_paragraph_after(
            curr,
            "Scalability requirements evaluate hardware and network dimensioning for the baseline workload of 100 peak concurrent users and 500 registered customers, demonstrating that the architecture can comfortably sustain peak traffic with standard commercial resources.",
            align=WD_ALIGN_PARAGRAPH.JUSTIFY
        )
        curr = insert_paragraph_after(curr, "Table 3.11: Workload Sizing & Infrastructure Capacity Assessment Matrix (100 CCU / 500 Users)", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        scale_headers = ["System Component", "Resource Dimensioning (100 CCU / 500 Users)", "Technical Solution & Infrastructure Strategy"]
        scale_widths = [Inches(1.8), Inches(2.2), Inches(2.5)]
        scale_data = [
            ['Web Application Server (Backend API)', '~0.5 – 1.0 vCPU, 1 GB – 2 GB RAM', 'Efficient asynchronous I/O (.NET / Node.js) effortlessly handling 100 concurrent HTTP connections with minimal memory footprint.'],
            ['Database Server (PostgreSQL / SQL Server)', 'Connection Pool: 50 – 100 active connections', 'Tuned connection pooling, B-tree composite indexing, and query plan optimization ensuring low latency under concurrent load.'],
            ['Media & Product Image Storage', '~500 SKUs × 3 images × 300 KB = ~450 MB', 'Cloudflare R2 / AWS S3 object storage with CDN edge caching or server local persistent volume.'],
            ['Network Bandwidth Capacity', 'Peak Load: 100 CCU × 50 KB/page = ~5 MB/s (~40 Mbps)', 'Standard cloud VPS networking (100–250 Mbps port speed) provides ample headroom for peak traffic bursts.']
        ]
        curr = insert_styled_table_after(curr, doc, scale_headers, scale_data, scale_widths)

    # Clean up any leftover guidance paragraph under quality attributes
    for p in doc.paragraphs:
        if 'Write measurable quality requirements and assign identifiers' in p.text:
            p.text = ''

    # 17. Embed General Use Case Diagram & Catalog
    if "General Use Case Diagram" in headings_map:
        print("Embedding General Use Case Diagram into Chapter III...")
        curr = headings_map["General Use Case Diagram"]
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/general-use-case-diagram.png', Inches(6.3),
                                   'Figure 3.2: FreshFood General Use Case Diagram (Master System Boundary)')

    # 18. Embed Decomposed Use Case Diagrams
    if "Decomposed Use Case Diagrams" in headings_map:
        print("Embedding Decomposed Use Case Diagrams into Chapter III...")
        curr = headings_map["Decomposed Use Case Diagrams"]
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/common-use-case-diagram.png', Inches(6.2),
                                   'Figure 3.3: Common Subsystem Use Case Diagram (Authentication & Shared Operations)')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/customer-use-case-diagram.png', Inches(6.2),
                                   'Figure 3.4: Customer Actor Subsystem Use Case Diagram')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/sale-staff-use-case-diagram.png', Inches(6.2),
                                   'Figure 3.5: Sales Staff Subsystem Use Case Diagram')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/wh-staff-use-case-diagram.png', Inches(6.2),
                                   'Figure 3.6: Warehouse Staff Subsystem Use Case Diagram')
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/store-owner-use-case-diagram.png', Inches(6.2),
                                   'Figure 3.7: Store Owner Subsystem Use Case Diagram')

    # 19. Populate Structured Use Case Descriptions (Canonical SWD392 12-Row Form)
    if "Use Case Descriptions" in headings_map:
        print("Populating Structured Use Case Descriptions (SWD392 12-Row Format)...")
        curr = headings_map["Use Case Descriptions"]
        
        # UC-C06 Checkout & Place Order
        uc_c06 = {
            "id_name": "UC-C06 Checkout & Place Order",
            "created_by": "SE Lifecycle Team",
            "date_created": "07/10/2026",
            "primary_actor": "Customer (Authenticated Shopper)",
            "secondary_actors": "Google Maps Distance API, SePay VietQR Payment Gateway",
            "description": "Allows an authenticated customer to select a delivery address, verify distance within 10 km, calculate tiered shipping fee, choose payment method (COD or VietQR), hold batch stock, and submit an order.",
            "trigger": "Customer clicks 'Proceed to Checkout' from the Shopping Cart.",
            "preconditions": "PRE-1. Customer is logged in via OAuth 2.0 (BR-AUTH-01).\nPRE-2. Cart contains at least one active product batch with available inventory (BR-BAT-02).",
            "postconditions": "POST-1. Order record created in 'Pending' (COD) or 'Pending Payment' (VietQR) status.\nPOST-2. Batch inventory is locked/reserved for 15 minutes (BR-ORD-01).\nPOST-3. Order notification dispatched to store.",
            "normal_flow": "1. Customer reviews cart and initiates checkout.\n2. System retrieves customer saved delivery addresses (BR-AUTH-03).\n3. Customer selects or inputs a delivery address.\n4. System calls Google Maps API to measure road distance d from store.\n5. System verifies d <= 10.0 km (BR-DEL-01) and computes tiered shipping fee (BR-DEL-02).\n6. System displays delivery fee and grand total.\n7. Customer selects Payment Method: Cash on Delivery (COD) or VietQR.\n8. Customer confirms order.\n9. System locks batch stock and creates order in Pending status.\n10. System displays Order Confirmation screen with estimated delivery window.",
            "alt_flows": "A7.1 VietQR Selected: System generates dynamic QR code with order-specific amount and reference. When SePay webhook confirms transfer, status updates to 'Paid' (BR-ORD-03).",
            "exceptions": "E5.1 Distance > 10.0 km: System blocks checkout, displays out-of-radius message, and prompts for an alternate address within 10 km (BR-DEL-01).\nE9.1 Concurrency conflict: If a batch sells out during checkout, system notifies user and prompts cart adjustment.",
            "priority": "High",
            "business_rules": "BR-DEL-01, BR-DEL-02, BR-ORD-01, BR-ORD-02, BR-ORD-03, BR-AUTH-01, BR-AUTH-03"
        }
        curr = insert_paragraph_after(curr, "Table 3.15: Use Case Description — UC-C06: Checkout & Place Order", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        curr = insert_uc_table(curr, doc, uc_c06)

        # UC-M08 Manage Goods Receipts
        uc_m08 = {
            "id_name": "UC-M08 Manage Goods Receipts",
            "created_by": "SE Lifecycle Team",
            "date_created": "07/10/2026",
            "primary_actor": "Warehouse Staff (WS)",
            "secondary_actors": "Supplier",
            "description": "Enables Warehouse Staff to record inbound supplier shipments, validate item quantities, enter physical batch lot numbers, MFG dates, and EXP dates, and ingest stock into warehouse inventory.",
            "trigger": "Warehouse Staff opens 'Goods Receipt Entry' module upon shipment arrival.",
            "preconditions": "PRE-1. Staff is logged in with Warehouse Staff role (BR-SEC-01).\nPRE-2. Supplier and Product SKUs are pre-registered in system.",
            "postconditions": "POST-1. Goods Receipt record created with status 'Confirmed'.\nPOST-2. BatchInventory records created with InitialQty, CurrentQty, and FEFO sorting keys.",
            "normal_flow": "1. Warehouse Staff selects Supplier from verified supplier list.\n2. Staff adds received line items, selecting product SKU, unit import price, and quantity.\n3. Staff inputs physical Batch Number, Manufacturing Date (MFG), and Expiration Date (EXP) for each item.\n4. System validates: EXP > MFG and EXP >= Receipt Date + 3 days for perishables (BR-GR-02).\n5. Staff reviews total receipt cost and submits Goods Receipt.\n6. System generates unique Receipt ID, increments batch inventory, and sets batch state to 'Active' (BR-BAT-01).",
            "alt_flows": "A4.1 New batch price differs from existing batch: System allows setting independent retail price for new batch (BR-BAT-01).",
            "exceptions": "E4.1 Invalid EXP date: System rejects entry with validation error message if EXP <= MFG or EXP is less than 3 days from receipt.",
            "priority": "High",
            "business_rules": "BR-GR-01, BR-GR-02, BR-BAT-01, BR-BAT-02, BR-SEC-01"
        }
        curr = insert_paragraph_after(curr, "Table 3.16: Use Case Description — UC-M08: Manage Goods Receipts", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        curr = insert_uc_table(curr, doc, uc_m08)

        # UC-M01 Process Orders
        uc_m01 = {
            "id_name": "UC-M01 Process Orders",
            "created_by": "SE Lifecycle Team",
            "date_created": "07/10/2026",
            "primary_actor": "Sales Staff (SS)",
            "secondary_actors": "—",
            "description": "Allows Sales Staff to view incoming customer orders, perform mandatory first-order phone verification, confirm order contents, and route orders to packaging.",
            "trigger": "Sales Staff accesses the Pending Orders queue.",
            "preconditions": "PRE-1. Sales Staff is authenticated with internal store credentials (BR-SEC-01).\nPRE-2. Orders exist in Pending or Paid status.",
            "postconditions": "POST-1. Order status advances to 'Processing'.\nPOST-2. Staff verification timestamp and notes are recorded.",
            "normal_flow": "1. Sales Staff opens order queue and selects an incoming order.\n2. System checks customer order history. If order count = 0, system flags 'First-Time Customer: Phone Verification Required' (BR-FUL-01).\n3. Staff places telephone call to customer, confirms delivery address, items, and delivery time window.\n4. Staff marks phone verification completed and clicks 'Approve Order'.\n5. System updates order status to 'Processing' and triggers invoice/packing slip printing (UC-M02).",
            "alt_flows": "A2.1 Repeat Customer (Order Count >= 1): Phone call is optional; staff clicks 'Quick Approve'.",
            "exceptions": "E3.1 Customer unreachable / fake phone: Staff logs attempt; after 3 failed attempts, marks order 'Cancelled' and stock is released (BR-ORD-05).",
            "priority": "High",
            "business_rules": "BR-FUL-01, BR-FUL-02, BR-ORD-04, BR-ORD-05, BR-SEC-01"
        }
        curr = insert_paragraph_after(curr, "Table 3.17: Use Case Description — UC-M01: Process Orders", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        curr = insert_uc_table(curr, doc, uc_m01)

        # UC-M09 Manage Batch Inventory & Pricing
        uc_m09 = {
            "id_name": "UC-M09 Manage Batch Inventory & Pricing",
            "created_by": "SE Lifecycle Team",
            "date_created": "07/10/2026",
            "primary_actor": "Warehouse Staff (WS)",
            "secondary_actors": "—",
            "description": "Allows Warehouse Staff to inspect batch stock levels, configure batch retail selling prices, apply clearance discounts, and release held batches.",
            "trigger": "Warehouse Staff selects 'Batch Inventory' from the navigation menu.",
            "preconditions": "PRE-1. Staff is logged in with Warehouse Staff role (BR-SEC-01).\nPRE-2. Active batches exist in warehouse inventory.",
            "postconditions": "POST-1. Batch selling price or discount rate is updated in real time.\nPOST-2. Storefront instantly reflects revised pricing.",
            "normal_flow": "1. Warehouse Staff views batch inventory list filtered by product or expiration urgency.\n2. Staff selects a batch nearing expiration (e.g., remaining shelf-life <= 2 days).\n3. Staff chooses 'Apply Clearance Discount' and selects discount rate (10% - 50%) (BR-BAT-04).\n4. System updates batch selling price and storefront displays clearance badge.\n5. When Current Date >= EXP, system automatically delists batch from sales (BR-EXP-01).",
            "alt_flows": "A3.1 Delayed Batch Activation: Staff switches batch status from 'Delayed' to 'Active' to enable parallel sales (BR-BAT-03).",
            "exceptions": "E3.1 Discount rate invalid (<10% or >50%): System restricts input within business rule boundaries.",
            "priority": "High",
            "business_rules": "BR-BAT-01, BR-BAT-02, BR-BAT-03, BR-BAT-04, BR-EXP-01"
        }
        curr = insert_paragraph_after(curr, "Table 3.18: Use Case Description — UC-M09: Manage Batch Inventory & Pricing", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        curr = insert_uc_table(curr, doc, uc_m09)

    # 20. Embed Complex Use Case Activity Diagram (UC-C06 Checkout)
    if "III.7.5 Activity Diagrams for Complex Use Cases" in headings_map:
        print("Embedding Complex Use Case Activity Diagram...")
        curr = headings_map["III.7.5 Activity Diagrams for Complex Use Cases"]
        curr = insert_picture_after(curr, doc, 'artifacts/diagrams/images/checkout-activity-diagram.png', Inches(6.3),
                                   'Figure 3.8: Customer Checkout Activity Diagram with Swimlanes (UC-C06)')

    # 21. Populate Data Dictionary Table (matching Table 8 of SWD392Example_RDS)
    if "Data Requirements" in headings_map:
        print("Populating Structured Data Dictionary Table (SWD392 Table 8 Format)...")
        curr = headings_map["Data Requirements"]
        
        entities_data = {
            "Category": ("Product Category Entity", [
                ["CatId", "String", "20", "Unique Category identifier (Primary Key)"],
                ["CatName", "String", "100", "Category name (Unique)"],
                ["Description", "String", "500", "Category description and storage guidelines"]
            ]),
            "Product": ("Master Product Catalog Entity", [
                ["ProductId", "String", "20", "Unique Product identifier / SKU (Primary Key)"],
                ["CatId", "String", "20", "Foreign Key referencing Category"],
                ["ProductName", "String", "150", "Full commercial product name"],
                ["MeasureUnit", "String", "30", "Unit of measurement (kg, bunch, box, gram)"],
                ["Description", "String", "Max", "Detailed description and nutritional info"],
                ["ImageUrl", "String", "255", "Product primary showcase photograph URL"],
                ["IsActive", "Boolean", "1", "Active status flag for storefront visibility"]
            ]),
            "Supplier": ("Vendor / Farm Supplier Entity", [
                ["SupplierId", "String", "20", "Unique Supplier code (Primary Key)"],
                ["SupplierName", "String", "150", "Company or organic farm cooperative name"],
                ["ContactPhone", "String", "20", "Representative contact phone number"],
                ["Address", "String", "255", "Farm or warehouse registered address"],
                ["IsActive", "Boolean", "1", "Active partnership status"]
            ]),
            "GoodsReceipt": ("Goods Receipt Note (GRN) Entity", [
                ["ReceiptId", "String", "20", "Unique Goods Receipt identifier (Primary Key)"],
                ["SupplierId", "String", "20", "Foreign Key referencing Supplier"],
                ["ReceiptDate", "DateTime", "8", "Timestamp when shipment arrived at warehouse"],
                ["ReceivedBy", "String", "20", "Foreign Key referencing Warehouse Staff Account"],
                ["TotalAmount", "Decimal", "18,0", "Total import invoice cost (sum of line totals)"],
                ["Status", "String", "20", "Receipt status (Draft, Confirmed, Locked)"]
            ]),
            "BatchInventory": ("Batch-Level Inventory Entity", [
                ["BatchId", "String", "20", "Unique Batch identifier (Primary Key)"],
                ["ProductId", "String", "20", "Foreign Key referencing Product"],
                ["ReceiptId", "String", "20", "Foreign Key referencing GoodsReceipt"],
                ["BatchCode", "String", "50", "Physical lot number printed on shipment cartons"],
                ["MfgDate", "Date", "4", "Manufacturing / Harvest date"],
                ["ExpDate", "Date", "4", "Expiration date (FEFO sort key)"],
                ["ImportPrice", "Decimal", "18,0", "Unit import acquisition cost"],
                ["RetailPrice", "Decimal", "18,0", "Current retail selling price for this batch"],
                ["DiscountRate", "Decimal", "5,2", "Clearance discount rate (0.00 to 0.50)"],
                ["InitialQty", "Decimal", "10,2", "Initial received quantity"],
                ["CurrentQty", "Decimal", "10,2", "Physical remaining unsold quantity in stock"],
                ["ReservedQty", "Decimal", "10,2", "Quantity locked for pending checkout orders"],
                ["Status", "String", "20", "Batch state (Active, Delayed, Delisted, Disposed)"]
            ]),
            "Order": ("Customer Order Header Entity", [
                ["OrderId", "String", "20", "Unique Order identifier (Primary Key)"],
                ["CustomerId", "String", "20", "Foreign Key referencing Customer Account"],
                ["OrderDate", "DateTime", "8", "Order submission timestamp"],
                ["ShippingAddress", "String", "255", "Delivery address"],
                ["DeliveryDistance", "Decimal", "5,2", "Driving distance from store in kilometers"],
                ["ShippingFee", "Decimal", "18,0", "Tiered shipping fee computed from distance"],
                ["SubTotal", "Decimal", "18,0", "Sum of line item totals"],
                ["TotalAmount", "Decimal", "18,0", "Final payable amount (SubTotal + ShippingFee)"],
                ["PaymentMethod", "String", "20", "Payment choice: 'COD' or 'VietQR'"],
                ["PaymentStatus", "String", "20", "Payment state: 'Unpaid' or 'Paid'"],
                ["OrderStatus", "String", "20", "Order lifecycle: Pending, Processing, In Delivery, Delivered, Cancelled"],
                ["VerifiedByStaff", "String", "20", "Sales Staff who confirmed first-time order"]
            ]),
            "OrderDetail": ("Order Line Item Entity", [
                ["DetailId", "String", "20", "Unique Order Detail identifier (Primary Key)"],
                ["OrderId", "String", "20", "Foreign Key referencing Order"],
                ["BatchId", "String", "20", "Foreign Key referencing BatchInventory"],
                ["Quantity", "Decimal", "10,2", "Purchased quantity"],
                ["UnitPrice", "Decimal", "18,0", "Applied batch retail price at checkout time"],
                ["DiscountAmount", "Decimal", "18,0", "Discount deduction per item"],
                ["LineTotal", "Decimal", "18,0", "Final line total: Qty * UnitPrice - Discount"]
            ]),
            "AuditLog": ("Staff Mutation Audit Log Entity", [
                ["LogId", "BigInt", "8", "Unique audit log entry identifier (Primary Key)"],
                ["StaffId", "String", "20", "Foreign Key referencing Staff Account"],
                ["ActionType", "String", "20", "Operation type: 'CREATE', 'UPDATE', or 'DELETE'"],
                ["EntityName", "String", "100", "Modified business table / domain entity name"],
                ["RecordId", "String", "100", "Target record business key or primary identifier"],
                ["OldValues", "String", "Max", "Serialized JSON snapshot of record prior to mutation"],
                ["NewValues", "String", "Max", "Serialized JSON snapshot of record after mutation"],
                ["IpAddress", "String", "45", "Client IPv4/IPv6 originating network address"],
                ["Timestamp", "DateTime", "8", "Exact timestamp when mutation was committed"]
            ])
        }
        curr = insert_paragraph_after(curr, "Table 3.13: Data Dictionary & Attribute Specifications", bold=True, font_size=10.5, color_rgb=(27, 94, 32))
        curr = insert_data_dictionary_table(curr, doc, entities_data)

    # 22. Apply comprehensive typography formatting across all paragraphs and tables
    print("Applying global typography invariants (Bold headings, Justify body, 0.5 cm indent)...")
    for p in doc.paragraphs:
        txt = p.text.strip()
        if not txt:
            continue
        # Headings / Titles: BOLD, no indent
        if p.style.name.startswith('Heading') or p.style.name in ['Title', 'Subtitle']:
            p.paragraph_format.first_line_indent = Cm(0)
            for r in p.runs:
                r.bold = True
            continue
        # Figure captions: Centered, BOLD
        if txt.startswith('Figure '):
            p.alignment = WD_ALIGN_PARAGRAPH.CENTER
            p.paragraph_format.first_line_indent = Cm(0)
            for r in p.runs:
                r.bold = True
            continue
        # Table captions: Left, BOLD
        if txt.startswith('Table '):
            p.alignment = WD_ALIGN_PARAGRAPH.LEFT
            p.paragraph_format.first_line_indent = Cm(0)
            p.paragraph_format.keep_with_next = True
            for r in p.runs:
                r.bold = True
            continue
        # Lists / Bullets: unindented
        if p.style.name.startswith('List') or txt.startswith('- ') or txt.startswith('* ') or txt.startswith('• ') or re.match(r'^\d+\.', txt):
            p.paragraph_format.first_line_indent = Cm(0)
            continue
        # Body text: Justified, 0.5 cm indent
        p.alignment = WD_ALIGN_PARAGRAPH.JUSTIFY
        p.paragraph_format.first_line_indent = Inches(0.197)

    # Format all tables: Header row centered bold, data cells justified unindented
    print("Applying global table invariants to all tables...")
    for tbl in doc.tables:
        sf.style_table(tbl)

    # 23. Save final document
    os.makedirs(os.path.dirname(TARGET_PATH), exist_ok=True)
    doc.save(TARGET_PATH)
    print(f"Master Specification successfully built: {TARGET_PATH} (size: {os.path.getsize(TARGET_PATH)} bytes)")

if __name__ == '__main__':
    build_full_specification()
