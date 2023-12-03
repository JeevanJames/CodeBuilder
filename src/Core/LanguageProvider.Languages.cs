// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

using NCodeBuilder.CLanguageFamily;

namespace NCodeBuilder;

public partial record LanguageProvider
{
    /// <summary>
    ///     A <see cref="LanguageProvider"/> that does not represent any language. In other words, a
    ///     no-op language provider, where all builder property implementations are no-ops.
    ///     <para/>
    ///     Use this language provider, if you do not want any language specific enhancements.
    /// </summary>
    public static readonly LanguageProvider NoLanguage = new LanguageProvider("No Language")
    {
        CommentBuilder = (_, _) => { },
    };

    public static LanguageProvider CLanguageFamily(CLanguageBraceStyle braceStyle = CLanguageBraceStyle.NextLine)
    {
        return new CLanguageFamilyProvider(braceStyle: braceStyle);
    }

    public static LanguageProvider CSharp(CLanguageBraceStyle braceStyle = CLanguageBraceStyle.NextLine)
    {
        return new CLanguageFamilyProvider("C#", braceStyle)
        {
            DocumentationCommentBuilder = (cb, comments) => cb
                ._("/// <summary>")
                .Repeat(comments, (cb2, s) => cb2._($"///     {s.Item}"))
                ._("/// </summary>"),
        };
    }

    public static LanguageProvider Python = new LanguageProvider("Python")
    {
        IndentSize = 4,
        CommentBuilder = (cb, comment) => cb._($"# {comment}"),
        DocumentationCommentBuilder = (cb, comments) => cb
            .Repeat(comments, static (cb2, s) => cb2
                .Inline(@""""""" ", s.IsFirst)
                ._(s.Item.ToString())
                ._(@" """"""", s.Count == 1)
                .Done())
            ._(@"""""""", comments.Count() > 1),
        StartBlockBuilder = (cb, code) => _ = cb._(code.ToString()).Indent,
        EndBlockBuilder = cb => _ = cb.Unindent,
    };

    /// <summary>
    ///     A <see cref="LanguageProvider"/> that represents text content. There is no support for
    ///     comments, but blocks are supported by indentation.
    /// </summary>
    /// <param name="indentSize">The indentation size to use for blocks. Defaults to 4.</param>
    /// <returns>A <see cref="LanguageProvider"/> instance/</returns>
    public static LanguageProvider Text(int indentSize = 4) => new LanguageProvider("Text")
    {
        IndentSize = indentSize,
        CommentBuilder = (_, _) => { },
        MultiLineCommentBuilder = (_, _) => { },
        DocumentationCommentBuilder = (_, _) => { },
        StartBlockBuilder = (cb, code) => cb.Indent._(code.ToString()),
        EndBlockBuilder = cb => _ = cb.Unindent,
    };
}
