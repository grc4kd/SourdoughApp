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
        ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BakingTestDb;Trusted_Connection=True;";

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