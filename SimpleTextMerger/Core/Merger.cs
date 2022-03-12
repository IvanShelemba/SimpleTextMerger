using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTextMerger.Core.Constraints;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core
{
    internal class Merger : IMerger
    {
        private readonly IReplacer _replacer;
        private readonly ISanitizer _sanitizer;
        private readonly SelectorBehavior _behavior;
        private readonly ICollection<ISelector> _selectors;
        private readonly ICollection<ITokenProvider> _providers;

        public Merger(
            ICollection<ISelector> selectors,
            ICollection<ITokenProvider> providers, 
            IReplacer replacer, 
            ISanitizer sanitizer,
            SelectorBehavior behavior)
        {
            _selectors = selectors;
            _providers = providers;
            _replacer = replacer;
            _sanitizer = sanitizer;
            _behavior = behavior;
        }

        public string Merge(string text)
        {
            var tokens = _providers.SelectMany(provider => provider.GetTokens(text));

            return tokens.Aggregate(text, ReplaceToken);
        }

        private string ReplaceToken(string text, string token)
        {
            return _replacer.Replace(text, token, GetValue(token) ?? GetAlternateValue(token));
        }

        private string GetValue(string token)
        {
            return _selectors.Select(selector => selector.Select(_sanitizer.Cleanup(token))).FirstOrDefault(val => val != null);
        }

        private string GetAlternateValue(string token)
        {
            return _behavior switch
            {
                SelectorBehavior.Ignore => token,
                SelectorBehavior.SetEmpty => string.Empty,
                SelectorBehavior.Exception => throw new KeyNotFoundException($"Invalid token: {token}"),

                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
