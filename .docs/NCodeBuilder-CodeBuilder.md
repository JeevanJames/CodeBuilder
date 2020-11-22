#### [NCodeBuilder](./index.md 'index')
### [NCodeBuilder](./NCodeBuilder.md 'NCodeBuilder')
## CodeBuilder Class
Generates code by concatenating smaller code blocks.  





Similar to a [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder'), but with code-specific methods.  
```csharp
public sealed class CodeBuilder
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CodeBuilder  
### Constructors
- [CodeBuilder(NCodeBuilder.LanguageProvider?)](./NCodeBuilder-CodeBuilder-CodeBuilder(NCodeBuilder-LanguageProvider-).md 'NCodeBuilder.CodeBuilder.CodeBuilder(NCodeBuilder.LanguageProvider?)')
### Properties
- [Blank](./NCodeBuilder-CodeBuilder-Blank.md 'NCodeBuilder.CodeBuilder.Blank')
- [Indent](./NCodeBuilder-CodeBuilder-Indent.md 'NCodeBuilder.CodeBuilder.Indent')
- [Unindent](./NCodeBuilder-CodeBuilder-Unindent.md 'NCodeBuilder.CodeBuilder.Unindent')
### Methods
- [Block(System.Nullable&lt;NCodeBuilder.CodeLine&gt;, string?)](./NCodeBuilder-CodeBuilder-Block(System-Nullable-NCodeBuilder-CodeLine-_string-).md 'NCodeBuilder.CodeBuilder.Block(System.Nullable&lt;NCodeBuilder.CodeLine&gt;, string?)')
- [Comment(NCodeBuilder.CodeLine[])](./NCodeBuilder-CodeBuilder-Comment(NCodeBuilder-CodeLine--).md 'NCodeBuilder.CodeBuilder.Comment(NCodeBuilder.CodeLine[])')
- [Comment(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;)](./NCodeBuilder-CodeBuilder-Comment(System-Collections-Generic-IEnumerable-NCodeBuilder-CodeLine-).md 'NCodeBuilder.CodeBuilder.Comment(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;)')
- [DocComments(NCodeBuilder.CodeLine[])](./NCodeBuilder-CodeBuilder-DocComments(NCodeBuilder-CodeLine--).md 'NCodeBuilder.CodeBuilder.DocComments(NCodeBuilder.CodeLine[])')
- [DocComments(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;)](./NCodeBuilder-CodeBuilder-DocComments(System-Collections-Generic-IEnumerable-NCodeBuilder-CodeLine-).md 'NCodeBuilder.CodeBuilder.DocComments(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;)')
- [EndBlock(string?)](./NCodeBuilder-CodeBuilder-EndBlock(string-).md 'NCodeBuilder.CodeBuilder.EndBlock(string?)')
- [EndSection()](./NCodeBuilder-CodeBuilder-EndSection().md 'NCodeBuilder.CodeBuilder.EndSection()')
- [Generate(System.Action&lt;NCodeBuilder.CodeBuilder&gt;, bool)](./NCodeBuilder-CodeBuilder-Generate(System-Action-NCodeBuilder-CodeBuilder-_bool).md 'NCodeBuilder.CodeBuilder.Generate(System.Action&lt;NCodeBuilder.CodeBuilder&gt;, bool)')
- [Iterate(object, System.Action&lt;NCodeBuilder.CodeBuilder,string,object&gt;)](./NCodeBuilder-CodeBuilder-Iterate(object_System-Action-NCodeBuilder-CodeBuilder_string_object-).md 'NCodeBuilder.CodeBuilder.Iterate(object, System.Action&lt;NCodeBuilder.CodeBuilder,string,object&gt;)')
- [Line(NCodeBuilder.CodeLine)](./NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine).md 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine)')
- [Line(NCodeBuilder.CodeLine, bool)](./NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_bool).md 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine, bool)')
- [Line(NCodeBuilder.CodeLine, System.Func&lt;bool&gt;)](./NCodeBuilder-CodeBuilder-Line(NCodeBuilder-CodeLine_System-Func-bool-).md 'NCodeBuilder.CodeBuilder.Line(NCodeBuilder.CodeLine, System.Func&lt;bool&gt;)')
- [MultiLineComment(NCodeBuilder.CodeLine[])](./NCodeBuilder-CodeBuilder-MultiLineComment(NCodeBuilder-CodeLine--).md 'NCodeBuilder.CodeBuilder.MultiLineComment(NCodeBuilder.CodeLine[])')
- [MultiLineComment(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;)](./NCodeBuilder-CodeBuilder-MultiLineComment(System-Collections-Generic-IEnumerable-NCodeBuilder-CodeLine-).md 'NCodeBuilder.CodeBuilder.MultiLineComment(System.Collections.Generic.IEnumerable&lt;NCodeBuilder.CodeLine&gt;)')
- [Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;)](./NCodeBuilder-CodeBuilder-Repeat-T-(System-Collections-Generic-IEnumerable-T-_System-Action-NCodeBuilder-CodeBuilder_NCodeBuilder-RepeatState-T--).md 'NCodeBuilder.CodeBuilder.Repeat&lt;T&gt;(System.Collections.Generic.IEnumerable&lt;T&gt;, System.Action&lt;NCodeBuilder.CodeBuilder,NCodeBuilder.RepeatState&lt;T&gt;&gt;)')
- [Section(bool)](./NCodeBuilder-CodeBuilder-Section(bool).md 'NCodeBuilder.CodeBuilder.Section(bool)')
- [Section(System.Func&lt;bool&gt;)](./NCodeBuilder-CodeBuilder-Section(System-Func-bool-).md 'NCodeBuilder.CodeBuilder.Section(System.Func&lt;bool&gt;)')
- [ToString()](./NCodeBuilder-CodeBuilder-ToString().md 'NCodeBuilder.CodeBuilder.ToString()')
