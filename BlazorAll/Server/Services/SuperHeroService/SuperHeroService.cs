namespace BlazorAll.Server.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly BlazorDBContext _dbContext;
        public SuperHeroService(BlazorDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SuperHero>> GetAll()
        {
            var heros = await _dbContext.SuperHeroes.ToListAsync();

            return heros;
        }
    }
}
