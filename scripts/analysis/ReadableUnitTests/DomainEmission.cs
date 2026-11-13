using System.Globalization;
using System.Text.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

static class DomainEmission
{
 internal static BlockSyntax Create(JsonElement m,JsonElement c)
 {
  var d=c.GetProperty("data");var type=m.GetProperty("type").GetString()!;var name=m.GetProperty("name").GetString()!;
  decimal N(string key,decimal fallback=0)=>d.TryGetProperty(key,out var v)&&v.ValueKind!=JsonValueKind.Null&&decimal.TryParse(v.ToString(),NumberStyles.Number,CultureInfo.InvariantCulture,out var n)?n:fallback;
  string Num(decimal n)=>n.ToString(CultureInfo.InvariantCulture)+"m";
  var error=c.GetProperty("exception").GetString()!.Split(' ')[0];var lines=new List<string>{"// Arrange"};string expression;bool isVoid=false;var checks=new List<string>();
  switch(type){
   case "DeliveryFeePolicy":var distance=N("distanceKm",1);lines.Add($"var distanceKm = {Num(distance)}; var subject = new DeliveryFeePolicy();");expression="subject.Quote(distanceKm)";checks.Add($"var expectedFee = {Num(distance<1?10000:distance<3?20000:30000)}; Assert.That(actual.Units, Is.EqualTo(expectedFee));");break;
   case "BatchPricingPolicy":var price=N("RetailPrice",10000);var rate=N("DiscountRate");lines.Add($"var batch = Fixture.Batch(); batch.RetailPrice = new VndAmount({Num(price)}); batch.DiscountRate = {Num(rate)}; var subject = new BatchPricingPolicy(); var asOf = DateTimeOffset.UtcNow;");expression="subject.Quote(batch, asOf)";checks.Add($"var expectedPrice = {Num(price*(100-rate)/100)}; Assert.That(actual.Units, Is.EqualTo(expectedPrice));");break;
   case "BatchInventory":var stock=N("CurrentStock",10);var reserved=N("ReservedStock",3);var quantity=N("quantity",2);lines.Add($"var subject = Fixture.Batch(stock: {(int)stock}, reserved: {(int)reserved}); var quantity = {(int)quantity};");expression=$"subject.{name}(quantity)";isVoid=true;checks.Add($"var expectedReservedStock = {(int)(reserved+(name=="Reserve"?quantity:-quantity))}; Assert.That(subject.ReservedStock, Is.EqualTo(expectedReservedStock));");break;
   case "VndAmount":
    var units=N("units",N("Units",10000));
    if(name=="Add"){var left=N("left",10000);var right=N("right",N("other",10000));lines.Add($"var subject = new VndAmount({Num(left)}); var other = new VndAmount({Num(right)});");expression="subject.Add(other)";checks.Add($"var expectedUnits = {Num(left+right)}; Assert.That(actual.Units, Is.EqualTo(expectedUnits));");}
    else if(name is "ToWire" or "ToString"){lines.Add($"var subject = new VndAmount({Num(units)});");expression="subject."+name+"()";checks.Add("var expectedText = "+Emit.String(units.ToString("0",CultureInfo.InvariantCulture))+"; Assert.That(actual, Is.EqualTo(expectedText));");}
    else {lines.Add($"var units = {Num(units)};");expression=name=="FromUnits"?"VndAmount.FromUnits(units)":"new VndAmount(units)";checks.Add($"var expectedUnits = {Num(units)}; Assert.That(actual.Units, Is.EqualTo(expectedUnits));");}break;
   case "Order":lines.Add("var subject = new Order { OrderStatus = OrderStatus.PendingUnpaid, PaymentStatus = PaymentStatus.Unpaid };");isVoid=true;
    if(name=="RecordPayment"){expression="subject.RecordPayment(PaymentStatus.Unpaid, PaymentStatus.Paid)";checks.Add("var expectedPayment = PaymentStatus.Paid; Assert.That(subject.PaymentStatus, Is.EqualTo(expectedPayment)); Assert.That(subject.OrderStatus, Is.EqualTo(OrderStatus.PendingUnpaid));");}
    else if(name=="Cancel"){lines.Add("var reason = \"Changed mind\";");expression="subject.Cancel(OrderStatus.PendingUnpaid, reason)";checks.Add("var expectedStatus = OrderStatus.Cancelled; Assert.That(subject.OrderStatus, Is.EqualTo(expectedStatus)); Assert.That(subject.CancellationReason, Is.EqualTo(reason));");}
    else {expression="subject.ApplyFulfillment(OrderStatus.PendingUnpaid, OrderStatus.Confirmed)";checks.Add("var expectedStatus = OrderStatus.Confirmed; Assert.That(subject.OrderStatus, Is.EqualTo(expectedStatus));");}break;
   case "Cart":lines.Add("var subject = new Cart { Items = [new() { ProductId = \"2\", Quantity = 4 }] }; var productId = \"1\";");isVoid=true;
    if(name=="ChangeQuantity"){lines.Add("subject.ChangeQuantity(productId, 2); var replacementQuantity = 3;");expression="subject.ChangeQuantity(productId, replacementQuantity)";checks.Add("var actualQuantity = subject.Items.Single(item => item.ProductId == productId).Quantity; var expectedQuantity = 3; Assert.That(actualQuantity, Is.EqualTo(expectedQuantity));");}
    else {lines.Add("subject.Items.Add(new CartItem { ProductId = productId, Quantity = 2 });");expression="subject.RemoveItem(productId)";checks.Add("Assert.That(subject.Items.Any(item => item.ProductId == productId), Is.False); subject.RemoveItem(\"99\");");}
    checks.Add("Assert.That(subject.Items.Single(item => item.ProductId == \"2\").Quantity, Is.EqualTo(4));");break;
   case "FefoBatchSpecification":lines.Add("var asOf = new DateTimeOffset(2099, 1, 1, 0, 0, 0, TimeSpan.Zero); var subject = new FefoBatchSpecification();");expression="subject.Criteria(asOf)";checks.Add("Assert.That(actual.ActiveProductsOnly, Is.True); Assert.That(actual.LockForUpdate, Is.True); Assert.That(actual.MinimumAvailable, Is.EqualTo(1)); var expectedSortKeys = new[] { \"expiry_date\", \"batch_id\" }; Assert.That(actual.SortKeys, Is.EqualTo(expectedSortKeys));");break;
   default:lines.Add("var input = new VndAmount(10000); var expectedJson = \"\\\"10000\\\"\";");expression="JsonSerializer.Serialize(input)";checks.Add("Assert.That(actual, Is.EqualTo(expectedJson)); var actualReadBack = JsonSerializer.Deserialize<VndAmount>(actual); Assert.That(actualReadBack.Units, Is.EqualTo(10000m));");break;
  }
  if(error.Length>0){lines.Add("var expectedErrorCode = "+Emit.String(error)+";\n// Act\nvar actualException = Assert.Throws<DomainException>(() => "+expression+")!;\n// Assert\nAssert.That(actualException.Code, Is.EqualTo(expectedErrorCode));");if(type=="BatchInventory")lines.Add($"Assert.That(subject.ReservedStock, Is.EqualTo({(int)N("ReservedStock",3)}));");}
  else {lines.Add("// Act\n"+(isVoid?expression:"var actual = "+expression)+";\n// Assert");lines.AddRange(checks);}
  return (BlockSyntax)ParseStatement("{"+string.Join("\n",lines)+"}");
 }
 internal static BlockSyntax FailClosed(JsonElement m)
 {
  var type=m.GetProperty("type").GetString()!;var full=m.GetProperty("fullType").GetString()!;var name=m.GetProperty("name").GetString()!;
  var code=type switch {"GoogleMapsGeocodingAdapter"=>"GEOCODING_TRANSPORT_NOT_CONFIGURED","GoogleMapsDistanceAdapter"=>"DISTANCE_TRANSPORT_NOT_CONFIGURED","SePayPaymentAdapter"=>name=="CreateQrAsync"?"PRE_ACCEPTANCE_PAYMENT_CORRELATION_TBD":"PAYMENT_VERIFIER_NOT_CONFIGURED","ConfiguredNotificationPublisher"=>"NOTIFICATION_TRANSPORT_NOT_CONFIGURED",_=>"PAYOUT_PROVIDER_TBD"};
  var parameters=m.GetProperty("parameters").EnumerateArray().ToArray();var text="// Arrange\n";
  foreach(var p in parameters){var t=Emit.Type(p);text+=$"var {p.GetProperty("name").GetString()} = ({t})Fixture.Value(typeof({t.TrimEnd('?')}))!;\n";}
  text+=$"var subject = new {full}(); var expectedErrorCode = {Emit.String(code)};\n// Act\nvar actualException = Assert.ThrowsAsync<DomainException>(async () => await subject.{name}("+string.Join(", ",parameters.Select(p=>p.GetProperty("name").GetString()))+"))!;\n// Assert\nAssert.That(actualException.Code, Is.EqualTo(expectedErrorCode)); Assert.That(actualException.Status, Is.EqualTo(503));";
  return (BlockSyntax)ParseStatement("{"+text+"}");
 }
}
