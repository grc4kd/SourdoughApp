using Microsoft.EntityFrameworkCore;

namespace database
{
    public class BakedRecipeContext : DbContext
    {
        public BakedRecipeContext(DbContextOptions<BakedRecipeContext> options) : base(options)
        {
        }

        public DbSet<BakedRecipe> Recipes { get; set; } = default!;
    }
}