"""Synthetic MathX fixtures. No live account credentials."""
import json
from pathlib import Path
CASES = json.loads(Path(__file__).with_name("mathx_login_data.json").read_text(encoding="utf-8"))
