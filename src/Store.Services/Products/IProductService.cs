using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Services.Products.Dto;

namespace Store.Services.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetAsync(Guid id);
        Task<IEnumerable<ProductDto>> BrowseAsync();
        Task AddAsync(Guid id, string name, decimal price);
    }
}