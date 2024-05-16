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
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<RecipeServiceFixture>()
            .Build();

        ConnectionString = configuration.GetConnectionString("RecipeDb") ?? throw new InvalidOperationException("User secret is missing for ConnectionString:RecipeDb");

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