namespace Lab.ShoppingBasket.BLL
{
    public class BasketProcessorFactory : IBasketProcessorFactory
    {
        public IBasketProcessor CreateGiftVoucherProcessor()
        {
           return  new GiftVoucherProcessor();
        }

        public IBasketProcessor CreateOfferVoucherProcessor()
        {
            return new OfferVoucherProcessor();
        }

        public IBasketProcessor CreateProductProcessor()
        {
            return  new ProductProcessor();
        }
    }
}
