using DSS.Models;

namespace DSS.SourceSeed
{
    public static class CategoriesInitializer
    {
        public static Category[] Initialize()
        {
            return new Category[]
            {
                new Category{Id=1, Name="Интегральные микросхемы", Image="1.gif" },
                new Category{Id=2, Name="Конденсаторы", Image="2.gif"  }
            };
        }
    }
}