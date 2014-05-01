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
    public class ReindeerController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Reindeer/

        public ActionResult Index()
        {
            var reindeer = db.Reindeer.Include(r => r.Stable);
            return View(reindeer.ToList());
        }

        //
        // GET: /Reindeer/Details/5

        public ActionResult Details(int id = 0)
        {
            Reindeer reindeer = db.Reindeer.Find(id);
            if (reindeer == null)
            {
                return HttpNotFound();
            }
            return View(reindeer);
        }

        //
        // GET: /Reindeer/Create

        public ActionResult Create()
        {
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name");
            return View();
        }

        //
        // POST: /Reindeer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reindeer reindeer)
        {
            if (ModelState.IsValid)
            {
                db.Reindeer.Add(reindeer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name", reindeer.WorkshopId);
            return View(reindeer);
        }

        //
        // GET: /Reindeer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reindeer reindeer = db.Reindeer.Find(id);
            if (reindeer == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name", reindeer.WorkshopId);
            return View(reindeer);
        }

        //
        // POST: /Reindeer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reindeer reindeer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reindeer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name", reindeer.WorkshopId);
            return View(reindeer);
        }

        //
        // GET: /Reindeer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reindeer reindeer = db.Reindeer.Find(id);
            if (reindeer == null)
            {
                return HttpNotFound();
            }
            return View(reindeer);
        }

        //
        // POST: /Reindeer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reindeer reindeer = db.Reindeer.Find(id);
            db.Reindeer.Remove(reindeer);
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