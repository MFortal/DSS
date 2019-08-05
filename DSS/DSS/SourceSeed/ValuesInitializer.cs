using DSS.Models;

namespace DSS.SourceSeed
{
    public static class ValuesInitializer
    {
        public static Value[] Initialize()
        {
            return new Value[]
            {
                new Value{Id=1, PropertyId=1, PropertyValue="Класс А"},
                new Value{Id=2, PropertyId=1, PropertyValue="Класс В"},
                new Value{Id=3, PropertyId=4, PropertyValue="450"},
                new Value{Id=4, PropertyId=4, PropertyValue="600"},
                new Value{Id=5, PropertyId=3, PropertyValue="Test"}
            };
        }
    }
}