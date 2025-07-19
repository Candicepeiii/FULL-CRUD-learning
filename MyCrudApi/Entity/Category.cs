using System.ComponentModel.DataAnnotations;

namespace MyCrudApi.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property for all related products
        public ICollection<Product>? Products { get; set; }
    }
}