using DSS.Models;

namespace DSS.SourceSeed
{
    public static class CountriesInitializer
    {
        public static Country[] Initialize()
        {
            return new Country[]
            {
                new Country{Id=1, Name="Россия", Flag="1.gif" },
                new Country{Id=2, Name="США", Flag="2.gif"  }
            };
        }
    }
}