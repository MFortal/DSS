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

                new Cell{Id=3, ComponentId=2, ValueId=2},
                new Cell{Id=4, ComponentId=2, ValueId=3},
                new Cell{Id=5, ComponentId=2, ValueId=8},

                new Cell{Id=6, ComponentId=3, ValueId=1},
                new Cell{Id=7, ComponentId=3, ValueId=5},
                new Cell{Id=8, ComponentId=3, ValueId=9},

                new Cell{Id=9, ComponentId=4, ValueId=1},

                new Cell{Id=10, ComponentId=5, ValueId=1},

                new Cell{Id=11, ComponentId=6, ValueId=4},



                new Cell{Id=12, ComponentId=7, ValueId=21},
                new Cell{Id=50, ComponentId=7, ValueId=9},
                new Cell{Id=13, ComponentId=7, ValueId=10},
                new Cell{Id=22, ComponentId=7, ValueId=15},

                new Cell{Id=51, ComponentId=8, ValueId=11},
                new Cell{Id=52, ComponentId=8, ValueId=14},
                new Cell{Id=53, ComponentId=8, ValueId=22},
                new Cell{Id=54, ComponentId=8, ValueId=30},
                new Cell{Id=55, ComponentId=8, ValueId=24},


                new Cell{Id=15, ComponentId=9, ValueId=21},
                new Cell{Id=16, ComponentId=9, ValueId=8},
                new Cell{Id=17, ComponentId=9, ValueId=11},
                new Cell{Id=56, ComponentId=9, ValueId=16},
                new Cell{Id=57, ComponentId=9, ValueId=31},

                new Cell{Id=58, ComponentId=19, ValueId=22},
                new Cell{Id=59, ComponentId=19, ValueId=24},
                new Cell{Id=60, ComponentId=19, ValueId=25},
                new Cell{Id=61, ComponentId=19, ValueId=13},
                new Cell{Id=62, ComponentId=19, ValueId=29},

                new Cell{Id=63, ComponentId=20, ValueId=21},
                new Cell{Id=64, ComponentId=20, ValueId=9},
                new Cell{Id=65, ComponentId=20, ValueId=10},
                new Cell{Id=66, ComponentId=20, ValueId=12},
                new Cell{Id=67, ComponentId=20, ValueId=28},

                new Cell{Id=68, ComponentId=21, ValueId=23},
                new Cell{Id=69, ComponentId=21, ValueId=24},
                new Cell{Id=70, ComponentId=21, ValueId=26},

                new Cell{Id=71, ComponentId=22, ValueId=27},
                new Cell{Id=72, ComponentId=22, ValueId=13},
                new Cell{Id=73, ComponentId=22, ValueId=26},
                new Cell{Id=74, ComponentId=22, ValueId=22},

                new Cell{Id=75, ComponentId=30, ValueId=21},
                new Cell{Id=76, ComponentId=30, ValueId=9},
                new Cell{Id=77, ComponentId=30, ValueId=10},
                new Cell{Id=78, ComponentId=30, ValueId=12},

                new Cell{Id=79, ComponentId=31, ValueId=21},
                new Cell{Id=80, ComponentId=31, ValueId=9},
                new Cell{Id=81, ComponentId=31, ValueId=11},
                new Cell{Id=82, ComponentId=31, ValueId=15},

                new Cell{Id=83, ComponentId=32, ValueId=11},
                new Cell{Id=84, ComponentId=32, ValueId=14},
                new Cell{Id=85, ComponentId=32, ValueId=30},
                new Cell{Id=86, ComponentId=32, ValueId=24},


                new Cell{Id=87, ComponentId=33, ValueId=22},
                new Cell{Id=88, ComponentId=33, ValueId=8},
                new Cell{Id=89, ComponentId=33, ValueId=11},
                new Cell{Id=90, ComponentId=33, ValueId=16},
                new Cell{Id=91, ComponentId=33, ValueId=31},

                new Cell{Id=18, ComponentId=13, ValueId=17},

                new Cell{Id=19, ComponentId=14, ValueId=17},

                new Cell{Id=20, ComponentId=15, ValueId=18}
            };
        }
    }
}