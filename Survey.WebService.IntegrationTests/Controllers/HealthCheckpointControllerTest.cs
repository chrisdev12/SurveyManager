using Newtonsoft.Json;
using Survey.WebService.Controllers;
using Survey.WebService.Responses;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Survey.WebService.IntegrationTests.Controllers
{
    public class HealthCheckpointControllerTest : IntegrationTestBase
    {
        private readonly string indexHealthCheckEndpoint = "/healthcheckpoint";

        [Fact]
        public async Task TestGetHealthCheckpoint()
        {
            var response = await _client.GetAsync(indexHealthCheckEndpoint);
            var responseString = await response.Content.ReadAsStringAsync();
            var controllerResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HealthCheckpointController.apiWorkingMessage, controllerResponse.Data);
        }
    }
}
