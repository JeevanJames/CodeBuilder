#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder._(CodeLine, Condition) Method

Adds a line of [code](NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,NCodeBuilder.Condition).md#NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,NCodeBuilder.Condition).code 'NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine, NCodeBuilder.Condition).code'). If the code is `null`, nothing is added.

```csharp
public NCodeBuilder.CodeBuilder _(NCodeBuilder.CodeLine code, NCodeBuilder.Condition condition=default(NCodeBuilder.Condition));
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,NCodeBuilder.Condition).code'></a>

`code` [CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')

The code line to add.  
This can either be a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') or a factory delegate  
([CodeFactory()](NCodeBuilder.CodeFactory().md 'NCodeBuilder.CodeFactory()')) that returns a string.

<a name='NCodeBuilder.CodeBuilder._(NCodeBuilder.CodeLine,NCodeBuilder.Condition).condition'></a>

`condition` [Condition](NCodeBuilder.Condition.md 'NCodeBuilder.Condition')

Condition that determines whether to add the line.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.