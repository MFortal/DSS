using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DSS.Common;
using DSS.Models;
using DSS.ViewModels;

namespace DSS.Controllers
{
    public class SearchAnalogsController : Controller
    {
        private DssContext db = new DssContext();

        [HttpGet]
        // GET: SearchAnalogsViewModels
        public ActionResult Index()
        {
            ViewBag.CountVariance = DefaultNames.CountVariance;
            return View();
        }


        public ActionResult ShowResult(Component component)
        {
            var firstSubstring = db.Components
                .FirstOrDefault(c => c.Name.ToLower().Contains(component.Name.ToLower()));

            if (firstSubstring == null)
            {
                return PartialView(null);
            }

            var thisComponent = db.Components
               .FirstOrDefault(x => x.Name.ToLower() == component.Name.ToLower());

            if (thisComponent == null)
            {
                thisComponent = firstSubstring;
            }

            var otherComponents = db.Components
                .Where(x => x.CountryId == DefaultNames.RusId && x.Id != thisComponent.Id)
                .Where(x => x.SubcategoryId == thisComponent.SubcategoryId).ToArray();

            var filteredComponents = otherComponents
                .Where(x => CheckByAnalog(x, thisComponent))
                .ToArray();

            var properties = thisComponent.Cells
                .Select(x => x.Value.Property)
                .Distinct()
                .OrderBy(x => x.Id)
                .ToArray();

            var tableHeader = new TableHeaderViewModel
            {
                ComponentNameColumnName = DefaultNames.ComponentColumnName,
                CountryColumnName = DefaultNames.CountryColumnName,
                PropertyColumnNames = properties
                   .Select(x => x.Name)
                   .ToArray()
            };


            var cells1 = new CellValueViewModel[properties.Count()];
            var indexCounter1 = 0;
            foreach (var property in properties)
            {
                var cell1 = thisComponent.Cells.FirstOrDefault(x => x.Value.PropertyId == property.Id);
                cells1[indexCounter1] = new CellValueViewModel
                {
                    Value = cell1?.Value.PropertyValue,
                    Unit = cell1?.Value.Property.Unit
                };
                indexCounter1++;
            }
            var thisCoomponentRow = new TableRowViewModel
            {
                ComponentId = thisComponent.Id,
                ComponentName = thisComponent.Name,
                CountryName = thisComponent.Country.Name,
                CountryFlag = thisComponent.Country.Flag,
                Cells = cells1
            };

            var rows = new List<TableRowViewModel>();
            foreach (var filteredComponent in filteredComponents)
            {
                var cells = new CellValueViewModel[properties.Count()];
                var indexCounter = 0;
                foreach (var property in properties)
                {
                    var cell = filteredComponent.Cells.FirstOrDefault(x => x.Value.PropertyId == property.Id);
                    cells[indexCounter] = new CellValueViewModel
                    {
                        Value = cell?.Value.PropertyValue,
                        Unit = cell?.Value.Property.Unit
                    };
                    indexCounter++;
                }
                rows.Add(new TableRowViewModel
                {
                    ComponentId = filteredComponent.Id,
                    ComponentName = filteredComponent.Name,
                    CountryName = filteredComponent.Country.Name,
                    CountryFlag = filteredComponent.Country.Flag,
                    Cells = cells
                });
            }

            var searchResult = new SearchResultViewModel
            {
                TableHeader = tableHeader,
                Rows = rows,
                ThisComponentRow = thisCoomponentRow
            };

            return PartialView(searchResult);
        }

        private bool CheckByAnalog(Component anotherComponent, Component thisComponent)
        {
            var count = 0;
            foreach (var cell in thisComponent.Cells)
            {
                var propertyId = cell.Value.PropertyId;
                var thisValue = cell.Value.PropertyValue;
                var anotherValue = anotherComponent.Cells.FirstOrDefault(x => x.Value.PropertyId == propertyId)?.Value.PropertyValue;
                if (thisValue != anotherValue && !string.IsNullOrEmpty(anotherValue))
                {
                    count++;
                    if (count > DefaultNames.CountVariance)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

