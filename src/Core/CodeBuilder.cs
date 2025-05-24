// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace NCodeBuilder;

/// <summary>
///     Generates code by concatenating smaller code blocks.
///     <para/>
///     Similar to a <see cref="System.Text.StringBuilder"/>, but with code-specific methods.
/// </summary>
/// <remarks>
///     Initializes an instance of the <see cref="CodeBuilder"/> class with the specific
///     <paramref name="language"/> provider.
/// </remarks>
/// <param name="language">
///     A <see cref="LanguageProvider"/> that provides language-specific code generation
///     enhancements.
///     <para/>
///     If not specified, then the <see cref="LanguageProvider.NoLanguage"/> provider is used,
///     which does not provide any language enhancements.
/// </param>
[DebuggerDisplay("Code Builder for {_language.Name,nq}")]
public sealed class CodeBuilder(LanguageProvider? language = null)
{
    private readonly StringBuilder _builder = new();
    private readonly LanguageProvider _language = language ?? LanguageProvider.NoLanguage;
    private readonly Stack<string?> _blockStack = new();
    private readonly Stack<bool> _sectionStack = new();

    // Indicates whether code can be emitted. Set to false when in a conditional block that evaluates
    // to false.
    private bool _canEmit = true;

    private int _indentLevel;

    /// <summary>
    ///     Adds a blank line.
    /// </summary>
    public CodeBuilder _____
    {
        get
        {
            if (_canEmit)
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
            if (!_canEmit)
                return this;

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
            if (!_canEmit)
                return this;

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
    /// <param name="condition">Condition that determines whether to add the line.</param>
    /// <returns>
    ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
    /// </returns>
    public CodeBuilder _(CodeLine code, Condition condition = default)
    {
        if (!_canEmit)
            return this;

        if (!condition.Evaluate())
            return this;

        string? line = code.ToString();
        if (line is null)
            return this;

        if (_indentLevel > 0)
            _builder.Append(GetIndent());
        _builder.AppendLine(code.ToString());

        return this;
    }

    /// <summary>
    ///     Adds a new line to the code being built, optionally based on a condition.
    /// </summary>
    /// <remarks>
    ///     If the builder is not in a state where it can emit code, no action is taken, and the current
    ///     instance is returned.
    /// </remarks>
    /// <param name="condition">
    ///     An optional condition that determines whether the new line should be added.  If <see langword="null"/>,
    ///     the new line is always added. If provided, the new line is added only if the condition evaluates to
    ///     <see langword="true"/>.
    /// </param>
    /// <returns>The current <see cref="CodeBuilder"/> instance, allowing for method chaining.</returns>
    public CodeBuilder _(Condition condition = default)
    {
        if (!_canEmit)
            return this;

        if (!condition.Evaluate())
            return this;

        _builder.AppendLine();

        return this;
    }

    /// <summary>
    ///     Appends a line of code to the builder, optionally based on a condition.
    /// </summary>
    /// <remarks>
    ///     If the condition is provided and evaluates to <see langword="false"/>, the code line is not
    ///     appended.
    /// </remarks>
    /// <param name="code">The line of code to append.</param>
    /// <param name="condition">
    ///     An optional condition that determines whether the code line should be appended.  If <see langword="null"/>,
    ///     the  code line is always appended.
    /// </param>
    /// <returns>The current <see cref="CodeBuilder"/> instance, allowing for method chaining.</returns>
    public CodeBuilder __(CodeLine code, Condition condition = default)
    {
        if (!_canEmit)
            return this;
        if (condition.Evaluate())
            return Indent._(code).Unindent;
        return this;
    }

    /// <summary>
    ///     Creates a new <see cref="InlineCodeBuilder"/> instance for constructing inline code elements.
    /// </summary>
    /// <returns>An <see cref="InlineCodeBuilder"/> initialized with the current context.</returns>
    public InlineCodeBuilder Inline() => new(this);

    public InlineCodeBuilder Inline(string str, Condition condition = default) => new(this, str, condition);

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
    public CodeBuilder Repeat<T>(IEnumerable<T> collection, Action<CodeBuilder, RepeatState<T>> action)
    {
        if (!_canEmit)
            return this;

        int index = 0;
        foreach (T item in collection)
        {
            action(this, new RepeatState<T>(collection, item, index));
            index++;
        }

        return this;
    }

    public CodeBuilder Repeat<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
        Action<CodeBuilder, DictionaryRepeatState<TKey, TValue>> action)
    {
        if (!_canEmit)
            return this;

        int index = 0;
        foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
        {
            action(this, new DictionaryRepeatState<TKey, TValue>(dictionary, kvp.Key, kvp.Value, index));
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
    public CodeBuilder Iterate(object? obj, Action<CodeBuilder, string, object?> action)
    {
        if (!_canEmit)
            return this;

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
        if (!_canEmit)
            return this;

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
    ///     Thrown if the method is called without an existing block, or if the specified
    ///     <paramref name="context"/> does not match the block's context.
    /// </exception>
    public CodeBuilder EndBlock(string? context = null)
    {
        if (!_canEmit)
            return this;

        if (_blockStack.Count == 0)
            throw new InvalidOperationException("No more blocks to end.");
        string? poppedContext = _blockStack.Pop();
        if (!string.Equals(context, poppedContext, StringComparison.Ordinal))
            throw new InvalidOperationException($"Current block being ended '{poppedContext ?? "[NULL]"}' does match the requested context '{context ?? "[NULL]"}'.");
        _language.EndBlockBuilder(this);
        return this;
    }

    /// <summary>
    ///     Starts a conditional section, where all subsequent code is generated only if the
    ///     specified <paramref name="condition"/> is <c>true</c>, until the
    ///     <see cref="EndSection"/> method is called.
    /// </summary>
    /// <param name="condition">The condition to check.</param>
    /// <returns>
    ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
    /// </returns>
    public CodeBuilder Section(Condition condition)
    {
        _sectionStack.Push(condition.Evaluate());
        _canEmit = _sectionStack.All(s => s);
        return this;
    }

    /// <summary>
    ///     Ends a condition section started with the <see cref="Section(Condition)"/> method.
    /// </summary>
    /// <returns>
    ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
    /// </returns>
    public CodeBuilder EndSection()
    {
        if (_sectionStack.Count == 0)
            throw new InvalidOperationException("No more sections to end.");
        _sectionStack.Pop();
        _canEmit = _sectionStack.Count == 0 || _sectionStack.All(s => s);
        return this;
    }

    /// <summary>
    ///     Executes the generator delegate to generate code. Useful to break the generation code
    ///     into separate methods.
    /// </summary>
    /// <param name="generator">The delegate to run.</param>
    /// <param name="condition">The condition to test.</param>
    /// <returns>
    ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
    /// </returns>
    public CodeBuilder Generate(Action<CodeBuilder> generator, Condition condition = default)
    {
        if (generator is null)
            throw new ArgumentNullException(nameof(generator));

        if (!_canEmit)
            return this;

        if (condition.Evaluate())
            generator.Invoke(this);

        return this;
    }

    public CodeBuilder Generate<T>(Action<CodeBuilder, T> generator, T args, Condition condition = default)
    {
        if (generator is null)
            throw new ArgumentNullException(nameof(generator));

        if (!_canEmit)
            return this;

        if (condition.Evaluate())
            generator.Invoke(this, args);

        return this;
    }

    public CodeBuilder Generate(Condition condition,
        Action<CodeBuilder> trueGenerator,
        Action<CodeBuilder>? falseGenerator = null)
    {
        if (trueGenerator is null)
            throw new ArgumentNullException(nameof(trueGenerator));

        if (!_canEmit)
            return this;

        if (condition.Evaluate())
            trueGenerator.Invoke(this);
        else if (falseGenerator is not null)
            falseGenerator.Invoke(this);

        return this;
    }

    public CodeBuilder Comment(CodeFactory comment)
    {
        if (!_canEmit)
            return this;

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
    public CodeBuilder Comment(params CodeLine[] comments)
    {
        if (!_canEmit)
            return this;

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
        if (!_canEmit)
            return this;

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
        if (!_canEmit)
            return this;

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
        if (!_canEmit)
            return this;

        _language.MultiLineCommentBuilder(this, comments);
        return this;
    }

    /// <summary>
    ///     Adds a documentation comment with the specified <paramref name="comments"/> lines. This
    ///     is language-specific and what exactly happens depends on the implementation in the
    ///     underlying language provider.
    /// </summary>
    /// <param name="comments">The lines to add in the documentation comment.</param>
    /// <returns>
    ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
    /// </returns>
    public CodeBuilder DocComments(params CodeLine[] comments)
    {
        if (!_canEmit)
            return this;

        _language.DocumentationCommentBuilder(this, comments);
        return this;
    }

    /// <summary>
    ///     Adds a documentation comment with the specified <paramref name="comments"/> lines. This
    ///     is language-specific and what exactly happens depends on the implementation in the
    ///     underlying language provider.
    /// </summary>
    /// <param name="comments">The lines to add in the documentation comment.</param>
    /// <returns>
    ///     An instance of the same <see cref="CodeBuilder"/>, so that calls can be chained.
    /// </returns>
    public CodeBuilder DocComments(IEnumerable<CodeLine> comments)
    {
        if (_canEmit)
            _language.DocumentationCommentBuilder(this, comments);
        return this;
    }

    public CodeBuilder StringBuilder(Action<StringBuilder> builderAction, Condition condition = default)
    {
        if (_canEmit && condition.Evaluate())
            builderAction(_builder);
        return this;
    }

    public CodeBuilder StringBuilder<TState>(Action<StringBuilder, TState?> builderAction,
        Condition condition = default, TState? state = default)
    {
        if (_canEmit && condition.Evaluate())
            builderAction(_builder, state);
        return this;
    }

    /// <summary>
    ///     Generates the code.
    /// </summary>
    /// <returns>The code.</returns>
    public override string ToString() => _builder.ToString();

    // As an optimization, we call string.Intern to ensure that the same string instances are
    // used for the same indentation levels. This is because new string() creates a separate
    // instance of the same indent string.
    public string GetIndent() => string.Intern(new string(' ', _indentLevel * _language.IndentSize));
}
