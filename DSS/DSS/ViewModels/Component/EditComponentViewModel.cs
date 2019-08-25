using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSS.ViewModels.Component
{
    public class EditComponentViewModel
    {
        public ComponentViewModel Component { get; set; }

        public string CountryName { get; set; }

        public string SubcategoryName { get; set; }
    }
}