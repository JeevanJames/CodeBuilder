using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuilder.Core.CLanguageFamily
{
    public class CLanguageFamilyProvider : LanguageProvider
    {
        public CLanguageFamilyProvider(CLanguageBraceStyle braceStyle = CLanguageBraceStyle.KAndR)
        {
            IndentSize = 4;
            CommentBuilder = (code, comment) => code.Line($"// {comment}");
            MultiLineCommentBuilder = (code, comments) => code
                .Line("/*")
                .Repeat(comments, (cb, comment) => cb.Line($"    {comment}"))
                .Line("*/");
            StartBlockBuilder = (cb, code) =>
            {
                if (!string.IsNullOrWhiteSpace(code))
                    cb.Line(code!);
                _ = cb.Line("{").Indent;
            };
            EndBlockBuilder = code => code.Unindent.Line("}");
        }
    }

    public enum CLanguageBraceStyle
    {
        KAndR,
        AllmanBSD,
    }
}
