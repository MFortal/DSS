using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using DSS.Models;

namespace DSS.Controllers
{
    public class SubcategoriesController : Controller
    {
        private DssContext db = new DssContext();

        // GET: Subcategories/Create
        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Subcategories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,CategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Subcategories.Add(subcategory);
                db.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Edit/5
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
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // POST: Subcategories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,CategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
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
