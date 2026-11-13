"""Run ten existing registration cases in visible Chrome for tester observation."""
from pathlib import Path
import os
from robot import run

ROOT = Path(__file__).resolve().parents[2]
CASES = ['001', '002', '003', '008', '029', '035', '036', '037', '038', '039']

if __name__ == '__main__':
    os.chdir(ROOT)
    raise SystemExit(run(
        'tests/functional/tutorialsninja_register.robot',
        test=[f'REG-{case}*' for case in CASES],
        variable=['BROWSER_OPTIONS:add_argument("--start-maximized")',
                  'ACTION_DELAY:0.5s', 'CASE_OBSERVATION_DELAY:3s'],
        outputdir='artifacts/test-results/tutorialsninja-register/visible-10',
    ))
