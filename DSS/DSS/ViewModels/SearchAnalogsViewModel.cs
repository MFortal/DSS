using DSS.Models;
using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class SearchAnalogsViewModel
    {
        public IEnumerable<Component> Components { get; set; }

        public TableHeaderViewModel TableHeader { get; set; }

        public IEnumerable<TableRowViewModel> Rows { get; set; }
    }
}