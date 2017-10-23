using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Utilities.Enumerations.Product;
using Lab.ShoppingBasket.Utilities.Enumerations.Voucher;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public class OfferVoucherRepository : IOfferVoucherRepository
    {

        private IEnumerable<OfferVoucher> _offerVouchers;

        public OfferVoucherRepository()
        {
            LoadofferVouchers();
        }

        public OfferVoucher GetOffVoucher(int id)
        {
            return _offerVouchers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OfferVoucher> GetOffVouchers()
        {
            return _offerVouchers;
        }

        private void LoadofferVouchers()
        {
            _offerVouchers = new List<OfferVoucher>
            {
                new OfferVoucher
                {
                    Id = 1,
                    Code = "YYY-YYY",
                    Value = 5.00m,
                    Threshold = 50m,
                    OfferVoucherType = OfferVoucherType.Product,
                    ProductCategory = Category.HeadGear
                },
                new OfferVoucher
                {
                    Id = 2,
                    Code = "YYY-YYY",
                    Value = 5.00m,
                    Threshold = 50m,
                    OfferVoucherType = OfferVoucherType.Basket
                }

            };
        }
    }
}
