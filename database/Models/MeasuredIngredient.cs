namespace database.Models;

public class MeasuredIngredient
{
    public int Id { get; set; }
    public required Measure Measure { get; set; }
    public required Ingredient Ingredient { get; set; }
}