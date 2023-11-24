using database.Models;
using Microsoft.EntityFrameworkCore;

namespace database;

public class BakedRecipeContext : DbContext
{
    public BakedRecipeContext(DbContextOptions<BakedRecipeContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
}