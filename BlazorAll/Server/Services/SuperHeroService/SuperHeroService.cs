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

        public async Task<PagedList<SuperHero>> GetInfo(SuperHeroParametes superHeroParametes)
        {

            var queryable = _dbContext.SuperHeroes.AsQueryable();

            var pagedlist = PagedList<SuperHero>.ToPagedList(queryable,superHeroParametes.PageNumber,superHeroParametes.PageSize);

            return pagedlist;

        }
    }
}
