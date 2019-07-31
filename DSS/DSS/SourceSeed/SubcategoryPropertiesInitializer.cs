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
                new SubcategoryProperty{Id=3, SubcategoryId=1, PropertyId=4}
            };
        }
    }
}