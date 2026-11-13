# View Layer Package Consistency Review

Date: 2026-10-31 | Status: User-directed design correction; baseline approval pending.

Source: artifacts/diagrams/architecture/freshfood-package-diagram.drawio. Customer Web packages are Pages and CallService. Staff Web has the same package split but is outside these five customer use cases. Mobile remains Views, ViewModels and Models; it is not collapsed into the two Web packages.

The previous class package already contained frontend classifiers on a combined last page, but lacked explicit package compartments and complete UI event responsibilities. The full VOPC realization is page 1; Web detail is page 2 and Mobile detail is page 3. Following the latest stakeholder correction, package frames/labels are removed from detailed class diagrams; this document preserves architecture ownership only.

| Use case | Pages | Concrete CallService class |
|---|---|---|
| UC-C01 | CatalogPage | CatalogApiClient |
| UC-C03 | CartPage | CartApiClient |
| UC-C05 | ProfilePage | ProfileApiClient |
| UC-C06 | CheckoutPage | CheckoutApiClient |
| UC-C07 | MyOrdersPage | MyOrdersApiClient |

Pages own rendering, current UI state, validation-display feedback and interaction events. Pages hold ordinary references to concrete CallService classes. Frontend DI interfaces and injected constructors have been removed. CallService implementations own authenticated HTTPS/JSON exchange and serialization. Pages have no direct server service, controller, database, payment verification or refund-policy dependency.

Web operations use Promise; Mobile operations use Future; Node backend operations use Promise/AbortSignal. UML Page classifiers denote React component responsibilities; frontend classes use ordinary object/module/widget lifecycle, without dependency injection. Only backend constructors receive abstractions from the DI container. DTO names are client-local wire projections, not cross-runtime backend type imports.

The existing canonical package master and all 24 state-transition class mappings remain unchanged. Detailed class specifications, analysis-to-design mapping, registration matrix and page index are regenerated from the corrected model. Stable RTM design IDs still point to the same editable masters. No implementation or new business requirement was introduced.
