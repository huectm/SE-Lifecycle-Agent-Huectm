/**
 * Approved design classifier: IStateTransition
 * Ownership: FreshFood-API.Services
 * + Id: string {get}
 * + CanExecute(snapshot: TransitionSnapshot, command: TransitionCommand): boolean
 * + ExecuteAsync(snapshot: TransitionSnapshot, command: TransitionCommand, signal: AbortSignal): Promise<TransitionResult>
 */
/** IStateTransition — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class IStateTransition {
  CanExecute(snapshot, command) { throw Object.assign(new Error("IStateTransition.CanExecute: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async ExecuteAsync(snapshot, command, signal) { throw Object.assign(new Error("IStateTransition.ExecuteAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
