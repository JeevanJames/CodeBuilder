using System;
using System.Collections.Generic;

namespace CodeBuilder.Core
{
    public class LanguageProvider
    {
        public int IndentSize { get; set; }

        public Action<CodeBuilder, string> CommentBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a single-line comment builder.");

        public Action<CodeBuilder, IEnumerable<string>> MultiLineCommentBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a multi-line comment builder.");

        public Action<CodeBuilder, IEnumerable<string>> DocumentationCommentBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a documentation comment builder.");

        public Action<CodeBuilder, string?> StartBlockBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a start block builder.");

        public Action<CodeBuilder> EndBlockBuilder { get; set; }
            = _ => throw new InvalidOperationException("Current language provider does not provide an end block builder.");
    }
}
