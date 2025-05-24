// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

/// <summary>
///     Provides a fluent API for building inline code snippets with conditional and repeated content.
/// </summary>
/// <remarks>
///     This class is designed to simplify the construction of inline code by allowing conditional appending
///     of strings, repeated operations over collections, and chaining of operations. It works in conjunction
///     with the <see cref="CodeBuilder"/> class to manage the underlying string construction.
/// </remarks>
public sealed class InlineCodeBuilder
{
    private readonly CodeBuilder _builder;

    internal InlineCodeBuilder(CodeBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        _builder.StringBuilder((sb, cb) => sb.Append(cb!.GetIndent()), state: builder);
    }

    internal InlineCodeBuilder(CodeBuilder builder, string? str, Condition condition)
        : this(builder)
    {
        _(str, condition);
    }

    public InlineCodeBuilder _(string? str, Condition condition = default)
    {
        if (condition.Evaluate() && str is not null)
            _builder.StringBuilder(sb => sb.Append(str), condition);
        return this;
    }

    public InlineCodeBuilder __
    {
        get
        {
            _builder.StringBuilder(sb => sb.Append(' '));
            return this;
        }
    }

    public InlineCodeBuilder Repeat<T>(IEnumerable<T> collection,
        Action<InlineCodeBuilder, RepeatState<T>> action)
    {
        int index = 0;

        foreach (T item in collection)
        {
            action(this, new RepeatState<T>(collection, item, index));
            index++;
        }

        return this;
    }

    public CodeBuilder Done() => _builder.StringBuilder(sb => sb.AppendLine());
}
