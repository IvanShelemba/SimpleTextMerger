using System.Collections.Generic;

namespace SimpleTextMerger.Tests.Objects
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
