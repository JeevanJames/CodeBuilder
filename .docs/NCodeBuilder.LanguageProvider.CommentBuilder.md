#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider')

## LanguageProvider.CommentBuilder Property

Gets or sets the delegate that is used to add single-line comments to the code.

```csharp
public System.Action<NCodeBuilder.CodeBuilder,NCodeBuilder.CodeLine> CommentBuilder { get; set; }
```

#### Property Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')