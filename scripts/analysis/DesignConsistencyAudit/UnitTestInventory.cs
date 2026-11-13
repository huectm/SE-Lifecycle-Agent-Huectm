using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal static class UnitTestInventory
{
    public static async Task Export(Solution solution, string root)
    {
        var methods = new List<object>();
        foreach (var project in solution.Projects.Where(p => p.Name is "FreshFood-API" or "FreshFood.Reposistory"))
        foreach (var document in project.Documents)
        {
            if (document.FilePath is null || document.FilePath.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar)) continue;
            var syntax = await document.GetSyntaxRootAsync(); var model = await document.GetSemanticModelAsync();
            if (syntax is null || model is null) continue;
            var file = Path.GetRelativePath(root, document.FilePath).Replace('\\', '/');
            var symbols = syntax.DescendantNodes().OfType<BaseTypeDeclarationSyntax>()
                .Select(n => model.GetDeclaredSymbol(n)).OfType<INamedTypeSymbol>()
                .SelectMany(t => t.GetMembers().OfType<IMethodSymbol>())
                .Where(m => !m.IsImplicitlyDeclared && m.MethodKind is MethodKind.Ordinary or MethodKind.Constructor or MethodKind.StaticConstructor or MethodKind.UserDefinedOperator or MethodKind.Conversion)
                .Concat(syntax.DescendantNodes().OfType<LocalFunctionStatementSyntax>().Select(n => model.GetDeclaredSymbol(n)).OfType<IMethodSymbol>())
                .Distinct(SymbolEqualityComparer.Default).OfType<IMethodSymbol>().ToList();
            foreach (var property in syntax.DescendantNodes().OfType<PropertyDeclarationSyntax>())
            {
                if (model.GetDeclaredSymbol(property) is not IPropertySymbol p) continue;
                if (property.ExpressionBody is not null && p.GetMethod is not null) symbols.Add(p.GetMethod);
                if (property.AccessorList is not null)
                foreach (var accessor in property.AccessorList.Accessors.Where(a => a.Body is not null || a.ExpressionBody is not null))
                    if (model.GetDeclaredSymbol(accessor) is IMethodSymbol a) symbols.Add(a);
            }
            foreach (var method in symbols)
            {
                var declaration = method.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax();
                if (declaration is null || declaration.SyntaxTree.FilePath != document.FilePath) continue;
                var primary = declaration is TypeDeclarationSyntax;
                SyntaxNode? body = declaration switch
                {
                    BaseMethodDeclarationSyntax b => (SyntaxNode?)b.Body ?? b.ExpressionBody,
                    LocalFunctionStatementSyntax l => (SyntaxNode?)l.Body ?? l.ExpressionBody,
                    AccessorDeclarationSyntax a => (SyntaxNode?)a.Body ?? a.ExpressionBody,
                    PropertyDeclarationSyntax p => p.ExpressionBody,
                    ArrowExpressionClauseSyntax a => a,
                    _ => null
                };
                var nodes = body?.DescendantNodesAndSelf().ToArray() ?? [];
                var decisions = new List<Decision>();
                void Add(string kind, ExpressionSyntax? expression, SyntaxNode at, string[]? outcomes = null)
                {
                    if (expression is null && outcomes is null) return;
                    var text = expression?.ToString() ?? at.ToString();
                    if (decisions.Any(d => d.Kind == kind && d.Line == Line(at) && d.Expression == text)) return;
                    decisions.Add(new(kind, Line(at), text, expression is null ? [] : Atoms(expression).ToArray(), outcomes ?? ["True", "False"], expression is null ? null : Tree(expression), Effects(kind, at)));
                }
                foreach (var node in nodes)
                {
                    switch (node)
                    {
                        case IfStatementSyntax n: Add("if", n.Condition, n); break;
                        case ConditionalExpressionSyntax n: Add("conditional", n.Condition, n); break;
                        case WhileStatementSyntax n: Add("while", n.Condition, n); break;
                        case DoStatementSyntax n: Add("do", n.Condition, n); break;
                        case ForStatementSyntax n: Add("for", n.Condition, n); break;
                        case ForEachStatementSyntax n: Add("foreach", n.Expression, n, ["Empty", "One item", "Multiple items"]); break;
                        case SwitchExpressionSyntax n:
                            foreach (var arm in n.Arms) Add("switch-arm", arm.WhenClause?.Condition, arm, [arm.Pattern.ToString()]); break;
                        case SwitchStatementSyntax n:
                            foreach (var label in n.Sections.SelectMany(s => s.Labels)) Add("switch-case", null, label, [label.ToString()]); break;
                        case CatchClauseSyntax n: Add("catch", null, n, [n.Declaration?.Type.ToString() ?? "Any exception"]); if (n.Filter is not null) Add("catch-filter", n.Filter.FilterExpression, n.Filter); break;
                        case AssignmentExpressionSyntax n when n.IsKind(SyntaxKind.CoalesceAssignmentExpression): Add("coalesce-assignment", n.Left, n, ["Null", "Non-null"]); break;
                        case BinaryExpressionSyntax n when n.IsKind(SyntaxKind.CoalesceExpression): Add("coalesce", n.Left, n, ["Null", "Non-null"]); break;
                        case ConditionalAccessExpressionSyntax n: Add("null-access", n.Expression, n, ["Null", "Non-null"]); break;
                        case InvocationExpressionSyntax n when n.Expression.ToString().EndsWith("Require") && n.ArgumentList.Arguments.Count > 0:
                            Add("guard", n.ArgumentList.Arguments[0].Expression, n); break;
                        case LambdaExpressionSyntax n when n.Body is ExpressionSyntax e && model.GetTypeInfo(e).Type?.SpecialType == SpecialType.System_Boolean:
                            Add("predicate", e, n); break;
                    }
                }
                if (body is ArrowExpressionClauseSyntax arrow && model.GetTypeInfo(arrow.Expression).Type?.SpecialType == SpecialType.System_Boolean)
                    Add("boolean-return", arrow.Expression, arrow.Expression);
                var isContract = method.ContainingType.TypeKind == TypeKind.Interface || method.IsAbstract;
                var line = Line(declaration);
                var signature = method.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
                var code = primary ? method.ContainingType.Name + "(" + string.Join(", ", method.Parameters.Select(p => p.ToDisplayString())) + ")" : declaration.ToString();
                methods.Add(new
                {
                    type = method.ContainingType.Name, fullType = method.ContainingType.ToDisplayString(), name = method.Name,
                    signature, kind = method.MethodKind.ToString(), accessibility = method.DeclaredAccessibility.ToString(),
                    file, line, endLine = primary ? line : declaration.GetLocation().GetLineSpan().EndLinePosition.Line + 1,
                    loc = primary ? 1 : code.Split('\n').Count(s => !string.IsNullOrWhiteSpace(s)),
                    contractOnly = isContract, primaryConstructor = primary,
                    indirect = method.DeclaredAccessibility is Accessibility.Private or Accessibility.Protected || method.MethodKind == MethodKind.LocalFunction,
                    parameters = method.Parameters.Select(p => new { name = p.Name, type = p.Type.ToDisplayString(), optional = p.IsOptional }).ToArray(),
                    returns = method.ReturnType.ToDisplayString(), code, decisions,
                    calls = nodes.OfType<InvocationExpressionSyntax>().Select(n => new { target = n.Expression.ToString(), arguments = n.ArgumentList.Arguments.Select(a => a.ToString()).ToArray(), line = Line(n) }).ToArray(),
                    throws = nodes.OfType<ThrowExpressionSyntax>().Select(t => t.Expression.ToString()).Concat(nodes.OfType<ThrowStatementSyntax>().Select(t => t.Expression?.ToString() ?? "rethrow")).Distinct().ToArray(),
                    sourceSha256 = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(document.FilePath)))
                });
            }
        }
        var output = Path.Combine(root, "artifacts/testing/test-design/backend-unit-method-inventory.json");
        Directory.CreateDirectory(Path.GetDirectoryName(output)!);
        await File.WriteAllTextAsync(output, JsonSerializer.Serialize(new { date = "2026-11-04", scope = "Five customer use cases and shared backend realization", methods }, new JsonSerializerOptions { WriteIndented = true }));
        Console.WriteLine($"Unit design inventory: {methods.Count} declarations including interface contracts, constructors, private helpers, operators and explicit accessors.");
    }
    private static int Line(SyntaxNode n) => n.GetLocation().GetLineSpan().StartLinePosition.Line + 1;
    private static string[] Effects(string kind, SyntaxNode node) => node switch
    {
        IfStatementSyntax n => ["True: " + n.Statement, "False: " + (n.Else?.Statement.ToString() ?? "Continue after if; no action from the true branch")],
        ConditionalExpressionSyntax n => ["True: " + n.WhenTrue, "False: " + n.WhenFalse],
        SwitchExpressionArmSyntax n => [n.Expression.ToString()],
        CaseSwitchLabelSyntax n => [n.Parent?.ToString() ?? n.ToString()],
        DefaultSwitchLabelSyntax n => [n.Parent?.ToString() ?? n.ToString()],
        CatchClauseSyntax n => [n.Block.ToString()],
        InvocationExpressionSyntax n when kind == "guard" => ["True: continue", "False: DomainException(" + string.Join(", ", n.ArgumentList.Arguments.Skip(1)) + ")"],
        ForEachStatementSyntax n => ["Empty: body not called", "Non-empty: " + n.Statement],
        _ => ["Outcome follows the expression: " + node.ToString()]
    };
    private static object Tree(ExpressionSyntax expression)
    {
        if (expression is ParenthesizedExpressionSyntax p) return Tree(p.Expression);
        if (expression is BinaryExpressionSyntax b && (b.IsKind(SyntaxKind.LogicalAndExpression) || b.IsKind(SyntaxKind.LogicalOrExpression)))
            return new { kind = b.IsKind(SyntaxKind.LogicalAndExpression) ? "And" : "Or", left = Tree(b.Left), right = Tree(b.Right) };
        if (expression is IsPatternExpressionSyntax pattern) return Pattern(pattern.Expression.ToString(), pattern.Pattern);
        return new { kind = "Atom", text = expression.ToString() };
    }
    private static object Pattern(string value, PatternSyntax pattern)
    {
        if (pattern is BinaryPatternSyntax binary)
            return new { kind = binary.IsKind(SyntaxKind.AndPattern) ? "And" : "Or", left = Pattern(value, binary.Left), right = Pattern(value, binary.Right) };
        if (pattern is ParenthesizedPatternSyntax p) return Pattern(value, p.Pattern);
        return new { kind = "Atom", text = value + " is " + pattern };
    }
    private static IEnumerable<string> Atoms(ExpressionSyntax expression)
    {
        if (expression is ParenthesizedExpressionSyntax p) return Atoms(p.Expression);
        if (expression is BinaryExpressionSyntax b && (b.IsKind(SyntaxKind.LogicalAndExpression) || b.IsKind(SyntaxKind.LogicalOrExpression))) return Atoms(b.Left).Concat(Atoms(b.Right));
        return [expression.ToString()];
    }
    private sealed record Decision(string Kind, int Line, string Expression, string[] Atoms, string[] Outcomes, object? Tree, string[] Effects);
}
