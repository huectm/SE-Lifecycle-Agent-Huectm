*** Settings ***
Documentation    Test suite generated from session b163deb7-9c6e-4907-b1bd-484ff4fddf98 containing 1 test case for web automation.
Library         SeleniumLibrary
Test Tags       automated    generated    web

*** Test Cases ***
MathX Login Survey Browser Lifecycle
    [Documentation]    Survey browser lifecycle only; not evidence of login functional correctness. Main reviewed suite is mathx_login.robot.
    Open Browser    https://mathx.vn/dang-nhap.html    chrome    options=add_argument("--headless=new");add_argument("--window-size=1440,1000")    # Open chrome and navigate to https://mathx.vn/dang-nhap.html
    Evaluate    robot.libraries.BuiltIn.BuiltIn().get_library_instance('SeleniumLibrary').close_all_browsers()    modules=robot.libraries.BuiltIn
    [Teardown]    Close Browser    
