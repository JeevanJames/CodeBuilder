#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder._(CodeLine, Func<bool>) Method

Adds a line of [code](NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,System.Func_bool_).md#NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,System.Func_bool_).code 'NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine, System.Func<bool>).code') if the specified [predicate](NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,System.Func_bool_).md#NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,System.Func_bool_).predicate 'NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine, System.Func<bool>).predicate') is  
`true`.

```csharp
public NCodeBuilder.CodeBuilder _(NCodeBuilder.CodeLine code, System.Func<bool> predicate);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,System.Func_bool_).code'></a>

`code` [CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')

The code line to add.  
This can either be a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') or a factory delegate  
([CodeFactory()](NCodeBuilder.CodeFactory().md 'NCodeBuilder.CodeFactory()')) that returns a string.

<a name='NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,System.Func_bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The predicate to test.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.