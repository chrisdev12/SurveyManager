using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace Survey.WebService.IntegrationTests
{
    public abstract class IntegrationTestBase : IDisposable
    {
        protected readonly TestServer _testServer;
        protected readonly HttpClient _client;
        private const string integrationTestConfigFile = "appsettings.integrationTest.json";

        protected IntegrationTestBase()
        {
            _testServer = new TestServer(
                new WebHostBuilder()
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddJsonFile(integrationTestConfigFile, optional: false, reloadOnChange: true);
                    configuration.Build();
                })
                .UseStartup<StartupIntegrationTest>());
            _client = _testServer.CreateClient();
        }

        public void Dispose()
        {
            if(_testServer != null)
                _testServer.Dispose();
        }
    }
}
