using System.CodeDom;
using System.CodeDom.Compiler;

namespace NCodeBuilder.CSharp;

internal static class CSharpHelpers
{
    internal static string GetFriendlyTypeName(Type type)
    {
        CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");
        CodeTypeReferenceExpression typeReferenceExpression = new(new CodeTypeReference(type));

        using StringWriter writer = new();
        codeDomProvider.GenerateCodeFromExpression(typeReferenceExpression, writer, new CodeGeneratorOptions());
        return writer.GetStringBuilder().ToString();
    }

    internal static string GetFriendlyTypeName<T>() => GetFriendlyTypeName(typeof(T));
}
