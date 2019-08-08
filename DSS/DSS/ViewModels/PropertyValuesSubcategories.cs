using DSS.Models;
using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class PropertyValuesSubcategories
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public IEnumerable<string> Values { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }

    }
}