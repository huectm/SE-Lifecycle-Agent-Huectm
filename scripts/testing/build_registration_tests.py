import csv,json
from pathlib import Path
root=Path(__file__).resolve().parents[2]
cases=[]
def add(title,field='',value='',expected='success',basis='Observed UI',technique='EP',flow='Basic'):
 i=f'REG-{len(cases)+1:03}'
 cases.append(dict(id=i,title=title,field=field,value=value,expected=expected,basis=basis,technique=technique,flow=flow))
add('Register with default Newsletter No')
add('Register with Newsletter Yes','newsletter','1',flow='Alt1.1')
for field,lo,hi,msg in [('firstname',1,32,'First Name must'),('lastname',1,32,'Last Name must'),('telephone',3,32,'Telephone must'),('password',4,20,'Password must')]:
 for n in sorted(set([0,lo-1,lo,lo+1,hi-1,hi,hi+1])):
  add(f'{field} length {n}',field,('7' if field=='telephone' else 'A')*n,msg if n<lo or n>hi else 'success',technique='BVA',flow='E1' if n<lo or n>hi else 'Basic')
for value in ['', 'plainaddress','a@','@example.com','a b@example.com']:
 add(f'Invalid email {value!r}','email',value,'email-invalid',flow='E2')
for value in ['', 'Different123!']:
 add('Confirmation empty or mismatch','confirm',value,'Password confirmation does not match',basis='UC-REG-01 BR-02',flow='E3')
add('Privacy not accepted','agree','0','You must agree to the Privacy Policy',basis='UC-REG-01 BR-03',flow='E4')
add('Previously registered email','duplicate','','already registered',flow='E5')
add('Login page link','login','','login',basis='UC-REG-01 Alt1.2',flow='Alt1.2')
add('Privacy policy dialog','policy','','policy',flow='UI')
for field,n in [('firstname',20),('firstname',21),('lastname',10),('lastname',11)]:
 add(f'Proposed UC {field} maximum boundary {n}',field,'A'*n,'success' if n in [20,10] else 'reject',basis='UC proposal; confirmation required',technique='BVA',flow='Appendix')
for password in ['Abc12!x','Abc12!xy','abc12!xy','ABC12!XY','Abcdef!x','Abc123xy']:
 add('Proposed UC password composition '+password,'password',password,'success' if password=='Abc12!xy' else 'reject',basis='UC proposal; confirmation required',technique='BVA/EP',flow='Appendix')
for field in ['firstname','lastname']:
 add('Whitespace-only '+field,field,'   ','reject',basis='UC proposal; confirmation required',flow='Appendix')
add('Network/system failure recovery','network','','blocked',basis='UC E6; controlled fault environment required',flow='E6')
for field,value in [('firstname','A'*19),('lastname','A'*9),('password','Abc123!xy')]:
 add('Proposed UC adjacent valid boundary '+field,field,value,'success',basis='UC proposal; confirmation required',technique='BVA',flow='Appendix')
p=root/'tests/data/tutorialsninja_register.csv'
with p.open('w',newline='',encoding='utf-8') as f:
 w=csv.DictWriter(f,fieldnames=list(cases[0]));w.writeheader();w.writerows(cases)
settings='''*** Settings ***
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
'''
for c in cases:
 settings+=f"{c['id']} {c['title']}\n    {c['id']}\n"
settings+='''
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
'''
(root/'tests/functional/tutorialsninja_register.robot').write_text(settings,encoding='utf-8')
print('Generated',len(cases),'cases')



