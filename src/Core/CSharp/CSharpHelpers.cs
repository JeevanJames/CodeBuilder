using System.CodeDom;
using System.CodeDom.Compiler;

namespace NCodeBuilder.CSharp;

public static class CSharpHelpers
{
    public static string GetFriendlyTypeName(Type type)
    {
        var codeDomProvider = CodeDomProvider.CreateProvider("C#");
        var typeReferenceExpression = new CodeTypeReferenceExpression(new CodeTypeReference(type));

        using var writer = new StringWriter();
        codeDomProvider.GenerateCodeFromExpression(typeReferenceExpression, writer, new CodeGeneratorOptions());
        return writer.GetStringBuilder().ToString();
    }
}
