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
public sealed class Entities_BatchInventoryTests
{
    /// <summary>
    /// UTM-103-TC001: Quantity -1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": -1}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: INSUFFICIENT_STOCK
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC001")]
    public void UTM_103_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = -1;
        var expectedErrorCode = "INSUFFICIENT_STOCK";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Reserve(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-103-TC002: Quantity 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 0}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: INSUFFICIENT_STOCK
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC002")]
    public void UTM_103_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 0;
        var expectedErrorCode = "INSUFFICIENT_STOCK";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Reserve(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-103-TC003: Quantity 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 1}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: ReservedStock=4
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC003")]
    public void UTM_103_TC003()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 1;
        // Act
        subject.Reserve(quantity);
        // Assert
        var expectedReservedStock = 4;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-103-TC004: Quantity 3
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 3}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: ReservedStock=6
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC004")]
    public void UTM_103_TC004()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 3;
        // Act
        subject.Reserve(quantity);
        // Assert
        var expectedReservedStock = 6;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-103-TC005: Quantity 7
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 7}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: ReservedStock=10
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC005")]
    public void UTM_103_TC005()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 7;
        // Act
        subject.Reserve(quantity);
        // Assert
        var expectedReservedStock = 10;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-103-TC006: Quantity 8
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 8}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: INSUFFICIENT_STOCK
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC006")]
    public void UTM_103_TC006()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 8;
        var expectedErrorCode = "INSUFFICIENT_STOCK";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Reserve(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-103-TC007: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"quantity": 2}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC007")]
    public void UTM_103_TC007()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 2;
        // Act
        subject.Reserve(quantity);
        // Assert
        var expectedReservedStock = 5;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-103-TC008: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"quantity": 2, "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC008")]
    public void UTM_103_TC008()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 2;
        // Act
        subject.Reserve(quantity);
        // Assert
        var expectedReservedStock = 5;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-103-TC009: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"quantity": 2, "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC009")]
    public void UTM_103_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-103-TC010: if L7 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 1, "review constraint": "CurrentStock -
    /// ReservedStock &lt; quantity = False; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:7. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"quantity": 1, "CurrentStock": 10, "ReservedStock": 3}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-103-D01:False, UTM-103-D01:C1:False, UTM-103-D01:C2:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC010")]
    public void UTM_103_TC010()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 1;
        // Act
        subject.Reserve(quantity);
        // Assert
        var expectedReservedStock = 4;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-103-TC011: if L7 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 1, "review constraint": "CurrentStock -
    /// ReservedStock &lt; quantity = True; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INSUFFICIENT_STOCK", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:7. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"quantity": 8, "CurrentStock": 10, "ReservedStock": 3}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INSUFFICIENT_STOCK
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-103-D01:True, UTM-103-D01:C1:False, UTM-103-D01:C2:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC011")]
    public void UTM_103_TC011()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 8;
        var expectedErrorCode = "INSUFFICIENT_STOCK";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Reserve(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-103-TC012: if L7 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.Reserve(int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.Reserve(int quantity); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INSUFFICIENT_STOCK", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:7. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"quantity": 0, "CurrentStock": 10, "ReservedStock": 3}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INSUFFICIENT_STOCK
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-103-D01:True, UTM-103-D01:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-103.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-103-TC012")]
    public void UTM_103_TC012()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 0;
        var expectedErrorCode = "INSUFFICIENT_STOCK";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.Reserve(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-104-TC001: Quantity -1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": -1}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: RESERVATION_INCONSISTENT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC001")]
    public void UTM_104_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = -1;
        var expectedErrorCode = "RESERVATION_INCONSISTENT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.ReleaseReservation(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-104-TC002: Quantity 0
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 0}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: RESERVATION_INCONSISTENT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC002")]
    public void UTM_104_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 0;
        var expectedErrorCode = "RESERVATION_INCONSISTENT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.ReleaseReservation(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-104-TC003: Quantity 1
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 1}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: ReservedStock=2
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC003")]
    public void UTM_104_TC003()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 1;
        // Act
        subject.ReleaseReservation(quantity);
        // Assert
        var expectedReservedStock = 2;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-104-TC004: Quantity 3
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 3}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: ReservedStock=0
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC004")]
    public void UTM_104_TC004()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 3;
        // Act
        subject.ReleaseReservation(quantity);
        // Assert
        var expectedReservedStock = 0;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-104-TC005: Quantity 7
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 7}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: RESERVATION_INCONSISTENT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC005")]
    public void UTM_104_TC005()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 7;
        var expectedErrorCode = "RESERVATION_INCONSISTENT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.ReleaseReservation(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-104-TC006: Quantity 8
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary / invariant; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"CurrentStock": 10, "ReservedStock": 3, "quantity": 8}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject; ReservedStock stays 3
    /// </para>
    /// <para>
    /// Design exception expectation: RESERVATION_INCONSISTENT
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC006")]
    public void UTM_104_TC006()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 8;
        var expectedErrorCode = "RESERVATION_INCONSISTENT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.ReleaseReservation(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-104-TC007: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"quantity": 2}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC007")]
    public void UTM_104_TC007()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 2;
        // Act
        subject.ReleaseReservation(quantity);
        // Assert
        var expectedReservedStock = 1;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-104-TC008: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"quantity": 2, "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC008")]
    public void UTM_104_TC008()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 2;
        // Act
        subject.ReleaseReservation(quantity);
        // Assert
        var expectedReservedStock = 1;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-104-TC009: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"quantity": 2, "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC009")]
    public void UTM_104_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-104-TC010: if L12 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 1, "review constraint": "ReservedStock &lt; quantity
    /// = False; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:12. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("RESERVATION_INCONSISTENT", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"quantity": 1, "CurrentStock": 10, "ReservedStock": 3}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-104-D01:False, UTM-104-D01:C1:False, UTM-104-D01:C2:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC010")]
    public void UTM_104_TC010()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 1;
        // Act
        subject.ReleaseReservation(quantity);
        // Assert
        var expectedReservedStock = 2;
        Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));
    }

    /// <summary>
    /// UTM-104-TC011: if L12 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 1, "review constraint": "ReservedStock &lt; quantity
    /// = True; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("RESERVATION_INCONSISTENT", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:12. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("RESERVATION_INCONSISTENT", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"quantity": 4, "CurrentStock": 10, "ReservedStock": 3}
    /// </para>
    /// <para>
    /// Concrete exception expectation: RESERVATION_INCONSISTENT
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-104-D01:True, UTM-104-D01:C1:False, UTM-104-D01:C2:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC011")]
    public void UTM_104_TC011()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 4;
        var expectedErrorCode = "RESERVATION_INCONSISTENT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.ReleaseReservation(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }

    /// <summary>
    /// UTM-104-TC012: if L12 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void BatchInventory.ReleaseReservation(int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void BatchInventory.ReleaseReservation(int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("RESERVATION_INCONSISTENT", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:12. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("RESERVATION_INCONSISTENT", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"quantity": 0, "CurrentStock": 10, "ReservedStock": 3}
    /// </para>
    /// <para>
    /// Concrete exception expectation: RESERVATION_INCONSISTENT
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-104-D01:True, UTM-104-D01:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-104.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-104-TC012")]
    public void UTM_104_TC012()
    {
        // Arrange: test inputs and mock setup.
        var subject = Fixture.Batch(stock: 10, reserved: 3);
        var quantity = 0;
        var expectedErrorCode = "RESERVATION_INCONSISTENT";
        // Act
        var actualException = Assert.Throws<DomainException>(() => subject.ReleaseReservation(quantity))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(subject.ReservedStock, Is.EqualTo(3));
    }
}
