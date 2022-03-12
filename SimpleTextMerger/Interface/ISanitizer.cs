namespace SimpleTextMerger.Interface
{
    /// <summary>
    /// Using to clean escape symbols from token
    /// </summary>
    public interface ISanitizer
    {
        /// <summary>
        /// Cleans escape symbols from token
        /// </summary>
        /// <param name="token">token to be cleaned</param>
        /// <returns>Cleaned token</returns>
        public string Cleanup(string token);
    }
}
