using DSS.Models;

namespace DSS.SourceSeed
{
    public static class ValuesInitializer
    {
        public static Value[] Initialize()
        {
            return new Value[]
            {
                new Value{Id=1, PropertyId=1, PropertyValue="Класс АB"},
                new Value{Id=2, PropertyId=1, PropertyValue="Класс В"},

                new Value{Id=3, PropertyId=2, PropertyValue="Bash®"},
                new Value{Id=4, PropertyId=2, PropertyValue="AudioMAX™"},
                new Value{Id=5, PropertyId=2, PropertyValue="PowerWise®"},

                new Value{Id=6, PropertyId=3, PropertyValue="Наушники, 1 канал (Моно)"},
                new Value{Id=7, PropertyId=3, PropertyValue="Наушники, 2 канала (Стерео)"},
                new Value{Id=8, PropertyId=3, PropertyValue="Differential"},
                new Value{Id=9, PropertyId=3, PropertyValue="Push-Pull"},

                new Value{Id=10, PropertyId=5, PropertyValue="CATV"},
                new Value{Id=11, PropertyId=5, PropertyValue="Driver"},

                new Value{Id=12, PropertyId=6, PropertyValue="1"},
                new Value{Id=13, PropertyId=6, PropertyValue="2"},
                new Value{Id=14, PropertyId=6, PropertyValue="3"},
                new Value{Id=15, PropertyId=6, PropertyValue="4"},
                new Value{Id=16, PropertyId=6, PropertyValue="5"},

                new Value{Id=17, PropertyId=9, PropertyValue="450"},
                new Value{Id=18, PropertyId=9, PropertyValue="550"},
                new Value{Id=19, PropertyId=9, PropertyValue="600"},
                new Value{Id=20, PropertyId=9, PropertyValue="1250"},

                new Value{Id=21, PropertyId=2, PropertyValue="Apex Precision Power™"},
                new Value{Id=22, PropertyId=2, PropertyValue="LT®"},
                new Value{Id=23, PropertyId=2, PropertyValue="VIP10™"},

                new Value{Id=24, PropertyId=3, PropertyValue="Rail-to-Rail"},

                new Value{Id=25, PropertyId=5, PropertyValue="Buffer"},
                new Value{Id=26, PropertyId=5, PropertyValue="DC Restoration"},

                new Value{Id=27, PropertyId=10, PropertyValue="800"},
                new Value{Id=28, PropertyId=10, PropertyValue="1000"},
                new Value{Id=29, PropertyId=10, PropertyValue="2000"},
                new Value{Id=30, PropertyId=10, PropertyValue="9000"},
                new Value{Id=31, PropertyId=10, PropertyValue="100"}
            };
        }
    }
}