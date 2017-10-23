using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
