#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.DocComments(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;) Method
Adds a documentation comment with the specified [comments](#NCodeBuilder-CodeBuilder-DocComments(System-Collections-Generic-IEnumerable-NCodeBuilder-CodeLine-)-comments 'NCodeBuilder.CodeBuilder.DocComments(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;).comments') lines. This  
is language-specific and what exactly happens depends on the implementation in the  
underlying language provider.  
```csharp
public NCodeBuilder.CodeBuilder DocComments(System.Collections.Generic.IEnumerable<NCodeBuilder.CodeLine> comments);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-DocComments(System-Collections-Generic-IEnumerable-NCodeBuilder-CodeLine-)-comments'></a>
`comments` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[CodeLine](./NCodeBuilder-CodeLine.md 'NCodeBuilder.CodeLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The lines to add in the documentation comment.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
