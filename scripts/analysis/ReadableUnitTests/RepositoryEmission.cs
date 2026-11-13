using System.Text.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

static partial class RepositoryEmission
{
 internal static BlockSyntax Create(JsonElement m,JsonElement c)
 {
  var d=c.GetProperty("data");var name=m.GetProperty("name").GetString()!;var type=m.GetProperty("fullType").GetString()!;
  string S(string key,string fallback="1")=>d.TryGetProperty(key,out var value)&&value.ValueKind!=JsonValueKind.Null?value.ToString():fallback;
  var empty=d.TryGetProperty("boundary",out _);var fail=d.TryGetProperty("failure",out _);
  var lines=new List<string>{"// Arrange"};
  if(fail)lines.Add("var expectedException = new TimeoutException(\"SQL sentinel\");");
  lines.Add("var database = new RepositorySessionFixture(emptyRows: "+(empty?"true":"false")+", queryError: "+(fail?"expectedException":"null")+(name=="ClaimCheckoutAsync"?", key: "+Emit.String(S("key","Sample"))+", reference: "+Emit.String(S("reference","Sample"))+", requestHash: "+Emit.String(S("requestHash",new string('a',64))):"")+");");
  foreach(var p in m.GetProperty("parameters").EnumerateArray()){
   var t=p.GetProperty("type").GetString()!;var n=p.GetProperty("name").GetString()!;
   var value=t switch {
    "string" or "string?" or "System.String" or "System.String?"=>Emit.String(S(n,n.Contains("code")?"POLICY_TBD":"1")),
    "System.Collections.Generic.List<string>"=>"new List<string> { \"1\" }",
    "System.Collections.Generic.List<FreshFood.Reposistory.Entities.BatchInventory>"=>empty?"new List<BatchInventory>()":"new List<BatchInventory> { Fixture.Batch() }",
    "System.Collections.Generic.List<FreshFood.Reposistory.Entities.OrderDetail>"=>"new List<OrderDetail> { new() { BatchId = \"1\", ProductId = \"1\", Quantity = 2 } }",
    "System.Threading.CancellationToken"=>"Fixture.Token",
    "FreshFood.Reposistory.Entities.Cart"=>"new Cart { CartId = \"1\", CustomerId = \"7\", Items = [new() { ProductId = \"1\", Quantity = 2 }] }",
    "FreshFood.Reposistory.Entities.Order"=>"new Order { OrderId = \"1\", CustomerId = \"7\", DeliveryAddressId = \"2\" }",
    "FreshFood.Reposistory.Entities.AuditLog"=>"new AuditLog { CustomerId = \"7\", RecordIdentifier = \"1\", OldValues = \"{}\", NewValues = \"{}\" }",
    "object" or "System.Object"=>"new { OrderId = \"1\" }",_=>$"({t})Fixture.Value(typeof({t.TrimEnd('?')}))!"
   };
   lines.Add($"var {n} = {value};");
  }
  var constructorArguments=type.EndsWith("CheckoutRepository")?"database.Session, new FefoBatchSpecification()":"database.Session";
  lines.Add($"var subject = new {m.GetProperty("type").GetString()}({constructorArguments});");
  var call="subject."+name+"("+string.Join(", ",m.GetProperty("parameters").EnumerateArray().Select(p=>p.GetProperty("name").GetString()))+")";
  var gaps=new Dictionary<string,string>{{"LoadLifecycleAsync","TRUSTED_STANDALONE_LIFECYCLE_SNAPSHOT_TBD"},{"SaveOrderLinesAsync","SHARED_ORDER_LINE_EFFECTS_REQUIRE_REVIEW"},{"SavePaymentOnceAsync","PAYMENT_CAPTURE_STORAGE_REVIEW_REQUIRED"},{"SaveFailureAsync","STAFF_DELIVERY_FAILURE_NOT_IN_CUSTOMER_INCREMENT"},{"SaveReceiptAsync","STAFF_RETURN_RECEIPT_NOT_IN_CUSTOMER_INCREMENT"},{"SaveRefundOnceAsync","REFUND_PROVIDER_AND_STORAGE_REVIEW_REQUIRED"},{"SaveShippingSettlementAsync","SHIPPING_SETTLEMENT_NOT_IN_CUSTOMER_INCREMENT"}};
  string? error=null;
  if(gaps.TryGetValue(name,out var gap))error=gap;
  else if(empty)error=name switch {"GetCustomerAsync" or "LockOrderAsync" or "LockOwnedAsync" or "GetOwnedAddressAsync" or "SaveAddressAsync"=>"NOT_FOUND","AppendAuditAsync"=>"AUDIT_ORDER_NOT_OWNED","CompleteCheckoutAsync"=>"IDEMPOTENCY_COMPLETION_CONFLICT","ClaimCheckoutAsync"=>"CHECKOUT_REFERENCE_REUSED",_=>null};
  var returns=m.GetProperty("returns").GetString()!;
  if(error is not null){lines.Add($"var expectedErrorCode = {Emit.String(error)};\n// Act\nvar actualException = Assert.ThrowsAsync<DomainException>(async () => await {call})!;\n// Assert\nAssert.That(actualException.Code, Is.EqualTo(expectedErrorCode));");if(gap is not null)lines.Add("Assert.That(database.Queries, Is.Empty);");}
  else if(fail)lines.Add($"// Act\nvar actualException = Assert.ThrowsAsync<TimeoutException>(async () => await {call})!;\n// Assert\nAssert.That(actualException, Is.SameAs(expectedException));");
  else if(returns=="System.Threading.Tasks.Task")lines.Add($"// Act\nawait {call};\n// Assert\nAssert.That(database.Queries, "+(name=="SaveBatchesAsync"&&empty?"Is.Empty":"Is.Not.Empty")+");");
  else {
   var inner=returns[(returns.IndexOf('<')+1)..^1];
   lines.Add($"// Act\nvar actual = await {call};\n// Assert");
   if(inner.Contains("List<"))lines.Add($"var expectedRowCount = {(empty?0:1)}; Assert.That(actual, NUnit.Framework.Has.Count.EqualTo(expectedRowCount));");
   else if(inner is "bool" or "System.Boolean")lines.Add($"var expected = {(empty?"false":"true")}; Assert.That(actual, Is.EqualTo(expected));");
   else if(inner.EndsWith("Cart")){lines.Add("var expectedCartId = \"1\"; var expectedCustomerId = \"7\"; Assert.That(actual.CartId, Is.EqualTo(expectedCartId)); Assert.That(actual.CustomerId, Is.EqualTo(expectedCustomerId));");}
   else if(inner=="object")lines.Add("Assert.That(actual, Is.TypeOf<CheckoutClaim>()); Assert.That(((CheckoutClaim)actual).Replay, Is.False);");
   else lines.Add("Assert.That(actual, "+(empty?"Is.Null":"Is.Not.Null")+");");
  }
  lines.Add("foreach (var query in database.Queries) { Assert.That(query.Token, Is.EqualTo(Fixture.Token)); Assert.That(query.Sql, Does.Not.Contain(\"Sample\")); Assert.That(query.Sql, Does.Not.Contain(\"tester@example.com\")); }");
  return (BlockSyntax)ParseStatement("{"+string.Join("\n",lines)+"}");
 }
}
