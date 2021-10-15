using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjecton;
using System.Reflection;

namespace Survey.WebService.IntegrationTests
{
    public class StatupTest
    {
        public StatupTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string AssemblyOriginalApiName = "Survey.WebService";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddSingleton(Configuration)
                .AddDataServices()
                .AddDomainServices()
                //As the controllers are from another assembly,
                //we have to load in that assembly and then call the AddControllersAsServices method.
                .AddControllers().AddApplicationPart(Assembly.Load(AssemblyOriginalApiName)).AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
