#region --- License & Copyright Notice ---
/*
CodeBuilder
Copyright (c) 2019-20 Jeevan James
All rights reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
#endregion

using System;

namespace NCodeBuilder.CLanguageFamily
{
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
                string? line = code.ToString();
                _ = BraceStyle switch
                {
                    CLanguageBraceStyle.NextLine => cb.Line(line).Line("{").Indent,
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
}
