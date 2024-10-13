// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using NCodeBuilder.CSharp.Builders;

namespace NCodeBuilder.CSharp;

/// <summary>
///     Extension methods on <see cref="CodeBuilder"/> to build C# language code in a strongly-typed
///     fluent manner.
/// </summary>
public static class CSharpExtensions
{
    /// <summary>
    ///     Adds a <c>using</c> statement to import a namespace.
    /// </summary>
    /// <param name="cb">The <see cref="CodeBuilder"/> instance.</param>
    /// <param name="ns">The namespace to import.</param>
    /// <returns>The same instance of the <see cref="CodeBuilder"/>.</returns>
    public static CodeBuilder Using(this CodeBuilder cb, string ns) =>
        cb._($"using {ns};");

    public static CodeBuilder UsingStatic(this CodeBuilder cb, string ns) =>
        cb._($"using static {ns};");

    public static CodeBuilder UsingAlias(this CodeBuilder cb, string alias, string value) =>
        cb._($"using {alias} = {value};");

    public static CodeBuilder Namespace(this CodeBuilder cb, string ns) =>
        cb.Block($"namespace {ns}", "namespace");

    public static CodeBuilder NamespaceFileScoped(this CodeBuilder cb, string ns) =>
        cb._($"namespace {ns};");

    public static CodeBuilder EndNamespace(this CodeBuilder cb) => cb.EndBlock("namespace");

    private const string IfElseIfElseBlock = "if-elseif-else";

    public static CodeBuilder If(this CodeBuilder cb, params string[] conditions) => cb
        .Repeat(conditions, (cb2, s) => cb2
            ._($"if ({s.Item})", s.Count == 1)
            ._($"if ({s.Item}", s.Count > 1 && s.IsFirst)
            .Section(s.Count > 1)
                .Indent
                    ._(s.Item, !s.IsFirst && !s.IsLast)
                    ._($"{s.Item})", s.IsLast)
                .Unindent
            .EndSection())
        .Block(context: IfElseIfElseBlock);

    public static CodeBuilder ElseIf(this CodeBuilder cb, params string[] conditions) => cb
        .EndBlock(IfElseIfElseBlock)
        .Repeat(conditions, (cb2, s) => cb2
            ._($"else if ({s.Item})", s.Count == 1)
            ._($"else if ({s.Item}", s.Count > 1 && s.IsFirst)
            .Section(s.Count > 1)
            .Indent
            ._(s.Item, !s.IsFirst && !s.IsLast)
            ._($"{s.Item})", s.IsLast)
            .Unindent
            .EndSection())
        .Block(context: IfElseIfElseBlock);

    public static CodeBuilder Else(this CodeBuilder cb) => cb
        .EndBlock(IfElseIfElseBlock)
        .Block("else", IfElseIfElseBlock);

    public static CodeBuilder EndIf(this CodeBuilder cb) => cb.EndBlock(IfElseIfElseBlock);

    private const string TryCatchFinallyBlock = "try-catch-finally";

    public static CodeBuilder Try(this CodeBuilder cb) => cb.Block("try", TryCatchFinallyBlock);

    public static CodeBuilder Catch(this CodeBuilder cb, string exception = "Exception", string? variable = null, string? filter = null)
    {
        string catchLine = $"catch ({exception}";
        if (!string.IsNullOrWhiteSpace(variable))
            catchLine += " " + variable;
        catchLine += ")";
        if (!string.IsNullOrWhiteSpace(filter))
            catchLine += $" when ({filter})";
        return cb.EndBlock(TryCatchFinallyBlock).Block(catchLine, TryCatchFinallyBlock);
    }

    public static CodeBuilder Catch<TException>(this CodeBuilder cb, string? variable = null, string? filter = null)
    {
        return Catch(cb, CSharpHelpers.GetFriendlyTypeName(typeof(TException)), variable, filter);
    }

    public static CodeBuilder Finally(this CodeBuilder cb)
        => cb.EndBlock(TryCatchFinallyBlock).Block("finally", TryCatchFinallyBlock);

    public static CodeBuilder EndTry(this CodeBuilder cb) => cb.EndBlock(TryCatchFinallyBlock);

    public static ClassBuilder Class(this CodeBuilder cb, string className) => new(cb, className);

    public static CodeBuilder EndClass(this CodeBuilder cb) => cb.EndBlock("csharp_class");

    public static ClassMethodBuilder Method(this CodeBuilder cb, string methodName) =>
        new(cb, methodName);

    public static CodeBuilder EndMethod(this CodeBuilder cb) => cb.EndBlock("csharp_method");

    public static AutoPropertyBuilder AutoProperty(this CodeBuilder cb, string propertyName, string propertyType) =>
        new(cb, propertyName, propertyType);

    public static AutoPropertyBuilder AutoProperty<TType>(this CodeBuilder cb, string propertyName) =>
        new(cb, propertyName, CSharpHelpers.GetFriendlyTypeName(typeof(TType)));

    public static FieldBuilder Field(this CodeBuilder cb, string name, string type) =>
        new(cb, name, type);

    public static FieldBuilder Field<TType>(this CodeBuilder cb, string name) =>
        new(cb, name, CSharpHelpers.GetFriendlyTypeName(typeof(TType)));

    public static EnumBuilder Enum(this CodeBuilder cb, string enumName) =>
        new(cb, enumName);

    public static CodeBuilder EndEnum(this CodeBuilder cb) => cb.EndBlock("csharp_enum");

    public static CodeBuilder EnumMember(this CodeBuilder cb, string memberName, int? value = null) =>
        cb.Inline(memberName)._($" = {value!.Value}", value.HasValue).Done();

    public static InterfaceBuilder Interface(this CodeBuilder cb, string interfaceName) =>
        new(cb, interfaceName);

    public static CodeBuilder EndInterface(this CodeBuilder cb) => cb.EndBlock("csharp_interface");

    public static InterfaceMethodBuilder InterfaceMethod(this CodeBuilder cb, string methodName) =>
        new(cb, methodName);
}

public static class Literal
{
    public const string Null = "null";

    public static string AsString(string value) => $@"""{value}""";
}
