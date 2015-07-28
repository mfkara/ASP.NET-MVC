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
    public class UcusController : Controller
    {
        private TravelScannerEntities db = new TravelScannerEntities();

        //
        // GET: /Ucus/

        public ActionResult Index()
        {   // bu satırda db.Ucus.Include(u => u.Firmalar) ile foreing key olan firmaların kontrolu yapılıyor.
            //kodun devamında aynı foreing key sorguları tablodaki kalkis varis içinde yapılıp liste şeklinde html tarafına gönderiliyor
            var ucus = db.Ucus.Include(u => u.Firmalar).Include(u => u.Sehir).Include(u => u.Sehir1);
            return View(ucus.ToList());//bu kod fonksiyonlar aynı isimdeki view'a ucus listesini göndermektedir.
            //Diger bir kullanım şekli ise view("gitmesini_İstediğimiz_view") ve view("gitmesini_İstediğimiz_view",gonderilecek_veri)
        }
        public ActionResult _List()
        {
            var ucus = db.Ucus.Include(u => u.Firmalar).Include(u => u.Sehir).Include(u => u.Sehir1);
            return PartialView(ucus.ToList());
            //_List isimli PartialView a döner
            //PartialView ("gitmesini_İstediğimiz_Partialview")vePartialView("gitmesini_İstediğimiz_Partialview",gonderilecek_veri)
            //Şeklinde de gönderilebilir

        }
        //
        // GET: /Ucus/Details/5

        public ActionResult Details(int id = 0)
        {
            Ucus ucus = db.Ucus.Find(id);//Ucus tablosunun içinden eşleşen id li veriyi ucus nesnesi olarak alıyoruz
            if (ucus == null)
            {
                return HttpNotFound();
            }
            return PartialView(ucus);
        }

        //
        // GET: /Ucus/Create

        public ActionResult Create()
        {
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi");
            ViewBag.kalkis = new SelectList(db.Sehir, "sehirId", "sehirAdi");
            //veri tabanındaki toplalardan Id ye göre şehir adları alınıp ViewBag içine atılıyor Buradaki amaç html tafarına geçildiğinde
            //oluşturulacak dropdownlist veya combobox lar için verileri hazırlamak
            ViewBag.varis = new SelectList(db.Sehir, "sehirId", "sehirAdi");
           
            return PartialView();
        }

        //
        // POST: /Ucus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ucus ucus)
        {
            if (ucus!=null)
            {
                db.Ucus.Add(ucus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", ucus.firmaId);
            ViewBag.kalkis = new SelectList(db.Sehir, "sehirId", "sehirAdi", ucus.kalkis);
            ViewBag.varis = new SelectList(db.Sehir, "sehirId", "sehirAdi", ucus.varis);
            return PartialView(ucus);
        }

        //
        // GET: /Ucus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ucus ucus = db.Ucus.Find(id);
            if (ucus == null)
            {
                return HttpNotFound();
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", ucus.firmaId);
            ViewBag.kalkis = new SelectList(db.Sehir, "sehirId", "sehirAdi", ucus.kalkis);
            ViewBag.varis = new SelectList(db.Sehir, "sehirId", "sehirAdi", ucus.varis);
            return PartialView(ucus);
        }

        //
        // POST: /Ucus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ucus ucus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucus).State = EntityState.Modified;
                //verideki değişikliği sorgulanıp kaydediliyor
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.firmaId = new SelectList(db.Firmalar, "firmaId", "firmaAdi", ucus.firmaId);
            ViewBag.kalkis = new SelectList(db.Sehir, "sehirId", "sehirAdi", ucus.kalkis);
            ViewBag.varis = new SelectList(db.Sehir, "sehirId", "sehirAdi", ucus.varis);
            return PartialView(ucus);
        }

        //
        // GET: /Ucus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ucus ucus = db.Ucus.Find(id);
            if (ucus == null)
            {
                return HttpNotFound();
            }
            var ucus1 = db.Ucus.Include(u => u.Firmalar).Include(u => u.Sehir).Include(u => u.Sehir1);
            //ucus nesnesi silindikten sonra listeyi guncelleyerek yeni bir ucus1 listesi geri döndürülüyor
            db.Ucus.Remove(ucus);
            db.SaveChanges();
            return PartialView("_List",ucus1.ToList());
        }

        //
        // POST: /Ucus/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ucus ucus = db.Ucus.Find(id);
            db.Ucus.Remove(ucus);
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