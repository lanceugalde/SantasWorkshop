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
    public class PresentController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Present/

        public ActionResult Index()
        {
            var present = db.Present.Include(p => p.Contents).Include(p => p.Wrapping).Include(p => p.Recipient);
            return View(present.ToList());
        }

        public ActionResult PresentReport()
        {
            var present = db.Present.Include(p => p.Contents).Include(p => p.Wrapping).Include(p => p.Recipient);
            return View(present.ToList());
        }

        public ActionResult PopularWrapping()
        {
            var present = db.Present.Include(p => p.Contents).Include(p => p.Wrapping).Include(p => p.Recipient);
            return View(present.ToList());
        }

        public ActionResult PresentsForKids()
        {
            var present = db.Present.Include(p => p.Contents).Include(p => p.Wrapping).Include(p => p.Recipient);
            return View(present.ToList());
        }

        //
        // GET: /Present/Details/5

        public ActionResult Details(int id = 0)
        {
            Present present = db.Present.Find(id);
            if (present == null)
            {
                return HttpNotFound();
            }
            return View(present);
        }

        //
        // GET: /Present/Create

        public ActionResult Create()
        {
            ViewBag.ToyId = new SelectList(db.Toy, "ToyId", "Name");
            ViewBag.WrappingPaperId = new SelectList(db.WrappingPaper, "WrappingPaperId", "Name");
            ViewBag.KidId = new SelectList(db.Kid, "KidId", "FirstName");
            return View();
        }

        //
        // POST: /Present/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Present present)
        {
            if (ModelState.IsValid)
            {
                db.Present.Add(present);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ToyId = new SelectList(db.Toy, "ToyId", "Name", present.ToyId);
            ViewBag.WrappingPaperId = new SelectList(db.WrappingPaper, "WrappingPaperId", "Name", present.WrappingPaperId);
            ViewBag.KidId = new SelectList(db.Kid, "KidId", "FirstName", present.KidId);
            return View(present);
        }

        //
        // GET: /Present/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Present present = db.Present.Find(id);
            if (present == null)
            {
                return HttpNotFound();
            }
            ViewBag.ToyId = new SelectList(db.Toy, "ToyId", "Name", present.ToyId);
            ViewBag.WrappingPaperId = new SelectList(db.WrappingPaper, "WrappingPaperId", "Name", present.WrappingPaperId);
            ViewBag.KidId = new SelectList(db.Kid, "KidId", "FirstName", present.KidId);
            return View(present);
        }

        //
        // POST: /Present/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Present present)
        {
            if (ModelState.IsValid)
            {
                db.Entry(present).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ToyId = new SelectList(db.Toy, "ToyId", "Name", present.ToyId);
            ViewBag.WrappingPaperId = new SelectList(db.WrappingPaper, "WrappingPaperId", "Name", present.WrappingPaperId);
            ViewBag.KidId = new SelectList(db.Kid, "KidId", "FirstName", present.KidId);
            return View(present);
        }

        //
        // GET: /Present/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Present present = db.Present.Find(id);
            if (present == null)
            {
                return HttpNotFound();
            }
            return View(present);
        }

        //
        // POST: /Present/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Present present = db.Present.Find(id);
            db.Present.Remove(present);
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