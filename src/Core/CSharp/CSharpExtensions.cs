// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

// ReSharper disable ArrangeMethodOrOperatorBody
namespace NCodeBuilder.CSharp;

public static class CSharpExtensions
{
    public static CodeBuilder Using(this CodeBuilder cb, string ns) =>
        cb._($"using {ns};");

    public static CodeBuilder UsingStatic(this CodeBuilder cb, string ns) =>
        cb._($"using static {ns};");

    public static CodeBuilder UsingAlias(this CodeBuilder cb, string alias, string value) =>
        cb._($"using {alias} = {value};");

    public static CodeBuilder Namespace(this CodeBuilder cb, string ns) =>
        cb.Block($"namespace {ns}", "namespace");

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
        return Catch(cb, typeof(TException).FullName, variable, filter);
    }

    public static CodeBuilder Finally(this CodeBuilder cb)
        => cb.EndBlock(TryCatchFinallyBlock).Block("finally", TryCatchFinallyBlock);

    public static CodeBuilder EndTry(this CodeBuilder cb) => cb.EndBlock(TryCatchFinallyBlock);
}
