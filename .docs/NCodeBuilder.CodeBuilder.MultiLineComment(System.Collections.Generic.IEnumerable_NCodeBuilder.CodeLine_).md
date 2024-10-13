#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.MultiLineComment(IEnumerable<CodeLine>) Method

Adds a multi-line comment with the specified [comments](NCodeBuilder.CodeBuilder.MultiLineComment(System.Collections.Generic.IEnumerable_NCodeBuilder.CodeLine_).md#NCodeBuilder.CodeBuilder.MultiLineComment(System.Collections.Generic.IEnumerable_NCodeBuilder.CodeLine_).comments 'NCodeBuilder.CodeBuilder.MultiLineComment(System.Collections.Generic.IEnumerable<NCodeBuilder.CodeLine>).comments') lines. This is  
language-specific and what exactly happens depends on the implementation in the  
underlying language provider.

```csharp
public NCodeBuilder.CodeBuilder MultiLineComment(System.Collections.Generic.IEnumerable<NCodeBuilder.CodeLine> comments);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.MultiLineComment(System.Collections.Generic.IEnumerable_NCodeBuilder.CodeLine_).comments'></a>

`comments` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The lines to add in the multi-line comment.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.