using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.Repositories;

namespace Store.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "IPhone X", 5000),
            new Product(Guid.NewGuid(), "Samsung S9", 4000),
            new Product(Guid.NewGuid(), "Dell XPS", 8000)
        };

        public async Task<Product> GetAsync(Guid id)
            => await Task.FromResult(_products.SingleOrDefault(p => p.Id == id));

        public async Task<IEnumerable<Product>> BrowseAsync()
            => await Task.FromResult(_products);

        public async Task AddAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
    }
}