using Microsoft.EntityFrameworkCore;
using MyCrudApi.Models; // 引用 Product 類別所在 namespace

namespace MyCrudApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
