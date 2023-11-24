using webapi.Services;

namespace tests_api_xunit
{
    public class RecipeTests : IClassFixture<RecipeServiceFixture>, IDisposable
    {
        public RecipeServiceFixture Fixture { get; }

        public RecipeTests(RecipeServiceFixture fixture)
        => Fixture = fixture;

        public void Dispose()
        {
            Fixture.CreateContext().Dispose();
            GC.SuppressFinalize(this);
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