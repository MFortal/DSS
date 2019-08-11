using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class DropDownSearchViewModel
    {
        public SelectionViewModel ThisCategory { get; set; }

        public SelectionViewModel ThisSubcategory { get; set; }

        public IEnumerable<SelectionViewModel> OtherCategories { get; set; }

        public IEnumerable<SelectionViewModel> OtherSubcategories { get; set; }
    }
}