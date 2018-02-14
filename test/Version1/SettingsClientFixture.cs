using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Settings.Client.Version1;
using PipServices.Settings.Data.Version1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Settings.Client.Test.Version1
{
    public class SettingsClientFixture
    {

        private SettingSectionClientV1 SETTING1 = new SettingSectionClientV1("1", new Dictionary<string, dynamic>());
        private SettingSectionClientV1 SETTING2 = new SettingSectionClientV1("2", new Dictionary<string, dynamic>() {
                    { "param", 2}
                });

        private readonly ISettingsClientV1 _client;

        public SettingsClientFixture(ISettingsClientV1 client)
        {
            _client = client;
        }

        public async Task TestCrudOperationsAsync()
        {
            // Create one setting
            Dictionary<string, dynamic> param = await _client.SetSectionAsync(null, SETTING1.Id, SETTING1.Parameters);

            Assert.NotNull(param);
            Assert.Equal(SETTING1.Parameters, param);

            // Create another setting
            Dictionary<string, dynamic> param2 = await _client.SetSectionAsync(null, SETTING2.Id, SETTING2.Parameters);

            Assert.NotNull(param2);
            Assert.Equal(SETTING2.Parameters["param"], param2["param"]);

            // Get all settings
            DataPage<SettingSectionV1> page = await _client.GetSectionsAsync(null, null, null);
            Assert.NotNull(page);
            Assert.NotNull(page.Data);
            Assert.Equal(2, page.Data.Count);

            //Get all sections ids 
            List<string> idsActual = new List<string>();
            idsActual.Add(SETTING1.Id);
            idsActual.Add(SETTING2.Id);

            // Update the setting
            param = new Dictionary<string, dynamic>();
            param["newKey"] = "text";
            Dictionary<string, dynamic> paramsModify = await _client.ModifySectionAsync(
                null,
                SETTING1.Id,
                param,
                null
            );

            Assert.NotNull(paramsModify);
            Assert.Equal(param["newKey"], paramsModify["newKey"]);

            param = new Dictionary<string, dynamic>();
            param["param"] = "5";
            paramsModify = await _client.ModifySectionAsync(
                null,
                SETTING2.Id,
                null,
                param
            );

            Assert.NotNull(paramsModify);
            Assert.Equal(7, paramsModify["param"]);

            // Delete the setting
            await _client.DeleteSectionByIdAsync(null, SETTING2.Id);

            // Try to get deleted setting
            param = await _client.GetSectionByIdAsync(null, SETTING2.Id);
            Assert.Empty(param);
        }
    }
}
