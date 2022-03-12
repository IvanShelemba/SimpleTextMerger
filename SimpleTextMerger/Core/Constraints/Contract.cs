namespace SimpleTextMerger.Core.Constraints
{
    internal class Contract
    {
        public const string PropertySeparator = ".";

        public const string EscapeCharactersRegex = @"{{|}}";

        public const string PropertySelectorRegex = @"{{[a-zA-Z_]+[0-9]*([\.]?[a-zA-Z_]+[0-9]*)+}}";

        public const string CustomKeySelectorRegex = @"{{[$]{1}[a-zA-Z]+[_0-9]*}}";
    }
}
