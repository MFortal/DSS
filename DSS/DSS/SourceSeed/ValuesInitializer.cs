using DSS.Models;

namespace DSS.SourceSeed
{
    public static class ValuesInitializer
    {
        public static Value[] Initialize()
        {
            return new Value[]
            {
                //Аудио усилители
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

                //Видео усилители, модули
                #region 10

                new Value{PropertyId=10, PropertyValue="Automatic Gain Control (AGC)"},
                new Value{PropertyId=10, PropertyValue="Automotive Systems"},
                new Value{PropertyId=10, PropertyValue="Bias Clamp, CRT Driver"},
                new Value{PropertyId=10, PropertyValue="Buffer"},
                new Value{PropertyId=10, PropertyValue="CATV"},
                new Value{PropertyId=10, PropertyValue="Current Feedback"},
                new Value{PropertyId=10, PropertyValue="DC Restoration"},
                new Value{PropertyId=10, PropertyValue="Differential"},
                new Value{PropertyId=10, PropertyValue="Driver"},

                #endregion

                #region 11

                new Value{PropertyId=11, PropertyValue="Differential"},
                new Value{PropertyId=11, PropertyValue="Push-Pull"},
                new Value{PropertyId=11, PropertyValue="Rail-to-Rail"},
                new Value{PropertyId=11, PropertyValue="Single-Ended"},

                #endregion

                #region 12

                new Value{PropertyId=12, PropertyValue="1"},
                new Value{PropertyId=12, PropertyValue="2"},
                new Value{PropertyId=12, PropertyValue="3"},
                new Value{PropertyId=12, PropertyValue="4"},
                new Value{PropertyId=12, PropertyValue="5"},
                new Value{PropertyId=12, PropertyValue="6"},
                new Value{PropertyId=12, PropertyValue="8"},                    
                new Value{PropertyId=12, PropertyValue="10"},
                new Value{PropertyId=12, PropertyValue="18"},
                new Value{PropertyId=12, PropertyValue="24"},

                #endregion

                #region 13

                new Value{PropertyId=13, PropertyValue="800"},
                new Value{PropertyId=13, PropertyValue="1000"},
                new Value{PropertyId=13, PropertyValue="2000"},
                new Value{PropertyId=13, PropertyValue="3500"},
                new Value{PropertyId=13, PropertyValue="5000"},
                new Value{PropertyId=13, PropertyValue="6000"},
                new Value{PropertyId=13, PropertyValue="8000"},
                new Value{PropertyId=13, PropertyValue="10000"},
                new Value{PropertyId=13, PropertyValue="20000"},
                new Value{PropertyId=13, PropertyValue="40000"},
                new Value{PropertyId=13, PropertyValue="80000"},

                #endregion

                #region 14

                new Value{PropertyId=14, PropertyValue="1"},
                new Value{PropertyId=14, PropertyValue="6"},
                new Value{PropertyId=14, PropertyValue="7"},
                new Value{PropertyId=14, PropertyValue="8"},
                new Value{PropertyId=14, PropertyValue="10"},
                new Value{PropertyId=14, PropertyValue="15"},
                new Value{PropertyId=14, PropertyValue="20"},
                new Value{PropertyId=14, PropertyValue="25"},
                new Value{PropertyId=14, PropertyValue="30"},
                new Value{PropertyId=14, PropertyValue="35"},
                new Value{PropertyId=14, PropertyValue="40"},
                new Value{PropertyId=14, PropertyValue="50"},

                #endregion

                #region 15
                
                new Value{PropertyId=15, PropertyValue="0,5"},
                new Value{PropertyId=15, PropertyValue="1"},
                new Value{PropertyId=15, PropertyValue="1,5"},
                new Value{PropertyId=15, PropertyValue="2"},
                new Value{PropertyId=15, PropertyValue="3"},
                new Value{PropertyId=15, PropertyValue="5"},
                new Value{PropertyId=15, PropertyValue="7"},
                new Value{PropertyId=15, PropertyValue="8"},
                new Value{PropertyId=15, PropertyValue="10"},
                new Value{PropertyId=15, PropertyValue="15"},
                new Value{PropertyId=15, PropertyValue="20"},
                new Value{PropertyId=15, PropertyValue="25"},

                #endregion

                //Обработка звука
                #region 20
                
                new Value{PropertyId=20, PropertyValue="ADPCM Processor"},
                new Value{PropertyId=20, PropertyValue="Amplifier"},
                new Value{PropertyId=20, PropertyValue="Audio"},
                new Value{PropertyId=20, PropertyValue="Audio Amp"},
                new Value{PropertyId=20, PropertyValue="Audio Attenuator"},
                new Value{PropertyId=20, PropertyValue="Audio Limiter"},
                new Value{PropertyId=20, PropertyValue="Audio Processor"},
                new Value{PropertyId=20, PropertyValue="Audio Suppressor"},

                #endregion

                #region 21

                new Value{PropertyId=21, PropertyValue="Amplifiers, Consoles, Processers, Receivers"},
                new Value{PropertyId=21, PropertyValue="Audio routing, processing"},
                new Value{PropertyId=21, PropertyValue="Automotive Audio"},
                new Value{PropertyId=21, PropertyValue="Cell Phones, PC, MIDI"},
                new Value{PropertyId=21, PropertyValue="Desktop Audio, MP3, USB"},
                new Value{PropertyId=21, PropertyValue="TV, HI-FI Systems"},

                #endregion

                #region 22

                new Value{PropertyId=22, PropertyValue="Поверхностный монтаж"},
                new Value{PropertyId=22, PropertyValue="Through Hole"},

                #endregion

                #region 23

                new Value{PropertyId=23, PropertyValue="8-DIP"},
                new Value{PropertyId=23, PropertyValue="8-SOP"},
                new Value{PropertyId=23, PropertyValue="10-UMLP"},
                new Value{PropertyId=23, PropertyValue="16-DIP"},
                new Value{PropertyId=23, PropertyValue="16-DMP"},
                new Value{PropertyId=23, PropertyValue="16-QFN"},
                new Value{PropertyId=23, PropertyValue="16-SOIC"},
                new Value{PropertyId=23, PropertyValue="20-DIP"},
                new Value{PropertyId=23, PropertyValue="24-DIP"},
                new Value{PropertyId=23, PropertyValue="24-SOP"},
                new Value{PropertyId=23, PropertyValue="24-TSSOP"},
                new Value{PropertyId=23, PropertyValue="30-DMP"},
                new Value{PropertyId=23, PropertyValue="30-SDMP"},
                new Value{PropertyId=23, PropertyValue="32-QFN"},
                new Value{PropertyId=23, PropertyValue="64-LQFP"},
                new Value{PropertyId=23, PropertyValue="64-QFP"},
                new Value{PropertyId=23, PropertyValue="64-TQFP"},
                new Value{PropertyId=23, PropertyValue="128-FBGA"},

                #endregion
        };
        }
    }
}