#region --- License & Copyright Notice ---
/*
CodeBuilder
Copyright (c) 2019-20 Jeevan James
All rights reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
#endregion

using System;

using NCodeBuilder;
using NCodeBuilder.CSharp;

using static System.Console;

namespace TestHarness
{
    internal static class Program
    {
        private static void Main()
        {
            string[] enumValues = { "Earth", "Water", "Fire", "Air" };

            var language = LanguageProvider.CSharp(NCodeBuilder.CLanguageFamily.CLanguageBraceStyle.SameLine);
            //LanguageProvider language = LanguageProvider.Python;
            CodeBuilder builder = new CodeBuilder(language)
                .MultiLineComment(
                    "CodeBuilder framework",
                    "Copyright (c) 2019-2020 Jeevan James")
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
                                .Comment((CodeFactory)(() => $"Error at {DateTime.Now:f}"))
                                .Line("WriteLine(ex.Message);")
                            .Finally()
                                .Line(@"WriteLine(""Done with method"");")
                            .EndTry()
                        .EndBlock()
                    .EndBlock()
                    .Blank
                    .Generate(Enums, enumValues)
                .EndNamespace();

            string code = builder.ToString();
            WriteLine(code);
        }

        private static void Enums(CodeBuilder code, string[] enumValues)
        {
            code.Block("public enum Elements")
                .Repeat(enumValues, (cb, s) => cb.Inline(s.Item).Add(",", !s.IsLast).Done())
                .EndBlock();

        }
    }
}
