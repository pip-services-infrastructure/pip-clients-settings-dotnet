using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;

namespace PipServices.Settings.Client.Version1
{
    public class SettingsDirectClientV1 : DirectClient<dynamic>, ISettingsClientV1
    {

        public SettingsDirectClientV1() : base()
        {
            this._dependencyResolver.Put("controller", new Descriptor("pip-services-settings", "controller", "*", "*", "*"));
        }

        public Task<SettingSectionV1> DeleteSectionByIdAsync(string correlationId, string id)
        {
            return this._controller.DeleteSectionByIdAsync(correlationId, id);
        }

        public Task<Dictionary<string, dynamic>> GetSectionByIdAsync(string correlationId, string id)
        {
            return this._controller.getSectionById(correlationId, id);
        }

        public Task<DataPage<string>> GetSectionIdsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            //var timing = this.Instrument(correlationId, "settings.get_section_ids");
            return this._controller.getSectionIds(correlationId, filter, paging);
        }

        public Task<DataPage<SettingSectionV1>> GetSectionsAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return this._controller.getSections(correlationId, filter, paging);
        }

        public Task<Dictionary<string, dynamic>> ModifySectionAsync(string correlationId, string id, Dictionary<string, dynamic> updateParams, Dictionary<string, dynamic> incrementParams)
        {
            return this._controller.modifySection(correlationId, id, updateParams, incrementParams);
        }

        public Task<Dictionary<string, dynamic>> SetSectionAsync(string correlationId, string id, Dictionary<string, dynamic> parameters)
        {
            return this._controller.setSection(correlationId, id, parameters);
        }
    }
}
