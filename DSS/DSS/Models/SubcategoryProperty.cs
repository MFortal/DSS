using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DSS.Models
{
    public class SubcategoryProperty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SubcategoryId { get; set; }
        public int PropertyId { get; set; }

        public virtual Subcategory Subcategory { get; set; }
        public virtual Property Property { get; set; }
    }
}