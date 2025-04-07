using Mierk.Injectable;

namespace SampleConsoleApp.Services;

[Injectable(ServiceLifetimeMode.Transient, typeof(IWeatherService))]
public class RandomForecastService : IWeatherService
{
    private readonly string _forecast = WeatherForecasts.GetForecast();
    
    public void DisplayWeather() => Console.WriteLine(_forecast);
}