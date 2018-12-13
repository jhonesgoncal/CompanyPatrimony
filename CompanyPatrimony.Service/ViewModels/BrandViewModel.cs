using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Newtonsoft.Json;

namespace CompanyPatrimony.Service.ViewModels
{
    public class BrandViewModel
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
    }
}