#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder.Section(Condition) Method

Starts a conditional section, where all subsequent code is generated only if the  
specified [condition](NCodeBuilder.CodeBuilder.Section(NCodeBuilder.Condition).md#NCodeBuilder.CodeBuilder.Section(NCodeBuilder.Condition).condition 'NCodeBuilder.CodeBuilder.Section(NCodeBuilder.Condition).condition') is `true`, until the  
[EndSection()](NCodeBuilder.CodeBuilder.EndSection().md 'NCodeBuilder.CodeBuilder.EndSection()') method is called.

```csharp
public NCodeBuilder.CodeBuilder Section(NCodeBuilder.Condition condition);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.Section(NCodeBuilder.Condition).condition'></a>

`condition` [Condition](NCodeBuilder.Condition.md 'NCodeBuilder.Condition')

The condition to check.

#### Returns
[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.