using MyCrudApi.Data;
using MyCrudApi.DTOs;
using MyCrudApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace MyCrudApi.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToListAsync();
        }

        public ProductDTO? GetProductById(int id)
        {
            var product = _context.Products
                .Where(p => !p.IsDeleted)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }


        public async Task<Product> CreateProductAsync(CreateProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            if (id != product.Id) return false;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
