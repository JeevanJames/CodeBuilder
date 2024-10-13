#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder.CSharp](NCodeBuilder.CSharp.md 'NCodeBuilder.CSharp').[CSharpExtensions](NCodeBuilder.CSharp.CSharpExtensions.md 'NCodeBuilder.CSharp.CSharpExtensions')

## CSharpExtensions.Using(this CodeBuilder, string) Method

Adds a `using` statement to import a namespace.

```csharp
public static NCodeBuilder.CodeBuilder Using(this NCodeBuilder.CodeBuilder cb, string ns);
```
#### Parameters

<a name='NCodeBuilder.CSharp.CSharpExtensions.Using(thisNCodeBuilder.CodeBuilder,string).cb'></a>

`cb` [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

The [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance.

<a name='NCodeBuilder.CSharp.CSharpExtensions.Using(thisNCodeBuilder.CodeBuilder,string).ns'></a>

`ns` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The namespace to import.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
The same instance of the [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder').