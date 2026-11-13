# Architecture Diagram Naming Consistency Review

Date: 2026-10-27
Scope: User-directed naming alignment across the High-Level Architecture, System Context, Component and Package diagrams. Existing design approval statuses are retained.

## Canonical names

| Element | Canonical display name | Notes |
|---|---|---|
| Whole system | FreshFood E-Commerce Platform | Context process and architecture boundary; diagram titles use FreshFood as the short system name. |
| Customer browser subsystem | FreshFood-Customer-Web | Same name in Architecture, Component and Package views. |
| Staff browser subsystem | FreshFood-Web | Same name in Architecture, Component and Package views. |
| Customer mobile subsystem | FreshFood-App | Same name in Architecture, Component and Package views. |
| API subsystem / business component | FreshFood-API | Same name in Architecture, Component and Package views. |
| Internal data-access component | FreshFood.Reposistory | Same name in Component and Package views; owned by FreshFood-API. |
| Database | FreshFood-DB | Architecture view only; excluded from software-only Component view. |
| Maps service | Google Maps | Capability details remain on a separate description line. |
| SMS service | SMS Gateway | Architecture retains SpeedSMS; Context retains the original operator descriptions. |
| Authentication service | OAuth 2.0 Providers | Architecture retains Google implementation details; Context retains Google / Facebook source labels. |
| Payment service | SePay | VietQR / banking capability remains in the description. |
| Printer device | Thermal Printer | Receipt / packing and ESC/POS details remain in the description. |
| Push service | Firebase FCM | Retained in Architecture; this naming edit does not add a new Context flow. |

## Verification and impact

Only display labels and diagram titles changed. Stable XML IDs, node geometry, connector geometry, flow values and source/target relationships were checked unchanged. Internal subsystem/component names already matched and were retained. All four editable drawio masters were saved before re-exporting their PNGs. View-specific stereotypes, interface names and package names remain unchanged.

Provider differences remain visible instead of inferring a provider replacement: Google versus Google / Facebook, and SpeedSMS versus mobile network operator descriptions. No provider choice or scope change is approved by this naming revision.

Master Specification embedded figures retain their previous approved versions pending review of the revised diagram package. This naming revision does not approve the draft Package Diagram or the full Architecture Baseline.


## User-directed component rename - 2026-10-27

The stakeholder explicitly renamed `FreshFood-API.DataAccess` to `FreshFood.Reposistory` (spelling retained exactly as requested). The current Component and Package diagram labels, including the Entity ownership note, use `FreshFood.Reposistory`. Earlier names in this document describe the previous revision. Component identity, existing diagram IDs, library role, IDataAccess contract, package allocation, dependencies and behavior are unchanged. The confirmed name is an explicit exception to the default parent-qualified naming convention; it does not introduce another subsystem. The complete Package Diagram retains its pending-review status.
