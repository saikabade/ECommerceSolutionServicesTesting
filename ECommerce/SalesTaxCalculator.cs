namespace ECommerce
{
    public class SalesTaxCalculator : ICalculateSalesTaxForOrders
    {
        public SalesTaxCalculator()
        {
        }

        public decimal CalculateSalesTaxOnAmount(decimal amountOfSale, string zipCode)
        {
           if(zipCode == "44107")
            {
                return amountOfSale * .07M;
            } else
            {
                return amountOfSale * .10M;
            }
            
        }

        public decimal GetTaxForOrder(decimal subTotal, string zipCode)
        {
           return CalculateSalesTaxOnAmount(subTotal, zipCode);
        }
    }
}