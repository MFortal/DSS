using System.Collections.Generic;
using System.Data;
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

        [HttpPost]
        public JsonResult Index(string prefix)
        {
            var componentsList = db.Components
                .Where (c => c.Name.ToLower().Contains(prefix.ToLower()) && c.Country.Id != DefaultNames.RusId)
                .Select(c => c.Name);

            return Json(componentsList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowResult(Component component)
        {
            var c = db.Components.Select(x => x.Name).ToList();

            if (!c.Contains(component.Name))
            {
                return PartialView(null);
            }

            var subcategoryId = db.Components
                .Where(x => x.Name == component.Name)
                .Select(x => x.SubcategoryId)
                .FirstOrDefault();

            var allComponents = db.Components
                .Where(x => x.SubcategoryId == subcategoryId);

            var thisComponent = db.Components
                .FirstOrDefault(x => x.Name == component.Name);

            var otherComponents = db.Components
                .Where(x => x.CountryId == DefaultNames.RusId)
                .Where(x => x.SubcategoryId == subcategoryId).ToArray();

            var properties = allComponents
                .SelectMany(x => x.Cells)
                .Select(x => x.Value.Property)
                .Distinct()
                .OrderBy(x => x.Id);

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

            var filteredComponent = otherComponents.AsEnumerable();
          
            var rows = new List<TableRowViewModel>();
            foreach (var filterComponent in filteredComponent)
            {
                var cells = new CellValueViewModel[properties.Count()];
                var indexCounter = 0;
                foreach (var property in properties)
                {
                    var cell = filterComponent.Cells.FirstOrDefault(x => x.Value.PropertyId == property.Id);
                    cells[indexCounter] = new CellValueViewModel
                    {
                        Value = cell?.Value.PropertyValue,
                        Unit = cell?.Value.Property.Unit
                    };
                    indexCounter++;
                }
                var row = new TableRowViewModel
                {
                    ComponentId = filterComponent.Id,
                    ComponentName = filterComponent.Name,
                    CountryName = filterComponent.Country.Name,
                    CountryFlag = filterComponent.Country.Flag,
                    Cells = cells
                };

                
                if (CheckByAnalog(row, thisCoomponentRow))
                {
                    rows.Add(row);
                }
            }

            var searchResult = new SearchResultViewModel
            {
                TableHeader = tableHeader,
                Rows = rows,
                ThisComponentRow = thisCoomponentRow
            };

            return PartialView(searchResult);
        }

        private bool CheckByAnalog(TableRowViewModel anotherComponent, TableRowViewModel thisCoomponentRow)
        {
            var kol = 0;
            for (var i = 0; i < anotherComponent.Cells.Count(); i++)
            { 
                var anotherValue = anotherComponent.Cells[i]?.Value;
                var thisValue = thisCoomponentRow.Cells[i]?.Value;
                
                if (!(anotherValue == thisValue))

                {
                    kol++;
                }
            }
            return kol <= DefaultNames.CountVariance ? true : false;
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

