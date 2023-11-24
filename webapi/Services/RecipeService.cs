using System;
using System.Linq;
using database;
using database.Models;

namespace webapi.Services;

public class RecipeService : IRecipeService
{
    private readonly BakedRecipeContext _context;

    public RecipeService(BakedRecipeContext context)
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
