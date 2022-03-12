using System.Collections.Generic;
using NUnit.Framework;
using SimpleTextMerger.Core;
using SimpleTextMerger.Core.Constraints;
using SimpleTextMerger.Tests.Objects;

namespace SimpleTextMerger.Tests.Tests
{
    internal class BehaviorTest
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

        [Test(Description = "Ignore behavior test")]
        public void SelectorBehaviorIgnore()
        {
            var text = "My Name is {{FirstName}} {{MiddleName}}";

            var expectedResult = "My Name is " + _person.FirstName + " {{MiddleName}}";

            var builder = new MergeBuilder();

            var merger = builder.AddDefaultSelectorFor(_person)
                .SetMergeBehavior(SelectorBehavior.Ignore)
                .Build();

            var result = merger.Merge(text);

            Assert.AreEqual(expectedResult, result);
        }

        [Test(Description = "SetEmpty behavior test")]
        public void SelectorBehaviorSetEmpty()
        {
            var text = "My Name is {{FirstName}} {{MiddleName}}";

            var expectedResult = $"My Name is {_person.FirstName} ";

            var builder = new MergeBuilder();

            var merger = builder.AddDefaultSelectorFor(_person)
                .SetMergeBehavior(SelectorBehavior.SetEmpty)
                .Build();

            var result = merger.Merge(text);

            Assert.AreEqual(expectedResult, result);
        }

        [Test(Description = "Exception behavior test")]
        public void SelectorBehaviorException()
        {
            var text = "My Name is {{FirstName}} {{MiddleName}}";

            var builder = new MergeBuilder();

            var merger = builder.AddDefaultSelectorFor(_person)
                .SetMergeBehavior(SelectorBehavior.Exception)
                .Build();

            Assert.Throws<KeyNotFoundException>(() => merger.Merge(text));
        }
    }
}
