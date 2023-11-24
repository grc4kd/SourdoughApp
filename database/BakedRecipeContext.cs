using database.Models;
using Microsoft.EntityFrameworkCore;

namespace database;

public class RecipeContext(DbContextOptions<RecipeContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; }
}