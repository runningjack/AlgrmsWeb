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
    public class ReceptorsController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: Receptors
        public async Task<ActionResult> Index()
        {
            return View(await db.Receptors.ToListAsync());
        }

        // GET: Receptors/Details/5
        public async Task<ActionResult> Details(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptor receptor = await db.Receptors.Where(r => r.receptor_code == code).FirstOrDefaultAsync();
            if (receptor == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> items = db.Revenues.Select(z => new SelectListItem { Value = z.revenue_code, Text = z.revenue_name });
            ViewBag.revenues = items;
            return View(receptor);
        }

        // GET: Receptors/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> agents = db.TaxAgents.Select(t => new SelectListItem { Value = t.agent_code, Text = t.first_name + " " + t.last_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.agents = agents;
            return View();
        }

        // POST: Receptors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "issuer_code,agent_code,receptor_code,first_name,last_name,other_name,company_name,dob,gender,receptor_type,addresse,city,state,country,background,nature_of_business,area_of_business,company_size,created_at,updated_at")] Receptor receptor)
        {
            if (ModelState.IsValid)
            {
                db.Receptors.Add(receptor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> agents = db.TaxAgents.Select(t => new SelectListItem { Value = t.agent_code, Text = t.first_name + " " + t.last_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.agents = agents;
            return View(receptor);
        }

        // GET: Receptors/Edit/5
        public async Task<ActionResult> Edit(string code  ="")
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptor receptor = await db.Receptors.Where(r => r.receptor_code == code).FirstOrDefaultAsync(); //await db.Receptors.FindAsync(id);
            if (receptor == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> agents = db.TaxAgents.Select(t => new SelectListItem { Value = t.agent_code, Text = t.first_name + " " + t.last_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.agents = agents;
            return View(receptor);
        }

        // POST: Receptors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "issuer_code,agent_code,receptor_code,first_name,last_name,other_name,company_name,dob,gender,receptor_type,addresse,city,state,country,background,nature_of_business,area_of_business,company_size,created_at,updated_at")] Receptor receptor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receptor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> items = db.Zones.Select(z => new SelectListItem { Value = z.state_name, Text = z.state_name });
            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
            IEnumerable<SelectListItem> agents = db.TaxAgents.Select(t => new SelectListItem { Value = t.agent_code, Text = t.first_name+" "+t.last_name });
            ViewBag.IssuersList = issuers;
            ViewBag.zones = items;
            ViewBag.agents = agents;
            return View(receptor);
        }

        // GET: Receptors/Delete/5
        public async Task<ActionResult> Delete(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptor receptor = await db.Receptors.Where(r => r.receptor_code == code).FirstOrDefaultAsync(); // await db.Receptors.FindAsync(id);
            if (receptor == null)
            {
                return HttpNotFound();
            }
            return View(receptor);
        }

        // POST: Receptors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string code)
        {
            Receptor receptor = await db.Receptors.Where(r => r.receptor_code == code).FirstOrDefaultAsync();
            db.Receptors.Remove(receptor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<PartialViewResult> AddRevenueToReceptor(string revenueCode,string receptorCode)
        {
            Receptor recept = await db.Receptors.Where(r => r.receptor_code == receptorCode).FirstOrDefaultAsync();
            Revenue revenue = await db.Revenues.Where(r => r.revenue_code == revenueCode).FirstOrDefaultAsync();
            //revenue.receptors.Add(recept);
            recept.revenues.Add(revenue);
            db.SaveChanges();
            return PartialView("_ListReceptorRevenueTable",recept);
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
