using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entites;
using ShopOnline.API.Respositores.Contracts;

namespace ShopOnline.API.Respositores
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await context.Categories
                .AsNoTracking()
                .ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await context.Categories.FindAsync(id);
            return category;
        }
    }
}
