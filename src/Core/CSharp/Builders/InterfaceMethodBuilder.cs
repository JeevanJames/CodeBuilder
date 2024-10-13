using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class InterfaceMethodBuilder(CodeBuilder builder, string name) : MethodBuilder<InterfaceMethodBuilder>(builder, name)
{
    public override CodeBuilder Done()
    {
        InlineCodeBuilder inlineBuilder = Builder.Inline(string.Empty);
        BuildCoreSignature(inlineBuilder);
        return inlineBuilder._(";").Done();
    }
}
