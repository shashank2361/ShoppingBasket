
namespace Lab.ShoppingBasket.Utilities.Extensions.DataTypes.Decimal
{
    public static class DecimalExtensions
    {
        public static decimal ConvertPercentToDecimal(this decimal percent)
        {
            return percent/100;
        }
    }

}
