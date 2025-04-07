using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Mierk.Injectable;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all classes that are marked with the <see cref="InjectableAttribute"/> for Dependency Injection
    /// </summary>
    /// <param name="services">An <see cref="IServiceCollection"/> instance to register the services to</param>
    /// <param name="assemblies">A collection of <see cref="Assembly">Assemblies</see> who's services should be registered</param>
    /// <param name="logRegistrations">Whether to log registrations (only applies for DEBUG mode)</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance for further configuring</returns>
    public static IServiceCollection RegisterInjectableServices(this IServiceCollection services, IEnumerable<Assembly> assemblies, bool logRegistrations = false)
    {
        var typesWithAttribute = assemblies.SelectMany(assembly => assembly.GetTypes())
            .Select(type => (Type: type, Attribute: type.GetCustomAttribute<InjectableAttribute>()))
            .Where(t => t.Attribute is not null);

        foreach (var (implementationType, attr) in typesWithAttribute)
        {
            foreach (var serviceType in attr!.ServiceTypes.DefaultIfEmpty(implementationType))
            {
                if (!serviceType.IsAssignableFrom(implementationType))
                    throw new InvalidOperationException($"{implementationType.Name} does not implement {serviceType.Name}");
                
                if (logRegistrations)
                    LogRegistration(serviceType, implementationType, attr.Lifetime);

                services = attr.Lifetime switch
                {
                    ServiceLifetimeMode.Singleton => services.AddSingleton(serviceType, implementationType),
                    ServiceLifetimeMode.Scoped => services.AddScoped(serviceType, implementationType),
                    ServiceLifetimeMode.Transient => services.AddTransient(serviceType, implementationType),
                    _ => throw new ArgumentOutOfRangeException(nameof(attr.Lifetime))
                };
            }
        }

        return services;
    }

    [Conditional("DEBUG")]
    private static void LogRegistration(Type serviceType, Type implementationType, ServiceLifetimeMode lifetime)
        => Console.WriteLine($"Registering {implementationType.Name} as {serviceType.Name} with {lifetime} lifetime");
}