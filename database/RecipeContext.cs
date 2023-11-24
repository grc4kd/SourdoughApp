using database.Models;
using Microsoft.EntityFrameworkCore;

namespace database;

public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeasuredIngredient>().Navigation(mi => mi.Measure).AutoInclude();
        modelBuilder.Entity<MeasuredIngredient>().Navigation(mi => mi.Ingredient).AutoInclude();
    }
}