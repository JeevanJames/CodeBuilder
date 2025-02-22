﻿// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

/// <summary>
///     Base class for inner builder classes - which construct well known statements in a strongly-typed
///     manner.
/// </summary>
public abstract class InnerBuilder
{
    protected InnerBuilder(CodeBuilder builder)
    {
        Builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    protected CodeBuilder Builder { get; }

    public virtual CodeBuilder Done() => Builder;

    public CodeBuilder _ => Done();
}
