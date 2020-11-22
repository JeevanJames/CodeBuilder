#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.EndBlock(string?) Method
Closes an existing code block created using the [Block(System.Nullable&lt;NCodeBuilder.CodeLine&gt;, string?)](./NCodeBuilder-CodeBuilder-Block(System-Nullable-NCodeBuilder-CodeLine-_string-).md 'NCodeBuilder.CodeBuilder.Block(System.Nullable&lt;NCodeBuilder.CodeLine&gt;, string?)')  
method. This is language-specific and what exactly happens depends on the implementation  
in the underlying language provider.  
```csharp
public NCodeBuilder.CodeBuilder EndBlock(string? context=null);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-EndBlock(string-)-context'></a>
`context` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
An optional name for the block, which needs to match against the name specified in the  
[Block(System.Nullable&lt;NCodeBuilder.CodeLine&gt;, string?)](./NCodeBuilder-CodeBuilder-Block(System-Nullable-NCodeBuilder-CodeLine-_string-).md 'NCodeBuilder.CodeBuilder.Block(System.Nullable&lt;NCodeBuilder.CodeLine&gt;, string?)') method. This will ensure that this method is closing the correct  
block.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Thrown if the method is called without an existing block, or if the specified  
[context](#NCodeBuilder-CodeBuilder-EndBlock(string-)-context 'NCodeBuilder.CodeBuilder.EndBlock(string?).context') does not match the block's context.  
