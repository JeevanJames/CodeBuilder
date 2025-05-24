// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class ClassMethodBuilder(CodeBuilder builder, string name) : MethodBuilder<ClassMethodBuilder>(builder, name)
{
    private bool _async;

    public ClassMethodBuilder Async
    {
        get { _async = true; return this; }
    }

    public override CodeBuilder Done()
    {
        InlineCodeBuilder builder = Builder
            .Inline(VisibilityKeyword)
            .__
            ._("static ", _static)
            ._("async ", _async);
        BuildCoreSignature(builder);
        return builder.Done().Block(context: "csharp_method");
    }
}
