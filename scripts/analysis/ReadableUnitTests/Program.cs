using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

var root=Path.GetFullPath(args.Length>0?args[0]:"src/Tests/Backend/FreshFood.Backend.UnitTests");
var templates=Directory.GetFiles("scripts/analysis/readable-unit-templates","*.txt").Select(p=>CSharpSyntaxTree.ParseText(File.ReadAllText(p)).GetCompilationUnitRoot()).ToList();
var helpers=templates.SelectMany(t=>t.DescendantNodes().OfType<MethodDeclarationSyntax>()).GroupBy(m=>m.Identifier.Text).ToDictionary(g=>g.Key,g=>g.First());
using var design=JsonDocument.Parse(File.ReadAllText("artifacts/testing/test-design/backend-unit/backend-unit-test-design.json"));
using var resolved=JsonDocument.Parse(File.ReadAllText("artifacts/testing/test-design/backend-unit/materialized-vectors.json"));
var methods=design.RootElement.GetProperty("methods").EnumerateArray().ToArray();
var cases=methods.SelectMany(m=>m.GetProperty("cases").EnumerateArray().Select(c=>(Id:c.GetProperty("id").GetString()!,Method:m,Case:c))).ToDictionary(x=>x.Id);
var imports=templates.SelectMany(t=>t.Usings).Select(u=>u.WithoutTrivia().ToString()).Append("using static FreshFood.Backend.UnitTests.ScenarioValues;").Distinct().Select(s=>ParseCompilationUnit(s).Usings[0]).ToArray();
int total=0;
foreach(var file in Directory.GetFiles(root,"*Tests.cs"))
{
 var tree=CSharpSyntaxTree.ParseText(File.ReadAllText(file)).GetCompilationUnitRoot();
 var replacements=new Dictionary<MethodDeclarationSyntax,MethodDeclarationSyntax>();
 foreach(var test in tree.DescendantNodes().OfType<MethodDeclarationSyntax>().Where(t=>t.ExpressionBody is not null))
 {
  var idMatch=System.Text.RegularExpressions.Regex.Match(test.Identifier.Text,@"UTM_(\d+)_TC(\d+)");
  BlockSyntax body;
  if(!idMatch.Success)
  {
   body=(BlockSyntax)new Expansion(null,null,"PaymentGuardSafety").Visit(helpers["PaymentGuardSafety"].Body)!;
  }
  else
  {
   var id="UTM-"+idMatch.Groups[1].Value+"-TC"+idMatch.Groups[2].Value;var entry=cases[id];var m=entry.Method;var c=entry.Case;
   var ignored=test.AttributeLists.SelectMany(a=>a.Attributes).FirstOrDefault(a=>a.Name.ToString().EndsWith("Ignore"));
   if(ignored is not null)
   {
    body=Block(ParseStatement("// Not executed: the documented design constraint must be resolved before arranging a real invocation.\nAssert.Ignore("+ignored.ArgumentList!.Arguments[0].Expression+");"));
   }
   else
   {
    if(resolved.RootElement.TryGetProperty(id,out var concrete))
    {
     var node=System.Text.Json.Nodes.JsonNode.Parse(c.GetRawText())!;node["data"]=System.Text.Json.Nodes.JsonNode.Parse(concrete.GetProperty("data").GetRawText());node["exception"]=concrete.GetProperty("exception").GetString();c=JsonSerializer.SerializeToElement(node);
    }
    var type=m.GetProperty("type").GetString()!;var name=m.GetProperty("name").GetString()!;
    if(name==".ctor" && type!="VndAmount")body=Emit.Constructor(m);
    else if(type.EndsWith("Controller") || type is "DistanceCalculator" or "NotificationAdapter" or "PaymentNoticeHandler")body=Emit.Forward(m,c,methods);
    else if(type.EndsWith("Repository") && m.GetProperty("accessibility").GetString()=="Public" && !name.StartsWith("get_"))body=RepositoryEmission.Create(m,c);
    else if(type is "DeliveryFeePolicy" or "BatchPricingPolicy" or "BatchInventory" or "Cart" or "Order" or "VndAmount" or "VndAmountConverter" or "FefoBatchSpecification")body=DomainEmission.Create(m,c);
    else if(type is "GoogleMapsGeocodingAdapter" or "GoogleMapsDistanceAdapter" or "SePayPaymentAdapter" or "ConfiguredNotificationPublisher" or "UnconfiguredPayoutAdapter")body=DomainEmission.FailClosed(m);
    else
    {
     var helper=type switch{
      "GoogleMapsGeocodingAdapter" or "GoogleMapsDistanceAdapter" or "SePayPaymentAdapter" or "ConfiguredNotificationPublisher" or "UnconfiguredPayoutAdapter"=>"FailClosed",
      "DeliveryFeePolicy" or "BatchPricingPolicy" or "BatchInventory" or "Cart" or "Order" or "VndAmount" or "VndAmountConverter" or "FefoBatchSpecification" or "ServiceRules"=>"Domain",
      "UnitOfWork"=>"Transaction","ApiJson"=>"Json","ApiCompositionRoot"=>"Composition","PaymentNoticeModelBinder"=>"Binder","CurrentCustomer"=>"Identity",
      "CheckoutService"=>"Checkout","OrderStateMachine"=>"Machine","ProfileService"=>"Profile","CatalogService"=>"Catalog","CartService"=>"CartServiceCase","MyOrdersService"=>"MyOrders",_=>"Repository"};
     body=helpers[helper].Body!;
     for(var pass=0;pass<4;pass++)body=(BlockSyntax)new Expansion(m,c,helper).Visit(body)!;
     body=Cleanup.RemoveDataLocals(body);
     // Keep any remaining data-dependent setup local and visible, never dispatched by case ID.
     var ids=body.DescendantNodes().OfType<IdentifierNameSyntax>().Select(i=>i.Identifier.Text).ToHashSet();
     var prefix=new List<StatementSyntax>();
     if(ids.Contains("m"))prefix.Add(ParseStatement("var m = JsonSerializer.Deserialize<JsonElement>("+Emit.String(JsonSerializer.Serialize(new {name=m.GetProperty("name").GetString(),fullType=m.GetProperty("fullType").GetString(),parameters=m.GetProperty("parameters")}))+");"));
     if(ids.Contains("c"))prefix.Add(ParseStatement("var c = JsonSerializer.Deserialize<JsonElement>("+Emit.String(JsonSerializer.Serialize(new {data=c.GetProperty("data"),exception=c.GetProperty("exception")}))+");"));
     body=body.WithStatements(List(prefix.Concat(body.Statements)));
    }
   }
  }
  body=body.RemoveNodes(body.DescendantNodes().OfType<ExpressionStatementSyntax>().Where(s=>s.Expression is AwaitExpressionSyntax a&&a.Expression.ToString()=="Task.CompletedTask"),SyntaxRemoveOptions.KeepNoTrivia)!;
  var mainNodes=body.DescendantNodes(n=>n is not AnonymousFunctionExpressionSyntax && n is not LocalFunctionStatementSyntax).ToArray();
  var needsAsync=mainNodes.OfType<AwaitExpressionSyntax>().Any() ||mainNodes.OfType<LocalDeclarationStatementSyntax>().Any(n=>n.AwaitKeyword.IsKind(SyntaxKind.AwaitKeyword));
  body=body.WithOpenBraceToken(Token(SyntaxKind.OpenBraceToken));
  if(body.Statements.Count>0)body=body.ReplaceNode(body.Statements[0],body.Statements[0].WithLeadingTrivia(ParseLeadingTrivia("// Arrange: test inputs and mock setup.\n").AddRange(body.Statements[0].GetLeadingTrivia())));
  replacements[test]=test.WithExpressionBody(null).WithSemicolonToken(default).WithBody(body).WithReturnType(ParseTypeName(needsAsync?"System.Threading.Tasks.Task":"void")).WithModifiers(needsAsync?TokenList(Token(SyntaxKind.PublicKeyword),Token(SyntaxKind.AsyncKeyword)):TokenList(Token(SyntaxKind.PublicKeyword)));
  total++;
 }
 tree=tree.ReplaceNodes(replacements.Keys,(old,_)=>replacements[old]).WithUsings(List(imports));
 File.WriteAllText(file,tree.NormalizeWhitespace(indentation:"    ",eol:"\n").ToFullString().Replace("Generated stable case entry points; assertions live in the reviewed execution helpers.","Generated explicit NUnit tests. Shared helpers only prepare reusable fixtures and mocks.")+"\n");
}
Console.WriteLine($"Expanded {total} readable NUnit test methods; business calls and assertions are local.");

