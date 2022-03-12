using System.Collections.Generic;

namespace SimpleTextMerger.Interface
{
    /// <summary>
    /// Using to get tokens that should be replaced
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Gets tokens that should be replaced
        /// </summary>
        /// <param name="rawText">Text with tokens</param>
        /// <returns>Collection of tokens</returns>
        public IEnumerable<string> GetTokens(string rawText);
    }
}
