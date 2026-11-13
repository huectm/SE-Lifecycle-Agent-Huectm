// Generated stable case entry points; assertions live in the reviewed execution helpers.
namespace FreshFood.Backend.UnitTests;
[NUnit.Framework.TestFixture]
public sealed class Repository_Implements_PostgreSqlSessionTests
{
    /// <summary>
    /// UTM-163-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: PostgreSqlSession.PostgreSqlSession(NpgsqlDataSource dataSource)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"dataSource": "Strict fake Npgsql.NpgsqlDataSource; capture calls, no external IO"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke PostgreSqlSession.PostgreSqlSession(NpgsqlDataSource
    /// dataSource); assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-163.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-163-TC001")]
    public System.Threading.Tasks.Task UTM_163_TC001() => CaseRunner.Run("UTM-163-TC001");
    /// <summary>
    /// UTM-163-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: PostgreSqlSession.PostgreSqlSession(NpgsqlDataSource dataSource)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"dataSource": "Strict fake Npgsql.NpgsqlDataSource; capture calls, no external IO",
    /// "variant": "Omit optional arguments; otherwise use distinct valid instances and empty collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke PostgreSqlSession.PostgreSqlSession(NpgsqlDataSource
    /// dataSource); assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-163.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-163-TC002")]
    public System.Threading.Tasks.Task UTM_163_TC002() => CaseRunner.Run("UTM-163-TC002");
    /// <summary>
    /// UTM-163-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: PostgreSqlSession.PostgreSqlSession(NpgsqlDataSource dataSource)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"dataSource": "Strict fake Npgsql.NpgsqlDataSource; capture calls, no external IO",
    /// "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke PostgreSqlSession.PostgreSqlSession(NpgsqlDataSource
    /// dataSource); assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-163.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-163-TC003")]
    public System.Threading.Tasks.Task UTM_163_TC003() => CaseRunner.Run("UTM-163-TC003");
    /// <summary>
    /// UTM-164-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: bool PostgreSqlSession.Active.get
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke bool PostgreSqlSession.Active.get; assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the value determined by arranged state without mutation.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-164.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-164-TC001")]
    public System.Threading.Tasks.Task UTM_164_TC001() => CaseRunner.Run("UTM-164-TC001");
    /// <summary>
    /// UTM-164-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: bool PostgreSqlSession.Active.get
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke bool PostgreSqlSession.Active.get; assert result, exception and
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-164.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-164-TC002")]
    public System.Threading.Tasks.Task UTM_164_TC002() => CaseRunner.Run("UTM-164-TC002");
    /// <summary>
    /// UTM-164-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: bool PostgreSqlSession.Active.get
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke bool PostgreSqlSession.Active.get; assert result, exception and
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-164.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-164-TC003")]
    public System.Threading.Tasks.Task UTM_164_TC003() => CaseRunner.Run("UTM-164-TC003");
    /// <summary>
    /// UTM-164-TC004: boolean-return L10 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: bool PostgreSqlSession.Active.get
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"transaction": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke bool PostgreSqlSession.Active.get; assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: transaction is not null | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:10. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-164-D01:False, UTM-164-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-164.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-164-TC004")]
    public System.Threading.Tasks.Task UTM_164_TC004() => CaseRunner.Run("UTM-164-TC004");
    /// <summary>
    /// UTM-164-TC005: boolean-return L10 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: bool PostgreSqlSession.Active.get
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"transaction": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke bool PostgreSqlSession.Active.get; assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: transaction is not null | Assert selected outcome
    /// True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:10. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-164-D01:True, UTM-164-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-164.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-164-TC005")]
    public System.Threading.Tasks.Task UTM_164_TC005() => CaseRunner.Run("UTM-164-TC005");
    /// <summary>
    /// UTM-165-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.BeginAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.BeginAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-165.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-165-TC001")]
    public System.Threading.Tasks.Task UTM_165_TC001() => CaseRunner.Run("UTM-165-TC001");
    /// <summary>
    /// UTM-165-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.BeginAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "boundary":
    /// "Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free
    /// forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.BeginAsync(CancellationToken signal);
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-165.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-165-TC002")]
    public System.Threading.Tasks.Task UTM_165_TC002() => CaseRunner.Run("UTM-165-TC002");
    /// <summary>
    /// UTM-165-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.BeginAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.BeginAsync(CancellationToken signal);
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-165.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-165-TC003")]
    public System.Threading.Tasks.Task UTM_165_TC003() => CaseRunner.Run("UTM-165-TC003");
    /// <summary>
    /// UTM-165-TC004: if L13 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.BeginAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"connection": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.BeginAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:13. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("Nested transactions are not supported."); rethrow
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-165-D01:False, UTM-165-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-165.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-165-TC004")]
    public System.Threading.Tasks.Task UTM_165_TC004() => CaseRunner.Run("UTM-165-TC004");
    /// <summary>
    /// UTM-165-TC005: if L13 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.BeginAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"connection": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.BeginAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new InvalidOperationException("Nested transactions are not supported.");
    /// | Assert selected outcome True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:13.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("Nested transactions are not supported."); rethrow
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-165-D01:True, UTM-165-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-165.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-165-TC005")]
    public System.Threading.Tasks.Task UTM_165_TC005() => CaseRunner.Run("UTM-165-TC005");
    /// <summary>
    /// UTM-165-TC006: catch L16 -&gt; Any exception
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.BeginAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"scenario": "Any exception", "expression": "catch { await connection.DisposeAsync(); connection = null;
    /// throw; }"}, "fault": "Throw Any exception from the dependency protected by this catch; exercise filter true
    /// and false when present."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.BeginAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: { await connection.DisposeAsync(); connection = null; throw; } | Assert selected
    /// outcome Any exception at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:16. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("Nested transactions are not supported."); rethrow
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-165-D02:Any exception
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-165.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-165-TC006")]
    public System.Threading.Tasks.Task UTM_165_TC006() => CaseRunner.Run("UTM-165-TC006");
    /// <summary>
    /// UTM-166-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.CommitAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.CommitAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-166.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-166-TC001")]
    public System.Threading.Tasks.Task UTM_166_TC001() => CaseRunner.Run("UTM-166-TC001");
    /// <summary>
    /// UTM-166-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.CommitAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "boundary":
    /// "Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free
    /// forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.CommitAsync(CancellationToken signal);
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-166.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-166-TC002")]
    public System.Threading.Tasks.Task UTM_166_TC002() => CaseRunner.Run("UTM-166-TC002");
    /// <summary>
    /// UTM-166-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.CommitAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.CommitAsync(CancellationToken signal);
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-166.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-166-TC003")]
    public System.Threading.Tasks.Task UTM_166_TC003() => CaseRunner.Run("UTM-166-TC003");
    /// <summary>
    /// UTM-166-TC004: if L20 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.CommitAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"transaction": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.CommitAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:20. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No transaction.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-166-D01:False, UTM-166-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-166.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-166-TC004")]
    public System.Threading.Tasks.Task UTM_166_TC004() => CaseRunner.Run("UTM-166-TC004");
    /// <summary>
    /// UTM-166-TC005: if L20 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.CommitAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"transaction": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.CommitAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new InvalidOperationException("No transaction."); | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:20. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// InvalidOperationException("No transaction.")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-166-D01:True, UTM-166-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-166.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-166-TC005")]
    public System.Threading.Tasks.Task UTM_166_TC005() => CaseRunner.Run("UTM-166-TC005");
    /// <summary>
    /// UTM-167-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.RollbackAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.RollbackAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-167.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-167-TC001")]
    public System.Threading.Tasks.Task UTM_167_TC001() => CaseRunner.Run("UTM-167-TC001");
    /// <summary>
    /// UTM-167-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.RollbackAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "boundary":
    /// "Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free
    /// forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.RollbackAsync(CancellationToken signal);
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-167.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-167-TC002")]
    public System.Threading.Tasks.Task UTM_167_TC002() => CaseRunner.Run("UTM-167-TC002");
    /// <summary>
    /// UTM-167-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.RollbackAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.RollbackAsync(CancellationToken signal);
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-167.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-167-TC003")]
    public System.Threading.Tasks.Task UTM_167_TC003() => CaseRunner.Run("UTM-167-TC003");
    /// <summary>
    /// UTM-167-TC004: if L26 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.RollbackAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"transaction": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.RollbackAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:26. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-167-D01:False, UTM-167-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-167.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-167-TC004")]
    public System.Threading.Tasks.Task UTM_167_TC004() => CaseRunner.Run("UTM-167-TC004");
    /// <summary>
    /// UTM-167-TC005: if L26 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task PostgreSqlSession.RollbackAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"signal": "CancellationToken.None; use distinct token in forwarding variants"},
    /// "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER", "SESSION"], "overrides":
    /// {"transaction": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task PostgreSqlSession.RollbackAsync(CancellationToken signal);
    /// assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: await transaction.RollbackAsync(signal); | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:26. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-167-D01:True, UTM-167-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-167.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-167-TC005")]
    public System.Threading.Tasks.Task UTM_167_TC005() => CaseRunner.Run("UTM-167-TC005");
    /// <summary>
    /// UTM-168-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC001")]
    public System.Threading.Tasks.Task UTM_168_TC001() => CaseRunner.Run("UTM-168-TC001");
    /// <summary>
    /// UTM-168-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC002")]
    public System.Threading.Tasks.Task UTM_168_TC002() => CaseRunner.Run("UTM-168-TC002");
    /// <summary>
    /// UTM-168-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"failure": "First collaborator throws TimeoutException sentinel; for pure methods use a
    /// declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC003")]
    public System.Threading.Tasks.Task UTM_168_TC003() => CaseRunner.Run("UTM-168-TC003");
    /// <summary>
    /// UTM-168-TC004: if L31 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"transaction": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:31. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-168-D01:False, UTM-168-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC004")]
    public System.Threading.Tasks.Task UTM_168_TC004() => CaseRunner.Run("UTM-168-TC004");
    /// <summary>
    /// UTM-168-TC005: if L31 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"transaction": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: await transaction.DisposeAsync(); | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:31. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-168-D01:True, UTM-168-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC005")]
    public System.Threading.Tasks.Task UTM_168_TC005() => CaseRunner.Run("UTM-168-TC005");
    /// <summary>
    /// UTM-168-TC006: if L32 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"connection": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:32. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-168-D02:False, UTM-168-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC006")]
    public System.Threading.Tasks.Task UTM_168_TC006() => CaseRunner.Run("UTM-168-TC006");
    /// <summary>
    /// UTM-168-TC007: if L32 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ValueTask PostgreSqlSession.DisposeAsync()
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT",
    /// "ORDER", "SESSION"], "overrides": {"connection": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ValueTask PostgreSqlSession.DisposeAsync(); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: await connection.DisposeAsync(); | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:32. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-168-D02:True, UTM-168-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-168.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-168-TC007")]
    public System.Threading.Tasks.Task UTM_168_TC007() => CaseRunner.Run("UTM-168-TC007");
    /// <summary>
    /// UTM-169-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters": "Typed object?[]
    /// fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC001")]
    public System.Threading.Tasks.Task UTM_169_TC001() => CaseRunner.Run("UTM-169-TC001");
    /// <summary>
    /// UTM-169-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters": "Typed object?[]
    /// fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed state.
    /// Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC002")]
    public System.Threading.Tasks.Task UTM_169_TC002() => CaseRunner.Run("UTM-169-TC002");
    /// <summary>
    /// UTM-169-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters": "Typed object?[]
    /// fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in forwarding variants",
    /// "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
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
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC003")]
    public System.Threading.Tasks.Task UTM_169_TC003() => CaseRunner.Run("UTM-169-TC003");
    /// <summary>
    /// UTM-169-TC004: coalesce L38 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Null", "expression": "connection"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: connection ?? await
    /// dataSource.OpenConnectionAsync(signal) | Assert selected outcome Null at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:38. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D01:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC004")]
    public System.Threading.Tasks.Task UTM_169_TC004() => CaseRunner.Run("UTM-169-TC004");
    /// <summary>
    /// UTM-169-TC005: coalesce L38 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Non-null", "expression": "connection"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: connection ?? await
    /// dataSource.OpenConnectionAsync(signal) | Assert selected outcome Non-null at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:38. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D01:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC005")]
    public System.Threading.Tasks.Task UTM_169_TC005() => CaseRunner.Run("UTM-169-TC005");
    /// <summary>
    /// UTM-169-TC006: foreach L42 -&gt; Empty
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Empty", "expression": "parameters"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {                 var p = new NpgsqlParameter {
    /// Value = value ?? DBNull.Value };                 if (value is null) p.NpgsqlDbType = NpgsqlDbType.Unknown;
    /// command.Parameters.Add(p);             } | Assert selected outcome Empty at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D02:Empty
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC006")]
    public System.Threading.Tasks.Task UTM_169_TC006() => CaseRunner.Run("UTM-169-TC006");
    /// <summary>
    /// UTM-169-TC007: foreach L42 -&gt; One item
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "One item", "expression": "parameters"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {                 var p = new NpgsqlParameter {
    /// Value = value ?? DBNull.Value };                 if (value is null) p.NpgsqlDbType = NpgsqlDbType.Unknown;
    /// command.Parameters.Add(p);             } | Assert selected outcome One item at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D02:One item
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC007")]
    public System.Threading.Tasks.Task UTM_169_TC007() => CaseRunner.Run("UTM-169-TC007");
    /// <summary>
    /// UTM-169-TC008: foreach L42 -&gt; Multiple items
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Multiple items", "expression": "parameters"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Empty: body not called | Non-empty: {                 var p = new NpgsqlParameter {
    /// Value = value ?? DBNull.Value };                 if (value is null) p.NpgsqlDbType = NpgsqlDbType.Unknown;
    /// command.Parameters.Add(p);             } | Assert selected outcome Multiple items at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D02:Multiple items
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC008")]
    public System.Threading.Tasks.Task UTM_169_TC008() => CaseRunner.Run("UTM-169-TC008");
    /// <summary>
    /// UTM-169-TC009: coalesce L44 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Null", "expression": "value"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: value ?? DBNull.Value | Assert selected outcome Null
    /// at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:44. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D03:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC009")]
    public System.Threading.Tasks.Task UTM_169_TC009() => CaseRunner.Run("UTM-169-TC009");
    /// <summary>
    /// UTM-169-TC010: coalesce L44 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Non-null", "expression": "value"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: value ?? DBNull.Value | Assert selected outcome
    /// Non-null at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:44. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D03:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC010")]
    public System.Threading.Tasks.Task UTM_169_TC010() => CaseRunner.Run("UTM-169-TC010");
    /// <summary>
    /// UTM-169-TC011: if L45 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"value": "typed fixture"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:45. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D04:False, UTM-169-D04:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC011")]
    public System.Threading.Tasks.Task UTM_169_TC011() => CaseRunner.Run("UTM-169-TC011");
    /// <summary>
    /// UTM-169-TC012: if L45 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"value": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: p.NpgsqlDbType = NpgsqlDbType.Unknown; | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:45. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D04:True, UTM-169-D04:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC012")]
    public System.Threading.Tasks.Task UTM_169_TC012() => CaseRunner.Run("UTM-169-TC012");
    /// <summary>
    /// UTM-169-TC013: while L52 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"review constraint": "await reader.ReadAsync(signal) = False; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: while (await reader.ReadAsync(signal))             {
    /// var item = new T();                 for (var i = 0; i &lt; reader.FieldCount; i++)                 {
    /// if (reader.IsDBNull(i) || !props.TryGetValue(reader.GetName(i).Replace("_", ""), out var prop) ||
    /// !prop.CanWrite) continue;                     var value = reader.GetValue(i);                     var t =
    /// Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;                     object converted = t
    /// == typeof(string) ? Convert.ToString(value, CultureInfo.InvariantCulture)!                         : t ==
    /// typeof(VndAmount) ? new VndAmount(Convert.ToDecimal(value, CultureInfo.InvariantCulture))
    /// : t == typeof(DateTimeOffset) &amp;&amp; value is DateTime dt ? new DateTimeOffset(DateTime.SpecifyKind(dt,
    /// DateTimeKind.Utc))                         : t == typeof(DateOnly) &amp;&amp; value is DateOnly date ? date
    /// : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)                         :
    /// Convert.ChangeType(value, t, CultureInfo.InvariantCulture);                     prop.SetValue(item,
    /// converted);                 }                 result.Add(item);             } | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:52. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D05:False, UTM-169-D05:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC013")]
    public System.Threading.Tasks.Task UTM_169_TC013() => CaseRunner.Run("UTM-169-TC013");
    /// <summary>
    /// UTM-169-TC014: while L52 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"review constraint": "await reader.ReadAsync(signal) = True; arrange matching
    /// entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: while (await reader.ReadAsync(signal))             {
    /// var item = new T();                 for (var i = 0; i &lt; reader.FieldCount; i++)                 {
    /// if (reader.IsDBNull(i) || !props.TryGetValue(reader.GetName(i).Replace("_", ""), out var prop) ||
    /// !prop.CanWrite) continue;                     var value = reader.GetValue(i);                     var t =
    /// Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;                     object converted = t
    /// == typeof(string) ? Convert.ToString(value, CultureInfo.InvariantCulture)!                         : t ==
    /// typeof(VndAmount) ? new VndAmount(Convert.ToDecimal(value, CultureInfo.InvariantCulture))
    /// : t == typeof(DateTimeOffset) &amp;&amp; value is DateTime dt ? new DateTimeOffset(DateTime.SpecifyKind(dt,
    /// DateTimeKind.Utc))                         : t == typeof(DateOnly) &amp;&amp; value is DateOnly date ? date
    /// : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)                         :
    /// Convert.ChangeType(value, t, CultureInfo.InvariantCulture);                     prop.SetValue(item,
    /// converted);                 }                 result.Add(item);             } | Assert selected outcome True
    /// at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:52. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D05:True, UTM-169-D05:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC014")]
    public System.Threading.Tasks.Task UTM_169_TC014() => CaseRunner.Run("UTM-169-TC014");
    /// <summary>
    /// UTM-169-TC015: for L55 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"review constraint": "i &lt; reader.FieldCount = False; arrange matching entity/mock
    /// state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: for (var i = 0; i &lt; reader.FieldCount; i++)
    /// {                     if (reader.IsDBNull(i) || !props.TryGetValue(reader.GetName(i).Replace("_", ""), out
    /// var prop) || !prop.CanWrite) continue;                     var value = reader.GetValue(i);
    /// var t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;                     object
    /// converted = t == typeof(string) ? Convert.ToString(value, CultureInfo.InvariantCulture)!
    /// : t == typeof(VndAmount) ? new VndAmount(Convert.ToDecimal(value, CultureInfo.InvariantCulture))
    /// : t == typeof(DateTimeOffset) &amp;&amp; value is DateTime dt ? new DateTimeOffset(DateTime.SpecifyKind(dt,
    /// DateTimeKind.Utc))                         : t == typeof(DateOnly) &amp;&amp; value is DateOnly date ? date
    /// : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)                         :
    /// Convert.ChangeType(value, t, CultureInfo.InvariantCulture);                     prop.SetValue(item,
    /// converted);                 } | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:55. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D06:False, UTM-169-D06:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC015")]
    public System.Threading.Tasks.Task UTM_169_TC015() => CaseRunner.Run("UTM-169-TC015");
    /// <summary>
    /// UTM-169-TC016: for L55 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"review constraint": "i &lt; reader.FieldCount = True; arrange matching entity/mock
    /// state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: for (var i = 0; i &lt; reader.FieldCount; i++)
    /// {                     if (reader.IsDBNull(i) || !props.TryGetValue(reader.GetName(i).Replace("_", ""), out
    /// var prop) || !prop.CanWrite) continue;                     var value = reader.GetValue(i);
    /// var t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;                     object
    /// converted = t == typeof(string) ? Convert.ToString(value, CultureInfo.InvariantCulture)!
    /// : t == typeof(VndAmount) ? new VndAmount(Convert.ToDecimal(value, CultureInfo.InvariantCulture))
    /// : t == typeof(DateTimeOffset) &amp;&amp; value is DateTime dt ? new DateTimeOffset(DateTime.SpecifyKind(dt,
    /// DateTimeKind.Utc))                         : t == typeof(DateOnly) &amp;&amp; value is DateOnly date ? date
    /// : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)                         :
    /// Convert.ChangeType(value, t, CultureInfo.InvariantCulture);                     prop.SetValue(item,
    /// converted);                 } | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:55. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D06:True, UTM-169-D06:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC016")]
    public System.Threading.Tasks.Task UTM_169_TC016() => CaseRunner.Run("UTM-169-TC016");
    /// <summary>
    /// UTM-169-TC017: if L57 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"reader row column": "typed non-null fixture value", "reader column": "ProductId",
    /// "resultType": "Fixture with ProductId writable property", "result property": "public writable property",
    /// "column": "matching property name"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:57. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D07:False, UTM-169-D07:C1:False, UTM-169-D07:C2:False,
    /// UTM-169-D07:C3:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC017")]
    public System.Threading.Tasks.Task UTM_169_TC017() => CaseRunner.Run("UTM-169-TC017");
    /// <summary>
    /// UTM-169-TC018: if L57 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"reader row column": "typed non-null fixture value", "reader column": "ProductId",
    /// "resultType": "Fixture with ProductId writable property", "result property": "read-only getter", "column":
    /// "matching property name"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue; | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:57. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D07:True, UTM-169-D07:C1:False, UTM-169-D07:C2:False, UTM-169-D07:C3:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC018")]
    public System.Threading.Tasks.Task UTM_169_TC018() => CaseRunner.Run("UTM-169-TC018");
    /// <summary>
    /// UTM-169-TC019: if L57 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"reader row column": "typed non-null fixture value", "reader column":
    /// "unmapped_column", "resultType": "Fixture with ProductId writable property"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue; | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:57. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D07:True, UTM-169-D07:C1:False, UTM-169-D07:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC019")]
    public System.Threading.Tasks.Task UTM_169_TC019() => CaseRunner.Run("UTM-169-TC019");
    /// <summary>
    /// UTM-169-TC020: if L57 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"reader row column": null}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue; | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:57. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D07:True, UTM-169-D07:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC020")]
    public System.Threading.Tasks.Task UTM_169_TC020() => CaseRunner.Run("UTM-169-TC020");
    /// <summary>
    /// UTM-169-TC021: coalesce L59 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Null", "expression":
    /// "Nullable.GetUnderlyingType(prop.PropertyType)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: Nullable.GetUnderlyingType(prop.PropertyType) ??
    /// prop.PropertyType | Assert selected outcome Null at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:59. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D08:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC021")]
    public System.Threading.Tasks.Task UTM_169_TC021() => CaseRunner.Run("UTM-169-TC021");
    /// <summary>
    /// UTM-169-TC022: coalesce L59 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Non-null", "expression":
    /// "Nullable.GetUnderlyingType(prop.PropertyType)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: Nullable.GetUnderlyingType(prop.PropertyType) ??
    /// prop.PropertyType | Assert selected outcome Non-null at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:59. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D08:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC022")]
    public System.Threading.Tasks.Task UTM_169_TC022() => CaseRunner.Run("UTM-169-TC022");
    /// <summary>
    /// UTM-169-TC023: conditional L60 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "int", "reader value": "value convertible to arranged
    /// property type"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: t == typeof(VndAmount) ? new VndAmount(Convert.ToDecimal(value,
    /// CultureInfo.InvariantCulture))                         : t == typeof(DateTimeOffset) &amp;&amp; value is DateTime dt
    /// ? new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc))                         : t ==
    /// typeof(DateOnly) &amp;&amp; value is DateOnly date ? date                         : t.IsEnum ? Enum.Parse(t,
    /// value.ToString()!.Replace("_", ""), true)                         : Convert.ChangeType(value, t,
    /// CultureInfo.InvariantCulture) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:60. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D09:False, UTM-169-D09:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC023")]
    public System.Threading.Tasks.Task UTM_169_TC023() => CaseRunner.Run("UTM-169-TC023");
    /// <summary>
    /// UTM-169-TC024: conditional L60 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "string", "reader value": "value convertible to arranged
    /// property type"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: Convert.ToString(value, CultureInfo.InvariantCulture)! | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:60. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D09:True, UTM-169-D09:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC024")]
    public System.Threading.Tasks.Task UTM_169_TC024() => CaseRunner.Run("UTM-169-TC024");
    /// <summary>
    /// UTM-169-TC025: conditional L61 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "int", "reader value": "value convertible to arranged
    /// property type"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: t == typeof(DateTimeOffset) &amp;&amp; value is DateTime dt ? new
    /// DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc))                         : t == typeof(DateOnly)
    /// &amp;&amp; value is DateOnly date ? date                         : t.IsEnum ? Enum.Parse(t,
    /// value.ToString()!.Replace("_", ""), true)                         : Convert.ChangeType(value, t,
    /// CultureInfo.InvariantCulture) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:61. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D10:False, UTM-169-D10:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC025")]
    public System.Threading.Tasks.Task UTM_169_TC025() => CaseRunner.Run("UTM-169-TC025");
    /// <summary>
    /// UTM-169-TC026: conditional L61 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "VndAmount", "reader value": "value convertible to
    /// arranged property type"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: new VndAmount(Convert.ToDecimal(value, CultureInfo.InvariantCulture)) | Assert
    /// selected outcome True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:61. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D10:True, UTM-169-D10:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC026")]
    public System.Threading.Tasks.Task UTM_169_TC026() => CaseRunner.Run("UTM-169-TC026");
    /// <summary>
    /// UTM-169-TC027: conditional L62 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "int", "reader value": "value convertible to arranged
    /// property type"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: t == typeof(DateOnly) &amp;&amp; value is DateOnly date ? date
    /// : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)                         :
    /// Convert.ChangeType(value, t, CultureInfo.InvariantCulture) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:62. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D11:False, UTM-169-D11:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC027")]
    public System.Threading.Tasks.Task UTM_169_TC027() => CaseRunner.Run("UTM-169-TC027");
    /// <summary>
    /// UTM-169-TC028: conditional L62 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "DateTimeOffset", "reader value": "value convertible to
    /// arranged property type", "reader value type": "DateTimeOffset"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: t == typeof(DateOnly) &amp;&amp; value is DateOnly date ? date
    /// : t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)                         :
    /// Convert.ChangeType(value, t, CultureInfo.InvariantCulture) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:62. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D11:False, UTM-169-D11:C1:True, UTM-169-D11:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC028")]
    public System.Threading.Tasks.Task UTM_169_TC028() => CaseRunner.Run("UTM-169-TC028");
    /// <summary>
    /// UTM-169-TC029: conditional L62 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "DateTimeOffset", "reader value": "value convertible to
    /// arranged property type", "reader value type": "DateTime (UTC)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc)) | Assert
    /// selected outcome True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:62. Untaken
    /// branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D11:True, UTM-169-D11:C1:True, UTM-169-D11:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC029")]
    public System.Threading.Tasks.Task UTM_169_TC029() => CaseRunner.Run("UTM-169-TC029");
    /// <summary>
    /// UTM-169-TC030: conditional L63 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "int", "reader value": "value convertible to arranged
    /// property type"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)
    /// : Convert.ChangeType(value, t, CultureInfo.InvariantCulture) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D12:False, UTM-169-D12:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC030")]
    public System.Threading.Tasks.Task UTM_169_TC030() => CaseRunner.Run("UTM-169-TC030");
    /// <summary>
    /// UTM-169-TC031: conditional L63 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "DateOnly", "reader value": "value convertible to arranged
    /// property type", "reader value type": "DateTime"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: t.IsEnum ? Enum.Parse(t, value.ToString()!.Replace("_", ""), true)
    /// : Convert.ChangeType(value, t, CultureInfo.InvariantCulture) | Assert selected outcome False at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D12:False, UTM-169-D12:C1:True, UTM-169-D12:C2:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC031")]
    public System.Threading.Tasks.Task UTM_169_TC031() => CaseRunner.Run("UTM-169-TC031");
    /// <summary>
    /// UTM-169-TC032: conditional L63 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "DateOnly", "reader value": "value convertible to arranged
    /// property type", "reader value type": "DateOnly"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: date | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:63. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D12:True, UTM-169-D12:C1:True, UTM-169-D12:C2:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC032")]
    public System.Threading.Tasks.Task UTM_169_TC032() => CaseRunner.Run("UTM-169-TC032");
    /// <summary>
    /// UTM-169-TC033: conditional L64 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "int", "reader value": 1}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Convert.ChangeType(value, t, CultureInfo.InvariantCulture) | Assert selected
    /// outcome False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:64. Untaken branch
    /// must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D13:False, UTM-169-D13:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC033")]
    public System.Threading.Tasks.Task UTM_169_TC033() => CaseRunner.Run("UTM-169-TC033");
    /// <summary>
    /// UTM-169-TC034: conditional L64 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"result property type": "OrderStatus", "reader value": "PENDING_UNPAID"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: Enum.Parse(t, value.ToString()!.Replace("_", ""), true) | Assert selected
    /// outcome True at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:64. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D13:True, UTM-169-D13:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC034")]
    public System.Threading.Tasks.Task UTM_169_TC034() => CaseRunner.Run("UTM-169-TC034");
    /// <summary>
    /// UTM-169-TC035: if L72 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"leased": false}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:72. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D14:False, UTM-169-D14:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC035")]
    public System.Threading.Tasks.Task UTM_169_TC035() => CaseRunner.Run("UTM-169-TC035");
    /// <summary>
    /// UTM-169-TC036: if L72 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql, object?[] parameters,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Concrete Npgsql connection/command/reader cannot currently be substituted through a project
    /// interface. Approval of an isolated transport seam or separately tagged component fixture required; real DB
    /// checks are not unit coverage. Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"sql": "SELECT product_id FROM products WHERE product_id=$1", "parameters":
    /// "Typed object?[] fixture from fixtures.json", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"leased": true}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;List&lt;T&gt;&gt; PostgreSqlSession.QueryAsync&lt;T&gt;(string sql,
    /// object?[] parameters, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: await client.DisposeAsync(); | Assert selected outcome True at
    /// src/FreshFood.Reposistory/Repository/Implements/PostgreSqlSession.cs:72. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-169-D14:True, UTM-169-D14:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Component case: requires an approved PostgreSQL transport fixture;
    /// excluded from isolated unit execution.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-169.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test][NUnit.Framework.Ignore("Component case: requires an approved PostgreSQL transport fixture; excluded from isolated unit execution.")]
    [NUnit.Framework.Property("DesignCase", "UTM-169-TC036")]
    public System.Threading.Tasks.Task UTM_169_TC036() => CaseRunner.Run("UTM-169-TC036");
}
