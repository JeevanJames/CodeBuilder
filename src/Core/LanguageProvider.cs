// Copyright (c) 2019-25 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using System.Diagnostics;

namespace NCodeBuilder;

/// <summary>
///     Provides language-specific enhancements to the <see cref="CodeBuilder"/>. This includes
///     default indentation size, support for various kinds of comments (single-line, multi-line and
///     documentation comments) and code blocks.
/// </summary>
[DebuggerDisplay("Language provider for {Name,nq}")]
public partial record LanguageProvider
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LanguageProvider"/> class with the
    ///     specified <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The name of the language supported by this provider.</param>
    public LanguageProvider(string name)
    {
        Name = name;
    }

    /// <summary>
    ///     Gets the name of the language supported by this provider.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Gets or sets the indentation size.
    /// </summary>
    public int IndentSize { get; set; }

    /// <summary>
    ///     Gets or sets the delegate that is used to add single-line comments to the code.
    /// </summary>
    public Action<CodeBuilder, CodeLine> CommentBuilder { get; set; } =
        (_, _) => throw new InvalidOperationException("Current language provider does not provide a single-line comment builder.");

    /// <summary>
    ///     Gets or sets the delegate that is used to add multi-line comments to the code.
    ///     <para/>
    ///     The default implementation calls the single-line comment generator multiple times.
    /// </summary>
    public Action<CodeBuilder, IEnumerable<CodeLine>> MultiLineCommentBuilder { get; set; } =
        (cb, comments) => cb.Comment(comments);

    /// <summary>
    ///     Gets or sets the delegate that is used to add documentation comments to the code.
    ///     <para/>
    ///     The default implementation calls the multi-line comment generator.
    /// </summary>
    public Action<CodeBuilder, IEnumerable<CodeLine>> DocumentationCommentBuilder { get; set; } =
        (cb, comments) => cb.MultiLineComment(comments);

    /// <summary>
    ///     Gets or sets the delegate that is used to start a code block in the code.
    /// </summary>
    public Action<CodeBuilder, CodeLine?> StartBlockBuilder { get; set; } =
        (cb, line) => _ = cb.Indent;

    /// <summary>
    ///     Gets or sets the delegate that is used to end a code block in the code.
    /// </summary>
    public Action<CodeBuilder> EndBlockBuilder { get; set; } = cb => _ = cb.Unindent;
}
