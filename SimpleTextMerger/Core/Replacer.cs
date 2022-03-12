using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core
{
    public class Replacer : IReplacer
    {
        public string Replace(string text, string pattern, string value)
        {
            return text.Replace(pattern, value);
        }
    }
}
