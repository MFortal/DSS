using DSS.Models;

namespace DSS.SourceSeed
{
    public static class SubcategoriesInitializer
    {
        public static Subcategory[] Initialize()
        {
            return new Subcategory[]
            {
                new Subcategory{Id=1, Name="Аудио усилители", Image=null, CategoryId=1 },
                new Subcategory{Id=2, Name="Видео усилители, модули", Image=null, CategoryId= 1 },
                new Subcategory{Id=3, Name="Модул", Image=null, CategoryId=2 }
            };
        }
    }
}