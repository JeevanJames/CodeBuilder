#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,T,int&gt;) Method
Iterates over a [collection](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-collection 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,T,int&gt;).collection') and executes the specified  
[action](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-action 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,T,int&gt;).action') on each item.  
```csharp
public NCodeBuilder.CodeBuilder Repeat<T>(System.Collections.Generic.IEnumerable<T> collection, System.Action<NCodeBuilder.CodeBuilder,T,int> action);
```
#### Type parameters
<a name='NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-T'></a>
`T`  
The type of item in the [collection](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-collection 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,T,int&gt;).collection').  
  
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-collection'></a>
`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-T 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,T,int&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The collection to iterate over.  
  
<a name='NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-action'></a>
`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')[T](#NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_T_int-)-T 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,T,int&gt;).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')  
The action to execute. This action accepts three parameters - the  
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance, the item itself and the index of the item in the  
collection.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
