
namespace BlazorAll.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> SuperHeros { get; set; }

        Task<string> GetSuperHeros();
    }
}
