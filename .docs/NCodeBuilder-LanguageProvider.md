#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder')
## LanguageProvider Class
Provides language-specific enhancements to the [CodeBuilder](./NCodeBuilder-CodeBuilder.md 'NCodeBuilder.CodeBuilder'). This includes  
default indentation size, support for various kinds of comments (single-line, multi-line and  
documentation comments) and code blocks.  
```csharp
public class LanguageProvider
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LanguageProvider  

Derived  
&#8627; [CLanguageFamilyProvider](./NCodeBuilder-CLanguageFamily-CLanguageFamilyProvider.md 'NCodeBuilder.CLanguageFamily.CLanguageFamilyProvider')  
### Constructors
- [LanguageProvider(string)](./NCodeBuilder-LanguageProvider-LanguageProvider(string).md 'NCodeBuilder.LanguageProvider.LanguageProvider(string)')
### Fields
- [NoLanguage](./NCodeBuilder-LanguageProvider-NoLanguage.md 'NCodeBuilder.LanguageProvider.NoLanguage')
### Properties
- [CommentBuilder](./NCodeBuilder-LanguageProvider-CommentBuilder.md 'NCodeBuilder.LanguageProvider.CommentBuilder')
- [DocumentationCommentBuilder](./NCodeBuilder-LanguageProvider-DocumentationCommentBuilder.md 'NCodeBuilder.LanguageProvider.DocumentationCommentBuilder')
- [EndBlockBuilder](./NCodeBuilder-LanguageProvider-EndBlockBuilder.md 'NCodeBuilder.LanguageProvider.EndBlockBuilder')
- [IndentSize](./NCodeBuilder-LanguageProvider-IndentSize.md 'NCodeBuilder.LanguageProvider.IndentSize')
- [MultiLineCommentBuilder](./NCodeBuilder-LanguageProvider-MultiLineCommentBuilder.md 'NCodeBuilder.LanguageProvider.MultiLineCommentBuilder')
- [Name](./NCodeBuilder-LanguageProvider-Name.md 'NCodeBuilder.LanguageProvider.Name')
- [StartBlockBuilder](./NCodeBuilder-LanguageProvider-StartBlockBuilder.md 'NCodeBuilder.LanguageProvider.StartBlockBuilder')
### Methods
- [Text(int)](./NCodeBuilder-LanguageProvider-Text(int).md 'NCodeBuilder.LanguageProvider.Text(int)')
