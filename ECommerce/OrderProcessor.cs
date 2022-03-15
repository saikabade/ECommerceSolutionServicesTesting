namespace ECommerce
{
    public class OrderProcessor
    {
        private readonly ICalculateSalesTaxForOrders _salesTaxCalculator;
        private readonly IDealWithCustomerLoyalty _customerLoyalty;
        public OrderProcessor(ICalculateSalesTaxForOrders salesTaxCalculator, IDealWithCustomerLoyalty customerLoyalty)
        {
            _salesTaxCalculator = salesTaxCalculator;
            _customerLoyalty = customerLoyalty;
        }
        // Don't create this without this.
        public OrderSummary ProcessOrder(ShoppingCart order)
        {

            var numberOfItems = order.Items.Count;
            if (numberOfItems == 0)
            {
                throw new CartCannotBeEmptyException();
            }
            var utils = new OrderProcessingUtilities();
            decimal subTotal = utils.GetSubtotalFromCart(order);

            //var salesTax = new SalesTaxCalculator();
            //decimal tax = salesTax.CalculateSalesTaxOnAmount(subTotal, order.ZipCode);
            decimal tax = _salesTaxCalculator.GetTaxForOrder(subTotal, order.ZipCode);

            // Orders with a total over $100 get a thank you card.
            if (subTotal >= 100)
            {
                // Tell don't ask
                _customerLoyalty.SendLargeOrderThankYou(order.EmailAddress);
             }

          
            return new OrderSummary
            {
                NumberOfItems = numberOfItems,
                SubTotal = subTotal,
                SalesTax = tax,
                Total = subTotal + tax
            };
        }

        
    }
}