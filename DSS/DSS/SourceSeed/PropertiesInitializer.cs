using DSS.Models;

namespace DSS.SourceSeed
{
    public static class PropertiesInitializer
    {
        public static Property[] Initialize()
        {
            return new[]
            {
                //Аудио усилители
                new Property{Id=1, Name="Тип", Unit=null, Description=null, IsEnum=true},
                new Property{Id=2, Name="Тип выхода",Unit=null, Description=null, IsEnum=true},
                new Property{Id=3, Name="Макс выходная мощность",Unit="Вт", Description=null, IsEnum=false},
                new Property{Id=4, Name="Нагрузка",Unit="Ом", Description=null, IsEnum=false},
                new Property{Id=5, Name="Мин напряжение",Unit="В", Description="Минимальное напряжение питания", IsEnum=false},
                new Property{Id=6, Name="Макс напряжение",Unit="В", Description="Максимальное напряжение питания", IsEnum=false},

                //Видео усилители, модули
                new Property{Id=10, Name="Сфера применения",Unit=null, Description=null, IsEnum=true},
                new Property{Id=11, Name="Тип выхода",Unit=null, Description=null, IsEnum=true},
                new Property{Id=12, Name="Число каналов",Unit=null, Description=null, IsEnum=true},
                new Property{Id=13, Name="Полоса пропускания -3 Дб",Unit="Гц", Description=null, IsEnum=false},
                new Property{Id=14, Name="Скорость нарастания выходного напряжения", Unit="В/мкс", Description=null, IsEnum=false},
                new Property{Id=15, Name="Ток выходной",Unit="мА", Description=null, IsEnum=true},

                //Обработка звука
                new Property{Id=20, Name="Тип",Unit=null, Description=null, IsEnum=true},
                new Property{Id=21, Name="Сфера применения",Unit=null, Description=null, IsEnum=true},
                new Property{Id=22, Name="Тип монтажа",Unit=null, Description=null, IsEnum=true},
                new Property{Id=23, Name="Корпус",Unit=null, Description=null, IsEnum=true},
            };
        }
    }
}