using Microsoft.Extensions.Logging;

namespace PowerPlant.Api.Configurations
{
    public static class LoggingSetup
    {
        public static void ConfigureLoggingSetup(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/powerplant-api-{Date}.txt");
        }
    }
}
