using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Net.Rest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PipServices.Settings.Client.Version1
{
    public class SettingsHttpClientV1 : CommandableHttpClient, ISettingsClientV1
    {
        public SettingsHttpClientV1()
              : base("settings")
        {
        }
        public Task<SettingSectionV1> DeleteSectionByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<SettingSectionV1>("delete_settings_by_id", correlationId, new
                {
                    correlation_id = correlationId,
                    id = id
                });
            }
        }

        public Task<ConfigParams> GetSectionByIdAsync(string correlationId, string id)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<ConfigParams>("get_section_by_id", correlationId, new
                {
                    correlation_id = correlationId,
                    id = id
                });
            }
        }

        public Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<DataPage<string>>("get_section_ids", correlationId, new
                {
                    correlation_id = correlationId,
                    filter = filter ?? new FilterParams(),
                    paging = paging ?? new PagingParams()
                });
            }
        }

        public Task<DataPage<SettingSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {

            using (var timing = Instrument(correlationId))
            {
                return CallCommand<DataPage<SettingSectionV1>>("get_sections", correlationId, new
                {
                    correlation_id = correlationId,
                    filter = filter ?? new FilterParams(),
                    paging = paging ?? new PagingParams()
                });
            }
        }

        public Task<ConfigParams> ModifySectionAsync(string correlationId, string id, ConfigParams updateParams, ConfigParams incrementParams)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<ConfigParams>("modify_section", correlationId, new
                {
                    correlation_id = correlationId,
                    id = id,
                    update_params = updateParams,
                    increment_params = incrementParams
                });
            }
        }

        public Task<ConfigParams> SetSectionAsync(string correlationId, string id, ConfigParams parameters)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<ConfigParams>("set_section", correlationId, new
                {
                    correlation_id = correlationId,
                    id = id,
                    parameters = parameters
                });
            }
        }
    }
}
