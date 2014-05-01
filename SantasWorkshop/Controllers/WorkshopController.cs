using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantasWorkshop.Models;

namespace SantasWorkshop.Controllers
{
    public class WorkshopController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Workshop/

        public ActionResult Index()
        {
            return View(db.Workshop.ToList());
        }

        //
        // GET: /Workshop/Details/5

        public ActionResult Details(int id = 0)
        {
            Workshop workshop = db.Workshop.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        //
        // GET: /Workshop/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Workshop/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                db.Workshop.Add(workshop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workshop);
        }

        //
        // GET: /Workshop/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Workshop workshop = db.Workshop.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        //
        // POST: /Workshop/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workshop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workshop);
        }

        //
        // GET: /Workshop/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Workshop workshop = db.Workshop.Find(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        //
        // POST: /Workshop/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workshop workshop = db.Workshop.Find(id);
            db.Workshop.Remove(workshop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}