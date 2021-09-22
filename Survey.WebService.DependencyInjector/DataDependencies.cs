using Microsoft.Extensions.DependencyInjection;
using Survey.WebService.DataAccess.DbContexts.Survey;
using Survey.WebService.Models;
using Survey.WebService.Repository;

namespace Microsoft.Extensions.DependencyInjecton
{
    public static class DataDependencies
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services
                .AddScoped<ISurveyContext, SurveyContext>()
                .AddScoped<IRepository<SurveyModel>, SurveyRepository>()
                .AddScoped<IRepository<QuestionModel>, QuestionRepository>()
                .AddScoped<IMemberRepository, MemberRepository>();


            return services;
        }
    }
}
