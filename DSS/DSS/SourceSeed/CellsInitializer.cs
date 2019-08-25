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
        }
    }
}