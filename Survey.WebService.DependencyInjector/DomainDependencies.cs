using Microsoft.Extensions.DependencyInjection;
using Survey.WebService.Services;

namespace Microsoft.Extensions.DependencyInjecton
{
    public static class DomainDependencies
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IGeneralSurveyService, GeneralSurveyService>();

            return services;
        }
    }
}