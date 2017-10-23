using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public interface IOfferVoucherRepository
    {
        IEnumerable<OfferVoucher> GetOffVouchers();
        OfferVoucher GetOffVoucher(int id);
    }
}
