using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DSS.Models
{
    public class Value
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, Column("Value")]
        public string PropertyValue { get; set; }
        
        public int PropertyId { get; set; }

        public virtual Property Property{ get; set; }
        public virtual ICollection<Cell> Cells { get; set; }
    }
}