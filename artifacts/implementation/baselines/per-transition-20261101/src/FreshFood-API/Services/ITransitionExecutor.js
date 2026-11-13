/**
 * Approved design classifier: ITransitionExecutor
 * Ownership: FreshFood-API.Services
 * + ExecuteAsync(command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 * + ExecuteInCurrentTransactionAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
/** ITransitionExecutor — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class ITransitionExecutor {
  async ExecuteAsync(command, signal) { throw Object.assign(new Error("ITransitionExecutor.ExecuteAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async ExecuteInCurrentTransactionAsync(snapshot, command, signal) { throw Object.assign(new Error("ITransitionExecutor.ExecuteInCurrentTransactionAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
