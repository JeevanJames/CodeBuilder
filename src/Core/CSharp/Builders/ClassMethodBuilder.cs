using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class ClassMethodBuilder : MethodBuilder<ClassMethodBuilder>
{
    private bool _async;

    public ClassMethodBuilder(CodeBuilder builder, string name) : base(builder, name)
    {
    }

    public ClassMethodBuilder Async
    {
        get { _async = true; return this; }
    }

    public override CodeBuilder Done()
    {
        InlineCodeBuilder builder = Builder
            .Inline(VisibilityKeyword)
            ._(" ")
            ._("static ", _static)
            ._("async ", _async);
        BuildCoreSignature(builder);
        return builder.Done().Block(context: "csharp_method");
    }
}
