using System.Configuration;
using System.Data.Common;
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
            .AddEnvironmentVariables()
            .Build();

        ConnectionString = configuration.GetConnectionString("RecipeDb") ?? string.Empty;
    
        // fallback to environment variable for hosted runners
        if (ConnectionString.IsNullOrEmpty()) {
            var MSSQL_SA_PASSWORD = Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD");

            if (MSSQL_SA_PASSWORD.IsNullOrEmpty()) {
                throw new InvalidOperationException("There are no available configurations for SQL Server, cannot initialize test fixture.");
            }

            var connectionBuilder = new DbConnectionStringBuilder
            {
                { "Data Source", "localhost" },
                { "User", "sa" },
                { "Password", Environment.GetEnvironmentVariable("MSSQL_SA_PASSWORD") ?? string.Empty },
                { "Initial Catalog", "RecipeDb" },
                { "TrustServerCertificate", true}
            };

            ConnectionString = connectionBuilder.ConnectionString;
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