using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;


namespace Lab.ShoppingBasket.BLL.Repositories
{
    public class GiftVoucherRepository : IGiftVoucherRepository
    {
        private IEnumerable<GiftVoucher> _giftVouchers;

        public GiftVoucherRepository()
        {
            LoadGiftVouchers();
        }

        public GiftVoucher GetGiftVoucher(int id)
        {
           return _giftVouchers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GiftVoucher> GetGiftVouchers()
        {
            return _giftVouchers;
        }

        private void LoadGiftVouchers()
        {
            _giftVouchers = new List<GiftVoucher>
            {
                new GiftVoucher {Id = 1,Code = "XXX-XXX", Value = 5m}
            };
        }
    }
}
