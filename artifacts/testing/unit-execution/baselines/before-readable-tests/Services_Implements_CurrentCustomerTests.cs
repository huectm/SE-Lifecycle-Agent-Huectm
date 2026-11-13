// Generated stable case entry points; assertions live in the reviewed execution helpers.
namespace FreshFood.Backend.UnitTests;
[NUnit.Framework.TestFixture]
public sealed class Services_Implements_CurrentCustomerTests
{
    /// <summary>
    /// UTM-056-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CurrentCustomer.CurrentCustomer(IHttpContextAccessor accessor, IDataProtectionProvider
    /// protection)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"accessor": "Typed Microsoft.AspNetCore.Http.IHttpContextAccessor fixture from
    /// fixtures.json", "protection": "Typed Microsoft.AspNetCore.DataProtection.IDataProtectionProvider fixture
    /// from fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CurrentCustomer.CurrentCustomer(IHttpContextAccessor accessor,
    /// IDataProtectionProvider protection); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-056.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-056-TC001")]
    public System.Threading.Tasks.Task UTM_056_TC001() => CaseRunner.Run("UTM-056-TC001");
    /// <summary>
    /// UTM-056-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CurrentCustomer.CurrentCustomer(IHttpContextAccessor accessor, IDataProtectionProvider
    /// protection)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"accessor": "Typed Microsoft.AspNetCore.Http.IHttpContextAccessor fixture from
    /// fixtures.json", "protection": "Typed Microsoft.AspNetCore.DataProtection.IDataProtectionProvider fixture
    /// from fixtures.json", "variant": "Omit optional arguments; otherwise use distinct valid instances and empty
    /// collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CurrentCustomer.CurrentCustomer(IHttpContextAccessor accessor,
    /// IDataProtectionProvider protection); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-056.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-056-TC002")]
    public System.Threading.Tasks.Task UTM_056_TC002() => CaseRunner.Run("UTM-056-TC002");
    /// <summary>
    /// UTM-056-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CurrentCustomer.CurrentCustomer(IHttpContextAccessor accessor, IDataProtectionProvider
    /// protection)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"accessor": "Typed Microsoft.AspNetCore.Http.IHttpContextAccessor fixture from
    /// fixtures.json", "protection": "Typed Microsoft.AspNetCore.DataProtection.IDataProtectionProvider fixture
    /// from fixtures.json", "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CurrentCustomer.CurrentCustomer(IHttpContextAccessor accessor,
    /// IDataProtectionProvider protection); assert result, exception and captured calls/effects.
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-056.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-056-TC003")]
    public System.Threading.Tasks.Task UTM_056_TC003() => CaseRunner.Run("UTM-056-TC003");
    /// <summary>
    /// UTM-057-TC001: Forged header
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Security error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Authenticated": false, "X-Customer-Id": "7"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject identity
    /// </para>
    /// <para>
    /// Design exception expectation: AUTHENTICATION_REQUIRED / 401
    /// </para>
    /// <para>
    /// Expected side effects: Header grants no authority
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC001")]
    public System.Threading.Tasks.Task UTM_057_TC001() => CaseRunner.Run("UTM-057-TC001");
    /// <summary>
    /// UTM-057-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
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
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC002")]
    public System.Threading.Tasks.Task UTM_057_TC002() => CaseRunner.Run("UTM-057-TC002");
    /// <summary>
    /// UTM-057-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
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
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC003")]
    public System.Threading.Tasks.Task UTM_057_TC003() => CaseRunner.Run("UTM-057-TC003");
    /// <summary>
    /// UTM-057-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
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
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC004")]
    public System.Threading.Tasks.Task UTM_057_TC004() => CaseRunner.Run("UTM-057-TC004");
    /// <summary>
    /// UTM-057-TC005: null-access L9 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "accessor.HttpContext"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: accessor.HttpContext?.User | Assert selected outcome
    /// Null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D01:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC005")]
    public System.Threading.Tasks.Task UTM_057_TC005() => CaseRunner.Run("UTM-057-TC005");
    /// <summary>
    /// UTM-057-TC006: null-access L9 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "accessor.HttpContext"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: accessor.HttpContext?.User | Assert selected outcome
    /// Non-null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:9. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D01:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC006")]
    public System.Threading.Tasks.Task UTM_057_TC006() => CaseRunner.Run("UTM-057-TC006");
    /// <summary>
    /// UTM-057-TC007: conditional L10 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"User.Identity.IsAuthenticated": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: null | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/CurrentCustomer.cs:10. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D02:False, UTM-057-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC007")]
    public System.Threading.Tasks.Task UTM_057_TC007() => CaseRunner.Run("UTM-057-TC007");
    /// <summary>
    /// UTM-057-TC008: conditional L10 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"User.Identity.IsAuthenticated": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: user.FindFirstValue("customer_id") | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/CurrentCustomer.cs:10. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D02:True, UTM-057-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC008")]
    public System.Threading.Tasks.Task UTM_057_TC008() => CaseRunner.Run("UTM-057-TC008");
    /// <summary>
    /// UTM-057-TC009: null-access L10 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "user"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: user?.Identity?.IsAuthenticated | Assert selected
    /// outcome Null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:10. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D03:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC009")]
    public System.Threading.Tasks.Task UTM_057_TC009() => CaseRunner.Run("UTM-057-TC009");
    /// <summary>
    /// UTM-057-TC010: null-access L10 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "user"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: user?.Identity?.IsAuthenticated | Assert selected
    /// outcome Non-null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:10. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D03:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC010")]
    public System.Threading.Tasks.Task UTM_057_TC010() => CaseRunner.Run("UTM-057-TC010");
    /// <summary>
    /// UTM-057-TC011: null-access L10 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": ".Identity"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: .Identity?.IsAuthenticated | Assert selected outcome
    /// Null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:10. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D04:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC011")]
    public System.Threading.Tasks.Task UTM_057_TC011() => CaseRunner.Run("UTM-057-TC011");
    /// <summary>
    /// UTM-057-TC012: null-access L10 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": ".Identity"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: .Identity?.IsAuthenticated | Assert selected outcome
    /// Non-null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:10. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D04:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC012")]
    public System.Threading.Tasks.Task UTM_057_TC012() => CaseRunner.Run("UTM-057-TC012");
    /// <summary>
    /// UTM-057-TC013: if L11 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"id": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:11. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D05:False, UTM-057-D05:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC013")]
    public System.Threading.Tasks.Task UTM_057_TC013() => CaseRunner.Run("UTM-057-TC013");
    /// <summary>
    /// UTM-057-TC014: if L11 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: string CurrentCustomer.RequireCustomerId()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"id": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke string CurrentCustomer.RequireCustomerId(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("AUTHENTICATION_REQUIRED", 401); | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:11. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("AUTHENTICATION_REQUIRED", 401)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-057-D05:True, UTM-057-D05:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-057.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-057-TC014")]
    public System.Threading.Tasks.Task UTM_057_TC014() => CaseRunner.Run("UTM-057-TC014");
    /// <summary>
    /// UTM-058-TC001: Tampered cookie
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Security error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Cookie": "invalid-token", "Scheme": "http"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Fresh session; Secure, HttpOnly, SameSite.Strict
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Never use cookie text as identity
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC001")]
    public System.Threading.Tasks.Task UTM_058_TC001() => CaseRunner.Run("UTM-058-TC001");
    /// <summary>
    /// UTM-058-TC002: Valid guest cookie
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Cookie": "protect(existing-session)"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Same session; no replacement cookie
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC002")]
    public System.Threading.Tasks.Task UTM_058_TC002() => CaseRunner.Run("UTM-058-TC002");
    /// <summary>
    /// UTM-058-TC003: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
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
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC003")]
    public System.Threading.Tasks.Task UTM_058_TC003() => CaseRunner.Run("UTM-058-TC003");
    /// <summary>
    /// UTM-058-TC004: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
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
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC004")]
    public System.Threading.Tasks.Task UTM_058_TC004() => CaseRunner.Run("UTM-058-TC004");
    /// <summary>
    /// UTM-058-TC005: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
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
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC005")]
    public System.Threading.Tasks.Task UTM_058_TC005() => CaseRunner.Run("UTM-058-TC005");
    /// <summary>
    /// UTM-058-TC006: coalesce L16 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "accessor.HttpContext"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: accessor.HttpContext ?? throw new
    /// InvalidOperationException("No request.") | Assert selected outcome Null at
    /// src/FreshFood-API/Services/Implements/CurrentCustomer.cs:16. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D01:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC006")]
    public System.Threading.Tasks.Task UTM_058_TC006() => CaseRunner.Run("UTM-058-TC006");
    /// <summary>
    /// UTM-058-TC007: coalesce L16 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "accessor.HttpContext"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: accessor.HttpContext ?? throw new
    /// InvalidOperationException("No request.") | Assert selected outcome Non-null at
    /// src/FreshFood-API/Services/Implements/CurrentCustomer.cs:16. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D01:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC007")]
    public System.Threading.Tasks.Task UTM_058_TC007() => CaseRunner.Run("UTM-058-TC007");
    /// <summary>
    /// UTM-058-TC008: if L17 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"User.Identity.IsAuthenticated": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D02:False, UTM-058-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC008")]
    public System.Threading.Tasks.Task UTM_058_TC008() => CaseRunner.Run("UTM-058-TC008");
    /// <summary>
    /// UTM-058-TC009: if L17 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"User.Identity.IsAuthenticated": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: return new() { CustomerId = RequireCustomerId() }; | Assert selected outcome
    /// True at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D02:True, UTM-058-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC009")]
    public System.Threading.Tasks.Task UTM_058_TC009() => CaseRunner.Run("UTM-058-TC009");
    /// <summary>
    /// UTM-058-TC010: null-access L17 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "context.User.Identity"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: context.User.Identity?.IsAuthenticated | Assert
    /// selected outcome Null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:17. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D03:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC010")]
    public System.Threading.Tasks.Task UTM_058_TC010() => CaseRunner.Run("UTM-058-TC010");
    /// <summary>
    /// UTM-058-TC011: null-access L17 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "context.User.Identity"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: context.User.Identity?.IsAuthenticated | Assert
    /// selected outcome Non-null at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:17. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D03:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC011")]
    public System.Threading.Tasks.Task UTM_058_TC011() => CaseRunner.Run("UTM-058-TC011");
    /// <summary>
    /// UTM-058-TC012: if L20 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"review constraint":
    /// "context.Request.Cookies.TryGetValue(\"FreshFood.GuestCart\", out var cookie) = False; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:20. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D04:False, UTM-058-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC012")]
    public System.Threading.Tasks.Task UTM_058_TC012() => CaseRunner.Run("UTM-058-TC012");
    /// <summary>
    /// UTM-058-TC013: if L20 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"review constraint":
    /// "context.Request.Cookies.TryGetValue(\"FreshFood.GuestCart\", out var cookie) = True; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: try { session = protector.Unprotect(cookie); } catch
    /// (System.Security.Cryptography.CryptographicException) { /* Invalid cookies never become cart identities. */
    /// } | Assert selected outcome True at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:20. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D04:True, UTM-058-D04:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC013")]
    public System.Threading.Tasks.Task UTM_058_TC013() => CaseRunner.Run("UTM-058-TC013");
    /// <summary>
    /// UTM-058-TC014: catch L21 -&gt; System.Security.Cryptography.CryptographicException
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"scenario": "System.Security.Cryptography.CryptographicException",
    /// "expression": "catch (System.Security.Cryptography.CryptographicException) { /* Invalid cookies never become
    /// cart identities. */ }"}, "fault": "Throw System.Security.Cryptography.CryptographicException from the
    /// dependency protected by this catch; exercise filter true and false when present."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: { /* Invalid cookies never become cart identities. */ } | Assert selected outcome
    /// System.Security.Cryptography.CryptographicException at
    /// src/FreshFood-API/Services/Implements/CurrentCustomer.cs:21. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D05:System.Security.Cryptography.CryptographicException
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC014")]
    public System.Threading.Tasks.Task UTM_058_TC014() => CaseRunner.Run("UTM-058-TC014");
    /// <summary>
    /// UTM-058-TC015: if L22 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"session": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:22. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D06:False, UTM-058-D06:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC015")]
    public System.Threading.Tasks.Task UTM_058_TC015() => CaseRunner.Run("UTM-058-TC015");
    /// <summary>
    /// UTM-058-TC016: if L22 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: CartIdentityDto CurrentCustomer.GetCartIdentity()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"session": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke CartIdentityDto CurrentCustomer.GetCartIdentity(); assert
    /// result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: {             session = Guid.NewGuid().ToString("N");
    /// context.Response.Cookies.Append("FreshFood.GuestCart", protector.Protect(session), new() { HttpOnly = true,
    /// Secure = true, SameSite = SameSiteMode.Strict, IsEssential = true });         } | Assert selected outcome
    /// True at src/FreshFood-API/Services/Implements/CurrentCustomer.cs:22. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No request.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-058-D06:True, UTM-058-D06:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-058.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-058-TC016")]
    public System.Threading.Tasks.Task UTM_058_TC016() => CaseRunner.Run("UTM-058-TC016");
}
