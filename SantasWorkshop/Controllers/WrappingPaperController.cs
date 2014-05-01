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
    public class WrappingPaperController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /WrappingPaper/

        public ActionResult Index()
        {
            return View(db.WrappingPaper.ToList());
        }

        //
        // GET: /WrappingPaper/Details/5

        public ActionResult Details(int id = 0)
        {
            WrappingPaper wrappingpaper = db.WrappingPaper.Find(id);
            if (wrappingpaper == null)
            {
                return HttpNotFound();
            }
            return View(wrappingpaper);
        }

        //
        // GET: /WrappingPaper/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WrappingPaper/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WrappingPaper wrappingpaper)
        {
            if (ModelState.IsValid)
            {
                db.WrappingPaper.Add(wrappingpaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wrappingpaper);
        }

        //
        // GET: /WrappingPaper/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WrappingPaper wrappingpaper = db.WrappingPaper.Find(id);
            if (wrappingpaper == null)
            {
                return HttpNotFound();
            }
            return View(wrappingpaper);
        }

        //
        // POST: /WrappingPaper/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WrappingPaper wrappingpaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wrappingpaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wrappingpaper);
        }

        //
        // GET: /WrappingPaper/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WrappingPaper wrappingpaper = db.WrappingPaper.Find(id);
            if (wrappingpaper == null)
            {
                return HttpNotFound();
            }
            return View(wrappingpaper);
        }

        //
        // POST: /WrappingPaper/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WrappingPaper wrappingpaper = db.WrappingPaper.Find(id);
            db.WrappingPaper.Remove(wrappingpaper);
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