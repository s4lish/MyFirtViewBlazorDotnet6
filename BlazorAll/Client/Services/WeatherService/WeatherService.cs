

namespace BlazorAll.Client.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _http;
        public WeatherService(HttpClient http)
        {
            _http = http;
        }
        public WeatherForecast[]? forecasts { get; set; } = null;


        public async Task GetForecasts()
        {
            forecasts = await _http.GetFromJsonAsync<WeatherForecast[]>("api/WeatherForecast");
        }
    }
}
