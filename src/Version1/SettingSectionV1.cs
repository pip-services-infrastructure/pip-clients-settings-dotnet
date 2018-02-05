﻿using PipServices.Commons.Config;
using PipServices.Commons.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PipServices.Settings.Client.Version1
{
    [DataContract]
    public class SettingSectionV1 : IStringIdentifiable
    {
        public SettingSectionV1() { }

        public SettingSectionV1(string id, ConfigParams param)
        {
            this.Id = id;
            this.Parameters = param;
            this.UpdateTime = new DateTime();
        }

        public SettingSectionV1(string id)
        {
            this.Id = id;
            this.Parameters = new ConfigParams();
            this.UpdateTime = new DateTime();
        }

        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "parameters")]
        public ConfigParams Parameters { set; get; }
        [DataMember(Name = "update_time")]
        public DateTime UpdateTime { set; get; }

    }
}