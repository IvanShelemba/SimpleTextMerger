using System.Text.RegularExpressions;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core
{
    public class Sanitizer : ISanitizer
    {
        private readonly Regex _cleaner;

        public Sanitizer(string cleanerRegex)
        {
            _cleaner = new Regex(cleanerRegex);
        }

        public string Cleanup(string token)
        {
            return _cleaner.Replace(token, string.Empty);
        }
    }
}
