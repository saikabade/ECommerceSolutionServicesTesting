namespace ECommerce
{
    public class ShoppingCartItem
    {
        public int Qty { get; set; }

        public decimal Price { get; set; }

        public decimal GetTotal()
        {
            return Qty * Price;
        }
    }
}