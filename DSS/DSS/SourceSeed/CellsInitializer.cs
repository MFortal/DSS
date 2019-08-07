using DSS.Models;

namespace DSS.SourceSeed
{
    public class CellsInitializer
    {
        public static Cell[] Initialize()
        {
            return new Cell[]
            {
                new Cell{Id=1, ComponentId=1, ValueId=1},
                new Cell{Id=2, ComponentId=1, ValueId=4},

                new Cell{Id=4, ComponentId=2, ValueId=2},
                new Cell{Id=5, ComponentId=2, ValueId=3},
                new Cell{Id=1, ComponentId=2, ValueId=8},

                new Cell{Id=2, ComponentId=3, ValueId=1},
                new Cell{Id=1, ComponentId=3, ValueId=5},
                new Cell{Id=2, ComponentId=3, ValueId=9},

                new Cell{Id=1, ComponentId=4, ValueId=1},

                new Cell{Id=1, ComponentId=5, ValueId=1},

                new Cell{Id=2, ComponentId=6, ValueId=4},

                new Cell{Id=1, ComponentId=7, ValueId=3},
                new Cell{Id=2, ComponentId=7, ValueId=8},

                new Cell{Id=1, ComponentId=8, ValueId=10},

                new Cell{Id=2, ComponentId=9, ValueId=4},
                new Cell{Id=1, ComponentId=9, ValueId=7},
                new Cell{Id=2, ComponentId=9, ValueId=13},

                new Cell{Id=1, ComponentId=13, ValueId=17},

                new Cell{Id=1, ComponentId=14, ValueId=17},

                new Cell{Id=2, ComponentId=15, ValueId=18}
            };
        }
    }
}