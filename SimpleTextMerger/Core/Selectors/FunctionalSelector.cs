using System;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core.Selectors
{
    public class FunctionalSelector : ISelector
    {
        private readonly Func<string, string> _selector;

        public FunctionalSelector(Func<string, string> selector)
        {
            _selector = selector;
        }


        public string Select(string property)
        {
            return _selector(property);
        }
    }
}
