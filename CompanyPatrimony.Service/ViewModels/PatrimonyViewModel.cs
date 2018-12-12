using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CompanyPatrimony.Service.ViewModels
{
    public class PatrimonyViewModel
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "numbertumble")]
        public Guid NumberTumble { get;  set; }

        [JsonProperty(PropertyName = "brand")]
        public BrandViewModel Brand { get; set; }

        public Guid BrandId { get; set; }
    }
}