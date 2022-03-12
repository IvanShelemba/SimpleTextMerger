using System;
using System.Linq;
using SimpleTextMerger.Core.Constraints;
using SimpleTextMerger.Interface;

namespace SimpleTextMerger.Core.Selectors
{
    public class ValueSelector : ISelector
    {
        private readonly object _obj;
        private readonly string _propertySeparator;

        public ValueSelector(object obj, string propertySeparator = Contract.PropertySeparator)
        {
            _obj = obj ?? throw new ArgumentNullException();

            _propertySeparator = propertySeparator;
        }

        public string Select(string expression)
        {
            var properties = expression.Split(_propertySeparator);

            var value = _obj;

            foreach (var property in properties)
            {
                value = GetValueByProperty(value, property);

                if (value is null) return null;
            }

            return value!.ToString();
        }

        private static object GetValueByProperty(object obj, string property)
        {
            return obj.GetType()
                .GetProperties()
                .FirstOrDefault(e => e.Name == property)?
                .GetValue(obj, null);
        }
    }
}
