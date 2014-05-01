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
    public class ElfController : Controller
    {
        private SantaContext db = new SantaContext();

        //
        // GET: /Elf/

        public ActionResult Index()
        {
            var elf = db.Elf.Include(e => e.Workplace);
            return View(elf.ToList());
        }

        //
        // GET: /Elf/Details/5

        public ActionResult Details(int id = 0)
        {
            Elf elf = db.Elf.Find(id);
            if (elf == null)
            {
                return HttpNotFound();
            }
            return View(elf);
        }

        //
        // GET: /Elf/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name");
            return View();
        }

        //
        // POST: /Elf/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Elf elf)
        {
            if (ModelState.IsValid)
            {
                db.Elf.Add(elf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", elf.DepartmentId);
            return View(elf);
        }

        //
        // GET: /Elf/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Elf elf = db.Elf.Find(id);
            if (elf == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", elf.DepartmentId);
            return View(elf);
        }

        //
        // POST: /Elf/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Elf elf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "Name", elf.DepartmentId);
            return View(elf);
        }

        //
        // GET: /Elf/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Elf elf = db.Elf.Find(id);
            if (elf == null)
            {
                return HttpNotFound();
            }
            return View(elf);
        }

        //
        // POST: /Elf/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elf elf = db.Elf.Find(id);
            db.Elf.Remove(elf);
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