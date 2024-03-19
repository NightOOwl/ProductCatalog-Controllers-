using Catalog_2.Interfaces;
using Catalog_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_2.Controllers
{
    [Route("/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly Catalog _catalog;
        private readonly IProductFactory _productFactory;
        public CatalogController(Catalog catalog, IProductFactory factory)
        {
            _catalog = catalog;
            _productFactory = factory;
        }

        [HttpGet("/catalog")]
        public IActionResult GetProducts()
        {
            return Ok(_catalog.GetProducts());
        }

        [HttpPost("/catalog")]
        public IActionResult CreateProduct(string name,string description,int categoryId)
        {
            try
            {
                var productDTO = _productFactory.Create(name, description, categoryId);
                var newProduct = _catalog.AddProduct(productDTO);
                var productUri = $"/catalog/{newProduct.Id}";
                return Created(uri:productUri,newProduct);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/catalog/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _catalog.GetProductById(id);
                return Ok(product);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("/catalog/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _catalog.DeleteProduct(id);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
