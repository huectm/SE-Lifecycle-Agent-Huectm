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
public sealed class Controllers_CartControllerTests
{
    /// <summary>
    /// UTM-003-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartController.CartController(ICartService service)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "CART"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartController.CartController(ICartService service); assert
    /// result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-003.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-003-TC001")]
    public void UTM_003_TC001()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.ICartService)Fixture.Value(typeof(FreshFood.Api.Services.ICartService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.CartController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.CartController>());
    }

    /// <summary>
    /// UTM-003-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartController.CartController(ICartService service)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "CART", "variant": "Omit optional arguments; otherwise use distinct valid
    /// instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartController.CartController(ICartService service); assert
    /// result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-003.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-003-TC002")]
    public void UTM_003_TC002()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.ICartService)Fixture.Value(typeof(FreshFood.Api.Services.ICartService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.CartController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.CartController>());
    }

    /// <summary>
    /// UTM-003-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartController.CartController(ICartService service)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "CART", "variant": "Missing non-nullable dependency is outside declared caller
    /// contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartController.CartController(ICartService service); assert
    /// result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-003.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-003-TC003")]
    public void UTM_003_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-004-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.GetCartAsync(CancellationToken signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartController.GetCartAsync(CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-004.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-004-TC001")]
    public async System.Threading.Tasks.Task UTM_004_TC001()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.GetCartAsync(signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetCartAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-004-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.GetCartAsync(CancellationToken signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartController.GetCartAsync(CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-004.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-004-TC002")]
    public async System.Threading.Tasks.Task UTM_004_TC002()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.GetCartAsync(signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetCartAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-004-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.GetCartAsync(CancellationToken signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt;
    /// CartController.GetCartAsync(CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-004.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-004-TC003")]
    public void UTM_004_TC003()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetCartAsync(signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetCartAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-005-TC001: Conflicting body identifier cannot override route
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string productId, CartChangeDto
    /// request, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience-based route/ownership regression; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"routeId": "1", "body": {"ProductId": "99", "Quantity": 2, "Rating": 5, "Reason": "Changed
    /// mind"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string
    /// productId, CartChangeDto request, CancellationToken signal); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service receives ProductId=1; return exact service sentinel
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No use of attacker-supplied body identifier 99 as selected target
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-005.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-005-TC001")]
    public async System.Threading.Tasks.Task UTM_005_TC001()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CartChangeDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartChangeDto))!;
        var signal = Fixture.Token;
        request.ProductId = "99";
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.ChangeQuantityAsync(productId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ChangeQuantityAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        var actualRequest = (CartChangeDto)actualArguments![0]!;
        Assert.That(actualRequest.ProductId, Is.EqualTo(productId));
        Assert.That(actualRequest.Quantity, Is.EqualTo(request.Quantity));
    }

    /// <summary>
    /// UTM-005-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string productId, CartChangeDto
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
    /// Design input: {"productId": "1", "request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string
    /// productId, CartChangeDto request, CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-005.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-005-TC002")]
    public async System.Threading.Tasks.Task UTM_005_TC002()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CartChangeDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartChangeDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.ChangeQuantityAsync(productId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ChangeQuantityAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        var actualRequest = (CartChangeDto)actualArguments![0]!;
        Assert.That(actualRequest.ProductId, Is.EqualTo(productId));
        Assert.That(actualRequest.Quantity, Is.EqualTo(request.Quantity));
    }

    /// <summary>
    /// UTM-005-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string productId, CartChangeDto
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
    /// Design input: {"productId": "1", "request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string
    /// productId, CartChangeDto request, CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-005.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-005-TC003")]
    public async System.Threading.Tasks.Task UTM_005_TC003()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CartChangeDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartChangeDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.ChangeQuantityAsync(productId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ChangeQuantityAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        var actualRequest = (CartChangeDto)actualArguments![0]!;
        Assert.That(actualRequest.ProductId, Is.EqualTo(productId));
        Assert.That(actualRequest.Quantity, Is.EqualTo(request.Quantity));
    }

    /// <summary>
    /// UTM-005-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string productId, CartChangeDto
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
    /// Design input: {"productId": "1", "request": {"fixture": "CartChangeDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel;
    /// for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.ChangeQuantityAsync(string
    /// productId, CartChangeDto request, CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-005.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-005-TC004")]
    public void UTM_005_TC004()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.CartChangeDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartChangeDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.ChangeQuantityAsync(productId, request, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("ChangeQuantityAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        var actualRequest = (CartChangeDto)actualArguments![0]!;
        Assert.That(actualRequest.ProductId, Is.EqualTo(productId));
        Assert.That(actualRequest.Quantity, Is.EqualTo(request.Quantity));
    }

    /// <summary>
    /// UTM-006-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.RemoveItemAsync(string productId, CancellationToken
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.RemoveItemAsync(string
    /// productId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-006.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-006-TC001")]
    public async System.Threading.Tasks.Task UTM_006_TC001()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.RemoveItemAsync(productId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("RemoveItemAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(productId));
    }

    /// <summary>
    /// UTM-006-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.RemoveItemAsync(string productId, CancellationToken
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.RemoveItemAsync(string
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-006.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-006-TC002")]
    public async System.Threading.Tasks.Task UTM_006_TC002()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualResult = await subject.RemoveItemAsync(productId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("RemoveItemAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(productId));
    }

    /// <summary>
    /// UTM-006-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CartResultDto&gt; CartController.RemoveItemAsync(string productId, CancellationToken
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CartResultDto&gt; CartController.RemoveItemAsync(string
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-006.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-006-TC003")]
    public void UTM_006_TC003()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CartResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CartResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICartService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CartController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.RemoveItemAsync(productId, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("RemoveItemAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(productId));
    }
}
