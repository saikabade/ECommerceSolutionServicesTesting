using Xunit;

namespace ECommerce.UnitTests;

public class UnitTest1 // Must be a public class
{
    [Fact]
    public void CanAddTwoNumbers() // facts are methods that are void, and take no arguments.
    {
        // Given (Arrange) (create a whole new of version of everything)
        int x = 10, y = 20, answer;

        // When (Act)
        answer = x + y; // SUT

        // Then (Assert)
        Assert.Equal(30, answer);

    }

    [Theory]
    [InlineData(2,2,4)]
    [InlineData(3,3,6)]
    [InlineData(4,4,8)]
    public void CanAddAnyTwoNumbers(int x, int y, int expected)
    {
        var answer = x + y;
        Assert.Equal(expected, answer);
    }


}
// Ctrl+R and then A = run all tests
// Ctrl+R and then T = run the current test

// Ctrl+R and then Ctrl-A = Debug all tests
// Ctrl+R and then Ctrl-T = Debug Current Test
