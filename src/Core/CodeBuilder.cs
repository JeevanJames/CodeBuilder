using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder.Core
{
    public sealed class CodeBuilder
    {
        private readonly StringBuilder _builder = new StringBuilder();
        private readonly LanguageProvider _language;
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

        public CodeBuilder Line(string code)
        {
            if (_indentLevel == 0)
                _builder.AppendLine(code);
            else
                _builder.AppendLine($"{GetIndent()}{code}");
            return this;
        }

        public CodeBuilder Line(string code, Func<bool> predicate)
        {
            if (predicate())
                Line(code);
            return this;
        }

        public CodeBuilder Line(string code, bool condition)
        {
            if (condition)
                Line(code);
            return this;
        }

        public CodeBuilder Line(Func<string> lineBuilder)
        {
            string line = lineBuilder();
            return Line(line, line is not null);
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

        public CodeBuilder Block(string? code = null)
        {
            _language.StartBlockBuilder(this, code);
            return this;
        }

        public CodeBuilder EndBlock()
        {
            _language.EndBlockBuilder(this);
            return this;
        }

        public CodeBuilder Comment(params string[] comments)
        {
            foreach (string comment in comments)
                _language.CommentBuilder(this, comment);
            return this;
        }

        public CodeBuilder Comment(IEnumerable<string> comments)
        {
            foreach (string comment in comments)
                _language.CommentBuilder(this, comment);
            return this;
        }

        public CodeBuilder MultiLineComment(params string[] comments)
        {
            _language.MultiLineCommentBuilder(this, comments);
            return this;
        }

        public CodeBuilder MultiLineComment(IEnumerable<string> comments)
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
