using SimpleTextMerger.Core.Constraints;

namespace SimpleTextMerger.Interface
{
    public interface IMergerBuilder
    {
        /// <summary>
        /// Builds configured merger
        /// </summary>
        /// <returns>IMerger that we can use to merge text</returns>
        public IMerger Build();

        /// <summary>
        /// Sets replacer that will be used in merger
        /// </summary>
        /// <param name="replacer">Custom IReplacer instance</param>
        /// <returns>Self</returns>
        public IMergerBuilder SetReplacer(IReplacer replacer);

        /// <summary>
        /// Sets selector that will be used in merger
        /// </summary>
        /// <param name="selector">Custom ISelector instance</param>
        /// <returns>Self</returns>
        public IMergerBuilder AddSelector(ISelector selector);

        /// <summary>
        /// Sets behavior that will be used in merger when key is not found
        /// </summary>
        /// <param name="behavior">Selector behavior when value is null</param>
        /// <returns>Self</returns>
        public IMergerBuilder SetMergeBehavior(SelectorBehavior behavior);

        /// <summary>
        /// Sets default selector that uses reflection to select values
        /// </summary>
        /// <param name="obj">object to select values from</param>
        /// <returns>Self</returns>
        public IMergerBuilder AddDefaultSelectorFor(object obj);

        /// <summary>
        /// Sets sanitizer that will be used in merger
        /// </summary>
        /// <param name="sanitizer">Custom ISanitizer instance</param>
        /// <returns>Self</returns>
        public IMergerBuilder SetSanitizer(ISanitizer sanitizer);

        /// <summary>
        /// Adds provider that will be used in merger
        /// </summary>
        /// <param name="provider">Custom ITokenProvider instance</param>
        /// <returns>Self</returns>
        public IMergerBuilder AddTokenProvider(ITokenProvider provider);
    }
}
