using DSS.Models;

namespace DSS.SourceSeed
{
    public class CellsInitializer
    {
        public static Cell[] Initialize()
        {
            return new Cell[]
            {
                new Cell{Id=1, ComponentId=1, PropertyId=1, ValueId=1, Value=null},
                new Cell{Id=2, ComponentId=1, PropertyId=4, ValueId=3, Value=null},
                new Cell{Id=3, ComponentId=2, PropertyId=1, ValueId=1, Value=null},
                new Cell{Id=4, ComponentId=3, PropertyId=4, ValueId=null, DefaultValue="def100"}
            };
        }
    }
}