using DSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSS.SourceSeed
{
    public static class CategoriesInitializer
    {
        public static Category[] Initialize()
        {
            return new Category[]
            {
                new Category{Id=1, Name="Интегральные микросхемы", Image=null },
                new Category{Id=2, Name="Конденсаторы", Image=null }
            };
        }
    }
}