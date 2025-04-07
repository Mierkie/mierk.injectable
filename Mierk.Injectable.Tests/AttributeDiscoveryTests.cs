using Microsoft.Extensions.DependencyInjection;
using Mierk.Injectable.Tests.TestServices;

namespace Mierk.Injectable.Tests;

public class AttributeDiscoveryTests
{
    [Fact]
    public void Discovers_Injectable_Class_With_Interface()
    {
        var services = new ServiceCollection();
        services.RegisterInjectableServices([typeof(ScopedService).Assembly]);

        var provider = services.BuildServiceProvider();

        var service = provider.GetService<IScopedService>();
        Assert.NotNull(service);
        Assert.IsType<ScopedService>(service);
    }

    [Fact]
    public void Discovers_Injectable_Class_Without_Interface()
    {
        var services = new ServiceCollection();
        services.RegisterInjectableServices([typeof(SelfRegisteredService).Assembly]);

        var provider = services.BuildServiceProvider();

        var service = provider.GetService<SelfRegisteredService>();
        Assert.NotNull(service);
    }
}