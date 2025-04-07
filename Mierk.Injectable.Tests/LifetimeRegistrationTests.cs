using Microsoft.Extensions.DependencyInjection;
using Mierk.Injectable.Tests.TestServices;

namespace Mierk.Injectable.Tests;

public class LifetimeRegistrationTests
{
    [Fact]
    public void Registers_With_Correct_Lifetime_Singleton()
    {
        const ServiceLifetimeMode mode = ServiceLifetimeMode.Singleton;
        
        var services = new ServiceCollection();
        services.RegisterInjectableServices([typeof(ScopedService).Assembly]);

        var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(SelfRegisteredService));
        Assert.NotNull(descriptor);
        Assert.Equal(MapLifetime(mode), descriptor.Lifetime);
    }
    
    [Fact]
    public void Registers_With_Correct_Lifetime_Scoped()
    {
        const ServiceLifetimeMode mode = ServiceLifetimeMode.Scoped;
        
        var services = new ServiceCollection();
        services.RegisterInjectableServices([typeof(ScopedService).Assembly]);

        var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IScopedService));
        Assert.NotNull(descriptor);
        Assert.Equal(MapLifetime(mode), descriptor.Lifetime);
    }
    
    [Fact]
    public void Registers_With_Correct_Lifetime_Transient()
    {
        const ServiceLifetimeMode mode = ServiceLifetimeMode.Transient;
        
        var services = new ServiceCollection();
        services.RegisterInjectableServices([typeof(ScopedService).Assembly]);

        var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(ITransientService));
        Assert.NotNull(descriptor);
        Assert.Equal(MapLifetime(mode), descriptor.Lifetime);
    }

    private static ServiceLifetime MapLifetime(ServiceLifetimeMode mode) => mode switch
    {
        ServiceLifetimeMode.Singleton => ServiceLifetime.Singleton,
        ServiceLifetimeMode.Scoped => ServiceLifetime.Scoped,
        ServiceLifetimeMode.Transient => ServiceLifetime.Transient,
        _ => throw new ArgumentOutOfRangeException()
    };
}