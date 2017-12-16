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
    public class ZonesController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: Zones
        public async Task<ActionResult> Index()
        {
            return View(await db.Zones.ToListAsync());
        }

        // GET: Zones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zone zone = await db.Zones.FindAsync(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        // GET: Zones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "zone_id,country_id,state_name,code,created_at,updated_at")] Zone zone)
        {
            if (ModelState.IsValid)
            {
                db.Zones.Add(zone);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(zone);
        }

        // GET: Zones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zone zone = await db.Zones.FindAsync(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        // POST: Zones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "zone_id,country_id,state_name,code,created_at,updated_at")] Zone zone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zone);
        }

        // GET: Zones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zone zone = await db.Zones.FindAsync(id);
            if (zone == null)
            {
                return HttpNotFound();
            }
            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Zone zone = await db.Zones.FindAsync(id);
            db.Zones.Remove(zone);
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
