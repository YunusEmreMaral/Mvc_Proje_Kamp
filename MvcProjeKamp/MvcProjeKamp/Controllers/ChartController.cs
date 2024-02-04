using DataAccessLayer.Concrete;
using MvcProjeKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            using (var context = new Context())
            {
                var categoryData = context.Categories.Select(category => new CategoryClass
                {
                    CategoryName = category.CategoryName,
                    CategoryCount = category.Headings.Count()
                }).ToList();

                return Json(categoryData, JsonRequestBehavior.AllowGet);
            }

        }

    }
}