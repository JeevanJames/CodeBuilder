#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;) Method
Iterates over a [collection](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-collection 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;).collection') and executes the specified  
[action](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-action 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;).action') on each item.  
```csharp
public NCodeBuilder.CodeBuilder Repeat<T>(System.Collections.Generic.IEnumerable<T> collection, System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState<T>> action);
```
#### Type parameters
<a name='NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-T'></a>
`T`  
The type of item in the [collection](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-collection 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;).collection').  
  
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-collection'></a>
`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-T 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The collection to iterate over.  
  
<a name='NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-action'></a>
`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[NCodeBuilder.RepeatState&lt;](./NCodeBuilder-RepeatState-T-.md 'NCodeBuilder.RepeatState&lt;T&gt;')[T](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--)-T 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;).T')[&gt;](./NCodeBuilder-RepeatState-T-.md 'NCodeBuilder.RepeatState&lt;T&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')  
The action to execute. This action accepts three parameters - the  
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance, the item itself and the index of the item in the  
collection.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
