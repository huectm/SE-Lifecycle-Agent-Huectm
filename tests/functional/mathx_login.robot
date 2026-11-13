*** Settings ***
Documentation    User-approved MathX login functional assessment; account-dependent cases remain blocked.
Library    SeleniumLibrary    timeout=20s
Library    Collections
Variables    ../data/mathx_login_data.py
Test Setup    Open MathX Login
Test Teardown    Close All Browsers
Test Tags    mathx    functional    login

*** Variables ***
${LOGIN_URL}    https://mathx.vn/dang-nhap.html
${CHROME_OPTIONS}    add_argument("--headless=new");add_argument("--window-size=1440,1000")
${PLAY_SPEED}    0s
${FORM}    css:#main_box form#login_form
${IDENTIFIER}    css:#main_box form#login_form input[name="e"]
${PASSWORD}    css:#main_box form#login_form input[name="p"]
${SUBMIT}    css:#main_box form#login_form button[type="submit"]
${REJECTION_PATTERN}    (?i)(sai|không (?:đúng|chính xác|tồn tại|hợp lệ)|thất bại|invalid|incorrect|not found)

*** Test Cases ***
MX-LG-001 Login page exposes the intended main form
    [Documentation]    One main login form; identifier/password and submit visible; reset and registration links visible.
    Verify Main Form Controls

MX-LG-002 Password is masked
    [Documentation]    Input type is password; input enabled.
    Verify Password Masking

MX-LG-003 Both required fields empty
    [Documentation]    Browser blocks submission; specified field has valueMissing=true, nonempty validationMessage and focus; login URL retained.
    Verify Required Fields    ${CASES}[empty_both]

MX-LG-004 Identifier empty
    [Documentation]    Browser blocks submission; specified field has valueMissing=true, nonempty validationMessage and focus; login URL retained.
    Verify Required Fields    ${CASES}[empty_identifier]

MX-LG-005 Password empty
    [Documentation]    Browser blocks submission; specified field has valueMissing=true, nonempty validationMessage and focus; login URL retained.
    Verify Required Fields    ${CASES}[empty_password]

MX-LG-006 Email identifier entry
    [Documentation]    The typed value is preserved. This tests input handling, not authentication or account validity.
    Verify Identifier Entry    ${CASES}[email][value]

MX-LG-007 Username identifier entry
    [Documentation]    The typed value is preserved. This tests input handling, not authentication or account validity.
    Verify Identifier Entry    ${CASES}[username][value]

MX-LG-008 Phone identifier entry
    [Documentation]    The typed value is preserved. This tests input handling, not authentication or account validity.
    Verify Identifier Entry    ${CASES}[phone][value]

MX-LG-009 Unicode identifier entry
    [Documentation]    The typed value is preserved. This tests input handling, not authentication or account validity.
    Verify Identifier Entry    ${CASES}[unicode_identifier][value]

MX-LG-010 One-character identifier entry
    [Documentation]    The typed value is preserved. This tests input handling, not authentication or account validity.
    Verify Identifier Entry    ${CASES}[one_identifier][value]

MX-LG-011 256-character identifier entry
    [Documentation]    The typed value is preserved. This tests input handling, not authentication or account validity.
    Verify Identifier Entry    ${CASES}[long_identifier][value]

MX-LG-012 Special and Unicode password entry
    [Documentation]    Typed value preserved and field remains type=password. No length policy inferred.
    Verify Password Entry    ${CASES}[special_password][value]

MX-LG-013 One-character password entry
    [Documentation]    Typed value preserved and field remains type=password. No length policy inferred.
    Verify Password Entry    ${CASES}[one_password][value]

MX-LG-014 256-character password entry
    [Documentation]    Typed value preserved and field remains type=password. No length policy inferred.
    Verify Password Entry    ${CASES}[long_password][value]

MX-LG-015 Keyboard focus sequence
    [Documentation]    Focus moves to main password and then main submit button.
    Verify Keyboard Focus

MX-LG-016 Forgot password navigation
    [Documentation]    URL is https://mathx.vn/quen-mat-khau.html and destination has a visible input; do not submit reset.
    Verify Linked Form    quen-mat-khau.html

MX-LG-017 Registration navigation
    [Documentation]    URL is https://mathx.vn/dang-ky.html and destination has a visible input; do not create an account.
    Verify Linked Form    dang-ky.html

MX-LG-018 Invalid credentials rejected by button
    [Documentation]    Login form remains visible and main region shows explicit invalid-credentials feedback. No successful authentication. Exact message is TBD; proposed rejection regex is documented.
    [Tags]    server-negative
    Verify Credential Rejection    ${CASES}[invalid_button]    button

