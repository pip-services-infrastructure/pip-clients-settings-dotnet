using System.Threading.Tasks;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;

namespace PipServices.Settings.Client.Version1
{
    public class SettingsNullClientV1 : ISettingsClientV1
    {
        public async Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<string>());
        }

        public async Task<DataPage<SettingsSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<SettingsSectionV1>());
        }

        public async Task<ConfigParams> GetSectionByIdAsync(string correlationId, string id)
        {
            return await Task.FromResult(new ConfigParams());
        }

        public async Task<ConfigParams> SetSectionAsync(string correlationId, string id, ConfigParams parameters)
        {
            return await Task.FromResult(new ConfigParams());
        }

        public async Task<ConfigParams> ModifySectionAsync(string correlationId, string id, ConfigParams updateParams, ConfigParams incrementParams)
        {
            return await Task.FromResult(new ConfigParams());
        }    
    }
}
