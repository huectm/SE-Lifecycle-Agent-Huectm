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
public sealed class Entities_DeliveryFeePolicyTests
{
    /// <summary>
    /// UTM-111-TC001: Distance -0.001
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": -0.001}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject outside service area
    /// </para>
    /// <para>
    /// Design exception expectation: OUTSIDE_DELIVERY_AREA
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC001")]
    public void UTM_111_TC001()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = -0.001m;
        var subject = new DeliveryFeePolicy();
        var expectedErrorCode = "OUTSIDE_DELIVERY_AREA";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Quote(distanceKm))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-111-TC002: Distance 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 0}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: VndAmount=10000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC002")]
    public void UTM_111_TC002()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 0m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC003: Distance 0.999
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 0.999}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: VndAmount=10000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC003")]
    public void UTM_111_TC003()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 0.999m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC004: Distance 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 1}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: VndAmount=20000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC004")]
    public void UTM_111_TC004()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 1m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC005: Distance 2.999
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 2.999}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: VndAmount=20000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC005")]
    public void UTM_111_TC005()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 2.999m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC006: Distance 3
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 3}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: VndAmount=30000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC006")]
    public void UTM_111_TC006()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 3m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 30000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC007: Distance 10
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 10}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: VndAmount=30000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC007")]
    public void UTM_111_TC007()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 10m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 30000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC008: Distance 10.001
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 10.001}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject outside service area
    /// </para>
    /// <para>
    /// Design exception expectation: OUTSIDE_DELIVERY_AREA
    /// </para>
    /// <para>
    /// Expected side effects: No mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC008")]
    public void UTM_111_TC008()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 10.001m;
        var subject = new DeliveryFeePolicy();
        var expectedErrorCode = "OUTSIDE_DELIVERY_AREA";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Quote(distanceKm))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-111-TC009: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 1}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: distanceKm=1 returns VndAmount(20000)
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC009")]
    public void UTM_111_TC009()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 1m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC010: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 1, "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC010")]
    public void UTM_111_TC010()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 1m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC011: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"distanceKm": 1, "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC011")]
    public void UTM_111_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-111-TC012: switch-arm L67 -&gt; &lt; 0 or &gt; 10
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"distanceKm": 1}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "&lt; 0 or &gt; 10", "expression": "&lt; 0 or &gt; 10 =&gt;
    /// throw new DomainException(\"OUTSIDE_DELIVERY_AREA\", 422)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: throw new DomainException("OUTSIDE_DELIVERY_AREA", 422) | Assert selected outcome &lt;
    /// 0 or &gt; 10 at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:67. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("OUTSIDE_DELIVERY_AREA", 422)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"distanceKm": -0.001}
    /// </para>
    /// <para>
    /// Concrete exception expectation: OUTSIDE_DELIVERY_AREA
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-111-D01:&lt; 0 or &gt; 10
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC012")]
    public void UTM_111_TC012()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = -0.001m;
        var subject = new DeliveryFeePolicy();
        var expectedErrorCode = "OUTSIDE_DELIVERY_AREA";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Quote(distanceKm))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-111-TC013: switch-arm L68 -&gt; &lt; 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"distanceKm": 1}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "&lt; 1", "expression": "&lt; 1 =&gt; new(10000)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: new(10000) | Assert selected outcome &lt; 1 at
    /// src/FreshFood.Reposistory/Entities/DomainBehavior.cs:68. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("OUTSIDE_DELIVERY_AREA", 422)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"distanceKm": 0.5}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-111-D02:&lt; 1
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC013")]
    public void UTM_111_TC013()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 0.5m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC014: switch-arm L69 -&gt; &lt; 3
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"distanceKm": 1}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "&lt; 3", "expression": "&lt; 3 =&gt; new(20000)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: new(20000) | Assert selected outcome &lt; 3 at
    /// src/FreshFood.Reposistory/Entities/DomainBehavior.cs:69. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("OUTSIDE_DELIVERY_AREA", 422)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"distanceKm": 2}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-111-D03:&lt; 3
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC014")]
    public void UTM_111_TC014()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 2m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }

    /// <summary>
    /// UTM-111-TC015: switch-arm L70 -&gt; _
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount DeliveryFeePolicy.Quote(decimal distanceKm)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"distanceKm": 1}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "_", "expression": "_ =&gt; new(30000)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount DeliveryFeePolicy.Quote(decimal distanceKm); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: new(30000) | Assert selected outcome _ at
    /// src/FreshFood.Reposistory/Entities/DomainBehavior.cs:70. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("OUTSIDE_DELIVERY_AREA", 422)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"distanceKm": 5}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-111-D04:_
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-111.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC015")]
    public void UTM_111_TC015()
    {
        // Arrange: test inputs and mock setup.
        var distanceKm = 5m;
        var subject = new DeliveryFeePolicy();
        // Act
        var actual = subject.Quote(distanceKm);
        // Assert
        var expectedFee = 30000m;
        Assert.That(actual.Units, Is.EqualTo(expectedFee));
    }
}
