// Generated stable case entry points; assertions live in the reviewed execution helpers.
namespace FreshFood.Backend.UnitTests;
[NUnit.Framework.TestFixture]
public sealed class ApiJsonTests
{
    /// <summary>
    /// UTM-002-TC001: Missing required member CartChangeDto
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: JsonSerializerOptions ApiJson.Create()
    /// </para>
    /// <para>
    /// Technique: Under-posting error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"DTO": "CartChangeDto", "JSON": "{}"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke JsonSerializerOptions ApiJson.Create(); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: JsonException for omitted Quantity, Rating or PaymentMethod; no defaulting to a
    /// valid operation
    /// </para>
    /// <para>
    /// Design exception expectation: JsonException
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-002.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-002-TC001")]
    public System.Threading.Tasks.Task UTM_002_TC001() => CaseRunner.Run("UTM-002-TC001");
    /// <summary>
    /// UTM-002-TC002: Missing required member OrderReviewDto
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: JsonSerializerOptions ApiJson.Create()
    /// </para>
    /// <para>
    /// Technique: Under-posting error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"DTO": "OrderReviewDto", "JSON": "{}"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke JsonSerializerOptions ApiJson.Create(); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: JsonException for omitted Quantity, Rating or PaymentMethod; no defaulting to a
    /// valid operation
    /// </para>
    /// <para>
    /// Design exception expectation: JsonException
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-002.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-002-TC002")]
    public System.Threading.Tasks.Task UTM_002_TC002() => CaseRunner.Run("UTM-002-TC002");
    /// <summary>
    /// UTM-002-TC003: Missing required member PlaceOrderDto
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: JsonSerializerOptions ApiJson.Create()
    /// </para>
    /// <para>
    /// Technique: Under-posting error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Reach through public owning method where feasible; reviewed internal/reflection harness for
    /// private/protected guards. Do not change production visibility silently. Prerequisite guards before the
    /// target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"DTO": "PlaceOrderDto", "JSON":
    /// "{\"AddressId\":\"2\",\"CheckoutReference\":\"r\",\"IdempotencyKey\":\"k\"}"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke JsonSerializerOptions ApiJson.Create(); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: JsonException for omitted Quantity, Rating or PaymentMethod; no defaulting to a
    /// valid operation
    /// </para>
    /// <para>
    /// Design exception expectation: JsonException
    /// </para>
    /// <para>
    /// Expected side effects:
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-002.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-002-TC003")]
    public System.Threading.Tasks.Task UTM_002_TC003() => CaseRunner.Run("UTM-002-TC003");
    /// <summary>
    /// UTM-002-TC004: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: JsonSerializerOptions ApiJson.Create()
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
    /// Act: Arrange fixtures and overrides; invoke JsonSerializerOptions ApiJson.Create(); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-002.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-002-TC004")]
    public System.Threading.Tasks.Task UTM_002_TC004() => CaseRunner.Run("UTM-002-TC004");
    /// <summary>
    /// UTM-002-TC005: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: JsonSerializerOptions ApiJson.Create()
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
    /// Act: Arrange fixtures and overrides; invoke JsonSerializerOptions ApiJson.Create(); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-002.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-002-TC005")]
    public System.Threading.Tasks.Task UTM_002_TC005() => CaseRunner.Run("UTM-002-TC005");
    /// <summary>
    /// UTM-002-TC006: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: JsonSerializerOptions ApiJson.Create()
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
    /// Act: Arrange fixtures and overrides; invoke JsonSerializerOptions ApiJson.Create(); assert result, exception
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
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-002.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("No injectable collaborator here; bind abnormal cases to the declared guard, or review N/A instead of inventing a fault injection seam.")]
    [NUnit.Framework.Property("DesignCase", "UTM-002-TC006")]
    public System.Threading.Tasks.Task UTM_002_TC006() => CaseRunner.Run("UTM-002-TC006");
}
