using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace Survey.WebService.IntegrationTests
{
    public abstract class IntegrationTestBase : IDisposable
    {
        protected readonly TestServer _testServer;
        protected readonly HttpClient _client;

        protected IntegrationTestBase()
        {
            _testServer = new TestServer(new WebHostBuilder()
                .UseStartup<StatupIntegrationTest>());
            _client = _testServer.CreateClient();
        }

        public void Dispose()
        {
            if(_testServer != null)
                _testServer.Dispose();
        }
    }
}
