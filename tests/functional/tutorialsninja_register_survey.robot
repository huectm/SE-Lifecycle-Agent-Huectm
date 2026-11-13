*** Settings ***
Documentation    Test suite generated from session 3eabbad7-dda9-4c85-ba8c-15d5b1c2c8ae containing 1 test case for web automation.
Library         SeleniumLibrary
Test Tags       automated    generated    web

*** Test Cases ***
Inspect Registration Empty Submission
    [Documentation]    Test case that opens browser, performs click action.
    Open Browser    https://tutorialsninja.com/demo/index.php?route=account/register    chrome    options=add_argument("--headless=new");add_argument("--window-size=1440,1000")    # Open chrome and navigate to https://tutorialsninja.com/demo/index.php?route=account/register
    Click Button    css:input[type='submit']    # Click on css:input[type='submit']
    [Teardown]    Close Browser    
