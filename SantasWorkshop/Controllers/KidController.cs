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
    public class KidController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Kid/

        public ActionResult Index()
        {
            var kid = db.Kid.Include(k => k.Home);
            return View(kid.ToList());
        }

        public ActionResult SantasList()
        {
            var kid = db.Kid.Include(k => k.Home);
            return View(kid.ToList());
        }

        //
        // GET: /Kid/Details/5

        public ActionResult Details(int id = 0)
        {
            Kid kid = db.Kid.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            return View(kid);
        }

        //
        // GET: /Kid/Create

        public ActionResult Create()
        {
            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress");
            return View();
        }

        //
        // POST: /Kid/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kid kid)
        {
            if (ModelState.IsValid)
            {
                db.Kid.Add(kid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress", kid.HouseId);
            return View(kid);
        }

        //
        // GET: /Kid/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kid kid = db.Kid.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress", kid.HouseId);
            return View(kid);
        }

        //
        // POST: /Kid/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kid kid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseId = new SelectList(db.House, "HouseId", "StreetAddress", kid.HouseId);
            return View(kid);
        }

        //
        // GET: /Kid/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kid kid = db.Kid.Find(id);
            if (kid == null)
            {
                return HttpNotFound();
            }
            return View(kid);
        }

        //
        // POST: /Kid/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kid kid = db.Kid.Find(id);
            db.Kid.Remove(kid);
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