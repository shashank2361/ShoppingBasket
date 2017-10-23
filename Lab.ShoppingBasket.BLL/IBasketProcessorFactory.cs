namespace Lab.ShoppingBasket.BLL
{
    public interface IBasketProcessorFactory
    {
        IBasketProcessor CreateProductProcessor();
        IBasketProcessor CreateGiftVoucherProcessor();
        IBasketProcessor CreateOfferVoucherProcessor();
    }
}
