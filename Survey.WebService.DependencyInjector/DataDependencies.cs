using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Repository;

namespace Microsoft.Extensions.DependencyInjecton
{
    public static class DataDependencies
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<ISurveyContext, SurveyContext>();
            services.AddScoped<IAspectRepository, AspectRepository>();

            return services;
        }
    }
}
