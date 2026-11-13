#!/usr/bin/env python3
"""
Karl Wiegers Quantitative Requirements Prioritization Calculator
Governed by: .agents/Rules/requirements-rules.md §14 and .agents/skills/requirements-engineering/SKILL.md

Formula:
  Total Value = 2 * Benefit + Penalty
  Value %     = (Total Value / sum(Total Value)) * 100
  Cost %      = (Cost / sum(Cost)) * 100
  Risk %      = (Risk / sum(Risk)) * 100
  Priority    = Value % / (Cost % + Risk %)

Scale for Benefit, Penalty, Cost, Risk: 1 (Lowest) to 9 (Highest).
"""

import argparse
import csv
import sys
from pathlib import Path
from typing import List, Dict, Any


def calculate_priorities(items: List[Dict[str, Any]]) -> List[Dict[str, Any]]:
    if not items:
        return []

    # Calculate Total Value for each item
    for item in items:
        benefit = float(item.get("Benefit", 1))
        penalty = float(item.get("Penalty", 1))
        cost = float(item.get("Cost", 1))
        risk = float(item.get("Risk", 1))

        item["Benefit"] = benefit
        item["Penalty"] = penalty
        item["Cost"] = cost
        item["Risk"] = risk
        item["Total_Value"] = 2.0 * benefit + penalty

    # Calculate Totals for normalization
    sum_total_value = sum(item["Total_Value"] for item in items)
    sum_cost = sum(item["Cost"] for item in items)
    sum_risk = sum(item["Risk"] for item in items)

    # Calculate percentages and Priority score
    for item in items:
        val_pct = (item["Total_Value"] / sum_total_value * 100.0) if sum_total_value > 0 else 0.0
        cost_pct = (item["Cost"] / sum_cost * 100.0) if sum_cost > 0 else 0.0
        risk_pct = (item["Risk"] / sum_risk * 100.0) if sum_risk > 0 else 0.0

        item["Value_Pct"] = val_pct
        item["Cost_Pct"] = cost_pct
        item["Risk_Pct"] = risk_pct

        denominator = cost_pct + risk_pct
        if denominator > 0:
            item["Priority"] = round(val_pct / denominator, 4)
        else:
            item["Priority"] = 0.0

        # Tier classification based on mean score = 0.500:
        # Score > 0.60: Above average value-to-cost ratio -> High
        # Score 0.45 - 0.60: Moderate/Average -> Medium
        # Score < 0.45: High cost/risk relative to value -> Low
        if item["Priority"] >= 0.60:
            item["Tier"] = "High (Sprint 1 Candidate)"
        elif item["Priority"] >= 0.45:
            item["Tier"] = "Medium (Sprint 2 Candidate)"
        else:
            item["Tier"] = "Low (Sprint 3 / Future Backlog)"

    # Sort descending by Priority
    items.sort(key=lambda x: x["Priority"], reverse=True)
    return items


def load_from_csv(csv_path: str) -> List[Dict[str, Any]]:
    items = []
    with open(csv_path, mode="r", encoding="utf-8-sig") as f:
        reader = csv.DictReader(f)
        for row in reader:
            items.append({
                "ID": row.get("ID", "").strip(),
                "Requirement_Name": row.get("Requirement_Name", row.get("Name", "")).strip(),
                "Benefit": float(row.get("Benefit", 1)),
                "Penalty": float(row.get("Penalty", 1)),
                "Cost": float(row.get("Cost", 1)),
                "Risk": float(row.get("Risk", 1)),
            })
    return items


def write_to_csv(items: List[Dict[str, Any]], out_path: str):
    fieldnames = [
        "Rank", "ID", "Requirement_Name", "Benefit", "Penalty",
        "Total_Value", "Value_Pct", "Cost", "Cost_Pct",
        "Risk", "Risk_Pct", "Priority", "Tier"
    ]
    with open(out_path, mode="w", newline="", encoding="utf-8") as f:
        writer = csv.DictWriter(f, fieldnames=fieldnames)
        writer.writeheader()
        for rank, item in enumerate(items, 1):
            row = {
                "Rank": rank,
                "ID": item["ID"],
                "Requirement_Name": item["Requirement_Name"],
                "Benefit": f"{item['Benefit']:.0f}",
                "Penalty": f"{item['Penalty']:.0f}",
                "Total_Value": f"{item['Total_Value']:.0f}",
                "Value_Pct": f"{item['Value_Pct']:.2f}%",
                "Cost": f"{item['Cost']:.0f}",
                "Cost_Pct": f"{item['Cost_Pct']:.2f}%",
                "Risk": f"{item['Risk']:.0f}",
                "Risk_Pct": f"{item['Risk_Pct']:.2f}%",
                "Priority": f"{item['Priority']:.3f}",
                "Tier": item["Tier"],
            }
            writer.writerow(row)


def print_markdown_table(items: List[Dict[str, Any]], top_n: int = None):
    display_items = items[:top_n] if top_n else items
    print("| Rank | Req ID | Requirement Description | Benefit | Penalty | Total Value | Value % | Cost | Cost % | Risk | Risk % | Priority Score | Backlog Tier |")
    print("|:---:|:---:|:---|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---|")
    for rank, it in enumerate(display_items, 1):
        print(f"| {rank} | {it['ID']} | {it['Requirement_Name']} | {it['Benefit']:.0f} | {it['Penalty']:.0f} | {it['Total_Value']:.0f} | {it['Value_Pct']:.2f}% | {it['Cost']:.0f} | {it['Cost_Pct']:.2f}% | {it['Risk']:.0f} | {it['Risk_Pct']:.2f}% | **{it['Priority']:.3f}** | {it['Tier']} |")


def main():
    parser = argparse.ArgumentParser(description="Calculate Karl Wiegers Requirements Priority")
    parser.add_argument("--input", "-i", type=str, help="Path to input CSV file with ID, Requirement_Name, Benefit, Penalty, Cost, Risk")
    parser.add_argument("--output", "-o", type=str, help="Path to output prioritized CSV file")
    parser.add_argument("--top", "-t", type=int, default=None, help="Show only top N requirements in console output")
    args = parser.parse_args()

    if not args.input:
        print("No input CSV provided. Run with --input <path_to_csv>.")
        sys.exit(1)

    items = load_from_csv(args.input)
    prioritized = calculate_priorities(items)

    if args.output:
        write_to_csv(prioritized, args.output)
        print(f"Successfully saved prioritized backlog to: {args.output}")

    print("\n--- Karl Wiegers Prioritization Ranking ---")
    print_markdown_table(prioritized, top_n=args.top)


if __name__ == "__main__":
    main()
