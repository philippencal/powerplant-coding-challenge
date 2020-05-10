using Microsoft.Extensions.DependencyInjection;
using PowerPlant.Application.Interfaces;
using PowerPlant.Application.Services;

namespace PowerPlant.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IPowerCalculateAppService, PowerCalculateAppService>();
        }
    }
}
