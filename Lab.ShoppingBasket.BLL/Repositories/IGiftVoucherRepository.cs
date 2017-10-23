using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public interface IGiftVoucherRepository
    {
        IEnumerable<GiftVoucher> GetGiftVouchers();
        GiftVoucher GetGiftVoucher(int id);
    }
}
