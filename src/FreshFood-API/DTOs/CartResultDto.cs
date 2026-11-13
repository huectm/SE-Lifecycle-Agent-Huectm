namespace FreshFood.Api.DTOs;

public class CartResultDto
{
    public List<CartLineDto> Lines { get; set; } = [];
    public string SubTotal { get; set; } = string.Empty;
    public bool CanCheckout { get; set; }
    public List<string> Warnings { get; set; } = [];
}
