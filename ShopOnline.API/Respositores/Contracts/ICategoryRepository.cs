using ShopOnline.API.Entites;

namespace ShopOnline.API.Respositores.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
    }
}
