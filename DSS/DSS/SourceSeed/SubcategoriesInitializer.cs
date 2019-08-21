using DSS.Models;

namespace DSS.SourceSeed
{
    public static class SubcategoriesInitializer
    {
        public static Subcategory[] Initialize()
        {
            return new Subcategory[]
            {
                new Subcategory{Id=1, Name="Аудио усилители", CategoryId=1 },
                new Subcategory{Id=2, Name="Видео усилители, модули", CategoryId= 1 },
                new Subcategory{Id=3, Name="Обработка звука", CategoryId= 1 },
                new Subcategory{Id=4, Name="Модульные", CategoryId=2 },
                new Subcategory{Id=5, Name="Щелочные", CategoryId= 3 },
                new Subcategory{Id=6, Name="Свинцово-кислотные", CategoryId= 3 },
                new Subcategory{Id=7, Name="Акселерометры", CategoryId= 4 },
                new Subcategory{Id=8, Name="Аксессуары", CategoryId= 4 },
                new Subcategory{Id=9, Name="Датчики света", CategoryId= 4 }
            };
        }
    }
}