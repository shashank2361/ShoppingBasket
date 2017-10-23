using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public interface IBasketItemRepository
    {
        IEnumerable<BasketItem> GetBasketItems();
        BasketItem GetBasketItem(int id);
    }
}
