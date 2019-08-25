using DSS.Models;

namespace DSS.SourceSeed
{
    public static class PropertiesInitializer
    {
        public static Property[] Initialize()
        {
            return new[]
            {
                new Property{Id=1, Name="Тип", Unit=null, Description=null, IsEnum=true},
                new Property{Id=2, Name="Серия", Unit=null, Description=null, IsEnum=true},
                new Property{Id=3, Name="Тип выхода",Unit=null, Description=null, IsEnum=true},
                new Property{Id=5, Name="Сфера применения",Unit=null, Description=null, IsEnum=true},
                new Property{Id=7, Name="Напряжение питания",Unit=null, Description=null, IsEnum=false},

                new Property{Id=6, Name="Число каналов",Unit=null, Description=null, IsEnum=true},
                new Property{Id=11, Name="Тип монтажа",Unit=null, Description=null, IsEnum=true},
                new Property{Id=10, Name="Полоса пропускания",Unit="kHz", Description=null, IsEnum=false},
                new Property{Id=9, Name="Емкость",Unit="mAh", Description=null, IsEnum=false}
            };
        }
    }
}