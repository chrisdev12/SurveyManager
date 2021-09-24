using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjecton;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Survey.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string defaultCorsPolicy = "defaultPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(Configuration)
                .AddDataServices()
                .AddDomainServices()
                .AddControllers();

            services.AddCors(ConfigureCors);
        }

        public void ConfigureCors(CorsOptions cors)
        {
            List<string> domainsAllowed = Configuration.GetSection("CorsAllowedDomains").Get<List<string>>();
            cors.AddPolicy(defaultCorsPolicy, builder =>
            {
                domainsAllowed.ForEach(domain => builder.WithOrigins(domain).AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(defaultCorsPolicy);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
