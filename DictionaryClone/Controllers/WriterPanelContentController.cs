using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
namespace DictionaryClone.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterLoginDal());
        Context c = new Context();

        public ActionResult MyContent(string p, int a = 1)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo =writerLoginManager.GetList().Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalue = contentManager.GetListByWriter(writeridinfo).ToPagedList(a,3);
            return View(contentvalue);
        }
        [HttpGet]
        public ActionResult ContentAdd(int id)
        {
            ViewBag.d = id;
            ViewBag.e = id;
            return View();
        }

        [HttpPost]
        public ActionResult ContentAdd(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = writerLoginManager.GetList().Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            contentManager.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}