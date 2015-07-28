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
    public class FirmaController : Controller
    {
        private TravelScannerEntities db = new TravelScannerEntities();

        //
        // GET: /Firma/

        public ActionResult Index()
        {
            var firmalar = db.Firmalar.Include(f => f.Sehir);
            return PartialView(firmalar.ToList());
        }
        public ActionResult _List()
        {
            var firmalar = db.Firmalar.Include(f => f.Sehir);
            return PartialView(firmalar.ToList());
        }

        //
        // GET: /Firma/Details/5

        public ActionResult Details(int id = 0)
        {
            Firmalar firmalar = db.Firmalar.Find(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return PartialView(firmalar);
        }

        //
        // GET: /Firma/Create

        public ActionResult Create()
        {
            ViewBag.sehirId = new SelectList(db.Sehir, "sehirId", "sehirAdi");
            return PartialView();
        }

        //
        // POST: /Firma/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Firmalar firmalar)
        {
            if (ModelState.IsValid)
            {
                db.Firmalar.Add(firmalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sehirId = new SelectList(db.Sehir, "sehirId", "sehirAdi", firmalar.sehirId);
            return PartialView(firmalar);
        }

        //
        // GET: /Firma/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Firmalar firmalar = db.Firmalar.Find(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            ViewBag.sehirId = new SelectList(db.Sehir, "sehirId", "sehirAdi", firmalar.sehirId);
            return PartialView(firmalar);
        }

        //
        // POST: /Firma/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Firmalar firmalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firmalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sehirId = new SelectList(db.Sehir, "sehirId", "sehirAdi", firmalar.sehirId);
            return PartialView(firmalar);
        }

        //
        // GET: /Firma/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Firmalar firmalar = db.Firmalar.Find(id);
            if (firmalar == null)
            {
                return HttpNotFound();
            }
              var firmalar1 = db.Firmalar.Include(f => f.Sehir);
            db.Firmalar.Remove(firmalar);
            db.SaveChanges();
            return PartialView("_List",firmalar1.ToList());
        }

        //
        // POST: /Firma/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firmalar firmalar = db.Firmalar.Find(id);
            db.Firmalar.Remove(firmalar);
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