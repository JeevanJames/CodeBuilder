﻿#region --- License & Copyright Notice ---
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

// ReSharper disable ArrangeMethodOrOperatorBody
namespace NCodeBuilder.CSharp
{
    public static class CSharpExtensions
    {
        public static CodeBuilder Using(this CodeBuilder cb, string ns) => cb.Line($"using {ns};");

        public static CodeBuilder UsingStatic(this CodeBuilder cb, string ns) => cb.Line($"using static {ns};");

        public static CodeBuilder UsingAlias(this CodeBuilder cb, string alias, string value)
            => cb.Line($"using {alias} = {value};");

        public static CodeBuilder Namespace(this CodeBuilder cb, string ns)
            => cb.Block($"namespace {ns}", "namespace");

        public static CodeBuilder EndNamespace(this CodeBuilder cb) => cb.EndBlock("namespace");

        private const string IfElseIfElseBlock = "if-elseif-else";

        public static CodeBuilder If(this CodeBuilder cb, params string[] conditions)
        {
            return cb.Repeat(conditions, (cb2, s) => cb2
                    .Line($"if ({s.Item})", s.Count == 1)
                    .Line($"if ({s.Item}", s.Count > 1 && s.IsFirst)
                    .Section(s.Count > 1)
                        .Indent
                        .Line(s.Item, !s.IsFirst && !s.IsLast)
                        .Line($"{s.Item})", s.IsLast)
                        .Unindent
                    .EndSection())
                .Block(context: IfElseIfElseBlock);
        }

        public static CodeBuilder ElseIf(this CodeBuilder cb, params string[] conditions)
        {
            return cb.EndBlock(IfElseIfElseBlock)
                .Repeat(conditions, (cb2, s) => cb2
                    .Line($"else if ({s.Item})", s.Count == 1)
                    .Line($"else if ({s.Item}", s.Count > 1 && s.IsFirst)
                    .Section(s.Count > 1)
                        .Indent
                        .Line(s.Item, !s.IsFirst && !s.IsLast)
                        .Line($"{s.Item})", s.IsLast)
                        .Unindent
                    .EndSection())
                .Block(context: IfElseIfElseBlock);
        }

        public static CodeBuilder Else(this CodeBuilder cb)
        {
            return cb.EndBlock(IfElseIfElseBlock)
                .Block("else", IfElseIfElseBlock);
        }

        public static CodeBuilder EndIf(this CodeBuilder cb)
        {
            return cb.EndBlock(IfElseIfElseBlock);
        }

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
}
