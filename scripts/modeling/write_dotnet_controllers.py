"""ASP.NET controller transports for the existing five customer use cases."""
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
views={
'Catalog':[
('HttpGet("/api/catalog")','GetCatalogAsync','[FromQuery] CatalogQueryDto query','query','CatalogResultDto'),
('HttpGet("/api/catalog/search")','SearchAsync','[FromQuery] CatalogQueryDto query','query','CatalogResultDto'),
('HttpGet("/api/catalog/clearance")','GetClearanceAsync','[FromQuery] CatalogQueryDto query','query','CatalogResultDto'),
('HttpGet("/api/products/{productId}")','GetProductDetailsAsync','string productId','productId','ProductDetailsDto')],
'Cart':[
('HttpGet("/api/cart")','GetCartAsync','','new CartIdentityDto()','CartResultDto'),
('HttpPut("/api/cart/items/{productId}")','ChangeQuantityAsync','string productId, [FromBody] CartChangeDto request','new CartChangeDto {ProductId=productId,Quantity=request.Quantity}','CartResultDto'),
('HttpDelete("/api/cart/items/{productId}")','RemoveItemAsync','string productId','productId','CartResultDto')],
'Profile':[
('HttpGet("/api/profile")','GetProfileAsync','','','ProfileResultDto'),
('HttpPatch("/api/profile")','UpdateProfileAsync','[FromBody] ProfileUpdateDto request','request','ProfileResultDto'),
('HttpPost("/api/addresses")','SaveAddressAsync','[FromBody] AddressInputDto request','request','AddressDto'),
('HttpPut("/api/addresses/{addressId}")','UpdateAddressAsync','string addressId, [FromBody] AddressInputDto request','request','AddressDto'),
('HttpPut("/api/addresses/{addressId}/default")','SetDefaultAddressAsync','string addressId','addressId','ProfileResultDto'),
('HttpDelete("/api/addresses/{addressId}")','DeleteAddressAsync','string addressId','addressId','OperationResultDto')],
'Checkout':[
('HttpGet("/api/checkout")','PrepareCheckoutAsync','[FromQuery] CheckoutInputDto request','request','CheckoutSummaryDto'),
('HttpPost("/api/orders")','PlaceOrderAsync','[FromBody] PlaceOrderDto request','request','OrderConfirmationDto'),
('HttpPost("/api/checkout/payment-qr")','CreatePaymentQrAsync','[FromBody] PaymentQrRequestDto request','request','PaymentQrDto')],
'MyOrders':[
('HttpGet("/api/orders")','GetOrdersAsync','','','OrderListDto'),
('HttpGet("/api/orders/{orderId}")','GetOrderDetailsAsync','string orderId','orderId','OrderDetailsDto'),
('HttpPost("/api/orders/{orderId}/cancel")','CancelOrderAsync','string orderId, [FromBody] CancelOrderDto request','request','OperationResultDto'),
('HttpPost("/api/orders/{orderId}/reorder")','ReorderAsync','string orderId','orderId','CartResultDto'),
('HttpPost("/api/orders/{orderId}/review")','SubmitReviewAsync','string orderId, [FromBody] OrderReviewDto request','request','OperationResultDto')]
}
for name,operations in views.items():
    text='using Microsoft.AspNetCore.Mvc;\nusing Microsoft.AspNetCore.Authorization;\n\nnamespace FreshFood.Api.Controllers;\n\n[ApiController]\n'
    if name in ['Profile','Checkout','MyOrders']:text+='[Authorize]\n'
    text+=f'public sealed class {name}Controller(I{name}Service service) : ControllerBase\n{{\n'
    for attribute,method,parameters,arg,result in operations:
        text+=f'    [{attribute}]\n    public Task<{result}> {method}({parameters}{", " if parameters else ""}CancellationToken signal)\n    {{\n'
        if method=='UpdateAddressAsync': text+='        request.AddressId=addressId;\n'
        if method in ['CancelOrderAsync','SubmitReviewAsync']:text+='        request.OrderId=orderId;\n'
        target='SaveAddressAsync' if method=='UpdateAddressAsync' else method
        text+=f'        return service.{target}({arg}{", " if arg else ""}signal);\n    }}\n'
    text+='}\n'
    p=ROOT/f'src/FreshFood-API/Controllers/{name}Controller.cs';p.parent.mkdir(exist_ok=True,parents=True);p.write_text(text,encoding='utf-8')
p=ROOT/'src/FreshFood-API/Controllers/PaymentWebhookController.cs'
p.write_text('''using Microsoft.AspNetCore.Mvc;
namespace FreshFood.Api.Controllers;
[ApiController]
public sealed class PaymentWebhookController(PaymentNoticeHandler handler) : ControllerBase
{
    [HttpPost("/api/payments/sepay/webhook")]
    public async Task<PaymentResultDto> HandleAsync(CancellationToken signal)
    {
        using var reader=new StreamReader(Request.Body);
        var raw=await reader.ReadToEndAsync(signal);
        return await handler.HandleAsync(new(){RawBody=raw,Signature=Request.Headers.Authorization.ToString(),ProviderReference=Request.Headers["X-Provider-Reference"].ToString()},signal);
    }
}
''',encoding='utf-8')
