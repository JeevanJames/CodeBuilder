#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Iterate(object, Action<CodeBuilder,string,object>) Method

Iterates over all public, non-indexer properties in the specified [obj](NCodeBuilder.CodeBuilder.Iterate(object,System.Action_NCodeBuilder.CodeBuilder,string,object_).md#NCodeBuilder.CodeBuilder.Iterate(object,System.Action_NCodeBuilder.CodeBuilder,string,object_).obj 'NCodeBuilder.CodeBuilder.Iterate(object, System.Action<NCodeBuilder.CodeBuilder,string,object>).obj')  
and executes the specified [action](NCodeBuilder.CodeBuilder.Iterate(object,System.Action_NCodeBuilder.CodeBuilder,string,object_).md#NCodeBuilder.CodeBuilder.Iterate(object,System.Action_NCodeBuilder.CodeBuilder,string,object_).action 'NCodeBuilder.CodeBuilder.Iterate(object, System.Action<NCodeBuilder.CodeBuilder,string,object>).action') on each property.

```csharp
public NCodeBuilder.CodeBuilder Iterate(object? obj, System.Action<NCodeBuilder.CodeBuilder,string,object?> action);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Iterate(object,System.Action_NCodeBuilder.CodeBuilder,string,object_).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to iterate over.

<a name='NCodeBuilder.CodeBuilder.Iterate(object,System.Action_NCodeBuilder.CodeBuilder,string,object_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-3 'System.Action`3')

The action to execute. This action accepts three parameters - the  
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance, the property name and the property value.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.