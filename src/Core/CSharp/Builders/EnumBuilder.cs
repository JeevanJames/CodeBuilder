// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

/* Unmerged change from project 'Core (net461)'
Before:
using NCodeBuilder.CSharp.Bases;
After:
using NCodeBuilder;
using NCodeBuilder.CSharp;

// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using NCodeBuilder.CSharp.Bases;
*/
using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class EnumBuilder : TypeBuilder<EnumBuilder>
{
    private bool _flags;

    public EnumBuilder(CodeBuilder builder, string enumName) : base(builder, enumName)
    {
    }

    public EnumBuilder Flags
    {
        get { _flags = true; return this; }
    }

    public override CodeBuilder Done()
    {
        return Builder
            ._("[Flags]", _flags)
            .Inline(VisibilityStr)
                ._($" enum {TypeName}")
                .Done()
            .Block(context: "csharp_enum");
    }
}
