// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

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
