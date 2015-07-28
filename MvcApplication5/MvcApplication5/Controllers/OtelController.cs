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
    public class OtelController : Controller
    {
        private TravelScannerEntities db = new TravelScannerEntities();

        //
        // GET: /Otel/

        public ActionResult Index()
        {
            var otel = db.Otel.Include(o => o.Firmalar);
            return PartialView(otel.ToList());
        }
        public ActionResult _List()
        {
            var otel = db.Otel.Include(o => o.Firmalar);
            return PartialView(otel.ToList());
        }
        //
        // GET: /Otel/Details/5

        public ActionResult Details(int id = 0)
        {
            Otel otel = db.Otel.Find(id);
            if (otel == null)
            {
                return HttpNotFound();
            }
            return PartialView(otel);
        }

        //
        // GET: /Otel/Create

        public ActionResult Create()
        {
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi");
            return PartialView();
        }

        //
        // POST: /Otel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Otel otel)
        {
            if (ModelState.IsValid)
            {
                db.Otel.Add(otel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", otel.firmaId);
            return PartialView(otel);
        }

        //
        // GET: /Otel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Otel otel = db.Otel.Find(id);
            if (otel == null)
            {
                return HttpNotFound();
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", otel.firmaId);
            return PartialView(otel);
        }

        //
        // POST: /Otel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Otel otel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", otel.firmaId);
            return PartialView(otel);
        }

        //
        // GET: /Otel/Delete/5

        public ActionResult Delete(int id )
        {
            Otel otel = db.Otel.Find(id);
            if (otel == null)
            {
                return HttpNotFound();
            }
            var otel1 = db.Otel.Include(o => o.Firmalar);
            db.Otel.Remove(otel);
            db.SaveChanges();
            return PartialView("_List",otel1.ToList());
        }

        //
        // POST: /Otel/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Otel otel = db.Otel.Find(id);
            db.Otel.Remove(otel);
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