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
        CommentBuilder = (code, comment) => code.Line($"// {comment}");
        MultiLineCommentBuilder = (code, comments) => code
            .Line("/*")
            .Repeat(comments, (cb, comment) => cb.Line($"    {comment}"))
            .Line("*/");
        StartBlockBuilder = (cb, code) =>
        {
            string? line = code?.ToString();
            _ = BraceStyle switch
            {
                CLanguageBraceStyle.NextLine when line is null => cb.Line("{").Indent,
                CLanguageBraceStyle.NextLine => cb.Line(line).Line("{").Indent,
                CLanguageBraceStyle.SameLine when line is null => cb.Indent,
                CLanguageBraceStyle.SameLine => cb.Line($"{line} {{").Indent,
                _ => throw new InvalidOperationException($"Unexpected brace style specified: {BraceStyle}."),
            };
        };
        EndBlockBuilder = code => code.Unindent.Line("}");
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
