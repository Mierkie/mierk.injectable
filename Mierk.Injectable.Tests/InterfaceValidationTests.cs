using Microsoft.Extensions.DependencyInjection;
using Mierk.Injectable.Tests.Invalid.TestServices;

namespace Mierk.Injectable.Tests;

public class InterfaceValidationTests
{
    [Fact]
    public void Throws_If_Class_Does_Not_Implement_Interface()
    {
        var services = new ServiceCollection();
        
        var exception = Assert.Throws<InvalidOperationException>(() =>
            services.RegisterInjectableServices([typeof(InvalidService).Assembly]));

        Assert.Contains("does not implement", exception.Message);
    }
}