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
    public class YorumController : Controller
    {
        private TravelScannerEntities db = new TravelScannerEntities();

        //
        // GET: /Yorum/

        public ActionResult Index()
        {
            var yorum = db.Yorum.Include(y => y.Firmalar);
            return View(yorum.ToList());
        }
        public ActionResult _List()
        {
            var yorum = db.Yorum.Include(y => y.Firmalar);
            return PartialView(yorum.ToList());
        }

        //
        // GET: /Yorum/Details/5

        public ActionResult Details(int id = 0)
        {
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        //
        // GET: /Yorum/Create

        public ActionResult Create()
        {
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi");
            return PartialView();
        }

        //
        // POST: /Yorum/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Yorum.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", yorum.firmaId);
            return View(yorum);
        }

        //
        // GET: /Yorum/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", yorum.firmaId);
            return View(yorum);
        }

        //
        // POST: /Yorum/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", yorum.firmaId);
            return View(yorum);
        }

        //
        // GET: /Yorum/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        //
        // POST: /Yorum/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum yorum = db.Yorum.Find(id);
            db.Yorum.Remove(yorum);
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