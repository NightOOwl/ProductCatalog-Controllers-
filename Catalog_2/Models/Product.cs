namespace Catalog_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }

        public Product(int id, string name, string description, int categoryId)
        {
            if (id > 0)
            {
                Id = id;
            }
            else
            {
                throw new ArgumentException($"{nameof(id)} have to be possitive. Was: {id}");
            }
           
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
