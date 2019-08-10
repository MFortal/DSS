using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class FilterPropertyViewModel
    {
        public int? PropertyId { get; set; }

        public string PropertyName { get; set; }

        public Dictionary<int, SelectionViewModel> ValueChecked { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

    }
}