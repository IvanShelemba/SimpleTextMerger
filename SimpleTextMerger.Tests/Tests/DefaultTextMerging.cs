using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SimpleTextMerger.Core;
using SimpleTextMerger.Core.Selectors;
using SimpleTextMerger.Core.TokenProviders;
using SimpleTextMerger.Tests.Objects;

namespace SimpleTextMerger.Tests.Tests
{
    internal class DefaultTextMerging
    {
        private Person _person;

        [SetUp]
        public void SetUp()
        {
            _person = new Person
            {
                FirstName = "Ivan",
                LastName = "Shelemba",

                Address = new Address
                {
                    Country = "Ukraine",
                    City = "Lviv",
                    Street = "SomeStreet",
                    HouseNumber = 1,
                },

                Contacts = new HashSet<Contact>
                {
                    new Contact
                    {
                        Type = "Email",
                        Value = "Ivan_Shelemba@gmail.com"
                    },
                    new Contact
                    {
                        Type = "Phone",
                        Value = "+3801111111"
                    }
                }
            };
        }

        [Test(Description = "Simple text")]
        public void SimpleText()
        {
            var text = "Hello World!! My Name is {{FirstName}} {{LastName}} I live in {{Address.Country}}!";

            var expectedResult = $"Hello World!! My Name is {_person.FirstName} {_person.LastName} I live in {_person.Address.Country}!";

            var builder = new MergeBuilder();

            var merger = builder.AddDefaultSelectorFor(_person).Build();

            var result = merger.Merge(text);

            Assert.AreEqual(expectedResult, result);
        }

        [Test(Description = "Text with custom selectors")]
        public void CustomSelectors()
        {
            var text = "My Email is {{$PersonEmail}}";

            var expectedResult = $"My Email is {_person.Contacts.First(e => e.Type == "Email").Value}";

            var builder = new MergeBuilder();

            var merger = builder
                .AddSelector(new FunctionalSelector(prop => FunctionalSelector(prop, _person)))
                .AddTokenProvider(new CustomKeyTokenProvider())
                .Build();

            var result = merger.Merge(text);

            Assert.AreEqual(expectedResult, result);
        }

        [Test(Description = "Complicated text")]
        public void ComplicatedText()
        {
            var text = "My Name is {{FirstName}} and email is {{$PersonEmail}}";

            var expectedResult = $"My Name is {_person.FirstName} and email is {_person.Contacts.First(e => e.Type == "Email").Value}";

            var builder = new MergeBuilder();

            var merger = builder
                .AddDefaultSelectorFor(_person)
                .AddSelector(new FunctionalSelector(prop => FunctionalSelector(prop, _person)))
                .AddTokenProvider(new RegexTokenProvider())
                .AddTokenProvider(new CustomKeyTokenProvider())
                .Build();

            var result = merger.Merge(text);

            Assert.AreEqual(expectedResult, result);
        }

        private static string FunctionalSelector(string property, Person person)
        {
            if (property == "$PersonEmail") return person.Contacts.First(e => e.Type == "Email").Value;

            return null;
        }
    }
}
