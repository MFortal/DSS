using System.Collections.Generic;

namespace DSS.ViewModels
{
    public class SearchResultViewModel
    {        
        public TableHeaderViewModel TableHeader { get; set; }

        public IEnumerable<TableRowViewModel> Rows { get; set; }
    }
}