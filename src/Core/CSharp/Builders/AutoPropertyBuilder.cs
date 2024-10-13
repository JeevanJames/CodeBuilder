using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class AutoPropertyBuilder : MemberBuilder<AutoPropertyBuilder>
{
    private readonly string _propertyType;
    private string? _initializationValue;
    private bool _readonly;

    public AutoPropertyBuilder(CodeBuilder builder, string name, string propertyType)
        : base(builder, name)
    {
        _propertyType = propertyType;
    }

    public AutoPropertyBuilder ReadOnly
    {
        get
        {
            _readonly = true;
            return this;
        }
    }

    public AutoPropertyBuilder SetReadOnly(bool isReadonly)
    {
        _readonly = isReadonly;
        return this;
    }

    public AutoPropertyBuilder InitializeWith(string value)
    {
        _initializationValue = value;
        return this;
    }

    public override CodeBuilder Done() =>
        Builder
            .Inline(VisibilityKeyword)
            ._(" ")
            ._("static ", _static)
            ._($"{_propertyType} {Name} {{ get; ")
            ._("set; ", !_readonly)
            ._("}")
            ._($" = {_initializationValue};", _initializationValue is not null)
            .Done();
}
