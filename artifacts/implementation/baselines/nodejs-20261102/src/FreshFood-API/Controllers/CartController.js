/**
 * Design revision 2026-11-02: CartController
 * Ownership: FreshFood-API.Controllers
 * - service: ICartService
 * + CartController(service: ICartService)
 * + GetCartAsync(identity: CartIdentityDto, signal: AbortSignal): Promise<CartResultDto>
 * + ChangeQuantityAsync(request: CartChangeDto, signal: AbortSignal): Promise<CartResultDto>
 * + RemoveItemAsync(productId: EntityId, signal: AbortSignal): Promise<CartResultDto>
 */
/** UC-C03: injected service contract; transport/authentication belongs to HTTP composition. */
export class CartController {
  constructor(service) { this.service = service; }
  async GetCartAsync(identity, signal) { return this.service.GetCartAsync(identity, signal); }
  async ChangeQuantityAsync(request, signal) { return this.service.ChangeQuantityAsync(request, signal); }
  async RemoveItemAsync(productId, signal) { return this.service.RemoveItemAsync(productId, signal); }
}
