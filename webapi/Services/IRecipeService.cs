using database.Models;

namespace webapi.Services;

public interface IRecipeService {
    public Recipe ReadRecipe();
}