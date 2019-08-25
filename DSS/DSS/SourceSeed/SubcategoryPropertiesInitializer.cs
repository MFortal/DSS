using DSS.Models;

namespace DSS.SourceSeed
{
    public static class SubcategoryPropertiesInitializer
    {
        public static SubcategoryProperty[] Initialize()
        {
            return new SubcategoryProperty[]
            {
                new SubcategoryProperty{SubcategoryId=1, PropertyId=1},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=2},            
                new SubcategoryProperty{SubcategoryId=1, PropertyId=3},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=5},
                new SubcategoryProperty{SubcategoryId=1, PropertyId=6},

                new SubcategoryProperty{SubcategoryId=2, PropertyId=2},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=7},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=8},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=9},
                new SubcategoryProperty{SubcategoryId=2, PropertyId=11},
            };
        }
    }
}