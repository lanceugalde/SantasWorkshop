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
    public class ToyController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Toy/

        public ActionResult Index()
        {
            var toy = db.Toy.Include(t => t.MadeIn);
            return View(toy.ToList());
        }

        //
        // GET: /Toy/Details/5

        public ActionResult Details(int id = 0)
        {
            Toy toy = db.Toy.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        //
        // GET: /Toy/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name");
            return View();
        }

        //
        // POST: /Toy/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Toy toy)
        {
            if (ModelState.IsValid)
            {
                db.Toy.Add(toy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", toy.DepartmentId);
            return View(toy);
        }

        //
        // GET: /Toy/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Toy toy = db.Toy.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", toy.DepartmentId);
            return View(toy);
        }

        //
        // POST: /Toy/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Toy toy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", toy.DepartmentId);
            return View(toy);
        }

        //
        // GET: /Toy/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Toy toy = db.Toy.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }

        //
        // POST: /Toy/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toy toy = db.Toy.Find(id);
            db.Toy.Remove(toy);
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