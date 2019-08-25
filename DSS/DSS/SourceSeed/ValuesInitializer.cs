using DSS.Models;

namespace DSS.SourceSeed
{
    public static class ValuesInitializer
    {
        public static Value[] Initialize()
        {
            return new Value[]
            {
                #region 1                               
                new Value{PropertyId=1, PropertyValue="Класс АB"},
                new Value{PropertyId=1, PropertyValue="Класс В"},
                new Value{PropertyId=1, PropertyValue="Класс H"},
                new Value{PropertyId=1, PropertyValue="Класс G"},
                new Value{PropertyId=1, PropertyValue="Класс D"},
                #endregion

                #region 2                               
                new Value{PropertyId=2, PropertyValue="Наушники, 1 канал (Моно)"},
                new Value{PropertyId=2, PropertyValue="Наушники, 2 канала (Стерео)"},
                new Value{PropertyId=2, PropertyValue="1-канальный (Моно)"},
                new Value{PropertyId=2, PropertyValue="1-канальный (Моно) или 2-канальный (Стерео)"},
                new Value{PropertyId=2, PropertyValue="1-канальный (Моно) с моно и стерео-наушниками"},
                new Value{PropertyId=2, PropertyValue="1-канальный (Моно) с моно-наушниками"},
                new Value{PropertyId=2, PropertyValue="1-канальный (Моно) с стерео-наушниками"},
                new Value{PropertyId=2, PropertyValue="2-канальный (Стерео)"},
                new Value{PropertyId=2, PropertyValue="2-канальный (Стерео) или 4-канальный (Квадро)"},
                new Value{PropertyId=2, PropertyValue="2-Channel (Stereo) with Mono and Stereo Headphones"},
                new Value{PropertyId=2, PropertyValue="2-Channel (Stereo) with Stereo Headphones"},
                new Value{PropertyId=2, PropertyValue="2-Channel (Stereo) with Stereo Headphones and Subwoofer"},
                new Value{PropertyId=2, PropertyValue="2-Channel (Stereo) with Subwoofer"},
                new Value{PropertyId=2, PropertyValue="3-Channel"},
                new Value{PropertyId=2, PropertyValue="4-Channel (Quad)"},
                new Value{PropertyId=2, PropertyValue="6-Channel"},
                #endregion

                #region 3                                
                new Value{PropertyId=3, PropertyValue="8"},
                new Value{PropertyId=3, PropertyValue="8,5"},
                new Value{PropertyId=3, PropertyValue="9"},
                new Value{PropertyId=3, PropertyValue="10"},
                new Value{PropertyId=3, PropertyValue="15"},
                new Value{PropertyId=3, PropertyValue="16"},
                new Value{PropertyId=3, PropertyValue="23"},
                new Value{PropertyId=3, PropertyValue="24"},
                new Value{PropertyId=3, PropertyValue="25"},
                new Value{PropertyId=3, PropertyValue="25,6"},
                new Value{PropertyId=3, PropertyValue="32"},
                new Value{PropertyId=3, PropertyValue="35"},
                new Value{PropertyId=3, PropertyValue="37"},
                new Value{PropertyId=3, PropertyValue="40"},                    
                new Value{PropertyId=3, PropertyValue="42"},
                #endregion

                #region 4
                new Value{PropertyId=4, PropertyValue="8"},
                new Value{PropertyId=4, PropertyValue="16"},
                new Value{PropertyId=4, PropertyValue="32"},
                #endregion

                #region 5                
                new Value{PropertyId=5, PropertyValue="1"},
                new Value{PropertyId=5, PropertyValue="1,5"},
                new Value{PropertyId=5, PropertyValue="1,8"},
                new Value{PropertyId=5, PropertyValue="2"},
                new Value{PropertyId=5, PropertyValue="2,5"},
                new Value{PropertyId=5, PropertyValue="3"},
                new Value{PropertyId=5, PropertyValue="4"},
                new Value{PropertyId=5, PropertyValue="5"},
                new Value{PropertyId=5, PropertyValue="10"},
                #endregion

                #region 6              
                new Value{PropertyId=6, PropertyValue="5"},
                new Value{PropertyId=6, PropertyValue="10"},
                new Value{PropertyId=6, PropertyValue="12"},
                new Value{PropertyId=6, PropertyValue="15"},
                new Value{PropertyId=6, PropertyValue="16"},
                new Value{PropertyId=6, PropertyValue="18"},
                new Value{PropertyId=6, PropertyValue="20"},
                new Value{PropertyId=6, PropertyValue="30"},
                new Value{PropertyId=6, PropertyValue="40"},
                #endregion


                //new Value{PropertyId=3, PropertyValue="Наушники, 1 канал (Моно)"},
                //new Value{PropertyId=3, PropertyValue="Наушники, 2 канала (Стерео)"},
                //new Value{PropertyId=3, PropertyValue="Differential"},
                //new Value{PropertyId=3, PropertyValue="Push-Pull"},

                //new Value{PropertyId=5, PropertyValue="CATV"},
                //new Value{PropertyId=5, PropertyValue="Driver"},

                //new Value{PropertyId=6, PropertyValue="1"},
                //new Value{PropertyId=6, PropertyValue="2"},
                //new Value{PropertyId=6, PropertyValue="3"},
                //new Value{PropertyId=6, PropertyValue="4"},
                //new Value{PropertyId=6, PropertyValue="5"},

                //new Value{PropertyId=9, PropertyValue="450"},
                //new Value{PropertyId=9, PropertyValue="550"},
                //new Value{PropertyId=9, PropertyValue="600"},
                //new Value{PropertyId=9, PropertyValue="1250"},

                //new Value{PropertyId=2, PropertyValue="Apex Precision Power™"},
                //new Value{PropertyId=2, PropertyValue="LT®"},
                //new Value{PropertyId=2, PropertyValue="VIP10™"},

                //new Value{PropertyId=3, PropertyValue="Rail-to-Rail"},

                //new Value{PropertyId=5, PropertyValue="Buffer"},
                //new Value{PropertyId=5, PropertyValue="DC Restoration"},

                //new Value{PropertyId=10, PropertyValue="800"},
                //new Value{PropertyId=10, PropertyValue="1000"},
                //new Value{PropertyId=10, PropertyValue="2000"},
                //new Value{PropertyId=10, PropertyValue="9000"},
                //new Value{PropertyId=10, PropertyValue="100"}
            };
        }
    }
}