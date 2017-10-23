using Lab.ShoppingBasket.Utilities.Enumerations.Voucher;
using System.Linq;
using Lab.ShoppingBasket.Utilities.Enumerations.Product;


namespace Lab.ShoppingBasket.BLL
{
    public class OfferVoucherProcessor : IBasketProcessor
    {
        private bool _isOfferApplied;

        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            if (shoppingBasket.OfferVoucher == null)
                return shoppingBasket;

            shoppingBasket = ValidateOfferVoucherForThreshold(shoppingBasket);
            if(!BasketHasErrors(shoppingBasket) && shoppingBasket.OfferVoucher.OfferVoucherType == OfferVoucherType.Basket)
            {
                shoppingBasket.Total = shoppingBasket.Total - shoppingBasket.OfferVoucher.Value;
                _isOfferApplied = true;
            }

            if (!BasketHasErrors(shoppingBasket) && !_isOfferApplied && shoppingBasket.OfferVoucher.OfferVoucherType == OfferVoucherType.Product)
            {
                shoppingBasket.Total = ValidateOfferVoucherForProducts(shoppingBasket).Total;
            }

            if(!BasketHasErrors(shoppingBasket) && !_isOfferApplied)
            {
                shoppingBasket.Messages.Add($"There are no products in your basket applicable to voucher Voucher {shoppingBasket.OfferVoucher.Code}.");
            }

            return shoppingBasket;
        }

        private static IShoppingBasket ValidateOfferVoucherForThreshold(IShoppingBasket shoppingBasket)
        {
            
            var basketsTotal = shoppingBasket.GetBasketItems().Where(x=>x.Product.Category != Category.GiftVoucher).Sum(basketItem => basketItem.Product.Price * basketItem.Quantity);

            if (basketsTotal < shoppingBasket.OfferVoucher.Threshold)
            {
                var additonalAmountToSpend = shoppingBasket.OfferVoucher.Threshold - basketsTotal + 0.01m;
                shoppingBasket.Messages.Add($"You have not reached the spend threshold for voucher {shoppingBasket.OfferVoucher.Code}. Spend another £{additonalAmountToSpend} to receive £5.00 discount from your basket total.");
                basketsTotal = shoppingBasket.Total;
            }

            shoppingBasket.Total = basketsTotal;

            return shoppingBasket;
        }

        private IShoppingBasket ValidateOfferVoucherForProducts(IShoppingBasket shoppingBasket)
        {
            var basketsTotal = 0.00m;
            foreach (var basketItem in shoppingBasket.GetBasketItems())
            {
                if(basketItem.Product.Category == shoppingBasket.OfferVoucher.ProductCategory && !_isOfferApplied)
                {
                    _isOfferApplied = true;
                    var productPrice = basketItem.Product.Price;
                    productPrice -= shoppingBasket.OfferVoucher.Value;
                    productPrice = productPrice >= 0 ? productPrice : 0m;

                    basketsTotal += productPrice;
                }
                else
                {
                    basketsTotal += basketItem.Product.Price;
                }
            }

            shoppingBasket.Total = basketsTotal;
            return shoppingBasket;
        }

        private static bool BasketHasErrors(IShoppingBasket shoppingBasket)
        {
            return shoppingBasket.Messages.Count > 0;
        }
    }
}
