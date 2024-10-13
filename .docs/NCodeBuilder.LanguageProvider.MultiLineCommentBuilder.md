#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider')

## LanguageProvider.MultiLineCommentBuilder Property

Gets or sets the delegate that is used to add multi-line comments to the code.  
The default implementation calls the single-line comment generator multiple times.

```csharp
public System.Action<NCodeBuilder.CodeBuilder,System.Collections.Generic.IEnumerable<NCodeBuilder.CodeLine>> MultiLineCommentBuilder { get; set; }
```

#### Property Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')