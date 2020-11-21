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

namespace NCodeBuilder
{
    /// <summary>
    ///     Represents a line of code, either as a string value or a factory that dynamically creates
    ///     the code.
    /// </summary>
    public readonly struct CodeLine
    {
        private readonly string? _line;
        private readonly CodeFactory? _builder;

        internal CodeLine(string line)
        {
            _line = line;
            _builder = null;
        }

        internal CodeLine(CodeFactory builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));
            _builder = builder;
            _line = null;
        }

        public override string? ToString()
        {
            return _builder is not null ? _builder() : _line;
        }

        public static implicit operator CodeLine(string line)
        {
            return new CodeLine(line);
        }

        public static implicit operator CodeLine(CodeFactory builder)
        {
            return new CodeLine(builder);
        }
    }

    /// <summary>
    ///     Delegate that can be used to dynamically construct a line of code. Equivalent to a
    ///     <c>Func&lt;string&gt;</c>
    /// </summary>
    public delegate string CodeFactory();
}
