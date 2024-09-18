using Shopping_App.Models;

namespace Shopping_App.Service
{
    public class CartService : ICartService
    {
        private readonly Cart _cart = new Cart();

        public Cart GetCart()
        {
            return _cart;
        }

        public void AddProduct(Product product)
        {
            var existingItem = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity < 5)
                {
                    existingItem.Quantity++;
                }
            }
            else
            {
                _cart.Items.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveProduct(int productId)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                _cart.Items.Remove(item);
            }
        }

        public void ClearCart()
        {
            _cart.Items.Clear();
        }
    }
}