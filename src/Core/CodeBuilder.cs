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
using System.Collections.Generic;
using System.Text;

namespace NCodeBuilder
{
    public sealed class CodeBuilder
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private readonly LanguageProvider _language;
        private readonly Stack<string?> _blockStack = new Stack<string?>();
        private int _indentLevel = 0;

        public CodeBuilder(LanguageProvider language)
        {
            _language = language;
        }

        public CodeBuilder Blank
        {
            get
            {
                _builder.AppendLine();
                return this;
            }
        }

        public CodeBuilder Indent
        {
            get
            {
                _indentLevel++;
                return this;
            }
        }

        public CodeBuilder Unindent
        {
            get
            {
                if (_indentLevel == 0)
                    throw new InvalidOperationException("Cannot decrease indent level below zero.");
                _indentLevel--;
                return this;
            }
        }

        public CodeBuilder Line(CodeLine code)
        {
            string? line = code.ToString();
            if (line is null)
                return this;

            if (_indentLevel > 0)
                _builder.Append(GetIndent());
            _builder.AppendLine(code.ToString());
            return this;
        }

        public CodeBuilder Line(CodeLine code, Func<bool> predicate)
        {
            if (predicate())
                Line(code);
            return this;
        }

        public CodeBuilder Line(CodeLine code, bool condition)
        {
            if (condition)
                Line(code);
            return this;
        }

        public CodeBuilder Repeat<T>(IEnumerable<T> collection, Action<CodeBuilder, T> action)
        {
            foreach (T item in collection)
                action(this, item);
            return this;
        }

        public CodeBuilder Repeat<T>(IEnumerable<T> collection, Action<CodeBuilder, T, int> action)
        {
            int counter = 0;
            foreach (T item in collection)
            {
                action(this, item, counter);
                counter++;
            }
            return this;
        }

        public CodeBuilder Block(CodeLine? code = null, string? context = null)
        {
            _blockStack.Push(context);
            _language.StartBlockBuilder(this, code);
            return this;
        }

        public CodeBuilder EndBlock(string? context = null)
        {
            if (_blockStack.Count == 0)
                throw new InvalidOperationException("No more blocks to end.");
            string? poppedContext = _blockStack.Pop();
            if (!string.Equals(context, poppedContext, StringComparison.Ordinal))
                throw new InvalidOperationException($"Current block being ended '{poppedContext ?? "[NULL]"}' does match the requested context '{context ?? "[NULL]"}'.");
            _language.EndBlockBuilder(this);
            return this;
        }

        public CodeBuilder Comment(params CodeLine[] comments)
        {
            foreach (CodeLine comment in comments)
                _language.CommentBuilder(this, comment);
            return this;
        }

        public CodeBuilder Comment(IEnumerable<CodeLine> comments)
        {
            foreach (CodeLine comment in comments)
                _language.CommentBuilder(this, comment);
            return this;
        }

        public CodeBuilder MultiLineComment(params CodeLine[] comments)
        {
            _language.MultiLineCommentBuilder(this, comments);
            return this;
        }

        public CodeBuilder MultiLineComment(IEnumerable<CodeLine> comments)
        {
            _language.MultiLineCommentBuilder(this, comments);
            return this;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }

        private string GetIndent()
        {
            return new string(' ', _indentLevel * _language.IndentSize);
        }
    }
}
