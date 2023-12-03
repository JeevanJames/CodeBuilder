// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

/// <summary>
///     Represents a line of code, either as a string value or a factory that dynamically creates
///     the code.
/// </summary>
public readonly struct CodeLine
{
    private readonly string? _line;
    private readonly CodeFactory? _builder;

    internal CodeLine(string line)
    {
        _line = line;
        _builder = null;
    }

    internal CodeLine(CodeFactory builder)
    {
        if (builder is null)
            throw new ArgumentNullException(nameof(builder));
        _builder = builder;
        _line = null;
    }

    public override string? ToString() => _builder is not null ? _builder() : _line;

    public static implicit operator CodeLine(string line) => new(line);

    public static implicit operator CodeLine(CodeFactory builder) => new(builder);
}

/// <summary>
///     Delegate that can be used to dynamically construct a line of code. Equivalent to a
///     <c>Func&lt;string&gt;</c>
/// </summary>
public delegate string CodeFactory();
