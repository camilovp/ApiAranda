using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ApiAranda.Models.DTO
{
    public class ProductsDTO
    {
        public Guid? Id { get; set; }

        [StringLength(50)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [StringLength(250)]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("category")]
        public Guid IdCategory { get; set; }

        public string? NameCategory { get; set; }
    }
}
