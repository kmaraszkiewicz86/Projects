using Microsoft.Extensions.Configuration;

namespace Core.Helpers
{
    public static class ConnectionBuilderHelper
    {
        public static string GetDefaultConnectionString()
        {
            var connection = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return connection["ConnectionString"];
        }
    }
}
