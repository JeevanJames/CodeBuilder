// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

/// <summary>
///     Represents a boolean condition, either as a boolean value or a predicate delegate.
/// </summary>
public readonly struct Condition
{
    private readonly Func<bool>? _predicate;

    // We use the inverse condition here, since we want the default condition to be true when a variable
    // of this type is assigned to default. In such a case, it would always assign the condition to
    // false, and there is no way to set it to true, even with a parameterless constructor, which is
    // not called when assigning to default.
    private readonly bool _inverseCondition;

    private Condition(bool condition)
    {
        _predicate = null;
        _inverseCondition = !condition;
    }

    private Condition(Func<bool> predicate)
    {
        _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
    }

    public bool Evaluate() => _predicate is not null ? _predicate() : !_inverseCondition;

    public static implicit operator Condition(bool condition) => new(condition);

    public static implicit operator Condition(Func<bool> predicate) => new(predicate);
}
