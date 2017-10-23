namespace Lab.ShoppingBasket.DAL
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
