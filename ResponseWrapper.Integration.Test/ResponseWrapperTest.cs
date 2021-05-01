using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace ResponseWrapper.Integration.Test
{
    public class ResponseWrapperTest : IClassFixture<WebApplicationFactory<Sample.API.Startup>>
    {
        private readonly WebApplicationFactory<Sample.API.Startup> _factory;

        public ResponseWrapperTest(WebApplicationFactory<Sample.API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test1Async()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync(Api.Base);

            //assert
            response.EnsureSuccessStatusCode();
        }

        private UrlBuilder Api => new UrlBuilder();
    }

    internal class UrlBuilder
    {
        private const string BASE_URL = "test1";

        public UrlBuilder()
        {
        }

        public string Base => BASE_URL;
    }
}