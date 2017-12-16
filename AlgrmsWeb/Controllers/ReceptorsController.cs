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
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptor receptor = await db.Receptors.FindAsync(id);
            if (receptor == null)
            {
                return HttpNotFound();
            }
            return View(receptor);
        }

        // GET: Receptors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receptors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "receptor_code,first_name,last_name,other_name,company_name,dob,gender,receptor_type,addresse,city,state,country,background,nature_of_business,area_of_business,company_size,created_at,updated_at")] Receptor receptor)
        {
            if (ModelState.IsValid)
            {
                db.Receptors.Add(receptor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(receptor);
        }

        // GET: Receptors/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptor receptor = await db.Receptors.FindAsync(id);
            if (receptor == null)
            {
                return HttpNotFound();
            }
            return View(receptor);
        }

        // POST: Receptors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "receptor_code,first_name,last_name,other_name,company_name,dob,gender,receptor_type,addresse,city,state,country,background,nature_of_business,area_of_business,company_size,created_at,updated_at")] Receptor receptor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receptor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(receptor);
        }

        // GET: Receptors/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receptor receptor = await db.Receptors.FindAsync(id);
            if (receptor == null)
            {
                return HttpNotFound();
            }
            return View(receptor);
        }

        // POST: Receptors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Receptor receptor = await db.Receptors.FindAsync(id);
            db.Receptors.Remove(receptor);
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
