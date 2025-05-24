#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder')

## CodeBuilder(LanguageProvider) Constructor

Generates code by concatenating smaller code blocks.  
Similar to a [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder'), but with code-specific methods.

```csharp
public CodeBuilder(NCodeBuilder.LanguageProvider? language=null);
```
#### Parameters

<a name='NCodeBuilder.CodeBuilder.CodeBuilder(NCodeBuilder.LanguageProvider).language'></a>

`language` [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider')

A [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') that provides language-specific code generation  
enhancements.  
If not specified, then the [NoLanguage](NCodeBuilder.LanguageProvider.NoLanguage.md 'NCodeBuilder.LanguageProvider.NoLanguage') provider is used,  
which does not provide any language enhancements.

### Remarks
Initializes an instance of the [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') class with the specific  
[language](NCodeBuilder.CodeBuilder.CodeBuilder(NCodeBuilder.LanguageProvider).md#NCodeBuilder.CodeBuilder.CodeBuilder(NCodeBuilder.LanguageProvider).language 'NCodeBuilder.CodeBuilder.CodeBuilder(NCodeBuilder.LanguageProvider).language') provider.