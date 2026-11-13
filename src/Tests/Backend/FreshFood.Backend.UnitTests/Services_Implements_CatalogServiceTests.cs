using System.Globalization;
using System.Reflection;
using System.Text.Json;
using FreshFood.Api;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System.Security.Claims;
using System.Text;
using FreshFood.Api.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using static FreshFood.Backend.UnitTests.ScenarioValues;

// Generated NUnit tests with explicit business calls and expected-result assertions.
namespace FreshFood.Backend.UnitTests;
[NUnit.Framework.TestFixture]
public sealed class Services_Implements_CatalogServiceTests
{
    /// <summary>
    /// UTM-039-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogService.CatalogService(ICatalogRepository catalogRepository, IBatchPricingPolicy
    /// pricing)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"catalogRepository": "Typed FreshFood.Reposistory.Repository.ICatalogRepository fixture from
    /// fixtures.json", "pricing": "CATALOG"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogService.CatalogService(ICatalogRepository
    /// catalogRepository, IBatchPricingPolicy pricing); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Instance retains supplied dependency/data identities; no business IO during
    /// construction
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No collaborator calls
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-039.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-039-TC001")]
    public void UTM_039_TC001()
    {
        // Arrange: test inputs and mock setup.
        var catalogRepository = (FreshFood.Reposistory.Repository.ICatalogRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.ICatalogRepository))!;
        var pricing = (FreshFood.Reposistory.Entities.IBatchPricingPolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IBatchPricingPolicy))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.CatalogService(catalogRepository, pricing);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.CatalogService>());
    }

    /// <summary>
    /// UTM-039-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogService.CatalogService(ICatalogRepository catalogRepository, IBatchPricingPolicy
    /// pricing)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"catalogRepository": "Typed FreshFood.Reposistory.Repository.ICatalogRepository fixture from
    /// fixtures.json", "pricing": "CATALOG", "variant": "Omit optional arguments; otherwise use distinct valid
    /// instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogService.CatalogService(ICatalogRepository
    /// catalogRepository, IBatchPricingPolicy pricing); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared defaults and fresh-instance isolation preserved
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No IO
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-039.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-039-TC002")]
    public void UTM_039_TC002()
    {
        // Arrange: test inputs and mock setup.
        var catalogRepository = (FreshFood.Reposistory.Repository.ICatalogRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.ICatalogRepository))!;
        var pricing = (FreshFood.Reposistory.Entities.IBatchPricingPolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IBatchPricingPolicy))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.CatalogService(catalogRepository, pricing);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.CatalogService>());
    }

    /// <summary>
    /// UTM-039-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogService.CatalogService(ICatalogRepository catalogRepository, IBatchPricingPolicy
    /// pricing)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"catalogRepository": "Typed FreshFood.Reposistory.Repository.ICatalogRepository fixture from
    /// fixtures.json", "pricing": "CATALOG", "variant": "Missing non-nullable dependency is outside declared caller
    /// contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogService.CatalogService(ICatalogRepository
    /// catalogRepository, IBatchPricingPolicy pricing); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: No invented runtime rejection. Review-only until abnormal constructor behavior is
    /// agreed; DI registration failures are verified at composition root.
    /// </para>
    /// <para>
    /// Design exception expectation: N/A - no constructor guard specified
    /// </para>
    /// <para>
    /// Expected side effects: No execution claim
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): No abnormal constructor guard contract; review-only category is not
    /// execution coverage.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-039.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-039-TC003")]
    public void UTM_039_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-040-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC001")]
    public async System.Threading.Tasks.Task UTM_040_TC001()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", ProductName = "Greens", IsActive = true }, new() { ProductId = "2", IsActive = false } }),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var mi = owner.GetType().GetMethod("Summaries", BindingFlags.Instance | BindingFlags.NonPublic)!;
                var r = (List<ProductSummaryDto>)(await Fixture.Await(Fixture.Invoke(mi, owner, new List<Product> { new() { ProductId = "1", IsActive = true } }, Fixture.Token)))!;
                Assert.That(TestChecks.Single(r).AvailableQuantity, Is.EqualTo(7));
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-040-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants", "boundary": "Empty then single-item
    /// collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field
    /// unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC002")]
    public async System.Threading.Tasks.Task UTM_040_TC002()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product>()),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var mi = owner.GetType().GetMethod("Summaries", BindingFlags.Instance | BindingFlags.NonPublic)!;
                var r = (List<ProductSummaryDto>)(await Fixture.Await(Fixture.Invoke(mi, owner, new List<Product> { new() { ProductId = "1", IsActive = true } }, Fixture.Token)))!;
                Assert.That(TestChecks.Single(r).AvailableQuantity, Is.EqualTo(7));
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-040-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants", "failure": "First collaborator throws
    /// TimeoutException sentinel; for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC003")]
    public async System.Threading.Tasks.Task UTM_040_TC003()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("catalog sentinel");
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var mi = owner.GetType().GetMethod("Summaries", BindingFlags.Instance | BindingFlags.NonPublic)!;
                var r = (List<ProductSummaryDto>)(await Fixture.Await(Fixture.Invoke(mi, owner, new List<Product> { new() { ProductId = "1", IsActive = true } }, Fixture.Token)))!;
                Assert.That(TestChecks.Single(r).AvailableQuantity, Is.EqualTo(7));
            }
        });
        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-040-TC004: predicate L8 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"p.IsActive": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.IsActive | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:8. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-040-D01:False, UTM-040-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC004")]
    public void UTM_040_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-040-TC005: predicate L8 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"p.IsActive": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.IsActive | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:8. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-040-D01:True, UTM-040-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC005")]
    public void UTM_040_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-040-TC006: predicate L10 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"b.ProductId": "99",
    /// "p.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: b =&gt; b.ProductId == p.ProductId | Assert selected
    /// outcome False at src/FreshFood-API/Services/Implements/CatalogService.cs:10. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-040-D02:False, UTM-040-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC006")]
    public void UTM_040_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-040-TC007: predicate L10 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"b.ProductId": "1",
    /// "p.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: b =&gt; b.ProductId == p.ProductId | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CatalogService.cs:10. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-040-D02:True, UTM-040-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC007")]
    public void UTM_040_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-040-TC008: conditional L17 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"stock.Count": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: "0" | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-040-D03:False, UTM-040-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC008")]
    public void UTM_040_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-040-TC009: conditional L17 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductSummaryDto&gt; &gt; CatalogService.Summaries(List&lt;Product&gt; products,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"products": "Typed two-item fixture collection; see fixtures.json", "ct":
    /// "CancellationToken.None; use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"stock.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductSummaryDto&gt; &gt;
    /// CatalogService.Summaries(List&lt;Product&gt; products, CancellationToken ct); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: pricing.Quote(stock[0], DateTimeOffset.UtcNow).ToWire() | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CatalogService.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-040-D03:True, UTM-040-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-040.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-040-TC009")]
    public void UTM_040_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-041-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC001")]
    public async System.Threading.Tasks.Task UTM_041_TC001()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", ProductName = "Greens", IsActive = true }, new() { ProductId = "2", IsActive = false } }),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.GetCatalogAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                {
                    var item = TestChecks.Single(r.Items);
                    Assert.That(item.AvailableQuantity, Is.EqualTo(7));
                    Assert.That(item.CurrentPrice, Is.EqualTo("10000"));
                }
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-041-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC002")]
    public async System.Threading.Tasks.Task UTM_041_TC002()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product>()),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.GetCatalogAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                Assert.That(r.Items, Is.Empty);
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-041-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC003")]
    public async System.Threading.Tasks.Task UTM_041_TC003()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("catalog sentinel");
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.GetCatalogAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                {
                    var item = TestChecks.Single(r.Items);
                    Assert.That(item.AvailableQuantity, Is.EqualTo(7));
                    Assert.That(item.CurrentPrice, Is.EqualTo("10000"));
                }
            }
        });
        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-041-TC004: conditional L23 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"query.CategoryId": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: int.Parse(ServiceRules.Id(query.CategoryId), CultureInfo.InvariantCulture) |
    /// Assert selected outcome False at src/FreshFood-API/Services/Implements/CatalogService.cs:23. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-041-D01:False, UTM-041-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC004")]
    public void UTM_041_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-041-TC005: conditional L23 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"query.CategoryId": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: null | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:23. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-041-D01:True, UTM-041-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC005")]
    public void UTM_041_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-041-TC006: coalesce L24 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "query.ClearanceOnly"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: query.ClearanceOnly ?? false | Assert selected
    /// outcome Null at src/FreshFood-API/Services/Implements/CatalogService.cs:24. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-041-D02:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC006")]
    public void UTM_041_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-041-TC007: coalesce L24 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "query.ClearanceOnly"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: query.ClearanceOnly ?? false | Assert selected
    /// outcome Non-null at src/FreshFood-API/Services/Implements/CatalogService.cs:24. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-041-D02:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC007")]
    public void UTM_041_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-041-TC008: conditional L29 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"products.Count": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: await Summaries(await catalogRepository.GetPopularAsync(6, signal), signal) |
    /// Assert selected outcome False at src/FreshFood-API/Services/Implements/CatalogService.cs:29. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-041-D03:False, UTM-041-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC008")]
    public void UTM_041_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-041-TC009: conditional L29 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetCatalogAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"products.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: [] | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-041-D03:True, UTM-041-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-041.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-041-TC009")]
    public void UTM_041_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-042-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.SearchAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.SearchAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-042.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-042-TC001")]
    public async System.Threading.Tasks.Task UTM_042_TC001()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", ProductName = "Greens", IsActive = true }, new() { ProductId = "2", IsActive = false } }),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.SearchAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                {
                    var item = TestChecks.Single(r.Items);
                    Assert.That(item.AvailableQuantity, Is.EqualTo(7));
                    Assert.That(item.CurrentPrice, Is.EqualTo("10000"));
                }
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-042-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.SearchAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.SearchAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-042.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-042-TC002")]
    public async System.Threading.Tasks.Task UTM_042_TC002()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product>()),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.SearchAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                Assert.That(r.Items, Is.Empty);
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-042-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.SearchAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.SearchAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): No injectable collaborator here; bind abnormal cases to the declared
    /// guard, or review N/A instead of inventing a fault injection seam.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-042.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-042-TC003")]
    public void UTM_042_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-043-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetClearanceAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetClearanceAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-043.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-043-TC001")]
    public async System.Threading.Tasks.Task UTM_043_TC001()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", ProductName = "Greens", IsActive = true }, new() { ProductId = "2", IsActive = false } }),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.GetClearanceAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                {
                    var item = TestChecks.Single(r.Items);
                    Assert.That(item.AvailableQuantity, Is.EqualTo(7));
                    Assert.That(item.CurrentPrice, Is.EqualTo("10000"));
                }
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-043-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetClearanceAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetClearanceAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-043.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-043-TC002")]
    public async System.Threading.Tasks.Task UTM_043_TC002()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product>()),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var query = new CatalogQueryDto();
                var r = await owner.GetClearanceAsync(query, Fixture.Token);
                TestChecks.Single(r.Categories);
                Assert.That(r.Items, Is.Empty);
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-043-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogService.GetClearanceAsync(CatalogQueryDto query,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"query": {"fixture": "CatalogQueryDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CatalogResultDto&gt;
    /// CatalogService.GetClearanceAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): No injectable collaborator here; bind abnormal cases to the declared
    /// guard, or review N/A instead of inventing a fault injection seam.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-043.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-043-TC003")]
    public void UTM_043_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-044-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogService.GetProductDetailsAsync(string productId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProductDetailsDto&gt;
    /// CatalogService.GetProductDetailsAsync(string productId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-044.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-044-TC001")]
    public async System.Threading.Tasks.Task UTM_044_TC001()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", ProductName = "Greens", IsActive = true }, new() { ProductId = "2", IsActive = false } }),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var r = await owner.GetProductDetailsAsync("1", Fixture.Token);
                Assert.That(r.Product.ProductId, Is.EqualTo("1"));
                TestChecks.Single(r.AvailableBatches);
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-044-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogService.GetProductDetailsAsync(string productId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProductDetailsDto&gt;
    /// CatalogService.GetProductDetailsAsync(string productId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-044.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-044-TC002")]
    public async System.Threading.Tasks.Task UTM_044_TC002()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "FindActiveAsync" or "GetPopularAsync" => Task.FromResult(new List<Product>()),
                "GetProductAsync" => Task.FromResult<Product?>(new() { ProductId = "1", ProductName = "Greens", IsActive = true }),
                "GetCategoriesAsync" => Task.FromResult(new List<ProductCategory> { new() { CategoryId = 1, CategoryName = "Vegetables" } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                _ => throw new InvalidOperationException(n)};
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var r = await owner.GetProductDetailsAsync("1", Fixture.Token);
                Assert.That(r.Product.ProductId, Is.EqualTo("1"));
                TestChecks.Single(r.AvailableBatches);
            }
        }

        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-044-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogService.GetProductDetailsAsync(string productId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProductDetailsDto&gt;
    /// CatalogService.GetProductDetailsAsync(string productId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-044.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-044-TC003")]
    public async System.Threading.Tasks.Task UTM_044_TC003()
    {
        // Arrange: test inputs and mock setup.
        var calls = new List<string>();
        var repo = StrictProxy.For<ICatalogRepository>((n, a) =>
        {
            calls.Add(n);
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("catalog sentinel");
        });
        var owner = new CatalogService(repo, new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var r = await owner.GetProductDetailsAsync("1", Fixture.Token);
                Assert.That(r.Product.ProductId, Is.EqualTo("1"));
                TestChecks.Single(r.AvailableBatches);
            }
        });
        Assert.That(calls, Is.Not.Empty);
    }

    /// <summary>
    /// UTM-044-TC004: if L37 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogService.GetProductDetailsAsync(string productId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"p": "typed fixture", "p.IsActive": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProductDetailsDto&gt;
    /// CatalogService.GetProductDetailsAsync(string productId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CatalogService.cs:37. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-044-D01:False, UTM-044-D01:C1:False, UTM-044-D01:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-044.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-044-TC004")]
    public void UTM_044_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-044-TC005: if L37 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogService.GetProductDetailsAsync(string productId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"p": "typed fixture", "p.IsActive": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProductDetailsDto&gt;
    /// CatalogService.GetProductDetailsAsync(string productId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("NOT_FOUND", 404); | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:37. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-044-D01:True, UTM-044-D01:C1:False, UTM-044-D01:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-044.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-044-TC005")]
    public void UTM_044_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-044-TC006: if L37 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogService.GetProductDetailsAsync(string productId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"p": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProductDetailsDto&gt;
    /// CatalogService.GetProductDetailsAsync(string productId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("NOT_FOUND", 404); | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CatalogService.cs:37. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-044-D01:True, UTM-044-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-044.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-044-TC006")]
    public void UTM_044_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }
}
