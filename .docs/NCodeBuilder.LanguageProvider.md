#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder')

## LanguageProvider Class

Provides language-specific enhancements to the [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'). This includes  
default indentation size, support for various kinds of comments (single-line, multi-line and  
documentation comments) and code blocks.

```csharp
public class LanguageProvider :
System.IEquatable<NCodeBuilder.LanguageProvider>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LanguageProvider

Derived  
&#8627; [CLanguageFamilyProvider](NCodeBuilder.CLanguageFamily.CLanguageFamilyProvider.md 'NCodeBuilder.CLanguageFamily.CLanguageFamilyProvider')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Constructors | |
| :--- | :--- |
| [LanguageProvider(string)](NCodeBuilder.LanguageProvider.LanguageProvider(string).md 'NCodeBuilder.LanguageProvider.LanguageProvider(string)') | Initializes a new instance of the [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') class with the<br/>specified [name](NCodeBuilder.LanguageProvider.LanguageProvider(string).md#NCodeBuilder.LanguageProvider.LanguageProvider(string).name 'NCodeBuilder.LanguageProvider.LanguageProvider(string).name'). |

| Fields | |
| :--- | :--- |
| [NoLanguage](NCodeBuilder.LanguageProvider.NoLanguage.md 'NCodeBuilder.LanguageProvider.NoLanguage') | A [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') that does not represent any language. In other words, a<br/>no-op language provider, where all builder property implementations are no-ops.<br/>Use this language provider, if you do not want any language specific enhancements. |

| Properties | |
| :--- | :--- |
| [CommentBuilder](NCodeBuilder.LanguageProvider.CommentBuilder.md 'NCodeBuilder.LanguageProvider.CommentBuilder') | Gets or sets the delegate that is used to add single-line comments to the code. |
| [DocumentationCommentBuilder](NCodeBuilder.LanguageProvider.DocumentationCommentBuilder.md 'NCodeBuilder.LanguageProvider.DocumentationCommentBuilder') | Gets or sets the delegate that is used to add documentation comments to the code.<br/>The default implementation calls the multi-line comment generator. |
| [EndBlockBuilder](NCodeBuilder.LanguageProvider.EndBlockBuilder.md 'NCodeBuilder.LanguageProvider.EndBlockBuilder') | Gets or sets the delegate that is used to end a code block in the code. |
| [IndentSize](NCodeBuilder.LanguageProvider.IndentSize.md 'NCodeBuilder.LanguageProvider.IndentSize') | Gets or sets the indentation size. |
| [MultiLineCommentBuilder](NCodeBuilder.LanguageProvider.MultiLineCommentBuilder.md 'NCodeBuilder.LanguageProvider.MultiLineCommentBuilder') | Gets or sets the delegate that is used to add multi-line comments to the code.<br/>The default implementation calls the single-line comment generator multiple times. |
| [Name](NCodeBuilder.LanguageProvider.Name.md 'NCodeBuilder.LanguageProvider.Name') | Gets the name of the language supported by this provider. |
| [StartBlockBuilder](NCodeBuilder.LanguageProvider.StartBlockBuilder.md 'NCodeBuilder.LanguageProvider.StartBlockBuilder') | Gets or sets the delegate that is used to start a code block in the code. |

| Methods | |
| :--- | :--- |
| [Text(int)](NCodeBuilder.LanguageProvider.Text(int).md 'NCodeBuilder.LanguageProvider.Text(int)') | A [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') that represents text content. There is no support for<br/>comments, but blocks are supported by indentation. |
