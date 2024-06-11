using webapi.models;

namespace tests_api
{
    public class Tests
    {
        [Fact]
        public void StarterMix_SetIngredients_StarterTestFields()
        {
            var expectedWater = 125;
            var expectedFlour = 125;
            var expectedMass = 250;
            var expectedHydration = 1;

            var starterMix = new Starter(expectedWater, expectedFlour);

            Assert.Equal(starterMix.Mass, expectedMass);
            Assert.Equal(starterMix.Hydration, expectedHydration);
        }
    }
}