// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

public sealed class InlineCodeBuilder
{
    private readonly CodeBuilder _builder;

    internal InlineCodeBuilder(CodeBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        _builder.StringBuilder((sb, cb) => sb.Append(cb!.GetIndent()), state: builder);
    }

    internal InlineCodeBuilder(CodeBuilder builder, string? str, bool condition)
        : this(builder)
    {
        _(str, condition);
    }

    internal InlineCodeBuilder(CodeBuilder builder, string? str, Func<bool> predicate)
        : this(builder)
    {
        _(str, predicate);
    }

    public InlineCodeBuilder _(string? str, bool condition = true)
    {
        if (condition && str is not null)
            _builder.StringBuilder(sb => sb.Append(str), condition);
        return this;
    }

    public InlineCodeBuilder _(string? str, Func<bool> predicate)
    {
        if (str is not null && predicate())
            _builder.StringBuilder(sb => sb.Append(str), predicate);
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

    public CodeBuilder Done()
    {
        return _builder.StringBuilder(sb => sb.AppendLine());
    }
}
