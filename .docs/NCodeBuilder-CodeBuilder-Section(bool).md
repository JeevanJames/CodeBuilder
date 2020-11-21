#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')
## CodeBuilder.Section(bool) Method
Starts a conditional section, where all subsequent code is generated only if the  
specified [condition](#NCodeBuilder-CodeBuilder-Section(bool)-condition 'NCodeBuilder.CodeBuilder.Section(bool).condition') is `true`, until the  
[EndSection()](./NCodeBuilder-CodeBuilder-EndSection().md 'NCodeBuilder.CodeBuilder.EndSection()') method is called.  
```csharp
public NCodeBuilder.CodeBuilder Section(bool condition);
```
#### Parameters
<a name='NCodeBuilder-CodeBuilder-Section(bool)-condition'></a>
`condition` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
The condition to check.  
  
#### Returns
[CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder')  
An instance of the same [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'), so that calls can be chained.  
