const trusted = new WeakMap();
export function trustedSnapshot(fields, context) { const snapshot=Object.freeze({...fields,GuardFacts:Object.freeze({...fields.GuardFacts})}); trusted.set(snapshot,context); return snapshot; }
export function transitionContext(snapshot) { const context=trusted.get(snapshot);if(!context)throw Object.assign(new Error('Untrusted transition snapshot'),{code:'UNTRUSTED_TRANSITION',status:403});return context; }
export async function publishAfterCommit(gateway,message,signal) { try { await gateway.PublishAsync(message,signal); } catch { console.warn('NOTIFICATION_DELIVERY_FAILED',message.EventCode); } }
