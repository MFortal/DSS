using DSS.Models;

namespace DSS.SourceSeed
{
    public static class SubcategoryPropertiesInitializer
    {
        public static SubcategoryProperty[] Initialize()
        {
            return new SubcategoryProperty[]
            {
                new SubcategoryProperty{Id=1, SubcategoryId=1, PropertyId=1},
                new SubcategoryProperty{Id=2, SubcategoryId=1, PropertyId=2},
                new SubcategoryProperty{Id=3, SubcategoryId=1, PropertyId=3},
                new SubcategoryProperty{Id=17, SubcategoryId=1, PropertyId=5},
                new SubcategoryProperty{Id=18, SubcategoryId=1, PropertyId=7},

                new SubcategoryProperty{Id=4, SubcategoryId=2, PropertyId=2},
                new SubcategoryProperty{Id=5, SubcategoryId=2, PropertyId=3},
                new SubcategoryProperty{Id=6, SubcategoryId=2, PropertyId=5},
                new SubcategoryProperty{Id=7, SubcategoryId=2, PropertyId=6},
                new SubcategoryProperty{Id=19, SubcategoryId=2, PropertyId=10},

                new SubcategoryProperty{Id=8, SubcategoryId=3, PropertyId=1},
                new SubcategoryProperty{Id=9, SubcategoryId=3, PropertyId=2},
                new SubcategoryProperty{Id=10, SubcategoryId=3, PropertyId=5},
                new SubcategoryProperty{Id=11, SubcategoryId=3, PropertyId=6},
                new SubcategoryProperty{Id=17, SubcategoryId=3, PropertyId=11},

                new SubcategoryProperty{Id=13, SubcategoryId=4, PropertyId=2},

                new SubcategoryProperty{Id=14, SubcategoryId=5, PropertyId=2},
                new SubcategoryProperty{Id=15, SubcategoryId=5, PropertyId=9},

                new SubcategoryProperty{Id=16, SubcategoryId=6, PropertyId=2}
            };
        }
    }
}