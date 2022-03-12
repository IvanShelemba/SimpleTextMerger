using System.Collections.Generic;
using System.Linq;
using SimpleTextMerger.Core.Constraints;
using SimpleTextMerger.Core.Selectors;
using SimpleTextMerger.Core.TokenProviders;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core
{
    public class MergeBuilder : IMergerBuilder
    {
        private IReplacer _replacer;
        private ISanitizer _sanitizer;
        private ISelector _defaultSelector;

        private readonly ICollection<ISelector> _selectors;
        private readonly ICollection<ITokenProvider> _providers;

        private SelectorBehavior _behavior = SelectorBehavior.Exception;

        public MergeBuilder()
        {
            _selectors = new HashSet<ISelector>();
            _providers = new HashSet<ITokenProvider>();
        }

        public IMergerBuilder AddSelector(ISelector selector)
        {
            _selectors.Add(selector); return this;
        }

        public IMergerBuilder SetMergeBehavior(SelectorBehavior behavior)
        {
            _behavior = behavior; return this;
        }

        public IMergerBuilder SetSanitizer(ISanitizer sanitizer)
        {
            _sanitizer = sanitizer; return this;
        }

        public IMergerBuilder AddTokenProvider(ITokenProvider provider)
        {
            _providers.Add(provider); return this;
        }

        public IMergerBuilder SetReplacer(IReplacer replacer)
        {
            _replacer = replacer; return this;
        }

        public IMergerBuilder AddDefaultSelectorFor(object obj)
        {
            _selectors.Add(_defaultSelector ??= new ValueSelector(obj)); return this;
        }

        public IMerger Build()
        {
            if (_selectors.Any() is false) throw new KeyNotFoundException("Selector is not provided!");

            if(_providers.Any() is false) _providers.Add(new RegexTokenProvider());

            return new Merger
            (
                _selectors,
                _providers,
                _replacer ?? new Replacer(),
                _sanitizer ?? new Sanitizer(Contract.EscapeCharactersRegex),
                _behavior
            );
        }
    }
}
