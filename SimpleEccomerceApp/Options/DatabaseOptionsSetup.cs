using Microsoft.Extensions.Options;

namespace SimpleEcommerceApp.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private const string SectionName = "DatabaseOptions";
        private readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            options.ConnectionString = _configuration.GetConnectionString("SimpleEcommerceAppDb");
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
