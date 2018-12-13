using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Newtonsoft.Json;

namespace CompanyPatrimony.Service.ViewModels
{
    public class PatrimonyViewModel
    {
        public PatrimonyViewModel()
        {
            NumberTumble = Guid.NewGuid();
        }

        [Key]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "numbertumble")]
        [ReadOnly(true)]
        public Guid NumberTumble { get;  set; }

        [JsonProperty(PropertyName = "brand")]
        public BrandViewModel Brand { get; set; }

        public Guid BrandId { get; set; }
    }
}