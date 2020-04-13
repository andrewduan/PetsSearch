using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PetsSearchApplication.Implements;
using PetsSearchApplication.Interfaces;
using PetsSearchApplication.Settings;

namespace PetsSearchApplication
{
    public static class Bootstrap
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureSettings(services, configuration);
            services.TryAddScoped<IPetsService, PetsService>();
            services.TryAddScoped<IHttpClient, PetsHttpClient>();

        }

        private static void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("AppSettings");
            var baseUrl = section["BaseUrl"];
            services.AddSingleton(typeof(UriSetting), new UriSetting(baseUrl));
        }
    }
}
