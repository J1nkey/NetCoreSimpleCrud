namespace SimpleEcommerceApp.Options
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public int CommandTimeout { get; set; }
        public int MaxRetryCount { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
        public bool EnableDetailedErrors { get; set; }
    }
}
