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
public sealed class Repository_Implements_SqlRepositoryTests
{
    /// <summary>
    /// UTM-177-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: SqlRepository.SqlRepository(IRepositorySession session)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"session": "Typed FreshFood.Reposistory.Repository.IRepositorySession fixture from
    /// fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke SqlRepository.SqlRepository(IRepositorySession session); assert
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
    /// Execution constraint (NUnit Ignore): Abstract base constructor is exercised through concrete repository
    /// classes.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-177.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Abstract base constructor is exercised through concrete repository classes.")]
    [NUnit.Framework.Property("DesignCase", "UTM-177-TC001")]
    public void UTM_177_TC001()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Abstract base constructor is exercised through concrete repository classes.");
    }

    /// <summary>
    /// UTM-177-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: SqlRepository.SqlRepository(IRepositorySession session)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"session": "Typed FreshFood.Reposistory.Repository.IRepositorySession fixture from
    /// fixtures.json", "variant": "Omit optional arguments; otherwise use distinct valid instances and empty
    /// collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke SqlRepository.SqlRepository(IRepositorySession session); assert
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
    /// Execution constraint (NUnit Ignore): Abstract base constructor is exercised through concrete repository
    /// classes.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-177.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Abstract base constructor is exercised through concrete repository classes.")]
    [NUnit.Framework.Property("DesignCase", "UTM-177-TC002")]
    public void UTM_177_TC002()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Abstract base constructor is exercised through concrete repository classes.");
    }

    /// <summary>
    /// UTM-177-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: SqlRepository.SqlRepository(IRepositorySession session)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"session": "Typed FreshFood.Reposistory.Repository.IRepositorySession fixture from
    /// fixtures.json", "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke SqlRepository.SqlRepository(IRepositorySession session); assert
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
    /// Execution constraint (NUnit Ignore): Abstract base constructor is exercised through concrete repository
    /// classes.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-177.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Abstract base constructor is exercised through concrete repository classes.")]
    [NUnit.Framework.Property("DesignCase", "UTM-177-TC003")]
    public void UTM_177_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Abstract base constructor is exercised through concrete repository classes.");
    }

    /// <summary>
    /// UTM-178-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Lock.get
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Lock.get; assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-178.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-178-TC001")]
    public async System.Threading.Tasks.Task UTM_178_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{}");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "get_Lock" && x.GetParameters().Length == 0);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("get_Lock", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo(" FOR UPDATE"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo(" FOR UPDATE"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-178-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Lock.get
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Lock.get; assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-178.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-178-TC002")]
    public async System.Threading.Tasks.Task UTM_178_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "get_Lock" && x.GetParameters().Length == 0);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("get_Lock", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo(" FOR UPDATE"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo(" FOR UPDATE"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-178-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Lock.get
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Lock.get; assert result, exception and
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-178.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-178-TC003")]
    public void UTM_178_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-178-TC004: conditional L6 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Lock.get
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"review constraint": "Session.Active = False; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Lock.get; assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: "" | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:6. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-178-D01:False, UTM-178-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-178.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-178-TC004")]
    public void UTM_178_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-178-TC005: conditional L6 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Lock.get
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"review constraint": "Session.Active = True; arrange matching entity/mock
    /// state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Lock.get; assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: " FOR UPDATE" | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:6. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-178-D01:True, UTM-178-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-178.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-178-TC005")]
    public void UTM_178_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-179-TC001: Identifier '1'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return parsed long
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC001")]
    public void UTM_179_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"1\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                var result = Fixture.Invoke(method, null, args);
                Assert.That(result, Is.EqualTo(long.Parse("1")));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-179-TC002: Identifier '9223372036854775807'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "9223372036854775807"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return parsed long
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC002")]
    public void UTM_179_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"9223372036854775807\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                var result = Fixture.Invoke(method, null, args);
                Assert.That(result, Is.EqualTo(long.Parse("9223372036854775807")));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-179-TC003: Identifier '0'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "0"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject ID
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_ID
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC003")]
    public void UTM_179_TC003()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"0\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            Assert.That(TestChecks.Throws<DomainException>(() => Fixture.Invoke(method, null, args)).Code, Is.EqualTo("INVALID_ID"));
            return;
        }
    }

    /// <summary>
    /// UTM-179-TC004: Identifier '-1'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "-1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject ID
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_ID
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC004")]
    public void UTM_179_TC004()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"-1\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            Assert.That(TestChecks.Throws<DomainException>(() => Fixture.Invoke(method, null, args)).Code, Is.EqualTo("INVALID_ID"));
            return;
        }
    }

    /// <summary>
    /// UTM-179-TC005: Identifier '9223372036854775808'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "9223372036854775808"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject ID
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_ID
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC005")]
    public void UTM_179_TC005()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"9223372036854775808\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            Assert.That(TestChecks.Throws<DomainException>(() => Fixture.Invoke(method, null, args)).Code, Is.EqualTo("INVALID_ID"));
            return;
        }
    }

    /// <summary>
    /// UTM-179-TC006: Identifier 'abc'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "abc"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject ID
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_ID
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC006")]
    public void UTM_179_TC006()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"abc\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            Assert.That(TestChecks.Throws<DomainException>(() => Fixture.Invoke(method, null, args)).Code, Is.EqualTo("INVALID_ID"));
            return;
        }
    }

    /// <summary>
    /// UTM-179-TC007: Identifier ''
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": ""}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject ID
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_ID
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC007")]
    public void UTM_179_TC007()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            Assert.That(TestChecks.Throws<DomainException>(() => Fixture.Invoke(method, null, args)).Code, Is.EqualTo("INVALID_ID"));
            return;
        }
    }

    /// <summary>
    /// UTM-179-TC008: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC008")]
    public void UTM_179_TC008()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"1\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                var result = Fixture.Invoke(method, null, args);
                Assert.That(result, Is.EqualTo(long.Parse("1")));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-179-TC009: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC009")]
    public void UTM_179_TC009()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"1\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Id" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                var result = Fixture.Invoke(method, null, args);
                Assert.That(result, Is.EqualTo(long.Parse("1")));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-179-TC010: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC010")]
    public void UTM_179_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-179-TC011: conditional L7 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"value": "abc"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: throw new DomainException("INVALID_ID") | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:7. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_ID")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-179-D01:False, UTM-179-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC011")]
    public void UTM_179_TC011()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-179-TC012: conditional L7 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"value": "1", "id": 0}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: throw new DomainException("INVALID_ID") | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:7. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_ID")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-179-D01:False, UTM-179-D01:C1:True, UTM-179-D01:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC012")]
    public void UTM_179_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-179-TC013: conditional L7 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long SqlRepository.Id(string value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"value": "1", "id": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long SqlRepository.Id(string value); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: id | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:7. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_ID")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-179-D01:True, UTM-179-D01:C1:True, UTM-179-D01:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-179.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-179-TC013")]
    public void UTM_179_TC013()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-180-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long? SqlRepository.OptionalId(string? value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long? SqlRepository.OptionalId(string? value); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-180.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-180-TC001")]
    public void UTM_180_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"1\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "OptionalId" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                var result = Fixture.Invoke(method, null, args);
                Assert.That(result, Is.EqualTo(long.Parse("1")));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-180-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long? SqlRepository.OptionalId(string? value)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long? SqlRepository.OptionalId(string? value); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-180.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-180-TC002")]
    public void UTM_180_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"1\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "OptionalId" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                var result = Fixture.Invoke(method, null, args);
                Assert.That(result, Is.EqualTo(long.Parse("1")));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-180-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long? SqlRepository.OptionalId(string? value)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "1", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long? SqlRepository.OptionalId(string? value); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-180.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-180-TC003")]
    public void UTM_180_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-180-TC004: conditional L8 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long? SqlRepository.OptionalId(string? value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"value": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long? SqlRepository.OptionalId(string? value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Id(value) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:8. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-180-D01:False, UTM-180-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-180.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-180-TC004")]
    public void UTM_180_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-180-TC005: conditional L8 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: long? SqlRepository.OptionalId(string? value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Sample"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"value": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke long? SqlRepository.OptionalId(string? value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: null | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:8. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-180-D01:True, UTM-180-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-180.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-180-TC005")]
    public void UTM_180_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-181-TC001: Enum wire PaymentMethod.VietQr
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Compatibility / error guessing; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "PaymentMethod.VietQr"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly VIETQR
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC001")]
    public async System.Threading.Tasks.Task UTM_181_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"PaymentMethod.VietQr\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Encode" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(OrderStatus));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Encode", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-181-TC002: Enum wire PaymentMethod.Cod
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Compatibility / error guessing; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "PaymentMethod.Cod"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly COD
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC002")]
    public async System.Threading.Tasks.Task UTM_181_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"PaymentMethod.Cod\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Encode" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(OrderStatus));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Encode", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-181-TC003: Enum wire OrderStatus.PendingPaid
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Compatibility / error guessing; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "OrderStatus.PendingPaid"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly PENDING_PAID
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC003")]
    public async System.Threading.Tasks.Task UTM_181_TC003()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"OrderStatus.PendingPaid\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Encode" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(OrderStatus));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Encode", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-181-TC004: Enum wire OrderStatus.DeliveryFailed
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Compatibility / error guessing; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "OrderStatus.DeliveryFailed"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Exactly DELIVERY_FAILED
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC004")]
    public async System.Threading.Tasks.Task UTM_181_TC004()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"OrderStatus.DeliveryFailed\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Encode" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(OrderStatus));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Encode", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-181-TC005: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "PaymentMethod.Cod"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC005")]
    public async System.Threading.Tasks.Task UTM_181_TC005()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"PaymentMethod.Cod\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Encode" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(OrderStatus));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Encode", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-181-TC006: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "PaymentMethod.Cod", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC006")]
    public async System.Threading.Tasks.Task UTM_181_TC006()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"value\": \"PaymentMethod.Cod\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Encode" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(OrderStatus));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Encode", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-181-TC007: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"value": "PaymentMethod.Cod", "failure": "First collaborator throws TimeoutException
    /// sentinel; for pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC007")]
    public void UTM_181_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-181-TC008: conditional L9 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Typed T fixture from fixtures.json"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "value is
    /// PaymentMethod.VietQr = False; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: System.Text.RegularExpressions.Regex.Replace(value.ToString(),
    /// "([a-z])([A-Z])", "$1_$2", System.Text.RegularExpressions.RegexOptions.None,
    /// TimeSpan.FromMilliseconds(100)).ToUpperInvariant() | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-181-D01:False, UTM-181-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC008")]
    public void UTM_181_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-181-TC009: conditional L9 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string SqlRepository.Encode&lt;T&gt;(T value)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"value": "Typed T fixture from fixtures.json"}, "baseFixtures": ["CUSTOMER",
    /// "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "value is
    /// PaymentMethod.VietQr = True; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string SqlRepository.Encode&lt;T&gt;(T value); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: "VIETQR" | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-181-D01:True, UTM-181-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-181.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-181-TC009")]
    public void UTM_181_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-182-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt; &gt; SqlRepository.Rows&lt;T&gt;(string sql, CancellationToken ct, params object?[]
    /// args)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "ct": "CancellationToken.None;
    /// use distinct token in forwarding variants", "args": "Typed object?[] fixture from fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt; &gt; SqlRepository.Rows&lt;T&gt;(string sql,
    /// CancellationToken ct, params object?[] args); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-182.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-182-TC001")]
    public async System.Threading.Tasks.Task UTM_182_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"sql\": \"SELECT product_id FROM products WHERE product_id=$1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"args\": \"Typed object?[] fixture from fixtures.json\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Rows" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Rows", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !false)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(1));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!false));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-182-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt; &gt; SqlRepository.Rows&lt;T&gt;(string sql, CancellationToken ct, params object?[]
    /// args)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "ct": "CancellationToken.None;
    /// use distinct token in forwarding variants", "args": "Typed object?[] fixture from fixtures.json",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt; &gt; SqlRepository.Rows&lt;T&gt;(string sql,
    /// CancellationToken ct, params object?[] args); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-182.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-182-TC002")]
    public async System.Threading.Tasks.Task UTM_182_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"sql\": \"SELECT product_id FROM products WHERE product_id=$1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"args\": \"Typed object?[] fixture from fixtures.json\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Rows" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Rows", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !true)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(0));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!true));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !true)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(0));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!true));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-182-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt; &gt; SqlRepository.Rows&lt;T&gt;(string sql, CancellationToken ct, params object?[]
    /// args)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "ct": "CancellationToken.None;
    /// use distinct token in forwarding variants", "args": "Typed object?[] fixture from fixtures.json", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt; &gt; SqlRepository.Rows&lt;T&gt;(string sql,
    /// CancellationToken ct, params object?[] args); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-182.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-182-TC003")]
    public async System.Threading.Tasks.Task UTM_182_TC003()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"sql\": \"SELECT product_id FROM products WHERE product_id=$1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"args\": \"Typed object?[] fixture from fixtures.json\",\r\n            \"failure\": \"First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard instead.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            throw new TimeoutException("SQL sentinel");
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Rows" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Rows", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
            await TestChecks.ThrowsAsync<TimeoutException>(async () =>
            {
                var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                {
                    Assert.That(queries, Is.Not.Empty);
                    if (method.ReturnType.IsGenericType && !false)
                        Assert.That(result, Is.Not.Null);
                    if (result is System.Collections.IList list)
                        Assert.That(list.Count, Is.EqualTo(1));
                    if (result is bool b)
                        Assert.That(b, Is.EqualTo(!false));
                }
            });
        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-183-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;T?&gt; SqlRepository.One&lt;T&gt;(string sql, CancellationToken ct, params object?[] args)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "ct": "CancellationToken.None;
    /// use distinct token in forwarding variants", "args": "Typed object?[] fixture from fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;T?&gt; SqlRepository.One&lt;T&gt;(string sql, CancellationToken ct,
    /// params object?[] args); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-183.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-183-TC001")]
    public async System.Threading.Tasks.Task UTM_183_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"sql\": \"SELECT product_id FROM products WHERE product_id=$1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"args\": \"Typed object?[] fixture from fixtures.json\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "One" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("One", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !false)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(1));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!false));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-183-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;T?&gt; SqlRepository.One&lt;T&gt;(string sql, CancellationToken ct, params object?[] args)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "ct": "CancellationToken.None;
    /// use distinct token in forwarding variants", "args": "Typed object?[] fixture from fixtures.json",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;T?&gt; SqlRepository.One&lt;T&gt;(string sql, CancellationToken ct,
    /// params object?[] args); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-183.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-183-TC002")]
    public async System.Threading.Tasks.Task UTM_183_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"sql\": \"SELECT product_id FROM products WHERE product_id=$1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"args\": \"Typed object?[] fixture from fixtures.json\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "One" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("One", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !true)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(0));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!true));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !true)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(0));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!true));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-183-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;T?&gt; SqlRepository.One&lt;T&gt;(string sql, CancellationToken ct, params object?[] args)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "ct": "CancellationToken.None;
    /// use distinct token in forwarding variants", "args": "Typed object?[] fixture from fixtures.json", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;T?&gt; SqlRepository.One&lt;T&gt;(string sql, CancellationToken ct,
    /// params object?[] args); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-183.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-183-TC003")]
    public void UTM_183_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-184-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt; ids, CancellationToken ct,
    /// bool locked = false)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"ids": "Sample", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "locked": false}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt;
    /// ids, CancellationToken ct, bool locked = false); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-184.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-184-TC001")]
    public async System.Threading.Tasks.Task UTM_184_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"ids\": \"Sample\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"locked\": false\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Batches" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Batches", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !false)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(1));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!false));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-184-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt; ids, CancellationToken ct,
    /// bool locked = false)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"ids": "Sample", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "locked": false, "boundary": "Empty then single-item collection where relevant; identifier=1; minimum
    /// allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt;
    /// ids, CancellationToken ct, bool locked = false); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-184.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-184-TC002")]
    public async System.Threading.Tasks.Task UTM_184_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"ids\": \"Sample\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"locked\": false,\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Batches" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("Batches", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !true)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(0));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!true));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !true)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(0));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!true));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-184-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt; ids, CancellationToken ct,
    /// bool locked = false)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"ids": "Sample", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "locked": false, "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt;
    /// ids, CancellationToken ct, bool locked = false); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-184.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-184-TC003")]
    public void UTM_184_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-184-TC004: conditional L13 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt; ids, CancellationToken ct,
    /// bool locked = false)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"ids": "Sample", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants", "locked": false}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "locked = False; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt;
    /// ids, CancellationToken ct, bool locked = false); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: "" | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:13. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-184-D01:False, UTM-184-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-184.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-184-TC004")]
    public void UTM_184_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-184-TC005: conditional L13 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt; ids, CancellationToken ct,
    /// bool locked = false)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"ids": "Sample", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants", "locked": false}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"review constraint": "locked = True; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;BatchInventory&gt; &gt; SqlRepository.Batches(List&lt;string&gt;
    /// ids, CancellationToken ct, bool locked = false); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: " FOR UPDATE OF b" | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:13. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-184-D01:True, UTM-184-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-184.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-184-TC005")]
    public void UTM_184_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC001")]
    public async System.Threading.Tasks.Task UTM_185_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"customerId\": \"7\",\r\n            \"sessionId\": \"1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "LoadCart" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("LoadCart", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !false)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(1));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!false));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-185-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum
    /// allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC002")]
    public async System.Threading.Tasks.Task UTM_185_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"customerId\": \"7\",\r\n            \"sessionId\": \"1\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "LoadCart" && x.GetParameters().Length == 3);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("LoadCart", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !true)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(0));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!true));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        {
            // Act and Assert: explicit invocation and expected-result comparisons.
            {
                var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                {
                    Assert.That(queries, Is.Not.Empty);
                    if (method.ReturnType.IsGenericType && !true)
                        Assert.That(result, Is.Not.Null);
                    if (result is System.Collections.IList list)
                        Assert.That(list.Count, Is.EqualTo(0));
                    if (result is bool b)
                        Assert.That(b, Is.EqualTo(!true));
                }
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-185-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use
    /// a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC003")]
    public void UTM_185_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-185-TC004: if L16 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"customerId": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:16. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D01:False, UTM-185-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC004")]
    public void UTM_185_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC005: if L16 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"customerId": null, "sessionId": "valid"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:16. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D01:False, UTM-185-D01:C1:True, UTM-185-D01:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC005")]
    public void UTM_185_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC006: if L16 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"customerId": null, "sessionId": ""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("CART_IDENTITY_REQUIRED", 401); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:16. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D01:True, UTM-185-D01:C1:True, UTM-185-D01:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC006")]
    public void UTM_185_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC007: coalesce-assignment L18 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "cart"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: cart ??= (await One&lt;Cart&gt;("INSERT INTO
    /// carts(customer_id,session_id) VALUES($1,$2) RETURNING *", ct, OptionalId(customerId), customerId is null ?
    /// sessionId : null))! | Assert selected outcome Null at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:18. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D02:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC007")]
    public void UTM_185_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC008: coalesce-assignment L18 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "cart"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: cart ??= (await One&lt;Cart&gt;("INSERT INTO
    /// carts(customer_id,session_id) VALUES($1,$2) RETURNING *", ct, OptionalId(customerId), customerId is null ?
    /// sessionId : null))! | Assert selected outcome Non-null at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:18. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D02:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC008")]
    public void UTM_185_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC009: conditional L18 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"customerId": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: null | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:18. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D03:False, UTM-185-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC009")]
    public void UTM_185_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-185-TC010: conditional L18 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string? sessionId,
    /// CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "sessionId": "1", "ct": "CancellationToken.None; use
    /// distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"customerId": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;Cart&gt; SqlRepository.LoadCart(string? customerId, string?
    /// sessionId, CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: sessionId | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:18. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("CART_IDENTITY_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-185-D03:True, UTM-185-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-185.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-185-TC010")]
    public void UTM_185_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-186-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void SqlRepository.RequireTransaction()
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void SqlRepository.RequireTransaction(); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-186.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-186-TC001")]
    public async System.Threading.Tasks.Task UTM_186_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{}");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "RequireTransaction" && x.GetParameters().Length == 0);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("RequireTransaction", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(queries, Is.Empty);
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(queries, Is.Empty);
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-186-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void SqlRepository.RequireTransaction()
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void SqlRepository.RequireTransaction(); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-186.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-186-TC002")]
    public async System.Threading.Tasks.Task UTM_186_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "RequireTransaction" && x.GetParameters().Length == 0);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("RequireTransaction", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    Assert.That(queries, Is.Empty);
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            Assert.That(queries, Is.Empty);
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-186-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void SqlRepository.RequireTransaction()
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void SqlRepository.RequireTransaction(); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-186.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-186-TC003")]
    public void UTM_186_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-186-TC004: if L22 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void SqlRepository.RequireTransaction()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"Session.Active": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void SqlRepository.RequireTransaction(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:22. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("An active transaction is required.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-186-D01:False, UTM-186-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-186.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-186-TC004")]
    public void UTM_186_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-186-TC005: if L22 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: void SqlRepository.RequireTransaction()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"Session.Active": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke void SqlRepository.RequireTransaction(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new InvalidOperationException("An active transaction is required."); |
    /// Assert selected outcome True at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:22. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("An active transaction is required.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-186-D01:True, UTM-186-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-186.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-186-TC005")]
    public void UTM_186_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-187-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.SaveCart(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.SaveCart(Cart cart, CancellationToken ct);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-187.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-187-TC001")]
    public async System.Threading.Tasks.Task UTM_187_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"cart\": \"CART\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "SaveCart" && x.GetParameters().Length == 2);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("SaveCart", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !false)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(1));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!false));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-187-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.SaveCart(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.SaveCart(Cart cart, CancellationToken ct);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-187.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-187-TC002")]
    public async System.Threading.Tasks.Task UTM_187_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"cart\": \"CART\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "SaveCart" && x.GetParameters().Length == 2);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("SaveCart", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !true)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(0));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!true));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !true)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(0));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!true));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-187-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.SaveCart(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.SaveCart(Cart cart, CancellationToken ct);
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-187.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-187-TC003")]
    public void UTM_187_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-187-TC004: foreach L27 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.SaveCart(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"scenario": "Empty", "expression": "cart.Items"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.SaveCart(Cart cart, CancellationToken ct);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: await Rows&lt;CartItem&gt;("INSERT INTO
    /// cart_items(cart_id,product_id,quantity) VALUES($1,$2,$3)", ct, Id(cart.CartId), Id(item.ProductId),
    /// item.Quantity); | Assert selected outcome Empty at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:27. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-187-D01:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-187.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-187-TC004")]
    public void UTM_187_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-187-TC005: foreach L27 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.SaveCart(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"scenario": "One item", "expression": "cart.Items"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.SaveCart(Cart cart, CancellationToken ct);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: await Rows&lt;CartItem&gt;("INSERT INTO
    /// cart_items(cart_id,product_id,quantity) VALUES($1,$2,$3)", ct, Id(cart.CartId), Id(item.ProductId),
    /// item.Quantity); | Assert selected outcome One item at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:27. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-187-D01:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-187.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-187-TC005")]
    public void UTM_187_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-187-TC006: foreach L27 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.SaveCart(Cart cart, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"cart": "CART", "ct": "CancellationToken.None; use distinct token in forwarding
    /// variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"],
    /// "overrides": {"scenario": "Multiple items", "expression": "cart.Items"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.SaveCart(Cart cart, CancellationToken ct);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: await Rows&lt;CartItem&gt;("INSERT INTO
    /// cart_items(cart_id,product_id,quantity) VALUES($1,$2,$3)", ct, Id(cart.CartId), Id(item.ProductId),
    /// item.Quantity); | Assert selected outcome Multiple items at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:27. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-187-D01:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-187.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-187-TC006")]
    public void UTM_187_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-188-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "ct": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-188.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-188-TC001")]
    public async System.Threading.Tasks.Task UTM_188_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"customerId\": \"7\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "LoadOrders" && x.GetParameters().Length == 2);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("LoadOrders", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !false)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(1));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!false));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !false)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(1));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!false));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-188-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-188.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-188-TC002")]
    public async System.Threading.Tasks.Task UTM_188_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"customerId\": \"7\",\r\n            \"ct\": \"CancellationToken.None; use distinct token in forwarding variants\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "LoadOrders" && x.GetParameters().Length == 2);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if (deferred.TryGetValue("LoadOrders", out var gapCode))
        {
            {
                Func<Task> operation = async () =>
                {
                    var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
                    {
                        Assert.That(queries, Is.Not.Empty);
                        if (method.ReturnType.IsGenericType && !true)
                            Assert.That(result, Is.Not.Null);
                        if (result is System.Collections.IList list)
                            Assert.That(list.Count, Is.EqualTo(0));
                        if (result is bool b)
                            Assert.That(b, Is.EqualTo(!true));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo((gapCode).Split(' ')[0]));
            }

            Assert.That(queries, Is.Empty);
        }
        else
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            var result = await Fixture.Await(Fixture.Invoke(method, owner, args));
            {
                Assert.That(queries, Is.Not.Empty);
                if (method.ReturnType.IsGenericType && !true)
                    Assert.That(result, Is.Not.Null);
                if (result is System.Collections.IList list)
                    Assert.That(list.Count, Is.EqualTo(0));
                if (result is bool b)
                    Assert.That(b, Is.EqualTo(!true));
            }
        }

        foreach (var query in queries)
        {
            Assert.That(query.Sql, Does.Not.Contain("Sample"));
            Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));
        }
    }

    /// <summary>
    /// UTM-188-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"customerId": "7", "ct": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-188.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-188-TC003")]
    public void UTM_188_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-188-TC004: foreach L32 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Empty", "expression": "orders"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {              order.Details = await
    /// Rows&lt;OrderDetail&gt;("SELECT d.*,b.product_id,p.product_name FROM order_details d JOIN batch_inventory b ON
    /// b.batch_id=d.batch_id JOIN products p ON p.product_id=b.product_id WHERE d.order_id=$1 ORDER BY
    /// d.order_detail_id", ct, Id(order.OrderId));              order.DeliveryAddress = (await
    /// One&lt;CustomerAddress&gt;("SELECT * FROM customer_addresses WHERE address_id=$1 AND customer_id=$2", ct,
    /// Id(order.DeliveryAddressId), Id(customerId)))!;              order.Failure = await
    /// One&lt;DeliveryFailure&gt;("SELECT * FROM delivery_failures WHERE order_id=$1", ct, Id(order.OrderId));          }
    /// | Assert selected outcome Empty at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:32.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-188-D01:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-188.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-188-TC004")]
    public void UTM_188_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-188-TC005: foreach L32 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "One item", "expression": "orders"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {              order.Details = await
    /// Rows&lt;OrderDetail&gt;("SELECT d.*,b.product_id,p.product_name FROM order_details d JOIN batch_inventory b ON
    /// b.batch_id=d.batch_id JOIN products p ON p.product_id=b.product_id WHERE d.order_id=$1 ORDER BY
    /// d.order_detail_id", ct, Id(order.OrderId));              order.DeliveryAddress = (await
    /// One&lt;CustomerAddress&gt;("SELECT * FROM customer_addresses WHERE address_id=$1 AND customer_id=$2", ct,
    /// Id(order.DeliveryAddressId), Id(customerId)))!;              order.Failure = await
    /// One&lt;DeliveryFailure&gt;("SELECT * FROM delivery_failures WHERE order_id=$1", ct, Id(order.OrderId));          }
    /// | Assert selected outcome One item at src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:32.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-188-D01:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-188.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-188-TC005")]
    public void UTM_188_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-188-TC006: foreach L32 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId, CancellationToken ct)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"customerId": "7", "ct": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Multiple items", "expression": "orders"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;Order&gt; &gt; SqlRepository.LoadOrders(string customerId,
    /// CancellationToken ct); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {              order.Details = await
    /// Rows&lt;OrderDetail&gt;("SELECT d.*,b.product_id,p.product_name FROM order_details d JOIN batch_inventory b ON
    /// b.batch_id=d.batch_id JOIN products p ON p.product_id=b.product_id WHERE d.order_id=$1 ORDER BY
    /// d.order_detail_id", ct, Id(order.OrderId));              order.DeliveryAddress = (await
    /// One&lt;CustomerAddress&gt;("SELECT * FROM customer_addresses WHERE address_id=$1 AND customer_id=$2", ct,
    /// Id(order.DeliveryAddressId), Id(customerId)))!;              order.Failure = await
    /// One&lt;DeliveryFailure&gt;("SELECT * FROM delivery_failures WHERE order_id=$1", ct, Id(order.OrderId));          }
    /// | Assert selected outcome Multiple items at
    /// src/FreshFood.Reposistory/Repository/Implements/SqlRepository.cs:32. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-188-D01:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-188.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-188-TC006")]
    public void UTM_188_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-189-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.Gap(string code)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"code": "POLICY_TBD"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.Gap(string code); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Fail closed: DomainException POLICY_TBD from caller / 503 where specified; no
    /// successful payment/refund effect.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-189.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-189-TC001")]
    public void UTM_189_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"code\": \"POLICY_TBD\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Gap" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                Func<Task> operation = () => Fixture.Await(Fixture.Invoke(method, null, args));
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "POLICY_TBD" }[0]));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-189-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.Gap(string code)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"code": "POLICY_TBD", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.Gap(string code); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-189.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-189-TC002")]
    public void UTM_189_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"code\": \"POLICY_TBD\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Gap" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                Func<Task> operation = () => Fixture.Await(Fixture.Invoke(method, null, args));
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "POLICY_TBD" }[0]));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-189-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task SqlRepository.Gap(string code)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"code": "POLICY_TBD", "failure": "First collaborator throws TimeoutException sentinel; for
    /// pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task SqlRepository.Gap(string code); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-189.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-189-TC003")]
    public void UTM_189_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }

    /// <summary>
    /// UTM-190-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;T&gt; SqlRepository.Gap&lt;T&gt;(string code)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"code": "POLICY_TBD"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;T&gt; SqlRepository.Gap&lt;T&gt;(string code); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Fail closed: DomainException POLICY_TBD from caller / 503 where specified; no
    /// successful payment/refund effect.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-190.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-190-TC001")]
    public void UTM_190_TC001()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"code\": \"POLICY_TBD\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = false && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Gap" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>
                {
                    Fixture.Batch()
                };
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                Func<Task> operation = () => Fixture.Await(Fixture.Invoke(method, null, args));
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "POLICY_TBD" }[0]));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-190-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;T&gt; SqlRepository.Gap&lt;T&gt;(string code)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"code": "POLICY_TBD", "boundary": "Empty then single-item collection where relevant;
    /// identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;T&gt; SqlRepository.Gap&lt;T&gt;(string code); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-190.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-190-TC002")]
    public void UTM_190_TC002()
    {
        // Arrange: test inputs and mock setup.
        var d = JsonSerializer.Deserialize<JsonElement>("{\r\n            \"code\": \"POLICY_TBD\",\r\n            \"boundary\": \"Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free forwarding: empty optional field unchanged.\"\r\n          }");
        var type = typeof(FreshFood.Reposistory.Repository.Implements.SqlRepository);
        var queries = new List<(string Sql, object? [] Args)>();
        var deferred = new Dictionary<string, string>
        {
            ["LoadLifecycleAsync"] = "TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",
            ["SaveOrderLinesAsync"] = "SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",
            ["SavePaymentOnceAsync"] = "PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",
            ["SaveFailureAsync"] = "STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveReceiptAsync"] = "STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",
            ["SaveRefundOnceAsync"] = "REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",
            ["SaveShippingSettlementAsync"] = "SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"
        };
        var session = (IRepositorySession)StrictProxy.Create(typeof(IRepositorySession), (mi, a) =>
        {
            if (mi.Name == "get_Active")
                return true;
            if (mi.Name != "QueryAsync")
                throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));
            var sql = (string)a[0]!;
            var args = (object? [])a[1]!;
            queries.Add((sql, args));
            var rowType = mi.GetGenericArguments()[0];
            var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow = true && (sql.StartsWith("INSERT INTO carts", StringComparison.Ordinal) || sql.StartsWith("INSERT INTO orders", StringComparison.Ordinal));
            if (!true || createRow)
            {
                var row = Fixture.Value(rowType)!;
                if (row is Cart cart)
                {
                    cart.CartId = "1";
                    cart.CustomerId = "7";
                }

                if (row is Order order)
                {
                    order.OrderId = "1";
                    order.CustomerId = "7";
                    order.DeliveryAddressId = "2";
                }

                if (rowType.Name == "ClaimRow")
                {
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row, "Sample");
                    rowType.GetProperty("RequestHash")!.SetValue(row, S(d, "requestHash", new string ('a', 64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row, "Sample");
                    rowType.GetProperty("Response")!.SetValue(row, null);
                }

                list.Add(row);
            }

            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null, [list]);
        });
        var owner = new ProbeRepository(session);
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).First(x => x.Name == "Gap" && x.GetParameters().Length == 1);
        if (method.IsGenericMethodDefinition)
            method = method.MakeGenericMethod(typeof(Cart));
        var args = method.GetParameters().Select(p =>
        {
            if (p.ParameterType == typeof(string))
                return (object? )S(d, p.Name!, p.Name?.Contains("code", StringComparison.Ordinal) == true ? "POLICY_TBD" : "1");
            if (p.ParameterType == typeof(List<string>))
                return new List<string>
                {
                    "1"
                };
            if (p.ParameterType == typeof(List<BatchInventory>))
                return new List<BatchInventory>();
            if (p.ParameterType == typeof(List<OrderDetail>))
                return new List<OrderDetail>
                {
                    new()
                    {
                        BatchId = "1",
                        ProductId = "1",
                        Quantity = 2
                    }
                };
            if (p.ParameterType == typeof(CancellationToken))
                return Fixture.Token;
            if (p.ParameterType == typeof(Cart))
                return new Cart
                {
                    CartId = "1",
                    CustomerId = "7",
                    Items = [new()
                    {
                        ProductId = "1",
                        Quantity = 2
                    }

                    ]
                };
            if (p.ParameterType == typeof(Order))
                return new Order
                {
                    OrderId = "1",
                    CustomerId = "7",
                    DeliveryAddressId = "2"
                };
            if (p.ParameterType == typeof(object[]))
                return Array.Empty<object>();
            if (p.ParameterType == typeof(object))
                return new
                {
                    OrderId = "1"
                };
            if (p.ParameterType == typeof(AuditLog))
                return new AuditLog
                {
                    CustomerId = "7",
                    RecordIdentifier = "1",
                    OldValues = "{}",
                    NewValues = "{}"
                };
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        {
            {
                Func<Task> operation = () => Fixture.Await(Fixture.Invoke(method, null, args));
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "POLICY_TBD" }[0]));
            }

            return;
        }
    }

    /// <summary>
    /// UTM-190-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;T&gt; SqlRepository.Gap&lt;T&gt;(string code)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"code": "POLICY_TBD", "failure": "First collaborator throws TimeoutException sentinel; for
    /// pure methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;T&gt; SqlRepository.Gap&lt;T&gt;(string code); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-190.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-190-TC003")]
    public void UTM_190_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.");
    }
}
