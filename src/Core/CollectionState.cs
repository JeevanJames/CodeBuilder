// Copyright (c) 2019-23 Jeevan James
// Licensed under the Apache License, Version 2. See LICENSE file in the project root for full license information.

namespace NCodeBuilder;

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

public readonly struct DictionaryRepeatState<TKey, TValue>
{
    internal DictionaryRepeatState(IDictionary<TKey, TValue> dictionary, TKey key, TValue value, int index)
    {
        Dictionary = dictionary;
        Key = key;
        Value = value;
        Index = index;
    }

    /// <summary>
    ///     Gets the reference to the collection being iterated over.
    ///     <para/>
    ///     Use this property instead of directly accessing the collection to prevent unnecessary
    ///     closures.
    /// </summary>
    public IDictionary<TKey, TValue> Dictionary { get; }

    /// <summary>
    ///     Gets the current iterated item in the collection.
    /// </summary>
    public TKey Key { get; }

    public TValue Value { get; }

    /// <summary>
    ///     Gets the index of the current iterated item in the collection.
    /// </summary>
    public int Index { get; }

    /// <summary>
    ///     Gets the number of items in the collection.
    /// </summary>
    public int Count => Dictionary.Count;

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
