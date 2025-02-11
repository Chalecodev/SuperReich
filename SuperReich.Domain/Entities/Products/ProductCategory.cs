using System.ComponentModel.DataAnnotations;

namespace SuperReich.Domain.Entities.Products
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
