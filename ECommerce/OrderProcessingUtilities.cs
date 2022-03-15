using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    public class OrderProcessingUtilities
    {
        public decimal GetSubtotalFromCart(ShoppingCart order)
        {
            return order.Items.Sum(i => i.GetTotal());
        }
    }
}
