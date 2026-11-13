*** Settings ***
Documentation    UC-REG-01 keyword-driven UI tests. CSV is the authoritative dataset. Proposed UC constraints may fail pending clarification.
Library    SeleniumLibrary    timeout=15s
Library    ../resources/RegistrationData.py
Suite Setup    Open Registration Browser
Suite Teardown    Close All Browsers
Test Setup    Reset Guest Registration
Test Teardown    Capture Registration Evidence
Test Template    Verify Registration Dataset
Test Tags    registration    functional    data-driven

*** Variables ***
${REGISTER_URL}    https://tutorialsninja.com/demo/index.php?route=account/register
${BROWSER_OPTIONS}    add_argument("--headless=new");add_argument("--window-size=1440,1000")
${ACTION_DELAY}    0s
${CASE_OBSERVATION_DELAY}    0s

*** Test Cases ***
REG-001 Register with default Newsletter No
    REG-001
REG-002 Register with Newsletter Yes
    REG-002
REG-003 firstname length 0
    REG-003
REG-004 firstname length 1
    REG-004
REG-005 firstname length 2
    REG-005
REG-006 firstname length 31
    REG-006
REG-007 firstname length 32
    REG-007
REG-008 firstname length 33
    REG-008
REG-009 lastname length 0
    REG-009
REG-010 lastname length 1
    REG-010
REG-011 lastname length 2
    REG-011
REG-012 lastname length 31
    REG-012
REG-013 lastname length 32
    REG-013
REG-014 lastname length 33
    REG-014
REG-015 telephone length 0
    REG-015
REG-016 telephone length 2
    REG-016
REG-017 telephone length 3
    REG-017
REG-018 telephone length 4
    REG-018
REG-019 telephone length 31
    REG-019
REG-020 telephone length 32
    REG-020
REG-021 telephone length 33
    REG-021
REG-022 password length 0
    REG-022
REG-023 password length 3
    REG-023
REG-024 password length 4
    REG-024
REG-025 password length 5
    REG-025
REG-026 password length 19
    REG-026
REG-027 password length 20
    REG-027
REG-028 password length 21
    REG-028
REG-029 Invalid email ''
    REG-029
REG-030 Invalid email 'plainaddress'
    REG-030
REG-031 Invalid email 'a@'
    REG-031
REG-032 Invalid email '@example.com'
    REG-032
REG-033 Invalid email 'a b@example.com'
    REG-033
REG-034 Confirmation empty or mismatch
    REG-034
REG-035 Confirmation empty or mismatch
    REG-035
REG-036 Privacy not accepted
    REG-036
REG-037 Previously registered email
    REG-037
REG-038 Login page link
    REG-038
REG-039 Privacy policy dialog
    REG-039
REG-040 Proposed UC firstname maximum boundary 20
    REG-040
REG-041 Proposed UC firstname maximum boundary 21
    REG-041
REG-042 Proposed UC lastname maximum boundary 10
    REG-042
REG-043 Proposed UC lastname maximum boundary 11
    REG-043
REG-044 Proposed UC password composition Abc12!x
    REG-044
REG-045 Proposed UC password composition Abc12!xy
    REG-045
REG-046 Proposed UC password composition abc12!xy
    REG-046
REG-047 Proposed UC password composition ABC12!XY
    REG-047
REG-048 Proposed UC password composition Abcdef!x
    REG-048
REG-049 Proposed UC password composition Abc123xy
    REG-049
REG-050 Whitespace-only firstname
    REG-050
REG-051 Whitespace-only lastname
    REG-051
REG-052 Network/system failure recovery
    REG-052
REG-053 Proposed UC adjacent valid boundary firstname
    REG-053
REG-054 Proposed UC adjacent valid boundary lastname
    REG-054
REG-055 Proposed UC adjacent valid boundary password
    REG-055

*** Keywords ***
Open Registration Browser
    Open Browser    ${REGISTER_URL}    chrome    options=${BROWSER_OPTIONS}
    Set Selenium Speed    ${ACTION_DELAY}

Reset Guest Registration
    Delete All Cookies
    Go To    ${REGISTER_URL}
    Wait Until Element Is Visible    id:input-firstname
    Radio Button Should Be Set To    newsletter    0
    Checkbox Should Not Be Selected    name:agree

Verify Registration Dataset
    [Arguments]    ${case_id}
    ${row}=    Get Registration Dataset    ${case_id}
    IF    $row['field'] == 'network'
        Skip    Controlled server/network fault and persistence access unavailable. No system-error branch coverage claimed.
    END
    IF    $row['field'] == 'login'
        Click Link    link:login page
        Location Should Contain    route=account/login
        RETURN
    END
    IF    $row['field'] == 'policy'
        Click Link    css:a.agree
        Wait Until Element Is Visible    css:.modal-dialog
        Element Should Contain    css:.modal-dialog    Privacy Policy
        RETURN
    END
    IF    $row['field'] == 'duplicate'
        ${row}=    Prepare Duplicate Account    ${row}
    END
    Fill Registration Form    ${row}
    Submit Registration
    Assert Registration Outcome    ${row}

Fill Registration Form
    [Arguments]    ${row}
    FOR    ${field}    IN    firstname    lastname    email    telephone    password    confirm
        Input Text    id:input-${field}    ${row}[${field}]
    END
    Select Radio Button    newsletter    ${row}[newsletter]
    IF    $row['agree'] == '1'
        Select Checkbox    name:agree
    END

Submit Registration
    Click Button    css:input[type="submit"]

Assert Registration Outcome
    [Arguments]    ${row}
    Check Registration Outcome    ${row}

Prepare Duplicate Account
    [Arguments]    ${row}
    Fill Registration Form    ${row}
    Submit Registration
    Wait Until Page Contains    Your Account Has Been Created!
    Location Should Contain    route=account/success
    Delete All Cookies
    Go To    ${REGISTER_URL}
    RETURN    ${row}

Capture Registration Evidence
    Save Registration Evidence    ${TEST NAME}    ${TEST STATUS}
    Sleep    ${CASE_OBSERVATION_DELAY}

