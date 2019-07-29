using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DSS.Models
{
    public class Cell
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ComponentsId { get; set; }
        public int PropertyId { get; set; }
        public int? ValueId { get; set; }
        [Column("Value")]
        public string DefaultValue { get; set; }

        public virtual Component Component { get; set; }
        public virtual Property Property { get; set; }
        public virtual Value Value { get; set; }
    }
}