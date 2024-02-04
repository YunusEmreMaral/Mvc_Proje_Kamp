using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace MvcProjeKamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());

        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Dosya adını oluştur
                string fileExtension = Path.GetExtension(file.FileName); // Dosya uzantısını al
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName); // Uzantısız dosya adını al
                string desiredFileName = "prefix_" + fileNameWithoutExtension + "_" + Guid.NewGuid() + fileExtension;

                // Dosyayı kaydet
                string relativePath = "~/AdminLTE-3.0.4/images/" + desiredFileName;
                string physicalPath = Server.MapPath(relativePath);
                file.SaveAs(physicalPath);

                // Veritabanına ekle
                var image = new ImageFile
                {
                    ImageName = desiredFileName,
                    ImagePath = "/AdminLTE-3.0.4/images/" + desiredFileName
                };
                ifm.ImageAdd(image);
            }

            return RedirectToAction("Index");
        }


    }
}