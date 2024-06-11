namespace Core.Tests;

public class HydrationTests
{
    const double tolerance = 0.000001;

    [Fact]
    public void TestHydrationGivenIngredients()
    {
        var expected = 0.68;

        var starterMass = 289;
        var starterHydration = 1;
        var waterMass = 260.261905;
        var flourMass = 450.738095;

        var starter = new Starter(new Ingredients{Water = 289 / 2, Flour = 289 / 2});

        var actual = SourdoughService.Hydration(starterMass, starterHydration, waterMass, flourMass);

        Assert.Equal(expected, actual, tolerance);
    }
}