using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entites;
using ShopOnline.API.Respositores.Contracts;

namespace ShopOnline.API.Respositores
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await context.Products
                .AsNoTracking()
                .Include(p => p.FitTypes)
                .Include(p => p.Categories)
                .Include(p => p.Images)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await context.Products
                .FindAsync(id);

            return product;
        }


        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            var products = await context.Categories
                .AsNoTracking()
                .Where(c => c.Id == categoryId)
                .Include(c => c.Products)
                .Select(c => c.Products)
                .ToListAsync();

            return (IEnumerable<Product>)products;
        }
    }
}
