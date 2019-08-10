namespace DSS.ViewModels
{
    public class TableRowViewModel
    {
        public int ComponentId { get; set; }

        public string ComponentName { get; set; }

        public string CountryName { get; set; }

        public string CountryFlag { get; set; }

        public CellValueViewModel[] Cells { get; set; }
    }
}