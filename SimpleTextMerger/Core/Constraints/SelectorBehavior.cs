namespace SimpleTextMerger.Core.Constraints
{
    /// <summary>
    /// Behavior of selector when value is null
    /// </summary>
    public enum SelectorBehavior
    {
        Ignore = 1,
        SetEmpty = 2,
        Exception = 3,
    }
}
