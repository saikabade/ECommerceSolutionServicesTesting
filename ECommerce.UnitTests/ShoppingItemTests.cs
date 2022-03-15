using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests;

public class ShoppingItemTests
{

    [Theory]
    [ClassData(typeof(ShoppingItemsTestData))]
    public void CanProduceTotal(ShoppingCartItem item, decimal expectedTotal)
    {
       // var someObjects = ObjectMother.GetMeAnOrder();

        Assert.Equal(expectedTotal, item.GetTotal());
    }

   
}
