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

using System.Linq;

using NCodeBuilder.CLanguageFamily;

namespace NCodeBuilder
{
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
                    .Line("/// <summary>")
                    .Repeat(comments, (cb2, comment) => cb2.Line($"///     {comment}"))
                    .Line("/// </summary>"),
            };
        }

        public static LanguageProvider Python = new LanguageProvider("Python")
        {
            IndentSize = 4,
            CommentBuilder = (cb, comment) => cb.Line($"# {comment}"),
            DocumentationCommentBuilder = (cb, comments) => cb
                .Repeat(comments, (cb2, comment, index) => cb2
                    .Inline(@""""""" ", index == 0)
                    .Inline(comment.ToString())
                    .Inline(@" """"""", comments.Count() == 1)
                    .Done())
                .Line(@"""""""", comments.Count() > 1),
            StartBlockBuilder = (cb, code) => _ = cb.Line(code.ToString()).Indent,
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
            StartBlockBuilder = (cb, code) => cb.Indent.Line(code.ToString()),
            EndBlockBuilder = cb => _ = cb.Unindent,
        };
    }
}
