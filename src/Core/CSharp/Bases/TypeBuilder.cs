// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder.CSharp.Bases;

public abstract class TypeBuilder<TSelf> : InnerBuilder
    where TSelf : TypeBuilder<TSelf>
{
    protected TypeBuilder(CodeBuilder builder, string typeName) : base(builder)
    {
        TypeName = typeName;
    }

    protected string TypeName { get; }

    protected TypeVisibility Visibility { get; set; } = TypeVisibility.Public;

    public TSelf Public
    {
        get { Visibility = TypeVisibility.Public; return (TSelf)this; }
    }

    public TSelf Internal
    {
        get { Visibility = TypeVisibility.Internal; return (TSelf)this; }
    }

    public TSelf Private
    {
        get { Visibility = TypeVisibility.Private; return (TSelf)this; }
    }

    protected string VisibilityStr => Visibility.ToString().ToLowerInvariant();
}
