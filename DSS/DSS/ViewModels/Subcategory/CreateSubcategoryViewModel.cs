using System.Collections.Generic;
using System.Web.Mvc;
using DSS.Models;

namespace DSS.ViewModels.Subcategory
{
    public class CreateSubcategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SelectList Categories { get; set; }

        public int SelectedCategoryId { get; set; }

        public SelectList Properties { get; set; }

        public IEnumerable<int> SelectedPropertyIds { get; set; }
    }
}