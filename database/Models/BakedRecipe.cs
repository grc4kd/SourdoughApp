public class BakedRecipe
{
    public int BakedRecipeId { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = null!;
}

