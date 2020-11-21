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
        private static void Main(string[] args)
        {
            Delegate d = (Func<string>)(() => "Blah");
            string code = new CodeBuilder(new CSharpLanguageProvider())
                .MultiLineComment(
                    "CodeBuilder framework",
                    "Copyright (c) 2019-2020 Jeevan James")
                .Blank
                .Using("System")
                .Using("System.Linq")
                .UsingStatic("System.Console")
                .Blank
                .Namespace("MyCode")
                    .Block("public sealed class MyClass")
                        .Line("private readonly string _value;")
                        .Blank
                        .Block("public MyClass(string value)")
                            .Line("_value = value;")
                        .EndBlock()
                        .Blank
                        .Block("public void DoSomething()")
                            .Try()
                                .Line("WriteLine(_value);")
                            .Catch<Exception>("ex")
                                .Comment((CodeFactory)(() => $"Error at {DateTime.Now:f}"))
                                .Line("WriteLine(ex.Message);")
                            .EndTry()
                        .EndBlock()
                    .EndBlock()
                .EndNamespace()
                .ToString();

            WriteLine(code);
        }
    }
}
