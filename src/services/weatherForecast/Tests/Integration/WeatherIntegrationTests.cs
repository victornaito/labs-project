using System.Linq;
using System.Net;
using System.Net.Http;
using labs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Weather.IntegrationTests
{
    public class WeatherIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public WeatherIntegrationTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this._httpClient ??= webApplicationFactory
                .WithWebHostBuilder(_ => _.UseTestServer())
                .CreateClient();
        }

        [Fact]
        public async void WeatherAPI_MustReturnNotNull()
        {
            var response = await _httpClient.GetAsync("WeatherForecast/");
            Assert.Equal(HttpStatusCode.OK.GetHashCode(), response.StatusCode.GetHashCode());
            var weathers = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(weathers.Cast<object>());
        }
    }
}
