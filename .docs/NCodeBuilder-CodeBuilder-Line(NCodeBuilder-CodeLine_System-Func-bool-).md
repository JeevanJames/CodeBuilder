#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Line(NCodeBuilder.CodeLine, System.Func&lt;bool&gt;) Method
Adds a line of [code](#NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_System-Func-bool-)-code 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine, System.Func&lt;bool&gt;).code') if the specified [predicate](#NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_System-Func-bool-)-predicate 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine, System.Func&lt;bool&gt;).predicate') is  
`true`.  
```csharp
public NCodeBuilder.CodeBuilder Line(NCodeBuilder.CodeLine code, System.Func<bool> predicate);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_System-Func-bool-)-code'></a>
`code` [CodeLine](./NCodeBuilder-CodeLine.md 'NCodeBuilder.CodeLine')  
The code line to add.  





This can either be a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') or a factory delegate  
([CodeFactory()](./NCodeBuilder-CodeFactory().md 'NCodeBuilder.CodeFactory()')) that returns a string.  
  
<a name='NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_System-Func-bool-)-predicate'></a>
`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')  
The predicate to test.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
