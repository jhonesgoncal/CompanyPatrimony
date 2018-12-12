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

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid NumberTumble { get;  set; }
    }
}