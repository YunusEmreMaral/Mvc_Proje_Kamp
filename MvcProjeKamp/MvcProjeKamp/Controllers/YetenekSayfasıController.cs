using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class YetenekSayfasıController : Controller
    {
        private Context _context; // Veritabanı bağlantısı

        public YetenekSayfasıController()
        {
            _context = new Context(); // Veritabanı bağlantısı oluşturuluyor
        }

        // GET: YetenekSayfası
        public ActionResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }

        public ActionResult Sil(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Arttir(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill != null)
            {
                skill.IncreaseSkillValue(1); // Değeri 1 artır
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Azalt(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill != null)
            {
                skill.DecreaseSkillValue(1); // Değeri 1 azalt
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

         
    }
}