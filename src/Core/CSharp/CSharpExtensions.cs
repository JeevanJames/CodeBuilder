namespace CodeBuilder.Core.CSharp
{
    public static class CSharpExtensions
    {
        public static CodeBuilder Using(this CodeBuilder cb, string ns)
        {
            return cb.Line($"using {ns};");
        }

        public static CodeBuilder UsingStatic(this CodeBuilder cb, string ns)
        {
            return cb.Line($"using static {ns};");
        }

        public static CodeBuilder UsingAlias(this CodeBuilder cb, string alias, string value)
        {
            return cb.Line($"using {alias} = {value};");
        }

        public static CodeBuilder Namespace(this CodeBuilder cb, string ns)
        {
            return cb.Block($"namespace {ns}");
        }
    }
}
