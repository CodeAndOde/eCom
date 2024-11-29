using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCom.Infrastructure.DBContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        // Constructor that takes IConfiguration
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
             string? connectionString = _configuration.GetConnectionString("PostgresConnection");

            _connection = new NpgsqlConnection(connectionString);
                               
        }

        public IDbConnection DbConnection => _connection;
    }
}
