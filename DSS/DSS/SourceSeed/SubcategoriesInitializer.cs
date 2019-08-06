using DSS.Models;

namespace DSS.SourceSeed
{
    public static class SubcategoriesInitializer
    {
        public static Subcategory[] Initialize()
        {
            return new Subcategory[]
            {
                new Subcategory{Id=1, Name="Аудио усилители", Image="1.gif", CategoryId=1 },
                new Subcategory{Id=2, Name="Видео усилители, модули", Image="2.gif", CategoryId= 1 },
                new Subcategory{Id=3, Name="Обработка звука", Image="3.gif", CategoryId= 1 },
                new Subcategory{Id=4, Name="Модульные", Image="4.gif", CategoryId=2 },
                new Subcategory{Id=5, Name="Щелочные", Image="5.gif", CategoryId= 3 },
                new Subcategory{Id=6, Name="Свинцово-кислотные", Image="6.gif", CategoryId= 3 },
                new Subcategory{Id=7, Name="Акселерометры", Image="7.gif", CategoryId= 4 },
                new Subcategory{Id=8, Name="Аксессуары", Image="8.gif", CategoryId= 4 },
                new Subcategory{Id=9, Name="Датчики света", Image="9.gif", CategoryId= 4 }
            };
        }
    }
}