using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests.TestDoubles;

public class DummySalesTaxCalculator : ICalculateSalesTaxForOrders
{
    public decimal GetTaxForOrder(decimal subTotal, string zipCode)
    {
        return 0; 
    }
}
