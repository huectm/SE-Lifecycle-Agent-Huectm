// Generated stable case entry points; assertions live in the reviewed execution helpers.
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
    public System.Threading.Tasks.Task UTM_111_TC001() => CaseRunner.Run("UTM-111-TC001");
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
    public System.Threading.Tasks.Task UTM_111_TC002() => CaseRunner.Run("UTM-111-TC002");
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
    public System.Threading.Tasks.Task UTM_111_TC003() => CaseRunner.Run("UTM-111-TC003");
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
    public System.Threading.Tasks.Task UTM_111_TC004() => CaseRunner.Run("UTM-111-TC004");
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
    public System.Threading.Tasks.Task UTM_111_TC005() => CaseRunner.Run("UTM-111-TC005");
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
    public System.Threading.Tasks.Task UTM_111_TC006() => CaseRunner.Run("UTM-111-TC006");
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
    public System.Threading.Tasks.Task UTM_111_TC007() => CaseRunner.Run("UTM-111-TC007");
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
    public System.Threading.Tasks.Task UTM_111_TC008() => CaseRunner.Run("UTM-111-TC008");
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
    public System.Threading.Tasks.Task UTM_111_TC009() => CaseRunner.Run("UTM-111-TC009");
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
    public System.Threading.Tasks.Task UTM_111_TC010() => CaseRunner.Run("UTM-111-TC010");
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
    [NUnit.Framework.Test][NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-111-TC011")]
    public System.Threading.Tasks.Task UTM_111_TC011() => CaseRunner.Run("UTM-111-TC011");
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
    public System.Threading.Tasks.Task UTM_111_TC012() => CaseRunner.Run("UTM-111-TC012");
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
    public System.Threading.Tasks.Task UTM_111_TC013() => CaseRunner.Run("UTM-111-TC013");
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
    public System.Threading.Tasks.Task UTM_111_TC014() => CaseRunner.Run("UTM-111-TC014");
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
    public System.Threading.Tasks.Task UTM_111_TC015() => CaseRunner.Run("UTM-111-TC015");
}
