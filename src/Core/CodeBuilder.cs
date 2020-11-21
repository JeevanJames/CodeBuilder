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
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCodeBuilder
{
    /// <summary>
    ///     Generates code by concatenating smaller code blocks.
    ///     <para/>
    ///     Similar to a <see cref="StringBuilder"/>, but with code-specific methods.
    /// </summary>
    [DebuggerDisplay("Code Builder for {_language.Name,nq}")]
    public sealed class CodeBuilder
    {
        private readonly StringBuilder _builder = new();
        private readonly LanguageProvider _language;
        private readonly Stack<string?> _blockStack = new();
        private int _indentLevel = 0;

        /// <summary>
        ///     Initializes an instance of the <see cref="CodeBuilder"/> class with the specific
        ///     <paramref name="language"/> provider.
        /// </summary>
        /// <param name="language">
        ///     A <see cref="LanguageProvider"/> that provides language-specific code generation
        ///     enhancements.
        ///     <para/>
        ///     If not specified, then the <see cref="LanguageProvider.NoLanguage"/> provider is used,
        ///     which does not provide any language enhancements.
        /// </param>
        public CodeBuilder(LanguageProvider? language = null)
        {
            _language = language ?? LanguageProvider.NoLanguage;
        }

        /// <summary>
        ///     Adds a blank line.
        /// </summary>
        public CodeBuilder Blank
        {
            get
            {
                _builder.AppendLine();
                return this;
            }
        }

        /// <summary>
        ///     Indents the code by a level.
        /// </summary>
        public CodeBuilder Indent
        {
            get
            {
                _indentLevel++;
                return this;
            }
        }

        /// <summary>
        ///     Unindents the code by a level.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if an attempt is made to unindent below 0.
        /// </exception>
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

        /// <summary>
        ///     Adds a line of <paramref name="code"/>. If the code is <c>null</c>, nothing is added.
        /// </summary>
        /// <param name="code">
        ///     The code line to add.
        ///     <para/>
        ///     This can either be a <see cref="string"/> or a factory delegate
        ///     (<see cref="CodeFactory"/>) that returns a string.
        /// </param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
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

        /// <summary>
        ///     Adds a line of <paramref name="code"/> if the specified <paramref name="predicate"/> is
        ///     <c>true</c>.
        /// </summary>
        /// <param name="code">
        ///     The code line to add.
        ///     <para/>
        ///     This can either be a <see cref="string"/> or a factory delegate
        ///     (<see cref="CodeFactory"/>) that returns a string.
        /// </param>
        /// <param name="predicate">The predicate to test.</param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Line(CodeLine code, Func<bool> predicate)
        {
            if (predicate())
                Line(code);
            return this;
        }

        /// <summary>
        ///     Adds a line of <paramref name="code"/> if the specified <paramref name="condition"/> is
        ///     <c>true</c>.
        /// </summary>
        /// <param name="code">
        ///     The code line to add.
        ///     <para/>
        ///     This can either be a <see cref="string"/> or a factory delegate
        ///     (<see cref="CodeFactory"/>) that returns a string.
        /// </param>
        /// <param name="condition">The condition to test.</param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Line(CodeLine code, bool condition)
        {
            if (condition)
                Line(code);
            return this;
        }

        /// <summary>
        ///     Iterates over a <paramref name="collection"/> and executes the specified
        ///     <paramref name="action"/> on each item.
        /// </summary>
        /// <typeparam name="T">The type of item in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection to iterate over.</param>
        /// <param name="action">
        ///     The action to execute. This action accepts two parameters - the
        ///     <see cref="CodeBuilder"/> instance and the item itself.
        /// </param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Repeat<T>(IEnumerable<T> collection, Action<CodeBuilder, T> action)
        {
            foreach (T item in collection)
                action(this, item);
            return this;
        }

        /// <summary>
        ///     Iterates over a <paramref name="collection"/> and executes the specified
        ///     <paramref name="action"/> on each item.
        /// </summary>
        /// <typeparam name="T">The type of item in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection to iterate over.</param>
        /// <param name="action">
        ///     The action to execute. This action accepts three parameters - the
        ///     <see cref="CodeBuilder"/> instance, the item itself and the index of the item in the
        ///     collection.
        /// </param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Repeat<T>(IEnumerable<T> collection, Action<CodeBuilder, T, int> action)
        {
            int index = 0;
            foreach (T item in collection)
            {
                action(this, item, index);
                index++;
            }
            return this;
        }

        /// <summary>
        ///     Iterates over all public, non-indexer properties in the specified <paramref name="obj"/>
        ///     and executes the specified <paramref name="action"/> on each property.
        /// </summary>
        /// <param name="obj">The object to iterate over.</param>
        /// <param name="action">
        ///     The action to execute. This action accepts three parameters - the
        ///     <see cref="CodeBuilder"/> instance, the property name and the property value.
        /// </param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Iterate(object obj, Action<CodeBuilder, string, object> action)
        {
            if (obj is null)
                return this;

            IEnumerable<PropertyInfo> properties = obj.GetType().GetProperties()
                .Where(pi => pi.CanRead && pi.GetIndexParameters().Length == 0);
            foreach (PropertyInfo property in properties)
                action(this, property.Name, property.GetValue(obj));

            return this;
        }

        /// <summary>
        ///     Starts a new code block. This is language-specific and what exactly happens depends on
        ///     the implementation in the underlying language provider.
        /// </summary>
        /// <param name="code">
        ///     Optional code associated with the code block. Some languages may need this.
        ///     <para/>
        ///     For example, in C#, an <c>if</c> block needs to specify the condition to check before
        ///     starting the block.
        ///     <para/>
        ///     This can either be a <see cref="string"/> or a factory delegate
        ///     (<see cref="CodeFactory"/>) that returns a string.
        /// </param>
        /// <param name="context">
        ///     An optional name for the block, which can be checked when the
        ///     <see cref="EndBlock(string?)"/> method is called to close the block to ensure that the
        ///     correct block is being closed.
        /// </param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Block(CodeLine? code = null, string? context = null)
        {
            _blockStack.Push(context);
            _language.StartBlockBuilder(this, code);
            return this;
        }

        /// <summary>
        ///     Closes an existing code block created using the <see cref="Block(CodeLine?, string?)"/>
        ///     method. This is language-specific and what exactly happens depends on the implementation
        ///     in the underlying language provider.
        /// </summary>
        /// <param name="context">
        ///     An optional name for the block, which needs to match against the name specified in the
        ///     <see cref="Block"/> method. This will ensure that this method is closing the correct
        ///     block.
        /// </param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if the method is called without aexisting block, or if the specified
        ///     <paramref name="context"/> does not match the block's context.
        /// </exception>
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

        /// <summary>
        ///     Adds one or more single line comments. This is language-specific and what exactly
        ///     happens depends on the implementation in the underlying language provider.
        /// </summary>
        /// <param name="comments">The single line comments to add.</param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Comment(params CodeLine[] comments)
        {
            foreach (CodeLine comment in comments)
                _language.CommentBuilder(this, comment);
            return this;
        }

        /// <summary>
        ///     Adds one or more single line comments. This is language-specific and what exactly
        ///     happens depends on the implementation in the underlying language provider.
        /// </summary>
        /// <param name="comments">The single line comments to add.</param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder Comment(IEnumerable<CodeLine> comments)
        {
            foreach (CodeLine comment in comments)
                _language.CommentBuilder(this, comment);
            return this;
        }

        /// <summary>
        ///     Adds a multi-line comment with the specified <paramref name="comments"/> lines. This is
        ///     language-specific and what exactly happens depends on the implementation in the
        ///     underlying language provider.
        /// </summary>
        /// <param name="comments">The lines to add in the multi-line comment.</param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder MultiLineComment(params CodeLine[] comments)
        {
            _language.MultiLineCommentBuilder(this, comments);
            return this;
        }

        /// <summary>
        ///     Adds a multi-line comment with the specified <paramref name="comments"/> lines. This is
        ///     language-specific and what exactly happens depends on the implementation in the
        ///     underlying language provider.
        /// </summary>
        /// <param name="comments">The lines to add in the multi-line comment.</param>
        /// <returns>
        ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
        /// </returns>
        public CodeBuilder MultiLineComment(IEnumerable<CodeLine> comments)
        {
            _language.MultiLineCommentBuilder(this, comments);
            return this;
        }

        /// <summary>
        ///     Generates the code.
        /// </summary>
        /// <returns>The code.</returns>
        public override string ToString()
        {
            return _builder.ToString();
        }

        private string GetIndent()
        {
            // As an optimization, we call string.Intern to ensure that the same string instances are
            // used for the same indentation levels. This is because new string() creates a separate
            // instance of the same indent string.
            return string.Intern(new string(' ', _indentLevel * _language.IndentSize));
        }
    }
}
