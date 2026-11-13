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
    internal static async Task PaymentGuardSafety(bool initial,bool verified,bool paidState)
    {
        var order=new Order{CustomerId="7",OrderStatus=paidState?OrderStatus.PendingPaid:OrderStatus.PendingUnpaid,PaymentStatus=PaymentStatus.Unpaid};
        var context=Context(order,[],initial,verified);
        typeof(TransitionSnapshot).GetProperty("PaymentInitialized",BindingFlags.NonPublic|BindingFlags.Instance)!.SetValue(context,true);
        var repository=StrictProxy.For<IOrderLifecycleRepository>((n,a)=>throw new InvalidOperationException("Rejected payment must not write evidence"));
        await Fixture.Error("STATE_GUARD_REJECTED",()=>new OrderStateMachine(repository).ProcessEventAsync(context,new(){Event="verifiedSePayNotification",AggregateId="checkout:7:ref",EventId="untrusted"},Fixture.Token));
        Assert.That(order.PaymentStatus, Is.EqualTo(PaymentStatus.Unpaid));
    }
    private static async Task Catalog(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var fail=Has(d,"failure");var empty=Has(d,"boundary");var calls=new List<string>();
        var repo=StrictProxy.For<ICatalogRepository>((n,a)=>{
            calls.Add(n);Assert.That(a[^1], Is.EqualTo(Fixture.Token));if(fail)throw new TimeoutException("catalog sentinel");
            return n switch {"FindActiveAsync" or "GetPopularAsync"=>Task.FromResult(empty?new List<Product>():new List<Product>{new(){ProductId="1",ProductName="Greens",IsActive=true},new(){ProductId="2",IsActive=false}}),"GetProductAsync"=>Task.FromResult<Product?>(new(){ProductId="1",ProductName="Greens",IsActive=true}),"GetCategoriesAsync"=>Task.FromResult(new List<ProductCategory>{new(){CategoryId=1,CategoryName="Vegetables"}}),"GetSellableBatchesAsync"=>Task.FromResult(new List<BatchInventory>{Fixture.Batch()}),_=>throw new InvalidOperationException(n)};
        });
        var owner=new CatalogService(repo,new BatchPricingPolicy());var method=m.GetProperty("name").GetString();
        async Task Action(){
            if(method=="GetProductDetailsAsync"){var r=await owner.GetProductDetailsAsync("1",Fixture.Token);Assert.That(r.Product.ProductId, Is.EqualTo("1"));TestChecks.Single(r.AvailableBatches);}
            else if(method=="Summaries"){var mi=owner.GetType().GetMethod(method,BindingFlags.Instance|BindingFlags.NonPublic)!;var r=(List<ProductSummaryDto>)(await Fixture.Await(Fixture.Invoke(mi,owner,new List<Product>{new(){ProductId="1",IsActive=true}},Fixture.Token)))!;Assert.That(TestChecks.Single(r).AvailableQuantity, Is.EqualTo(7));}
            else {var query=new CatalogQueryDto();var r=method=="GetClearanceAsync"?await owner.GetClearanceAsync(query,Fixture.Token):method=="SearchAsync"?await owner.SearchAsync(query,Fixture.Token):await owner.GetCatalogAsync(query,Fixture.Token);TestChecks.Single(r.Categories);if(empty)Assert.That(r.Items, Is.Empty);else{var item=TestChecks.Single(r.Items);Assert.That(item.AvailableQuantity, Is.EqualTo(7));Assert.That(item.CurrentPrice, Is.EqualTo("10000"));}}
        }
        if(fail)await TestChecks.ThrowsAsync<TimeoutException>(Action);else await Action();Assert.That(calls, Is.Not.Empty);
    }
    private static async Task CartServiceCase(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var fail=Has(d,"failure");var empty=Has(d,"boundary");var cart=new Cart{CartId="1",CustomerId="7",Items=empty?[]:[new(){ProductId="1",Quantity=2}]};int saves=0;
        var repo=StrictProxy.For<ICartRepository>((n,a)=>{
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));if(fail)throw new TimeoutException("cart sentinel");
            return n switch {"GetAsync"=>a[0]?.ToString()=="7"?Task.FromResult(cart):throw new InvalidOperationException("Untrusted identity"),"GetProductsAsync"=>Task.FromResult(new List<Product>{new(){ProductId="1",IsActive=true}}),"GetSellableBatchesAsync"=>Task.FromResult(new List<BatchInventory>{Fixture.Batch()}),"SaveAsync"=>Save(),_=>throw new InvalidOperationException(n)};
        });Task Save(){saves++;return Task.CompletedTask;}
        var owner=new CartService(repo,Fixture.Customer(),new ImmediateWork(),new BatchPricingPolicy());var name=S(m,"name");
        async Task Action(){
            if(name=="Load"){var mi=owner.GetType().GetMethod(name,BindingFlags.NonPublic|BindingFlags.Instance)!;Assert.That(await Fixture.Await(Fixture.Invoke(mi,owner,Fixture.Token)), Is.SameAs(cart));return;}
            CartResultDto result;
            if(name=="ChangeQuantityAsync"){result=await owner.ChangeQuantityAsync(new(){ProductId="1",Quantity=2},Fixture.Token);Assert.That(TestChecks.Single(result.Lines).Quantity, Is.EqualTo(2));Assert.That(saves, Is.EqualTo(1));}
            else if(name=="RemoveItemAsync"){result=await owner.RemoveItemAsync("1",Fixture.Token);Assert.That(result.Lines, Is.Empty);Assert.That(saves, Is.EqualTo(1));}
            else if(name=="Result"){var mi=owner.GetType().GetMethod(name,BindingFlags.NonPublic|BindingFlags.Instance)!;result=(CartResultDto)(await Fixture.Await(Fixture.Invoke(mi,owner,cart,Fixture.Token)))!;}
            else result=await owner.GetCartAsync(new(){CustomerId="99"},Fixture.Token);
            Assert.That(result.SubTotal, Is.EqualTo(result.Lines.Count>0?"20000":"0"));
        }
        if(fail)await TestChecks.ThrowsAsync<TimeoutException>(Action);else await Action();
    }
    private static async Task Profile(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var fail=Has(d,"failure");var customer=new Customer{CustomerId="7",FullName="Before"};var addresses=new List<CustomerAddress>{Fixture.Address()};CustomerAddress? saved=null;int geocodes=0,writes=0;
        var repo=StrictProxy.For<IProfileRepository>((n,a)=>{
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));if(fail)throw new TimeoutException("profile sentinel");
            return n switch {"GetCustomerAsync"=>Task.FromResult(customer),"GetAddressesAsync"=>Task.FromResult(addresses),"SaveCustomerAsync"=>Write(),"SaveAddressAsync"=>Save(a),"HasActiveOrderAsync"=>Task.FromResult(S(d,"HasActiveOrder")=="True"),"DeleteAddressAsync"=>Write(),_=>throw new InvalidOperationException(n)};
        });Task Write(){writes++;return Task.CompletedTask;}Task Save(object?[] a){saved=(CustomerAddress)a[0]!;return Write();}
        var geo=StrictProxy.For<IGeocodingGateway>((n,a)=>{geocodes++;return Task.FromResult(new GeoPointDto{Latitude=N(d,"Latitude",10),Longitude=N(d,"Longitude",105)});});var work=new ImmediateWork();var owner=new ProfileService(repo,Fixture.Customer(),work,geo);
        var code=S(c,"exception");
        async Task Action(){switch(S(m,"name")){
            case "GetProfileAsync":var profile=await owner.GetProfileAsync(Fixture.Token);Assert.That(profile.CustomerId, Is.EqualTo("7"));TestChecks.Single(profile.Addresses);break;
            case "UpdateProfileAsync":var email=Has(d,"Email")?(d.GetProperty("Email").ValueKind==JsonValueKind.Null?null:S(d,"Email")):"tester@example.com";if(email?.Contains("65000",StringComparison.Ordinal)==true)email="tester@"+new string('.',65000)+"@";var updated=await owner.UpdateProfileAsync(new(){FullName=" Tester ",Email=email},Fixture.Token);Assert.That(updated.FullName, Is.EqualTo("Tester"));Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email)?null:email));break;
            case "SaveAddressAsync":var result=await owner.SaveAddressAsync(new(){AddressId=Has(d,"AddressId")?d.GetProperty("AddressId").GetString():null,RecipientName=" Tester ",RecipientPhone=S(d,"Phone","123456789"),StreetAddress=" Test street ",IsDefault=S(d,"IsDefault")=="True"?true:null},Fixture.Token);Assert.That(saved, Is.Not.Null);Assert.That(saved!.CustomerId, Is.EqualTo("7"));Assert.That(result.IsDefault, Is.EqualTo(S(d,"IsDefault")=="True"));Assert.That(geocodes, Is.EqualTo(1));break;
            case "SetDefaultAddressAsync":await owner.SetDefaultAddressAsync("2",Fixture.Token);Assert.That(addresses[0].IsDefault, Is.True);Assert.That(writes, Is.EqualTo(1));break;
            case "DeleteAddressAsync":Assert.That((await owner.DeleteAddressAsync("2",Fixture.Token)).MessageCode, Is.EqualTo("ADDRESS_DELETED"));Assert.That(writes, Is.EqualTo(1));break;
        }}
        if(fail)await TestChecks.ThrowsAsync<TimeoutException>(Action);else if(code.Length>0){await Fixture.Error(code,Action);Assert.That(writes, Is.EqualTo(0));if(code=="INVALID_PHONE")Assert.That(geocodes, Is.EqualTo(0));}else await Action();
    }
    private static async Task MyOrders(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var name=S(m,"name");var fail=Has(d,"failure");var order=new Order{OrderId="1",CustomerId="7",DeliveryAddress=Fixture.Address(),OrderStatus=Enum.Parse<OrderStatus>(S(d,"OrderStatus",name=="SubmitReviewAsync"?"Delivered":"PendingUnpaid")),PaymentStatus=PaymentStatus.Unpaid,Details=[new(){ProductId="1",BatchId="1",Quantity=(int)N(d,"Wanted",2),UnitPrice=new(10000),LineTotal=new(20000)}],Failure=S(d,"Failure")=="True"?new(){Reason="Customer unavailable"}:null};
        int writes=0;Cart? savedCart=null;var batch=Fixture.Batch((int)N(d,"Available",7),0);batch.RetailPrice=new(N(d,"Price",10000));
        var repo=StrictProxy.For<IMyOrdersRepository>((n,a)=>{
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));if(fail)throw new TimeoutException("orders sentinel");
            return n switch {"FindOwnedAsync"=>Task.FromResult(new List<Order>{order}),"LockOwnedAsync"=>Task.FromResult(order),"GetReturnReceiptAsync"=>Task.FromResult<ReturnReceipt?>(S(d,"Receipt")=="True"?new():null),"GetRefundAsync"=>Task.FromResult<Refund?>(S(d,"Refund")=="True"?new(){GoodsAmount=new(N(d,"GoodsAmount")),ShippingAmount=new(N(d,"ShippingAmount"))}:null),"GetCurrentBatchesAsync"=>Task.FromResult(new List<BatchInventory>{batch}),"SaveCartAsync"=>Save(a),"SaveReviewOnceAsync"=>Task.FromResult(Review()),_=>throw new InvalidOperationException(n)};
        });Task Save(object?[] a){writes++;savedCart=(Cart)a[0]!;return Task.CompletedTask;}bool Review(){writes++;return S(d,"SaveReviewOnce","True")=="True";}
        var life=StrictProxy.For<IOrderLifecycleRepository>((n,a)=>n switch {"RecordEventOnceAsync"=>Task.FromResult(true),"LockReservedBatchesAsync"=>Task.FromResult(new List<BatchInventory>{Fixture.Batch(10,2)}),"SaveBatchesAsync" or "SaveAsync" or "AppendAuditAsync"=>Task.CompletedTask,_=>throw new InvalidOperationException(n)});
        var owner=new MyOrdersService(repo,Fixture.Customer(),new ImmediateWork(),StrictProxy.For<INotificationGateway>((n,a)=>Task.CompletedTask),new OrderStateMachine(life),new BatchPricingPolicy(),NullLogger<MyOrdersService>.Instance);
        async Task Action(){switch(name){
            case "GetOrdersAsync":Assert.That(TestChecks.Single((await owner.GetOrdersAsync(Fixture.Token)).Orders).OrderId, Is.EqualTo("1"));break;
            case "GetOrderDetailsAsync":var detail=await owner.GetOrderDetailsAsync("1",Fixture.Token);if(S(d,"Receipt")=="True"||S(d,"Refund")=="True"){Assert.That(detail.Return, Is.Not.Null);Assert.That(detail.Return!.GoodsRefunded, Is.EqualTo(S(d,"Refund")=="True"?S(d,"GoodsAmount"):"0"));}else Assert.That(detail.Return, Is.Null);break;
            case "CancelOrderAsync":var cancelled=await owner.CancelOrderAsync(new(){OrderId="1",Reason="Changed mind"},Fixture.Token);Assert.That(cancelled.MessageCode, Is.EqualTo(S(d,"OrderStatus")=="Cancelled"?"ORDER_ALREADY_CANCELLED":"ORDER_CANCELLED"));Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.Cancelled));break;
            case "ReorderAsync":var cart=await owner.ReorderAsync("1",Fixture.Token);Assert.That(savedCart, Is.Not.Null);if(N(d,"Available",7)==0){Assert.That(cart.Lines, Is.Empty);Assert.That(cart.Warnings, Does.Contain("UNAVAILABLE:1"));}else {var line=TestChecks.Single(cart.Lines);Assert.That(line.Quantity, Is.EqualTo(Math.Min((int)N(d,"Wanted",2),(int)N(d,"Available",7))));Assert.That(decimal.Parse(line.LineTotal), Is.EqualTo(line.Quantity*N(d,"Price",10000)));}break;
            case "SubmitReviewAsync":Assert.That((await owner.SubmitReviewAsync(new(){OrderId="1",Rating=(int)N(d,"Rating",5)},Fixture.Token)).MessageCode, Is.EqualTo("REVIEW_SAVED"));Assert.That(writes, Is.EqualTo(1));break;
        }}
        if(fail)await TestChecks.ThrowsAsync<TimeoutException>(Action);else if(S(c,"exception").Length>0)await Fixture.Error(S(c,"exception"),Action);else await Action();
    }
    private static TransitionSnapshot Context(Order order,bool initial=true,bool paid=false)=>Context(order,[Fixture.Batch()],initial,paid);
    private static TransitionSnapshot Context(Order order,List<BatchInventory> batches,bool initial,bool paid)
    {
        var ctor=typeof(TransitionSnapshot).GetConstructors(BindingFlags.Instance|BindingFlags.NonPublic).Single();
        var value=(TransitionSnapshot)ctor.Invoke(["checkout:7:ref","7",order,batches,initial]);typeof(TransitionSnapshot).GetProperty("VerifiedPayment",BindingFlags.NonPublic|BindingFlags.Instance)!.SetValue(value,paid);return value;
    }
    private static async Task Machine(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var paid=S(d,"VerifiedPayment")=="True";var order=new Order{CustomerId="7",PaymentStatus=paid?PaymentStatus.Paid:PaymentStatus.Unpaid,Details=[new(){BatchId="1",Quantity=(int)N(d,"Quantity",2)}]};var evidence=new List<string>();var fail=Has(d,"failure");
        var repo=StrictProxy.For<IOrderLifecycleRepository>((n,a)=>{if(fail)throw new TimeoutException("evidence sentinel");Assert.That(n, Is.EqualTo("RecordEventOnceAsync"));evidence.Add((string)a[2]!);return Task.FromResult(S(d,"RecordEventOnce","True")=="True");});var owner=new OrderStateMachine(repo);
        var name=S(m,"name");
        if(name is "State" or "Guard"){
            var b=Fixture.Batch((int)N(d,"Available",7),0);b.BatchId=S(d,"BatchId","1");var context=Context(order,[b],S(d,"Initial")=="True",false);
            void Set(string property,object value)=>typeof(TransitionSnapshot).GetProperty(property,BindingFlags.NonPublic|BindingFlags.Instance)!.SetValue(context,value);
            Set("PaymentInitialized",S(d,"PaymentInitialized")=="True");Set("FulfillmentCompleted",S(d,"Completed")=="True");Set("WorkflowNode",S(d,"Workflow","initial"));
            var method=typeof(OrderStateMachine).GetMethod(name,BindingFlags.Static|BindingFlags.NonPublic)!;
            if(name=="State")Assert.That(Fixture.Invoke(method,null,S(d,"Region"),context), Is.EqualTo(S(d,"StateExpected")));
            else Assert.That(Fixture.Invoke(method,null,S(d,"Guard"),context), Is.EqualTo(S(d,"GuardExpected")=="True"));
            return;
        }
        if(name=="CurrentState"){
            if(S(d,"HasSnapshot")=="True"){await owner.ProcessEventAsync(Context(order),new(){Event="acceptOrder",AggregateId="checkout:7:ref",EventId="event"},Fixture.Token);Assert.That(owner.CurrentState()!.FulfillmentState, Is.EqualTo(OrderStatus.PendingUnpaid));}else Assert.That(owner.CurrentState(), Is.Null);return;
        }
        if(name=="Canonical"){Assert.That(Fixture.Invoke(typeof(OrderStateMachine).GetMethod(name,BindingFlags.NonPublic|BindingFlags.Static)!,null,"PendingPaid"), Is.EqualTo("pending_paid"));return;}
        if(name=="LoadTable"){var table=(Array)Fixture.Invoke(typeof(OrderStateMachine).GetMethod(name,BindingFlags.NonPublic|BindingFlags.Static)!,null)!;Assert.That(table.Length, Is.EqualTo(24));return;}
        if(S(d,"ExistingSnapshot")=="True")await owner.ProcessEventAsync(Context(order),new(){Event="acceptOrder",AggregateId="checkout:7:ref",EventId="first"},Fixture.Token);
        async Task Action(){
            var context=Context(order,true,paid);var aggregate=S(d,"DifferentAggregate")=="True"?"other":"checkout:7:ref";
            if(S(d,"DifferentAggregate")=="True"||S(d,"DifferentCustomer")=="True")context=(TransitionSnapshot)typeof(TransitionSnapshot).GetConstructors(BindingFlags.NonPublic|BindingFlags.Instance).Single().Invoke([aggregate,S(d,"DifferentCustomer")=="True"?"8":"7",order,new List<BatchInventory>{Fixture.Batch()},true]);
            var result=await owner.ProcessEventAsync(context,new(){Event=S(d,"Event","acceptOrder"),AggregateId=S(d,"AggregateMismatch")=="True"?"other":aggregate,EventId="event"},Fixture.Token);Assert.That(result.Applied, Is.True);Assert.That(result.TransitionIds, Is.EqualTo(paid?new[]{"I00","T01p","P01","P02"}:new[]{"I00","T01u","P01"}));Assert.That(order.OrderStatus, Is.EqualTo(paid?OrderStatus.PendingPaid:OrderStatus.PendingUnpaid));Assert.That(order.PaymentStatus, Is.EqualTo(paid?PaymentStatus.Paid:PaymentStatus.Unpaid));
        }
        if(fail){await TestChecks.ThrowsAsync<TimeoutException>(Action);Assert.That(owner.CurrentState(), Is.Null);}else if(S(c,"exception").Length>0){await Fixture.Error(S(c,"exception"),Action);if(S(d,"ExistingSnapshot")!="True")Assert.That(owner.CurrentState(), Is.Null);else Assert.That(owner.CurrentState(), Is.Not.Null);}else await Action();
    }
    private static async Task Checkout(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var name=S(m,"name");
        if(name is "RequestHash" or "LegacyJsonString"){
            if(Has(d,"Fixture")){using var vectors=JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory,"checkout-hash-vectors.json")));foreach(var vector in vectors.RootElement.EnumerateArray())Assert.That(CheckoutService.RequestHash(new(){AddressId="2",PaymentMethod=PaymentMethod.Cod,CheckoutReference=vector.GetProperty("Reference").GetString()!}), Is.EqualTo(vector.GetProperty("Hash").GetString()));}
            else if(name=="LegacyJsonString")Assert.That(Fixture.Invoke(typeof(CheckoutService).GetMethod(name,BindingFlags.NonPublic|BindingFlags.Static)!,null,"Sample"), Is.EqualTo("\"Sample\""));
            else Assert.That(CheckoutService.RequestHash(new(){AddressId="2",PaymentMethod=PaymentMethod.Cod,CheckoutReference="ref"}).Length, Is.EqualTo(64));return;
        }
        var cart=new Cart{CartId="1",CustomerId="7",Items=[new(){ProductId="1",Quantity=(int)N(d,"Quantity",2)}]};var addresses=0;var saves=0;var clears=0;var completes=0;var notices=0;var fail=Has(d,"failure");var replay=S(d,"ClaimReplay")=="True";var address=Fixture.Address();
        var stored=new OrderConfirmationDto{OrderId="42",OrderNumber="existing",Total="30000",Status=OrderStatus.PendingUnpaid,PaymentStatus=PaymentStatus.Unpaid};
        var repo=StrictProxy.For<ICheckoutRepository>((n,a)=>{
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));if(fail)throw new TimeoutException("checkout sentinel");
            return n switch {"GetCheckoutCartAsync"=>Cart(),"GetOwnedAddressAsync"=>Address(),"LockFefoBatchesAsync"=>Task.FromResult(new List<BatchInventory>{Fixture.Batch((int)N(d,"Available",7)+3,3)}),"ClaimCheckoutAsync"=>Task.FromResult<object>(new CheckoutClaim{Replay=replay,Response=replay?JsonSerializer.Serialize(stored,ApiJson.Options):null}),"SaveOrderAsync"=>Save(a),"ClearCartAsync"=>Clear(),"CompleteCheckoutAsync"=>Complete(),_=>throw new InvalidOperationException(n)};
        });
        Task<Cart> Cart(){if(replay)return Task.FromResult(new Cart());return Task.FromResult(cart);}
        Task<CustomerAddress> Address(){addresses++;if(Has(d,"lockedStreet")&&addresses>1){var other=Fixture.Address();other.StreetAddress=S(d,"lockedStreet");return Task.FromResult(other);}return Task.FromResult(address);}
        Task Save(object?[] a){saves++;((Order)a[0]!).OrderId="42";return Task.CompletedTask;}Task Clear(){clears++;return Task.CompletedTask;}Task Complete(){completes++;return Task.CompletedTask;}
        var distance=StrictProxy.For<IDistanceCalculator>((n,a)=>Task.FromResult(0.5m));
        var gateway=StrictProxy.For<IPaymentGateway>((n,a)=>fail?throw new TimeoutException("payment verification sentinel"):Task.FromResult(new VerifiedPaymentDto{ProviderReference="provider",CheckoutReference="ref"}));
        var life=StrictProxy.For<IOrderLifecycleRepository>((n,a)=>n=="RecordEventOnceAsync"?Task.FromResult(true):throw new InvalidOperationException(n));
        var notify=StrictProxy.For<INotificationGateway>((n,a)=>{notices++;if(Has(d,"Publish"))throw new TimeoutException("notification sentinel");return Task.CompletedTask;});
        var owner=new CheckoutService(repo,Fixture.Customer(),new ImmediateWork(),distance,gateway,notify,new OrderStateMachine(life),new BatchPricingPolicy(),new DeliveryFeePolicy(),NullLogger<CheckoutService>.Instance);
        async Task Action(){
            if(name=="CreatePaymentQrAsync"){await owner.CreatePaymentQrAsync(new(){CheckoutReference="ref"},Fixture.Token);return;}
            if(name=="HandleVerifiedPaymentAsync"){await owner.HandleVerifiedPaymentAsync(new(),Fixture.Token);return;}
            if(name=="PrepareCheckoutAsync"){var summary=await owner.PrepareCheckoutAsync(new(){AddressId="2"},Fixture.Token);Assert.That(summary.Total, Is.EqualTo("30000"));Assert.That(TestChecks.Single(summary.Lines).Quantity, Is.EqualTo(2));return;}
            if(name is "Plan" or "Allocate"){var method=typeof(CheckoutService).GetMethod(name,BindingFlags.NonPublic|BindingFlags.Instance)!;var result=await Fixture.Await(Fixture.Invoke(method,owner,name=="Plan"?"2":cart,Fixture.Token));Assert.That(result, Is.Not.Null);return;}
            var resultOrder=await owner.PlaceOrderAsync(new(){AddressId="2",CheckoutReference="ref",IdempotencyKey="key",PaymentMethod=S(d,"PaymentMethod")=="VietQr"?PaymentMethod.VietQr:PaymentMethod.Cod},Fixture.Token);
            Assert.That(resultOrder.OrderId, Is.EqualTo("42"));Assert.That(resultOrder.Total, Is.EqualTo("30000"));Assert.That(saves, Is.EqualTo(replay?0:1));Assert.That(clears, Is.EqualTo(saves));Assert.That(completes, Is.EqualTo(saves));Assert.That(notices, Is.EqualTo(saves));
        }
        if(name=="CreatePaymentQrAsync")await Fixture.Error("PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD",Action);else if(fail)await TestChecks.ThrowsAsync<TimeoutException>(Action);else if(S(c,"exception").Length>0)await Fixture.Error(S(c,"exception"),Action);else if(name=="HandleVerifiedPaymentAsync")await Fixture.Error("PAYMENT_CORRELATION_AND_LATE_PAYMENT_POLICY_TBD",Action);else await Action();
    }
}
