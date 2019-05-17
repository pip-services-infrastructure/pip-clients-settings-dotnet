using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipServices.Settings.Client.Version1
{
    public interface ISettingsClientV1
    {
        Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<DataPage<SettingsSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<ConfigParams> GetSectionByIdAsync(string correlationId, string id);
        Task<ConfigParams> SetSectionAsync(string correlationId, string id, ConfigParams parameters);
        Task<ConfigParams> ModifySectionAsync(string correlationId, string id, ConfigParams updateParams, ConfigParams incrementParams);
    }
}
