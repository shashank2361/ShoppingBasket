using System.Linq;

namespace Lab.ShoppingBasket.BLL
{
    public class GiftVoucherProcessor : IBasketProcessor
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            if(shoppingBasket.GiftVouchers != null && shoppingBasket.GiftVouchers.Any())
                 shoppingBasket.Total -= shoppingBasket.GiftVouchers.Sum(x => x.Value);
            return shoppingBasket;
        }
    }
}
