#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder')

## RepeatState<T> Struct

Represents the state of an iteration in the `Repeat` methods.

```csharp
public readonly struct RepeatState<T>
```
#### Type parameters

<a name='NCodeBuilder.RepeatState_T_.T'></a>

`T`

The type of the items in the collection being iterated.

| Properties | |
| :--- | :--- |
| [Collection](NCodeBuilder.RepeatState_T_.Collection.md 'NCodeBuilder.RepeatState<T>.Collection') | Gets the reference to the collection being iterated over.<br/>Use this property instead of directly accessing the collection to prevent unnecessary<br/>closures. |
| [Count](NCodeBuilder.RepeatState_T_.Count.md 'NCodeBuilder.RepeatState<T>.Count') | Gets the number of items in the collection. |
| [Index](NCodeBuilder.RepeatState_T_.Index.md 'NCodeBuilder.RepeatState<T>.Index') | Gets the index of the current iterated item in the collection. |
| [IsFirst](NCodeBuilder.RepeatState_T_.IsFirst.md 'NCodeBuilder.RepeatState<T>.IsFirst') | Gets a value indicating whether the current iteration item is the first item in the<br/>collection. |
| [IsLast](NCodeBuilder.RepeatState_T_.IsLast.md 'NCodeBuilder.RepeatState<T>.IsLast') | Gets a value indicating whether the current iteration item is the last item in the<br/>collection. |
| [Item](NCodeBuilder.RepeatState_T_.Item.md 'NCodeBuilder.RepeatState<T>.Item') | Gets the current iterated item in the collection. |
