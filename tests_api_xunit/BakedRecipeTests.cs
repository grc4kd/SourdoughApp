using webapi.Services;

namespace tests_api_xunit
{
    public class BakedRecipeTests : IClassFixture<RecipeServiceFixture>, IDisposable
    {
        public RecipeServiceFixture Fixture { get; }

        public BakedRecipeTests(RecipeServiceFixture fixture)
        => Fixture = fixture;

        public void Dispose()
        {
            Fixture.CreateContext().Dispose();
        }

        [Fact]
        public void GetRecipeTest()
        {
            var context = Fixture.CreateContext();
            var service = new RecipeService(context);
            var data = service.ReadRecipe();

            Assert.False(data == null);
        }

    }
}