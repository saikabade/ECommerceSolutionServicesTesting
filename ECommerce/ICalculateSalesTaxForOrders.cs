namespace ECommerce;

public interface ICalculateSalesTaxForOrders
{
    decimal GetTaxForOrder(decimal subTotal, string zipCode);
}
