
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorAll.Client.Services.SuperHeroService
{
    public class SuperHerohttpService : ISuperHerohttpService
    {
        private readonly HttpClient _http;

        JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);
        public SuperHerohttpService(HttpClient http)
        {
            _http = http;
        }


        public List<SuperHero> SuperHeros { get; set; }

        public async Task<string> GetAllSuperHeros()
        {
            var res = await _http.GetAsync("api/SuperHero/all");


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

        public async Task<PagingResponse<SuperHero>> GetSuperHeros(SuperHeroParametes parametes)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = parametes.PageNumber.ToString()
            };
            var query = QueryHelpers.AddQueryString("api/SuperHero", queryStringParam);

            var response = await _http.GetAsync(query);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var pagingResponse = new PagingResponse<SuperHero>
            {
                Items = JsonSerializer.Deserialize<List<SuperHero>>(content, _jsonOptions),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _jsonOptions)
            };

            return pagingResponse;

        }
    }
}
