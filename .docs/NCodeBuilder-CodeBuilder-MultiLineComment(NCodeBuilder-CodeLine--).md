#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.MultiLineComment(NCodeBuilder.CodeLine[]) Method
Adds a multi-line comment with the specified [comments](#NCodeBuilder-CodeBuilder-MultiLineComment(NCodeBuilder-CodeLine--)-comments 'NCodeBuilder.CodeBuilder.MultiLineComment(NCodeBuilder.CodeLine[]).comments') lines. This is  
language-specific and what exactly happens depends on the implementation in the  
underlying language provider.  
```csharp
public NCodeBuilder.CodeBuilder MultiLineComment(params NCodeBuilder.CodeLine[] comments);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-MultiLineComment(NCodeBuilder-CodeLine--)-comments'></a>
`comments` [CodeLine](./NCodeBuilder-CodeLine.md 'NCodeBuilder.CodeLine')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The lines to add in the multi-line comment.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
