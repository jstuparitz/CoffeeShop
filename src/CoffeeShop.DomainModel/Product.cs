using System;
using System.Runtime.Serialization;

namespace CoffeeShop.DomainModel
{
    [DataContract]
    public class Product
    {
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public decimal Price { get; private set; }
    }
}