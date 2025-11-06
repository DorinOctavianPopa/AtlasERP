using Xunit;

public class BasicTests
{
    [Fact]
    public void HelloWorldTest()
    {
        Assert.Equal(1 + 1, 2);
    }
}