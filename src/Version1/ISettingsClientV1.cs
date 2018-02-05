using PipServices.Commons.Config;
using PipServices.Commons.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PipServices.Settings.Client.Version1
{
    public interface ISettingsClientV1
    {
        Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<DataPage<SettingSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<ConfigParams> GetSectionByIdAsync(string correlationId, string id);
        Task<ConfigParams> SetSectionAsync(string correlationId, string id, ConfigParams parameters);
        Task<SettingSectionV1> DeleteSectionByIdAsync(string correlationId, string id);
        Task<ConfigParams> ModifySectionAsync(string correlationId, string id, ConfigParams updateParams, ConfigParams incrementParams);

    }
}
