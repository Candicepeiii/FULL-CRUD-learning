namespace MyCrudApi.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}