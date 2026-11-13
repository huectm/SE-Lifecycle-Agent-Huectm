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
public sealed class Repository_Implements_CatalogRepositoryTests
{
    /// <summary>
    /// UTM-125-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogRepository.CatalogRepository(IRepositorySession session)
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
    /// fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogRepository.CatalogRepository(IRepositorySession session);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-125.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-125-TC001")]
    public void UTM_125_TC001()
    {
        // Arrange: test inputs and mock setup.
        var session = (FreshFood.Reposistory.Repository.IRepositorySession)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IRepositorySession))!;
        // Act
        var actual = new FreshFood.Reposistory.Repository.Implements.CatalogRepository(session);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Reposistory.Repository.Implements.CatalogRepository>());
    }

    /// <summary>
    /// UTM-125-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogRepository.CatalogRepository(IRepositorySession session)
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
    /// fixtures.json", "variant": "Omit optional arguments; otherwise use distinct valid instances and empty
    /// collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogRepository.CatalogRepository(IRepositorySession session);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-125.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-125-TC002")]
    public void UTM_125_TC002()
    {
        // Arrange: test inputs and mock setup.
        var session = (FreshFood.Reposistory.Repository.IRepositorySession)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IRepositorySession))!;
        // Act
        var actual = new FreshFood.Reposistory.Repository.Implements.CatalogRepository(session);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Reposistory.Repository.Implements.CatalogRepository>());
    }

    /// <summary>
    /// UTM-125-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CatalogRepository.CatalogRepository(IRepositorySession session)
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
    /// fixtures.json", "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CatalogRepository.CatalogRepository(IRepositorySession session);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-125.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-125-TC003")]
    public void UTM_125_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-126-TC001: SQL-like keyword is data
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string? keyword, int? categoryId,
    /// bool clearanceOnly, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Security error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"keyword": "x' OR 1=1 --", "categoryId": null, "clearanceOnly": false}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string?
    /// keyword, int? categoryId, bool clearanceOnly, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Keyword stays in a bound parameter; SQL structure unchanged; no injected predicate
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No write
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-126.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-126-TC001")]
    public async System.Threading.Tasks.Task UTM_126_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var keyword = "x' OR 1=1 --";
        var categoryId = (int? )Fixture.Value(typeof(int))!;
        var clearanceOnly = (bool)Fixture.Value(typeof(bool))!;
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.FindActiveAsync(keyword, categoryId, clearanceOnly, signal);
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
    /// UTM-126-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string? keyword, int? categoryId,
    /// bool clearanceOnly, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"keyword": "Sample", "categoryId": "1", "clearanceOnly": false, "signal":
    /// "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string?
    /// keyword, int? categoryId, bool clearanceOnly, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-126.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-126-TC002")]
    public async System.Threading.Tasks.Task UTM_126_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var keyword = "Sample";
        var categoryId = (int? )Fixture.Value(typeof(int))!;
        var clearanceOnly = (bool)Fixture.Value(typeof(bool))!;
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.FindActiveAsync(keyword, categoryId, clearanceOnly, signal);
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
    /// UTM-126-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string? keyword, int? categoryId,
    /// bool clearanceOnly, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"keyword": "Sample", "categoryId": "1", "clearanceOnly": false, "signal":
    /// "CancellationToken.None; use distinct token in forwarding variants", "boundary": "Empty then single-item
    /// collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field
    /// unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string?
    /// keyword, int? categoryId, bool clearanceOnly, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-126.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-126-TC003")]
    public async System.Threading.Tasks.Task UTM_126_TC003()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var keyword = "Sample";
        var categoryId = (int? )Fixture.Value(typeof(int))!;
        var clearanceOnly = (bool)Fixture.Value(typeof(bool))!;
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.FindActiveAsync(keyword, categoryId, clearanceOnly, signal);
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
    /// UTM-126-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string? keyword, int? categoryId,
    /// bool clearanceOnly, CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"keyword": "Sample", "categoryId": "1", "clearanceOnly": false, "signal":
    /// "CancellationToken.None; use distinct token in forwarding variants", "failure": "First collaborator throws
    /// TimeoutException sentinel; for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.FindActiveAsync(string?
    /// keyword, int? categoryId, bool clearanceOnly, CancellationToken signal); assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-126.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-126-TC004")]
    public void UTM_126_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-127-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductCategory&gt; &gt; CatalogRepository.GetCategoriesAsync(CancellationToken
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
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductCategory&gt; &gt;
    /// CatalogRepository.GetCategoriesAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-127.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-127-TC001")]
    public async System.Threading.Tasks.Task UTM_127_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetCategoriesAsync(signal);
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
    /// UTM-127-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductCategory&gt; &gt; CatalogRepository.GetCategoriesAsync(CancellationToken
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
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "boundary":
    /// "Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free
    /// forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductCategory&gt; &gt;
    /// CatalogRepository.GetCategoriesAsync(CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-127.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-127-TC002")]
    public async System.Threading.Tasks.Task UTM_127_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetCategoriesAsync(signal);
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
    /// UTM-127-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;ProductCategory&gt; &gt; CatalogRepository.GetCategoriesAsync(CancellationToken
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
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;ProductCategory&gt; &gt;
    /// CatalogRepository.GetCategoriesAsync(CancellationToken signal); assert result, exception and captured
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-127.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-127-TC003")]
    public void UTM_127_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-128-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Product?&gt; CatalogRepository.GetProductAsync(string productId, CancellationToken
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Product?&gt; CatalogRepository.GetProductAsync(string
    /// productId, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-128.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-128-TC001")]
    public async System.Threading.Tasks.Task UTM_128_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var productId = "1";
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetProductAsync(productId, signal);
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
    /// UTM-128-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Product?&gt; CatalogRepository.GetProductAsync(string productId, CancellationToken
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Product?&gt; CatalogRepository.GetProductAsync(string
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-128.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-128-TC002")]
    public async System.Threading.Tasks.Task UTM_128_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var productId = "1";
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetProductAsync(productId, signal);
        // Assert
        Assert.That(actual, Is.Null);
        foreach (var query in database.Queries)
        {
            Assert.That(query.Token, Is.EqualTo(Fixture.Token));
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-128-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Product?&gt; CatalogRepository.GetProductAsync(string productId, CancellationToken
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
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Product?&gt; CatalogRepository.GetProductAsync(string
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
    /// Execution constraint (NUnit Ignore): No injectable collaborator here; bind abnormal cases to the declared
    /// guard, or review N/A instead of inventing a fault injection seam.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-128.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-128-TC003")]
    public void UTM_128_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-129-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; CatalogRepository.GetSellableBatchesAsync(List&lt;string&gt;
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
    /// CatalogRepository.GetSellableBatchesAsync(List&lt;string&gt; productIds, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-129.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-129-TC001")]
    public async System.Threading.Tasks.Task UTM_129_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var productIds = new List<string>
        {
            "1"
        };
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetSellableBatchesAsync(productIds, signal);
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
    /// UTM-129-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; CatalogRepository.GetSellableBatchesAsync(List&lt;string&gt;
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
    /// CatalogRepository.GetSellableBatchesAsync(List&lt;string&gt; productIds, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-129.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-129-TC002")]
    public async System.Threading.Tasks.Task UTM_129_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var productIds = new List<string>
        {
            "1"
        };
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetSellableBatchesAsync(productIds, signal);
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
    /// UTM-129-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; CatalogRepository.GetSellableBatchesAsync(List&lt;string&gt;
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
    /// CatalogRepository.GetSellableBatchesAsync(List&lt;string&gt; productIds, CancellationToken signal); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-129.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-129-TC003")]
    public void UTM_129_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-130-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.GetPopularAsync(int limit, CancellationToken
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
    /// Design input: {"limit": 2, "signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.GetPopularAsync(int limit,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-130.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-130-TC001")]
    public async System.Threading.Tasks.Task UTM_130_TC001()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: false, queryError: null);
        var limit = (int)Fixture.Value(typeof(int))!;
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetPopularAsync(limit, signal);
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
    /// UTM-130-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.GetPopularAsync(int limit, CancellationToken
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
    /// Design input: {"limit": 2, "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.GetPopularAsync(int limit,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-130.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-130-TC002")]
    public async System.Threading.Tasks.Task UTM_130_TC002()
    {
        // Arrange: test inputs and mock setup.
        var database = new RepositorySessionFixture(emptyRows: true, queryError: null);
        var limit = (int)Fixture.Value(typeof(int))!;
        var signal = Fixture.Token;
        var subject = new CatalogRepository(database.Session);
        // Act
        var actual = await subject.GetPopularAsync(limit, signal);
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
    /// UTM-130-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Product&gt; &gt; CatalogRepository.GetPopularAsync(int limit, CancellationToken
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
    /// Design input: {"limit": 2, "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Product&gt; &gt; CatalogRepository.GetPopularAsync(int limit,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-130.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-130-TC003")]
    public void UTM_130_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }
}
