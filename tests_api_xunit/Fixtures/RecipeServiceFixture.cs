using System.Configuration;
using database;
using database.Data;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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

        ConnectionString = configuration.GetConnectionString("RecipeDb") ?? string.Empty;
    
        // fallback to LocalDb connection for testing on hosted runners
        if (ConnectionString.IsNullOrEmpty()) {
            ConnectionString = "Server=(localdb)\\mysqllocaldb;Database=BakingTestDb;Trusted_Connection=True;";
        }

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