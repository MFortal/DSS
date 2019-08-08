using DSS.Models;
using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class ComponentsSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
        public IEnumerable<ValueTable> Values { get; set; }
    }
}