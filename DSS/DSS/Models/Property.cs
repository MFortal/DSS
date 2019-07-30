using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSS.Models
{
    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public bool isEnum { get; }

        public virtual ICollection<SubcategoryProperty> SubcategoryProperties { get; set; }
        public virtual ICollection<Value> Values { get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
    }
}