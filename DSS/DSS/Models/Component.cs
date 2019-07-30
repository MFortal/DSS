using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSS.Models
{
    public class Component
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }


        public virtual Country Country { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
    }
}