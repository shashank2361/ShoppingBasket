using System.Linq;

namespace Lab.ShoppingBasket.BLL
{
    public class ProductProcessor : IBasketProcessor
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            shoppingBasket.Total = shoppingBasket.GetBasketItems().Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);
            return shoppingBasket;
        }
    }
}
