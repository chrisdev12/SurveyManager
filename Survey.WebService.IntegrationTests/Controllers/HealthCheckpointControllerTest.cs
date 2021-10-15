using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Survey.WebService.Controllers;
using Survey.WebService.Responses;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Survey.WebService.IntegrationTests.Controllers
{
    public class HealthCheckpointControllerTest : IDisposable
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _client;
        private readonly string indexhealthCheckEndpoint = "/healthcheckpoint";

        public HealthCheckpointControllerTest()
        {
            // Arrange
            _testServer = new TestServer(new WebHostBuilder()
                .UseStartup<StatupTest>());
            _client = _testServer.CreateClient();
        }

        [Fact]
        public async Task TestGetHealthChecpoint()
        {
            var response = await _client.GetAsync(indexhealthCheckEndpoint);
            var responseString = await response.Content.ReadAsStringAsync();
            var controllerResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HealthCheckpointController.apiWorkingMessage, controllerResponse.Data);
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }
    }
}
