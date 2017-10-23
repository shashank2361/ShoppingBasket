using Lab.ShoppingBasket.Utilities.Enumerations.Product;
using Lab.ShoppingBasket.Utilities.Enumerations.Voucher;

namespace Lab.ShoppingBasket.DAL
{
    public class OfferVoucher
    {
        public  int Id { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public bool CanBeAppliedToBasket { get; set; }
        public decimal Threshold { get; set; }
        public OfferVoucherType OfferVoucherType { get; set; }
        public Category ProductCategory { get; set;}
    }
}
