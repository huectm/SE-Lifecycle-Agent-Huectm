using System.Reflection;
using System.Text.Json;
using FreshFood.Api;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FreshFood.Api.Tests;

public sealed class DesignMappingTests
{
    private static readonly JsonSerializerOptions MappingJsonOptions = new() { WriteIndented = true };
    [Fact]
    public void AllBackendClassifiersMapToCompiledCSharpOrFrameworkSymbols()
    {
        var root=Root();
        using var model=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"artifacts/design/detailed/detailed-class-model.json")));
        using var mapping=JsonDocument.Parse(File.ReadAllText(Path.Combine(root,"artifacts/design/detailed/pim-to-code-mapping.json")));
        var classAliases=mapping.RootElement.GetProperty("class_aliases").EnumerateObject().ToDictionary(p=>p.Value.GetString()!,p=>p.Name);
        var types=typeof(ApiCompositionRoot).Assembly.GetTypes().Concat(typeof(Order).Assembly.GetTypes()).ToArray();
        var platform=new Dictionary<string,string>{["EntityId"]="System.String",["LocalDate"]="System.DateOnly",["VndAmountString"]="System.String",["IsoDateTime"]="System.DateTimeOffset",
            ["AuthenticatedPrincipal"]="System.Security.Claims.ClaimsPrincipal",["DatabaseConnection"]="Npgsql.NpgsqlDataSource",["DatabaseTransaction"]="Npgsql.NpgsqlTransaction",
            ["RegistrationMap"]="Microsoft.Extensions.DependencyInjection.IServiceCollection",["HttpTransport"]="System.Net.Http.HttpClient",["TransactionWork"]="System.Func<CancellationToken,Task>"};
        var rows=new List<object>();var missing=new List<string>();
        foreach(var entry in model.RootElement.GetProperty("classes").EnumerateObject())
        {
            var package=entry.Value.GetProperty("package").GetString()!;
            if(!package.StartsWith("FreshFood-API",StringComparison.Ordinal)&&!package.StartsWith("FreshFood.Reposistory",StringComparison.Ordinal))continue;
            var sourceName=classAliases.GetValueOrDefault(entry.Name,entry.Name);
            var type=types.SingleOrDefault(t=>t.IsPublic&&t.Name==sourceName);
            if(type is null)
            {
                if(!platform.TryGetValue(entry.Name,out var symbol)){missing.Add(entry.Name);continue;}
                rows.Add(new{Name=entry.Name,Symbol=symbol,Kind="Framework or type alias",Operations=Array.Empty<string>()});continue;
            }
            var ops=type.GetConstructors().Select(c=>"+ "+entry.Name+"("+Parameters(c.GetParameters())+")")
                .Concat(type.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly).Where(m=>!m.IsSpecialName)
                    .Select(m=>"+ "+m.Name+"("+Parameters(m.GetParameters())+"): "+Name(m.ReturnType))).ToArray();
            rows.Add(new{Name=entry.Name,Symbol=type.FullName!,Kind="Compiled C#",Operations=ops});
        }
        Assert.Empty(missing);
        File.WriteAllText(Path.Combine(root,"artifacts/implementation/dotnet-compiled-design-mapping.json"),JsonSerializer.Serialize(rows,MappingJsonOptions));
    }
    [Fact]
    public async Task BackendCompositionResolvesScopedServicesAndStateMachines()
    {
        var services=new ServiceCollection();services.AddLogging();
        var configuration=new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string,string?>{["ConnectionStrings:FreshFood"]="Host=localhost;Database=not_opened;Username=test"}).Build();
        ApiCompositionRoot.ConfigureServices(services,configuration);
        await using var provider=services.BuildServiceProvider(new ServiceProviderOptions{ValidateScopes=true,ValidateOnBuild=true});
        await using var first=provider.CreateAsyncScope();await using var second=provider.CreateAsyncScope();
        foreach(var contract in new[]{typeof(FreshFood.Api.Services.ICatalogService),typeof(FreshFood.Api.Services.ICartService),typeof(FreshFood.Api.Services.IProfileService),typeof(FreshFood.Api.Services.ICheckoutService),typeof(FreshFood.Api.Services.IMyOrdersService)})
            Assert.NotNull(first.ServiceProvider.GetRequiredService(contract));
        Assert.NotSame(first.ServiceProvider.GetRequiredService<FreshFood.Api.Services.IOrderStateMachine>(),second.ServiceProvider.GetRequiredService<FreshFood.Api.Services.IOrderStateMachine>());
    }
    private static string Parameters(ParameterInfo[] args)=>string.Join(", ",args.Select(p=>p.Name+": "+Name(p.ParameterType)));
    private static string Name(Type type)
    {
        if(type.IsGenericType)
        {
            if(type.GetGenericTypeDefinition()==typeof(Nullable<>))return Name(type.GenericTypeArguments[0])+"?";
            return type.Name.Split('`')[0]+"<"+string.Join(", ",type.GenericTypeArguments.Select(Name))+">";
        }
        return type==typeof(void)?"void":type==typeof(string)?"string":type==typeof(bool)?"bool":type==typeof(int)?"int":type==typeof(decimal)?"decimal":type.Name;
    }
    private static string Root()
    {
        var p=new DirectoryInfo(AppContext.BaseDirectory);while(p is not null&&!File.Exists(Path.Combine(p.FullName,"AGENTS.md")))p=p.Parent;
        return p?.FullName??throw new InvalidOperationException("Workspace not found.");
    }
}
