#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Generate(Action<CodeBuilder>, Condition) Method

Executes the generator delegate to generate code. Useful to break the generation code  
into separate methods.

```csharp
public NCodeBuilder.CodeBuilder Generate(System.Action<NCodeBuilder.CodeBuilder> generator, NCodeBuilder.Condition condition=default(NCodeBuilder.Condition));
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Generate(System.Action_NCodeBuilder.CodeBuilder_,NCodeBuilder.Condition).generator'></a>

`generator` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The delegate to run.

<a name='NCodeBuilder.CodeBuilder.Generate(System.Action_NCodeBuilder.CodeBuilder_,NCodeBuilder.Condition).condition'></a>

`condition` [Condition](NCodeBuilder.Condition.md 'NCodeBuilder.Condition')

The condition to test.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.