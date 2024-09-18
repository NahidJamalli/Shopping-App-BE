using Shopping_App.Models;

namespace Shopping_App.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}
