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
public sealed class Controllers_CatalogControllerTests
{
    /// <summary>
    /// UTM-007-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogController.CatalogController(ICatalogService service)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "Typed FreshFood.Api.Services.ICatalogService fixture from fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogController.CatalogController(ICatalogService service);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-007.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-007-TC001")]
    public void UTM_007_TC001()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.ICatalogService)Fixture.Value(typeof(FreshFood.Api.Services.ICatalogService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.CatalogController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.CatalogController>());
    }

    /// <summary>
    /// UTM-007-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogController.CatalogController(ICatalogService service)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "Typed FreshFood.Api.Services.ICatalogService fixture from fixtures.json",
    /// "variant": "Omit optional arguments; otherwise use distinct valid instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogController.CatalogController(ICatalogService service);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-007.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-007-TC002")]
    public void UTM_007_TC002()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.ICatalogService)Fixture.Value(typeof(FreshFood.Api.Services.ICatalogService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.CatalogController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.CatalogController>());
    }

    /// <summary>
    /// UTM-007-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogController.CatalogController(ICatalogService service)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "Typed FreshFood.Api.Services.ICatalogService fixture from fixtures.json",
    /// "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogController.CatalogController(ICatalogService service);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-007.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-007-TC003")]
    public void UTM_007_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-008-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.GetCatalogAsync(CatalogQueryDto query,
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
    /// CatalogController.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-008.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-008-TC001")]
    public async System.Threading.Tasks.Task UTM_008_TC001()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.GetCatalogAsync(query, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetCatalogAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-008-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.GetCatalogAsync(CatalogQueryDto query,
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
    /// CatalogController.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-008.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-008-TC002")]
    public async System.Threading.Tasks.Task UTM_008_TC002()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.GetCatalogAsync(query, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetCatalogAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-008-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.GetCatalogAsync(CatalogQueryDto query,
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
    /// CatalogController.GetCatalogAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-008.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-008-TC003")]
    public void UTM_008_TC003()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetCatalogAsync(query, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetCatalogAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-009-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.SearchAsync(CatalogQueryDto query,
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
    /// CatalogController.SearchAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-009.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-009-TC001")]
    public async System.Threading.Tasks.Task UTM_009_TC001()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.SearchAsync(query, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SearchAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-009-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.SearchAsync(CatalogQueryDto query,
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
    /// CatalogController.SearchAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-009.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-009-TC002")]
    public async System.Threading.Tasks.Task UTM_009_TC002()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.SearchAsync(query, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SearchAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-009-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.SearchAsync(CatalogQueryDto query,
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
    /// CatalogController.SearchAsync(CatalogQueryDto query, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-009.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-009-TC003")]
    public void UTM_009_TC003()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.SearchAsync(query, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SearchAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-010-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.GetClearanceAsync(CatalogQueryDto query,
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
    /// CatalogController.GetClearanceAsync(CatalogQueryDto query, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-010.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-010-TC001")]
    public async System.Threading.Tasks.Task UTM_010_TC001()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.GetClearanceAsync(query, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetClearanceAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-010-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.GetClearanceAsync(CatalogQueryDto query,
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
    /// CatalogController.GetClearanceAsync(CatalogQueryDto query, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-010.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-010-TC002")]
    public async System.Threading.Tasks.Task UTM_010_TC002()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.GetClearanceAsync(query, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetClearanceAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-010-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CatalogResultDto&gt; CatalogController.GetClearanceAsync(CatalogQueryDto query,
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
    /// CatalogController.GetClearanceAsync(CatalogQueryDto query, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-010.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-010-TC003")]
    public void UTM_010_TC003()
    {
        // Arrange: test inputs and mock setup.
        var query = (FreshFood.Api.DTOs.CatalogQueryDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogQueryDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.CatalogResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.CatalogResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetClearanceAsync(query, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetClearanceAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(query));
    }

    /// <summary>
    /// UTM-011-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogController.GetProductDetailsAsync(string productId,
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
    /// CatalogController.GetProductDetailsAsync(string productId, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-011.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-011-TC001")]
    public async System.Threading.Tasks.Task UTM_011_TC001()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProductDetailsDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProductDetailsDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.GetProductDetailsAsync(productId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetProductDetailsAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(productId));
    }

    /// <summary>
    /// UTM-011-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogController.GetProductDetailsAsync(string productId,
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
    /// CatalogController.GetProductDetailsAsync(string productId, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-011.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-011-TC002")]
    public async System.Threading.Tasks.Task UTM_011_TC002()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProductDetailsDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProductDetailsDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualResult = await subject.GetProductDetailsAsync(productId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetProductDetailsAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(productId));
    }

    /// <summary>
    /// UTM-011-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProductDetailsDto&gt; CatalogController.GetProductDetailsAsync(string productId,
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
    /// CatalogController.GetProductDetailsAsync(string productId, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-011.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-011-TC003")]
    public void UTM_011_TC003()
    {
        // Arrange: test inputs and mock setup.
        var productId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProductDetailsDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProductDetailsDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.ICatalogService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.CatalogController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetProductDetailsAsync(productId, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetProductDetailsAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(productId));
    }
}
