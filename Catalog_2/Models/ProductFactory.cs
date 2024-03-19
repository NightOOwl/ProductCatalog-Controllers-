using Catalog_2.Interfaces;

namespace Catalog_2.Models
{
    public class ProductFactory : IProductFactory
    {
        public ProductDTO Create(string name, string description, int categoryId)
        {
            var productDTO = new ProductDTO(name,description,categoryId);
            return productDTO;
        }
    }
}
