using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiAranda.Models.DTO
{
    public class CategoriesDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [StringLength(50)]
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
