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
    public class TaxAgentsController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: TaxAgents
        public async Task<ActionResult> Index()
        {
            return View(await db.TaxAgents.ToListAsync());
        }

        // GET: TaxAgents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxAgent taxAgent = await db.TaxAgents.FindAsync(id);
            if (taxAgent == null)
            {
                return HttpNotFound();
            }
            return View(taxAgent);
        }

        // GET: TaxAgents/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> forces = db.TaxForces.Select(t => new SelectListItem { Value = t.task_force_code, Text = t.task_force_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.forces = forces;
            return View();
        }

        // POST: TaxAgents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "issuer_code,tax_force_code,agent_code,first_name,last_name,other_name,dob,gender,address,city,state,country,created_at,updated_at")] TaxAgent taxAgent)
        {
            if (ModelState.IsValid)
            {
                db.TaxAgents.Add(taxAgent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> forces = db.TaxForces.Select(t => new SelectListItem { Value = t.task_force_code, Text = t.task_force_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.forces = forces;
            return View(taxAgent);
        }

        // GET: TaxAgents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxAgent taxAgent = await db.TaxAgents.FindAsync(id);
            if (taxAgent == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> forces = db.TaxForces.Select(t => new SelectListItem { Value = t.task_force_code, Text = t.task_force_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.forces = forces;
            return View(taxAgent);
        }

        // POST: TaxAgents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "issuer_code,tax_force_code,agent_code,first_name,last_name,other_name,dob,gender,address,city,state,country,created_at,updated_at")] TaxAgent taxAgent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxAgent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> forces = db.TaxForces.Select(t => new SelectListItem { Value = t.task_force_code, Text = t.task_force_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.forces = forces;
            return View(taxAgent);
        }

        // GET: TaxAgents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxAgent taxAgent = await db.TaxAgents.FindAsync(id);
            if (taxAgent == null)
            {
                return HttpNotFound();
            }
            return View(taxAgent);
        }

        // POST: TaxAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaxAgent taxAgent = await db.TaxAgents.FindAsync(id);
            db.TaxAgents.Remove(taxAgent);
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
