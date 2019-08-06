using DSS.Models;

namespace DSS.SourceSeed
{
    public static class ComponentsInitializer
    {
        public static Component[] Initialize()
        {
            return new Component[]
            {
                new Component{Id=1, Name="Товар 1", Image="1.gif", SubcategoryId=1, CountryId=1 },
                new Component{Id=2, Name="Товар 2", Image="2.gif", SubcategoryId=1, CountryId=5 },
                new Component{Id=3, Name="Товар 3", Image="3.gif", SubcategoryId=1, CountryId=4 },
                new Component{Id=4, Name="Товар 4", Image="1.gif", SubcategoryId=1, CountryId=2 },
                new Component{Id=5, Name="Товар 5", Image=null, SubcategoryId=1, CountryId=3 },
                new Component{Id=6, Name="Товар 6", Image="3.gif", SubcategoryId=1, CountryId=4 },

                new Component{Id=7, Name="Товар 7", Image="4.gif", SubcategoryId=2, CountryId=2 },
                new Component{Id=8, Name="Товар 8", Image="5.gif", SubcategoryId=2, CountryId=4 },
                new Component{Id=9, Name="Товар 9", Image="6.gif", SubcategoryId=2, CountryId=5 },

                new Component{Id=10, Name="Товар 10", Image="7.gif", SubcategoryId=3, CountryId=5 },
                new Component{Id=11, Name="Товар 11", Image="8.gif", SubcategoryId=3, CountryId=3 },
                new Component{Id=12, Name="Товар 12", Image=null, SubcategoryId=3, CountryId=1 },

                new Component{Id=13, Name="Товар 13", Image="9.gif", SubcategoryId=5, CountryId=5 },
                new Component{Id=14, Name="Товар 14", Image="10.gif", SubcategoryId=5, CountryId=1 },
                new Component{Id=15, Name="Товар 15", Image="11.gif", SubcategoryId=5, CountryId=4 },
            };
        }
    }
}