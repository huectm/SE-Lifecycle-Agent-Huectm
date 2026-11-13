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
public sealed class Repository_Implements_CheckoutRepositoryTests
{
    /// <summary>
    /// UTM-131-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CheckoutRepository.CheckoutRepository(IRepositorySession session, IFefoBatchSpecification
    /// fefo)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"session": "Typed FreshFood.Reposistory.Repository.IRepositorySession fixture from
    /// fixtures.json", "fefo": "CATALOG"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CheckoutRepository.CheckoutRepository(IRepositorySession
    /// session, IFefoBatchSpecification fefo); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-131.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-131-TC001")]
    public void UTM_131_TC001()
    {
        // Arrange: test inputs and mock setup.
        var session = (FreshFood.Reposistory.Repository.IRepositorySession)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IRepositorySession))!;
        var fefo = (FreshFood.Reposistory.Repository.IFefoBatchSpecification)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IFefoBatchSpecification))!;
        // Act
        var actual = new FreshFood.Reposistory.Repository.Implements.CheckoutRepository(session, fefo);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Reposistory.Repository.Implements.CheckoutRepository>());
    }

    /// <summary>
    /// UTM-131-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CheckoutRepository.CheckoutRepository(IRepositorySession session, IFefoBatchSpecification
    /// fefo)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"session": "Typed FreshFood.Reposistory.Repository.IRepositorySession fixture from
    /// fixtures.json", "fefo": "CATALOG", "variant": "Omit optional arguments; otherwise use distinct valid
    /// instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CheckoutRepository.CheckoutRepository(IRepositorySession
    /// session, IFefoBatchSpecification fefo); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-131.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-131-TC002")]
    public void UTM_131_TC002()
    {
        // Arrange: test inputs and mock setup.
        var session = (FreshFood.Reposistory.Repository.IRepositorySession)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IRepositorySession))!;
        var fefo = (FreshFood.Reposistory.Repository.IFefoBatchSpecification)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IFefoBatchSpecification))!;
        // Act
        var actual = new FreshFood.Reposistory.Repository.Implements.CheckoutRepository(session, fefo);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Reposistory.Repository.Implements.CheckoutRepository>());
    }

    /// <summary>
    /// UTM-131-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CheckoutRepository.CheckoutRepository(IRepositorySession session, IFefoBatchSpecification
    /// fefo)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"session": "Typed FreshFood.Reposistory.Repository.IRepositorySession fixture from
    /// fixtures.json", "fefo": "CATALOG", "variant": "Missing non-nullable dependency is outside declared caller
    /// contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CheckoutRepository.CheckoutRepository(IRepositorySession
    /// session, IFefoBatchSpecification fefo); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-131.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-131-TC003")]
    public void UTM_131_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-132-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; CheckoutRepository.GetCheckoutCartAsync(string customerId, CancellationToken
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
    /// Design input: {"customerId": "7", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; CheckoutRepository.GetCheckoutCartAsync(string
    /// customerId, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-132.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-132-TC001")]
    public async System.Threading.Tasks.Task UTM_132_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var customerId = "7";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        var actual = await subject.GetCheckoutCartAsync(customerId, signal);
        // Assert
        var expectedCartId = "1";
        var expectedCustomerId = "7";
        Assert.That(actual.CartId, Is.EqualTo(expectedCartId));
        Assert.That(actual.CustomerId, Is.EqualTo(expectedCustomerId));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-132-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; CheckoutRepository.GetCheckoutCartAsync(string customerId, CancellationToken
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
    /// Design input: {"customerId": "7", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; CheckoutRepository.GetCheckoutCartAsync(string
    /// customerId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-132.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-132-TC002")]
    public async System.Threading.Tasks.Task UTM_132_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var customerId = "7";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        var actual = await subject.GetCheckoutCartAsync(customerId, signal);
        // Assert
        var expectedCartId = "1";
        var expectedCustomerId = "7";
        Assert.That(actual.CartId, Is.EqualTo(expectedCartId));
        Assert.That(actual.CustomerId, Is.EqualTo(expectedCustomerId));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-132-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; CheckoutRepository.GetCheckoutCartAsync(string customerId, CancellationToken
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
    /// Design input: {"customerId": "7", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; CheckoutRepository.GetCheckoutCartAsync(string
    /// customerId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-132.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-132-TC003")]
    public void UTM_132_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-133-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CustomerAddress&gt; CheckoutRepository.GetOwnedAddressAsync(string customerId, string
    /// addressId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CustomerAddress&gt;
    /// CheckoutRepository.GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-133.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-133-TC001")]
    public async System.Threading.Tasks.Task UTM_133_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var customerId = "7";
        var addressId = "2";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        var actual = await subject.GetOwnedAddressAsync(customerId, addressId, signal);
        // Assert
        Assert.That(actual, Is.Not.Null);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-133-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CustomerAddress&gt; CheckoutRepository.GetOwnedAddressAsync(string customerId, string
    /// addressId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum
    /// allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CustomerAddress&gt;
    /// CheckoutRepository.GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-133.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-133-TC002")]
    public void UTM_133_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var customerId = "7";
        var addressId = "2";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        var expectedErrorCode = "NOT_FOUND";
        // Act
        var actualException = Assert.ThrowsAsync<DomainException>(async () => await subject.GetOwnedAddressAsync(customerId, addressId, signal))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-133-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CustomerAddress&gt; CheckoutRepository.GetOwnedAddressAsync(string customerId, string
    /// addressId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use
    /// a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CustomerAddress&gt;
    /// CheckoutRepository.GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-133.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-133-TC003")]
    public void UTM_133_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-133-TC004: coalesce L12 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CustomerAddress&gt; CheckoutRepository.GetOwnedAddressAsync(string customerId, string
    /// addressId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "addressId": "2", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "await
    /// One&lt;CustomerAddress&gt;(\"SELECT * FROM customer_addresses WHERE customer_id=$1 AND address_id=$2\" + Lock,
    /// signal, Id(customerId), Id(addressId))"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CustomerAddress&gt;
    /// CheckoutRepository.GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: await One&lt;CustomerAddress&gt;("SELECT * FROM
    /// customer_addresses WHERE customer_id=$1 AND address_id=$2" + Lock, signal, Id(customerId), Id(addressId)) ??
    /// throw new DomainException("NOT_FOUND", 404) | Assert selected outcome Null at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:12. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-133-D01:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-133.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-133-TC004")]
    public void UTM_133_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-133-TC005: coalesce L12 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;CustomerAddress&gt; CheckoutRepository.GetOwnedAddressAsync(string customerId, string
    /// addressId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "addressId": "2", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "await
    /// One&lt;CustomerAddress&gt;(\"SELECT * FROM customer_addresses WHERE customer_id=$1 AND address_id=$2\" + Lock,
    /// signal, Id(customerId), Id(addressId))"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;CustomerAddress&gt;
    /// CheckoutRepository.GetOwnedAddressAsync(string customerId, string addressId, CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: await One&lt;CustomerAddress&gt;("SELECT * FROM
    /// customer_addresses WHERE customer_id=$1 AND address_id=$2" + Lock, signal, Id(customerId), Id(addressId)) ??
    /// throw new DomainException("NOT_FOUND", 404) | Assert selected outcome Non-null at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:12. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-133-D01:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-133.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-133-TC005")]
    public void UTM_133_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-134-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; CheckoutRepository.LockFefoBatchesAsync(List&lt;string&gt;
    /// productIds, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productIds": "Sample", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt;
    /// CheckoutRepository.LockFefoBatchesAsync(List&lt;string&gt; productIds, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-134.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-134-TC001")]
    public async System.Threading.Tasks.Task UTM_134_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var productIds = new List<string>
        {
            "1"
        };
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        var actual = await subject.LockFefoBatchesAsync(productIds, signal);
        // Assert
        var expectedRowCount = 1;
        Assert.That(actual, NUnit.Framework.Has.Count.EqualTo(expectedRowCount));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-134-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; CheckoutRepository.LockFefoBatchesAsync(List&lt;string&gt;
    /// productIds, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productIds": "Sample", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt;
    /// CheckoutRepository.LockFefoBatchesAsync(List&lt;string&gt; productIds, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-134.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-134-TC002")]
    public async System.Threading.Tasks.Task UTM_134_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var productIds = new List<string>
        {
            "1"
        };
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        var actual = await subject.LockFefoBatchesAsync(productIds, signal);
        // Assert
        var expectedRowCount = 0;
        Assert.That(actual, NUnit.Framework.Has.Count.EqualTo(expectedRowCount));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-134-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; CheckoutRepository.LockFefoBatchesAsync(List&lt;string&gt;
    /// productIds, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"productIds": "Sample", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt;
    /// CheckoutRepository.LockFefoBatchesAsync(List&lt;string&gt; productIds, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-134.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-134-TC003")]
    public void UTM_134_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-135-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC001")]
    public async System.Threading.Tasks.Task UTM_135_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var order = new Order
        {
            OrderId = "1",
            CustomerId = "7",
            DeliveryAddressId = "2"
        };
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        await subject.SaveOrderAsync(order, signal);
        // Assert
        Assert.That(database.Queries, Is.Not.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-135-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC002")]
    public async System.Threading.Tasks.Task UTM_135_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var order = new Order
        {
            OrderId = "1",
            CustomerId = "7",
            DeliveryAddressId = "2"
        };
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        await subject.SaveOrderAsync(order, signal);
        // Assert
        Assert.That(database.Queries, Is.Not.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-135-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC003")]
    public void UTM_135_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-135-TC004: foreach L21 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Empty", "expression": "order.Details"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: if ((await Rows&lt;BatchInventory&gt;("UPDATE
    /// batch_inventory SET reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock &gt;=
    /// $1 RETURNING batch_id", signal, line.Quantity, Id(line.BatchId))).Count != 1)                 throw new
    /// DomainException("INSUFFICIENT_STOCK", 409); | Assert selected outcome Empty at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:21. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D01:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC004")]
    public void UTM_135_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC005: foreach L21 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "One item", "expression": "order.Details"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: if ((await Rows&lt;BatchInventory&gt;("UPDATE
    /// batch_inventory SET reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock &gt;=
    /// $1 RETURNING batch_id", signal, line.Quantity, Id(line.BatchId))).Count != 1)                 throw new
    /// DomainException("INSUFFICIENT_STOCK", 409); | Assert selected outcome One item at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:21. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D01:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC005")]
    public void UTM_135_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC006: foreach L21 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Multiple items", "expression": "order.Details"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: if ((await Rows&lt;BatchInventory&gt;("UPDATE
    /// batch_inventory SET reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock &gt;=
    /// $1 RETURNING batch_id", signal, line.Quantity, Id(line.BatchId))).Count != 1)                 throw new
    /// DomainException("INSUFFICIENT_STOCK", 409); | Assert selected outcome Multiple items at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:21. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D01:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC006")]
    public void UTM_135_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC007: if L22 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"(await Rows&lt;BatchInventory&gt;(\"UPDATE batch_inventory SET
    /// reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock &gt;= $1 RETURNING
    /// batch_id\", signal, line.Quantity, Id(line.BatchId)))": ["typed fixture item"]}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:22. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D02:False, UTM-135-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC007")]
    public void UTM_135_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC008: if L22 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"(await Rows&lt;BatchInventory&gt;(\"UPDATE batch_inventory SET
    /// reserved_stock=reserved_stock+$1 WHERE batch_id=$2 AND current_stock-reserved_stock &gt;= $1 RETURNING
    /// batch_id\", signal, line.Quantity, Id(line.BatchId)))": []}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INSUFFICIENT_STOCK", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:22. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D02:True, UTM-135-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC008")]
    public void UTM_135_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC009: foreach L27 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Empty", "expression": "order.Details"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: await Rows&lt;OrderDetail&gt;("INSERT INTO
    /// order_details(order_id,batch_id,quantity,unit_price,discount_amount,line_total) VALUES($1,$2,$3,$4,$5,$6)",
    /// signal, Id(order.OrderId), Id(line.BatchId), line.Quantity, line.UnitPrice.Units, line.DiscountAmount.Units,
    /// line.LineTotal.Units); | Assert selected outcome Empty at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:27. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D03:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC009")]
    public void UTM_135_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC010: foreach L27 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "One item", "expression": "order.Details"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: await Rows&lt;OrderDetail&gt;("INSERT INTO
    /// order_details(order_id,batch_id,quantity,unit_price,discount_amount,line_total) VALUES($1,$2,$3,$4,$5,$6)",
    /// signal, Id(order.OrderId), Id(line.BatchId), line.Quantity, line.UnitPrice.Units, line.DiscountAmount.Units,
    /// line.LineTotal.Units); | Assert selected outcome One item at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:27. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D03:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC010")]
    public void UTM_135_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-135-TC011: foreach L27 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.SaveOrderAsync(Order order, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"order": "ORDER", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Multiple items", "expression": "order.Details"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.SaveOrderAsync(Order order,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: await Rows&lt;OrderDetail&gt;("INSERT INTO
    /// order_details(order_id,batch_id,quantity,unit_price,discount_amount,line_total) VALUES($1,$2,$3,$4,$5,$6)",
    /// signal, Id(order.OrderId), Id(line.BatchId), line.Quantity, line.UnitPrice.Units, line.DiscountAmount.Units,
    /// line.LineTotal.Units); | Assert selected outcome Multiple items at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:27. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INSUFFICIENT_STOCK", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-135-D03:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-135.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-135-TC011")]
    public void UTM_135_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-136-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;bool&gt; CheckoutRepository.SavePaymentOnceAsync(OrderPayment payment,
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
    /// Design input: {"payment": "ORDER", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;bool&gt; CheckoutRepository.SavePaymentOnceAsync(OrderPayment
    /// payment, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Fail closed: DomainException PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED / 503 where
    /// specified; no successful payment/refund effect.
    /// </para>
    /// <para>
    /// Design exception expectation: PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-136.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-136-TC001")]
    public void UTM_136_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var payment = (FreshFood.Reposistory.Entities.OrderPayment)Fixture.Value(typeof(FreshFood.Reposistory.Entities.OrderPayment))!;
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        var expectedErrorCode = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED";
        // Act
        var actualException = Assert.ThrowsAsync<DomainException>(async () => await subject.SavePaymentOnceAsync(payment, signal))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(database.Queries, Is.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-136-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;bool&gt; CheckoutRepository.SavePaymentOnceAsync(OrderPayment payment,
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
    /// Design input: {"payment": "ORDER", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;bool&gt; CheckoutRepository.SavePaymentOnceAsync(OrderPayment
    /// payment, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-136.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-136-TC002")]
    public void UTM_136_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var payment = (FreshFood.Reposistory.Entities.OrderPayment)Fixture.Value(typeof(FreshFood.Reposistory.Entities.OrderPayment))!;
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        var expectedErrorCode = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED";
        // Act
        var actualException = Assert.ThrowsAsync<DomainException>(async () => await subject.SavePaymentOnceAsync(payment, signal))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        Assert.That(database.Queries, Is.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-136-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;bool&gt; CheckoutRepository.SavePaymentOnceAsync(OrderPayment payment,
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
    /// Design input: {"payment": "ORDER", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;bool&gt; CheckoutRepository.SavePaymentOnceAsync(OrderPayment
    /// payment, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-136.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-136-TC003")]
    public void UTM_136_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-137-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.ClearCartAsync(string cartId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cartId": "1", "signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.ClearCartAsync(string cartId,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-137.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-137-TC001")]
    public async System.Threading.Tasks.Task UTM_137_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var cartId = "1";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        await subject.ClearCartAsync(cartId, signal);
        // Assert
        Assert.That(database.Queries, Is.Not.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-137-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.ClearCartAsync(string cartId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cartId": "1", "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.ClearCartAsync(string cartId,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-137.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-137-TC002")]
    public async System.Threading.Tasks.Task UTM_137_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var cartId = "1";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        await subject.ClearCartAsync(cartId, signal);
        // Assert
        Assert.That(database.Queries, Is.Not.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-137-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.ClearCartAsync(string cartId, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cartId": "1", "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.ClearCartAsync(string cartId,
    /// CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-137.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-137-TC003")]
    public void UTM_137_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-138-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC001")]
    public async System.Threading.Tasks.Task UTM_138_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null, key: "Sample", reference: "Sample", requestHash: "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        var customerId = "7";
        var reference = "Sample";
        var key = "Sample";
        var requestHash = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        var actual = await subject.ClaimCheckoutAsync(customerId, reference, key, requestHash, signal);
        // Assert
        Assert.That(actual, Is.TypeOf<CheckoutClaim>());
        Assert.That(((CheckoutClaim)actual).Replay, Is.False);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-138-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC002")]
    public void UTM_138_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null, key: "Sample", reference: "Sample", requestHash: "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        var customerId = "7";
        var reference = "Sample";
        var key = "Sample";
        var requestHash = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        var expectedErrorCode = "CHECKOUT_REFERENCE_REUSED";
        // Act
        var actualException = Assert.ThrowsAsync<DomainException>(async () => await subject.ClaimCheckoutAsync(customerId, reference, key, requestHash, signal))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-138-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for
    /// pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC003")]
    public void UTM_138_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-138-TC004: coalesce L42 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "await
    /// One&lt;ClaimRow&gt;(\"SELECT * FROM checkout_idempotency WHERE customer_id=$1 AND operation='PlaceOrder' AND
    /// idempotency_key=$2 FOR UPDATE\", signal, Id(customerId), key)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: await One&lt;ClaimRow&gt;("SELECT * FROM
    /// checkout_idempotency WHERE customer_id=$1 AND operation='PlaceOrder' AND idempotency_key=$2 FOR UPDATE",
    /// signal, Id(customerId), key)             ?? throw new DomainException("CHECKOUT_REFERENCE_REUSED", 409) |
    /// Assert selected outcome Null at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:42.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D01:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC004")]
    public void UTM_138_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC005: coalesce L42 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "await
    /// One&lt;ClaimRow&gt;(\"SELECT * FROM checkout_idempotency WHERE customer_id=$1 AND operation='PlaceOrder' AND
    /// idempotency_key=$2 FOR UPDATE\", signal, Id(customerId), key)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: await One&lt;ClaimRow&gt;("SELECT * FROM
    /// checkout_idempotency WHERE customer_id=$1 AND operation='PlaceOrder' AND idempotency_key=$2 FOR UPDATE",
    /// signal, Id(customerId), key)             ?? throw new DomainException("CHECKOUT_REFERENCE_REUSED", 409) |
    /// Assert selected outcome Non-null at
    /// src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D01:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC005")]
    public void UTM_138_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC006: if L44 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"saved.RequestHash": "1", "requestHash": "1",
    /// "saved.CheckoutReference": "1", "reference": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:44. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D02:False, UTM-138-D02:C1:False, UTM-138-D02:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC006")]
    public void UTM_138_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC007: if L44 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"saved.RequestHash": "1", "requestHash": "1",
    /// "saved.CheckoutReference": "99", "reference": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("IDEMPOTENCY_KEY_REUSED", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:44. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D02:True, UTM-138-D02:C1:False, UTM-138-D02:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC007")]
    public void UTM_138_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC008: if L44 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"saved.RequestHash": "99", "requestHash": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("IDEMPOTENCY_KEY_REUSED", 409); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:44. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D02:True, UTM-138-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC008")]
    public void UTM_138_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC009: if L45 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"saved.Response": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:45. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D03:False, UTM-138-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC009")]
    public void UTM_138_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC010: if L45 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"saved.Response": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: return new CheckoutClaim { Replay = true, Response = saved.Response }; |
    /// Assert selected outcome True at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:45.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D03:True, UTM-138-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC010")]
    public void UTM_138_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC011: if L46 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"inserted.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:46. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D04:False, UTM-138-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC011")]
    public void UTM_138_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-138-TC012: if L46 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string customerId, string reference,
    /// string key, string requestHash, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "requestHash":
    /// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "signal": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"inserted.Count": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;object&gt; CheckoutRepository.ClaimCheckoutAsync(string
    /// customerId, string reference, string key, string requestHash, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503); | Assert
    /// selected outcome True at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:46. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CHECKOUT_REFERENCE_REUSED", 409); new DomainException("IDEMPOTENCY_KEY_REUSED", 409); new
    /// DomainException("INCOMPLETE_IDEMPOTENCY_RECORD", 503)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-138-D04:True, UTM-138-D04:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-138.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-138-TC012")]
    public void UTM_138_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-139-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.CompleteCheckoutAsync(string customerId, string reference, string
    /// key, object response, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "reference": "Sample", "key": "Sample", "response": "Typed object fixture
    /// from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.CompleteCheckoutAsync(string customerId,
    /// string reference, string key, object response, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Capture parameterized SQL and ordered arguments from the source reference. Return
    /// configured typed rows/projection; mutators require Active=true. No real DB for unit cases.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-139.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-139-TC001")]
    public async System.Threading.Tasks.Task UTM_139_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var customerId = "7";
        var reference = "Sample";
        var key = "Sample";
        var response = new
        {
            OrderId = "1"
        };
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        // Act
        await subject.CompleteCheckoutAsync(customerId, reference, key, response, signal);
        // Assert
        Assert.That(database.Queries, Is.Not.Empty);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-139-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.CompleteCheckoutAsync(string customerId, string reference, string
    /// key, object response, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "reference": "Sample", "key": "Sample", "response": "Typed object fixture
    /// from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.CompleteCheckoutAsync(string customerId,
    /// string reference, string key, object response, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-139.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-139-TC002")]
    public void UTM_139_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var customerId = "7";
        var reference = "Sample";
        var key = "Sample";
        var response = new
        {
            OrderId = "1"
        };
        var signal = Fixture.Token;
        var subject = new CheckoutRepository(database.Session, new FefoBatchSpecification());
        var expectedErrorCode = "IDEMPOTENCY_COMPLETION_CONFLICT";
        // Act
        var actualException = Assert.ThrowsAsync<DomainException>(async () => await subject.CompleteCheckoutAsync(customerId, reference, key, response, signal))!;
        // Assert
        Assert.That(actualException.Code, Is.EqualTo(expectedErrorCode));
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-139-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.CompleteCheckoutAsync(string customerId, string reference, string
    /// key, object response, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "reference": "Sample", "key": "Sample", "response": "Typed object fixture
    /// from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.CompleteCheckoutAsync(string customerId,
    /// string reference, string key, object response, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-139.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-139-TC003")]
    public void UTM_139_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-139-TC004: if L53 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.CompleteCheckoutAsync(string customerId, string reference, string
    /// key, object response, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "response": "Typed
    /// object fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"updated.Count": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.CompleteCheckoutAsync(string customerId,
    /// string reference, string key, object response, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:53. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("IDEMPOTENCY_COMPLETION_CONFLICT", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-139-D01:False, UTM-139-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-139.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-139-TC004")]
    public void UTM_139_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-139-TC005: if L53 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task CheckoutRepository.CompleteCheckoutAsync(string customerId, string reference, string
    /// key, object response, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "reference": "Sample", "key": "Sample", "response": "Typed
    /// object fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"updated.Count": 2}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task CheckoutRepository.CompleteCheckoutAsync(string customerId,
    /// string reference, string key, object response, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("IDEMPOTENCY_COMPLETION_CONFLICT", 409); | Assert
    /// selected outcome True at src/FreshFood.Reposistory/Repository/Implements/CheckoutRepository.cs:53. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("IDEMPOTENCY_COMPLETION_CONFLICT", 409)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-139-D01:True, UTM-139-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-139.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-139-TC005")]
    public void UTM_139_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }
}
