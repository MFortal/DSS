namespace DSS.ViewModels
{
    public class FilterPropertyViewModel
    {
        public int? PropertyId { get; set; }

        public string PropertyName { get; set; }

        public bool IsEnum { get; set; }

        public SelectionViewModel[] ValueChecked { get; set; }

        public double? Min { get; set; }

        public double? Max { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

    }
}