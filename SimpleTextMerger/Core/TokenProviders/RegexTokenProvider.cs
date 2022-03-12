using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleTextMerger.Core.Constraints;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core.TokenProviders
{
    public class RegexTokenProvider : ITokenProvider
    {
        private readonly Regex _selector;

        public RegexTokenProvider(string selectorPattern = Contract.PropertySelectorRegex)
        {
            _selector = new Regex(selectorPattern);
        }

        public IEnumerable<string> GetTokens(string rawText)
        {
            return _selector.Matches(rawText).Select(match => match.Value);
        }
    }
}
