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

using System.Collections.Generic;
using System.Linq;

namespace NCodeBuilder
{
    /// <summary>
    ///     Represents the state of an iteration in the <c>Repeat</c> methods.
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection being iterated.</typeparam>
    public readonly struct RepeatState<T>
    {
        internal RepeatState(IEnumerable<T> collection, T item, int index)
        {
            Collection = collection;
            Item = item;
            Index = index;
        }

        /// <summary>
        ///     Gets the reference to the collection being iterated over.
        ///     <para/>
        ///     Use this property instead of directly accessing the collection to prevent unnecessary
        ///     closures.
        /// </summary>
        public IEnumerable<T> Collection { get; }

        /// <summary>
        ///     Gets the current iterated item in the collection.
        /// </summary>
        public T Item { get; }

        /// <summary>
        ///     Gets the index of the current iterated item in the collection.
        /// </summary>
        public int Index { get; }

        /// <summary>
        ///     Gets the number of items in the collection.
        /// </summary>
        public int Count => Collection is ICollection<T> coll ? coll.Count : Collection.Count();

        /// <summary>
        ///     Gets a value indicating whether the current iteration item is the first item in the
        ///     collection.
        /// </summary>
        public bool IsFirst => Index == 0;

        /// <summary>
        ///     Gets a value indicating whether the current iteration item is the last item in the
        ///     collection.
        /// </summary>
        public bool IsLast => Index == Count - 1;
    }
}
