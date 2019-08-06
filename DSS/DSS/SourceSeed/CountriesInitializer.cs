using DSS.Models;

namespace DSS.SourceSeed
{
    public static class CountriesInitializer
    {
        public static Country[] Initialize()
        {
            return new Country[]
            {
                new Country{Id=1, Name="Россия", Flag="1.gif"},
                new Country{Id=2, Name="США", Flag="2.png"},
                new Country{Id=3, Name="Франция", Flag="3.jpg"},
                new Country{Id=4, Name="Великобритания", Flag="4.png"},
                new Country{Id=5, Name="Германия", Flag="5.jpg"}
            };
        }
    }
}