using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using FreshFood.Api;
using FreshFood.Api.Controllers;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using NUnit.Framework;

namespace FreshFood.Backend.UnitTests;
internal static partial class CaseRunner
{
    private static void Json(JsonElement c)
    {
        var d=c.GetProperty("data");if(Has(d,"DTO")){var t=typeof(PlaceOrderDto).Assembly.GetType("FreshFood.Api.DTOs."+S(d,"DTO"))!;TestChecks.Throws<JsonException>(()=>JsonSerializer.Deserialize(S(d,"JSON"),t,ApiJson.Options));}
        else {Assert.That(JsonSerializer.Serialize(OrderStatus.PendingPaid,ApiJson.Options), Does.Contain("PendingPaid"));TestChecks.Throws<JsonException>(()=>JsonSerializer.Deserialize<PaymentMethod>("0",ApiJson.Options));}
    }
    private static async Task Composition(JsonElement c)
    {
        var services=new ServiceCollection();var configuration=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>{{"ConnectionStrings:FreshFood","Host=localhost;Database=unused;Username=unused"}}).Build();
        services.AddLogging();ApiCompositionRoot.ConfigureServices(services,configuration);await using var provider=services.BuildServiceProvider();await using var scope=provider.CreateAsyncScope();
        TestChecks.IsType<CheckoutService>(scope.ServiceProvider.GetRequiredService<FreshFood.Api.Services.ICheckoutService>());TestChecks.IsType<BatchPricingPolicy>(provider.GetRequiredService<IBatchPricingPolicy>());
    }
    private static async Task Binder(JsonElement c)
    {
        var d=c.GetProperty("data");var raw=S(d,"RawBody",S(d,"body","{ \"amount\" : 100 }\n"));var http=new DefaultHttpContext();http.Request.Body=new MemoryStream(Encoding.UTF8.GetBytes(raw));http.Request.Headers.Authorization="Apikey signature";http.Request.Headers["X-Provider-Reference"]="provider";
        var metadata=new EmptyModelMetadataProvider().GetMetadataForType(typeof(PaymentNoticeDto));var binding=DefaultModelBindingContext.CreateBindingContext(new ActionContext{HttpContext=http},new CompositeValueProvider(),metadata,null,"notice");
        await new PaymentNoticeModelBinder().BindModelAsync(binding);var notice=TestChecks.IsType<PaymentNoticeDto>(binding.Result.Model);Assert.That(notice.RawBody, Is.EqualTo(raw));Assert.That(notice.Signature, Is.EqualTo("Apikey signature"));Assert.That(notice.ProviderReference, Is.EqualTo("provider"));Assert.That(http.Request.Body.CanRead, Is.True);
    }
    private static void Identity(JsonElement c,string name)
    {
        var d=c.GetProperty("data");var context=new DefaultHttpContext();var protection=new EphemeralDataProtectionProvider();var owner=new CurrentCustomer(new HttpContextAccessor{HttpContext=context},protection);
        if(name=="RequireCustomerId"){
            if(S(d,"Authenticated")=="False"){context.Request.Headers["X-Customer-Id"]="7";Assert.That(TestChecks.Throws<DomainException>(()=>owner.RequireCustomerId()).Code, Is.EqualTo("AUTHENTICATION_REQUIRED"));}
            else{context.User=new ClaimsPrincipal(new ClaimsIdentity([new Claim("customer_id","7")],"unit"));Assert.That(owner.RequireCustomerId(), Is.EqualTo("7"));}
        }else{
            var existing=S(d,"Cookie").StartsWith("protect",StringComparison.Ordinal);if(Has(d,"Cookie"))context.Request.Headers.Cookie="FreshFood.GuestCart="+(existing?protection.CreateProtector("FreshFood.GuestCart.v1").Protect("existing-session"):"invalid-token");
            var identity=owner.GetCartIdentity();Assert.That(identity.CustomerId, Is.Null);Assert.That(string.IsNullOrEmpty(identity.SessionId), Is.False);
            if(existing){Assert.That(identity.SessionId, Is.EqualTo("existing-session"));Assert.That(context.Response.Headers.SetCookie.Count, Is.EqualTo(0));}else{var cookie=context.Response.Headers.SetCookie.ToString();Assert.That(cookie, Does.Contain("httponly").IgnoreCase);Assert.That(cookie, Does.Contain("secure").IgnoreCase);Assert.That(cookie, Does.Contain("samesite=strict").IgnoreCase);}
        }
    }
    private sealed class ProbeRepository(IRepositorySession session):SqlRepository(session) { }
    private static async Task Repository(JsonElement m,JsonElement c)
    {
        var d=c.GetProperty("data");var type=TypeOf(m);var name=S(m,"name");var fail=Has(d,"failure");var queries=new List<(string Sql,object?[] Args)>();
        var deferred=new Dictionary<string,string>{["LoadLifecycleAsync"]="TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD",["SaveOrderLinesAsync"]="SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW",["SavePaymentOnceAsync"]="PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED",["SaveFailureAsync"]="STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT",["SaveReceiptAsync"]="STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT",["SaveRefundOnceAsync"]="REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED",["SaveShippingSettlementAsync"]="SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"};
        var boundary=Has(d,"boundary");
        var session=(IRepositorySession)StrictProxy.Create(typeof(IRepositorySession),(mi,a)=>{
            if(mi.Name=="get_Active")return true;
            if(mi.Name!="QueryAsync")throw new InvalidOperationException(mi.Name);
            Assert.That(a[2], Is.EqualTo(Fixture.Token));var sql=(string)a[0]!;var args=(object?[])a[1]!;queries.Add((sql,args));if(fail)throw new TimeoutException("SQL sentinel");
            var rowType=mi.GetGenericArguments()[0];var list=(System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(rowType))!;
            var createRow=boundary && (sql.StartsWith("INSERT INTO carts",StringComparison.Ordinal)||sql.StartsWith("INSERT INTO orders",StringComparison.Ordinal));
            if(!Has(d,"boundary")||createRow){
                var row=Fixture.Value(rowType)!;
                if(row is Cart cart){cart.CartId="1";cart.CustomerId="7";}
                if(row is Order order){order.OrderId="1";order.CustomerId="7";order.DeliveryAddressId="2";}
                if(rowType.Name=="ClaimRow"){
                    rowType.GetProperty("IdempotencyKey")!.SetValue(row,S(d,"key","Sample"));
                    rowType.GetProperty("RequestHash")!.SetValue(row,S(d,"requestHash",new string('a',64)));
                    rowType.GetProperty("CheckoutReference")!.SetValue(row,S(d,"reference","Sample"));
                    rowType.GetProperty("Response")!.SetValue(row,null);
                }
                list.Add(row);
            }
            return typeof(Task).GetMethod(nameof(Task.FromResult))!.MakeGenericMethod(list.GetType()).Invoke(null,[list]);
        });
        object owner=type==typeof(SqlRepository)?new ProbeRepository(session):type==typeof(CheckoutRepository)?new CheckoutRepository(session,new FefoBatchSpecification()):Activator.CreateInstance(type,session)!;
        var method=type.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static).First(x=>x.Name==name&&x.GetParameters().Length==m.GetProperty("parameters").GetArrayLength());
        if(method.IsGenericMethodDefinition)method=method.MakeGenericMethod(name=="Encode"?typeof(OrderStatus):typeof(Cart));
        var args=method.GetParameters().Select(p=>{
            if(p.ParameterType==typeof(string))return (object?)S(d,p.Name!,p.Name?.Contains("code",StringComparison.Ordinal)==true?"POLICY_TBD":"1");
            if(p.ParameterType==typeof(List<string>))return new List<string>{"1"};
            if(p.ParameterType==typeof(List<BatchInventory>))return boundary?new List<BatchInventory>():new List<BatchInventory>{Fixture.Batch()};
            if(p.ParameterType==typeof(List<OrderDetail>))return new List<OrderDetail>{new(){BatchId="1",ProductId="1",Quantity=2}};
            if(p.ParameterType==typeof(CancellationToken))return Fixture.Token;
            if(p.ParameterType==typeof(Cart))return new Cart{CartId="1",CustomerId="7",Items=[new(){ProductId="1",Quantity=2}]};
            if(p.ParameterType==typeof(Order))return new Order{OrderId="1",CustomerId="7",DeliveryAddressId="2"};
            if(p.ParameterType==typeof(object[]))return Array.Empty<object>();
            if(p.ParameterType==typeof(object))return new { OrderId="1" };
            if(p.ParameterType==typeof(AuditLog))return new AuditLog{CustomerId="7",RecordIdentifier="1",OldValues="{}",NewValues="{}"};
            return Fixture.Value(p.ParameterType);
        }).ToArray();
        if(type==typeof(SqlRepository)&&name is "Id" or "OptionalId"){
            var expected=S(c,"exception");if(expected.Length>0)Assert.That(TestChecks.Throws<DomainException>(()=>Fixture.Invoke(method,null,args)).Code, Is.EqualTo(expected));else {var result=Fixture.Invoke(method,null,args);Assert.That(result, Is.EqualTo(long.Parse(S(d,"value","1"))));}return;
        }
        if(name is "Gap"){await Fixture.Error(S(d,"code","POLICY_TBD"),()=>Fixture.Await(Fixture.Invoke(method,null,args)));return;}
        async Task Action(){
            var result=await Fixture.Await(Fixture.Invoke(method,owner,args));
            if(name=="get_Lock")Assert.That(result, Is.EqualTo(" FOR UPDATE"));
            else if(name=="Encode")Assert.That(result, Is.EqualTo("PENDING_UNPAID"));
            else if(name=="RequireTransaction")Assert.That(queries, Is.Empty);
            else if(name=="SaveBatchesAsync" && boundary)Assert.That(queries, Is.Empty);
            else {
                Assert.That(queries, Is.Not.Empty);
                if(method.ReturnType.IsGenericType && !boundary)Assert.That(result, Is.Not.Null);
                if(result is System.Collections.IList list)Assert.That(list.Count, Is.EqualTo(boundary?0:1));
                if(result is bool b)Assert.That(b, Is.EqualTo(!boundary));
            }
        }
        if(deferred.TryGetValue(name,out var gapCode)){await Fixture.Error(gapCode,Action);Assert.That(queries, Is.Empty);}
        else if(fail)await TestChecks.ThrowsAsync<TimeoutException>(Action);
        else if(boundary && name is "GetCustomerAsync" or "LockOrderAsync" or "LockOwnedAsync" or "GetOwnedAddressAsync" or "SaveAddressAsync")await Fixture.Error("NOT_FOUND",Action);
        else if(boundary && name=="AppendAuditAsync")await Fixture.Error("AUDIT_ORDER_NOT_OWNED",Action);
        else if(boundary && name=="CompleteCheckoutAsync")await Fixture.Error("IDEMPOTENCY_COMPLETION_CONFLICT",Action);
        else if(boundary && name=="ClaimCheckoutAsync")await Fixture.Error("CHECKOUT_REFERENCE_REUSED",Action);
        else if(boundary && name is "LoadCart" or "GetAsync" or "SaveCartAsync" or "SaveOrderAsync"){
            // These boundary paths need a created-row identity or write return row;
            // a zero-row fake is not a valid completed creation fixture.
            await Action();
        }
        else await Action();
        foreach(var query in queries){Assert.That(query.Sql, Does.Not.Contain("Sample"));Assert.That(query.Sql, Does.Not.Contain("tester@example.com"));}
    }
}
