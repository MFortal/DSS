using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class PropertyValuesSubcategories
    {
        public string PropertyName { get; set; }
        public IEnumerable<string> Values { get; set; }
        public string Description { get; set; }
    }
}