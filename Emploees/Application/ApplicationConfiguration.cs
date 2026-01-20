namespace Emploees.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddZupService(this IServiceCollection services)
        {
            services.AddScoped<IZupService, ZupService>();

            return services;
        }

        public static IServiceCollection AddBuhService(this IServiceCollection services)
        {
            services.AddScoped<IBuhService, BuhService>();

            return services;
        }

        public static IServiceCollection AddAdUserService(this IServiceCollection services)
        {
            services.AddScoped<IAdUserService, AdUserService>();

            return services;
        }
    }
}
