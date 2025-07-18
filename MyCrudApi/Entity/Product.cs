using System.ComponentModel.DataAnnotations;

namespace MyCrudApi.Entity
{
    public class Product
    {
      public int Id { get; set; }

      [Required(ErrorMessage = "Product name cannot be empty")]
      [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
      public string Name { get; set; } = string.Empty;

      [Range(0.01, 99999.99, ErrorMessage = "Product price must between 0.01 to 99999.99")]
      public decimal Price { get; set; }

      public bool IsDeleted { get; set; } = false;

      public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

