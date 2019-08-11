namespace DSS.ViewModels
{
    public class SearchViewModel
    {
        public SearchFilterViewModel Filter { get; set; }

        public SearchResultViewModel Result { get; set; }        

        public string MyText { get; set; }

        public bool MyChecked { get; set; }
    }
}