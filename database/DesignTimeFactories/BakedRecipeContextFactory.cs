using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace database.DesignTimeFactories
{
    public class BakedRecipeContextFactory : IDesignTimeDbContextFactory<BakedRecipeContext>
    {
        public BakedRecipeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BakedRecipeContext>();
            optionsBuilder.UseSqlite("Data Source=recipe.db");

            return new BakedRecipeContext(optionsBuilder.Options);
        }
    }
}