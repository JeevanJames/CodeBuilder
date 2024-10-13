// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder.CSharp.Bases;

public abstract class MethodBuilder<TSelf> : MemberBuilder<TSelf>
    where TSelf : MethodBuilder<TSelf>
{
    protected MethodBuilder(CodeBuilder builder, string name) : base(builder, name)
    {
    }

    protected string? ReturnType { get; set; }

    protected List<MethodParameter>? Parameters { get; set; }

    public TSelf Returns<TReturn>() => Returns(CSharpHelpers.GetFriendlyTypeName(typeof(TReturn)));

    public TSelf Returns(string returnType, bool nullable = false)
    {
        ReturnType = nullable ? $"{returnType}?" : returnType;
        return (TSelf)this;
    }

    public TSelf ReturnsTaskOf<TReturn>(bool nullable = false) =>
        ReturnsTaskOf(CSharpHelpers.GetFriendlyTypeName(typeof(TReturn)), nullable);

    public TSelf ReturnsTaskOf(string returnType, bool nullable = false)
    {
        ReturnType = $"{typeof(Task)}<{(nullable ? $"{returnType}?" : returnType)}>";
        return (TSelf)this;
    }

    public TSelf Parameter(string name, string type, bool nullable = false, MethodParameterModifier? modifier = null)
    {
        Parameters ??= [];
        Parameters.Add(new MethodParameter(name, type, nullable, modifier));
        return (TSelf)this;
    }

    public TSelf Parameter<T>(string name, bool nullable = false, MethodParameterModifier? modifier = null) =>
        Parameter(name, CSharpHelpers.GetFriendlyTypeName<T>(), nullable, modifier);

    protected void BuildCoreSignature(InlineCodeBuilder cb)
    {
        cb._(ReturnType).__._(Name)._("(")
            .Repeat(Parameters ?? [], static (icb, state) => icb
                ._($"{state.Item.Modifier.ToString().ToLowerInvariant()} ", state.Item.Modifier.HasValue)
                ._(state.Item.Type)
                ._("?", state.Item.Nullable)
                .__
                ._(state.Item.Name)
                ._(", ", !state.IsLast))
            ._(")");
    }

    public sealed class MethodParameter(string name, string type, bool nullable, MethodParameterModifier? modifier)
    {
        public string Name { get; } = name;
        public string Type { get; } = type;
        public bool Nullable { get; } = nullable;
        public MethodParameterModifier? Modifier { get; } = modifier;
    }
}
