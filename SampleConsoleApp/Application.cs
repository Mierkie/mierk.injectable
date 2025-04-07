using Microsoft.Extensions.DependencyInjection;
using Mierk.Injectable;
using SampleConsoleApp.Services;

namespace SampleConsoleApp;

public static class Application
{
    public static void Run()
    {
        var serviceProvider = BuildServiceProvider();
        
        DisplayFiveDifferentWeatherForecasts(serviceProvider);
        DisplayFiveSameWeatherForecasts(serviceProvider);
    }

    private static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        
        return services
            .RegisterInjectableServices([typeof(Application).Assembly])
            .BuildServiceProvider();
    }

    private static void DisplayFiveDifferentWeatherForecasts(IServiceProvider serviceProvider)
    {
        Console.WriteLine("Transient (different each time):");
        
        for (var i = 0; i < 5; i++)
            serviceProvider.GetRequiredService<IWeatherService>().DisplayWeather();
    }
    
    private static void DisplayFiveSameWeatherForecasts(IServiceProvider serviceProvider)
    {
        Console.WriteLine("Singleton (same instance):");
        
        for (var i = 0; i < 5; i++)
            serviceProvider.GetRequiredService<CachedForecastService>().DisplayWeather();
    }
}