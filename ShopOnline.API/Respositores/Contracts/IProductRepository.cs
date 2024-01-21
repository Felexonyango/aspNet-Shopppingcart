using ShopOnline.API.Entites;

namespace ShopOnline.API.Respositores.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<Product> GetProductById(int id);
        
    }
}
