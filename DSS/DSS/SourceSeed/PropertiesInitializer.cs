using DSS.Models;

namespace DSS.SourceSeed
{
    public static class PropertiesInitializer
    {
        public static Property[] Initialize()
        {
            return new Property[]
            {
                new Property{Id=1, Name="Тип", Unit=null, Description="Тип компонента", isEnum=false},
                new Property{Id=2, Name="Серия", Unit=null, Description=null, isEnum=false},
                new Property{Id=3, Name="Тип выхода",Unit=null, Description=null, isEnum=false},
                new Property{Id=5, Name="Сфера применения",Unit=null, Description=null, isEnum=false},
                new Property{Id=6, Name="Число каналов",Unit=null, Description=null, isEnum=false},
                new Property{Id=9, Name="Емкость",Unit="mAh", Description=null, isEnum=false}
            };
        }
    }
}