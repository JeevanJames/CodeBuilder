#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Line(NCodeBuilder.CodeLine) Method
Adds a line of [code](#NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine)-code 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine).code'). If the code is `null`, nothing is added.  
```csharp
public NCodeBuilder.CodeBuilder Line(NCodeBuilder.CodeLine code);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine)-code'></a>
`code` [CodeLine](./NCodeBuilder-CodeLine.md 'NCodeBuilder.CodeLine')  
The code line to add.  





This can either be a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') or a factory delegate  
([CodeFactory()](./NCodeBuilder-CodeFactory().md 'NCodeBuilder.CodeFactory()')) that returns a string.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
