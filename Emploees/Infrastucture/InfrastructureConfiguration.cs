using Emploees.Infrastucture.AD;
using Emploees.Infrastucture.Buh;
using Emploees.Infrastucture.Zup;
using System.Net.Http.Headers;
using System.Text;

namespace Emploees.Infrastucture
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddZupClient(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationSection = configuration.GetSection(nameof(ZupConfig));

            services.Configure<ZupConfig>(configurationSection);

            var config = configurationSection.Get<ZupConfig>()
                ?? throw new InvalidOperationException("ZupConfig not found");

            services.AddHttpClient<ZupClient>(client =>
            {
                client.BaseAddress = new Uri(config.BaseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{config.UserName}:{config.Password}")));

            });

            return services;
        }
        public static IServiceCollection AddBuhClient(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationSection = configuration.GetSection(nameof(BuhConfig));

            services.Configure<BuhConfig>(configurationSection);

            var config = configurationSection.Get<BuhConfig>()
                ?? throw new InvalidOperationException("BuhConfig not found");

            services.AddHttpClient<BuhClient>(client =>
            {
                client.BaseAddress = new Uri(config.BaseAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{config.UserName}:{config.Password}")));

            });

            return services;
        }

        public static IServiceCollection AddAdClient(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationSection = configuration.GetSection(nameof(AdConfig));

            services.Configure<AdConfig>(configurationSection);

            var config = configurationSection.Get<AdConfig>()
                ?? throw new InvalidOperationException("AdConfig not found");

            services.AddHttpClient<AdClient>(client =>
            {
                client.BaseAddress = new Uri(config.BaseAddress);
                client.DefaultRequestHeaders.Add("Key", config.ApiKey);
            });

            return services;
        }

    }
}
