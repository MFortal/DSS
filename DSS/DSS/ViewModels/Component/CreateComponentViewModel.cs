using System.Collections.Generic;
using System.Web.Mvc;

namespace DSS.ViewModels.Component
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SubcategoryId { get; set; }

        public SelectList Countries { get; set; }

        public int SelectedCountryId { get; set; }

        public PropertyViewModel[] Properties { get; set; }

        public string PreviousUrl { get; set; }
    }
}