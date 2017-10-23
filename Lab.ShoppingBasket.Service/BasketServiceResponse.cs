using System.Collections.Generic;

namespace Lab.ShoppingBasket.Service
{
    public class BasketServiceResponse
    {
        public List<string> Notifications { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public decimal BasketTotal { get; set; }
    }
}
