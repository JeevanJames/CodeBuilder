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

    protected TopLevelAccessibility Accessibility { get; set; } = TopLevelAccessibility.Public;

    public TSelf Public
    {
        get { Accessibility = TopLevelAccessibility.Public; return (TSelf)this; }
    }

    public TSelf Internal
    {
        get { Accessibility = TopLevelAccessibility.Internal; return (TSelf)this; }
    }

    protected string AccessibilityStr => Accessibility.ToString().ToLowerInvariant();
}
