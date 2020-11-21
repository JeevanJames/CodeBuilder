using CodeBuilder.Core.CLanguageFamily;

namespace CodeBuilder.Core.CSharp
{
    public class CSharpLanguageProvider : CLanguageFamilyProvider
    {
        public CSharpLanguageProvider()
            : base(CLanguageBraceStyle.AllmanBSD)
        {
        }
    }
}
