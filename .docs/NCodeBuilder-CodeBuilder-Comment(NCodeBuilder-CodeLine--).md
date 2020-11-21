#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Comment(NCodeBuilder.CodeLine[]) Method
Adds one or more single line comments. This is language-specific and what exactly  
happens depends on the implementation in the underlying language provider.  
```csharp
public NCodeBuilder.CodeBuilder Comment(params NCodeBuilder.CodeLine[] comments);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Comment(NCodeBuilder-CodeLine--)-comments'></a>
`comments` [CodeLine](./NCodeBuilder-CodeLine.md 'NCodeBuilder.CodeLine')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The single line comments to add.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
