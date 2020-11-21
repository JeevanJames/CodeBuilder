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
using System.Collections.Generic;

namespace NCodeBuilder
{
    public class LanguageProvider
    {
        public int IndentSize { get; set; }

        public Action<CodeBuilder, CodeLine> CommentBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a single-line comment builder.");

        public Action<CodeBuilder, IEnumerable<CodeLine>> MultiLineCommentBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a multi-line comment builder.");

        public Action<CodeBuilder, IEnumerable<CodeLine>> DocumentationCommentBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a documentation comment builder.");

        public Action<CodeBuilder, CodeLine?> StartBlockBuilder { get; set; }
            = (_, _) => throw new InvalidOperationException("Current language provider does not provide a start block builder.");

        public Action<CodeBuilder> EndBlockBuilder { get; set; }
            = _ => throw new InvalidOperationException("Current language provider does not provide an end block builder.");
    }
}
