using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleTextMerger.Core.Constraints;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core.TokenProviders
{
    public class CustomKeyTokenProvider : ITokenProvider
    {
        private readonly Regex _selector;

        public CustomKeyTokenProvider(string selectorPattern = Contract.CustomKeySelectorRegex)
        {
            _selector = new Regex(selectorPattern);
        }

        public IEnumerable<string> GetTokens(string rawText)
        {
            return _selector.Matches(rawText).Select(match => match.Value);
        }
    }
}
