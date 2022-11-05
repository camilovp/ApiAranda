using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ApiAranda.Models.Entities
{
    public class Products
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(250)]
        public string Description { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public Guid IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Categories Category { get; set; }
    }
}
