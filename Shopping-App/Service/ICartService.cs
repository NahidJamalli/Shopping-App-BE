using Shopping_App.Models;

namespace Shopping_App.Service
{
    public interface ICartService
    {
        Cart GetCart();
        void AddProduct(Product product);
        void RemoveProduct(int productId);
        void ClearCart();
    }
}
