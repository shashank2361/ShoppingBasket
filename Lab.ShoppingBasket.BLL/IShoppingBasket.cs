using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL
{
    public interface IShoppingBasket
    {
        //IEnumerable<Product> Products { get; set; }
        IEnumerable<BasketItem> GetBasketItems();
        void AddtemToBasket(Product product);
     //  void RemoveItemFromBasket(Product product);
        void EmptyBasketItems();
        IEnumerable<GiftVoucher> GiftVouchers { get; set; }
        OfferVoucher OfferVoucher { get; set; }
        IList<string> Messages { get; set; }
        decimal Total { get; set; }
    }
}
