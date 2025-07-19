using MyCrudApi.Entity;

namespace MyCrudApi.Data
{
    public static class DbInitializer
    {
        public static void SeedCategories(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Electronics" },
                    new Category { Name = "Books" },
                    new Category { Name = "Clothing" },
                    new Category { Name = "Home & Kitchen" },
                    new Category { Name = "Sports" },
                    new Category { Name = "Toys" },
                    new Category { Name = "Beauty" },
                    new Category { Name = "Food" },
                    new Category { Name = "Others" },
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }
    }
}
