namespace database.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BakedRecipeContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Recipes.Any())
            {
                return; // db already seeded
            }

            var recipes = new BakedRecipe[] {
                new() {Ingredients=new Ingredient[]{
                    new Ingredient{SubstanceName="flour"},
                    new Ingredient{SubstanceName="water"},
                    new Ingredient{SubstanceName="salt"},
                    new Ingredient{SubstanceName="yeast"},
                }}
            };

            context.AddRange(recipes);
            context.SaveChanges();
        }
    }
}