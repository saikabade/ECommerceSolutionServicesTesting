using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests;

public class CustomerLoyaltyForLargeOrders
{
    [Fact]
    public void OrdersAtThresholdAndLargerShouldGetEmailSent()
    {
        // Given
        var cart = new ShoppingCart
        {
            EmailAddress = "joe@aol.com",
            Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem { Price = 100M, Qty = 1}
            }
        };

        var mockedLoyalty = new Mock<IDealWithCustomerLoyalty>();
        var orderProcessor = new OrderProcessor(new Mock<ICalculateSalesTaxForOrders>().Object, mockedLoyalty.Object);


        // When
        orderProcessor.ProcessOrder(cart);


        // Then
        mockedLoyalty.Verify(v => v.SendLargeOrderThankYou("joe@aol.com"),Times.Once);


    }

    [Fact]
    public void OrdersUnderThresholdGetNoEmail()
    {
        // Given
        var cart = new ShoppingCart
        {
            EmailAddress = "joe@aol.com",
            Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem { Price = 99.99M, Qty = 1}
            }
        };

        var mockedLoyalty = new Mock<IDealWithCustomerLoyalty>();
        var orderProcessor = new OrderProcessor(new Mock<ICalculateSalesTaxForOrders>().Object, mockedLoyalty.Object);


        // When
        orderProcessor.ProcessOrder(cart);


        // Then 
        mockedLoyalty.Verify(v => v.SendLargeOrderThankYou(It.IsAny<string>()), Times.Never);
    }
}
