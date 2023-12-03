// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using System;

using NCodeBuilder.CSharp;

using static System.Console;

namespace NCodeBuilder.TestHarness;

internal static class Program
{
    private static void Main()
    {
        string[] enumValues = { "Earth", "Water", "Fire", "Air" };

            // @formatter:off
            var language = LanguageProvider.CSharp(NCodeBuilder.CLanguageFamily.CLanguageBraceStyle.NextLine);
            //LanguageProvider language = LanguageProvider.Python;
            CodeBuilder builder = new CodeBuilder(language)
                .MultiLineComment(
                    "CodeBuilder framework",
                    "Copyright (c) 2019-2023 Jeevan James")
                .Blank
                .Using("System")
                .Using("System.Linq")
                .UsingStatic("System.Console")
                .Blank
                .Namespace("MyCode")
                    .DocComments("The main class to do stuff")
                    .Block("public sealed class MyClass")
                        .Line("private readonly string _value;")
                        .Blank
                        .Block("public MyClass(string value)")
                            .Line("_value = value;")
                        .EndBlock()
                        .Blank
                        .DocComments(
                            "Does something with the provided value.",
                            "Does not return anything")
                        .Block("public void DoSomething()")
                            .Try()
                                .Inline("//TODO: ")
                                    ._("This is a sample TODO")
                                    .Done()
                                .If("DateTime.Now.DayOfWeek == DayOfWeek.Monday")
                                    .Line("WriteLine(_value);")
                                .ElseIf("DateTime.Now.DayOfWeek == DayOfWeek.Wednesday")
                                    .Line(@"WriteLine(""Boring"");")
                                .Else()
                                    .Line(@"WriteLine(""Yay, almost there"");")
                                .EndIf()
                            .Catch<InvalidOperationException>()
                                .Line(@"WriteLine(""Invalid operation"")")
                            .Catch<Exception>("ex")
                                .Comment(() => $"Error at {DateTime.Now:f}")
                                .Line("WriteLine(ex.Message);")
                            .Finally()
                                .Line(@"WriteLine(""Done with method"");")
                            .EndTry()
                        .EndBlock()
                    .EndBlock()
                    .Blank
                    .Generate(Enums, enumValues)
                .EndNamespace();
        // @formatter:on

        string code = builder.ToString();
        WriteLine(code);
    }

    private static void Enums(CodeBuilder code, string[] enumValues)
    {
        code.Block("public enum Elements")
            .Repeat(enumValues, static (cb, s) => cb.Inline(s.Item)._(",", !s.IsLast).Done())
            .EndBlock();
    }
}
