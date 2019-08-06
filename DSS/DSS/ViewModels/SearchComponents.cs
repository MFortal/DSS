using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSS.Models
{
    public class SearchComponents
    {
        [Key]
        public string PropertyName { get; set; }
        
        public ICollection<Value> Values { get; set; }
    }
}