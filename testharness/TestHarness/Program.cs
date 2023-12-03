// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

using NCodeBuilder.CLanguageFamily;
using NCodeBuilder.CSharp;

using static System.Console;

namespace NCodeBuilder.TestHarness;

internal static class Program
{
    private static void Main()
    {
        string[] enumValues = { "Earth", "Water", "Fire", "Air" };

            // @formatter:off
            var language = LanguageProvider.CSharp();
            //LanguageProvider language = LanguageProvider.Python;
            CodeBuilder builder = new CodeBuilder(language)
                .MultiLineComment(
                    "CodeBuilder framework",
                    "Copyright (c) 2019-2023 Jeevan James")
                .__
                .Using("System")
                .Using("System.Linq")
                .UsingStatic("System.Console")
                .__
                .Namespace("MyCode")
                    .DocComments("The main class to do stuff")
                    .Class("MyClass").Public.Sealed.Partial.Inherits<Comparer<string>>().Implements<IEnumerable<string>>().x
                        ._("private readonly string _value;")
                        .__
                        .Block("public MyClass(string value)")
                            ._("_value = value;")
                        .EndBlock()
                        .__
                        .DocComments(
                            "Does something with the provided value.",
                            "Does not return anything")
                        .Block("public void DoSomething()")
                            .Try()
                                .Inline("//TODO: ")
                                    ._("This is a sample TODO")
                                    .Done()
                                .If("DateTime.Now.DayOfWeek == DayOfWeek.Monday")
                                    ._("WriteLine(_value);")
                                .ElseIf("DateTime.Now.DayOfWeek == DayOfWeek.Wednesday")
                                    ._(@"WriteLine(""Boring"");")
                                .Else()
                                    ._(@"WriteLine(""Yay, almost there"");")
                                .EndIf()
                            .Catch<InvalidOperationException>()
                                ._(@"WriteLine(""Invalid operation"")")
                            .Catch<Exception>("ex")
                                .Comment(() => $"Error at {DateTime.Now:f}")
                                ._("WriteLine(ex.Message);")
                            .Finally()
                                ._(@"WriteLine(""Done with method"");")
                            .EndTry()
                        .EndBlock()
                    .EndClass()
                    .__
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
