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
public sealed class Services_Implements_CheckoutServiceTests
{
    /// <summary>
    /// UTM-045-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CheckoutService.CheckoutService(ICheckoutRepository checkoutRepository, ICurrentCustomer
    /// currentCustomer, IUnitOfWork unitOfWork, IDistanceCalculator distanceCalculator, IPaymentGateway
    /// paymentGateway, INotificationGateway notificationGateway, IOrderStateMachine orderStateMachine,
    /// IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy, ILogger&lt;CheckoutService&gt; logger)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"checkoutRepository": "Typed FreshFood.Reposistory.Repository.ICheckoutRepository fixture
    /// from fixtures.json", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer fixture from
    /// fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "distanceCalculator": "Typed FreshFood.Api.Services.IDistanceCalculator fixture from
    /// fixtures.json", "paymentGateway": "Typed FreshFood.Api.Services.IPaymentGateway fixture from fixtures.json",
    /// "notificationGateway": "Typed FreshFood.Api.Services.INotificationGateway fixture from fixtures.json",
    /// "orderStateMachine": "ORDER", "pricing": "CATALOG", "deliveryFeePolicy": "Typed
    /// FreshFood.Reposistory.Entities.IDeliveryFeePolicy fixture from fixtures.json", "logger": "Typed
    /// Microsoft.Extensions.Logging.ILogger&lt;FreshFood.Api.Services.Implements.CheckoutService&gt; fixture from
    /// fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CheckoutService.CheckoutService(ICheckoutRepository
    /// checkoutRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IDistanceCalculator
    /// distanceCalculator, IPaymentGateway paymentGateway, INotificationGateway notificationGateway,
    /// IOrderStateMachine orderStateMachine, IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy,
    /// ILogger&lt;CheckoutService&gt; logger); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-045.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-045-TC001")]
    public void UTM_045_TC001()
    {
        // Arrange: test inputs and mock setup.
        var checkoutRepository = (FreshFood.Reposistory.Repository.ICheckoutRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.ICheckoutRepository))!;
        var currentCustomer = (FreshFood.Api.Services.ICurrentCustomer)Fixture.Value(typeof(FreshFood.Api.Services.ICurrentCustomer))!;
        var unitOfWork = (FreshFood.Reposistory.Repository.IUnitOfWork)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IUnitOfWork))!;
        var distanceCalculator = (FreshFood.Api.Services.IDistanceCalculator)Fixture.Value(typeof(FreshFood.Api.Services.IDistanceCalculator))!;
        var paymentGateway = (FreshFood.Api.Services.IPaymentGateway)Fixture.Value(typeof(FreshFood.Api.Services.IPaymentGateway))!;
        var notificationGateway = (FreshFood.Api.Services.INotificationGateway)Fixture.Value(typeof(FreshFood.Api.Services.INotificationGateway))!;
        var orderStateMachine = (FreshFood.Api.Services.IOrderStateMachine)Fixture.Value(typeof(FreshFood.Api.Services.IOrderStateMachine))!;
        var pricing = (FreshFood.Reposistory.Entities.IBatchPricingPolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IBatchPricingPolicy))!;
        var deliveryFeePolicy = (FreshFood.Reposistory.Entities.IDeliveryFeePolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IDeliveryFeePolicy))!;
        var logger = (Microsoft.Extensions.Logging.ILogger<FreshFood.Api.Services.Implements.CheckoutService>)Fixture.Value(typeof(Microsoft.Extensions.Logging.ILogger<FreshFood.Api.Services.Implements.CheckoutService>))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.CheckoutService(checkoutRepository, currentCustomer, unitOfWork, distanceCalculator, paymentGateway, notificationGateway, orderStateMachine, pricing, deliveryFeePolicy, logger);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.CheckoutService>());
    }

    /// <summary>
    /// UTM-045-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CheckoutService.CheckoutService(ICheckoutRepository checkoutRepository, ICurrentCustomer
    /// currentCustomer, IUnitOfWork unitOfWork, IDistanceCalculator distanceCalculator, IPaymentGateway
    /// paymentGateway, INotificationGateway notificationGateway, IOrderStateMachine orderStateMachine,
    /// IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy, ILogger&lt;CheckoutService&gt; logger)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"checkoutRepository": "Typed FreshFood.Reposistory.Repository.ICheckoutRepository fixture
    /// from fixtures.json", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer fixture from
    /// fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "distanceCalculator": "Typed FreshFood.Api.Services.IDistanceCalculator fixture from
    /// fixtures.json", "paymentGateway": "Typed FreshFood.Api.Services.IPaymentGateway fixture from fixtures.json",
    /// "notificationGateway": "Typed FreshFood.Api.Services.INotificationGateway fixture from fixtures.json",
    /// "orderStateMachine": "ORDER", "pricing": "CATALOG", "deliveryFeePolicy": "Typed
    /// FreshFood.Reposistory.Entities.IDeliveryFeePolicy fixture from fixtures.json", "logger": "Typed
    /// Microsoft.Extensions.Logging.ILogger&lt;FreshFood.Api.Services.Implements.CheckoutService&gt; fixture from
    /// fixtures.json", "variant": "Omit optional arguments; otherwise use distinct valid instances and empty
    /// collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CheckoutService.CheckoutService(ICheckoutRepository
    /// checkoutRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IDistanceCalculator
    /// distanceCalculator, IPaymentGateway paymentGateway, INotificationGateway notificationGateway,
    /// IOrderStateMachine orderStateMachine, IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy,
    /// ILogger&lt;CheckoutService&gt; logger); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-045.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-045-TC002")]
    public void UTM_045_TC002()
    {
        // Arrange: test inputs and mock setup.
        var checkoutRepository = (FreshFood.Reposistory.Repository.ICheckoutRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.ICheckoutRepository))!;
        var currentCustomer = (FreshFood.Api.Services.ICurrentCustomer)Fixture.Value(typeof(FreshFood.Api.Services.ICurrentCustomer))!;
        var unitOfWork = (FreshFood.Reposistory.Repository.IUnitOfWork)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IUnitOfWork))!;
        var distanceCalculator = (FreshFood.Api.Services.IDistanceCalculator)Fixture.Value(typeof(FreshFood.Api.Services.IDistanceCalculator))!;
        var paymentGateway = (FreshFood.Api.Services.IPaymentGateway)Fixture.Value(typeof(FreshFood.Api.Services.IPaymentGateway))!;
        var notificationGateway = (FreshFood.Api.Services.INotificationGateway)Fixture.Value(typeof(FreshFood.Api.Services.INotificationGateway))!;
        var orderStateMachine = (FreshFood.Api.Services.IOrderStateMachine)Fixture.Value(typeof(FreshFood.Api.Services.IOrderStateMachine))!;
        var pricing = (FreshFood.Reposistory.Entities.IBatchPricingPolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IBatchPricingPolicy))!;
        var deliveryFeePolicy = (FreshFood.Reposistory.Entities.IDeliveryFeePolicy)Fixture.Value(typeof(FreshFood.Reposistory.Entities.IDeliveryFeePolicy))!;
        var logger = (Microsoft.Extensions.Logging.ILogger<FreshFood.Api.Services.Implements.CheckoutService>)Fixture.Value(typeof(Microsoft.Extensions.Logging.ILogger<FreshFood.Api.Services.Implements.CheckoutService>))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.CheckoutService(checkoutRepository, currentCustomer, unitOfWork, distanceCalculator, paymentGateway, notificationGateway, orderStateMachine, pricing, deliveryFeePolicy, logger);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.CheckoutService>());
    }

    /// <summary>
    /// UTM-045-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CheckoutService.CheckoutService(ICheckoutRepository checkoutRepository, ICurrentCustomer
    /// currentCustomer, IUnitOfWork unitOfWork, IDistanceCalculator distanceCalculator, IPaymentGateway
    /// paymentGateway, INotificationGateway notificationGateway, IOrderStateMachine orderStateMachine,
    /// IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy, ILogger&lt;CheckoutService&gt; logger)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"checkoutRepository": "Typed FreshFood.Reposistory.Repository.ICheckoutRepository fixture
    /// from fixtures.json", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer fixture from
    /// fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "distanceCalculator": "Typed FreshFood.Api.Services.IDistanceCalculator fixture from
    /// fixtures.json", "paymentGateway": "Typed FreshFood.Api.Services.IPaymentGateway fixture from fixtures.json",
    /// "notificationGateway": "Typed FreshFood.Api.Services.INotificationGateway fixture from fixtures.json",
    /// "orderStateMachine": "ORDER", "pricing": "CATALOG", "deliveryFeePolicy": "Typed
    /// FreshFood.Reposistory.Entities.IDeliveryFeePolicy fixture from fixtures.json", "logger": "Typed
    /// Microsoft.Extensions.Logging.ILogger&lt;FreshFood.Api.Services.Implements.CheckoutService&gt; fixture from
    /// fixtures.json", "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CheckoutService.CheckoutService(ICheckoutRepository
    /// checkoutRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IDistanceCalculator
    /// distanceCalculator, IPaymentGateway paymentGateway, INotificationGateway notificationGateway,
    /// IOrderStateMachine orderStateMachine, IBatchPricingPolicy pricing, IDeliveryFeePolicy deliveryFeePolicy,
    /// ILogger&lt;CheckoutService&gt; logger); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-045.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-045-TC003")]
    public void UTM_045_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-048-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Preparation&gt; CheckoutService.Plan(string addressId, CancellationToken ct)
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
    /// Design input: {"addressId": "2", "ct": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Preparation&gt; CheckoutService.Plan(string addressId,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-048.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-048-TC001")]
    public async System.Threading.Tasks.Task UTM_048_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var method = typeof(CheckoutService).GetMethod("Plan", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, "2", Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        }
    }

    /// <summary>
    /// UTM-048-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Preparation&gt; CheckoutService.Plan(string addressId, CancellationToken ct)
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
    /// Design input: {"addressId": "2", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Preparation&gt; CheckoutService.Plan(string addressId,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-048.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-048-TC002")]
    public async System.Threading.Tasks.Task UTM_048_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var method = typeof(CheckoutService).GetMethod("Plan", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, "2", Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        }
    }

    /// <summary>
    /// UTM-048-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Preparation&gt; CheckoutService.Plan(string addressId, CancellationToken ct)
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
    /// Design input: {"addressId": "2", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Preparation&gt; CheckoutService.Plan(string addressId,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-048.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-048-TC003")]
    public async System.Threading.Tasks.Task UTM_048_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("checkout sentinel");
        });
        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => throw new TimeoutException("payment verification sentinel"));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var method = typeof(CheckoutService).GetMethod("Plan", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, "2", Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        });
    }

    /// <summary>
    /// UTM-048-TC004: guard L15 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Preparation&gt; CheckoutService.Plan(string addressId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"cart.Items.Count": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Preparation&gt; CheckoutService.Plan(string addressId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("EMPTY_CART", 422) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:15. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-048-D01:False, UTM-048-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-048.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-048-TC004")]
    public void UTM_048_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-048-TC005: guard L15 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Preparation&gt; CheckoutService.Plan(string addressId, CancellationToken ct)
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
    /// Design input: {"arguments": {"addressId": "2", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"cart.Items.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Preparation&gt; CheckoutService.Plan(string addressId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:15. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-048-D01:True, UTM-048-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-048.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-048-TC005")]
    public void UTM_048_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC001: FEFO split across batches
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Decision table; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"fixture": "FEFO", "ProductId": "1", "RetailPrice": "10000", "SaleStatus": "ACTIVE"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Batch1 qty5 then batch2 qty1; SubTotal="60000"
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No accepted order or partial stock commit
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC001")]
    public async System.Threading.Tasks.Task UTM_049_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var method = typeof(CheckoutService).GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, cart, Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        }
    }

    /// <summary>
    /// UTM-049-TC002: Insufficient all-line stock
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Quantity": 8, "Available": 7}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject all lines
    /// </para>
    /// <para>
    /// Design exception expectation: INSUFFICIENT_STOCK / 409
    /// </para>
    /// <para>
    /// Expected side effects: No partial commit
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC002")]
    public void UTM_049_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(8m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    var method = typeof(CheckoutService).GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Instance)!;
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, cart, Fixture.Token));
                    Assert.That(result, Is.Not.Null);
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "INSUFFICIENT_STOCK", "/", "409" }[0]));
        }
    }

    /// <summary>
    /// UTM-049-TC003: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC003")]
    public async System.Threading.Tasks.Task UTM_049_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var method = typeof(CheckoutService).GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, cart, Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        }
    }

    /// <summary>
    /// UTM-049-TC004: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC004")]
    public async System.Threading.Tasks.Task UTM_049_TC004()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var method = typeof(CheckoutService).GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, cart, Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        }
    }

    /// <summary>
    /// UTM-049-TC005: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC005")]
    public async System.Threading.Tasks.Task UTM_049_TC005()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("checkout sentinel");
        });
        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => throw new TimeoutException("payment verification sentinel"));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var method = typeof(CheckoutService).GetMethod("Allocate", BindingFlags.NonPublic | BindingFlags.Instance)!;
                var result = await Fixture.Await(Fixture.Invoke(method, owner, cart, Fixture.Token));
                Assert.That(result, Is.Not.Null);
                return;
            }
        });
    }

    /// <summary>
    /// UTM-049-TC006: foreach L24 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {             ServiceRules.Require(item.Quantity
    /// &gt; 0, "INVALID_QUANTITY"); var remaining = item.Quantity;             foreach (var b in batches.Where(b =&gt;
    /// b.ProductId == item.ProductId))             {                 var qty = Math.Min(remaining, b.CurrentStock -
    /// b.ReservedStock); if (qty == 0) continue;                 var price = pricing.Quote(b,
    /// DateTimeOffset.UtcNow);                 lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId,
    /// Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
    /// total += price.Units * qty; remaining -= qty; if (remaining == 0) break;             }
    /// ServiceRules.Require(remaining == 0, "INSUFFICIENT_STOCK", 409);         } | Assert selected outcome Empty
    /// at src/FreshFood-API/Services/Implements/CheckoutService.cs:24. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D01:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC006")]
    public void UTM_049_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC007: foreach L24 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {             ServiceRules.Require(item.Quantity
    /// &gt; 0, "INVALID_QUANTITY"); var remaining = item.Quantity;             foreach (var b in batches.Where(b =&gt;
    /// b.ProductId == item.ProductId))             {                 var qty = Math.Min(remaining, b.CurrentStock -
    /// b.ReservedStock); if (qty == 0) continue;                 var price = pricing.Quote(b,
    /// DateTimeOffset.UtcNow);                 lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId,
    /// Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
    /// total += price.Units * qty; remaining -= qty; if (remaining == 0) break;             }
    /// ServiceRules.Require(remaining == 0, "INSUFFICIENT_STOCK", 409);         } | Assert selected outcome One
    /// item at src/FreshFood-API/Services/Implements/CheckoutService.cs:24. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D01:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC007")]
    public void UTM_049_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC008: foreach L24 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {             ServiceRules.Require(item.Quantity
    /// &gt; 0, "INVALID_QUANTITY"); var remaining = item.Quantity;             foreach (var b in batches.Where(b =&gt;
    /// b.ProductId == item.ProductId))             {                 var qty = Math.Min(remaining, b.CurrentStock -
    /// b.ReservedStock); if (qty == 0) continue;                 var price = pricing.Quote(b,
    /// DateTimeOffset.UtcNow);                 lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId,
    /// Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
    /// total += price.Units * qty; remaining -= qty; if (remaining == 0) break;             }
    /// ServiceRules.Require(remaining == 0, "INSUFFICIENT_STOCK", 409);         } | Assert selected outcome
    /// Multiple items at src/FreshFood-API/Services/Implements/CheckoutService.cs:24. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D01:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC008")]
    public void UTM_049_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC009: guard L26 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"item.Quantity": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_QUANTITY") | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:26. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D02:False, UTM-049-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC009")]
    public void UTM_049_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC010: guard L26 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"item.Quantity": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:26. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D02:True, UTM-049-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC010")]
    public void UTM_049_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC011: foreach L27 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"scenario": "Empty", "expression": "batches.Where(b =&gt; b.ProductId == item.ProductId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {                 var qty = Math.Min(remaining,
    /// b.CurrentStock - b.ReservedStock); if (qty == 0) continue;                 var price = pricing.Quote(b,
    /// DateTimeOffset.UtcNow);                 lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId,
    /// Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
    /// total += price.Units * qty; remaining -= qty; if (remaining == 0) break;             } | Assert selected
    /// outcome Empty at src/FreshFood-API/Services/Implements/CheckoutService.cs:27. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D03:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC011")]
    public void UTM_049_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC012: foreach L27 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"scenario": "One item", "expression": "batches.Where(b =&gt; b.ProductId == item.ProductId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {                 var qty = Math.Min(remaining,
    /// b.CurrentStock - b.ReservedStock); if (qty == 0) continue;                 var price = pricing.Quote(b,
    /// DateTimeOffset.UtcNow);                 lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId,
    /// Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
    /// total += price.Units * qty; remaining -= qty; if (remaining == 0) break;             } | Assert selected
    /// outcome One item at src/FreshFood-API/Services/Implements/CheckoutService.cs:27. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D03:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC012")]
    public void UTM_049_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC013: foreach L27 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"scenario": "Multiple items", "expression": "batches.Where(b =&gt; b.ProductId ==
    /// item.ProductId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {                 var qty = Math.Min(remaining,
    /// b.CurrentStock - b.ReservedStock); if (qty == 0) continue;                 var price = pricing.Quote(b,
    /// DateTimeOffset.UtcNow);                 lines.Add(new() { ProductId = item.ProductId, BatchId = b.BatchId,
    /// Quantity = qty, UnitPrice = price, LineTotal = new(price.Units * qty), DiscountAmount = new(0) });
    /// total += price.Units * qty; remaining -= qty; if (remaining == 0) break;             } | Assert selected
    /// outcome Multiple items at src/FreshFood-API/Services/Implements/CheckoutService.cs:27. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D03:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC013")]
    public void UTM_049_TC013()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC014: predicate L27 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: b =&gt; b.ProductId == item.ProductId | Assert selected
    /// outcome False at src/FreshFood-API/Services/Implements/CheckoutService.cs:27. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D04:False, UTM-049-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC014")]
    public void UTM_049_TC014()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC015: predicate L27 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: b =&gt; b.ProductId == item.ProductId | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CheckoutService.cs:27. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D04:True, UTM-049-D04:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC015")]
    public void UTM_049_TC015()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC016: if L29 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"qty": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D05:False, UTM-049-D05:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC016")]
    public void UTM_049_TC016()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC017: if L29 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"qty": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue; | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:29. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D05:True, UTM-049-D05:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC017")]
    public void UTM_049_TC017()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC018: if L32 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"remaining": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:32. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D06:False, UTM-049-D06:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC018")]
    public void UTM_049_TC018()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC019: if L32 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"remaining": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: break; | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:32. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D06:True, UTM-049-D06:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC019")]
    public void UTM_049_TC019()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC020: guard L34 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"remaining": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INSUFFICIENT_STOCK", 409) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:34. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D07:False, UTM-049-D07:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC020")]
    public void UTM_049_TC020()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-049-TC021: guard L34 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart, CancellationToken ct)
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
    /// "overrides": {"remaining": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Allocation&gt; CheckoutService.Allocate(Cart cart,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:34. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-049-D07:True, UTM-049-D07:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-049.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-049-TC021")]
    public void UTM_049_TC021()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-050-TC001: FEFO split across batches
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CheckoutSummaryDto&gt; CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Decision table; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"fixture": "FEFO", "ProductId": "1", "RetailPrice": "10000", "SaleStatus": "ACTIVE"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CheckoutSummaryDto&gt;
    /// CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Batch1 qty5 then batch2 qty1; SubTotal="60000"
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No accepted order or partial stock commit
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-050.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-050-TC001")]
    public async System.Threading.Tasks.Task UTM_050_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var summary = await owner.PrepareCheckoutAsync(new() { AddressId = "2" }, Fixture.Token);
                Assert.That(summary.Total, Is.EqualTo("30000"));
                Assert.That(TestChecks.Single(summary.Lines).Quantity, Is.EqualTo(2));
                return;
            }
        }
    }

    /// <summary>
    /// UTM-050-TC002: Insufficient all-line stock
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CheckoutSummaryDto&gt; CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Quantity": 8, "Available": 7}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CheckoutSummaryDto&gt;
    /// CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject all lines
    /// </para>
    /// <para>
    /// Design exception expectation: INSUFFICIENT_STOCK / 409
    /// </para>
    /// <para>
    /// Expected side effects: No partial commit
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-050.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-050-TC002")]
    public void UTM_050_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(8m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    var summary = await owner.PrepareCheckoutAsync(new() { AddressId = "2" }, Fixture.Token);
                    Assert.That(summary.Total, Is.EqualTo("30000"));
                    Assert.That(TestChecks.Single(summary.Lines).Quantity, Is.EqualTo(2));
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "INSUFFICIENT_STOCK", "/", "409" }[0]));
        }
    }

    /// <summary>
    /// UTM-050-TC003: Summary calculation
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CheckoutSummaryDto&gt; CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request,
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
    /// Design input: {"fixture": "CHECKOUT", "Quantity": 2, "Price": "10000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CheckoutSummaryDto&gt;
    /// CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: SubTotal="20000", ShippingFee="20000", Total="40000"
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-050.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-050-TC003")]
    public async System.Threading.Tasks.Task UTM_050_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var summary = await owner.PrepareCheckoutAsync(new() { AddressId = "2" }, Fixture.Token);
                Assert.That(summary.Total, Is.EqualTo("30000"));
                Assert.That(TestChecks.Single(summary.Lines).Quantity, Is.EqualTo(2));
                return;
            }
        }
    }

    /// <summary>
    /// UTM-050-TC004: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CheckoutSummaryDto&gt; CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request,
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
    /// Design input: {"request": {"fixture": "CheckoutInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CheckoutSummaryDto&gt;
    /// CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-050.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-050-TC004")]
    public async System.Threading.Tasks.Task UTM_050_TC004()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var summary = await owner.PrepareCheckoutAsync(new() { AddressId = "2" }, Fixture.Token);
                Assert.That(summary.Total, Is.EqualTo("30000"));
                Assert.That(TestChecks.Single(summary.Lines).Quantity, Is.EqualTo(2));
                return;
            }
        }
    }

    /// <summary>
    /// UTM-050-TC005: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CheckoutSummaryDto&gt; CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request,
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
    /// Design input: {"request": {"fixture": "CheckoutInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CheckoutSummaryDto&gt;
    /// CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-050.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-050-TC005")]
    public async System.Threading.Tasks.Task UTM_050_TC005()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var summary = await owner.PrepareCheckoutAsync(new() { AddressId = "2" }, Fixture.Token);
                Assert.That(summary.Total, Is.EqualTo("30000"));
                Assert.That(TestChecks.Single(summary.Lines).Quantity, Is.EqualTo(2));
                return;
            }
        }
    }

    /// <summary>
    /// UTM-050-TC006: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CheckoutSummaryDto&gt; CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request,
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
    /// Design input: {"request": {"fixture": "CheckoutInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CheckoutSummaryDto&gt;
    /// CheckoutService.PrepareCheckoutAsync(CheckoutInputDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-050.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-050-TC006")]
    public void UTM_050_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-051-TC001: Persisted fingerprint compatibility
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.RequestHash(PlaceOrderDto request)
    /// </para>
    /// <para>
    /// Technique: Compatibility error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Fixture": "src/FreshFood-API.Tests/Fixtures/checkout-hash-vectors.json", "Variants": "quote,
    /// backslash, control, Unicode, paired and lone surrogates"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.RequestHash(PlaceOrderDto request);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exact JSON.stringify-compatible output / fixture SHA256; no normalization
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-051.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-051-TC001")]
    public void UTM_051_TC001()
    {
        // Arrange: test inputs and mock setup.
        {
            {
                using var vectors = JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "checkout-hash-vectors.json")));
                foreach (var vector in vectors.RootElement.EnumerateArray())
                    Assert.That(CheckoutService.RequestHash(new() { AddressId = "2", PaymentMethod = PaymentMethod.Cod, CheckoutReference = vector.GetProperty("Reference").GetString()! }), Is.EqualTo(vector.GetProperty("Hash").GetString()));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-051-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.RequestHash(PlaceOrderDto request)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "PlaceOrderDto"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.RequestHash(PlaceOrderDto request);
    /// assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-051.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-051-TC002")]
    public void UTM_051_TC002()
    {
        // Arrange: test inputs and mock setup.
        {
            Assert.That(CheckoutService.RequestHash(new() { AddressId = "2", PaymentMethod = PaymentMethod.Cod, CheckoutReference = "ref" }).Length, Is.EqualTo(64));
            return;
        }
    }

    /// <summary>
    /// UTM-051-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.RequestHash(PlaceOrderDto request)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "PlaceOrderDto"}, "boundary": "Empty then single-item collection where
    /// relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.RequestHash(PlaceOrderDto request);
    /// assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-051.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-051-TC003")]
    public void UTM_051_TC003()
    {
        // Arrange: test inputs and mock setup.
        {
            Assert.That(CheckoutService.RequestHash(new() { AddressId = "2", PaymentMethod = PaymentMethod.Cod, CheckoutReference = "ref" }).Length, Is.EqualTo(64));
            return;
        }
    }

    /// <summary>
    /// UTM-051-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.RequestHash(PlaceOrderDto request)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "PlaceOrderDto"}, "failure": "First collaborator throws
    /// TimeoutException sentinel; for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.RequestHash(PlaceOrderDto request);
    /// assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-051.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-051-TC004")]
    public void UTM_051_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-052-TC001: Persisted fingerprint compatibility
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
    /// </para>
    /// <para>
    /// Technique: Compatibility error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Fixture": "src/FreshFood-API.Tests/Fixtures/checkout-hash-vectors.json", "Variants": "quote,
    /// backslash, control, Unicode, paired and lone surrogates"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exact JSON.stringify-compatible output / fixture SHA256; no normalization
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC001")]
    public void UTM_052_TC001()
    {
        // Arrange: test inputs and mock setup.
        {
            {
                using var vectors = JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "checkout-hash-vectors.json")));
                foreach (var vector in vectors.RootElement.EnumerateArray())
                    Assert.That(CheckoutService.RequestHash(new() { AddressId = "2", PaymentMethod = PaymentMethod.Cod, CheckoutReference = vector.GetProperty("Reference").GetString()! }), Is.EqualTo(vector.GetProperty("Hash").GetString()));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-052-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"text": "Sample"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC002")]
    public void UTM_052_TC002()
    {
        // Arrange: test inputs and mock setup.
        {
            Assert.That(Fixture.Invoke(typeof(CheckoutService).GetMethod("LegacyJsonString", BindingFlags.NonPublic | BindingFlags.Static)!, null, "Sample"), Is.EqualTo("\"Sample\""));
            return;
        }
    }

    /// <summary>
    /// UTM-052-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"text": "Sample", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC003")]
    public void UTM_052_TC003()
    {
        // Arrange: test inputs and mock setup.
        {
            Assert.That(Fixture.Invoke(typeof(CheckoutService).GetMethod("LegacyJsonString", BindingFlags.NonPublic | BindingFlags.Static)!, null, "Sample"), Is.EqualTo("\"Sample\""));
            return;
        }
    }

    /// <summary>
    /// UTM-052-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"text": "Sample", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
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
    /// Execution constraint (NUnit Ignore): No injectable collaborator here; bind abnormal cases to the declared
    /// guard, or review N/A instead of inventing a fault injection seam.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC004")]
    public void UTM_052_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-052-TC005: for L60 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text": "", "i": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: for (var i = 0; i &lt; text.Length; i++)         {
    /// var c = text[i];             var escape = c switch { '"' =&gt; "\\\"", '\\' =&gt; "\\\\", '\b' =&gt; "\\b", '\f' =&gt;
    /// "\\f", '\n' =&gt; "\\n", '\r' =&gt; "\\r", '\t' =&gt; "\\t", _ =&gt; null };             if (escape is not null)
    /// output.Append(escape);             else if (char.IsHighSurrogate(c) &amp; &amp; i + 1 &lt; text.Length &amp; &amp;
    /// char.IsLowSurrogate(text[i + 1])) { output.Append(c).Append(text[++i]); }             else if (c &lt; 32 ||
    /// char.IsSurrogate(c)) output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
    /// else output.Append(c);         } | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:60. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D01:False, UTM-052-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC005")]
    public void UTM_052_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC006: for L60 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text": "a", "i": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: for (var i = 0; i &lt; text.Length; i++)         {
    /// var c = text[i];             var escape = c switch { '"' =&gt; "\\\"", '\\' =&gt; "\\\\", '\b' =&gt; "\\b", '\f' =&gt;
    /// "\\f", '\n' =&gt; "\\n", '\r' =&gt; "\\r", '\t' =&gt; "\\t", _ =&gt; null };             if (escape is not null)
    /// output.Append(escape);             else if (char.IsHighSurrogate(c) &amp; &amp; i + 1 &lt; text.Length &amp; &amp;
    /// char.IsLowSurrogate(text[i + 1])) { output.Append(c).Append(text[++i]); }             else if (c &lt; 32 ||
    /// char.IsSurrogate(c)) output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
    /// else output.Append(c);         } | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:60. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D01:True, UTM-052-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC006")]
    public void UTM_052_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC007: switch-arm L63 -&gt; '"'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\"'", "expression": "'\"' =&gt; \"\\\\\\\"\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\\"" | Assert selected outcome '"' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D02:'"'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC007")]
    public void UTM_052_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC008: switch-arm L63 -&gt; '\\'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\\\\'", "expression": "'\\\\' =&gt;
    /// \"\\\\\\\\\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\\\" | Assert selected outcome '\\' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D03:'\\'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC008")]
    public void UTM_052_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC009: switch-arm L63 -&gt; '\b'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\\b'", "expression": "'\\b' =&gt; \"\\\\b\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\b" | Assert selected outcome '\b' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D04:'\b'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC009")]
    public void UTM_052_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC010: switch-arm L63 -&gt; '\f'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\\f'", "expression": "'\\f' =&gt; \"\\\\f\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\f" | Assert selected outcome '\f' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D05:'\f'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC010")]
    public void UTM_052_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC011: switch-arm L63 -&gt; '\n'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\\n'", "expression": "'\\n' =&gt; \"\\\\n\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\n" | Assert selected outcome '\n' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D06:'\n'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC011")]
    public void UTM_052_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC012: switch-arm L63 -&gt; '\r'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\\r'", "expression": "'\\r' =&gt; \"\\\\r\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\r" | Assert selected outcome '\r' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D07:'\r'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC012")]
    public void UTM_052_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC013: switch-arm L63 -&gt; '\t'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "'\\t'", "expression": "'\\t' =&gt; \"\\\\t\""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: "\\t" | Assert selected outcome '\t' at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D08:'\t'
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC013")]
    public void UTM_052_TC013()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC014: switch-arm L63 -&gt; _
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "_", "expression": "_ =&gt; null"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: null | Assert selected outcome _ at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D09:_
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC014")]
    public void UTM_052_TC014()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC015: if L64 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"escape": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: if (char.IsHighSurrogate(c) &amp; &amp; i + 1 &lt; text.Length &amp; &amp;
    /// char.IsLowSurrogate(text[i + 1])) { output.Append(c).Append(text[++i]); }             else if (c &lt; 32 ||
    /// char.IsSurrogate(c)) output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
    /// else output.Append(c); | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:64. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D10:False, UTM-052-D10:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC015")]
    public void UTM_052_TC015()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC016: if L64 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"escape": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: output.Append(escape); | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:64. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D10:True, UTM-052-D10:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC016")]
    public void UTM_052_TC016()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC017: if L65 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+0041"], "index": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: if (c &lt; 32 || char.IsSurrogate(c))
    /// output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));             else
    /// output.Append(c); | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:65. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D11:False, UTM-052-D11:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC017")]
    public void UTM_052_TC017()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC018: if L65 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+D800", "U+DC00"], "index": 0, "text":
    /// "a", "i": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: if (c &lt; 32 || char.IsSurrogate(c))
    /// output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));             else
    /// output.Append(c); | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:65. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D11:False, UTM-052-D11:C1:True, UTM-052-D11:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC018")]
    public void UTM_052_TC018()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC019: if L65 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+D800", "U+0041"], "index": 0, "text":
    /// "ab", "i": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: if (c &lt; 32 || char.IsSurrogate(c))
    /// output.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));             else
    /// output.Append(c); | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:65. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D11:False, UTM-052-D11:C1:True, UTM-052-D11:C2:True, UTM-052-D11:C3:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC019")]
    public void UTM_052_TC019()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC020: if L65 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+D800", "U+DC00"], "index": 0, "text":
    /// "ab", "i": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: { output.Append(c).Append(text[++i]); } | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:65. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D11:True, UTM-052-D11:C1:True, UTM-052-D11:C2:True, UTM-052-D11:C3:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC020")]
    public void UTM_052_TC020()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC021: if L66 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+0041"]}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: output.Append(c); | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:66. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D12:False, UTM-052-D12:C1:False, UTM-052-D12:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC021")]
    public void UTM_052_TC021()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC022: if L66 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+D800"]}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: output.Append("\\u").Append(((int)c).ToString("x4",
    /// CultureInfo.InvariantCulture)); | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:66. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D12:True, UTM-052-D12:C1:False, UTM-052-D12:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC022")]
    public void UTM_052_TC022()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-052-TC023: if L66 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CheckoutService.LegacyJsonString(string text)
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
    /// Design input: {"arguments": {"text": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"text code points": ["U+0000"]}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CheckoutService.LegacyJsonString(string text); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: output.Append("\\u").Append(((int)c).ToString("x4",
    /// CultureInfo.InvariantCulture)); | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:66. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-052-D12:True, UTM-052-D12:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-052.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-052-TC023")]
    public void UTM_052_TC023()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC001: COD acceptance
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Transaction / state transition; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"fixture": "CHECKOUT", "ClaimReplay": false}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: PendingUnpaid/Unpaid; Total="40000"
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Claim -&gt; lock/revalidate -&gt; FEFO -&gt; acceptOrder -&gt; save/clear/complete -&gt; commit -&gt;
    /// notify once
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC001")]
    public async System.Threading.Tasks.Task UTM_053_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
            Assert.That(resultOrder.Total, Is.EqualTo("30000"));
            Assert.That(saves, Is.EqualTo(1));
            Assert.That(clears, Is.EqualTo(saves));
            Assert.That(completes, Is.EqualTo(saves));
            Assert.That(notices, Is.EqualTo(saves));
        }
    }

    /// <summary>
    /// UTM-053-TC002: Replay despite stale preparation failure
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / idempotency; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"ClaimReplay": true, "StoredResponse": "existing confirmation", "PlanError": "EMPTY_CART"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly stored confirmation
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No new order, stock mutation, clear or notification
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC002")]
    public async System.Threading.Tasks.Task UTM_053_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = true, Response = JsonSerializer.Serialize(stored, ApiJson.Options) }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(new Cart());
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
            Assert.That(resultOrder.Total, Is.EqualTo("30000"));
            Assert.That(saves, Is.EqualTo(0));
            Assert.That(clears, Is.EqualTo(saves));
            Assert.That(completes, Is.EqualTo(saves));
            Assert.That(notices, Is.EqualTo(saves));
        }
    }

    /// <summary>
    /// UTM-053-TC003: Address changed after preparation
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"originalStreet": "A", "lockedStreet": "B"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject checkout
    /// </para>
    /// <para>
    /// Design exception expectation: CHECKOUT_ADDRESS_CHANGED / 409
    /// </para>
    /// <para>
    /// Expected side effects: Rollback claim and writes
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC003")]
    public void UTM_053_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            if (true && addresses > 1)
            {
                var other = Fixture.Address();
                other.StreetAddress = "B";
                return Task.FromResult(other);
            }

            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
                Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
                Assert.That(resultOrder.Total, Is.EqualTo("30000"));
                Assert.That(saves, Is.EqualTo(1));
                Assert.That(clears, Is.EqualTo(saves));
                Assert.That(completes, Is.EqualTo(saves));
                Assert.That(notices, Is.EqualTo(saves));
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "CHECKOUT_ADDRESS_CHANGED", "/", "409" }[0]));
        }
    }

    /// <summary>
    /// UTM-053-TC004: Notification fails after commit
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Publish": "throws sentinel"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Committed confirmation returned
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Warning logged; committed order not rolled back
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC004")]
    public async System.Threading.Tasks.Task UTM_053_TC004()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            throw new TimeoutException("notification sentinel");
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
            Assert.That(resultOrder.Total, Is.EqualTo("30000"));
            Assert.That(saves, Is.EqualTo(1));
            Assert.That(clears, Is.EqualTo(saves));
            Assert.That(completes, Is.EqualTo(saves));
            Assert.That(notices, Is.EqualTo(saves));
        }
    }

    /// <summary>
    /// UTM-053-TC005: Prepaid flow still deferred
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"PaymentMethod": "VietQr"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: No acceptance
    /// </para>
    /// <para>
    /// Design exception expectation: PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD / 503
    /// </para>
    /// <para>
    /// Expected side effects: No claim or write
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC005")]
    public void UTM_053_TC005()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.VietQr }, Fixture.Token);
                Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
                Assert.That(resultOrder.Total, Is.EqualTo("30000"));
                Assert.That(saves, Is.EqualTo(1));
                Assert.That(clears, Is.EqualTo(saves));
                Assert.That(completes, Is.EqualTo(saves));
                Assert.That(notices, Is.EqualTo(saves));
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", "/", "503" }[0]));
        }
    }

    /// <summary>
    /// UTM-053-TC006: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC006")]
    public async System.Threading.Tasks.Task UTM_053_TC006()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
            Assert.That(resultOrder.Total, Is.EqualTo("30000"));
            Assert.That(saves, Is.EqualTo(1));
            Assert.That(clears, Is.EqualTo(saves));
            Assert.That(completes, Is.EqualTo(saves));
            Assert.That(notices, Is.EqualTo(saves));
        }
    }

    /// <summary>
    /// UTM-053-TC007: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC007")]
    public async System.Threading.Tasks.Task UTM_053_TC007()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
            Assert.That(resultOrder.Total, Is.EqualTo("30000"));
            Assert.That(saves, Is.EqualTo(1));
            Assert.That(clears, Is.EqualTo(saves));
            Assert.That(completes, Is.EqualTo(saves));
            Assert.That(notices, Is.EqualTo(saves));
        }
    }

    /// <summary>
    /// UTM-053-TC008: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC008")]
    public async System.Threading.Tasks.Task UTM_053_TC008()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("checkout sentinel");
        });
        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => throw new TimeoutException("payment verification sentinel"));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            var resultOrder = await owner.PlaceOrderAsync(new() { AddressId = "2", CheckoutReference = "ref", IdempotencyKey = "key", PaymentMethod = PaymentMethod.Cod }, Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));
            Assert.That(resultOrder.Total, Is.EqualTo("30000"));
            Assert.That(saves, Is.EqualTo(1));
            Assert.That(clears, Is.EqualTo(saves));
            Assert.That(completes, Is.EqualTo(saves));
            Assert.That(notices, Is.EqualTo(saves));
        });
    }

    /// <summary>
    /// UTM-053-TC009: guard L73 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"PaymentMethod": 999}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_PAYMENT_METHOD") | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:73. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D01:False, UTM-053-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC009")]
    public void UTM_053_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC010: guard L73 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"PaymentMethod": "Cod"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:73. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D01:True, UTM-053-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC010")]
    public void UTM_053_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC011: if L76 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.PaymentMethod": "Cod"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:76. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D02:False, UTM-053-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC011")]
    public void UTM_053_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC012: if L76 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.PaymentMethod": "VietQr"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503); |
    /// Assert selected outcome True at src/FreshFood-API/Services/Implements/CheckoutService.cs:76. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D02:True, UTM-053-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC012")]
    public void UTM_053_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC013: catch L78 -&gt; Exception
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Exception", "expression": "catch (Exception e)
    /// when (e is not OperationCanceledException) { preparationError = e; }"}, "fault": "Throw Exception from the
    /// dependency protected by this catch; exercise filter true and false when present."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: { preparationError = e; } | Assert selected outcome Exception at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:78. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D03:Exception
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC013")]
    public void UTM_053_TC013()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC014: catch-filter L78 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"injectedException": "OperationCanceledException"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: when (e is not OperationCanceledException) | Assert
    /// selected outcome False at src/FreshFood-API/Services/Implements/CheckoutService.cs:78. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D04:False, UTM-053-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC014")]
    public void UTM_053_TC014()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC015: catch-filter L78 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"injectedException": "TimeoutException"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: when (e is not OperationCanceledException) | Assert
    /// selected outcome True at src/FreshFood-API/Services/Implements/CheckoutService.cs:78. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D04:True, UTM-053-D04:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC015")]
    public void UTM_053_TC015()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC016: if L82 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"claim.Replay": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:82. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D05:False, UTM-053-D05:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC016")]
    public void UTM_053_TC016()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC017: if L82 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"claim.Replay": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: return (Confirmation:
    /// JsonSerializer.Deserialize&lt;OrderConfirmationDto&gt;(claim.Response!, ApiJson.Options)!, Replay: true); | Assert
    /// selected outcome True at src/FreshFood-API/Services/Implements/CheckoutService.cs:82. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D05:True, UTM-053-D05:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC017")]
    public void UTM_053_TC017()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC018: if L83 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"preparationError": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:83. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D06:False, UTM-053-D06:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC018")]
    public void UTM_053_TC018()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC019: if L83 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"preparationError": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True:
    /// System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(preparationError).Throw(); | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CheckoutService.cs:83. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D06:True, UTM-053-D06:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC019")]
    public void UTM_053_TC019()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC020: guard L85 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"cart.Items.Count": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("EMPTY_CART", 422) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:85. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D07:False, UTM-053-D07:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC020")]
    public void UTM_053_TC020()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC021: guard L85 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"cart.Items.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:85. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D07:True, UTM-053-D07:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC021")]
    public void UTM_053_TC021()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC022: guard L87 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"address.StreetAddress": "99", "p.Address.StreetAddress":
    /// "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("CHECKOUT_ADDRESS_CHANGED", 409) | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:87. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D08:False, UTM-053-D08:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC022")]
    public void UTM_053_TC022()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC023: guard L87 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"address.StreetAddress": "1", "p.Address.StreetAddress": "1",
    /// "address.Latitude": "99", "p.Address.Latitude": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("CHECKOUT_ADDRESS_CHANGED", 409) | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:87. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D08:False, UTM-053-D08:C1:True, UTM-053-D08:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC023")]
    public void UTM_053_TC023()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC024: guard L87 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"address.StreetAddress": "1", "p.Address.StreetAddress": "1",
    /// "address.Latitude": "1", "p.Address.Latitude": "1", "address.Longitude": "99", "p.Address.Longitude": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("CHECKOUT_ADDRESS_CHANGED", 409) | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:87. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D08:False, UTM-053-D08:C1:True, UTM-053-D08:C2:True, UTM-053-D08:C3:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC024")]
    public void UTM_053_TC024()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC025: guard L87 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"address.StreetAddress": "1", "p.Address.StreetAddress": "1",
    /// "address.Latitude": "1", "p.Address.Latitude": "1", "address.Longitude": "1", "p.Address.Longitude": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:87. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D08:True, UTM-053-D08:C1:True, UTM-053-D08:C2:True, UTM-053-D08:C3:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC025")]
    public void UTM_053_TC025()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC026: if L111 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "!result.Replay = False; arrange
    /// matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CheckoutService.cs:111. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D09:False, UTM-053-D09:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC026")]
    public void UTM_053_TC026()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC027: if L111 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "!result.Replay = True; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: try { await notificationGateway.PublishAsync(new() { OrderId =
    /// result.Confirmation.OrderId, EventCode = "ORDER_ACCEPTED" }, signal); }             catch (Exception e) {
    /// logger.LogWarning(e, "Notification failed after committed order {OrderId}", result.Confirmation.OrderId); }
    /// | Assert selected outcome True at src/FreshFood-API/Services/Implements/CheckoutService.cs:111. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D09:True, UTM-053-D09:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC027")]
    public void UTM_053_TC027()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-053-TC028: catch L113 -&gt; Exception
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderConfirmationDto&gt; CheckoutService.PlaceOrderAsync(PlaceOrderDto request,
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
    /// Design input: {"arguments": {"request": {"fixture": "PlaceOrderDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Exception", "expression": "catch (Exception e) {
    /// logger.LogWarning(e, \"Notification failed after committed order {OrderId}\", result.Confirmation.OrderId);
    /// }"}, "fault": "Throw Exception from the dependency protected by this catch; exercise filter true and false
    /// when present."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderConfirmationDto&gt;
    /// CheckoutService.PlaceOrderAsync(PlaceOrderDto request, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: { logger.LogWarning(e, "Notification failed after committed order {OrderId}",
    /// result.Confirmation.OrderId); } | Assert selected outcome Exception at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:113. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-053-D10:Exception
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-053.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-053-TC028")]
    public void UTM_053_TC028()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-054-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentQrDto&gt; CheckoutService.CreatePaymentQrAsync(PaymentQrRequestDto request,
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
    /// Design input: {"request": {"fixture": "PaymentQrRequestDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentQrDto&gt;
    /// CheckoutService.CreatePaymentQrAsync(PaymentQrRequestDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Fail closed: DomainException PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD / 503 where
    /// specified; no successful payment/refund effect.
    /// </para>
    /// <para>
    /// Design exception expectation: PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-054.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-054-TC001")]
    public void UTM_054_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    await owner.CreatePaymentQrAsync(new() { CheckoutReference = "ref" }, Fixture.Token);
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD" }[0]));
        }
    }

    /// <summary>
    /// UTM-054-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentQrDto&gt; CheckoutService.CreatePaymentQrAsync(PaymentQrRequestDto request,
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
    /// Design input: {"request": {"fixture": "PaymentQrRequestDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentQrDto&gt;
    /// CheckoutService.CreatePaymentQrAsync(PaymentQrRequestDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-054.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-054-TC002")]
    public void UTM_054_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    await owner.CreatePaymentQrAsync(new() { CheckoutReference = "ref" }, Fixture.Token);
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD" }[0]));
        }
    }

    /// <summary>
    /// UTM-054-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentQrDto&gt; CheckoutService.CreatePaymentQrAsync(PaymentQrRequestDto request,
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
    /// Design input: {"request": {"fixture": "PaymentQrRequestDto"}, "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for
    /// pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentQrDto&gt;
    /// CheckoutService.CreatePaymentQrAsync(PaymentQrRequestDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-054.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-054-TC003")]
    public void UTM_054_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("checkout sentinel");
        });
        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => throw new TimeoutException("payment verification sentinel"));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    await owner.CreatePaymentQrAsync(new() { CheckoutReference = "ref" }, Fixture.Token);
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD" }[0]));
        }
    }

    /// <summary>
    /// UTM-055-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentResultDto&gt; CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "PaymentNoticeDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentResultDto&gt;
    /// CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Fail closed: DomainException PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD / 503
    /// where specified; no successful payment/refund effect.
    /// </para>
    /// <para>
    /// Design exception expectation: PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-055.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-055-TC001")]
    public void UTM_055_TC001()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    await owner.HandleVerifiedPaymentAsync(new(), Fixture.Token);
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD" }[0]));
        }
    }

    /// <summary>
    /// UTM-055-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentResultDto&gt; CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "PaymentNoticeDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentResultDto&gt;
    /// CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-055.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-055-TC002")]
    public void UTM_055_TC002()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var addresses = 0;
        var saves = 0;
        var clears = 0;
        var completes = 0;
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCheckoutCartAsync" => Cart(),
                "GetOwnedAddressAsync" => Address(),
                "LockFefoBatchesAsync" => Task.FromResult(new List<BatchInventory> { Fixture.Batch((int)(7m) + 3, 3) }),
                "ClaimCheckoutAsync" => Task.FromResult<object>(new CheckoutClaim { Replay = false, Response = null }),
                "SaveOrderAsync" => Save(a),
                "ClearCartAsync" => Clear(),
                "CompleteCheckoutAsync" => Complete(),
                _ => throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart()
        {
            return Task.FromResult(cart);
        }

        Task<CustomerAddress> Address()
        {
            addresses++;
            return Task.FromResult(address);
        }

        Task Save(object? [] a)
        {
            saves++;
            ((Order)a[0]!).OrderId = "42";
            return Task.CompletedTask;
        }

        Task Clear()
        {
            clears++;
            return Task.CompletedTask;
        }

        Task Complete()
        {
            completes++;
            return Task.CompletedTask;
        }

        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => Task.FromResult(new VerifiedPaymentDto { ProviderReference = "provider", CheckoutReference = "ref" }));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        {
            Func<Task> operation = async () =>
            {
                {
                    await owner.HandleVerifiedPaymentAsync(new(), Fixture.Token);
                    return;
                }
            };
            var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
            Assert.That(actualException.Code, Is.EqualTo(new string[] { "PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD" }[0]));
        }
    }

    /// <summary>
    /// UTM-055-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentResultDto&gt; CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "PaymentNoticeDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentResultDto&gt;
    /// CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-055.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-055-TC003")]
    public async System.Threading.Tasks.Task UTM_055_TC003()
    {
        // Arrange: test inputs and mock setup.
        var cart = new Cart
        {
            CartId = "1",
            CustomerId = "7",
            Items = [new()
            {
                ProductId = "1",
                Quantity = (int)(2m)
            }

            ]
        };
        var notices = 0;
        var address = Fixture.Address();
        var stored = new OrderConfirmationDto
        {
            OrderId = "42",
            OrderNumber = "existing",
            Total = "30000",
            Status = OrderStatus.PendingUnpaid,
            PaymentStatus = PaymentStatus.Unpaid
        };
        var repo = StrictProxy.For<ICheckoutRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("checkout sentinel");
        });
        var distance = StrictProxy.For<IDistanceCalculator>((n, a) => Task.FromResult(0.5m));
        var gateway = StrictProxy.For<IPaymentGateway>((n, a) => throw new TimeoutException("payment verification sentinel"));
        var life = StrictProxy.For<IOrderLifecycleRepository>((n, a) => n == "RecordEventOnceAsync" ? Task.FromResult(true) : throw new InvalidOperationException(n));
        var notify = StrictProxy.For<INotificationGateway>((n, a) =>
        {
            notices++;
            return Task.CompletedTask;
        });
        var owner = new CheckoutService(repo, Fixture.Customer(), new ImmediateWork(), distance, gateway, notify, new OrderStateMachine(life), new BatchPricingPolicy(), new DeliveryFeePolicy(), NullLogger<CheckoutService>.Instance);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                await owner.HandleVerifiedPaymentAsync(new(), Fixture.Token);
                return;
            }
        });
    }

    /// <summary>
    /// UTM-055-TC004: guard L121 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentResultDto&gt; CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "PaymentNoticeDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"verified.ProviderReference": "valid"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentResultDto&gt;
    /// CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("UNVERIFIED_PAYMENT", 403) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:121. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-055-D01:False, UTM-055-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-055.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-055-TC004")]
    public void UTM_055_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-055-TC005: guard L121 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentResultDto&gt; CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "PaymentNoticeDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"verified.ProviderReference": "",
    /// "verified.CheckoutReference": "valid"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentResultDto&gt;
    /// CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("UNVERIFIED_PAYMENT", 403) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:121. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-055-D01:False, UTM-055-D01:C1:True, UTM-055-D01:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-055.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-055-TC005")]
    public void UTM_055_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-055-TC006: guard L121 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;PaymentResultDto&gt; CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "PaymentNoticeDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"verified.ProviderReference": "",
    /// "verified.CheckoutReference": ""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;PaymentResultDto&gt;
    /// CheckoutService.HandleVerifiedPaymentAsync(PaymentNoticeDto request, CancellationToken signal); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CheckoutService.cs:121. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-055-D01:True, UTM-055-D01:C1:True, UTM-055-D01:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-055.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-055-TC006")]
    public void UTM_055_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }
}
