#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Line(NCodeBuilder.CodeLine, bool) Method
Adds a line of [code](#NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_bool)-code 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine, bool).code') if the specified [condition](#NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_bool)-condition 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine, bool).condition') is  
`true`.  
```csharp
public NCodeBuilder.CodeBuilder Line(NCodeBuilder.CodeLine code, bool condition);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_bool)-code'></a>
`code` [CodeLine](./NCodeBuilder-CodeLine.md 'NCodeBuilder.CodeLine')  
The code line to add.  





This can either be a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') or a factory delegate  
([CodeFactory()](./NCodeBuilder-CodeFactory().md 'NCodeBuilder.CodeFactory()')) that returns a string.  
  
<a name='NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_bool)-condition'></a>
`condition` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
The condition to test.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
