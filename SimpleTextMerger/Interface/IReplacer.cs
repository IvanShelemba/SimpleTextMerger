namespace SimpleTextMerger.Interface
{
    /// <summary>
    /// Replacer using for replace patterns in provided text by provided value
    /// </summary>
    public interface IReplacer
    {
        /// <summary>
        /// Replaces patterns in provided text by provided value
        /// </summary>
        /// <param name="text">Raw text</param>
        /// <param name="pattern">Pattern to replace</param>
        /// <param name="value">Value that will be sets instead of pattern</param>
        /// <returns>Text with replaced patterns to values</returns>
        public string Replace(string text, string pattern, string value);
    }
}
