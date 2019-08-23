using System.Web.Mvc;
using DSS.Models;

namespace DSS.ViewModels.Component
{
    public class PropertyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }
    }
}