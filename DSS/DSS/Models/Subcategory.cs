using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DSS.Models
{
    public class Subcategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Categories { get; set; }
        public virtual ICollection<SubcategoryProperty> SubcategoryProperties { get; set; }
        public virtual ICollection<Component> Components { get; set; }
    }
}