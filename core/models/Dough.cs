

namespace Core;

public class Dough
{
    public double Hydration => SourdoughService.Hydration(Ingredients.Water, Ingredients.Flour);
    public readonly double Mass;

    public readonly Ingredients Ingredients;

    public Dough(Ingredients ingredients)
    {
        Ingredients = ingredients;
        // salt is not accounted for in hydration or mass calculations for sourdough recipes
        Mass = ingredients.Water + ingredients.Flour;
    }

    public Dough MixWith(double water, double flour, double salt)
    {
        return new Dough(
            new Ingredients
            {
                Water = Ingredients.Water + water,
                Flour = Ingredients.Flour + flour,
                Salt = Ingredients.Salt + salt
            });
    }
}