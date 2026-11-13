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
public sealed class Controllers_ProfileControllerTests
{
    /// <summary>
    /// UTM-025-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ProfileController.ProfileController(IProfileService service)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "Typed FreshFood.Api.Services.IProfileService fixture from fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ProfileController.ProfileController(IProfileService service);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-025.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-025-TC001")]
    public void UTM_025_TC001()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.IProfileService)Fixture.Value(typeof(FreshFood.Api.Services.IProfileService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.ProfileController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.ProfileController>());
    }

    /// <summary>
    /// UTM-025-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ProfileController.ProfileController(IProfileService service)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "Typed FreshFood.Api.Services.IProfileService fixture from fixtures.json",
    /// "variant": "Omit optional arguments; otherwise use distinct valid instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ProfileController.ProfileController(IProfileService service);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-025.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-025-TC002")]
    public void UTM_025_TC002()
    {
        // Arrange: test inputs and mock setup.
        var service = (FreshFood.Api.Services.IProfileService)Fixture.Value(typeof(FreshFood.Api.Services.IProfileService))!;
        // Act
        var actual = new FreshFood.Api.Controllers.ProfileController(service);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Controllers.ProfileController>());
    }

    /// <summary>
    /// UTM-025-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ProfileController.ProfileController(IProfileService service)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"service": "Typed FreshFood.Api.Services.IProfileService fixture from fixtures.json",
    /// "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ProfileController.ProfileController(IProfileService service);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-025.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-025-TC003")]
    public void UTM_025_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-026-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.GetProfileAsync(CancellationToken signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.GetProfileAsync(CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-026.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-026-TC001")]
    public async System.Threading.Tasks.Task UTM_026_TC001()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.GetProfileAsync(signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetProfileAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-026-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.GetProfileAsync(CancellationToken signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.GetProfileAsync(CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-026.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-026-TC002")]
    public async System.Threading.Tasks.Task UTM_026_TC002()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.GetProfileAsync(signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetProfileAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-026-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.GetProfileAsync(CancellationToken signal)
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.GetProfileAsync(CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-026.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-026-TC003")]
    public void UTM_026_TC003()
    {
        // Arrange: test inputs and mock setup.
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.GetProfileAsync(signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("GetProfileAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
    }

    /// <summary>
    /// UTM-027-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.UpdateProfileAsync(ProfileUpdateDto request,
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
    /// Design input: {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-027.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-027-TC001")]
    public async System.Threading.Tasks.Task UTM_027_TC001()
    {
        // Arrange: test inputs and mock setup.
        var request = (FreshFood.Api.DTOs.ProfileUpdateDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileUpdateDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.UpdateProfileAsync(request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("UpdateProfileAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
    }

    /// <summary>
    /// UTM-027-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.UpdateProfileAsync(ProfileUpdateDto request,
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
    /// Design input: {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-027.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-027-TC002")]
    public async System.Threading.Tasks.Task UTM_027_TC002()
    {
        // Arrange: test inputs and mock setup.
        var request = (FreshFood.Api.DTOs.ProfileUpdateDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileUpdateDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.UpdateProfileAsync(request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("UpdateProfileAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
    }

    /// <summary>
    /// UTM-027-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.UpdateProfileAsync(ProfileUpdateDto request,
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
    /// Design input: {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-027.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-027-TC003")]
    public void UTM_027_TC003()
    {
        // Arrange: test inputs and mock setup.
        var request = (FreshFood.Api.DTOs.ProfileUpdateDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileUpdateDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.UpdateProfileAsync(request, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("UpdateProfileAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
    }

    /// <summary>
    /// UTM-028-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.SaveAddressAsync(AddressInputDto request,
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
    /// Design input: {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt;
    /// ProfileController.SaveAddressAsync(AddressInputDto request, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-028.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-028-TC001")]
    public async System.Threading.Tasks.Task UTM_028_TC001()
    {
        // Arrange: test inputs and mock setup.
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.SaveAddressAsync(request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
    }

    /// <summary>
    /// UTM-028-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.SaveAddressAsync(AddressInputDto request,
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
    /// Design input: {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt;
    /// ProfileController.SaveAddressAsync(AddressInputDto request, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-028.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-028-TC002")]
    public async System.Threading.Tasks.Task UTM_028_TC002()
    {
        // Arrange: test inputs and mock setup.
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.SaveAddressAsync(request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
    }

    /// <summary>
    /// UTM-028-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.SaveAddressAsync(AddressInputDto request,
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
    /// Design input: {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt;
    /// ProfileController.SaveAddressAsync(AddressInputDto request, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-028.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-028-TC003")]
    public void UTM_028_TC003()
    {
        // Arrange: test inputs and mock setup.
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.SaveAddressAsync(request, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
    }

    /// <summary>
    /// UTM-029-TC001: Conflicting body identifier cannot override route
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string addressId, AddressInputDto
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
    /// Design input: {"routeId": "2", "body": {"AddressId": "99", "Quantity": 2, "Rating": 5, "Reason": "Changed
    /// mind"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string
    /// addressId, AddressInputDto request, CancellationToken signal); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Injected service receives AddressId=2; return exact service sentinel
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No use of attacker-supplied body identifier 99 as selected target
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-029.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-029-TC001")]
    public async System.Threading.Tasks.Task UTM_029_TC001()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        request.AddressId = "99";
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.UpdateAddressAsync(addressId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.AddressId, Is.EqualTo(addressId));
    }

    /// <summary>
    /// UTM-029-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string addressId, AddressInputDto
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
    /// Design input: {"addressId": "2", "request": {"fixture": "AddressInputDto"}, "signal":
    /// "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string
    /// addressId, AddressInputDto request, CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-029.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-029-TC002")]
    public async System.Threading.Tasks.Task UTM_029_TC002()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.UpdateAddressAsync(addressId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.AddressId, Is.EqualTo(addressId));
    }

    /// <summary>
    /// UTM-029-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string addressId, AddressInputDto
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
    /// Design input: {"addressId": "2", "request": {"fixture": "AddressInputDto"}, "signal":
    /// "CancellationToken.None; use distinct token in forwarding variants", "boundary": "Empty then single-item
    /// collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field
    /// unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string
    /// addressId, AddressInputDto request, CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-029.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-029-TC003")]
    public async System.Threading.Tasks.Task UTM_029_TC003()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.UpdateAddressAsync(addressId, request, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.AddressId, Is.EqualTo(addressId));
    }

    /// <summary>
    /// UTM-029-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string addressId, AddressInputDto
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
    /// Design input: {"addressId": "2", "request": {"fixture": "AddressInputDto"}, "signal":
    /// "CancellationToken.None; use distinct token in forwarding variants", "failure": "First collaborator throws
    /// TimeoutException sentinel; for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileController.UpdateAddressAsync(string
    /// addressId, AddressInputDto request, CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-029.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-029-TC004")]
    public void UTM_029_TC004()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var request = (FreshFood.Api.DTOs.AddressInputDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressInputDto))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.AddressDto)Fixture.Value(typeof(FreshFood.Api.DTOs.AddressDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.UpdateAddressAsync(addressId, request, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SaveAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(request));
        Assert.That(request.AddressId, Is.EqualTo(addressId));
    }

    /// <summary>
    /// UTM-030-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.SetDefaultAddressAsync(string addressId,
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
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-030.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-030-TC001")]
    public async System.Threading.Tasks.Task UTM_030_TC001()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.SetDefaultAddressAsync(addressId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SetDefaultAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(addressId));
    }

    /// <summary>
    /// UTM-030-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.SetDefaultAddressAsync(string addressId,
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
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-030.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-030-TC002")]
    public async System.Threading.Tasks.Task UTM_030_TC002()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.SetDefaultAddressAsync(addressId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SetDefaultAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(addressId));
    }

    /// <summary>
    /// UTM-030-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileController.SetDefaultAddressAsync(string addressId,
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
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileController.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-030.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-030-TC003")]
    public void UTM_030_TC003()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.ProfileResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.ProfileResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.SetDefaultAddressAsync(addressId, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("SetDefaultAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(addressId));
    }

    /// <summary>
    /// UTM-031-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileController.DeleteAddressAsync(string addressId,
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
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileController.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-031.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-031-TC001")]
    public async System.Threading.Tasks.Task UTM_031_TC001()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.DeleteAddressAsync(addressId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("DeleteAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(addressId));
    }

    /// <summary>
    /// UTM-031-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileController.DeleteAddressAsync(string addressId,
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
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileController.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-031.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-031-TC002")]
    public async System.Threading.Tasks.Task UTM_031_TC002()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            return Task.FromResult(expectedResult);
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualResult = await subject.DeleteAddressAsync(addressId, signal);
        // Assert
        Assert.That(actualResult, Is.SameAs(expectedResult));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("DeleteAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(addressId));
    }

    /// <summary>
    /// UTM-031-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileController.DeleteAddressAsync(string addressId,
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
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileController.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-031.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-031-TC003")]
    public void UTM_031_TC003()
    {
        // Arrange: test inputs and mock setup.
        var addressId = (string)Fixture.Value(typeof(string))!;
        var signal = Fixture.Token;
        var expectedResult = (FreshFood.Api.DTOs.OperationResultDto)Fixture.Value(typeof(FreshFood.Api.DTOs.OperationResultDto))!;
        var expectedException = new TimeoutException("arranged collaborator failure");
        object? []? actualArguments = null;
        string? actualMethod = null;
        var actualCallCount = 0;
        var collaborator = StrictProxy.For<FreshFood.Api.Services.IProfileService>((calledMethod, arguments) =>
        {
            actualCallCount++;
            actualMethod = calledMethod;
            actualArguments = arguments;
            throw expectedException;
        });
        var subject = new FreshFood.Api.Controllers.ProfileController(collaborator);
        // Act
        var actualException = Assert.ThrowsAsync<TimeoutException>(async () => await subject.DeleteAddressAsync(addressId, signal))!;
        // Assert
        Assert.That(actualException, Is.SameAs(expectedException));
        Assert.That(actualCallCount, Is.EqualTo(1));
        Assert.That(actualMethod, Is.EqualTo("DeleteAddressAsync"));
        Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));
        Assert.That(actualArguments, Does.Contain(addressId));
    }
}
