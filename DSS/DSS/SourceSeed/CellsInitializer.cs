using DSS.Models;

namespace DSS.SourceSeed
{
    public class CellsInitializer
    {
        public static Cell[] Initialize()
        {
            return new Cell[]
            {
                new Cell{Id=1, ComponentId=1, PropertyId=1, ValueId=1, DefaultValue=null},
                new Cell{Id=2, ComponentId=1, PropertyId=2, ValueId=4, DefaultValue=null},
                new Cell{Id=3, ComponentId=1, PropertyId=3, ValueId=null, DefaultValue="defValue"},

                new Cell{Id=4, ComponentId=2, PropertyId=1, ValueId=2, DefaultValue=null},
                new Cell{Id=5, ComponentId=2, PropertyId=2, ValueId=3, DefaultValue=null},
                new Cell{Id=1, ComponentId=2, PropertyId=3, ValueId=8, DefaultValue=null},

                new Cell{Id=2, ComponentId=3, PropertyId=1, ValueId=1, DefaultValue=null},
                new Cell{Id=1, ComponentId=3, PropertyId=2, ValueId=5, DefaultValue=null},
                new Cell{Id=2, ComponentId=3, PropertyId=3, ValueId=9, DefaultValue=null},

                new Cell{Id=1, ComponentId=4, PropertyId=1, ValueId=1, DefaultValue=null},
                new Cell{Id=2, ComponentId=4, PropertyId=2, ValueId=null, DefaultValue="defСерия"},

                new Cell{Id=1, ComponentId=5, PropertyId=1, ValueId=1, DefaultValue=null},

                new Cell{Id=2, ComponentId=6, PropertyId=2, ValueId=4, DefaultValue=null},

                new Cell{Id=1, ComponentId=7, PropertyId=2, ValueId=3, DefaultValue=null},
                new Cell{Id=2, ComponentId=7, PropertyId=3, ValueId=8, DefaultValue=null},

                new Cell{Id=1, ComponentId=8, PropertyId=5, ValueId=10, DefaultValue=null},

                new Cell{Id=2, ComponentId=9, PropertyId=2, ValueId=4, DefaultValue=null},
                new Cell{Id=1, ComponentId=9, PropertyId=3, ValueId=7, DefaultValue=null},
                new Cell{Id=2, ComponentId=9, PropertyId=6, ValueId=13, DefaultValue=null},

                new Cell{Id=1, ComponentId=13, PropertyId=9, ValueId=17, DefaultValue=null},

                new Cell{Id=1, ComponentId=14, PropertyId=9, ValueId=null, DefaultValue="def1000"},

                new Cell{Id=2, ComponentId=15, PropertyId=9, ValueId=18, DefaultValue=null}
            };
        }
    }
}