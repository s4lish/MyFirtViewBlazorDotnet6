namespace BlazorAll.Client.Services.WeatherService
{
    public interface IWeatherService
    {
        WeatherForecast[]? forecasts { get; set; }

        Task GetForecasts();



    }
}
