using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBuilder.Core
{
    public class CodeBuilder
    {
        private int _indentLevel = 0;

        protected StringBuilder Builder { get; } = new StringBuilder();

        public CodeBuilder Blank()
        {
            Builder.AppendLine();
            return this;
        }

        public CodeBuilder Indent()
        {
            _indentLevel++;
            return this;
        }

        public CodeBuilder Unindent()
        {
            if (_indentLevel == 0)
                throw new InvalidOperationException("Cannot decrease indent level below zero.");
            _indentLevel--;
            return this;
        }

        public CodeBuilder Line(string code)
        {
            if (_indentLevel == 0)
                Builder.AppendLine(code);
            else
                Builder.AppendLine($"{new string(' ', _indentLevel * 4)}{code}");
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

        public override string ToString()
        {
            return Builder.ToString();
        }
    }
}
