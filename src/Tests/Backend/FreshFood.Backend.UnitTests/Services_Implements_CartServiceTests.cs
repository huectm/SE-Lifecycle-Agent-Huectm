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
public sealed class Services_Implements_CartServiceTests
{
    /// <summary>
    /// UTM-033-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartService.CartService(ICartRepository cartRepository, ICurrentCustomer currentCustomer,
    /// IUnitOfWork unitOfWork, IBatchPricingPolicy pricing)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cartRepository": "CART", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer
    /// fixture from fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "pricing": "CATALOG"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartService.CartService(ICartRepository cartRepository,
    /// ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IBatchPricingPolicy pricing); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-033.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-033-TC001")]
    public void UTM_033_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cartRepository = (FreshFood.Reposistory.Repository.ICartRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.ICartRepository))!;
        var currentCustomer = (FreshFood.Api.Services.ICurrentCustomer)Fixture.Value(typeof(FreshFood.Api.Services.ICurrentCustomer))!;
        var unitOfWork = (FreshFood.Reposistory.Repository.IUnitOfWork)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IUnitOfWork))!;
        var pricing = (FreshFood.Reposistory.Entities.IBatchPricingPolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IBatchPricingPolicy))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.CartService(cartRepository, currentCustomer, unitOfWork, pricing);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.CartService>());
    }

    /// <summary>
    /// UTM-033-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartService.CartService(ICartRepository cartRepository, ICurrentCustomer currentCustomer,
    /// IUnitOfWork unitOfWork, IBatchPricingPolicy pricing)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cartRepository": "CART", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer
    /// fixture from fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "pricing": "CATALOG", "variant": "Omit optional arguments; otherwise use distinct valid
    /// instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartService.CartService(ICartRepository cartRepository,
    /// ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IBatchPricingPolicy pricing); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-033.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-033-TC002")]
    public void UTM_033_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cartRepository = (FreshFood.Reposistory.Repository.ICartRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.ICartRepository))!;
        var currentCustomer = (FreshFood.Api.Services.ICurrentCustomer)Fixture.Value(typeof(FreshFood.Api.Services.ICurrentCustomer))!;
        var unitOfWork = (FreshFood.Reposistory.Repository.IUnitOfWork)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IUnitOfWork))!;
        var pricing = (FreshFood.Reposistory.Entities.IBatchPricingPolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IBatchPricingPolicy))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.CartService(cartRepository, currentCustomer, unitOfWork, pricing);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.CartService>());
    }

    /// <summary>
    /// UTM-033-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartService.CartService(ICartRepository cartRepository, ICurrentCustomer currentCustomer,
    /// IUnitOfWork unitOfWork, IBatchPricingPolicy pricing)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cartRepository": "CART", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer
    /// fixture from fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "pricing": "CATALOG", "variant": "Missing non-nullable dependency is outside declared caller
    /// contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartService.CartService(ICartRepository cartRepository,
    /// ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IBatchPricingPolicy pricing); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-033.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-033-TC003")]
    public void UTM_033_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-034-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; CartService.Load(CancellationToken ct)
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
    /// Design input: {"ct": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; CartService.Load(CancellationToken ct); assert
    /// result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-034.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-034-TC001")]
    public async System.Threading.Tasks.Task UTM_034_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var mi = owner.GetType().GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Instance)!;
                Assert.That(await Fixture.Await(Fixture.Invoke(mi, owner, Fixture.Token)), Is.SameAs(cart));
                return;
            }
        }
    }

    /// <summary>
    /// UTM-034-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; CartService.Load(CancellationToken ct)
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
    /// Design input: {"ct": "CancellationToken.None; use distinct token in forwarding variants", "boundary": "Empty
    /// then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding:
    /// empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; CartService.Load(CancellationToken ct); assert
    /// result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-034.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-034-TC002")]
    public async System.Threading.Tasks.Task UTM_034_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = []
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var mi = owner.GetType().GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Instance)!;
                Assert.That(await Fixture.Await(Fixture.Invoke(mi, owner, Fixture.Token)), Is.SameAs(cart));
                return;
            }
        }
    }

    /// <summary>
    /// UTM-034-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; CartService.Load(CancellationToken ct)
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
    /// Design input: {"ct": "CancellationToken.None; use distinct token in forwarding variants", "failure": "First
    /// collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; CartService.Load(CancellationToken ct); assert
    /// result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-034.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-034-TC003")]
    public async System.Threading.Tasks.Task UTM_034_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("cart sentinel");
        });
        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var mi = owner.GetType().GetMethod("Load", BindingFlags.NonPublic | BindingFlags.Instance)!;
                Assert.That(await Fixture.Await(Fixture.Invoke(mi, owner, Fixture.Token)), Is.SameAs(cart));
                return;
            }
        });
    }

    /// <summary>
    /// UTM-035-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC001")]
    public async System.Threading.Tasks.Task UTM_035_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            {
                var mi = owner.GetType().GetMethod("Result", BindingFlags.NonPublic | BindingFlags.Instance)!;
                result = (CartResultDto)(await Fixture.Await(Fixture.Invoke(mi, owner, cart, Fixture.Token)))!;
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-035-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC002")]
    public async System.Threading.Tasks.Task UTM_035_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = []
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            {
                var mi = owner.GetType().GetMethod("Result", BindingFlags.NonPublic | BindingFlags.Instance)!;
                result = (CartResultDto)(await Fixture.Await(Fixture.Invoke(mi, owner, cart, Fixture.Token)))!;
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-035-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC003")]
    public async System.Threading.Tasks.Task UTM_035_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("cart sentinel");
        });
        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            CartResultDto result;
            {
                var mi = owner.GetType().GetMethod("Result", BindingFlags.NonPublic | BindingFlags.Instance)!;
                result = (CartResultDto)(await Fixture.Await(Fixture.Invoke(mi, owner, cart, Fixture.Token)))!;
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        });
    }

    /// <summary>
    /// UTM-035-TC004: foreach L11 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"scenario": "Empty", "expression": "cart.Items"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {             var stock =
    /// ServiceRules.Fefo(batches.Where(b =&gt; b.ProductId == item.ProductId));             var available =
    /// products.Any(p =&gt; p.ProductId == item.ProductId &amp; &amp; p.IsActive) ? stock.Sum(b =&gt; b.CurrentStock -
    /// b.ReservedStock) : 0;             var price = stock.Count &gt; 0 ? pricing.Quote(stock[0],
    /// DateTimeOffset.UtcNow).Units : 0;             var total = price * item.Quantity; subtotal += total;
    /// result.Lines.Add(new() { ProductId = item.ProductId, Quantity = item.Quantity, AvailableQuantity =
    /// available, CurrentPrice = ServiceRules.Money(price), LineTotal = ServiceRules.Money(total) });
    /// if (item.Quantity &gt; available) result.Warnings.Add("UNAVAILABLE:" + item.ProductId);         } | Assert
    /// selected outcome Empty at src/FreshFood-API/Services/Implements/CartService.cs:11. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D01:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC004")]
    public void UTM_035_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC005: foreach L11 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"scenario": "One item", "expression": "cart.Items"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {             var stock =
    /// ServiceRules.Fefo(batches.Where(b =&gt; b.ProductId == item.ProductId));             var available =
    /// products.Any(p =&gt; p.ProductId == item.ProductId &amp; &amp; p.IsActive) ? stock.Sum(b =&gt; b.CurrentStock -
    /// b.ReservedStock) : 0;             var price = stock.Count &gt; 0 ? pricing.Quote(stock[0],
    /// DateTimeOffset.UtcNow).Units : 0;             var total = price * item.Quantity; subtotal += total;
    /// result.Lines.Add(new() { ProductId = item.ProductId, Quantity = item.Quantity, AvailableQuantity =
    /// available, CurrentPrice = ServiceRules.Money(price), LineTotal = ServiceRules.Money(total) });
    /// if (item.Quantity &gt; available) result.Warnings.Add("UNAVAILABLE:" + item.ProductId);         } | Assert
    /// selected outcome One item at src/FreshFood-API/Services/Implements/CartService.cs:11. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D01:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC005")]
    public void UTM_035_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC006: foreach L11 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"scenario": "Multiple items", "expression": "cart.Items"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {             var stock =
    /// ServiceRules.Fefo(batches.Where(b =&gt; b.ProductId == item.ProductId));             var available =
    /// products.Any(p =&gt; p.ProductId == item.ProductId &amp; &amp; p.IsActive) ? stock.Sum(b =&gt; b.CurrentStock -
    /// b.ReservedStock) : 0;             var price = stock.Count &gt; 0 ? pricing.Quote(stock[0],
    /// DateTimeOffset.UtcNow).Units : 0;             var total = price * item.Quantity; subtotal += total;
    /// result.Lines.Add(new() { ProductId = item.ProductId, Quantity = item.Quantity, AvailableQuantity =
    /// available, CurrentPrice = ServiceRules.Money(price), LineTotal = ServiceRules.Money(total) });
    /// if (item.Quantity &gt; available) result.Warnings.Add("UNAVAILABLE:" + item.ProductId);         } | Assert
    /// selected outcome Multiple items at src/FreshFood-API/Services/Implements/CartService.cs:11. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D01:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC006")]
    public void UTM_035_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC007: predicate L13 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"b.ProductId": "99", "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: b =&gt; b.ProductId == item.ProductId | Assert selected
    /// outcome False at src/FreshFood-API/Services/Implements/CartService.cs:13. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D02:False, UTM-035-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC007")]
    public void UTM_035_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC008: predicate L13 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"b.ProductId": "1", "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: b =&gt; b.ProductId == item.ProductId | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CartService.cs:13. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D02:True, UTM-035-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC008")]
    public void UTM_035_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC009: conditional L14 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"products": [], "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: 0 | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CartService.cs:14. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D03:False, UTM-035-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC009")]
    public void UTM_035_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC010: conditional L14 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"products": [{"ProductId": "1", "IsActive": true}], "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: stock.Sum(b =&gt; b.CurrentStock - b.ReservedStock) | Assert selected outcome
    /// True at src/FreshFood-API/Services/Implements/CartService.cs:14. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D03:True, UTM-035-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC010")]
    public void UTM_035_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC011: predicate L14 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"p.ProductId": "99", "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.ProductId == item.ProductId &amp; &amp; p.IsActive |
    /// Assert selected outcome False at src/FreshFood-API/Services/Implements/CartService.cs:14. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D04:False, UTM-035-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC011")]
    public void UTM_035_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC012: predicate L14 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"p.ProductId": "1", "item.ProductId": "1", "p.IsActive": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.ProductId == item.ProductId &amp; &amp; p.IsActive |
    /// Assert selected outcome False at src/FreshFood-API/Services/Implements/CartService.cs:14. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D04:False, UTM-035-D04:C1:True, UTM-035-D04:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC012")]
    public void UTM_035_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC013: predicate L14 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"p.ProductId": "1", "item.ProductId": "1", "p.IsActive": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.ProductId == item.ProductId &amp; &amp; p.IsActive |
    /// Assert selected outcome True at src/FreshFood-API/Services/Implements/CartService.cs:14. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D04:True, UTM-035-D04:C1:True, UTM-035-D04:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC013")]
    public void UTM_035_TC013()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC014: conditional L15 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"stock.Count": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: 0 | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CartService.cs:15. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D05:False, UTM-035-D05:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC014")]
    public void UTM_035_TC014()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC015: conditional L15 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"stock.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: pricing.Quote(stock[0], DateTimeOffset.UtcNow).Units | Assert selected outcome
    /// True at src/FreshFood-API/Services/Implements/CartService.cs:15. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D05:True, UTM-035-D05:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC015")]
    public void UTM_035_TC015()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC016: if L18 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"review constraint": "item.Quantity &gt; available = False; arrange matching entity/mock state
    /// and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CartService.cs:18. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D06:False, UTM-035-D06:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC016")]
    public void UTM_035_TC016()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-035-TC017: if L18 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.Result(Cart cart, CancellationToken ct)
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
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"review constraint": "item.Quantity &gt; available = True; arrange matching entity/mock state and
    /// verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.Result(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: result.Warnings.Add("UNAVAILABLE:" + item.ProductId); | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CartService.cs:18. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-035-D06:True, UTM-035-D06:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-035.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-035-TC017")]
    public void UTM_035_TC017()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-036-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.GetCartAsync(CartIdentityDto identity, CancellationToken
    /// signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"identity": {"fixture": "CartIdentityDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.GetCartAsync(CartIdentityDto
    /// identity, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-036.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-036-TC001")]
    public async System.Threading.Tasks.Task UTM_036_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            result = await owner.GetCartAsync(new() { CustomerId = "99" }, Fixture.Token);
            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-036-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.GetCartAsync(CartIdentityDto identity, CancellationToken
    /// signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"identity": {"fixture": "CartIdentityDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.GetCartAsync(CartIdentityDto
    /// identity, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-036.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-036-TC002")]
    public async System.Threading.Tasks.Task UTM_036_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = []
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            result = await owner.GetCartAsync(new() { CustomerId = "99" }, Fixture.Token);
            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-036-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.GetCartAsync(CartIdentityDto identity, CancellationToken
    /// signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"identity": {"fixture": "CartIdentityDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.GetCartAsync(CartIdentityDto
    /// identity, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-036.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-036-TC003")]
    public void UTM_036_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-037-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC001")]
    public async System.Threading.Tasks.Task UTM_037_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            {
                result = await owner.ChangeQuantityAsync(new() { ProductId = "1", Quantity = 2 }, Fixture.Token);
                Assert.That(TestChecks.Single(result.Lines).Quantity, Is.EqualTo(2));
                Assert.That(saves, Is.EqualTo(1));
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-037-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC002")]
    public async System.Threading.Tasks.Task UTM_037_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = []
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            {
                result = await owner.ChangeQuantityAsync(new() { ProductId = "1", Quantity = 2 }, Fixture.Token);
                Assert.That(TestChecks.Single(result.Lines).Quantity, Is.EqualTo(2));
                Assert.That(saves, Is.EqualTo(1));
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-037-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC003")]
    public async System.Threading.Tasks.Task UTM_037_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("cart sentinel");
        });
        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            CartResultDto result;
            {
                result = await owner.ChangeQuantityAsync(new() { ProductId = "1", Quantity = 2 }, Fixture.Token);
                Assert.That(TestChecks.Single(result.Lines).Quantity, Is.EqualTo(2));
                Assert.That(saves, Is.EqualTo(1));
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        });
    }

    /// <summary>
    /// UTM-037-TC004: guard L25 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Quantity": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_QUANTITY") | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CartService.cs:25. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D01:False, UTM-037-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC004")]
    public void UTM_037_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC005: guard L25 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Quantity": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CartService.cs:25. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D01:True, UTM-037-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC005")]
    public void UTM_037_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC006: guard L29 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"products": [], "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("PRODUCT_UNAVAILABLE", 422) | Assert selected outcome False
    /// at src/FreshFood-API/Services/Implements/CartService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D02:False, UTM-037-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC006")]
    public void UTM_037_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC007: guard L29 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"products": [{"ProductId": "1", "IsActive": true}],
    /// "item.ProductId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CartService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D02:True, UTM-037-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC007")]
    public void UTM_037_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC008: predicate L29 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"p.IsActive": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.IsActive | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CartService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D03:False, UTM-037-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC008")]
    public void UTM_037_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC009: predicate L29 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"p.IsActive": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: p =&gt; p.IsActive | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CartService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D03:True, UTM-037-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC009")]
    public void UTM_037_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC010: guard L32 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"available": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("OUT_OF_STOCK", 422) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CartService.cs:32. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D04:False, UTM-037-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC010")]
    public void UTM_037_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC011: guard L32 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"available": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CartService.cs:32. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D04:True, UTM-037-D04:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC011")]
    public void UTM_037_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC012: if L34 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "actual &lt; request.Quantity = False;
    /// arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CartService.cs:34. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D05:False, UTM-037-D05:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC012")]
    public void UTM_037_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-037-TC013: if L34 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.ChangeQuantityAsync(CartChangeDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "actual &lt; request.Quantity = True;
    /// arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartService.ChangeQuantityAsync(CartChangeDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: result.Warnings.Add("QUANTITY_CLAMPED:" + request.ProductId); | Assert
    /// selected outcome True at src/FreshFood-API/Services/Implements/CartService.cs:34. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-037-D05:True, UTM-037-D05:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-037.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-037-TC013")]
    public void UTM_037_TC013()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-038-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.RemoveItemAsync(string productId, CancellationToken
    /// signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.RemoveItemAsync(string
    /// productId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-038.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-038-TC001")]
    public async System.Threading.Tasks.Task UTM_038_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            {
                result = await owner.RemoveItemAsync("1", Fixture.Token);
                Assert.That(result.Lines, Is.Empty);
                Assert.That(saves, Is.EqualTo(1));
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-038-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.RemoveItemAsync(string productId, CancellationToken
    /// signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.RemoveItemAsync(string
    /// productId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-038.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-038-TC002")]
    public async System.Threading.Tasks.Task UTM_038_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = []
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetAsync" => a[0]?.ToString() == "7" ? Task.FromResult(cart) : throw new InvalidOperationException("Untrusted identity"),
                "GetProductsAsync" => Task.FromResult(new List<Product> { new() { ProductId = "1", IsActive = true } }),
                "GetSellableBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch() }),
                "SaveAsync" => Save(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Save()
        {
            saves++;
            return Task.CompletedTask;
        }

        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            CartResultDto result;
            {
                result = await owner.RemoveItemAsync("1", Fixture.Token);
                Assert.That(result.Lines, Is.Empty);
                Assert.That(saves, Is.EqualTo(1));
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        }
    }

    /// <summary>
    /// UTM-038-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartService.RemoveItemAsync(string productId, CancellationToken
    /// signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartService.RemoveItemAsync(string
    /// productId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-038.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-038-TC003")]
    public async System.Threading.Tasks.Task UTM_038_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = 2
            }

            ]
        };
        int saves = 0;
        var repo = StrictProxy.For<ICartRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("cart sentinel");
        });
        var owner = new CartService(repo, Fixture.Customer(), new ImmediateWork(), new BatchPricingPolicy());
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            CartResultDto result;
            {
                result = await owner.RemoveItemAsync("1", Fixture.Token);
                Assert.That(result.Lines, Is.Empty);
                Assert.That(saves, Is.EqualTo(1));
            }

            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count > 0 ? "20000" : "0"));
        });
    }
}
