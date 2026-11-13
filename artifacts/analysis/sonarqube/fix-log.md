# Sonar Remediation Execution Log

Date: 2026-11-04 | Scope: all 18 original issues | Authority: explicit stakeholder instruction.

## Result

All 18 original issue keys are FIXED on SonarCloud. No issue suppression or manual server-side closure was used. Release build: 0 errors, 0 warnings. Tests: 67 passed, 0 failed, 0 skipped. Open issues: 0. Coverage: 73.2%. Quality Gate remains ERROR solely because coverage is below 80%.

## Execution history

1. Preserved pre-batch report, metrics, issue list and defect workbook.
2. Applied code fixes grouped by security regex, DTO presence/defaults, webhook binding, async host and test allocation recommendations.
3. Added HTTP raw-webhook, required numeric input, optional-filter and phone-boundary regression tests.
4. Release build and all 67 tests passed; static analysis build produced 0 warnings and 0 errors.
5. Completed SonarCloud scan and verified all original issue keys FIXED.
6. Rechecked PIM source refinements; 347 logical operation mappings retained; raw-body adapter and optional flags documented.
7. Recorded remaining coverage gate failure without changing its threshold.

## Issue-by-issue change log

| ID | Rule | Source location at detection | Implemented change | Server result |
|---|---|---|---|---|
| SQ-001 | csharpsquid:S6444 | src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:9 | Set a 100 ms timeout on enum-to-SQL-name regex replacement; retain existing casing and VIETQR encoding. | FIXED |
| SQ-002 | csharpsquid:S6964 | src/FreshFood-API/DTOs/AddressInputDto.cs:9 | Use nullable IsDefault transport input and explicitly default to false in ProfileService; preserve optional-field behavior. | FIXED |
| SQ-003 | csharpsquid:S6964 | src/FreshFood-API/DTOs/CatalogQueryDto.cs:7 | Use nullable ClearanceOnly transport input and explicitly default to false in CatalogService; preserve optional filtering. | FIXED |
| SQ-004 | csharpsquid:S6964 | src/FreshFood-API/DTOs/CartChangeDto.cs:6 | Mark Quantity with JsonRequired so omitted JSON cannot silently become zero; preserve existing quantity validation. | FIXED |
| SQ-005 | csharpsquid:S6964 | src/FreshFood-API/DTOs/OrderReviewDto.cs:6 | Mark Rating with JsonRequired so omitted JSON cannot silently become zero; preserve existing rating validation. | FIXED |
| SQ-006 | csharpsquid:S6966 | src/FreshFood-API/Program.cs:49 | Await app.RunAsync instead of synchronously running the web host. | FIXED |
| SQ-007 | csharpsquid:S2092 | src/FreshFood-API/Services/Implements/CurrentCustomer.cs:25 | Set guest-cart cookie Secure=true unconditionally; preserve HttpOnly, SameSite.Strict and data protection. | FIXED |
| SQ-008 | csharpsquid:S6932 | src/FreshFood-API/Controllers/PaymentWebhookController.cs:12 | Bind PaymentNoticeDto through PaymentNoticeModelBinder, retaining exact raw body text and verification headers; controller delegates unchanged. | FIXED |
| SQ-009 | csharpsquid:S6444 | src/FreshFood-API/Services/Implements/ProfileService.cs:15 | Use a 100 ms timeout for the unchanged email regex; map RegexMatchTimeoutException to INVALID_EMAIL before transaction or writes. | FIXED |
| SQ-010 | csharpsquid:S6444 | src/FreshFood-API/Services/Implements/ProfileService.cs:29 | Use a 100 ms phone regex timeout; map timeout to INVALID_PHONE before geocoding, transaction or persistence. | FIXED |
| SQ-011 | csharpsquid:S6444 | src/FreshFood-API/Services/Implements/OrderStateMachine.cs:19 | Set a 100 ms timeout on state-name normalization; retain the single table-driven OrderStateMachine and stable transition IDs. | FIXED |
| SQ-012 | external_roslyn:CA1861 | src/FreshFood-API.Tests/BackendTests.cs:141 | Reuse a static readonly expected transition array in the existing test. | FIXED |
| SQ-013 | external_roslyn:CA1869 | src/FreshFood-API.Tests/DesignMappingTests.cs:43 | Reuse a static readonly JsonSerializerOptions instance in design-mapping serialization. | FIXED |
| SQ-014 | external_roslyn:ASP0027 | src/FreshFood-API/Program.cs:51 | Remove the redundant partial Program declaration under ASP.NET Core 10; HTTP integration tests verify generated Program accessibility. | FIXED |
| SQ-015 | external_roslyn:SYSLIB1045 | src/FreshFood-API/Services/Implements/OrderStateMachine.cs:19 | The bounded-time regex overload removes the GeneratedRegex recommendation; no independent state-machine refactor or suppression. | FIXED |
| SQ-016 | external_roslyn:SYSLIB1045 | src/FreshFood-API/Services/Implements/ProfileService.cs:15 | No independent GeneratedRegex refactor. The bounded-time overload introduced for SQ-009 also removes this analyzer recommendation. | FIXED |
| SQ-017 | external_roslyn:SYSLIB1045 | src/FreshFood-API/Services/Implements/ProfileService.cs:29 | The bounded-time phone regex overload removes the GeneratedRegex recommendation; no change to the accepted phone pattern. | FIXED |
| SQ-018 | external_roslyn:SYSLIB1045 | src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:9 | The bounded-time SQL-name regex overload removes the GeneratedRegex recommendation; no SQL encoding change. | FIXED |

## Evidence

- Current analysis: `af077057-bbb6-4582-88a8-8b5300225c8f`.
- `review.json`: complete findings, source hashes and execution history.
- `all-issues-server-verification.json`: original issue statuses from SonarCloud.
- `SonarCloud_Defect_Log.xlsx`: existing approved defect-log format.
- `build-analysis.txt`, `test-coverage.txt`, `coverage.xml`, `quality-gate.json`: verification evidence.

Existing deferred payment/provider integrations and business-policy TBDs remain explicit. This remediation does not claim release readiness or exhaustive branch coverage.
