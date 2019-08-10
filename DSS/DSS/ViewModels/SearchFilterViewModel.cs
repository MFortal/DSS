using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class SearchFilterViewModel
    {
        public FilterPropertyViewModel CountryProperty { get; set; }

        public IEnumerable<FilterPropertyViewModel> Properties { get; set; }
    }
}