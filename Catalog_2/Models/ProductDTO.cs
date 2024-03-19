using System.Xml.Linq;

namespace Catalog_2.Models
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }      
        public ProductDTO(string name, string description, int categoryId )
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name;

            ArgumentException.ThrowIfNullOrWhiteSpace(description);
            Description = description;

            if (categoryId > 0)
            {
                CategoryId = categoryId;
            }
            else
            {
                throw new ArgumentException($"{nameof(categoryId)} have to be possitive. Was: {categoryId}");
            }
        }
    }
}
