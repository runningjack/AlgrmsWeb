using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlgrmsWeb.Models;

namespace AlgrmsWeb.Controllers
{
    public class TaxCategoryController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: TaxCategory
        public async Task<ActionResult> Index()
        {
            return View(await db.TaxCategories.ToListAsync());
        }

        // GET: TaxCategory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxCategory TaxCategory = await db.TaxCategories.FindAsync(id);
            if (TaxCategory == null)
            {
                return HttpNotFound();
            }
            return View(TaxCategory);
        }

        // GET: TaxCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,code,title,description,created_at,updated_at")] TaxCategory TaxCategory)
        {
            if (ModelState.IsValid)
            {
                db.TaxCategories.Add(TaxCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(TaxCategory);
        }

        // GET: TaxCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxCategory TaxCategory = await db.TaxCategories.FindAsync(id);
            if (TaxCategory == null)
            {
                return HttpNotFound();
            }
            return View(TaxCategory);
        }

        // POST: TaxCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,code,title,description,created_at,updated_at")] TaxCategory TaxCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TaxCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(TaxCategory);
        }

        // GET: TaxCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxCategory TaxCategory = await db.TaxCategories.FindAsync(id);
            if (TaxCategory == null)
            {
                return HttpNotFound();
            }
            return View(TaxCategory);
        }

        // POST: TaxCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaxCategory TaxCategory = await db.TaxCategories.FindAsync(id);
            db.TaxCategories.Remove(TaxCategory);
            await db.SaveChangesAsync();
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
