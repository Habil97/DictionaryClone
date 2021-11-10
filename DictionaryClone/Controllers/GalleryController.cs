using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;

namespace DictionaryClone.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imageManager = new ImageFileManager(new EfImageFileDal());

        [Authorize]
        public ActionResult Index()
        {
            var files = imageManager.GetList();
            return View(files);
        }
    }
}