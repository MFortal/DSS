using System;
using System.Collections.Generic;
using System.Linq;
using DSS.Models;

namespace DSS.SourceSeed
{
    public class CellsInitializer
    {
        public static Cell[] Initialize(DssContext db)
        {
            var rand = new Random();
            var result = new List<Cell>();

            foreach (var component in db.Components)
            {
                //выбор всех свойст подкатегории
                var propertyIds = db.SubcategoryProperties
                    .Where(x => component.SubcategoryId == x.SubcategoryId)
                    .Select(x => x.PropertyId);
                var properties = db.Properties
                    .Where(x => propertyIds.Contains(x.Id))
                    .Where(x => x.IsEnum);

                foreach (var property in properties)
                {
                    var values = db.Values
                        .Where(x => property.Id == x.PropertyId)
                        .Select(x => x.Id)
                        .ToArray();

                    if (values.Any())
                    {
                        result.Add(new Cell()
                        {
                            ComponentId = component.Id,
                            ValueId = values[rand.Next(0, values.Length)]
                        });
                    }                    
                }
            }

            return result.ToArray();

            //return new Cell[]
            //{
            //    new Cell{Id=1, ComponentId=1, ValueId=1},
            //    new Cell{Id=2, ComponentId=1, ValueId=4},

            //    new Cell{Id=3, ComponentId=2, ValueId=2},
            //    new Cell{Id=4, ComponentId=2, ValueId=3},
            //    new Cell{Id=5, ComponentId=2, ValueId=8},

            //    new Cell{Id=6, ComponentId=3, ValueId=1},
            //    new Cell{Id=7, ComponentId=3, ValueId=5},
            //    new Cell{Id=8, ComponentId=3, ValueId=9},

            //    new Cell{Id=9, ComponentId=4, ValueId=1},

            //    new Cell{Id=10, ComponentId=5, ValueId=1},

            //    new Cell{Id=11, ComponentId=6, ValueId=4},

            //    new Cell{Id=12, ComponentId=7, ValueId=3},
            //    new Cell{Id=13, ComponentId=7, ValueId=8},
            //    new Cell{Id=22, ComponentId=7, ValueId=15},

            //    new Cell{Id=14, ComponentId=8, ValueId=10},
            //    new Cell{Id=21, ComponentId=8, ValueId=14},

            //    new Cell{Id=15, ComponentId=9, ValueId=4},
            //    new Cell{Id=16, ComponentId=9, ValueId=7},
            //    new Cell{Id=17, ComponentId=9, ValueId=13},

            //    new Cell{Id=18, ComponentId=13, ValueId=17},

            //    new Cell{Id=19, ComponentId=14, ValueId=17},

            //    new Cell{Id=20, ComponentId=15, ValueId=18}
            //};
        }
    }
}