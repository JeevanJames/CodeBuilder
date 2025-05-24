// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

/// <summary>
///     Base class for inner builder classes - which construct well known statements in a strongly-typed
///     manner.
/// </summary>
public abstract class InnerBuilder(CodeBuilder builder)
{
    protected CodeBuilder Builder { get; } = builder ?? throw new ArgumentNullException(nameof(builder));

    public virtual CodeBuilder Done() => Builder;

    public CodeBuilder _ => Done();
}
