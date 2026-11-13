using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

sealed record TypeMarker(string Name);
sealed class Expansion : CSharpSyntaxRewriter
{
 readonly JsonElement? method, test;readonly string helper;
 readonly Dictionary<string,object?> constants=new();HashSet<string> mutable=[];
 internal Expansion(JsonElement? m,JsonElement? c,string h){method=m;test=c;helper=h;if(m.HasValue)constants["m"]=m.Value;if(c.HasValue){constants["c"]=c.Value;constants["d"]=c.Value.GetProperty("data");}if(h=="Identity"&&m.HasValue)constants["name"]=m.Value.GetProperty("name").GetString();}
 public override SyntaxNode? VisitBlock(BlockSyntax node)
 {
  foreach(var e in node.DescendantNodes().OfType<AssignmentExpressionSyntax>())if(e.Left is IdentifierNameSyntax n)mutable.Add(n.Identifier.Text);
  foreach(var e in node.DescendantNodes().OfType<PostfixUnaryExpressionSyntax>())if(e.Operand is IdentifierNameSyntax n)mutable.Add(n.Identifier.Text);
  return base.VisitBlock(node);
 }
 public override SyntaxNode? VisitVariableDeclarator(VariableDeclaratorSyntax node)
 {
  if(node.Initializer is not null && !mutable.Contains(node.Identifier.Text)&&Try(node.Initializer.Value,out var value))constants[node.Identifier.Text]=value;
  return base.VisitVariableDeclarator(node);
 }
 public override SyntaxNode? VisitIfStatement(IfStatementSyntax node)
 {if(Try(node.Condition,out var v)&&v is bool b)return Visit(b?node.Statement:node.Else?.Statement);return base.VisitIfStatement(node);}
 public override SyntaxNode? VisitConditionalExpression(ConditionalExpressionSyntax node)
 {if(Try(node.Condition,out var v)&&v is bool b)return Visit(b?node.WhenTrue:node.WhenFalse);return base.VisitConditionalExpression(node);}
 public override SyntaxNode? VisitSwitchStatement(SwitchStatementSyntax node)
 {
  if(Try(node.Expression,out var v)){
   var section=node.Sections.FirstOrDefault(s=>s.Labels.OfType<CaseSwitchLabelSyntax>().Any(l=>Try(l.Value,out var x)&&Equals(v,x)))??node.Sections.FirstOrDefault(s=>s.Labels.Any(l=>l is DefaultSwitchLabelSyntax));
   if(section is not null)return Visit(Block(section.Statements.Where(s=>s is not BreakStatementSyntax)));
  }return base.VisitSwitchStatement(node);
 }
 public override SyntaxNode? VisitInvocationExpression(InvocationExpressionSyntax node)
 {
  if(Try(node,out var value))return LiteralOf(value).WithTriviaFrom(node);
  if(node.Expression.ToString()=="Context")return base.VisitInvocationExpression(node.WithExpression(ParseExpression("Fixture.TransitionContext")));
  if(node.Expression.ToString()=="Fixture.Invoke" && helper=="Repository" && method.HasValue && method.Value.GetProperty("accessibility").GetString()=="Public"){
   var m=method.Value;var name=m.GetProperty("name").GetString()!;
   if(!name.StartsWith("get_")&&name!=".ctor"){
    var args=m.GetProperty("parameters").EnumerateArray().Select((p,i)=>"("+p.GetProperty("type").GetString()+")args["+i+"]!");
    return ParseExpression("owner."+name+"("+string.Join(", ",args)+")");
   }
  }
  return base.VisitInvocationExpression(node);
 }
 public override SyntaxNode? VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
 {
  if(node.Declaration.Type.IsVar && node.Declaration.Variables.Count==1 && Try(node.Declaration.Variables[0].Initializer!.Value,out var value)&&value is null)
   return base.VisitLocalDeclarationStatement(node.WithDeclaration(node.Declaration.WithType(ParseTypeName("string?"))));
  if(helper=="Repository" && node.Declaration.Variables.Any(v=>v.Identifier.Text=="owner")&&method.HasValue){
   var t=method.Value.GetProperty("type").GetString();var full=method.Value.GetProperty("fullType").GetString();
   var init=t=="SqlRepository"?"new ProbeRepository(session)":t=="CheckoutRepository"?"new CheckoutRepository(session, new FefoBatchSpecification())":"new "+full+"(session)";
   return ParseStatement("var owner = "+init+";");
  }
  return base.VisitLocalDeclarationStatement(node);
 }
 public override SyntaxNode? VisitExpressionStatement(ExpressionStatementSyntax node)
 {
  if(node.Expression is AwaitExpressionSyntax {Expression:InvocationExpressionSyntax call}&&call.Expression.ToString()=="Fixture.Error"){
   var code=(ExpressionSyntax)Visit(call.ArgumentList.Arguments[0].Expression)!;var action=(ExpressionSyntax)Visit(call.ArgumentList.Arguments[1].Expression)!;
   return ParseStatement("{ Func<Task> operation = "+action+"; var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!; Assert.That(actualException.Code, Is.EqualTo(("+code+").Split(' ')[0])); }");
  }
  return base.VisitExpressionStatement(node);
 }
 public override SyntaxNode? VisitIdentifierName(IdentifierNameSyntax node)
 {
  // Do not replace member names, type names or identifiers assigned by the fixture.
  if(node.Parent is MemberAccessExpressionSyntax ma && ma.Name==node)return node;
  if(constants.TryGetValue(node.Identifier.Text,out var v)&&v is not JsonElement&&v is not TypeMarker && !mutable.Contains(node.Identifier.Text))return LiteralOf(v).WithTriviaFrom(node);
  return base.VisitIdentifierName(node);
 }
 bool Try(ExpressionSyntax e,out object? result)
 {
  result=null;
  try{
   switch(e){
    case LiteralExpressionSyntax l:result=l.Token.Value;return true;
    case IdentifierNameSyntax i:return !mutable.Contains(i.Identifier.Text)&&constants.TryGetValue(i.Identifier.Text,out result);
    case TypeOfExpressionSyntax t:result=new TypeMarker(t.Type.ToString().Split('.').Last());return true;
    case ParenthesizedExpressionSyntax p:return Try(p.Expression,out result);
    case PostfixUnaryExpressionSyntax p when p.IsKind(SyntaxKind.SuppressNullableWarningExpression):return Try(p.Operand,out result);
    case PrefixUnaryExpressionSyntax p when p.IsKind(SyntaxKind.LogicalNotExpression)&&Try(p.Operand,out var n)&&n is bool b:result=!b;return true;
    case IsPatternExpressionSyntax p when Try(p.Expression,out var x):return Pattern(p.Pattern,x,out result);
    case BinaryExpressionSyntax b when Try(b.Left,out var left):
     if(b.IsKind(SyntaxKind.LogicalAndExpression)&&left is false){result=false;return true;}
     if(b.IsKind(SyntaxKind.LogicalOrExpression)&&left is true){result=true;return true;}
     if(!Try(b.Right,out var right))return false;
     var equal=left is TypeMarker lt && right is TypeMarker rt?lt.Name.Split('.').Last()==rt.Name.Split('.').Last():left is int or decimal or long && right is int or decimal or long?Convert.ToDecimal(left)==Convert.ToDecimal(right):Equals(left,right);
     result=b.Kind() switch {SyntaxKind.EqualsExpression=>equal,SyntaxKind.NotEqualsExpression=>!equal,SyntaxKind.LogicalAndExpression=>(bool)left!&&(bool)right!,SyntaxKind.LogicalOrExpression=>(bool)left!||(bool)right!,SyntaxKind.GreaterThanExpression=>Convert.ToDecimal(left)>Convert.ToDecimal(right),SyntaxKind.LessThanExpression=>Convert.ToDecimal(left)<Convert.ToDecimal(right),_=>null};return result is not null;
    case MemberAccessExpressionSyntax a:
     if(a.ToString()=="JsonValueKind.Null"){result=JsonValueKind.Null;return true;}
     if(!Try(a.Expression,out var receiver))return false;
     if(a.Name.Identifier.Text=="Length"&&receiver is string str){result=str.Length;return true;}
     if(a.Name.Identifier.Text=="Name"&&receiver is TypeMarker tm){result=tm.Name;return true;}
     if(a.Name.Identifier.Text=="ValueKind"&&receiver is JsonElement je){result=je.ValueKind;return true;}return false;
    case ElementAccessExpressionSyntax a when Try(a.Expression,out var indexedReceiver)&&Try(a.ArgumentList.Arguments[0].Expression,out var index):
     if(indexedReceiver is JsonElement indexedJson){result=indexedJson[Convert.ToInt32(index)];return true;}if(indexedReceiver is string[] array){result=array[Convert.ToInt32(index)];return true;}return false;
    case InvocationExpressionSyntax call:
     var name=call.Expression.ToString();
     if(name=="TypeOf"&&method.HasValue){result=new TypeMarker(method.Value.GetProperty("fullType").GetString()!);return true;}
     var values=new List<object?>();foreach(var arg in call.ArgumentList.Arguments){if(!Try(arg.Expression,out var v))return false;values.Add(v);}
     if(name is "S" or "N" or "Has"){
      var d=(JsonElement)values[0]!;var key=(string)values[1]!;var exists=d.TryGetProperty(key,out var v);
      if(name=="Has"){result=exists;return true;}
      var text=exists&&v.ValueKind!=JsonValueKind.Null?v.ToString():values.Count>2?Convert.ToString(values[2],System.Globalization.CultureInfo.InvariantCulture):name=="N"?"0":"";
      result=name=="N"?decimal.Parse(text!,System.Globalization.CultureInfo.InvariantCulture):text;return true;
     }
     if(call.Expression is MemberAccessExpressionSyntax member&&Try(member.Expression,out var obj)){
      switch(member.Name.Identifier.Text){
       case "GetProperty" when obj is JsonElement j:result=j.GetProperty((string)values[0]!);return true;
       case "GetString" when obj is JsonElement j:result=j.ValueKind==JsonValueKind.Null?null:j.GetString();return true;
       case "GetArrayLength" when obj is JsonElement j:result=j.GetArrayLength();return true;
       case "Contains" when obj is string s:result=s.Contains((string)values[0]!,StringComparison.Ordinal);return true;
       case "Split" when obj is string s:result=s.Split(Convert.ToChar(values[0]));return true;
      }
     }return false;
   }
  }catch(InvalidOperationException){}catch(ArgumentException){}catch(KeyNotFoundException){}catch(FormatException){}
  return false;
 }
 bool Pattern(PatternSyntax pattern,object? value,out object? result){
  result=null;
  if(pattern is ConstantPatternSyntax c&&Try(c.Expression,out var x)){result=Equals(value,x);return true;}
  if(pattern is UnaryPatternSyntax u&&Pattern(u.Pattern,value,out var n)){result=!(bool)n!;return true;}
  if(pattern is BinaryPatternSyntax b&&Pattern(b.Left,value,out var l)&&Pattern(b.Right,value,out var r)){result=b.IsKind(SyntaxKind.OrPattern)?(bool)l!||(bool)r!:(bool)l!&&(bool)r!;return true;}
  return false;
 }
 static ExpressionSyntax LiteralOf(object? value)=>value switch{
  null=>LiteralExpression(SyntaxKind.NullLiteralExpression),string s=>LiteralExpression(SyntaxKind.StringLiteralExpression,Literal(s)),string[] a=>ParseExpression("new string[] {"+string.Join(", ",a.Select(Emit.String))+"}"),char c=>LiteralExpression(SyntaxKind.CharacterLiteralExpression,Literal(c)),bool b=>LiteralExpression(b?SyntaxKind.TrueLiteralExpression:SyntaxKind.FalseLiteralExpression),decimal d=>ParseExpression("("+d.ToString(System.Globalization.CultureInfo.InvariantCulture)+"m)"),int i=>ParseExpression(i.ToString()),TypeMarker t=>t.Name.EndsWith(".ServiceRules")?ParseExpression("typeof(CheckoutService).Assembly.GetType("+Emit.String(t.Name)+")!"):ParseExpression("typeof("+t.Name+")"),JsonValueKind k=>ParseExpression("JsonValueKind."+k),JsonElement j=>ParseExpression("JsonSerializer.Deserialize<JsonElement>("+Emit.String(j.GetRawText())+")"),_=>throw new InvalidOperationException("Unsupported constant "+value.GetType())};
}
static class Cleanup
{
 internal static BlockSyntax RemoveDataLocals(BlockSyntax body)
 {
  body=(BlockSyntax)new Reachability().Visit(body)!;
  for(int pass=0;pass<6;pass++){
   var calls=body.DescendantNodes().OfType<InvocationExpressionSyntax>().Where(i=>i.Expression is IdentifierNameSyntax).Select(i=>((IdentifierNameSyntax)i.Expression).Identifier.Text).Concat(body.DescendantNodes().OfType<ArgumentSyntax>().Where(a=>a.Expression is IdentifierNameSyntax).Select(a=>((IdentifierNameSyntax)a.Expression).Identifier.Text)).Concat(body.DescendantNodes().OfType<EqualsValueClauseSyntax>().Where(e=>e.Value is IdentifierNameSyntax).Select(e=>((IdentifierNameSyntax)e.Value).Identifier.Text)).ToHashSet();
   body=body.RemoveNodes(body.DescendantNodes().OfType<LocalFunctionStatementSyntax>().Where(f=>!calls.Contains(f.Identifier.Text)),SyntaxRemoveOptions.KeepNoTrivia)!;
   var used=body.DescendantNodes().OfType<IdentifierNameSyntax>().Select(n=>n.Identifier.Text).ToHashSet();
   var removable=body.DescendantNodes().OfType<LocalDeclarationStatementSyntax>().Where(n=>n.Declaration.Variables.All(v=>!used.Contains(v.Identifier.Text))&&n.Declaration.Variables.All(v=>v.Initializer?.Value is LiteralExpressionSyntax or ParenthesizedExpressionSyntax ||v.Identifier.Text is "d" or "c" or "m" or "name" or "type" or "t" or "method" or "expected" or "fail" or "empty" or "paid" or "code" or "boundary" or "replay" or "quantity" or "qty" or "value")).ToArray();
   body=body.RemoveNodes(removable,SyntaxRemoveOptions.KeepNoTrivia)!;
   foreach(var declaration in body.DescendantNodes().OfType<LocalDeclarationStatementSyntax>().Where(n=>n.Declaration.Variables.Count>1).ToArray()){
    var keep=declaration.Declaration.Variables.Where(v=>used.Contains(v.Identifier.Text)||v.Initializer?.Value is not LiteralExpressionSyntax).ToArray();
    if(keep.Length>0 && keep.Length<declaration.Declaration.Variables.Count)body=body.ReplaceNode(declaration,declaration.WithDeclaration(declaration.Declaration.WithVariables(SeparatedList(keep))));
   }
  }
  var action=body.DescendantNodes().OfType<LocalFunctionStatementSyntax>().FirstOrDefault(f=>f.Identifier.Text=="Action");
  if(action?.Body is not null)body=(BlockSyntax)new InlineAction(action.Body).Visit(body)!;
  return body;
 }
}
sealed class InlineAction(BlockSyntax actionBody):CSharpSyntaxRewriter
{
 ExpressionSyntax Lambda()=>ParenthesizedLambdaExpression().WithAsyncKeyword(Token(SyntaxKind.AsyncKeyword)).WithBlock(actionBody);
 public override SyntaxNode? VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)=>node.Identifier.Text=="Action"?null:base.VisitLocalFunctionStatement(node);
 public override SyntaxNode? VisitArgument(ArgumentSyntax node)=>node.Expression is IdentifierNameSyntax i&&i.Identifier.Text=="Action"?node.WithExpression(Lambda()):base.VisitArgument(node);
 public override SyntaxNode? VisitEqualsValueClause(EqualsValueClauseSyntax node)=>node.Value is IdentifierNameSyntax i&&i.Identifier.Text=="Action"?node.WithValue(Lambda()):base.VisitEqualsValueClause(node);
 public override SyntaxNode? VisitExpressionStatement(ExpressionStatementSyntax node)=>node.Expression is AwaitExpressionSyntax { Expression:InvocationExpressionSyntax {Expression:IdentifierNameSyntax i}}&&i.Identifier.Text=="Action"?actionBody.WithLeadingTrivia(ParseLeadingTrivia("// Act and Assert: explicit invocation and expected-result comparisons.\n")):base.VisitExpressionStatement(node);
}
sealed class Reachability:CSharpSyntaxRewriter
{
 static bool Stops(StatementSyntax s)=>s is ReturnStatementSyntax or ThrowStatementSyntax ||s is BlockSyntax b&&b.Statements.LastOrDefault() is { } last&&Stops(last);
 public override SyntaxNode? VisitBlock(BlockSyntax node){var statements=new List<StatementSyntax>();foreach(var s in node.Statements){var rewritten=(StatementSyntax?)Visit(s);if(rewritten is null)continue;statements.Add(rewritten);if(Stops(rewritten))break;}return node.WithStatements(List(statements));}
}
