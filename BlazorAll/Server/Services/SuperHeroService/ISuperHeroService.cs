namespace BlazorAll.Server.Services.SuperHeroService
{
    public interface ISuperHeroService
    {

        Task<List<SuperHero>> GetAll();
         
    }
}
