using Microsoft.Extensions.Logging.Console;
using PipServices.Commons.Refer;
using PipServices.Settings.Client.Version1;
using PipServices.Settings.Logic;
using PipServices.Settings.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PipServices.Settings.Client.Test.Version1
{
    public class SettingsDirectClientTest 
    {
        private readonly SettingsDirectClientV1 _client;
        private readonly SettingsClientFixture _fixture;

        public SettingsDirectClientTest()
        {
            var persistence = new SettingsMemoryPersistence();
            var controller = new SettingsController();

            References references = References.FromTuples(
                new Descriptor("pip-services-settings", "persistence", "memory", "default", "1.0"), persistence,
                new Descriptor("pip-services-settings", "controller", "default", "default", "1.0"), controller
    
            );
            controller.SetReferences(references);

            _client = new SettingsDirectClientV1();
            _client.SetReferences(references);

            _fixture = new SettingsClientFixture(_client);

            _client.OpenAsync(null);
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
