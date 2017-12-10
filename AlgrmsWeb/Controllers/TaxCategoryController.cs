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

        // GET: TaxCategoryModels
        public async Task<ActionResult> Index()
        {
            return View(await db.TaxCategoryModels.ToListAsync());
        }

        // GET: TaxCategoryModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxCategory taxCategoryModel = await db.TaxCategoryModels.FindAsync(id);
            if (taxCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(taxCategoryModel);
        }

        // GET: TaxCategoryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxCategoryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,code,title,description,created_at,updated_at")] TaxCategory taxCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.TaxCategoryModels.Add(taxCategoryModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taxCategoryModel);
        }

        // GET: TaxCategoryModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxCategory taxCategoryModel = await db.TaxCategoryModels.FindAsync(id);
            if (taxCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(taxCategoryModel);
        }

        // POST: TaxCategoryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,code,title,description,created_at,updated_at")] TaxCategory taxCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxCategoryModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taxCategoryModel);
        }

        // GET: TaxCategoryModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxCategory taxCategoryModel = await db.TaxCategoryModels.FindAsync(id);
            if (taxCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(taxCategoryModel);
        }

        // POST: TaxCategoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaxCategory taxCategoryModel = await db.TaxCategoryModels.FindAsync(id);
            db.TaxCategoryModels.Remove(taxCategoryModel);
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
