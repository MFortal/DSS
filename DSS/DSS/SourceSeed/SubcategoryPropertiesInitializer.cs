using DSS.Models;

namespace DSS.SourceSeed
{
    public static class SubcategoryPropertiesInitializer
    {
        public static SubcategoryProperty[] Initialize()
        {
            return new SubcategoryProperty[]
            {
                //Аудио усилители
                new SubcategoryProperty{SubcategoryId=1, PropertyId=1},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=2},            
                new SubcategoryProperty{SubcategoryId=1, PropertyId=3},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=4},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=5},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=6},

                //Видео усилители, модули
                new SubcategoryProperty{SubcategoryId=2, PropertyId=10},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=11},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=12},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=13},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=14},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=15},

                //Обработка звука
                new SubcategoryProperty{SubcategoryId=3, PropertyId=20},
                new SubcategoryProperty{SubcategoryId=3, PropertyId=21},
                new SubcategoryProperty{SubcategoryId=3, PropertyId=22},
                new SubcategoryProperty{SubcategoryId=3, PropertyId=23},
            };
        }
    }
}