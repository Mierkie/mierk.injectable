using Mierk.Injectable;

namespace SampleConsoleApp.Services;

[Injectable(ServiceLifetimeMode.Singleton)]
public class CachedForecastService : IWeatherService
{
    private readonly string _forecast = WeatherForecasts.GetForecast();
    
    public void DisplayWeather() => Console.WriteLine(_forecast);
}