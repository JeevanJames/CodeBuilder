#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.DocComments(CodeLine[]) Method

Adds a documentation comment with the specified [comments](NCodeBuilder.CodeBuilder.DocComments(NCodeBuilder.CodeLine[]).md#NCodeBuilder.CodeBuilder.DocComments(NCodeBuilder.CodeLine[]).comments 'NCodeBuilder.CodeBuilder.DocComments(NCodeBuilder.CodeLine[]).comments') lines. This  
is language-specific and what exactly happens depends on the implementation in the  
underlying language provider.

```csharp
public NCodeBuilder.CodeBuilder DocComments(params NCodeBuilder.CodeLine[] comments);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.DocComments(NCodeBuilder.CodeLine[]).comments'></a>

`comments` [CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The lines to add in the documentation comment.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.