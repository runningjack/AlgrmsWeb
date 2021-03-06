﻿using System;
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
    public class RevenuesController : Controller
    {
        private AlgrmsWebContext db = new AlgrmsWebContext();

        // GET: Revenues
        public async Task<ActionResult> Index()
        {
            
            return View(await db.Revenues.ToListAsync());
        }

        // GET: Revenues/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = await db.Revenues.FindAsync(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // GET: Revenues/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = db.TaxCategories.Select(c => new SelectListItem
            {
                Value = c.category_code,
                Text = c.title

            });

            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });
           
            ViewBag.TCategory = items;
            ViewBag.IssuersList = issuers;
            return View();
        }

        // POST: Revenues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "issuer_code,category_code,revenue_code,revenue_name,description,frequency,amount,rate,created_at,updated_at")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                db.Revenues.Add(revenue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(revenue);
        }

        // GET: Revenues/Edit/5
        public async Task<ActionResult> Edit(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = await db.Revenues.Where(r => r.revenue_code == code).FirstOrDefaultAsync();
            if (revenue == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SelectListItem> items = db.TaxCategories.Select(c => new SelectListItem
            {
                Value = c.category_code,
                Text = c.title

            });

            IEnumerable<SelectListItem> issuers = db.Issuers.Select(iss => new SelectListItem { Value = iss.issuer_code, Text = iss.issuer_name });

            ViewBag.TCategory = items;
            ViewBag.IssuersList = issuers;

            return View(revenue);
        }

        // POST: Revenues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "issuer_code,category_code,revenue_code,revenue_name,description,frequency,amount,rate,created_at,updated_at")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revenue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(revenue);
        }

        // GET: Revenues/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = await db.Revenues.FindAsync(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // POST: Revenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Revenue revenue = await db.Revenues.FindAsync(id);
            db.Revenues.Remove(revenue);
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
