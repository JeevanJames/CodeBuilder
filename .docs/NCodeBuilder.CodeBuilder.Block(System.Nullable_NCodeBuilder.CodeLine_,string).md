#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Block(Nullable<CodeLine>, string) Method

Starts a new code block. This is language-specific and what exactly happens depends on  
the implementation in the underlying language provider.

```csharp
public NCodeBuilder.CodeBuilder Block(System.Nullable<NCodeBuilder.CodeLine> code=null, string? context=null);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Block(System.Nullable_NCodeBuilder.CodeLine_,string).code'></a>

`code` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Optional code associated with the code block. Some languages may need this.  
For example, in C#, an `if` block needs to specify the condition to check before  
starting the block.  
This can either be a [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') or a factory delegate  
([CodeFactory()](NCodeBuilder.CodeFactory().md 'NCodeBuilder.CodeFactory()')) that returns a string.

<a name='NCodeBuilder.CodeBuilder.Block(System.Nullable_NCodeBuilder.CodeLine_,string).context'></a>

`context` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

An optional name for the block, which can be checked when the  
[EndBlock(string)](NCodeBuilder.CodeBuilder.EndBlock(string).md 'NCodeBuilder.CodeBuilder.EndBlock(string)') method is called to close the block to ensure that the  
correct block is being closed.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.