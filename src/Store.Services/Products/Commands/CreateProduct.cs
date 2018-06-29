using System;

namespace Store.Services.Products.Commands
{
    public class CreateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}