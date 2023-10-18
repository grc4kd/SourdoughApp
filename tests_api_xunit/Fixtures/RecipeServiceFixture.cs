using database;
using database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class RecipeServiceFixture
{
    private readonly string ConnectionString;
    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public RecipeServiceFixture()
    {
        ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Database=BakingTestDb";

        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    DbInitializer.Initialize(context);
                }

                _databaseInitialized = true;
            }
        }
    }

    public BakedRecipeContext CreateContext()
        => new BakedRecipeContext(
            new DbContextOptionsBuilder<BakedRecipeContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}