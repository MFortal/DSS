using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DSS.Common;
using DSS.Models;
using DSS.ViewModels;

namespace DSS.Controllers
{
    public class SearchComponentsController : Controller
    {
        private readonly DssContext db = new DssContext();

        // GET: SearchComponents
        public ActionResult Index(int? categoryId, int? subcategoryId)
        {
            #region CheckIds           
            if (categoryId == null)
            {
                categoryId = db.Categories.First().Id;
            }

            if (subcategoryId == null)
            {
                subcategoryId = db.Categories.First(x => x.Id == categoryId).Subcategories.First().Id;
            }

            ViewBag.categoryId = categoryId;
            #endregion

            #region DropDown
            //Передача текущих значений для dropDown
            var categoryThis = db.Categories
                .FirstOrDefault(x => x.Id == categoryId);

            var subcategoriesThis = db.Subcategories
                .FirstOrDefault(x => x.Id == subcategoryId);          

            //Все значения кроме текущих
            var categoriesWithoutThis = db.Categories
                .Where(x => x.Id != categoryId)
                .Select(x =>
                new SelectionViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            var subcategoriesCategoryWithoutThis = db.Subcategories
               .Where(x => x.CategoryId == categoryId && x.Id != subcategoryId)
               .Select(x =>
               new SelectionViewModel
               {
                   Id = x.Id,
                   Name = x.Name
               });

            var dropDown = new DropDownSearchViewModel
            {
                ThisCategory = new SelectionViewModel
                {
                    Id = categoryThis.Id,
                    Name = categoryThis.Name
                },
                ThisSubcategory = new SelectionViewModel
                {
                    Id = subcategoriesThis.Id,
                    Name = subcategoriesThis.Name
                },
                OtherCategories = categoriesWithoutThis,
                OtherSubcategories = subcategoriesCategoryWithoutThis
            };
            #endregion

            var components = db.Components
                .Where(x => x.SubcategoryId == subcategoryId);

            var countries = components
                .Select(x => x.Country)
                .Distinct();

            var countryProperty = new FilterPropertyViewModel
            {
                PropertyId = null,
                Description = null,
                PropertyName = DefaultNames.CountryColumnName,
                Unit = null,
                ValueChecked = countries
                .Select(x =>
                new SelectionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Checked = false
                })
                .ToArray()
            };

            var properties = components
                .SelectMany(x => x.Cells)
                .Select(x => x.Value.Property)
                .Distinct()
                .OrderBy(x => x.Id);

            var values = components
                .SelectMany(x => x.Cells)
                .Select(x => x.Value)
                .Distinct();

            var filterProperties = properties
                .AsEnumerable()
                .Select(x => new FilterPropertyViewModel
                {
                    PropertyId = x.Id,
                    Description = x.Description,
                    PropertyName = x.Name,
                    Unit = x.Unit,
                    ValueChecked = values
                    .Where(v => v.PropertyId == x.Id)
                    .Select(v =>
                    new SelectionViewModel
                    {
                        Id = v.Id,
                        Name = v.PropertyValue,
                        Checked = false
                    })
                    .ToArray()
                })
                .ToArray();

            var filterViewModel = new SearchFilterViewModel
            {
                DropDown = dropDown,
                CountryProperty = countryProperty,
                Properties = filterProperties
            };            

            return View(filterViewModel);
        }

        [HttpPost]
        public ActionResult ShowResult(SearchFilterViewModel searchFilterViewModel)
        {
            var subcategoryId = searchFilterViewModel.DropDown.ThisSubcategory.Id;

            var components = db.Components
                .Where(x => x.SubcategoryId == subcategoryId);

            var countryFilter = searchFilterViewModel.CountryProperty;
            var propertiesFilter = searchFilterViewModel.Properties;
            
            var filteredComponent = components.AsEnumerable()
                .Where(x => CheckByCountry(x, countryFilter))
                .Where(x => propertiesFilter.All(p => CheckByProperty(x, p)));                

            var tableHeader = new TableHeaderViewModel
            {
                ComponentNameColumnName = DefaultNames.ComponentColumnName,
                CountryColumnName = DefaultNames.CountryColumnName,
                PropertyColumnNames = propertiesFilter
                    .Select(x => x.PropertyName)
                    .ToArray()
            };

            var rows = new List<TableRowViewModel>();
            foreach (var component in filteredComponent)
            {
                var cells = new CellValueViewModel[propertiesFilter.Count()];
                var indexCounter = 0;
                foreach (var property in propertiesFilter)
                {
                    var cell = component.Cells.FirstOrDefault(x => x.Value.PropertyId == property.PropertyId);
                    cells[indexCounter] = new CellValueViewModel
                    {
                        Value = cell?.Value.PropertyValue,
                        Unit = cell?.Value.Property.Unit
                    };
                    indexCounter++;
                }
                var row = new TableRowViewModel
                {
                    ComponentId = component.Id,
                    ComponentName = component.Name,
                    CountryName = component.Country.Name,
                    CountryFlag = component.Country.Flag,
                    Cells = cells
                };
                rows.Add(row);
            }

            var searchResult = new SearchResultViewModel
            {
                TableHeader = tableHeader,
                Rows = rows
            };

            return PartialView(searchResult);
        }

        private bool CheckByProperty(Component component, FilterPropertyViewModel filterProperty)
        {
            if (!filterProperty.ValueChecked.Any(x => x.Checked))
            {
                return true;
            }
            var value = component.Cells.FirstOrDefault(x => x.Value.PropertyId == filterProperty.PropertyId)?.Value;

            return value == null 
                || filterProperty.ValueChecked
                .Where(x => x.Checked)
                .Any(x => x.Id == value.Id);
        }
        private bool CheckByCountry(Component component, FilterPropertyViewModel filterCountry)
        {
            if (!filterCountry.ValueChecked.Any(x => x.Checked))
            {
                return true;
            }

            return filterCountry.ValueChecked
                .Where(x => x.Checked)
                .Any(x => x.Id == component.CountryId);
        }

        // GET: SearchComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Components.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
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
