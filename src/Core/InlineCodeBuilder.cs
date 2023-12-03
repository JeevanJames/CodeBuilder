// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using System.Text;

namespace NCodeBuilder;

public sealed class InlineCodeBuilder
{
    private readonly CodeBuilder _builder;
    private readonly StringBuilder _inlineBuilder = new(); //TODO: Use the parent code builder's StringBuilder

    internal InlineCodeBuilder(CodeBuilder builder)
    {
        _builder = builder;
    }

    internal InlineCodeBuilder(CodeBuilder builder, string? str, bool condition)
        : this(builder)
    {
        Add(str, condition);
    }

    internal InlineCodeBuilder(CodeBuilder builder, string? str, Func<bool> predicate)
        : this(builder)
    {
        Add(str, predicate);
    }

    public InlineCodeBuilder Add(string? str, bool condition = true)
    {
        if (condition && str is not null)
            _inlineBuilder.Append(str);
        return this;
    }

    public InlineCodeBuilder _(string? str, bool condition = true)
    {
        if (condition && str is not null)
            _inlineBuilder.Append(str);
        return this;
    }

    public InlineCodeBuilder Add(string? str, Func<bool> predicate)
    {
        if (str is not null && predicate())
            _inlineBuilder.Append(str);
        return this;
    }

    public InlineCodeBuilder _(string? str, Func<bool> predicate)
    {
        if (str is not null && predicate())
            _inlineBuilder.Append(str);
        return this;
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
        _builder.Line(_inlineBuilder.ToString());
        return _builder;
    }
}
