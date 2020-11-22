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
using System.Text;

namespace NCodeBuilder
{
    public sealed class InlineCodeBuilder
    {
        private readonly CodeBuilder _builder;
        private readonly StringBuilder _inlineBuilder = new();

        internal InlineCodeBuilder(CodeBuilder builder, string? str, bool condition)
        {
            _builder = builder;
            Inline(str, condition);
        }

        internal InlineCodeBuilder(CodeBuilder builder, string? str, Func<bool> predicate)
        {
            _builder = builder;
            Inline(str, predicate);
        }

        public InlineCodeBuilder Inline(string? str, bool condition = true)
        {
            if (condition && str is not null)
                _inlineBuilder.Append(str);
            return this;
        }

        public InlineCodeBuilder Inline(string? str, Func<bool> predicate)
        {
            if (str is not null && predicate())
                _inlineBuilder.Append(str);
            return this;
        }

        public CodeBuilder Done()
        {
            _builder.Line(_inlineBuilder.ToString());
            return _builder;
        }
    }
}
