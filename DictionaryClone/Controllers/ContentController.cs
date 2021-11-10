using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;

namespace DictionaryClone.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentReport()
        {
            var contentvalue = contentManager.GetListReport();
            return View(contentvalue);
        }

        //Arama İşlemi
        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetList(p);
            return View(values);
        }
  
        public ActionResult ContentByHeading(int id)
        {
            var contentvalue = contentManager.GetListByHeadingID(id);
            return View(contentvalue);
        }
    }
}