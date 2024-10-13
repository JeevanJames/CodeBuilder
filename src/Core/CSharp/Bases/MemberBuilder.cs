namespace NCodeBuilder.CSharp.Bases;

public abstract class MemberBuilder<TSelf> : InnerBuilder
    where TSelf : MemberBuilder<TSelf>
{
    protected MemberVisibility _visibility;
    protected bool _static;

    protected MemberBuilder(CodeBuilder builder, string name) : base(builder)
    {
        Name = name;
    }

    public string Name { get; }

    protected string VisibilityKeyword => _visibility.ToString("G").ToLowerInvariant();

    public TSelf Public
    {
        get { _visibility = MemberVisibility.Public; return (TSelf)this; }
    }

    public TSelf Internal
    {
        get { _visibility = MemberVisibility.Internal; return (TSelf)this; }
    }

    public TSelf Protected
    {
        get { _visibility = MemberVisibility.Protected; return (TSelf)this; }
    }

    public TSelf ProtectedOrInternal
    {
        get { _visibility = MemberVisibility.ProtectedOrInternal; return (TSelf)this; }
    }

    public TSelf Private
    {
        get { _visibility = MemberVisibility.Private; return (TSelf)this; }
    }

    public TSelf Static 
    {
        get { _static = true; return (TSelf)this; }
    }
}
