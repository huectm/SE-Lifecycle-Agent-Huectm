using System.Globalization;
using System.Reflection;
using System.Text.Json;
using FreshFood.Api;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace FreshFood.Backend.UnitTests;
internal static partial class CaseRunner
{
    private static readonly JsonDocument Design=JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory,"Design.json")));
    private static readonly Dictionary<string,(JsonElement Method,JsonElement Case)> Cases=Design.RootElement.GetProperty("methods").EnumerateArray().SelectMany(m=>m.GetProperty("cases").EnumerateArray().Select(c=>(Id:c.GetProperty("id").GetString()!,Pair:(m,c)))).ToDictionary(x=>x.Id,x=>x.Pair);
    private static readonly JsonDocument Materialized=JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory,"Materialized.json")));
    internal static string S(JsonElement d,string key,string fallback="")=>d.TryGetProperty(key,out var v)&&v.ValueKind!=JsonValueKind.Null?v.ToString():fallback;
    internal static decimal N(JsonElement d,string key,decimal fallback=0)=>decimal.Parse(S(d,key,fallback.ToString(CultureInfo.InvariantCulture)),CultureInfo.InvariantCulture);
    internal static bool Has(JsonElement d,string key)=>d.TryGetProperty(key,out _);
    internal static Type TypeOf(JsonElement m)=>typeof(CheckoutService).Assembly.GetType(m.GetProperty("fullType").GetString()!)??typeof(Order).Assembly.GetType(m.GetProperty("fullType").GetString()!)??throw new InvalidOperationException("Unresolved source type");
    internal static async Task Run(string id)
    {
        var (m,c)=Cases[id];
        if(Materialized.RootElement.TryGetProperty(id,out var concrete)){
            var node=System.Text.Json.Nodes.JsonNode.Parse(c.GetRawText())!;node["data"]=System.Text.Json.Nodes.JsonNode.Parse(concrete.GetProperty("data").GetRawText());node["exception"]=concrete.GetProperty("exception").GetString();c=JsonSerializer.SerializeToElement(node);
        }
        var type=m.GetProperty("type").GetString()!;var name=m.GetProperty("name").GetString()!;var d=c.GetProperty("data");
        if(name==".ctor" && type!="VndAmount") {Constructor(m);return;}
        if(type.EndsWith("Controller",StringComparison.Ordinal)||type is "DistanceCalculator" or "NotificationAdapter" or "PaymentNoticeHandler") {await Forward(m,c);return;}
        if(type is "GoogleMapsGeocodingAdapter" or "GoogleMapsDistanceAdapter" or "SePayPaymentAdapter" or "ConfiguredNotificationPublisher" or "UnconfiguredPayoutAdapter") {await FailClosed(m,c);return;}
        if(type is "DeliveryFeePolicy" or "BatchPricingPolicy" or "BatchInventory" or "Cart" or "Order" or "VndAmount" or "VndAmountConverter" or "FefoBatchSpecification" or "ServiceRules" or "DomainException" or "TransitionSnapshot") {await Domain(m,c);return;}
        if(type=="UnitOfWork"){await Transaction(m,c);return;}
        if(type=="ApiJson"){Json(c);return;}
        if(type=="ApiCompositionRoot"){await Composition(c);return;}
        if(type=="PaymentNoticeModelBinder"){await Binder(c);return;}
        if(type=="CurrentCustomer"){Identity(c,name);return;}
        if(type=="CheckoutService"){await Checkout(m,c);return;}
        if(type=="OrderStateMachine"){await Machine(m,c);return;}
        if(type=="ProfileService"){await Profile(m,c);return;}
        if(type=="CatalogService"){await Catalog(m,c);return;}
        if(type=="CartService"){await CartServiceCase(m,c);return;}
        if(type=="MyOrdersService"){await MyOrders(m,c);return;}
        if(type.EndsWith("Repository",StringComparison.Ordinal)){await Repository(m,c);return;}
        throw new InvalidOperationException("No executable realization for "+id);
    }
    private static void Constructor(JsonElement m)
    {
        var t=TypeOf(m);var ctor=t.GetConstructors(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance).OrderByDescending(x=>x.GetParameters().Length).First();
        var args=ctor.GetParameters().Select(p=>Fixture.Value(p.ParameterType)).ToArray();
        var result=ctor.Invoke(args);TestChecks.IsType(t, result);
    }
    private static async Task Forward(JsonElement m,JsonElement c)
    {
        var type=TypeOf(m);var method=type.GetMethod(m.GetProperty("name").GetString()!)!;
        var ctor=type.GetConstructors().Single();var collaborator=ctor.GetParameters()[0].ParameterType;
        var webhook=type.Name=="PaymentWebhookController";
        if(webhook)collaborator=typeof(ICheckoutService);
        var failure=Has(c.GetProperty("data"),"failure");var sentinelError=new TimeoutException("arranged collaborator failure");
        var returnType=method.ReturnType.GenericTypeArguments.FirstOrDefault();
        var sentinel=returnType is null?null:Fixture.Value(returnType);int calls=0;
        var args=method.GetParameters().Select(p=>Fixture.Value(p.ParameterType)).ToArray();
        if(Has(c.GetProperty("data"),"routeId"))foreach(var dto in args.Where(a=>a is not null)){
            foreach(var key in new[]{"ProductId","OrderId","AddressId"})dto!.GetType().GetProperty(key)?.SetValue(dto,"99");
        }
        var proxy=StrictProxy.Create(collaborator,(called,forwarded)=>{
            calls++;Assert.That(forwarded[^1], Is.EqualTo(Fixture.Token));
            foreach(var original in args.Where(a=>a is not CancellationToken && a is not string))
            {
                if(original is CartChangeDto body){var actual=TestChecks.IsType<CartChangeDto>(forwarded[0]);Assert.That(actual.ProductId, Is.EqualTo("1"));Assert.That(actual.Quantity, Is.EqualTo(body.Quantity));}
                else {Assert.That(forwarded, Does.Contain(original));}
            }
            foreach(var p in forwarded.OfType<CancelOrderDto>())Assert.That(p.OrderId, Is.EqualTo("1"));
            foreach(var p in forwarded.OfType<OrderReviewDto>())Assert.That(p.OrderId, Is.EqualTo("1"));
            foreach(var p in forwarded.OfType<AddressInputDto>())if(method.Name=="UpdateAddressAsync")Assert.That(p.AddressId, Is.EqualTo("1"));
            if(failure)throw sentinelError;
            if(called.ReturnType==typeof(Task))return Task.CompletedTask;
            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(called.ReturnType.GenericTypeArguments[0]).Invoke(null,[sentinel]);
        });
        // Webhook controller depends on a concrete handler whose checkout port is faked.
        var owner=ctor.Invoke([webhook?new PaymentNoticeHandler((ICheckoutService)proxy):proxy]);
        if(failure){var error=await TestChecks.ThrowsAsync<TimeoutException>(()=>Fixture.Await(Fixture.Invoke(method,owner,args)));Assert.That(error, Is.SameAs(sentinelError));}
        else {
            var result=await Fixture.Await(Fixture.Invoke(method,owner,args));
            if(returnType is null) { /* Task completion is the output contract. */ }
            else if(returnType.IsValueType)Assert.That(result, Is.EqualTo(sentinel));
            else Assert.That(result, Is.SameAs(sentinel));
        }
        Assert.That(calls, Is.EqualTo(1));
    }
    private static async Task FailClosed(JsonElement m,JsonElement c)
    {
        var t=TypeOf(m);var method=t.GetMethod(m.GetProperty("name").GetString()!)!;
        var code=t.Name switch {"GoogleMapsGeocodingAdapter"=>"GEOCODING_TRANSPORT_NOT_CONFIGURED","GoogleMapsDistanceAdapter"=>"DISTANCE_TRANSPORT_NOT_CONFIGURED","SePayPaymentAdapter"=>method.Name=="CreateQrAsync"?"PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD":"PAYMENT_VERIFIER_NOT_CONFIGURED","ConfiguredNotificationPublisher"=>"NOTIFICATION_TRANSPORT_NOT_CONFIGURED",_=>"PAYOUT_PROVIDER_TBD"};
        await Fixture.Error(code,()=>Fixture.Await(Fixture.Invoke(method,Activator.CreateInstance(t),method.GetParameters().Select(p=>Fixture.Value(p.ParameterType)).ToArray())));
    }
    private static async Task Domain(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var type=m.GetProperty("type").GetString();var name=m.GetProperty("name").GetString();var expected=S(c,"exception").Split(' ')[0];
        void Check(Action action){if(expected.Length>0)Assert.That(TestChecks.Throws<DomainException>(action).Code, Is.EqualTo(expected));else action();}
        switch(type)
        {
            case "DeliveryFeePolicy":Check(()=>{var value=new DeliveryFeePolicy().Quote(N(d,"distanceKm",1));var oracle=N(d,"distanceKm",1)<1?10000:N(d,"distanceKm",1)<3?20000:30000;Assert.That(value.Units, Is.EqualTo(oracle));});break;
            case "BatchPricingPolicy":Check(()=>{var b=Fixture.Batch();b.RetailPrice=new(N(d,"RetailPrice",10000));b.DiscountRate=N(d,"DiscountRate");Assert.That(new BatchPricingPolicy().Quote(b,DateTimeOffset.UtcNow).Units, Is.EqualTo(b.RetailPrice.Units*(100-b.DiscountRate)/100));});break;
            case "BatchInventory":
                var batch=Fixture.Batch((int)N(d,"CurrentStock",10),(int)N(d,"ReservedStock",3));var old=batch.ReservedStock;var qty=(int)N(d,"quantity",2);
                Check(()=>{if(name=="Reserve")batch.Reserve(qty);else batch.ReleaseReservation(qty);});Assert.That(batch.ReservedStock, Is.EqualTo(expected.Length>0?old:old+(name=="Reserve"?qty:-qty)));break;
            case "Cart":
                var cart=new Cart();cart.Items.Add(new(){ProductId="2",Quantity=4});
                if(name=="ChangeQuantity"){cart.ChangeQuantity("1",2);cart.ChangeQuantity("1",3);Assert.That(cart.Items.Single(x=>x.ProductId=="1").Quantity, Is.EqualTo(3));}
                else{cart.Items.Add(new(){ProductId="1",Quantity=2});cart.RemoveItem("1");Assert.That(cart.Items.Any(x=>x.ProductId=="1"), Is.False);cart.RemoveItem("99");}Assert.That(cart.Items.Single(x=>x.ProductId=="2").Quantity, Is.EqualTo(4));break;
            case "Order":
                var order=new Order { OrderStatus=OrderStatus.PendingUnpaid,PaymentStatus=PaymentStatus.Unpaid };
                if(name=="RecordPayment"){order.RecordPayment(PaymentStatus.Unpaid,PaymentStatus.Paid);Assert.That(order.PaymentStatus, Is.EqualTo(PaymentStatus.Paid));Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.PendingUnpaid));}
                else if(name=="Cancel"){order.Cancel(OrderStatus.PendingUnpaid,"Changed mind");Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.Cancelled));Assert.That(order.CancellationReason, Is.EqualTo("Changed mind"));}
                else{order.ApplyFulfillment(OrderStatus.PendingUnpaid,OrderStatus.Confirmed);Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.Confirmed));}break;
            case "VndAmount":
                var value=N(d,"units",N(d,"Units",10000));
                Check(()=>{
                    if(name=="Add"){var left=N(d,"left",10000);var right=N(d,"right",N(d,"other",10000));Assert.That(new VndAmount(left).Add(new(right)).Units, Is.EqualTo(left+right));}
                    else if(name=="FromUnits")Assert.That(VndAmount.FromUnits(value).Units, Is.EqualTo(value));
                    else {var v=new VndAmount(value);Assert.That(name=="ToString"?v.ToString():v.ToWire(), Is.EqualTo(value.ToString("0",CultureInfo.InvariantCulture)));}
                });break;
            case "FefoBatchSpecification":var criteria=new FefoBatchSpecification().Criteria(new(2099,1,1,0,0,0,TimeSpan.Zero));Assert.That(criteria.ActiveProductsOnly, Is.True);Assert.That(criteria.LockForUpdate, Is.True);Assert.That(criteria.MinimumAvailable, Is.EqualTo(1));Assert.That(criteria.SortKeys, Is.EqualTo(new[]{"expiry_date","batch_id"}));break;
            case "ServiceRules":
                var t=TypeOf(m);var method=t.GetMethod(name!,BindingFlags.NonPublic|BindingFlags.Static)!;
                object?[] args=method.GetParameters().Select(p=>p.ParameterType==typeof(string)?(object?)S(d,p.Name!,p.Name=="code"?"POLICY_TBD":"Sample"):p.ParameterType==typeof(int)?(int)N(d,p.Name!,400):p.ParameterType==typeof(bool)?S(d,p.Name!)=="True":p.ParameterType==typeof(BatchInventory)?Fixture.Batch():Fixture.Value(p.ParameterType)).ToArray();
                if(name is "Id" or "Key" or "Text")Check(()=>{var result=Fixture.Invoke(method,null,args);Assert.That(result, Is.EqualTo(S(d,"value","Sample").Trim()));});
                else if(name=="Require") {var error=TestChecks.Throws<DomainException>(()=>Fixture.Invoke(method,null,args));Assert.That(error.Code, Is.EqualTo(S(d,"code","POLICY_TBD")));}
                else if(name=="Sellable")Assert.That(Fixture.Invoke(method,null,args), Is.EqualTo(true));
                else if(name=="Money")Assert.That(Fixture.Invoke(method,null,[10000m]), Is.EqualTo("10000"));
                else if(name=="Fefo"){var b1=Fixture.Batch();var b2=Fixture.Batch();b2.BatchId="2";Assert.That(((List<BatchInventory>)Fixture.Invoke(method,null,[new[]{b2,b1}])!).Select(x=>x.BatchId), Is.EqualTo(new[]{"1","2"}));}
                else if(name=="Address"){var a=Fixture.Address();var dto=(AddressDto)Fixture.Invoke(method,null,[a])!;Assert.That(dto.AddressId, Is.EqualTo(a.AddressId));Assert.That(dto.Latitude, Is.EqualTo(a.Latitude));}
                else {var o=new Order{OrderId="1",TotalAmount=new(10000)};Assert.That(((OrderSummaryDto)Fixture.Invoke(method,null,[o])!).Total, Is.EqualTo("10000"));}break;
            case "VndAmountConverter":var wire=JsonSerializer.Serialize(new VndAmount(10000));Assert.That(wire, Is.EqualTo("\"10000\""));Assert.That(JsonSerializer.Deserialize<VndAmount>(wire).Units, Is.EqualTo(10000));break;
            default:throw new InvalidOperationException("Missing domain oracle "+type);
        }
        await Task.CompletedTask;
    }
    private static async Task Transaction(JsonElement m,JsonElement c)
    {
        var events=new List<string>();var fail=Has(c.GetProperty("data"),"failure");var error=new TimeoutException("work failed");
        var session=StrictProxy.For<IRepositorySession>((n,a)=>{events.Add(n);Assert.That(a[0], Is.EqualTo(n=="RollbackAsync"?CancellationToken.None:Fixture.Token));return Task.CompletedTask;});
        var work=new UnitOfWork(session);
        async Task Action(){if(m.GetProperty("parameters")[0].GetProperty("type").GetString()!.Contains("Task<T>",StringComparison.Ordinal))Assert.That(await work.ExecuteAsync<int>(ct=>{events.Add("work");if(fail)throw error;return Task.FromResult(42);},Fixture.Token), Is.EqualTo(42));else await work.ExecuteAsync(ct=>{events.Add("work");if(fail)throw error;return Task.CompletedTask;},Fixture.Token);}
        if(fail)Assert.That(await TestChecks.ThrowsAsync<TimeoutException>(Action), Is.SameAs(error));else await Action();Assert.That(events, Is.EqualTo(new[]{"BeginAsync","work",fail?"RollbackAsync":"CommitAsync"}));
    }
}
