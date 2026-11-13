namespace FreshFood.Api.Services;

public interface ICartService
{
    Task<CartResultDto> GetCartAsync(CartIdentityDto identity, CancellationToken signal);
    Task<CartResultDto> ChangeQuantityAsync(CartChangeDto request, CancellationToken signal);
    Task<CartResultDto> RemoveItemAsync(string productId, CancellationToken signal);
}
