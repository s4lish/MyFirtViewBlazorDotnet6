namespace BlazorAll.Server.Services.SuperHeroService
{
    public interface ISuperHeroService
    {

        Task<List<SuperHero>> GetAll();
        Task<PagedList<SuperHero>> GetInfo(SuperHeroParametes superHeroParametes);
    }
}
