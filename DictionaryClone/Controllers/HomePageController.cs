using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;

namespace DictionaryClone.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headinglist = headingManager.GetList();
            return View(headinglist);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentlist = contentManager.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}