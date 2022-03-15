global using Xunit;
global using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests;

public class ProcessingOrders
{
    [Fact]
    public void CanGiveMeATotalNumberOfItems()
    {
        // Given
        // This is a dummy that we created.
        var orderProcessor = new OrderProcessor(new TestDoubles.DummySalesTaxCalculator(), new Mock<IDealWithCustomerLoyalty>().Object);

        var order = new ShoppingCart
        {
            Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem(),
                new ShoppingCartItem()
            }
        };
        // When
        OrderSummary summary = orderProcessor.ProcessOrder(order);
        // Then
        Assert.Equal(2, summary.NumberOfItems);

    }
    [Fact]
    public void CalculatesSubtotal()
    {
        // This is a dummy created using Moq. It does the same thing we did above, but with less code.
        var orderProcessor = new OrderProcessor(new Mock<ICalculateSalesTaxForOrders>().Object, new Mock<IDealWithCustomerLoyalty>().Object);

        var order = new ShoppingCart
        {
            Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem() { Qty = 1, Price=1.99M},
                new ShoppingCartItem() { Qty = 3, Price=10.00M}
            }
        };
        // When
        OrderSummary summary = orderProcessor.ProcessOrder(order);


        decimal subTotal = summary.SubTotal;
        Assert.Equal(31.99M, subTotal);
    }

    [Fact]
    public void EmptyBasketCannotBeProcessed()
    {
        // Given
        var orderProcessor = new OrderProcessor(new Mock<ICalculateSalesTaxForOrders>().Object, new Mock<IDealWithCustomerLoyalty>().Object);

        var order = new ShoppingCart();

        // When/Then

        Assert.Throws<CartCannotBeEmptyException>(() => orderProcessor.ProcessOrder(order));
    }

    [Fact]
    public void HasCorrectTaxAndTotal()
    {
        // Set a trap:
        // - IF you get called with the right total, and the right zip code, return $99.99, otherwise return 0.
        var stubbedTaxCalculator = new Mock<ICalculateSalesTaxForOrders>();
        stubbedTaxCalculator.Setup(c => c.GetTaxForOrder(31.99M, "44107")).Returns(99.99M);

        // otherwise, I'm a dummy. (return 0).

        var orderProcessor = new OrderProcessor(stubbedTaxCalculator.Object, new Mock<IDealWithCustomerLoyalty>().Object);

        var order = new ShoppingCart
        {
            ZipCode = "44107",

            Items = new List<ShoppingCartItem>
            {
                new ShoppingCartItem() { Qty = 1, Price=1.99M},
                new ShoppingCartItem() { Qty = 3, Price=10.00M}
            }
        };
        // When
        OrderSummary summary = orderProcessor.ProcessOrder(order);
        // Our order processory passed the right arguments to the tax calculator, and used the value returned
        // as the tax.

        decimal subTotal = summary.SubTotal;
        decimal tax = summary.SalesTax;
        decimal total = summary.Total;
        Assert.Equal(31.99M, subTotal);
        Assert.Equal(99.99M, tax);
        Assert.Equal(31.99M + 99.99M, total);
    }
}
