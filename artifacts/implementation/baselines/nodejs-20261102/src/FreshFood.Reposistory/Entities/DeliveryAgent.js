/**
 * Design revision 2026-11-02: DeliveryAgent
 * Ownership: FreshFood.Reposistory.Entities
 * + DeliveryAgentId: EntityId {private set}
 * + DisplayName: string {private set}
 * + ContactPhone: string {private set}
 */
import { initializeEntity, patchEntity } from './EntityState.js';
export class DeliveryAgent {
  constructor(values={}){initializeEntity(this,values,["DeliveryAgentId", "DisplayName", "ContactPhone"]);}
}
