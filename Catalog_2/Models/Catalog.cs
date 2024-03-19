using System.Xml.Linq;

namespace Catalog_2.Models
{
    public class Catalog
    {
        public Catalog()
        {
            products = new List<Product>();
			var testProd = new Product(1, "test", "Desc", 3);
            products.Add(testProd);
        }
        private List<Product> products;

		public Product GetProductById(int id)
		{
			try
			{
				return products.First(p => p.Id == id);
			}
			catch(InvalidOperationException)
			{
				throw new ArgumentException($"Product with {nameof(id)} = {id} not exist");
			}
		}

		public Product AddProduct(ProductDTO product)
		{
			int maxId = 1;
			if (products.Count> 0)
			{
				maxId = products.Max(p => p.Id)+1;
			}
			var newProduct = new Product(
				id: maxId,
				name: product.Name,
				description: product.Description,
				categoryId: product.CategoryId
				);
			products.Add(newProduct);
			return newProduct;
		}

		public IReadOnlyList<Product> GetProducts()
		{
			return products.AsReadOnly();
		}

		public void DeleteProduct(int id)
		{
			try
			{
				var productToDelete = products.First(p => p.Id == id);
				products.Remove(productToDelete);
			}
			catch (InvalidOperationException)
			{
                throw new ArgumentException($"Product with {nameof(id)} = {id} not exist");
            }
		}
	}
}
