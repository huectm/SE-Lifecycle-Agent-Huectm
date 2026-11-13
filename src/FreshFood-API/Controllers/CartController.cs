using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FreshFood.Api.Controllers;

[ApiController]
public sealed class CartController(ICartService service) : ControllerBase
{
    [HttpGet("/api/cart")]
    public Task<CartResultDto> GetCartAsync(CancellationToken signal)
    {
        return service.GetCartAsync(new CartIdentityDto(), signal);
    }
    [HttpPut("/api/cart/items/{productId}")]
    public Task<CartResultDto> ChangeQuantityAsync(string productId, [FromBody] CartChangeDto request, CancellationToken signal)
    {
        return service.ChangeQuantityAsync(new CartChangeDto { ProductId = productId, Quantity = request.Quantity }, signal);
    }
    [HttpDelete("/api/cart/items/{productId}")]
    public Task<CartResultDto> RemoveItemAsync(string productId, CancellationToken signal)
    {
        return service.RemoveItemAsync(productId, signal);
    }
}
