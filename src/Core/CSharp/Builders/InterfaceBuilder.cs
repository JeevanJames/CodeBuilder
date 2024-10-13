// Copyright (c) 2019-23 Jeevan James
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

public sealed class InterfaceBuilder : TypeBuilder<InterfaceBuilder>
{
    private bool _partial;

    public InterfaceBuilder(CodeBuilder builder, string interfaceName) : base(builder, interfaceName)
    {
    }

    public InterfaceBuilder Partial
    {
        get { _partial = true; return this; }
    }

    public override CodeBuilder Done()
    {
        return Builder
            .Inline(AccessibilityStr)
                ._(" partial", _partial)
                ._($" interface {TypeName}")
                .Done()
            .Block(context: "csharp_interface");
    }
}
