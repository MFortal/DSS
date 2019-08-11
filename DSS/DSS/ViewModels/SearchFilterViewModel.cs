namespace DSS.ViewModels
{
    public class SearchFilterViewModel
    {
        public DropDownSearchViewModel DropDown { get; set; }

        public FilterPropertyViewModel CountryProperty { get; set; }

        public FilterPropertyViewModel[] Properties { get; set; }
    }
}