using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DictionaryClone.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {

        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterLoginDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer p)
        {
            var writeruserinfo = writerLoginManager.GetList().FirstOrDefault(x => x.WriterMail == p.WriterMail
           && x.WriterPassword == p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
            public ActionResult LogOut()
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Headings", "HomePage");
            }
        }
    }
