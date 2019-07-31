using DSS.Models;

namespace DSS.SourceSeed
{
    public static class ComponentsInitializer
    {
        public static Component[] Initialize()
        {
            return new Component[]
            {
                new Component{Id=1, Name="Товар 1", Image=null, SubcategoryId=1, CountryId=1 },
                new Component{Id=2, Name="Товар 2", Image=null, SubcategoryId=1, CountryId=1 },
                new Component{Id=3, Name="Товар 3", Image=null, SubcategoryId=1, CountryId=2 }
            };
        }
    }
}