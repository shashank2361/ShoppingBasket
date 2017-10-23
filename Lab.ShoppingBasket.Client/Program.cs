using Lab.ShoppingBasket.BLL;
using Lab.ShoppingBasket.Service;
using Lab.ShoppingBasket.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.BLL.Repositories;

namespace Lab.ShoppingBasket.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IGiftVoucherRepository giftVoucherRepository = new GiftVoucherRepository();
            IOfferVoucherRepository offerVoucherRepository = new OfferVoucherRepository();

            ConsoleSetup(0);
            // Empty Basket
            var shoppingBasket = new BLL.ShoppingBasket();

            IBasketProcessorFactory basketProcessorFactory = new BasketProcessorFactory();
            var basetService = new BasketService(basketProcessorFactory);
            var basketServiceResponse = basetService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket0 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket0 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            ConsoleSetup(0);
            // Basket 1:
            shoppingBasket = new BLL.ShoppingBasket
            {
                GiftVouchers = new List<GiftVoucher>
                {
                    giftVoucherRepository.GetGiftVoucher(1)
                }

            };

            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(2));
            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket1 - Total : £{basketServiceResponse.BasketTotal}");

            ConsoleSetup(0);
            // Basket 2:

            shoppingBasket = new BLL.ShoppingBasket
            {
                OfferVoucher = offerVoucherRepository.GetOffVoucher(1)
            };

            shoppingBasket.AddtemToBasket(productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(4));

            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket2 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket2 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            ConsoleSetup(0);
            // Basket 3:

            shoppingBasket = new BLL.ShoppingBasket
            {
                OfferVoucher = offerVoucherRepository.GetOffVoucher(1)
            };

            shoppingBasket.AddtemToBasket(productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(4));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(5));

            //basketProcessorFactory = new BasketProcessorFactory();
            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket3 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket3 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            ConsoleSetup(0);
            // Basket 4:

            shoppingBasket = new BLL.ShoppingBasket
            {
                GiftVouchers = new List<GiftVoucher>
                {
                    giftVoucherRepository.GetGiftVoucher(1)
                },
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2)
            };

            shoppingBasket.AddtemToBasket(productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(4));

            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket4 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket4 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            ConsoleSetup(0);
            // Basket 5:

            shoppingBasket = new BLL.ShoppingBasket
            {
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2)
            };

            shoppingBasket.AddtemToBasket(productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(6));

            basetService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basetService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket5 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket5 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            Console.ReadLine();

        }

        private static void ConsoleSetup(int scenarioId)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"******** {scenarioId} ******************");
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
