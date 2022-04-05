
using System.Net;
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


        public List<SuperHero> SuperHeros { get; set; }

        public async Task<string> GetSuperHeros()
        {
            var res = await _http.GetAsync("api/SuperHero");


            if (res.IsSuccessStatusCode)
            {
                SuperHeros = new List<SuperHero>();
                SuperHeros = await res.Content.ReadFromJsonAsync<List<SuperHero>>();
                return "";
            }
            else if(res.StatusCode == HttpStatusCode.Unauthorized)
            {
                SuperHeros = null;
                return "خطای احراز هویت";
            }
            else if (res.StatusCode == HttpStatusCode.NotFound)
            {
                SuperHeros = null;
                return "اطلاعات یافت نشد.";
            }
            else
            {
                SuperHeros = null;
                return "خطای سیستمی در دریافت اطلاعات از وب سرویس";

            }

        }
    }
}
