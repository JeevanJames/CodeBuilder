#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Comment(IEnumerable<CodeLine>) Method

Adds one or more single line comments. This is language-specific and what exactly  
happens depends on the implementation in the underlying language provider.

```csharp
public NCodeBuilder.CodeBuilder Comment(System.Collections.Generic.IEnumerable<NCodeBuilder.CodeLine> comments);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Comment(System.Collections.Generic.IEnumerable_NCodeBuilder.CodeLine_).comments'></a>

`comments` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The single line comments to add.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.