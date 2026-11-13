*** Settings ***
Documentation    DRAFT - Awaiting test design approval. Dantri article-detail functional tests.
Library    SeleniumLibrary    timeout=20s
Variables    ../data/dantri_article_data.py
Test Setup    Open Browser    https://dantri.com.vn/    chrome
Test Teardown    Close All Browsers
Test Tags    dantri    functional    article-detail

*** Test Cases ***
DT-001 Open Entertainment Article From Homepage
    Verify Article Detail    ${CASES}[0]

DT-002 Open Business Article From Homepage
    Verify Article Detail    ${CASES}[1]

DT-003 Open World Article From Homepage
    Verify Article Detail    ${CASES}[2]

*** Keywords ***
Verify Article Detail
    [Arguments]    ${case}
    ${link}=    Set Variable    xpath=(//h3//a[@data-prop="title" and @href="${case}[url]"])[1]
    Wait Until Element Is Visible    ${link}    20s    DATA_STALE_OR_PAGE_CHANGED: snapshot article is not visible on homepage.
    ${listing_title}=    Get Text    ${link}
    Should Be Equal As Strings    ${listing_title}    ${case}[title]    collapse_spaces=${True}
    Click Element    ${link}
    Wait Until Element Is Visible    css:h1    20s
    Location Should Be    ${case}[url]
    ${detail_title}=    Get Text    css:h1
    Should Be Equal As Strings    ${detail_title}    ${case}[title]    collapse_spaces=${True}
    ${body}=    Set Variable    xpath=(//article[.//p]//p[normalize-space()])[1]
    Wait Until Element Is Visible    ${body}    20s
    ${body_text}=    Get Text    ${body}
    Should Not Be Empty    ${body_text}
