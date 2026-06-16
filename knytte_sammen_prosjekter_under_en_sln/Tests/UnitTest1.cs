using Classes;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void AddingService_AddsTwoNumbers()
    {
        var service = new AddingService();

        var result = service.Add(1,2);
        Assert.Equal(3, result);
    }
}
