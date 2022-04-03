
using System.Net.Http.Json;

namespace BlazorAll.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        public SuperHeroService(HttpClient http)
        {
            _http = http;
        }


        public List<SuperHero> SuperHeros { get; set; } = new List<SuperHero>();

        public async Task GetSuperHeros()
        {
            SuperHeros = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
        }
    }
}
