namespace SimpleTextMerger.Interface
{
    public interface IMerger
    {
        /// <summary>
        /// Merges provided text with configured object
        /// </summary>
        /// <param name="text">Text to merge</param>
        /// <returns>Merged text</returns>
        public string Merge(string text);
    }
}
