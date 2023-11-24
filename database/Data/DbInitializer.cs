using database.Models;

namespace database.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RecipeContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Recipes.Any())
            {
                return; // db already seeded
            }

            var oneCupFlour = new MeasuredIngredient()
            {
                Measure = new Measure("cup", 1.0f),
                Ingredient = new Ingredient() { Name = "flour" }
            };

            var scantCupWater = new MeasuredIngredient()
            {
                Measure = new Measure("cup", 0.90f),
                Ingredient = new Ingredient() { Name = "water" }
            };

            var recipe = new Recipe() { 
                Ingredients = new[] { oneCupFlour, scantCupWater }, 
                Steps = new[] { new Step("mix flour and water together"), new Step("bake until toasted and cooked through") } 
            };

            context.Add(recipe);
            context.SaveChanges();
        }
    }
}