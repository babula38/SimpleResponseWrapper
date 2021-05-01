using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using VerifyXunit;
using Xunit;

namespace ResponseWrapper.Integration.Test
{
    [UsesVerify]
    public class ResponseWrapperTest : IClassFixture<WebApplicationFactory<Sample.API.Startup>>
    {
        private static UrlBuilder Api => new();
        private readonly WebApplicationFactory<Sample.API.Startup> _factory;

        public ResponseWrapperTest(WebApplicationFactory<Sample.API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Check_if_api_is_working()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync(Api.Base);

            //assert
            response.EnsureSuccessStatusCode();
            await Verifier.Verify(response);
        }

        [Fact]
        public async Task Returns_wrapped_ok_response()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(Api.WrappedOkResponse);

            //assert
            response.EnsureSuccessStatusCode();
            await Verifier.Verify(response.Content.ReadAsStringAsync());
        }
    }

    internal class UrlBuilder //: IUrlBuilder
    {
        private const string BASE_URL = "test";

        public UrlBuilder()
        {
        }

        public string Base => BASE_URL;

        public string WrappedOkResponse => $"{Base}/ok";
    }

    internal interface IUrlBuilder
    {
    }
}