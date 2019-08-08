using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSS.ViewModels
{
    public class ValueTable
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}