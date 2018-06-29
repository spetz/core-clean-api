using System;

namespace Store.Core.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        private Product()
        {
        }

        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            SetName(name);
            SetPrice(price);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Invalid name.", nameof(name));
            }
            Name = name;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException($"Invalid price: '{price}.'", nameof(price));
            }
            Price = price;
        }
    }
}