// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder.CSharp.Bases;

public abstract class MemberBuilder<TSelf>(CodeBuilder builder, string name) : InnerBuilder(builder)
    where TSelf : MemberBuilder<TSelf>
{
    protected MemberVisibility _visibility;
    protected bool _static;

    /// <summary>
    ///     The name of the C# member.
    /// </summary>
    public string Name { get; } = name;

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
