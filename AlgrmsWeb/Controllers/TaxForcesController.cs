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
    public class TaxForcesController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: TaxForces
        public async Task<ActionResult> Index()
        {
            return View(await db.TaxForces.ToListAsync());
        }

        // GET: TaxForces/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxForce taxForce = await db.TaxForces.FindAsync(id);
            if (taxForce == null)
            {
                return HttpNotFound();
            }
            return View(taxForce);
        }

        // GET: TaxForces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxForces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,issuer_code,task_force_code,task_force_name,task_force_description,task_force_address,task_force_phone,task_force_email,view_status,active_status,enabled_status,created_at,updated_at")] TaxForce taxForce)
        {
            if (ModelState.IsValid)
            {
                db.TaxForces.Add(taxForce);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taxForce);
        }

        // GET: TaxForces/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxForce taxForce = await db.TaxForces.FindAsync(id);
            if (taxForce == null)
            {
                return HttpNotFound();
            }
            return View(taxForce);
        }

        // POST: TaxForces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,issuer_code,task_force_code,task_force_name,task_force_description,task_force_address,task_force_phone,task_force_email,view_status,active_status,enabled_status,created_at,updated_at")] TaxForce taxForce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxForce).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taxForce);
        }

        // GET: TaxForces/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxForce taxForce = await db.TaxForces.FindAsync(id);
            if (taxForce == null)
            {
                return HttpNotFound();
            }
            return View(taxForce);
        }

        // POST: TaxForces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaxForce taxForce = await db.TaxForces.FindAsync(id);
            db.TaxForces.Remove(taxForce);
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
