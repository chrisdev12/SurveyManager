using Microsoft.Extensions.DependencyInjection;
using Survey.WebService.Services;

namespace Microsoft.Extensions.DependencyInjecton
{
    public static class DomainDependencies
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAspectService, AspectService>();

            return services;
        }
    }
}