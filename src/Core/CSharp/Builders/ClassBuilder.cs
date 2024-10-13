// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using NCodeBuilder.CSharp.Bases;

namespace NCodeBuilder.CSharp.Builders;

public sealed class ClassBuilder : TypeBuilder<ClassBuilder>
{
    private bool _static;
    private bool _abstract;
    private bool _sealed;
    private bool _partial;
    private string? _baseClassName;
    private List<string>? _interfaces;

    public ClassBuilder(CodeBuilder builder, string className) : base(builder, className)
    {
    }

    public ClassBuilder Static
    {
        get { _static = true; return this; }
    }

    public ClassBuilder Abstract
    {
        get { _abstract = true; return this; }
    }

    public ClassBuilder Sealed
    {
        get { _sealed = true; return this; }
    }

    public ClassBuilder Partial
    {
        get { _partial = true; return this; }
    }

    public ClassBuilder Inherits(string baseClassName)
    {
        _baseClassName = baseClassName;
        return this;
    }

    public ClassBuilder Inherits<T>()
    {
        if (typeof(T).IsSealed)
            throw new InvalidOperationException($"{typeof(T)} is a sealed class and cannot be inherited from.");
        return Inherits(CSharpHelpers.GetFriendlyTypeName(typeof(T)));
    }

    public ClassBuilder Implements(params string[] interfaces)
    {
        _interfaces ??= new List<string>();
        _interfaces.AddRange(interfaces);
        return this;
    }

    public ClassBuilder Implements<T>()
    {
        if (!typeof(T).IsInterface)
            throw new InvalidOperationException($"{typeof(T)} is not an interface.");

        return Implements(CSharpHelpers.GetFriendlyTypeName(typeof(T)));
    }

    public override CodeBuilder Done()
    {
        if (_static && (_abstract || _sealed))
            throw new InvalidOperationException($"Cannot use abstract or sealed on a static class.");
        if (_abstract && _sealed)
            throw new InvalidOperationException($"Cannot be abstract and sealed at the same time.");

        string[]? inheriting = null;
        if (_baseClassName is not null || _interfaces is { Count: > 0 })
        {
            inheriting = new string[(_baseClassName is null ? 0 : 1) + (_interfaces is null ? 0 : _interfaces.Count)];
            if (_baseClassName is not null)
                inheriting[0] = _baseClassName;
            if (_interfaces is { Count: > 0 })
                _interfaces.CopyTo(inheriting, 1);
        }

        return Builder
            .Inline(AccessibilityStr)
                ._(" ")
                ._("static ", _static)
                ._("abstract ", _abstract)
                ._("sealed ", _sealed)
                ._("partial ", _partial)
                ._(TypeName)
                ._($" : {string.Join(", ", inheriting)}", inheriting is not null)
                .Done()
            .Block(context: "csharp_class");
    }
}
