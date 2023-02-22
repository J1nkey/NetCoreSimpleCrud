using Microsoft.Data.SqlClient;
using System.Data;

namespace SimpleEcommerceApp.Data
{
    public class ApplicationDapperContext
    {
        private const string ConnectionStringSectionName = "SimpleEcommerceAppDb";
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationDapperContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new NullReferenceException("Configuration has not reference");
            _connectionString = _configuration.GetConnectionString(ConnectionStringSectionName);
        }

        public IDbConnection CreateConnection() =>
            new SqlConnection(_connectionString);
    }
}
