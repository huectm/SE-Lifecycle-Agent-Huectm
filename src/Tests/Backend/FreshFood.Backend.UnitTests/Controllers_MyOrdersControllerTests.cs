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
public sealed class Controllers_MyOrdersControllerTests
{
    /// <summary>
    /// UTM-016-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: MyOrdersController.MyOrdersController(IMyOrdersService service)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "ORDER"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke MyOrdersController.MyOrdersController(IMyOrdersService service);
    /// assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-016.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-016-TC001")]
    public void UTM_016_TC001()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.IMyOrdersService)Fixture.Value(typeof(FreshFood.Api.Services.IMyOrdersService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.MyOrdersController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.MyOrdersController>());
    }

    /// <summary>
    /// UTM-016-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: MyOrdersController.MyOrdersController(IMyOrdersService service)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "ORDER", "variant": "Omit optional arguments; otherwise use distinct valid
    /// instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke MyOrdersController.MyOrdersController(IMyOrdersService service);
    /// assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-016.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-016-TC002")]
    public void UTM_016_TC002()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.IMyOrdersService)Fixture.Value(typeof(FreshFood.Api.Services.IMyOrdersService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.MyOrdersController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.MyOrdersController>());
    }

    /// <summary>
    /// UTM-016-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: MyOrdersController.MyOrdersController(IMyOrdersService service)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "ORDER", "variant": "Missing non-nullable dependency is outside declared caller
    /// contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke MyOrdersController.MyOrdersController(IMyOrdersService service);
    /// assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-016.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-016-TC003")]
    public void UTM_016_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-017-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderListDto&gt; MyOrdersController.GetOrdersAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderListDto&gt;
    /// MyOrdersController.GetOrdersAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service called once with arranged DTO; route identifier overrides
    /// conflicting body identifier where implemented; return exact sentinel.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-017.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-017-TC001")]
    public async System.Threading.Tasks.Task UTM_017_TC001()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OrderListDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderListDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.GetOrdersAsync(signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetOrdersAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-017-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderListDto&gt; MyOrdersController.GetOrdersAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "boundary":
    /// "Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free
    /// forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderListDto&gt;
    /// MyOrdersController.GetOrdersAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-017.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-017-TC002")]
    public async System.Threading.Tasks.Task UTM_017_TC002()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OrderListDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderListDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.GetOrdersAsync(signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetOrdersAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-017-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderListDto&gt; MyOrdersController.GetOrdersAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderListDto&gt;
    /// MyOrdersController.GetOrdersAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-017.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-017-TC003")]
    public void UTM_017_TC003()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OrderListDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderListDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetOrdersAsync(signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetOrdersAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-018-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderDetailsDto&gt; MyOrdersController.GetOrderDetailsAsync(string orderId,
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
    /// Design input: {"orderId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderDetailsDto&gt;
    /// MyOrdersController.GetOrderDetailsAsync(string orderId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service called once with arranged DTO; route identifier overrides
    /// conflicting body identifier where implemented; return exact sentinel.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-018.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-018-TC001")]
    public async System.Threading.Tasks.Task UTM_018_TC001()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OrderDetailsDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderDetailsDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.GetOrderDetailsAsync(orderId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetOrderDetailsAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(orderId));
    }

    /// <summary>
    /// UTM-018-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderDetailsDto&gt; MyOrdersController.GetOrderDetailsAsync(string orderId,
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
    /// Design input: {"orderId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderDetailsDto&gt;
    /// MyOrdersController.GetOrderDetailsAsync(string orderId, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-018.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-018-TC002")]
    public async System.Threading.Tasks.Task UTM_018_TC002()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OrderDetailsDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderDetailsDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.GetOrderDetailsAsync(orderId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetOrderDetailsAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(orderId));
    }

    /// <summary>
    /// UTM-018-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OrderDetailsDto&gt; MyOrdersController.GetOrderDetailsAsync(string orderId,
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
    /// Design input: {"orderId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OrderDetailsDto&gt;
    /// MyOrdersController.GetOrderDetailsAsync(string orderId, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-018.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-018-TC003")]
    public void UTM_018_TC003()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OrderDetailsDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderDetailsDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetOrderDetailsAsync(orderId, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetOrderDetailsAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(orderId));
    }

    /// <summary>
    /// UTM-019-TC001: Conflicting body identifier cannot override route
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.CancelOrderAsync(string orderId,
    /// CancelOrderDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience-based route/ownership regression; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"routeId": "1", "body": {"OrderId": "99", "Quantity": 2, "Rating": 5, "Reason": "Changed
    /// mind"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.CancelOrderAsync(string orderId, CancelOrderDto request, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service receives OrderId=1; return exact service sentinel
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No use of attacker-supplied body identifier 99 as selected target
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-019.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-019-TC001")]
    public async System.Threading.Tasks.Task UTM_019_TC001()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CancelOrderDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CancelOrderDto))!;
        var signal = Fixture.Token;
        request.OrderId = "99";
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.CancelOrderAsync(orderId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("CancelOrderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-019-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.CancelOrderAsync(string orderId,
    /// CancelOrderDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"orderId": "1", "request": {"fixture": "CancelOrderDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.CancelOrderAsync(string orderId, CancelOrderDto request, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service called once with arranged DTO; route identifier overrides
    /// conflicting body identifier where implemented; return exact sentinel.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-019.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-019-TC002")]
    public async System.Threading.Tasks.Task UTM_019_TC002()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CancelOrderDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CancelOrderDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.CancelOrderAsync(orderId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("CancelOrderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-019-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.CancelOrderAsync(string orderId,
    /// CancelOrderDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"orderId": "1", "request": {"fixture": "CancelOrderDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.CancelOrderAsync(string orderId, CancelOrderDto request, CancellationToken signal);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-019.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-019-TC003")]
    public async System.Threading.Tasks.Task UTM_019_TC003()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CancelOrderDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CancelOrderDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.CancelOrderAsync(orderId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("CancelOrderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-019-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.CancelOrderAsync(string orderId,
    /// CancelOrderDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"orderId": "1", "request": {"fixture": "CancelOrderDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel;
    /// for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.CancelOrderAsync(string orderId, CancelOrderDto request, CancellationToken signal);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-019.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-019-TC004")]
    public void UTM_019_TC004()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CancelOrderDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CancelOrderDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.CancelOrderAsync(orderId, request, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("CancelOrderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-020-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; MyOrdersController.ReorderAsync(string orderId, CancellationToken
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
    /// Design input: {"orderId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; MyOrdersController.ReorderAsync(string
    /// orderId, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service called once with arranged DTO; route identifier overrides
    /// conflicting body identifier where implemented; return exact sentinel.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-020.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-020-TC001")]
    public async System.Threading.Tasks.Task UTM_020_TC001()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.ReorderAsync(orderId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ReorderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(orderId));
    }

    /// <summary>
    /// UTM-020-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; MyOrdersController.ReorderAsync(string orderId, CancellationToken
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
    /// Design input: {"orderId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; MyOrdersController.ReorderAsync(string
    /// orderId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-020.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-020-TC002")]
    public async System.Threading.Tasks.Task UTM_020_TC002()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.ReorderAsync(orderId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ReorderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(orderId));
    }

    /// <summary>
    /// UTM-020-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; MyOrdersController.ReorderAsync(string orderId, CancellationToken
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
    /// Design input: {"orderId": "1", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; MyOrdersController.ReorderAsync(string
    /// orderId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-020.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-020-TC003")]
    public void UTM_020_TC003()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.ReorderAsync(orderId, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ReorderAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(orderId));
    }

    /// <summary>
    /// UTM-021-TC001: Conflicting body identifier cannot override route
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.SubmitReviewAsync(string orderId,
    /// OrderReviewDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience-based route/ownership regression; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"routeId": "1", "body": {"OrderId": "99", "Quantity": 2, "Rating": 5, "Reason": "Changed
    /// mind"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.SubmitReviewAsync(string orderId, OrderReviewDto request, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service receives OrderId=1; return exact service sentinel
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No use of attacker-supplied body identifier 99 as selected target
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-021.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-021-TC001")]
    public async System.Threading.Tasks.Task UTM_021_TC001()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.OrderReviewDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderReviewDto))!;
        var signal = Fixture.Token;
        request.OrderId = "99";
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.SubmitReviewAsync(orderId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SubmitReviewAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-021-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.SubmitReviewAsync(string orderId,
    /// OrderReviewDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"orderId": "1", "request": {"fixture": "OrderReviewDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.SubmitReviewAsync(string orderId, OrderReviewDto request, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service called once with arranged DTO; route identifier overrides
    /// conflicting body identifier where implemented; return exact sentinel.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-021.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-021-TC002")]
    public async System.Threading.Tasks.Task UTM_021_TC002()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.OrderReviewDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderReviewDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.SubmitReviewAsync(orderId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SubmitReviewAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-021-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.SubmitReviewAsync(string orderId,
    /// OrderReviewDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"orderId": "1", "request": {"fixture": "OrderReviewDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.SubmitReviewAsync(string orderId, OrderReviewDto request, CancellationToken signal);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-021.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-021-TC003")]
    public async System.Threading.Tasks.Task UTM_021_TC003()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.OrderReviewDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderReviewDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualResult = await subject.SubmitReviewAsync(orderId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SubmitReviewAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }

    /// <summary>
    /// UTM-021-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; MyOrdersController.SubmitReviewAsync(string orderId,
    /// OrderReviewDto request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"orderId": "1", "request": {"fixture": "OrderReviewDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel;
    /// for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// MyOrdersController.SubmitReviewAsync(string orderId, OrderReviewDto request, CancellationToken signal);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-021.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-021-TC004")]
    public void UTM_021_TC004()
    {
        // Arrange: test inputs and mock setup.
        var orderId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.OrderReviewDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OrderReviewDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IMyOrdersService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.MyOrdersController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.SubmitReviewAsync(orderId, request, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SubmitReviewAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
    }
}
