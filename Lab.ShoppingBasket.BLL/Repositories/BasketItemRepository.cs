using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private IEnumerable<BasketItem> _basketItems;
        private readonly IProductRepository _productRepository;

        public BasketItemRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            LoadBasketItems();
        }

        public IEnumerable<BasketItem> GetBasketItems()
        {
            return _basketItems;
        }

        public BasketItem GetBasketItem(int id)
        {
            return _basketItems.FirstOrDefault(x => x.Id == id);
        }

        private void LoadBasketItems()
        {


            _basketItems = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = 1,
                    Product = _productRepository.GetProduct(1),
                    Quantity = 1
                    
                },
                new BasketItem
                {
                    Id = 2,
                    Product = _productRepository.GetProduct(5),
                    
                    Quantity = 3

                },
                new BasketItem
                {
                    Id = 3,
                    Product = _productRepository.GetProduct(7),
                    
                    Quantity = 6

                },
            };
        }
    }
}
