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
    public class VisitorController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Visitor/

        public ActionResult Index()
        {
            var visitor = db.Visitor.Include(v => v.Home).Include(v => v.LastVisited);
            return View(visitor.ToList());
        }

        //
        // GET: /Visitor/Details/5

        public ActionResult Details(int id = 0)
        {
            Visitor visitor = db.Visitor.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        //
        // GET: /Visitor/Create

        public ActionResult Create()
        {
            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress");
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name");
            return View();
        }

        //
        // POST: /Visitor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Visitor.Add(visitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress", visitor.HouseId);
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name", visitor.WorkshopId);
            return View(visitor);
        }

        //
        // GET: /Visitor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Visitor visitor = db.Visitor.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress", visitor.HouseId);
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name", visitor.WorkshopId);
            return View(visitor);
        }

        //
        // POST: /Visitor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress", visitor.HouseId);
            ViewBag.WorkshopId = new SelectList(db.Workshop, "WorkshopId", "Name", visitor.WorkshopId);
            return View(visitor);
        }

        //
        // GET: /Visitor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Visitor visitor = db.Visitor.Find(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        //
        // POST: /Visitor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitor visitor = db.Visitor.Find(id);
            db.Visitor.Remove(visitor);
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