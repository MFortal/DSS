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

        public string Unit { get; set; }

        public string Description { get; set; }

        public bool IsEnum { get; set; }

        public virtual ICollection<SubcategoryProperty> SubcategoryProperties { get; set; }

        public virtual ICollection<Value> Values { get; set; }
    }
}