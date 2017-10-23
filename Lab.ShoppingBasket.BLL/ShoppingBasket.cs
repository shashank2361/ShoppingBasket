using System;
using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL
{
    public class ShoppingBasket : IShoppingBasket
    {
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();
        //public IEnumerable<Product> Products { get; set; }
        public IEnumerable<GiftVoucher> GiftVouchers { get; set; }
        public OfferVoucher OfferVoucher { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
        public decimal Total { get; set; }
        public IEnumerable<BasketItem> GetBasketItems()
        {
            return _basketItems;
        }

        public void EmptyBasketItems()
        {
            _basketItems.Clear();
        }

/*        public void RemoveItemFromBasket(Product product)
        {
            var basketItem = _basketItems.FirstOrDefault(x => x.Product.Id == product.Id);

            if (basketItem == null) return;

            if (basketItem.Quantity <= 1)
                _basketItems.Remove(basketItem);
            else
                basketItem.Quantity--;
        }*/

        public void AddtemToBasket(Product product)
        {
            var basketItem = _basketItems.FirstOrDefault(x => x.Product.Id == product.Id);

            if (basketItem != null)
                basketItem.Quantity++;
            else
                _basketItems.Add(new BasketItem
                {
                    BasketItemId = GetBasketItemId(),
                    Product = product,
                    Quantity = 1
                });
        }

        private static string GetBasketItemId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
