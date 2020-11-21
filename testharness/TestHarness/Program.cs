using CodeBuilder.Core;
using CodeBuilder.Core.CSharp;

using static System.Console;

namespace TestHarness
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string code = new CodeBuilder.Core.CodeBuilder(new CSharpLanguageProvider())
                .MultiLineComment(
                    "CodeBuilder framework",
                    "Copyright (c) 2019 Jeevan James")
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
                    .EndBlock()
                .EndBlock()
                .ToString();

            WriteLine(code);
        }
    }
}
