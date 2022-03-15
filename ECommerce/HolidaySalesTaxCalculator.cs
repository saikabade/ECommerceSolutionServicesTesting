using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    public class HolidaySalesTaxCalculator : ICalculateSalesTaxForOrders
    {
        public decimal GetTaxForOrder(decimal subTotal, string zipCode)
        {
            return 0; // We are not charging tax now!
        }
    }
}
