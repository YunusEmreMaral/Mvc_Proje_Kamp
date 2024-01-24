using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class istatistikController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.ToplamKategoriSayisi = db.Categories.Count();

            ViewBag.YazilimKategorisiBaslikSayisi = db.Headings
                .Where(b => b.Category.CategoryName == "yazılım")
                .Count();

            ViewBag.AHarfiliYazarSayisi = db.Headings
                .Where(b => b.Writer.WriterName.Contains("a"))
                .Select(b => b.Writer.WriterName)
                .Distinct()
                .Count();

            ViewBag.EnFazlaBasligaSahipKategoriAdi = db.Categories
                .OrderByDescending(k => k.Headings.Count)
                .Select(k => k.CategoryName)
                .FirstOrDefault();

            ViewBag.DurumFarki = db.Categories
                .GroupBy(k => k.CategoryStatus)
                .Select(g => new
                {
                    Durum = g.Key,
                    KategoriSayisi = g.Count()
                })
                .ToDictionary(g => g.Durum, g => g.KategoriSayisi);

            return View();

        }
    }
}