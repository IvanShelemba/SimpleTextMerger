namespace SimpleTextMerger.Interface
{
    /// <summary>
    /// Using to select property from configured object
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Selects property from configured object
        /// </summary>
        /// <param name="property">property to be selected</param>
        /// <returns>Value of that property</returns>
        public string Select(string property);
    }
}
