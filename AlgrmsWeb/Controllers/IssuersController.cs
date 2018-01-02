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
    public class IssuersController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: Issuers
        public async Task<ActionResult> Index()
        {
            return View(await db.Issuers.ToListAsync());
        }

        // GET: Issuers/Details/5
        public async Task<ActionResult> Details(string code ="")
        {
            if (code == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issuer issuer = await db.Issuers.Where(s=> s.issuer_code == code).FirstOrDefaultAsync();
            if (issuer == null)
            {
                return HttpNotFound();
            }
            return View(issuer);
        }

        // GET: Issuers/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem
            {
                Value = z.state_name,// z.zone_id.ToString(),
                Text = z.state_name
            });

            ViewBag.zones = items;
            return View();
        }

        // POST: Issuers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "issuer_code,issuer_name,issuer_contact_name,issuer_conatct_phone,issuer_email,issuer_desription,issuer_address,issuer_city,issuer_state,issuer_country,view_status,active_status,issuer_geo_data,created_at,updated_at")] Issuer issuer)
        {
            if(issuer != null)
            {
                int k = 0;
            }
            if (ModelState.IsValid)
            {
                db.Issuers.Add(issuer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem
            {
                Value = z.state_name,// z.zone_id.ToString(),
                Text = z.state_name
            });

            ViewBag.zones = items;
            return View(issuer);
        }

        // GET: Issuers/Edit/5
        public async Task<ActionResult> Edit(string code ="")
        {

            if (code == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issuer issuer = await db.Issuers.Where(s => s.issuer_code == code).FirstOrDefaultAsync();
            if (issuer == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem
            {
                Value = z.state_name,// z.zone_id.ToString(),
                Text = z.state_name
            });

            ViewBag.Zones = items;
            return View(issuer);
        }

        // POST: Issuers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "issuer_code,issuer_name,issuer_contact_name,issuer_conatct_phone,issuer_email,issuer_desription,issuer_address,issuer_city,issuer_state,issuer_country,view_status,active_status,issuer_geo_data,created_at,updated_at")] Issuer issuer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issuer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(issuer);
        }

        // GET: Issuers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issuer issuer = await db.Issuers.FindAsync(id);
            if (issuer == null)
            {
                return HttpNotFound();
            }
            return View(issuer);
        }

        // POST: Issuers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Issuer issuer = await db.Issuers.FindAsync(id);
            db.Issuers.Remove(issuer);
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
