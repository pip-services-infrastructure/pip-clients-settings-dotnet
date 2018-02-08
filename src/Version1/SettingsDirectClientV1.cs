using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;
using PipServices.Settings.Data.Version1;

namespace PipServices.Settings.Client.Version1
{
    public class SettingsDirectClientV1 : DirectClient<dynamic>, ISettingsClientV1
    {

        public SettingsDirectClientV1() : base()
        {
            this._dependencyResolver.Put("controller", new Descriptor("pip-services-settings", "controller", "*", "*", "*"));
        }

        public async Task<SettingSectionV1> DeleteSectionByIdAsync(string correlationId, string id)
        {
            return await this._controller.DeleteSectionByIdAsync(correlationId, id);
        }

        public async Task<Dictionary<string, dynamic>> GetSectionByIdAsync(string correlationId, string id)
        {
            return await this._controller.GetSectionByIdAsync(correlationId, id);
        }

        public async Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            //var timing = this.Instrument(correlationId, "settings.get_section_ids");
            return await this._controller.GetSectionIdsAsync(correlationId, filter, paging);
        }

        public async Task<DataPage<SettingSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await this._controller.GetSectionsAsync(correlationId, filter, paging);
        }

        public async Task<Dictionary<string, dynamic>> ModifySectionAsync(string correlationId, string id, Dictionary<string, dynamic> updateParams, Dictionary<string, dynamic> incrementParams)
        {
            return await this._controller.ModifySectionAsync(correlationId, id, updateParams, incrementParams);
        }

        public async Task<Dictionary<string, dynamic>> SetSectionAsync(string correlationId, string id, Dictionary<string, dynamic> parameters)
        {
            return await this._controller.SetSectionAsync(correlationId, id, parameters);
        }
    }
}
