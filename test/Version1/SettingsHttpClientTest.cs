using PipServices.Commons.Config;
using PipServices.Settings.Client.Version1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PipServices.Settings.Client.Test.Version1
{
    public class SettingsHttpClientTest
    {

        private static readonly ConfigParams RestConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
            );

        private readonly SettingsHttpClientV1 _client;
        private readonly SettingsClientFixture _fixture;

        public SettingsHttpClientTest()
        {
            _client = new SettingsHttpClientV1();
            _client.Configure(RestConfig);

            _fixture = new SettingsClientFixture(_client);

            var clientTask = _client.OpenAsync(null);
            clientTask.Wait();
        }

        [Fact]
        public void TestCrudOperations()
        {
            var task = _fixture.TestCrudOperationsAsync();
            task.Wait();
        }

        public void Dispose()
        {
            var task = _client.CloseAsync(null);
            task.Wait();
        }
    }
}
