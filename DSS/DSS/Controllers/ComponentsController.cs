using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DSS.Models;
using DSS.ViewModels.Component;

namespace DSS.Controllers
{
    public class ComponentsController : Controller
    {
        private DssContext db = new DssContext();

        // GET: Components/Details/5
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

        // GET: Components/Create
        public ActionResult Create(int subcategoryId)
        {
            var propertyIds = db.SubcategoryProperties
                .Where(x => x.SubcategoryId == subcategoryId)
                .Select(x => x.PropertyId);

            var properties = db.Properties
                .Where(x => propertyIds.Contains(x.Id))
                .OrderBy(x => x.Id)
                .Select(x => new PropertyViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Unit = x.Unit
                })
                .OrderBy(x => x.Name)
                .ToArray();

            var componentViewModel = new ComponentViewModel()
            {
                SubcategoryId = subcategoryId,
                Countries = new SelectList(db.Countries, "Id", "Name"),
                Properties = properties,
                PreviousUrl = Request.UrlReferrer.AbsoluteUri                
            };

            return View(componentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComponentViewModel componentViewModel)
        {
            var cells = new List<Cell>();
            foreach (var propertyViewModel in componentViewModel.Properties)
            {
                var property = db.Properties.Find(propertyViewModel.Id);

                if (string.IsNullOrEmpty(propertyViewModel.Value))
                {
                    continue;
                }

                if (property.IsEnum)
                {                    
                    var matchedValue = property.Values
                        .FirstOrDefault(x => x.PropertyValue.ToLower().Trim() == propertyViewModel.Value.ToLower().Trim().Replace(".", ","));

                    if (matchedValue != null)
                    {
                        cells.Add(
                            new Cell
                            {
                                Value = matchedValue
                            });
                        continue;
                    }
                }
                cells.Add(
                    new Cell()
                    {
                        Value = new Value()
                        {
                            PropertyId = propertyViewModel.Id,
                            PropertyValue = propertyViewModel.Value.Replace(".", ",")
                        }
                    });
            }

            var component = new Component()
            {
                Name = componentViewModel.Name,
                CountryId = componentViewModel.SelectedCountryId,
                SubcategoryId = componentViewModel.SubcategoryId,
                Cells = cells
            };

            if (ModelState.IsValid)
            {
                db.Components.Add(component);
                db.SaveChanges();

                return RedirectPermanent(componentViewModel.PreviousUrl);
            }
            return View(componentViewModel);
        }

        // GET: Components/Edit/5
        public ActionResult Edit(int? id)
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
            var propertyIds = db.SubcategoryProperties
                .Where(x => x.SubcategoryId == component.SubcategoryId)
                .Select(x => x.PropertyId);

            var properties = db.Properties
                .Where(x => propertyIds.Contains(x.Id))
                .AsEnumerable()
                .Select(x => new PropertyViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Unit = x.Unit,
                    Value = component.Cells.AsEnumerable().FirstOrDefault(c => c.Value.PropertyId == x.Id).Value.PropertyValue,
                })
                .OrderBy(x => x.Name)
                .ToArray();

            var componentViewModel = new ComponentViewModel()
            {
                Id = component.Id,
                Name = component.Name,
                SubcategoryId = component.SubcategoryId,
                SelectedCountryId = component.CountryId,
                Countries = new SelectList(db.Countries, "Id", "Name", component.CountryId),
                Properties = properties,
                PreviousUrl = Request.UrlReferrer.AbsoluteUri
            };
            return View(componentViewModel);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComponentViewModel componentViewModel)
        {

            var cells = new List<Cell>();
            foreach (var propertyViewModel in componentViewModel.Properties)
            {
                var property = db.Properties.Find(propertyViewModel.Id);

                if (string.IsNullOrEmpty(propertyViewModel.Value))
                {
                    continue;
                }

                if (property.IsEnum)
                {
                    var matchedValue = property.Values
                        .FirstOrDefault(x => x.PropertyValue.ToLower().Trim() == propertyViewModel.Value.ToLower().Trim().Replace(".", ","));

                    if (matchedValue != null)
                    {
                        cells.Add(
                            new Cell
                            {
                                Value = matchedValue
                            });
                        continue;
                    }
                }
                cells.Add(
                    new Cell()
                    {
                        Value = new Value()
                        {
                            PropertyId = propertyViewModel.Id,
                            PropertyValue = propertyViewModel.Value.Replace(".", ",")
                        }
                    });
            }

            var component = db.Components.Find(componentViewModel.Id);
            component.Name = componentViewModel.Name;
            component.CountryId = componentViewModel.SelectedCountryId;
            component.SubcategoryId = componentViewModel.SubcategoryId;
            db.Cells.RemoveRange(component.Cells);
            //component.Cells.Clear();
            component.Cells = cells;

            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "SearchComponents", new { subcategoryId = component.SubcategoryId });
            }
            return View(componentViewModel);
        }

        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int subcategoryId)
        {
            Component component = db.Components.Find(id);
            db.Components.Remove(component);
            db.SaveChanges();
            return RedirectToAction("Index", "SearchComponents", new { subcategoryId = subcategoryId});
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
