#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Repeat<T>(IEnumerable<T>, Action<CodeBuilder,RepeatState<T>>) Method

Iterates over a [collection](NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).md#NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).collection 'NCodeBuilder.CodeBuilder.Repeat<T>(System.Collections.Generic.IEnumerable<T>, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>>).collection') and executes the specified  
[action](NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).md#NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).action 'NCodeBuilder.CodeBuilder.Repeat<T>(System.Collections.Generic.IEnumerable<T>, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>>).action') on each item.

```csharp
public NCodeBuilder.CodeBuilder Repeat<T>(System.Collections.Generic.IEnumerable<T> collection, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>> action);
```
#### Type parameters

<a name='NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).T'></a>

`T`

The type of item in the [collection](NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).md#NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).collection 'NCodeBuilder.CodeBuilder.Repeat<T>(System.Collections.Generic.IEnumerable<T>, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>>).collection').
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).collection'></a>

`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).md#NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).T 'NCodeBuilder.CodeBuilder.Repeat<T>(System.Collections.Generic.IEnumerable<T>, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The collection to iterate over.

<a name='NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[NCodeBuilder.RepeatState&lt;](NCodeBuilder.RepeatState_T_.md 'NCodeBuilder.RepeatState<T>')[T](NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).md#NCodeBuilder.CodeBuilder.Repeat_T_(System.Collections.Generic.IEnumerable_T_,System.Action_NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState_T__).T 'NCodeBuilder.CodeBuilder.Repeat<T>(System.Collections.Generic.IEnumerable<T>, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>>).T')[&gt;](NCodeBuilder.RepeatState_T_.md 'NCodeBuilder.RepeatState<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')

The action to execute. This action accepts three parameters - the  
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance, the item itself and the index of the item in the  
collection.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.