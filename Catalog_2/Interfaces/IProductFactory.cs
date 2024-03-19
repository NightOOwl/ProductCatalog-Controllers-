using Catalog_2.Models;

namespace Catalog_2.Interfaces
{
    public interface IProductFactory
    {
        ProductDTO Create(string name,string description, int categoryId);
    }
}
