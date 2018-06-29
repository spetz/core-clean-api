using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Products;
using Store.Services.Products.Commands;
using Store.Services.Products.Dto;

namespace Store.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
            => Ok(await _productService.BrowseAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
            => Single(await _productService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProduct command)
        {
            command.Id = Guid.NewGuid();
            await _productService.AddAsync(command.Id, command.Name, command.Price);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
    }
}