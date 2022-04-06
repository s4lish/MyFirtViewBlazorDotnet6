
namespace BlazorAll.Client.Services.SuperHeroService
{
    public interface ISuperHerohttpService
    {
        List<SuperHero> SuperHeros { get; set; }

        Task<string> GetAllSuperHeros();

        Task<PagingResponse<SuperHero>> GetSuperHeros(SuperHeroParametes parametes);
    }
}
