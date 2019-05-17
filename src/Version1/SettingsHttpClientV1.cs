using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using PipServices3.Rpc.Clients;
using System.Threading.Tasks;

namespace PipServices.Settings.Client.Version1
{
    public class SettingsHttpClientV1 : CommandableHttpClient, ISettingsClientV1
    {
        public SettingsHttpClientV1() : base("v1/settings")
        { }

        public SettingsHttpClientV1(object config) : base("v1/settings")
        {
            if (config != null)
                this.Configure(ConfigParams.FromValue(config));
        }

        public async Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<string>>(
                    "get_section_ids",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                    );
            }
        }

        public async Task<DataPage<SettingsSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<SettingsSectionV1>>(
                    "get_sections",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                    );
            }
        }

        public async Task<ConfigParams> GetSectionByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<ConfigParams>(
                    "get_section_by_id",
                    correlationId,
                    new
                    {
                        id = id
                    }
                    );
            }
        }

        public async Task<ConfigParams> SetSectionAsync(string correlationId, string id, ConfigParams parameters)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<ConfigParams>(
                    "set_section",
                    correlationId,
                    new
                    {
                        id = id,
                        parameters = parameters
                    }
                    );
            }
        }

        public async Task<ConfigParams> ModifySectionAsync(string correlationId, string id, ConfigParams updateParams, ConfigParams incrementParams)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<ConfigParams>(
                    "modify_section",
                    correlationId,
                    new
                    {
                        id = id,
                        update_params = updateParams,
                        increment_params = incrementParams
                    }
                    );
            }
        }
    }
}
