using System.Collections.Generic;
using DSS.Models;

namespace DSS.ViewModels.Subcategory
{
    public class DetailsSubcategoryViewModel
    {
        public string Name { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Property> Properties { get; set; }
    }
}