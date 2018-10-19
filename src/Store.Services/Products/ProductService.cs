using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Services.Products.Dto;

namespace Store.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetAsync(Guid id)
            => await _productRepository.GetAsync(id)
                .ContinueWith(t => Map(t.Result));

        public async Task<IEnumerable<ProductDto>> BrowseAsync()
            => await _productRepository.BrowseAsync()
                .ContinueWith(t => t.Result.Select(Map));

        public async Task AddAsync(Guid id, string name, decimal price)
            => await _productRepository.AddAsync(new Product(id, name, price));

        private ProductDto Map(Product product)
            => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
    }
}
