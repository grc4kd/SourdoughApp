namespace Core.Tests;

public class DoughTests
{
    const double tolerance = 0.000001;

    [Fact]
    public void TestStarterHydrationOnConstruction() {
        var expectedMass = 289;
        var expectedHydration = 1;
        var starterWater = 144.5;
        var starterFlour = 144.5;

        var expectedIngredients = new Ingredients {
            Water = starterWater,
            Flour = starterFlour
        };

        var starter = new Starter(
            expectedIngredients
        );

        Assert.Equal(expectedMass, starter.Mass);
        Assert.Equal(expectedHydration, starter.Hydration, tolerance);
        Assert.Equal(expectedIngredients, starter.Ingredients);
    }

    [Fact]
    public void TestDoughHydrationOnConstruction()
    {
        var expectedMass = 1000;
        var expectedHydration = 0.68;

        var starterWater = 144.5;
        var starterFlour = 144.5;

        var expectedIngredients = new Ingredients
        {
            Water = 260.261905 + starterWater, 
            Flour = 450.738095 + starterFlour
        };

        var dough = new Dough(expectedIngredients);

        Assert.Equal(expectedMass, dough.Mass);
        Assert.Equal(expectedHydration, dough.Hydration, tolerance);
        Assert.Equal(expectedIngredients, dough.Ingredients);
    }

    [Fact]
    public void TestDoughHydrationOnMixWith() 
    {
        var expectedHydration = 0.68;

        var starterWater = 144.5;
        var starterFlour = 144.5;
        var water = 260.261905;
        var flour = 450.738095;
        var salt = 9.09090;

        var starter = new Starter(new Ingredients{
            Water = starterWater,
            Flour = starterFlour
        });

        var expectedIngredients = new Ingredients {
            Water = starterWater + water,
            Flour = starterFlour + flour,
            Salt = salt
        };

        var dough = starter.MixWith(water, flour, salt);

        Assert.Equal(expectedHydration, dough.Hydration, tolerance);
        Assert.Equivalent(expectedIngredients, dough.Ingredients);
    }
}