*** Settings ***
Documentation    Test suite generated from session 34c8972f-a460-4fed-b614-f2c92c0c6c26 containing 1 test case for web automation.
Library         SeleniumLibrary
Test Tags       automated    generated    web

*** Test Cases ***
Chrome Environment Smoke
    [Documentation]    Environment smoke only. No business baseline or approval changes.
    Open Browser    about:blank    chrome
    Location Should Be    about:blank
    [Teardown]    Close All Browsers    
