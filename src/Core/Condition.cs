// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

/// <summary>
///     Represents a boolean condition, either as a boolean value or condition, or a predicate delegate.
/// </summary>
public sealed class Condition
{
    private readonly Func<bool>? _predicate;
    private readonly bool _condition;

    private Condition(bool condition)
    {
        _predicate = null;
        _condition = condition;
    }

    private Condition(Func<bool> predicate)
    {
        _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
    }

    public bool Evaluate() => _predicate is not null ? _predicate() : _condition;

    public static implicit operator Condition(bool condition) => new Condition(condition);

    public static implicit operator Condition(Func<bool> predicate) => new Condition(predicate);
}
