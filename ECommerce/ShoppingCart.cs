namespace ECommerce
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public string ZipCode { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
    }
}