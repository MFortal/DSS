using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
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
            if (subcategoryId == null && categoryId == null)
            {
                subcategoryId = 1;
                categoryId = 1;
            }
            if (subcategoryId == -1)
            {
                subcategoryId = db.Subcategories
                    .Where(x => x.CategoryId == categoryId)
                    .Select(x => x.Id)
                    .First();
            }

            ViewBag.categoryId = categoryId;
            #endregion

            #region DropDown
            //Передача текущих значений для dropDown
            var categoryThis = db.Categories
                .Where(x => x.Id == categoryId)
                .Select(x =>
                new DropDownSearch
                {
                    Id = x.Id,
                    Name = x.Name
                });

            ViewBag.categoryThis = categoryThis;

            var subcategoriesThis = db.Subcategories
                .Where(x => x.Id == subcategoryId)
                .Select(x =>
                new DropDownSearch
                {
                    Id = x.Id,
                    Name = x.Name
                });

            ViewBag.subcategoryThis = subcategoriesThis;

            //Все значения кроме текущих
            var categoriesWithoutThis = db.Categories
                .Where(x => x.Id != categoryId)
                .Select(x =>
                new DropDownSearch
                {
                    Id = x.Id,
                    Name = x.Name
                });

            var subcategoriesCategoryWithoutThis = db.Subcategories
               .Where(x => x.CategoryId == categoryId && x.Id != subcategoryId)
               .Select(x =>
               new DropDownSearch
               {
                   Id = x.Id,
                   Name = x.Name
               });

            ViewBag.Categories = categoriesWithoutThis;
            ViewBag.Subcategories = subcategoriesCategoryWithoutThis;
            #endregion

            #region SeachAllComponents
            //Поиск всех компонентов в подкатегории
            var components = db.Components
                .Where(x => x.SubcategoryId == subcategoryId)
                .Select(x =>
                new ComponentsSubcategory
                {
                    Id = x.Id,
                    Name = x.Name,
                    CountryName = x.Country.Name,
                    CountryFlag = x.Country.Flag
                });
            #endregion

            #region SearchField
            //Поиск свойств подкатегории в сущности Properties - Values
            var propertyIds = db.SubcategoryProperties
                .Where(x => x.SubcategoryId == subcategoryId)
                .Select(x => x.PropertyId);

            //Поиск всех Id компонентов в этой подкатегории
            var componentIds = db.Components
                .Where(x => x.SubcategoryId == subcategoryId)
                .Select(x => x.Id);

            //Все свойства, присутствующие в Cells
            var valuesCells = db.Cells
                .Where(x => componentIds.Contains(x.ComponentId))
                .Select(x => x.ValueId);

            //Перечисление свойств и их значений
            var propertiesWithValues = db.Properties
                .Where(x => propertyIds.Contains(x.Id))
                .Select(x =>
                new PropertyValuesSubcategories
                {
                    PropertyName = x.Name,
                    Values = x.Values
                        .Where(y => valuesCells.Contains(y.Id))
                        .Select(y => y.PropertyValue),
                    Description = x.Description,
                    Unit = x.Unit
                }).ToList();

            //Все страны, присутствующие в Cells
            var countyIds = db.Components
                .Where(x => componentIds.Contains(x.Id))
                .Select(x => x.CountryId);

            //Поиск производителей присутствующих у компонентов этой подкатегори
            var makerWithValues = new List<PropertyValuesSubcategories>
            {
                new PropertyValuesSubcategories
                {
                    PropertyName = "Производитель",
                    Values = db.Countries
                        .Where(f=>countyIds.Contains(f.Id))
                        .Select(f => f.Name),
                    Description = "Made in, как говорится"
                }
            };

            var propertyResult = propertiesWithValues.Union(makerWithValues);
            #endregion

            var viewSearch = new ViewSearch { PropertyValuesSubcategories = propertyResult, ComponentsSubcategory = components };

            return View(viewSearch);
        }

        // GET: SearchComponents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchComponents searchComponents = db.SearchComponents.Find(id);
            if (searchComponents == null)
            {
                return HttpNotFound();
            }
            return View(searchComponents);
        }

        // GET: SearchComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchComponents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyName")] SearchComponents searchComponents)
        {
            if (ModelState.IsValid)
            {
                db.SearchComponents.Add(searchComponents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(searchComponents);
        }

        // GET: SearchComponents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchComponents searchComponents = db.SearchComponents.Find(id);
            if (searchComponents == null)
            {
                return HttpNotFound();
            }
            return View(searchComponents);
        }

        // POST: SearchComponents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyName")] SearchComponents searchComponents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchComponents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchComponents);
        }

        // GET: SearchComponents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchComponents searchComponents = db.SearchComponents.Find(id);
            if (searchComponents == null)
            {
                return HttpNotFound();
            }
            return View(searchComponents);
        }

        // POST: SearchComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SearchComponents searchComponents = db.SearchComponents.Find(id);
            db.SearchComponents.Remove(searchComponents);
            db.SaveChanges();
            return RedirectToAction("Index");
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
