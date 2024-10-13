#### [NCodeBuilder](index.md 'index')
### [NCodeBuilder](NCodeBuilder.md 'NCodeBuilder').[LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider')

## LanguageProvider.Text(int) Method

A [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') that represents text content. There is no support for  
comments, but blocks are supported by indentation.

```csharp
public static NCodeBuilder.LanguageProvider Text(int indentSize=4);
```
#### Parameters

<a name='NCodeBuilder.LanguageProvider.Text(int).indentSize'></a>

`indentSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The indentation size to use for blocks. Defaults to 4.

#### Returns
[LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider')  
A [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') instance/