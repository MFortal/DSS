using DSS.Models;

namespace DSS.SourceSeed
{
    public static class PropertiesInitializer
    {
        public static Property[] Initialize()
        {
            return new Property[]
            {
                new Property{Id=1, Name="Тип", Unit=null, Description=null, isEnum=false},
                new Property{Id=2, Name="Серия", Unit=null, Description=null, isEnum=false},
                new Property{Id=3, Name="Тип выхода",Unit=null, Description=null, isEnum=false},
                new Property{Id=4, Name="Напряжение",Unit="µV", Description=null, isEnum=true}
            };
        }
    }
}