#### [NCodeBuilder](index.md 'index')

## NCodeBuilder Namespace

| Classes | |
| :--- | :--- |
| [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder') | Generates code by concatenating smaller code blocks.<br/>Similar to a [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder'), but with code-specific methods. |
| [Condition](NCodeBuilder.Condition.md 'NCodeBuilder.Condition') | Represents a boolean condition, either as a boolean value or condition, or a predicate delegate. |
| [InnerBuilder](NCodeBuilder.InnerBuilder.md 'NCodeBuilder.InnerBuilder') | Base class for inner builder classes - which construct well known statements in a strongly-typed<br/>manner. |
| [LanguageProvider](NCodeBuilder.LanguageProvider.md 'NCodeBuilder.LanguageProvider') | Provides language-specific enhancements to the [CodeBuilder](NCodeBuilder.CodeBuilder.md 'NCodeBuilder.CodeBuilder'). This includes<br/>default indentation size, support for various kinds of comments (single-line, multi-line and<br/>documentation comments) and code blocks. |

| Structs | |
| :--- | :--- |
| [CodeLine](NCodeBuilder.CodeLine.md 'NCodeBuilder.CodeLine') | Represents a line of code, either as a string value or a factory that dynamically creates<br/>the code. |
| [DictionaryRepeatState&lt;TKey,TValue&gt;](NCodeBuilder.DictionaryRepeatState_TKey,TValue_.md 'NCodeBuilder.DictionaryRepeatState<TKey,TValue>') | |
| [RepeatState&lt;T&gt;](NCodeBuilder.RepeatState_T_.md 'NCodeBuilder.RepeatState<T>') | Represents the state of an iteration in the `Repeat` methods. |

| Delegates | |
| :--- | :--- |
| [CodeFactory()](NCodeBuilder.CodeFactory().md 'NCodeBuilder.CodeFactory()') | Delegate that can be used to dynamically construct a line of code. Equivalent to a<br/>`Func<string>` |
