using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DSS.Common;
using DSS.Models;
using DSS.ViewModels.Subcategory;

namespace DSS.Controllers
{
    public class SubcategoriesController : Controller
    {
        private DssContext db = new DssContext();

        // GET: Subcategories/Create
        [Authorize(Roles = DefaultRoles.Admin)]
        public ActionResult Create()
        {
            var model = new CreateSubcategoryViewModel
            {
                Categories = new SelectList(db.Categories, "Id", "Name"),
                Properties = new SelectList(db.Properties, "Id", "Name"),
            };
            return View(model);
        }

        // POST: Subcategories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSubcategoryViewModel subcategoryViewModel)
        {
            var subcategory = new Subcategory()
            {
                Name = subcategoryViewModel.Name,
                CategoryId = subcategoryViewModel.SelectedCategoryId,
                SubcategoryProperties = new List<SubcategoryProperty>()
            };

            foreach (var selectedPropertyId in subcategoryViewModel.SelectedPropertyIds ?? Array.Empty<int>())
            {
                db.SubcategoryProperties.Add(
                    new SubcategoryProperty()
                    {
                        PropertyId = selectedPropertyId,
                        SubcategoryId = subcategory.Id
                    });
            }

            if (ModelState.IsValid)
            {
                db.Subcategories.Add(subcategory);
                db.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", subcategory.CategoryId);
            return View(subcategoryViewModel);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = db.Subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }

            var properties = db.Properties
                .AsEnumerable()
                .Where(x => subcategory.SubcategoryProperties.Any(y => y.PropertyId == x.Id));

            var model = new DetailsSubcategoryViewModel()
            {
                Name = subcategory.Name,
                Category = subcategory.Category,
                Properties = properties
            };
            return View(model);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = db.Subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }

            var categoryId = subcategory.CategoryId;
            var propertyIds = subcategory.SubcategoryProperties.Select(x => x.PropertyId);

            var model = new CreateSubcategoryViewModel
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                Categories = new SelectList(db.Categories, "Id", "Name", categoryId),
                Properties = new SelectList(db.Properties, "Id", "Name", propertyIds),
                SelectedCategoryId = subcategory.CategoryId,
                SelectedPropertyIds = propertyIds,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateSubcategoryViewModel subcategoryViewModel)
        {
            Subcategory subcategory = db.Subcategories.Find(subcategoryViewModel.Id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }

            subcategory.CategoryId = subcategoryViewModel.SelectedCategoryId;
            subcategory.Name = subcategoryViewModel.Name;

            var oldSubcategoryProperties = db.SubcategoryProperties.Where(x => x.SubcategoryId == subcategory.Id);
            db.SubcategoryProperties.RemoveRange(oldSubcategoryProperties);
            foreach (var selectedPropertyId in subcategoryViewModel.SelectedPropertyIds)
            {
                subcategory.SubcategoryProperties.Add(
                    new SubcategoryProperty()
                    {
                        SubcategoryId = subcategory.Id,
                        PropertyId = selectedPropertyId
                    }
                );
            }

            db.SaveChanges();

            return RedirectToAction("Details", "Categories", new {id = subcategory.CategoryId});
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = db.Subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategory subcategory = db.Subcategories.Find(id);
            db.Subcategories.Remove(subcategory);
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");
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
