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
    public class RevenueChargesController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: RevenueCharges
        public async Task<ActionResult> Index()
        {
            return View(await db.RevenueCharges.ToListAsync());
        }

        // GET: RevenueCharges/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevenueCharge revenueCharge = await db.RevenueCharges.FindAsync(id);
            if (revenueCharge == null)
            {
                return HttpNotFound();
            }
            return View(revenueCharge);
        }

        // GET: RevenueCharges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RevenueCharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,issuer_code,revenue_code,title,description,charge_rate,charge_amount,created_at,updated_at")] RevenueCharge revenueCharge)
        {
            if (ModelState.IsValid)
            {
                db.RevenueCharges.Add(revenueCharge);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(revenueCharge);
        }

        // GET: RevenueCharges/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevenueCharge revenueCharge = await db.RevenueCharges.FindAsync(id);
            if (revenueCharge == null)
            {
                return HttpNotFound();
            }
            return View(revenueCharge);
        }

        // POST: RevenueCharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,issuer_code,revenue_code,title,description,charge_rate,charge_amount,created_at,updated_at")] RevenueCharge revenueCharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revenueCharge).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(revenueCharge);
        }

        // GET: RevenueCharges/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevenueCharge revenueCharge = await db.RevenueCharges.FindAsync(id);
            if (revenueCharge == null)
            {
                return HttpNotFound();
            }
            return View(revenueCharge);
        }

        // POST: RevenueCharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RevenueCharge revenueCharge = await db.RevenueCharges.FindAsync(id);
            db.RevenueCharges.Remove(revenueCharge);
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
