namespace BlazorAll.Server.Data;

    public class BlazorDBContext : DbContext
    {
        public BlazorDBContext (DbContextOptions<BlazorDBContext> opt) : base(opt) { }

        public DbSet<SuperHero>? SuperHeroes { get; set; }

    }

