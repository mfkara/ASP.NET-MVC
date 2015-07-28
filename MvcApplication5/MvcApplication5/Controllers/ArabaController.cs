using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;

namespace MvcApplication5.Controllers
{
    public class ArabaController : Controller
    {
        private TravelScannerEntities db = new TravelScannerEntities();

        //
        // GET: /Araba/

        public ActionResult Index()
        {
            var araba = db.Araba.Include(a => a.Firmalar);
            return View(araba.ToList());
        }
        public ActionResult _List()
        {
            var araba = db.Araba.Include(a => a.Firmalar);
            return PartialView(araba.ToList());
        }

        //
        // GET: /Araba/Details/5

        public ActionResult Details(int id = 0)
        {
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return PartialView(araba);
        }

        //
        // GET: /Araba/Create

        public ActionResult Create()
        {
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi");
            return PartialView();
        }

        //
        // POST: /Araba/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Araba.Add(araba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", araba.firmaId);
            return PartialView(araba);
        }

        //
        // GET: /Araba/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", araba.firmaId);
            return PartialView(araba);
        }

        //
        // POST: /Araba/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(araba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", araba.firmaId);
            return PartialView(araba);
        }

        //
        // GET: /Araba/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            var araba1 = db.Araba.Include(a => a.Firmalar);
            db.Araba.Remove(araba);
            db.SaveChanges();
            return PartialView("_List",araba1.ToList());
        }

        //
        // POST: /Araba/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Araba araba = db.Araba.Find(id);
            db.Araba.Remove(araba);
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