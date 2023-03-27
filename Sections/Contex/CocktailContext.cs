using Microsoft.EntityFrameworkCore;
using OpgaverApi.Sections.Entities;

namespace OpgaverApi.Sections.Contex
{
    public class CocktailContext : DbContext
    {
        public CocktailContext(DbContextOptions<CocktailContext> options) : base(options) { }

        public DbSet<CocktailRecipe> Recipes { get; set; }

        public DbSet<CocktailIngredient> Ingredients { get; set; }

        public DbSet<Quantity> Quantities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CocktailIngredient>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
