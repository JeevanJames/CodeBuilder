// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder.CLanguageFamily;

public record CLanguageFamilyProvider : LanguageProvider
{
    public CLanguageFamilyProvider(string name = "C Language Family",
        CLanguageBraceStyle braceStyle = CLanguageBraceStyle.NextLine)
        : base(name)
    {
        IndentSize = 4;
        CommentBuilder = (code, comment) => code._($"// {comment}");
        MultiLineCommentBuilder = (code, comments) => code
            ._("/*")
            .Repeat(comments, (cb, comment) => cb._($"    {comment}"))
            ._("*/");
        StartBlockBuilder = (cb, code) =>
        {
            string? line = code?.ToString();
            _ = BraceStyle switch
            {
                CLanguageBraceStyle.NextLine when line is null => cb._("{").Indent,
                CLanguageBraceStyle.NextLine => cb._(line)._("{").Indent,
                CLanguageBraceStyle.SameLine when line is null => cb.Indent,
                CLanguageBraceStyle.SameLine => cb._($"{line} {{").Indent,
                _ => throw new InvalidOperationException($"Unexpected brace style specified: {BraceStyle}."),
            };
        };
        EndBlockBuilder = code => code.Unindent._("}");
        BraceStyle = braceStyle;
    }

    /// <summary>
    ///     Gets or sets the brace style to use for code blocks.
    /// </summary>
    public CLanguageBraceStyle BraceStyle { get; set; }
}

public enum CLanguageBraceStyle
{
    NextLine,
    SameLine,
}
