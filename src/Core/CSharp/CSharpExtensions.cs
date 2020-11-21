namespace CodeBuilder.Core.CSharp
{
    public static class CSharpExtensions
    {
        public static CodeBuilder Using(this CodeBuilder cb, string ns) => cb.Line($"using {ns};");

        public static CodeBuilder UsingStatic(this CodeBuilder cb, string ns) => cb.Line($"using static {ns};");

        public static CodeBuilder UsingAlias(this CodeBuilder cb, string alias, string value)
            => cb.Line($"using {alias} = {value};");

        public static CodeBuilder Namespace(this CodeBuilder cb, string ns) => cb.Block($"namespace {ns}");

        public static CodeBuilder EndNamespace(this CodeBuilder cb) => cb.EndBlock();

        public static CodeBuilder Try(this CodeBuilder cb) => cb.Block("try");

        public static CodeBuilder Catch(this CodeBuilder cb, string exception = "Exception", string? variable = null, string? filter = null)
        {
            string catchLine = $"catch ({exception}";
            if (!string.IsNullOrWhiteSpace(variable))
                catchLine += " " + variable;
            catchLine += ")";
            if (!string.IsNullOrWhiteSpace(filter))
                catchLine += $" when ({filter})";
            return cb.EndBlock().Block(catchLine);
        }

        public static CodeBuilder Catch<TException>(this CodeBuilder cb, string? variable = null, string? filter = null)
        {
            return Catch(cb, typeof(TException).FullName, variable, filter);
        }

        public static CodeBuilder Finally(this CodeBuilder cb) => cb.EndBlock().Block("finally");

        public static CodeBuilder EndTry(this CodeBuilder cb) => cb.EndBlock();
    }
}
