using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace database.DesignTimeFactories
{
    public class BakedRecipeContextFactory : IDesignTimeDbContextFactory<RecipeContext>
    {
        public RecipeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecipeContext>();
            optionsBuilder.UseSqlite("Data Source=recipe.db");

            return new RecipeContext(optionsBuilder.Options);
        }
    }
}