"""
Export all .drawio diagrams in artifacts/diagrams/ to high-resolution .png images.
Uses Microsoft Edge headless and scratch/viewer-static.min.js for offline, pixel-perfect rendering.
"""

import os
import json
import html
import subprocess

edge_exe = r'C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe'

def render_drawio_to_png(drawio_path, output_png, width=1600, height=1100):
    if not os.path.exists(drawio_path):
        print(f"File not found: {drawio_path}")
        return False
        
    with open(drawio_path, 'r', encoding='utf-8') as f:
        xml_content = f.read()

    config = {
        "xml": xml_content,
        "page": 0,
        "zoom": 1.25,
        "nav": False,
        "toolbar": None,
        "resize": True
    }
    config_attr = html.escape(json.dumps(config), quote=True)
    viewer_js = os.path.abspath('scratch/viewer-static.min.js').replace('\\', '/')

    html_content = f"""<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<style>
  html, body {{
    margin: 0;
    padding: 20px;
    background: #ffffff;
  }}
  .mxgraph {{
    background: #ffffff;
  }}
</style>
</head>
<body>
<div class="mxgraph" style="max-width:100%;border:none;" data-mxgraph="{config_attr}"></div>
<script src="{viewer_js}"></script>
<script>
  window.addEventListener('load', () => {{
    if (window.GraphViewer && window.GraphViewer.processElements) {{
      window.GraphViewer.processElements();
    }}
  }});
</script>
</body>
</html>
"""
    html_path = os.path.abspath('scratch/temp_drawio_batch.html')
    with open(html_path, 'w', encoding='utf-8') as f:
        f.write(html_content)

    os.makedirs(os.path.dirname(output_png), exist_ok=True)
    abs_png = os.path.abspath(output_png)
    cmd = [
        edge_exe,
        '--headless',
        '--disable-gpu',
        '--virtual-time-budget=3500',
        f'--window-size={width},{height}',
        f'--screenshot={abs_png}',
        f'file:///{html_path}'
    ]
    subprocess.run(cmd, check=True, capture_output=True)
    print(f"Rendered: {output_png} ({os.path.getsize(abs_png)} bytes)")
    return True

def export_all():
    diagrams = [
        ('artifacts/diagrams/context/system-context-diagram.drawio', 'artifacts/diagrams/images/system-context-diagram.png', 1600, 1100),
        ('artifacts/diagrams/use-case/general-use-case-diagram.drawio', 'artifacts/diagrams/images/general-use-case-diagram.png', 1600, 1100),
        ('artifacts/diagrams/use-case/customer-use-case-diagram.drawio', 'artifacts/diagrams/images/customer-use-case-diagram.png', 1600, 1200),
        ('artifacts/diagrams/use-case/wh-staff-decomposed-use-case-diagram.drawio', 'artifacts/diagrams/images/wh-staff-use-case-diagram.png', 1600, 1300),
        ('artifacts/diagrams/use-case/sale-staff-decomposed-use-case-diagram.drawio', 'artifacts/diagrams/images/sale-staff-use-case-diagram.png', 1600, 1100),
        ('artifacts/diagrams/use-case/store-owner-decomposed-use-case-diagram.drawio', 'artifacts/diagrams/images/store-owner-use-case-diagram.png', 1600, 1000),
        ('artifacts/diagrams/use-case/common-use-case-diagram.drawio', 'artifacts/diagrams/images/common-use-case-diagram.png', 1600, 1000),
        ('artifacts/diagrams/activity/bp01-goods-receipt-activity-diagram.drawio', 'artifacts/diagrams/images/bp01-goods-receipt-activity.png', 1600, 1200),
        ('artifacts/diagrams/activity/bp02-online-ordering-activity-diagram.drawio', 'artifacts/diagrams/images/bp02-online-ordering-activity.png', 1600, 1200),
        ('artifacts/diagrams/activity/bp03-order-fulfillment-activity-diagram.drawio', 'artifacts/diagrams/images/bp03-order-fulfillment-activity.png', 1600, 1200),
        ('artifacts/diagrams/activity/bp04-post-purchase-activity-diagram.drawio', 'artifacts/diagrams/images/bp04-post-purchase-activity.png', 1600, 1200),
        ('artifacts/diagrams/activity/checkout-activity-diagram.drawio', 'artifacts/diagrams/images/checkout-activity-diagram.png', 1600, 1200)
    ]

    print("=== EXPORTING ALL DIAGRAMS TO HIGH-RESOLUTION PNG ===")
    success_count = 0
    for d_in, d_out, w, h in diagrams:
        try:
            if render_drawio_to_png(d_in, d_out, w, h):
                success_count += 1
        except Exception as e:
            print(f"Error rendering {d_in}: {e}")
            
    print(f"Completed rendering {success_count}/{len(diagrams)} diagrams to artifacts/diagrams/images/")

if __name__ == '__main__':
    export_all()
