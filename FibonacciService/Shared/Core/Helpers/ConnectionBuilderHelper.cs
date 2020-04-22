using Microsoft.Extensions.Configuration;

namespace Core.Helpers
{
    public static class ConnectionBuilderHelper
    {
        public static IConfiguration BuildDefault()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetDefaultConnectionString()
        {

            return BuildDefault()["ConnectionString"];
        }
    }
}
