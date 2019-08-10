using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        private DssContext db = new DssContext();

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
                .Where(x => x.Id == categoryId)
                .Select(x =>
                new DropDownSearchViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            ViewBag.categoryThis = categoryThis;

            var subcategoriesThis = db.Subcategories
                .Where(x => x.Id == subcategoryId)
                .Select(x =>
                new DropDownSearchViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            ViewBag.subcategoryThis = subcategoriesThis;

            //Все значения кроме текущих
            var categoriesWithoutThis = db.Categories
                .Where(x => x.Id != categoryId)
                .Select(x =>
                new DropDownSearchViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            var subcategoriesCategoryWithoutThis = db.Subcategories
               .Where(x => x.CategoryId == categoryId && x.Id != subcategoryId)
               .Select(x =>
               new DropDownSearchViewModel
               {
                   Id = x.Id,
                   Name = x.Name
               });

            ViewBag.Categories = categoriesWithoutThis;
            ViewBag.Subcategories = subcategoriesCategoryWithoutThis;
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
                ValueChecked = countries.ToDictionary(k => k.Id, v => new SelectionViewModel
                {
                    Name = v.Name,
                    Checked = false
                })
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
                        .ToDictionary(k => k.Id, v => new SelectionViewModel
                        {
                            Name = v.PropertyValue,
                            Checked = false
                        })
                });

            var filterViewModel = new SearchFilterViewModel
            {
                CountryProperty = countryProperty,
                Properties = filterProperties
            };

            var tableHeader = new TableHeaderViewModel
            {
                ComponentNameColumnName = DefaultNames.ComponentColumnName,
                CountryColumnName = DefaultNames.CountryColumnName,
                PropertyColumnNames = properties
                    .Select(x => x.Name)
                    .ToArray()
            };

            var rows = new List<TableRowViewModel>();
            foreach (var component in components)
            {
                var cells = new CellValueViewModel[properties.Count()];
                var indexCounter = 0;
                foreach (var property in properties)
                {
                    var cell = component.Cells.FirstOrDefault(x => x.Value.PropertyId == property.Id);
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

            var searchViewModel = new SearchViewModel
            {
                Filter = filterViewModel,
                Result = searchResult
            };

            return View(searchViewModel);
        }

        [HttpPost]
        public ActionResult ShowResult(SearchFilterViewModel searchFilter)
        {
            return PartialView();
        }

        public ActionResult FilterProperty(FilterPropertyViewModel filterPropertyViewModel)
        {
            return PartialView(filterPropertyViewModel);
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

        // GET: SearchComponents/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: SearchComponents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PropertyName")] SearchComponents searchComponents)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SearchComponents.Add(searchComponents);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(searchComponents);
        //}

        // GET: SearchComponents/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SearchComponents searchComponents = db.SearchComponents.Find(id);
        //    if (searchComponents == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(searchComponents);
        //}

        // POST: SearchComponents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PropertyName")] SearchComponents searchComponents)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(searchComponents).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(searchComponents);
        //}

        // GET: SearchComponents/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SearchComponents searchComponents = db.SearchComponents.Find(id);
        //    if (searchComponents == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(searchComponents);
        //}

        // POST: SearchComponents/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    SearchComponents searchComponents = db.SearchComponents.Find(id);
        //    db.SearchComponents.Remove(searchComponents);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
