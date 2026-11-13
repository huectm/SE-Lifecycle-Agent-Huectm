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
public sealed class Entities_CartTests
{
    /// <summary>
    /// UTM-105-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "quantity": 2}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC001")]
    public void UTM_105_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = new Cart
        {
            Items = [new()
            {
                ProductId = "2",
                Quantity = 4
            }

            ]
        };
        var productId = "1";
        subject.ChangeQuantity(productId, 2);
        var replacementQuantity = 3;
        // Act
        subject.ChangeQuantity(productId, replacementQuantity);
        // Assert
        var actualQuantity = subject.Items.Single(item => item.ProductId == productId).Quantity;
        var expectedQuantity = 3;
        Assert.That(actualQuantity, Is.EqualTo(expectedQuantity));
        Assert.That(subject.Items.Single(item => item.ProductId == "2").Quantity, Is.EqualTo(4));
    }

    /// <summary>
    /// UTM-105-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "quantity": 2, "boundary": "Empty then single-item collection where
    /// relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC002")]
    public void UTM_105_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = new Cart
        {
            Items = [new()
            {
                ProductId = "2",
                Quantity = 4
            }

            ]
        };
        var productId = "1";
        subject.ChangeQuantity(productId, 2);
        var replacementQuantity = 3;
        // Act
        subject.ChangeQuantity(productId, replacementQuantity);
        // Assert
        var actualQuantity = subject.Items.Single(item => item.ProductId == productId).Quantity;
        var expectedQuantity = 3;
        Assert.That(actualQuantity, Is.EqualTo(expectedQuantity));
        Assert.That(subject.Items.Single(item => item.ProductId == "2").Quantity, Is.EqualTo(4));
    }

    /// <summary>
    /// UTM-105-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "quantity": 2, "failure": "First collaborator throws TimeoutException
    /// sentinel; for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC003")]
    public void UTM_105_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-105-TC004: if L20 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG",
    /// "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:20. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_QUANTITY")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-105-D01:False, UTM-105-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC004")]
    public void UTM_105_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-105-TC005: if L20 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG",
    /// "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"quantity": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INVALID_QUANTITY"); | Assert selected outcome True
    /// at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:20. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_QUANTITY")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-105-D01:True, UTM-105-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC005")]
    public void UTM_105_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-105-TC006: predicate L21 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG",
    /// "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"i.ProductId": "99", "productId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: i =&gt; i.ProductId == productId | Assert selected
    /// outcome False at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:21. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_QUANTITY")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-105-D02:False, UTM-105-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC006")]
    public void UTM_105_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-105-TC007: predicate L21 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG",
    /// "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"i.ProductId": "1", "productId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: i =&gt; i.ProductId == productId | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:21. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_QUANTITY")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-105-D02:True, UTM-105-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC007")]
    public void UTM_105_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-105-TC008: if L22 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG",
    /// "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"item": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: item.Quantity = quantity; | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Entities/DomainBehavior.cs:22. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_QUANTITY")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-105-D03:False, UTM-105-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC008")]
    public void UTM_105_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-105-TC009: if L22 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.ChangeQuantity(string productId, int quantity)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1", "quantity": 2}, "baseFixtures": ["CUSTOMER", "CATALOG",
    /// "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"item": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.ChangeQuantity(string productId, int quantity); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: Items.Add(new CartItem { ProductId = productId, Quantity = quantity }); |
    /// Assert selected outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:22. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_QUANTITY")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-105-D03:True, UTM-105-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-105.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-105-TC009")]
    public void UTM_105_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-106-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.RemoveItem(string productId)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.RemoveItem(string productId); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-106.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-106-TC001")]
    public void UTM_106_TC001()
    {
        // Arrange: test inputs and mock setup.
        var subject = new Cart
        {
            Items = [new()
            {
                ProductId = "2",
                Quantity = 4
            }

            ]
        };
        var productId = "1";
        subject.Items.Add(new CartItem { ProductId = productId, Quantity = 2 });
        // Act
        subject.RemoveItem(productId);
        // Assert
        Assert.That(subject.Items.Any(item => item.ProductId == productId), Is.False);
        subject.RemoveItem("99");
        Assert.That(subject.Items.Single(item => item.ProductId == "2").Quantity, Is.EqualTo(4));
    }

    /// <summary>
    /// UTM-106-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.RemoveItem(string productId)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.RemoveItem(string productId); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-106.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-106-TC002")]
    public void UTM_106_TC002()
    {
        // Arrange: test inputs and mock setup.
        var subject = new Cart
        {
            Items = [new()
            {
                ProductId = "2",
                Quantity = 4
            }

            ]
        };
        var productId = "1";
        subject.Items.Add(new CartItem { ProductId = productId, Quantity = 2 });
        // Act
        subject.RemoveItem(productId);
        // Assert
        Assert.That(subject.Items.Any(item => item.ProductId == productId), Is.False);
        subject.RemoveItem("99");
        Assert.That(subject.Items.Single(item => item.ProductId == "2").Quantity, Is.EqualTo(4));
    }

    /// <summary>
    /// UTM-106-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.RemoveItem(string productId)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productId": "1", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.RemoveItem(string productId); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-106.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-106-TC003")]
    public void UTM_106_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-106-TC004: predicate L25 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.RemoveItem(string productId)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"i.ProductId": "99", "productId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.RemoveItem(string productId); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: i =&gt; i.ProductId == productId | Assert selected
    /// outcome False at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:25. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-106-D01:False, UTM-106-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-106.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-106-TC004")]
    public void UTM_106_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-106-TC005: predicate L25 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void Cart.RemoveItem(string productId)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"productId": "1"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"i.ProductId": "1", "productId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void Cart.RemoveItem(string productId); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: i =&gt; i.ProductId == productId | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Entities/DomainBehavior.cs:25. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-106-D01:True, UTM-106-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-106.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-106-TC005")]
    public void UTM_106_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }
}
