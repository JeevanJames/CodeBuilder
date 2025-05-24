#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder._(Condition) Method

Adds a new line to the code being built, optionally based on a condition.

```csharp
public NCodeBuilder.CodeBuilder _(NCodeBuilder.Condition condition=default(NCodeBuilder.Condition));
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder._(NCodeBuilder.Condition).condition'></a>

`condition` [Condition](NCodeBuilder.Condition.md 'NCodeBuilder.Condition')

An optional condition that determines whether the new line should be added.  If [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'),  
the new line is always added. If provided, the new line is added only if the condition evaluates to  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
The current [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance, allowing for method chaining.

### Remarks
If the builder is not in a state where it can emit code, no action is taken, and the current  
instance is returned.