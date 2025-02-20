// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

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
            ._____
            .Using("System")
            .Using("System.Linq")
            .UsingStatic("System.Console")
            ._____
            .NamespaceFileScoped("MyCode")
            ._____
            .DocComments("This is a sample interface")
            .Interface("IMyInterface").Public._
                .InterfaceMethod("Add").Returns<int>()
                    .Parameter<int>("a")
                    .Parameter<int>("b")
                    ._
                ._____
                .InterfaceMethod("DoSomething").ReturnsTaskOf<string>()
                    .Parameter<string>("json")
                    ._
            .EndInterface()
            ._____
            .DocComments("The main class to do stuff")
            .Class("MyClass").Public.Sealed.Partial.Inherits<Comparer<string>>().Implements<IEnumerable<string>>().Implements("TestBase")._
                .Field<string>("_value").Private.ReadOnly._
                .Field("_lock", "object?").Private.Static.InitializeWith(Literal.Null)._
                    ._____
                    .Block("public MyClass(string value)")
                        ._("_value = value;")
                    .EndBlock()
                    ._____
                    .DocComments(
                        "Does something with the provided value.",
                        "Does not return anything")
                    .Method("DoSomething").Internal.Static.Returns<int>()
                        .Parameter<string>("name", nullable: true, modifier: MethodParameterModifier.Out)._
                        ._("if (name is null)")
                            .__("throw new ArgumentNullException(nameof(name));", DateTime.Now.Second % 2 == 0)
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
                    .EndMethod()
                    ._____
                    .AutoProperty<string>("Data").Public.Static.ReadOnly.InitializeWith(Literal.AsString("Jeevan"))._
                    .AutoProperty("LockObject", "object?").Private.InitializeWith(Literal.Null)._
                .EndClass()
                ._____
                .Generate(Enums, enumValues)
                ._____
                .Enum("OtherEnum").Internal.Flags._
                    .EnumMember("MemberOne", 0x1)
                    .EnumMember("MemberTwo", 0x2)
                .EndEnum();
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
