using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests;

public class CalculatingSalesTaxOnOrders
{

    [Theory]
    [InlineData(100,"44107", 7)]
    [InlineData(200, "44107", 14)]
    [InlineData(100, "44319", 10)]
    public void CanCalculateSalesTaxOnAmount(decimal amountOfSale, string zipCode, decimal expected)
    {
        var salesTaxCalculator = new SalesTaxCalculator();
       
        decimal salesTax = salesTaxCalculator.CalculateSalesTaxOnAmount(amountOfSale, zipCode);

        Assert.Equal(expected, salesTax);
        
    }
}
