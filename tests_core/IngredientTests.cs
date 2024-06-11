namespace Core.Tests;

public class IngredientTests
{
    const double tolerance = 0.000001;

    [Fact]
    public void TestIngredientsGivenSpecification()
    {
        var expectedWater = 260.261905;
        var expectedFlour = 450.738095;
        var expectedSalt = 9.09090;

        var starterMass = 289;
        var starterHydration = 1;
        var desiredHydration = 0.68;
        var desiredMass = 1000;

        var actual = SourdoughService.Ingredients(starterMass, starterHydration, desiredHydration, desiredMass);

        Assert.Equal(expectedWater, actual.Water, tolerance);
        Assert.Equal(expectedFlour, actual.Flour, tolerance);
        Assert.Equal(expectedSalt, actual.Salt, tolerance);
    }
}