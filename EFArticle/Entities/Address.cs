using System;

namespace EFArticle.Entities
{
    public class Address
    {
        public Guid Id { get; }
        
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }

        private Address()
        {

        }
        
        public Address(string city, string street, string number)
        {
            Id = Guid.NewGuid();

            City = city;
            Street = street;
            Number = number;
        }
    }
}