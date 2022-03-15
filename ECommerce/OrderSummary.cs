namespace ECommerce
{
    public class OrderSummary
    {
        public int NumberOfItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}