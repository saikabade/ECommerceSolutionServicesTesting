using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests
{
    public class ShoppingItemsTestData : IEnumerable<Object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
           

            yield return new object[] { new ShoppingCartItem { Qty = 1, Price = 10 }, 10 };
            yield return new object[] { new ShoppingCartItem { Qty = 2, Price = 10 }, 20 };
            yield return new object[] { new ShoppingCartItem { Qty = 3, Price = 15.29M }, 45.87M };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
