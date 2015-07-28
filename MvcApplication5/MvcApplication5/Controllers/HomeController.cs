using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;



namespace MvcApplication5.Controllers
{
    public class HomeController : Controller
    {
        private TravelScannerEntities db = new TravelScannerEntities();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


            return View();
        }
        public ActionResult IndexFirmalar()
        {
            var firmalar = db.Firmalar.Include(f => f.Sehir);
            return View(firmalar.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        //
        // GET: /Firma/Details/5

        public ActionResult Details(int id )
        {
            Firmalar firmalar = db.Firmalar.Single(f=>f.firmaId==id);
            ViewBag.yorumlar = db.Yorum.Where(f => f.firmaId == id);
         
            if (firmalar == null)
            {
                return HttpNotFound();
            }
            return View("FirmaYorum",firmalar);

        }
        public ActionResult Create(int id,String yorm)
        {
            Firmalar firmalar = db.Firmalar.Single(f => f.firmaId == id);
            db.Yorum.Add(new Yorum(yorm, id));
            db.SaveChanges();
            ViewBag.yorumlar = db.Yorum.Where(f => f.firmaId == id);
            return View("FirmaYorum",firmalar);
        }

        public ActionResult Delete(int id = 0,int fid=0)
        {
            Yorum yorum = db.Yorum.Find(id);
            Firmalar firmalar = db.Firmalar.Single(f => f.firmaId == fid);
            db.Yorum.Remove(yorum);
            db.SaveChanges();
            ViewBag.yorumlar = db.Yorum.Where(f => f.firmaId == fid);

            return View("FirmaYorum",firmalar);
           
         
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult getUcus()
        {
            var dbResult = db.Ucus.ToList();
            var Ucus = (from u in dbResult
                        select new
                        {
                            u.ucusId,
                            u.saat,
                            u.fiyat,
                            u.ucusSuresi,
                            u.tarih,
                            u.model,
                            u.mesafe,
                            u.Sehir.sehirAdi,
                            u.varis,
                            u.Firmalar.firmaAdi

                        });
            return Json(Ucus, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getSehir()
        {
            var dbResult = db.Sehir.ToList();

            dbResult = dbResult.OrderBy(x => x.sehirId).ToList();
            var shr = (from s in dbResult
                       select new
                       {
                           s.sehirId,
                           s.sehirAdi
                       });
            //var shr="a";
            //for (int i = 0; i <= dbResult.Count; i++)
            //{
            //    shr = dbResult[i].sehirAdi;
            //    shr = (dbResult[i].sehirId).ToString();

            //    //var shr= select new {dbResult[i].sehirId,
            //    //                     dbResult[i].sehirAdi};
            //}


            ////var Sehir = from it in db.Sehir
            ////            where it.sehirId.Equals(5)
            ////            select it;
            ////Sehir.ToString();

            //var shr = db.Database.SqlQuery<String>("select sehirAdi from TravelScanner.Sehir").ToList();

            //var Sehir = from u in db.Sehir
            //              select u.sehirAdi;
            return Json(shr, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ucusAra(int kalkis, int varis, DateTime gidis)
        {

            var result = from it in db.Ucus
                         where it.Sehir.Equals(kalkis) && it.Sehir1.Equals(varis) && it.tarih.Equals(gidis)
                         orderby it.fiyat
                         select it;
             return PartialView("_List",result);
            
        }
      /*  public ActionResult _List()
        {
            var ucus = db.Ucus.Include(u => u.Firmalar).Include(u => u.Sehir).Include(u => u.Sehir1);
           
        }*/
    }
}
