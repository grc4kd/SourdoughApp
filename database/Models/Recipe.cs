namespace database.Models;

public class Recipe
{
    public int Id { get; set; }
    public ICollection<MeasuredIngredient> Ingredients { get; set; } = new List<MeasuredIngredient>();
    public ICollection<Step> Steps {get;set;} = new List<Step>();
}