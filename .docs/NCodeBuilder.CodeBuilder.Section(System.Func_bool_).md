#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Section(Func<bool>) Method

Starts a conditional section, where all subsequent code is generated only if the  
specified [predicate](NCodeBuilder.CodeBuilder.Section(System.Func_bool_).md#NCodeBuilder.CodeBuilder.Section(System.Func_bool_).predicate 'NCodeBuilder.CodeBuilder.Section(System.Func<bool>).predicate') delegate returns `true`, until the  
[EndSection()](NCodeBuilder.CodeBuilder.EndSection().md 'NCodeBuilder.CodeBuilder.EndSection()') method is called.

```csharp
public NCodeBuilder.CodeBuilder Section(System.Func<bool> predicate);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Section(System.Func_bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The predicate to check.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.