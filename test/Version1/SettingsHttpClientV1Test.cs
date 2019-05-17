using PipServices.Settings.Client.Version1;
using PipServices3.Commons.Config;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Settings.Client.Test.Version1
{
    public class SettingsHttpClientV1Test : IDisposable
    {
        private static readonly ConfigParams HttpConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
        );

        private SettingsHttpClientV1 _client;
        private SettingsClientFixtureV1 _fixture;

        public SettingsHttpClientV1Test()
        {
            _client = new SettingsHttpClientV1();
            _client.Configure(HttpConfig);

            _fixture = new SettingsClientFixtureV1(_client);
            _client.OpenAsync(null);
        }

        public void Dispose()
        {
            _client.CloseAsync(null).Wait();
        }

        [Fact]
        public async Task TestCrudOperations()
        {
            await _fixture.TestCrudOperationsAsync();
        }
    }
}
