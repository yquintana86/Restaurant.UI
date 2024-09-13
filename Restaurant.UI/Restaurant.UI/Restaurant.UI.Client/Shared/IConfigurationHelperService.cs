namespace Restaurant.UI.Client.Shared
{
    public class ConfigurationHelperService
    {
        private readonly IConfiguration _configuration;
        public static IConfiguration StaticConfig { get; set; } = null!;

        public ConfigurationHelperService(IConfiguration configuration)
        {
            _configuration = configuration;
            StaticConfig = _configuration;
        }
    }
}
