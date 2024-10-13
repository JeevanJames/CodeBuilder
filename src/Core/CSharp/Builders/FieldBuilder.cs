using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class FieldBuilder : MemberBuilder<FieldBuilder>
{
    private readonly string _type;
    private bool _readonly;
    private string? _initializationValue;

    public FieldBuilder(CodeBuilder builder, string name, string type) : base(builder, name)
    {
        _type = type;
    }

    public FieldBuilder ReadOnly 
    {
        get { _readonly = true; return this; }
    }

    public FieldBuilder SetReadOnly(bool isReadonly)
    {
        _readonly = isReadonly;
        return this;
    }

    public FieldBuilder InitializeWith(string value)
    {
        _initializationValue = value;
        return this;
    }

    public override CodeBuilder Done() =>
        Builder
            .Inline(VisibilityKeyword)
            ._(" ")
            ._("static ", _static)
            ._("readonly ", _readonly)
            ._($"{_type} {Name}")
            ._($" = {_initializationValue};", _initializationValue is not null)
            ._(";", _initializationValue is null)
            .Done();
}
