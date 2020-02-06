using System;
using System.Collections.Generic;

namespace EFArticle.Entities
{
    public class Person
    {
        public Guid Id { get; }
        
        public string Name { get; private set; }
        public Document Document { get; private set; }

        public IReadOnlyList<Address> Address => _address;
        private readonly List<Address> _address;

        private Person()
        {
            _address = new List<Address>();
        }
        
        public Person(string name, Document document): this()
        {
            Id = Guid.NewGuid();
            
            Name = name;
            Document = document;
        }

        public void AddAddress(string city, string street, string number)
        {
            // Address validation;
            
            var address = new Address(city, street, number);
            _address.Add(address);
        }
    }
}
