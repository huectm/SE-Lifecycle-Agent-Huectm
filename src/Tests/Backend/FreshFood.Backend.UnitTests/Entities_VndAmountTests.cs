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
public sealed class Entities_VndAmountTests
{
    /// <summary>
    /// UTM-113-TC001: Amount 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "0"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=0
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC001")]
    public void UTM_113_TC001()
    {
        // Arrange: test inputs and mock setup.
        var units = 0m;
        // Act
        var actual = new VndAmount(units);
        // Assert
        var expectedUnits = 0m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-113-TC002: Amount 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=1
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC002")]
    public void UTM_113_TC002()
    {
        // Arrange: test inputs and mock setup.
        var units = 1m;
        // Act
        var actual = new VndAmount(units);
        // Assert
        var expectedUnits = 1m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-113-TC003: Amount 999999999999999999
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "999999999999999999"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=999999999999999999
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC003")]
    public void UTM_113_TC003()
    {
        // Arrange: test inputs and mock setup.
        var units = 999999999999999999m;
        // Act
        var actual = new VndAmount(units);
        // Assert
        var expectedUnits = 999999999999999999m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-113-TC004: Amount -1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "-1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC004")]
    public void UTM_113_TC004()
    {
        // Arrange: test inputs and mock setup.
        var units = -1m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => new VndAmount(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-113-TC005: Amount 1000000000000000000
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "1000000000000000000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC005")]
    public void UTM_113_TC005()
    {
        // Arrange: test inputs and mock setup.
        var units = 1000000000000000000m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => new VndAmount(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-113-TC006: Amount 0.5
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "0.5"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC006")]
    public void UTM_113_TC006()
    {
        // Arrange: test inputs and mock setup.
        var units = 0.5m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => new VndAmount(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-113-TC007: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": 10000}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Construct Units=10000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC007")]
    public void UTM_113_TC007()
    {
        // Arrange: test inputs and mock setup.
        var units = 10000m;
        // Act
        var actual = new VndAmount(units);
        // Assert
        var expectedUnits = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-113-TC008: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": 10000, "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC008")]
    public void UTM_113_TC008()
    {
        // Arrange: test inputs and mock setup.
        var units = 10000m;
        // Act
        var actual = new VndAmount(units);
        // Assert
        var expectedUnits = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-113-TC009: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": 10000, "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC009")]
    public void UTM_113_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-113-TC010: if L9 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"units": 10000}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"units": "999999999999999999", "review constraint":
    /// "decimal.Truncate(units) != units = False; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Entities/VndAmount.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_VND_AMOUNT")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"units": "10000"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-113-D01:False, UTM-113-D01:C1:False, UTM-113-D01:C2:False,
    /// UTM-113-D01:C3:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC010")]
    public void UTM_113_TC010()
    {
        // Arrange: test inputs and mock setup.
        var units = 10000m;
        // Act
        var actual = new VndAmount(units);
        // Assert
        var expectedUnits = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-113-TC011: if L9 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"units": 10000}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"units": "999999999999999999", "review constraint":
    /// "decimal.Truncate(units) != units = True; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INVALID_VND_AMOUNT"); | Assert selected outcome
    /// True at src/FreshFood.Reposistory/Entities/VndAmount.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_VND_AMOUNT")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"units": "0.5"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-113-D01:True, UTM-113-D01:C1:False, UTM-113-D01:C2:False, UTM-113-D01:C3:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC011")]
    public void UTM_113_TC011()
    {
        // Arrange: test inputs and mock setup.
        var units = 0.5m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => new VndAmount(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-113-TC012: if L9 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"units": 10000}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"units": "1000000000000000000"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INVALID_VND_AMOUNT"); | Assert selected outcome
    /// True at src/FreshFood.Reposistory/Entities/VndAmount.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_VND_AMOUNT")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"units": "1000000000000000000"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-113-D01:True, UTM-113-D01:C1:False, UTM-113-D01:C2:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC012")]
    public void UTM_113_TC012()
    {
        // Arrange: test inputs and mock setup.
        var units = 1000000000000000000m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => new VndAmount(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-113-TC013: if L9 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount.VndAmount(decimal units)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"units": 10000}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"units": -1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount.VndAmount(decimal units); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INVALID_VND_AMOUNT"); | Assert selected outcome
    /// True at src/FreshFood.Reposistory/Entities/VndAmount.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_VND_AMOUNT")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"units": "-1"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-113-D01:True, UTM-113-D01:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-113.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-113-TC013")]
    public void UTM_113_TC013()
    {
        // Arrange: test inputs and mock setup.
        var units = -1m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => new VndAmount(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-114-TC001: Amount 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "0"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=0
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC001")]
    public void UTM_114_TC001()
    {
        // Arrange: test inputs and mock setup.
        var units = 0m;
        // Act
        var actual = VndAmount.FromUnits(units);
        // Assert
        var expectedUnits = 0m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-114-TC002: Amount 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=1
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC002")]
    public void UTM_114_TC002()
    {
        // Arrange: test inputs and mock setup.
        var units = 1m;
        // Act
        var actual = VndAmount.FromUnits(units);
        // Assert
        var expectedUnits = 1m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-114-TC003: Amount 999999999999999999
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "999999999999999999"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=999999999999999999
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC003")]
    public void UTM_114_TC003()
    {
        // Arrange: test inputs and mock setup.
        var units = 999999999999999999m;
        // Act
        var actual = VndAmount.FromUnits(units);
        // Assert
        var expectedUnits = 999999999999999999m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-114-TC004: Amount -1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "-1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC004")]
    public void UTM_114_TC004()
    {
        // Arrange: test inputs and mock setup.
        var units = -1m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => VndAmount.FromUnits(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-114-TC005: Amount 1000000000000000000
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "1000000000000000000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC005")]
    public void UTM_114_TC005()
    {
        // Arrange: test inputs and mock setup.
        var units = 1000000000000000000m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => VndAmount.FromUnits(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-114-TC006: Amount 0.5
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": "0.5"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC006")]
    public void UTM_114_TC006()
    {
        // Arrange: test inputs and mock setup.
        var units = 0.5m;
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => VndAmount.FromUnits(units))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-114-TC007: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": 10000}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=10000 without rounding
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC007")]
    public void UTM_114_TC007()
    {
        // Arrange: test inputs and mock setup.
        var units = 10000m;
        // Act
        var actual = VndAmount.FromUnits(units);
        // Assert
        var expectedUnits = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-114-TC008: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": 10000, "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC008")]
    public void UTM_114_TC008()
    {
        // Arrange: test inputs and mock setup.
        var units = 10000m;
        // Act
        var actual = VndAmount.FromUnits(units);
        // Assert
        var expectedUnits = 10000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-114-TC009: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.FromUnits(decimal units)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"units": 10000, "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.FromUnits(decimal units); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-114.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-114-TC009")]
    public void UTM_114_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-115-TC001: Add 0 + 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.Add(VndAmount other)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"left": "0", "right": "0"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.Add(VndAmount other); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=0
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-115.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-115-TC001")]
    public void UTM_115_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(0m);
        var other = new VndAmount(0m);
        // Act
        var actual = subject.Add(other);
        // Assert
        var expectedUnits = 0m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-115-TC002: Add 10000 + 20000
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.Add(VndAmount other)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"left": "10000", "right": "20000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.Add(VndAmount other); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=30000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-115.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-115-TC002")]
    public void UTM_115_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        var other = new VndAmount(20000m);
        // Act
        var actual = subject.Add(other);
        // Assert
        var expectedUnits = 30000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-115-TC003: Add 999999999999999999 + 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.Add(VndAmount other)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"left": "999999999999999999", "right": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.Add(VndAmount other); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject invalid amount
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_VND_AMOUNT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-115.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-115-TC003")]
    public void UTM_115_TC003()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(999999999999999999m);
        var other = new VndAmount(1m);
        var expectedErrorCode = "INVALID_VND_AMOUNT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Add(other))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
    }

    /// <summary>
    /// UTM-115-TC004: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.Add(VndAmount other)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"other": "10000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.Add(VndAmount other); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Units=20000 when this=10000 and other=10000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-115.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-115-TC004")]
    public void UTM_115_TC004()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        var other = new VndAmount(10000m);
        // Act
        var actual = subject.Add(other);
        // Assert
        var expectedUnits = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-115-TC005: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.Add(VndAmount other)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"other": "10000", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.Add(VndAmount other); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-115.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-115-TC005")]
    public void UTM_115_TC005()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        var other = new VndAmount(10000m);
        // Act
        var actual = subject.Add(other);
        // Assert
        var expectedUnits = 20000m;
        Assert.That(actual.Units, Is.EqualTo(expectedUnits));
    }

    /// <summary>
    /// UTM-115-TC006: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: VndAmount VndAmount.Add(VndAmount other)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"other": "10000", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke VndAmount VndAmount.Add(VndAmount other); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-115.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-115-TC006")]
    public void UTM_115_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-116-TC001: Exact wire 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToWire()
    /// </para>
    /// <para>
    /// Technique: Precision error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Units": "0"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToWire(); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly "0" in every culture
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-116.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-116-TC001")]
    public void UTM_116_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(0m);
        // Act
        var actual = subject.ToWire();
        // Assert
        var expectedText = "0";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-116-TC002: Exact wire 10000
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToWire()
    /// </para>
    /// <para>
    /// Technique: Precision error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Units": "10000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToWire(); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly "10000" in every culture
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-116.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-116-TC002")]
    public void UTM_116_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        // Act
        var actual = subject.ToWire();
        // Assert
        var expectedText = "10000";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-116-TC003: Exact wire 999999999999999999
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToWire()
    /// </para>
    /// <para>
    /// Technique: Precision error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Units": "999999999999999999"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToWire(); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly "999999999999999999" in every culture
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-116.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-116-TC003")]
    public void UTM_116_TC003()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(999999999999999999m);
        // Act
        var actual = subject.ToWire();
        // Assert
        var expectedText = "999999999999999999";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-116-TC004: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToWire()
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToWire(); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly string "10000" for fixture Units=10000
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-116.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-116-TC004")]
    public void UTM_116_TC004()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        // Act
        var actual = subject.ToWire();
        // Assert
        var expectedText = "10000";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-116-TC005: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToWire()
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToWire(); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-116.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-116-TC005")]
    public void UTM_116_TC005()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        // Act
        var actual = subject.ToWire();
        // Assert
        var expectedText = "10000";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-116-TC006: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToWire()
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToWire(); assert result, exception and captured
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
    /// Execution constraint (NUnit Ignore): No injectable collaborator here; bind abnormal cases to the declared
    /// guard, or review N/A instead of inventing a fault injection seam.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-116.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-116-TC006")]
    public void UTM_116_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-117-TC001: Exact wire 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToString()
    /// </para>
    /// <para>
    /// Technique: Precision error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Units": "0"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToString(); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly "0" in every culture
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-117.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-117-TC001")]
    public void UTM_117_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(0m);
        // Act
        var actual = subject.ToString();
        // Assert
        var expectedText = "0";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-117-TC002: Exact wire 10000
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToString()
    /// </para>
    /// <para>
    /// Technique: Precision error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Units": "10000"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToString(); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly "10000" in every culture
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-117.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-117-TC002")]
    public void UTM_117_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        // Act
        var actual = subject.ToString();
        // Assert
        var expectedText = "10000";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-117-TC003: Exact wire 999999999999999999
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToString()
    /// </para>
    /// <para>
    /// Technique: Precision error guessing; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Units": "999999999999999999"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToString(); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly "999999999999999999" in every culture
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-117.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-117-TC003")]
    public void UTM_117_TC003()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(999999999999999999m);
        // Act
        var actual = subject.ToString();
        // Assert
        var expectedText = "999999999999999999";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-117-TC004: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToString()
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToString(); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly string "10000"
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-117.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-117-TC004")]
    public void UTM_117_TC004()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        // Act
        var actual = subject.ToString();
        // Assert
        var expectedText = "10000";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-117-TC005: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToString()
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToString(); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-117.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-117-TC005")]
    public void UTM_117_TC005()
    {
        // Arrange: test inputs and mock setup.
        var subject = new VndAmount(10000m);
        // Act
        var actual = subject.ToString();
        // Assert
        var expectedText = "10000";
        Assert.That(actual, Is.EqualTo(expectedText));
    }

    /// <summary>
    /// UTM-117-TC006: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string VndAmount.ToString()
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string VndAmount.ToString(); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-117.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-117-TC006")]
    public void UTM_117_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }
}
