/**
 * Design revision 2026-11-02: ICartService
 * Ownership: FreshFood-API.Services
 * + GetCartAsync(identity: CartIdentityDto, signal: AbortSignal): Promise<CartResultDto>
 * + ChangeQuantityAsync(request: CartChangeDto, signal: AbortSignal): Promise<CartResultDto>
 * + RemoveItemAsync(productId: EntityId, signal: AbortSignal): Promise<CartResultDto>
 */
/** ICartService — FreshFood-API.Services; approved design source: detailed-class-model.json. */
export class ICartService {
  async GetCartAsync(identity, signal) { throw Object.assign(new Error("ICartService.GetCartAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async ChangeQuantityAsync(request, signal) { throw Object.assign(new Error("ICartService.ChangeQuantityAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
  async RemoveItemAsync(productId, signal) { throw Object.assign(new Error("ICartService.RemoveItemAsync: implementation or external port required"), { code: "DESIGN_PORT_UNCONFIGURED", status: 503 }); }
}
