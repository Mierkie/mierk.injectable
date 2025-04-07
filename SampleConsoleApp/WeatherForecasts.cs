namespace SampleConsoleApp;

public static class WeatherForecasts
{
    private static readonly string[] Forecasts =
    [
        "Sunny, 25°C",
        "Partly Cloudy, 22°C",
        "Rainy, 17°C",
        "Thunderstorms, 18°C",
        "Snowy, -2°C",
        "Foggy, 10°C",
        "Severe Storms, 16°C",
        "Light Snow, -1°C",
        "Tornado Warning, 20°C",
        "Showers, 19°C",
        "Hot and Sunny, 32°C",
        "Windy, 15°C",
        "Misty, 11°C",
        "Rain Expected, 14°C",
        "Heatwave, 38°C"
    ];

    private static readonly Random Random = new();

    public static string GetForecast() =>
        Forecasts[Random.Next(Forecasts.Length)];
}