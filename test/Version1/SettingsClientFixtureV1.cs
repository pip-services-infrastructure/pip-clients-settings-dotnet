using PipServices.Settings.Client.Version1;
using PipServices3.Commons.Config;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Settings.Client.Test.Version1
{
    public class SettingsClientFixtureV1
    {
        private ISettingsClientV1 _client;

        public SettingsClientFixtureV1(ISettingsClientV1 client)
        {
            _client = client;
        }

        public async Task TestCrudOperationsAsync()
        {
            // Create one section
            ConfigParams parameters = await this._client.SetSectionAsync(null, "test.1", ConfigParams.FromTuples(
                        "key1", "value11",
                        "key2", "value12"
                    ));

            Assert.NotNull(parameters);
            Assert.Equal("value11", parameters.GetAsString("key1"));

            // Create another section
            parameters = await this._client.ModifySectionAsync(null, "test.2", 
                ConfigParams.FromTuples("key1", "value21"),
                ConfigParams.FromTuples("key2", 1));

            Assert.NotNull(parameters);
            Assert.Equal("value21", parameters.GetAsString("key1"));
            Assert.Equal("1", parameters.GetAsString("key2"));

            // Get second section
            parameters = await this._client.GetSectionByIdAsync(null, "test.2");

            Assert.NotNull(parameters);
            Assert.Equal("value21", parameters.GetAsString("key1"));
            Assert.Equal("1", parameters.GetAsString("key2"));

            // Get all sections
            var page = await this._client.GetSectionsAsync(null, null, null);

            Assert.NotNull(page);
            Assert.Equal(2, page.Data.Count);

            // Get all section ids
            var page1 = await this._client.GetSectionIdsAsync(null, null, null);

            Assert.NotNull(page1);
            Assert.Equal(2, page1.Data.Count);
        }
    }
}