MX-LG-019 Invalid credentials rejected by Enter
    [Documentation]    Login form remains visible and main region shows explicit invalid-credentials feedback. No successful authentication. Exact message is TBD; proposed rejection regex is documented.
    [Tags]    server-negative
    Verify Credential Rejection    ${CASES}[invalid_enter]    enter

MX-LG-020 Successful login using registered email
    [Documentation]    Authenticated account identity and destination match approved expectations. TBD – Stakeholder confirmation required.
    [Tags]    requires-account
    Skip    No authorized account or approved success oracle supplied.

MX-LG-021 Successful login using registered username
    [Documentation]    Authenticated account identity and destination match approved expectations. TBD – Stakeholder confirmation required.
    [Tags]    requires-account
    Skip    No authorized account or approved success oracle supplied.

MX-LG-022 Successful login using registered phone
    [Documentation]    Authenticated account identity and destination match approved expectations. TBD – Stakeholder confirmation required.
    [Tags]    requires-account
    Skip    No authorized account or approved success oracle supplied.

*** Keywords ***
Open MathX Login
    Set Selenium Speed    ${PLAY_SPEED}
    Open Browser    ${LOGIN_URL}    chrome    options=${CHROME_OPTIONS}
    Wait Until Element Is Visible    ${FORM}    20s
    Wait Until Element Is Visible    ${IDENTIFIER}    20s
    Location Should Be    ${LOGIN_URL}

Verify Main Form Controls
    ${count}=    Get Element Count    ${FORM}
    Should Be Equal As Integers    ${count}    1
    Element Should Be Visible    ${IDENTIFIER}
    Element Should Be Enabled    ${IDENTIFIER}
    Element Should Be Visible    ${PASSWORD}
    Element Should Be Visible    ${SUBMIT}
    Element Should Be Enabled    ${SUBMIT}
    Element Should Be Visible    css:#main_box form#login_form a[href="https://mathx.vn/quen-mat-khau.html"]
    Element Should Be Visible    css:#main_box form#login_form a[href="https://mathx.vn/dang-ky.html"]

Verify Password Masking
    ${type}=    Get Element Attribute    ${PASSWORD}    type
    Should Be Equal    ${type}    password
    Element Should Be Enabled    ${PASSWORD}

Verify Required Fields
    [Arguments]    ${case}
    Input Text    ${IDENTIFIER}    ${case}[identifier]
    Input Password    ${PASSWORD}    ${case}[password]
    Click Button    ${SUBMIT}
    ${missing}=    Execute Javascript    return document.querySelector('#main_box form#login_form input[name="${case}[missing]"]').validity.valueMissing;
    Should Be True    ${missing}
    ${message}=    Execute Javascript    return document.querySelector('#main_box form#login_form input[name="${case}[missing]"]').validationMessage;
    Should Not Be Empty    ${message}
    ${focused}=    Execute Javascript    return document.activeElement.name;
    Should Be Equal    ${focused}    ${case}[missing]
    Location Should Be    ${LOGIN_URL}

Verify Identifier Entry
    [Arguments]    ${value}
    Input Text    ${IDENTIFIER}    ${value}
    ${actual}=    Get Value    ${IDENTIFIER}
    Should Be Equal As Strings    ${actual}    ${value}

Verify Password Entry
    [Arguments]    ${value}
    Input Password    ${PASSWORD}    ${value}
    ${actual}=    Get Value    ${PASSWORD}
    Should Be Equal As Strings    ${actual}    ${value}
    Verify Password Masking

Verify Keyboard Focus
    Click Element    ${IDENTIFIER}
    Press Keys    ${IDENTIFIER}    TAB
    ${name}=    Execute Javascript    return document.activeElement.name;
    Should Be Equal    ${name}    p
    Press Keys    ${PASSWORD}    TAB
    ${focused}=    Execute Javascript    return document.activeElement === document.querySelector('#main_box form#login_form button[type="submit"]');
    Should Be True    ${focused}

Verify Linked Form
    [Arguments]    ${path}
    Click Link    css:#main_box form#login_form a[href="https://mathx.vn/${path}"]
    Wait Until Location Is    https://mathx.vn/${path}    20s
    Wait Until Element Is Visible    css:#main_box input:not([type="hidden"])    20s

Verify Credential Rejection
    [Arguments]    ${case}    ${method}
    Input Text    ${IDENTIFIER}    ${case}[identifier]
    Input Password    ${PASSWORD}    ${case}[password]
    IF    $method == 'button'
        Click Button    ${SUBMIT}
    ELSE
        Press Keys    ${PASSWORD}    ENTER
    END
    Wait Until Keyword Succeeds    20s    1s    Main Region Should Show Rejection
    Element Should Be Visible    ${FORM}
    Location Should Be    ${LOGIN_URL}

Main Region Should Show Rejection
    ${message}=    Get Text    css:#main_box
    Should Match Regexp    ${message}    ${REJECTION_PATTERN}
