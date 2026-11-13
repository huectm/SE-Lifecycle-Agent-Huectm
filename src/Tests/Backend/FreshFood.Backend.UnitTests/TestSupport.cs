using System.Reflection;
using System.Text.Json;
using FreshFood.Api.DTOs;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using NUnit.Framework;

[assembly: LevelOfParallelism(1)]
[assembly: NonParallelizable]
namespace FreshFood.Backend.UnitTests;

public class StrictProxy : DispatchProxy
{
    public Func<MethodInfo, object?[], object?> Handler = null!;
    protected override object? Invoke(MethodInfo? method, object?[]? args) => Handler(method!, args ?? []);
    public static object Create(Type type, Func<MethodInfo, object?[], object?> handler)
    { var proxy = Create(type, typeof(StrictProxy)); ((StrictProxy)proxy).Handler = handler; return proxy; }
    public static T For<T>(Func<string, object?[], object?> handler) where T : class =>
        (T)Create(typeof(T), (m, a) => handler(m.Name, a));
}
public sealed class ImmediateWork : IUnitOfWork
{
    public int Calls;
    public async Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken ct) { Calls++; await action(ct); }
    public async Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken ct) { Calls++; return await action(ct); }
}
internal static class Fixture
{
    internal static FreshFood.Api.DTOs.TransitionSnapshot TransitionContext(Order order, bool initial = true, bool paid = false) => TransitionContext(order, [Batch()], initial, paid);
    internal static FreshFood.Api.DTOs.TransitionSnapshot TransitionContext(Order order, List<BatchInventory> batches, bool initial, bool paid)
    {
        var ctor = typeof(FreshFood.Api.DTOs.TransitionSnapshot).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Single();
        var context = (FreshFood.Api.DTOs.TransitionSnapshot)ctor.Invoke(["checkout:7:ref", "7", order, batches, initial]);
        typeof(FreshFood.Api.DTOs.TransitionSnapshot).GetProperty("VerifiedPayment", BindingFlags.NonPublic | BindingFlags.Instance)!.SetValue(context, paid);
        return context;
    }
    internal static readonly CancellationToken Token = new CancellationTokenSource().Token;
    internal static BatchInventory Batch(int stock = 10, int reserved = 3) => new() { BatchId="1",ProductId="1",CurrentStock=stock,ReservedStock=reserved,SaleStatus="ACTIVE",ExpiryDate=new(2099,1,1),RetailPrice=new(10000) };
    internal static CustomerAddress Address() => new() { AddressId="2",CustomerId="7",RecipientName="Tester",RecipientPhone="123456789",StreetAddress="Test street",Latitude=10,Longitude=105 };
    internal static FreshFood.Api.Services.ICurrentCustomer Customer() => StrictProxy.For<FreshFood.Api.Services.ICurrentCustomer>((n,a)=>n=="RequireCustomerId"?"7":new CartIdentityDto { CustomerId="7" });
    internal static object? Value(Type t)
    {
        if(t==typeof(string))return "1";
        if(t==typeof(CancellationToken))return Token;
        if(t==typeof(VndAmount))return new VndAmount(10000);
        if(t==typeof(DateTimeOffset))return new DateTimeOffset(2099,1,1,0,0,0,TimeSpan.Zero);
        if(t==typeof(DateOnly))return new DateOnly(2099,1,1);
        if(t.IsInterface)return StrictProxy.Create(t,(m,a)=>throw new InvalidOperationException("Unexpected collaborator: "+m.Name));
        if(t.IsValueType)return Activator.CreateInstance(t);
        if(t.IsGenericType && t.GetGenericTypeDefinition()==typeof(Microsoft.Extensions.Logging.ILogger<>))return typeof(Microsoft.Extensions.Logging.Abstractions.NullLogger<>).MakeGenericType(t.GenericTypeArguments).GetProperty("Instance")!.GetValue(null);
        var constructor=t.GetConstructors(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance).OrderBy(x=>x.GetParameters().Length).FirstOrDefault();
        var value=constructor is null?Activator.CreateInstance(t):constructor.Invoke(constructor.GetParameters().Select(p=>Value(p.ParameterType)).ToArray());
        foreach(var p in t.GetProperties().Where(p=>p.CanWrite && p.PropertyType==typeof(string)))p.SetValue(value,p.Name=="Email"?"tester@example.com":p.Name.Contains("Phone")?"123456789":p.Name.Contains("Name")?"Tester":p.Name=="Reason"?"Changed mind":"1");
        if(value is CartChangeDto cart)cart.Quantity=2;
        if(value is OrderReviewDto review)review.Rating=5;
        return value;
    }
    internal static async Task<object?> Await(object? value)
    { if(value is not Task task)return value;await task;return task.GetType().GetProperty("Result")?.GetValue(task); }
    internal static object? Invoke(MethodInfo m,object? owner,params object?[] args)
    { try{return m.Invoke(owner,args);}catch(TargetInvocationException e) when(e.InnerException is not null){System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(e.InnerException).Throw();throw;} }
    internal static async Task Error(string code,Func<Task> action)
    { var e=await TestChecks.ThrowsAsync<FreshFood.Reposistory.Repository.Implements.DomainException>(action);Assert.That(e.Code, Is.EqualTo(code.Split(' ')[0])); }
}

internal sealed class ProbeRepository(IRepositorySession session) : FreshFood.Reposistory.Repository.Implements.SqlRepository(session) { }

// Data conversion only. No business-method dispatch or assertions live here.
internal static class ScenarioValues
{
    internal static string S(JsonElement data, string key, string fallback = "") => data.TryGetProperty(key, out var value) && value.ValueKind != JsonValueKind.Null ? value.ToString() : fallback;
    internal static decimal N(JsonElement data, string key, decimal fallback = 0) => decimal.Parse(S(data, key, fallback.ToString(System.Globalization.CultureInfo.InvariantCulture)), System.Globalization.CultureInfo.InvariantCulture);
    internal static bool Has(JsonElement data, string key) => data.TryGetProperty(key, out _);
}