static class Emit
{
 internal static string String(string? value)=>Literal(value??"").ToFullString();
 internal static string Type(JsonElement parameter)=>parameter.GetProperty("type").GetString()!;
 internal static BlockSyntax Constructor(JsonElement m)
 {
  var type=m.GetProperty("fullType").GetString()!;var pars=m.GetProperty("parameters").EnumerateArray().ToArray();var lines=new List<string>();
  foreach(var p in pars)lines.Add($"var {p.GetProperty("name").GetString()} = ({Type(p)})Fixture.Value(typeof({Type(p).TrimEnd('?')}))!;");
  var args=string.Join(", ",pars.Select(p=>p.GetProperty("name").GetString()));
  if(m.GetProperty("accessibility").GetString()=="Public")lines.Add($"// Act\nvar actual = new {type}({args});");
  else lines.Add($"// Act: the constructor is internal, so production visibility is preserved.\nvar constructor = typeof({type}).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Single();\nvar actual = constructor.Invoke(new object?[] {{ {args} }});");
  lines.Add($"// Assert\nAssert.That(actual, Is.TypeOf<{type}>());");
  return ParseStatement("{"+string.Join("\n",lines)+"}") as BlockSyntax ?? throw new Exception();
 }
 internal static BlockSyntax Forward(JsonElement m,JsonElement c,JsonElement[] methods)
 {
  var full=m.GetProperty("fullType").GetString()!;var name=m.GetProperty("name").GetString()!;var data=c.GetProperty("data");var fail=data.TryGetProperty("failure",out _);var pars=m.GetProperty("parameters").EnumerateArray().ToArray();
  var ctor=methods.First(x=>x.GetProperty("fullType").GetString()==full && x.GetProperty("name").GetString()==".ctor");
  var port=ctor.GetProperty("parameters")[0].GetProperty("type").GetString()!;var webhook=full.EndsWith("PaymentWebhookController");if(webhook)port="FreshFood.Api.Services.ICheckoutService";
  var returns=m.GetProperty("returns").GetString()!;var inner=returns.Contains('<')?returns[(returns.IndexOf('<')+1)..^1]:null;
  var lines=new List<string>();
  foreach(var p in pars){var t=Type(p);var n=p.GetProperty("name").GetString()!;lines.Add(t.Contains("CancellationToken")?$"var {n} = Fixture.Token;":$"var {n} = ({t})Fixture.Value(typeof({t}))!;");}
  if(data.TryGetProperty("routeId",out _))foreach(var p in pars){var t=Type(p);var field=t.EndsWith("CartChangeDto")?"ProductId":t.EndsWith("CancelOrderDto")||t.EndsWith("OrderReviewDto")?"OrderId":t.EndsWith("AddressInputDto")?"AddressId":null;if(field is not null)lines.Add($"{p.GetProperty("name").GetString()}.{field} = \"99\";");}
  if(inner is not null)lines.Add($"var expectedResult = ({inner})Fixture.Value(typeof({inner}))!;");
  if(fail)lines.Add("var expectedException = new TimeoutException(\"arranged collaborator failure\");");
  lines.Add("object?[]? actualArguments = null; string? actualMethod = null; var actualCallCount = 0;");
  lines.Add($"var collaborator = StrictProxy.For<{port}>((calledMethod, arguments) => {{ actualCallCount++; actualMethod = calledMethod; actualArguments = arguments; "+(fail?"throw expectedException;":inner is null?"return Task.CompletedTask;":"return Task.FromResult(expectedResult);")+" });");
  lines.Add($"var subject = new {full}("+(webhook?"new PaymentNoticeHandler(collaborator)":"collaborator")+");");
  var call=$"subject.{name}("+string.Join(", ",pars.Select(p=>p.GetProperty("name").GetString()))+")";
  if(fail)lines.Add($"// Act\nvar actualException = Assert.ThrowsAsync<TimeoutException>(async () => await {call})!;\n// Assert\nAssert.That(actualException, Is.SameAs(expectedException));");
  else if(inner is null)lines.Add($"// Act\nawait {call};\n// Assert: successful Task completion and the captured call are the output contract.");
  else lines.Add($"// Act\nvar actualResult = await {call};\n// Assert\nAssert.That(actualResult, "+(inner is "decimal" or "bool" or "int"?"Is.EqualTo":"Is.SameAs")+"(expectedResult));");
  var expectedMethod=name=="UpdateAddressAsync"?"SaveAddressAsync":webhook||full.EndsWith("PaymentNoticeHandler")?"HandleVerifiedPaymentAsync":full.EndsWith("DistanceCalculator")?"DrivingDistanceAsync":full.EndsWith("NotificationAdapter")?"SendAsync":name;
  lines.Add($"Assert.That(actualCallCount, Is.EqualTo(1)); Assert.That(actualMethod, Is.EqualTo({String(expectedMethod)})); Assert.That(actualArguments![^1], Is.EqualTo(Fixture.Token));");
  foreach(var p in pars)
  {
   var t=Type(p);var n=p.GetProperty("name").GetString()!;if(t.Contains("CancellationToken"))continue;
   if(t.EndsWith("CartChangeDto"))lines.Add($"var actualRequest = (CartChangeDto)actualArguments![0]!; Assert.That(actualRequest.ProductId, Is.EqualTo(productId)); Assert.That(actualRequest.Quantity, Is.EqualTo({n}.Quantity));");
   else if(t is "string" or "string?" or "System.String") {if(pars.Length<=2)lines.Add($"Assert.That(actualArguments, Does.Contain({n}));");}
   else lines.Add($"Assert.That(actualArguments, Does.Contain({n}));");
  }
  if(name is "CancelOrderAsync" or "SubmitReviewAsync")lines.Add($"Assert.That(request.OrderId, Is.EqualTo(orderId));");
  if(name=="UpdateAddressAsync")lines.Add("Assert.That(request.AddressId, Is.EqualTo(addressId));");
  return (BlockSyntax)ParseStatement("{"+string.Join("\n",lines)+"}");
 }
}
