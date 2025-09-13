using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya> ();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var shesap=repo.Find(x=>x.ID == id);
            return View(shesap);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya s)
        {
            var shesap = repo.Find(x => x.ID == s.ID);
            shesap.Ad = s.Ad;
            shesap.Durum = true;
            shesap.Link = s.Link;
            shesap.ikon = s.ikon;
            repo.TUpdate(shesap);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var shesap = repo.Find(x => x.ID == id);
            shesap.Durum = false;
            repo.TUpdate(shesap);
            return RedirectToAction("Index");
        }
    }
}