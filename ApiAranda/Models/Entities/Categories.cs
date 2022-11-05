using System.ComponentModel.DataAnnotations;

namespace ApiAranda.Models.Entities
{
    public class Categories
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
