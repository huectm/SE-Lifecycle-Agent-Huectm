"""Load captured Dantri fixtures with Python standard library only."""
from pathlib import Path
import csv

def get_variables():
    with Path(__file__).with_name("dantri_article_details.csv").open(encoding="utf-8", newline="") as stream:
        cases = list(csv.DictReader(stream))
    if len(cases) != 3 or any(not c["url"].startswith("https://dantri.com.vn/") for c in cases):
        raise ValueError("Expected three Dantri article fixtures.")
    return {"CASES": cases}
