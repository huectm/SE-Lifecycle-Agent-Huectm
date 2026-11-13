/**
 * Design revision 2026-11-02: NotificationDto
 * Ownership: FreshFood-API.DTOs
 * + OrderId: EntityId
 * + EventCode: string
 */
/** NotificationDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class NotificationDto {
  constructor(values = {}) {
    this.OrderId = values.OrderId;
    this.EventCode = values.EventCode;
  }
}
