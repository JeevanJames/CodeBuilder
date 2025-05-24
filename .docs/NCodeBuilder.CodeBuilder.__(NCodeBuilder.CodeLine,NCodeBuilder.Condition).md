#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.__(CodeLine, Condition) Method

Appends a line of code to the builder, optionally based on a condition.

```csharp
public NCodeBuilder.CodeBuilder __(NCodeBuilder.CodeLine code, NCodeBuilder.Condition condition=default(NCodeBuilder.Condition));
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.__(NCodeBuilder.CodeLine,NCodeBuilder.Condition).code'></a>

`code` [CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')

The line of code to append.

<a name='NCodeBuilder.CodeBuilder.__(NCodeBuilder.CodeLine,NCodeBuilder.Condition).condition'></a>

`condition` [Condition](NCodeBuilder.Condition.md 'NCodeBuilder.Condition')

An optional condition that determines whether the code line should be appended.  If [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null'),  
the  code line is always appended.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
The current [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') instance, allowing for method chaining.

### Remarks
If the condition is provided and evaluates to [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool'), the code line is not  
appended.