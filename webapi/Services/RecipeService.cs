using System;
using System.Linq;
using database;
using database.Models;

namespace webapi.Services;

public class RecipeService : IRecipeService
{
    private readonly RecipeContext _context;

    public RecipeService(RecipeContext context)
    {
        _context = context;
    }

    public Recipe ReadRecipe()
    {
        Console.WriteLine("Querying for a recipe");

        return _context.Recipes
            .OrderBy(r => r.Id)
            .First();
    }
}
