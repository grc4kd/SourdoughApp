using database;
using database.Data;
using Microsoft.EntityFrameworkCore;

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

    public RecipeContext CreateContext()
        => new RecipeContext(
            new DbContextOptionsBuilder<RecipeContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}